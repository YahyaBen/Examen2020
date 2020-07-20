using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_YB.Models
{
    public class Patient
    {
        public int Id { get; set; }
        [Required] // Obligatoire
        [StringLength(30, MinimumLength = 3)] // pour {3,30}
        [DataType(DataType.Text)] // pour la forme [A-Z-a-z]
        public  string Nom { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string Prenom { get; set; }
        [Required]// Obligatoire
        [Range(0, Double.PositiveInfinity)] // Positive strict.
        public int Age { get; set; }
        public string Sexe { get; set; }
        public bool Deces { get; set; }
        public virtual ICollection<Historique> Historiques { get; set; }
    }
}
