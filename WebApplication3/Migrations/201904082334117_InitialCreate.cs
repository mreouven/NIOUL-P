namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblReceip",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        user = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        types = c.String(nullable: false),
                        tempsdepreparation = c.String(nullable: false),
                        tempsdecuisson = c.String(nullable: false),
                        difficulty = c.String(nullable: false),
                        nombrePers = c.String(nullable: false),
                        ingredients = c.String(nullable: false),
                        explication = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblReceip");
        }
    }
}
