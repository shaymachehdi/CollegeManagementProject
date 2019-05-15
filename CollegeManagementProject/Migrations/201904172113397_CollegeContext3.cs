namespace CollegeManagementProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CollegeContext3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Enseignants", "Matiere_MatiereId1", c => c.Int());
            CreateIndex("dbo.Enseignants", "Matiere_MatiereId1");
            AddForeignKey("dbo.Enseignants", "Matiere_MatiereId1", "dbo.Matieres", "MatiereId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enseignants", "Matiere_MatiereId1", "dbo.Matieres");
            DropIndex("dbo.Enseignants", new[] { "Matiere_MatiereId1" });
            DropColumn("dbo.Enseignants", "Matiere_MatiereId1");
        }
    }
}
