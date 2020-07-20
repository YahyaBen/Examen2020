using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_YB.Models
{
    public class Ville
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public virtual ICollection<Hopital> Hopitals { get; set; }
    }
}
