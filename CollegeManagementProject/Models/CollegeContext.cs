using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CollegeManagementProject.Models
{
    public class CollegeContext : DbContext
    {
        public CollegeContext()
       
            : base("name=DefaultConnection")
        {


        }

        public DbSet<Classe> Classe { get; set; }
        public DbSet<Niveau> Niveau { get; set; }
        public DbSet<Salle>  Salle { get; set; }
        public DbSet<Etudiant> Etudiant { get; set; }
        public DbSet<TypeSalle> TypeSalle { get; set; }
        public DbSet<Matiere> Matiere { get; set; }
        public DbSet<Enseignant> Enseignant { get; set; }

        public DbSet<Absence> Absence { get; set; }


    }
}