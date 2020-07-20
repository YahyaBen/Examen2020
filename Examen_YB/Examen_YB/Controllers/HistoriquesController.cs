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
    public class HistoriquesController : Controller
    {
        private readonly MyContext _context;

        public HistoriquesController(MyContext context)
        {
            _context = context;
        }

        // GET: Historiques
        public async Task<IActionResult> Index()
        {
            var myContext = _context.Historiques.Include(h => h.Hopital).Include(h => h.Patient);
            return View(await myContext.ToListAsync());
        }

        // GET: Historiques/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historique = await _context.Historiques
                .Include(h => h.Hopital)
                .Include(h => h.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historique == null)
            {
                return NotFound();
            }

            return View(historique);
        }

        // GET: Historiques/Create
        public IActionResult Create()
        {
            ViewData["HopitalId"] = new SelectList(_context.Hopitals, "Id", "Libelle");
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "NomComplet");
            return View();
        }

        // POST: Historiques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateEntree,DateSortie,HopitalId,PatientId")] Historique historique)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historique);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HopitalId"] = new SelectList(_context.Hopitals, "Id", "Id", historique.HopitalId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Nom", historique.PatientId);
            return View(historique);
        }

        // GET: Historiques/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historique = await _context.Historiques.FindAsync(id);
            if (historique == null)
            {
                return NotFound();
            }
            ViewData["HopitalId"] = new SelectList(_context.Hopitals, "Id", "Id", historique.HopitalId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Nom", historique.PatientId);
            return View(historique);
        }

        // POST: Historiques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateEntree,DateSortie,HopitalId,PatientId")] Historique historique)
        {
            if (id != historique.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historique);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoriqueExists(historique.Id))
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
            ViewData["HopitalId"] = new SelectList(_context.Hopitals, "Id", "Id", historique.HopitalId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Nom", historique.PatientId);
            return View(historique);
        }

        // GET: Historiques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historique = await _context.Historiques
                .Include(h => h.Hopital)
                .Include(h => h.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historique == null)
            {
                return NotFound();
            }

            return View(historique);
        }

        // POST: Historiques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var historique = await _context.Historiques.FindAsync(id);
            _context.Historiques.Remove(historique);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistoriqueExists(int id)
        {
            return _context.Historiques.Any(e => e.Id == id);
        }
    }
}
