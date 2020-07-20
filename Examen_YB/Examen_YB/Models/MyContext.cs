using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_YB.Models
{
    public class MyContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Historique> Historiques { get; set; }
        public DbSet<Hopital> Hopitals { get; set; }
        public DbSet<Ville> Villes { get; set; }
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }
    }
}
