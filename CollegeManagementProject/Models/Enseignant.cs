using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeManagementProject.Models
{
    public class Enseignant
    {
        public int EnseignantId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public int Tel { get; set; }
        public int MatiereId { get; set; }
        public Matiere Matiere { get; set; }
        public ICollection<Matiere> Matieres { get; set; }
    }
}