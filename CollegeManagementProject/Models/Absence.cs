using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeManagementProject.Models
{
    public class Absence
    {

        public int AbsenceId { get; set; }
        public DateTime DateAbsence { get; set; }
        public int EtudiantID { get; set; }
        public Etudiant Etudiant { get; set; }
        public ICollection<Etudiant> Etudiants { get; set; }


    }
}