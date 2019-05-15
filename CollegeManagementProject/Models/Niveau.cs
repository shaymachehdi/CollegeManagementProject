using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeManagementProject.Models
{
    public class Niveau
    {
        public int NiveauId { get; set; }
        public string DesignationNiveau { get; set; }
        
        public ICollection<Classe> Classes { get; set; }
        public ICollection<Matiere> Matieres { get; set; }

    }
}