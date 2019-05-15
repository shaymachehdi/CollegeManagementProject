namespace CollegeManagementProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CollegeContext2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Matieres",
                c => new
                    {
                        MatiereId = c.Int(nullable: false, identity: true),
                        Designation = c.String(),
                        DateMatiere = c.DateTime(nullable: false),
                        EnseignantId = c.Int(nullable: false),
                        SalleId = c.Int(nullable: false),
                        NiveauId = c.Int(nullable: false),
                        Enseignant_EnseignantId = c.Int(),
                        Enseignant_EnseignantId1 = c.Int(),
                    })
                .PrimaryKey(t => t.MatiereId)
                .ForeignKey("dbo.Enseignants", t => t.Enseignant_EnseignantId)
                .ForeignKey("dbo.Enseignants", t => t.Enseignant_EnseignantId1)
                .ForeignKey("dbo.Niveaux", t => t.NiveauId, cascadeDelete: true)
                .ForeignKey("dbo.Salles", t => t.SalleId, cascadeDelete: true)
                .Index(t => t.SalleId)
                .Index(t => t.NiveauId)
                .Index(t => t.Enseignant_EnseignantId)
                .Index(t => t.Enseignant_EnseignantId1);
            
            CreateTable(
                "dbo.Enseignants",
                c => new
                    {
                        EnseignantId = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Email = c.String(),
                        Tel = c.Int(nullable: false),
                        MatiereId = c.Int(nullable: false),
                        Matiere_MatiereId = c.Int(),
                    })
                .PrimaryKey(t => t.EnseignantId)
                .ForeignKey("dbo.Matieres", t => t.Matiere_MatiereId)
                .Index(t => t.Matiere_MatiereId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matieres", "SalleId", "dbo.Salles");
            DropForeignKey("dbo.Matieres", "NiveauId", "dbo.Niveaux");
            DropForeignKey("dbo.Matieres", "Enseignant_EnseignantId1", "dbo.Enseignants");
            DropForeignKey("dbo.Matieres", "Enseignant_EnseignantId", "dbo.Enseignants");
            DropForeignKey("dbo.Enseignants", "Matiere_MatiereId", "dbo.Matieres");
            DropIndex("dbo.Enseignants", new[] { "Matiere_MatiereId" });
            DropIndex("dbo.Matieres", new[] { "Enseignant_EnseignantId1" });
            DropIndex("dbo.Matieres", new[] { "Enseignant_EnseignantId" });
            DropIndex("dbo.Matieres", new[] { "NiveauId" });
            DropIndex("dbo.Matieres", new[] { "SalleId" });
            DropTable("dbo.Enseignants");
            DropTable("dbo.Matieres");
        }
    }
}
