using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeManagementProject.Models
{
    public class Salle
    {
        public int SalleId { get; set; }

        public string Designation { get; set; }

        public int TypeSalleId { get; set; }

        public Salle salle { get; set; }
        public ICollection<Matiere> Matieres { get; set; }

    }
}