using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Examen_YB.Models;

namespace Examen_YB.Controllers
{
    public class HopitalsController : Controller
    {
        private readonly MyContext _context;

        public HopitalsController(MyContext context)
        {
            _context = context;
        }

        // GET: Hopitals
        public async Task<IActionResult> Index()
        {
            var myContext = _context.Hopitals.Include(h => h.Ville);
            return View(await myContext.ToListAsync());
        }

        // GET: Hopitals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hopital = await _context.Hopitals
                .Include(h => h.Ville)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hopital == null)
            {
                return NotFound();
            }

            return View(hopital);
        }

        // GET: Hopitals/Create
        public IActionResult Create()
        {
            ViewData["VilleId"] = new SelectList(_context.Villes, "Id", "Libelle");
            return View();
        }

        // POST: Hopitals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Libelle,Fix,VilleId")] Hopital hopital)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hopital);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VilleId"] = new SelectList(_context.Villes, "Id", "Id", hopital.VilleId);
            return View(hopital);
        }

        // GET: Hopitals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hopital = await _context.Hopitals.FindAsync(id);
            if (hopital == null)
            {
                return NotFound();
            }
            ViewData["VilleId"] = new SelectList(_context.Villes, "Id", "Libelle", hopital.VilleId);
            return View(hopital);
        }

        // POST: Hopitals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Libelle,Fix,VilleId")] Hopital hopital)
        {
            if (id != hopital.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hopital);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HopitalExists(hopital.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["VilleId"] = new SelectList(_context.Villes, "Id", "Id", hopital.VilleId);
            return View(hopital);
        }

        // GET: Hopitals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hopital = await _context.Hopitals
                .Include(h => h.Ville)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hopital == null)
            {
                return NotFound();
            }

            return View(hopital);
        }

        // POST: Hopitals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hopital = await _context.Hopitals.FindAsync(id);
            _context.Hopitals.Remove(hopital);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HopitalExists(int id)
        {
            return _context.Hopitals.Any(e => e.Id == id);
        }
    }
}
