using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeManagementProject.Models
{
    public class Etudiant
    {
        public int EtudiantId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Adresse { get; set; }
        public string Email { get; set; }
        public int Tel { get; set; }
        public int ClasseId { get; set; }

        public Classe classe { get; set; }
        public ICollection<Absence> Absences { get; set; }


    }
}