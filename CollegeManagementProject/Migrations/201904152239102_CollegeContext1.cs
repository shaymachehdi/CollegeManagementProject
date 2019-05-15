namespace CollegeManagementProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CollegeContext1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TypeSalles",
                c => new
                    {
                        TypeSalleId = c.Int(nullable: false, identity: true),
                        Designation = c.String(),
                    })
                .PrimaryKey(t => t.TypeSalleId);
            
            AddColumn("dbo.Salles", "TypeSalleId", c => c.Int(nullable: false));
            AddColumn("dbo.Salles", "salle_SalleId", c => c.Int());
            CreateIndex("dbo.Salles", "TypeSalleId");
            CreateIndex("dbo.Salles", "salle_SalleId");
            AddForeignKey("dbo.Salles", "salle_SalleId", "dbo.Salles", "SalleId");
            AddForeignKey("dbo.Salles", "TypeSalleId", "dbo.TypeSalles", "TypeSalleId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Salles", "TypeSalleId", "dbo.TypeSalles");
            DropForeignKey("dbo.Salles", "salle_SalleId", "dbo.Salles");
            DropIndex("dbo.Salles", new[] { "salle_SalleId" });
            DropIndex("dbo.Salles", new[] { "TypeSalleId" });
            DropColumn("dbo.Salles", "salle_SalleId");
            DropColumn("dbo.Salles", "TypeSalleId");
            DropTable("dbo.TypeSalles");
        }
    }
}
