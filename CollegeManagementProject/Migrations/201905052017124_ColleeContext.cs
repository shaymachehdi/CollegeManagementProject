namespace CollegeManagementProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColleeContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Absences",
                c => new
                    {
                        AbsenceId = c.Int(nullable: false, identity: true),
                        DateAbsence = c.DateTime(nullable: false),
                        EtudiantID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AbsenceId)
                .ForeignKey("dbo.Etudiants", t => t.EtudiantID, cascadeDelete: true)
                .Index(t => t.EtudiantID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Absences", "EtudiantID", "dbo.Etudiants");
            DropIndex("dbo.Absences", new[] { "EtudiantID" });
            DropTable("dbo.Absences");
        }
    }
}
