using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeManagementProject.Models
{
    public class Matiere
    {
        public int MatiereId { get; set; }
        public string Designation { get; set; }
        public DateTime DateMatiere { get; set; }
        public int EnseignantId { get; set; }
        public int SalleId { get; set; }
        public int NiveauId { get; set; }
        public Enseignant Enseignant { get; set; }
        public Niveau Niveau { get; set; }
        public Salle Salle { get; set; }
        public ICollection<Enseignant> Enseignants { get; set; }
    }
}