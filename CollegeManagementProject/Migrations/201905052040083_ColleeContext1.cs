namespace CollegeManagementProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColleeContext1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Absences", "EtudiantID", "dbo.Etudiants");
            DropIndex("dbo.Absences", new[] { "EtudiantID" });
            AddColumn("dbo.Absences", "Etudiant_EtudiantId", c => c.Int());
            AddColumn("dbo.Absences", "Etudiant_EtudiantId1", c => c.Int());
            AddColumn("dbo.Etudiants", "Absence_AbsenceId", c => c.Int());
            CreateIndex("dbo.Absences", "Etudiant_EtudiantId");
            CreateIndex("dbo.Absences", "Etudiant_EtudiantId1");
            CreateIndex("dbo.Etudiants", "Absence_AbsenceId");
            AddForeignKey("dbo.Etudiants", "Absence_AbsenceId", "dbo.Absences", "AbsenceId");
            AddForeignKey("dbo.Absences", "Etudiant_EtudiantId1", "dbo.Etudiants", "EtudiantId");
            AddForeignKey("dbo.Absences", "Etudiant_EtudiantId", "dbo.Etudiants", "EtudiantId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Absences", "Etudiant_EtudiantId", "dbo.Etudiants");
            DropForeignKey("dbo.Absences", "Etudiant_EtudiantId1", "dbo.Etudiants");
            DropForeignKey("dbo.Etudiants", "Absence_AbsenceId", "dbo.Absences");
            DropIndex("dbo.Etudiants", new[] { "Absence_AbsenceId" });
            DropIndex("dbo.Absences", new[] { "Etudiant_EtudiantId1" });
            DropIndex("dbo.Absences", new[] { "Etudiant_EtudiantId" });
            DropColumn("dbo.Etudiants", "Absence_AbsenceId");
            DropColumn("dbo.Absences", "Etudiant_EtudiantId1");
            DropColumn("dbo.Absences", "Etudiant_EtudiantId");
            CreateIndex("dbo.Absences", "EtudiantID");
            AddForeignKey("dbo.Absences", "EtudiantID", "dbo.Etudiants", "EtudiantId", cascadeDelete: true);
        }
    }
}
