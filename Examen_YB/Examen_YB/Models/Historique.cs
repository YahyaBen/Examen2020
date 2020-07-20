using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_YB.Models
{
    public class Historique
    {
        public int Id { get; set; }
        public DateTime DateEntree { get; set; }
        public DateTime DateSortie { get; set; }
        public virtual Hopital Hopital { get; set; }
        public int HopitalId { get; set; }
        public virtual Patient Patient { get; set; }
        public int PatientId { get; set; }

    }
}
