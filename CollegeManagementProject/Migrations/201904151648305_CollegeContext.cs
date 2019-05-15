namespace CollegeManagementProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CollegeContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ClasseId = c.Int(nullable: false, identity: true),
                        Designation = c.String(),
                        NiveauId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClasseId)
                .ForeignKey("dbo.Niveaux", t => t.NiveauId, cascadeDelete: true)
                .Index(t => t.NiveauId);
            
            CreateTable(
                "dbo.Etudiants",
                c => new
                    {
                        EtudiantId = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        DateNaissance = c.DateTime(nullable: false),
                        Adresse = c.String(),
                        Email = c.String(),
                        Tel = c.Int(nullable: false),
                        ClasseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EtudiantId)
                .ForeignKey("dbo.Classes", t => t.ClasseId, cascadeDelete: true)
                .Index(t => t.ClasseId);
            
            CreateTable(
                "dbo.Niveaux",
                c => new
                    {
                        NiveauId = c.Int(nullable: false, identity: true),
                        DesignationNiveau = c.String(),
                    })
                .PrimaryKey(t => t.NiveauId);
            
            CreateTable(
                "dbo.Salles",
                c => new
                    {
                        SalleId = c.Int(nullable: false, identity: true),
                        Designation = c.String(),
                    })
                .PrimaryKey(t => t.SalleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Classes", "NiveauId", "dbo.Niveaux");
            DropForeignKey("dbo.Etudiants", "ClasseId", "dbo.Classes");
            DropIndex("dbo.Etudiants", new[] { "ClasseId" });
            DropIndex("dbo.Classes", new[] { "NiveauId" });
            DropTable("dbo.Salles");
            DropTable("dbo.Niveaux");
            DropTable("dbo.Etudiants");
            DropTable("dbo.Classes");
        }
    }
}
