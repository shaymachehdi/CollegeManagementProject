using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeManagementProject.Models
{
    public class Classe
    {

        public int ClasseId { get; set; }
        public string Designation { get; set; }
        public int NiveauId { get; set; }
        public Niveau Niveau { get; set; }

        public ICollection<Etudiant> Etudiants { get; set; }
    }

}