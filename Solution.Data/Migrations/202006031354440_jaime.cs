namespace Solution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jaime : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Interesses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserID = c.String(nullable: false, maxLength: 128),
                        IdAnnonce = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Annonces", t => t.IdAnnonce, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.IdAnnonce);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Interesses", "UserID", "dbo.Users");
            DropForeignKey("dbo.Interesses", "IdAnnonce", "dbo.Annonces");
            DropIndex("dbo.Interesses", new[] { "IdAnnonce" });
            DropIndex("dbo.Interesses", new[] { "UserID" });
            DropTable("dbo.Interesses");
        }
    }
}
