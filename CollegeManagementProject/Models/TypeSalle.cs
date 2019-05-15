using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeManagementProject.Models
{
    public class TypeSalle


    {

        public int TypeSalleId { get; set; }

        public string Designation { get; set; }

        public ICollection<Salle> Salles { get; set; }
    }
}