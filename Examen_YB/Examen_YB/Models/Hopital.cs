using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_YB.Models
{
    public class Hopital
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Fix { get; set; }
        public virtual ICollection<Historique> Historiques { get; set; }
        public virtual Ville Ville { get; set; }
        public int VilleId { get; set; }
    }
}
