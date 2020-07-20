using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_YB.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public  string Nom { get; set; }
        public string Prenom { get; set; }
        public int Age { get; set; }
        public string Sexe { get; set; }
        public bool Deces { get; set; }
        public virtual ICollection<Historique> Historiques { get; set; }
    }
}
