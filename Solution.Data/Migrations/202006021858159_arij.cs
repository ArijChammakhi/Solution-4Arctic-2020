namespace Solution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arij : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Meubles",
                c => new
                    {
                        IdMeuble = c.Int(nullable: false, identity: true),
                        Titre = c.String(),
                        Adresse = c.String(),
                        Image = c.String(),
                        PrixM = c.Single(nullable: false),
                        Description = c.String(),
                        UserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IdMeuble)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Meubles", "UserID", "dbo.Users");
            DropIndex("dbo.Meubles", new[] { "UserID" });
            DropTable("dbo.Meubles");
        }
    }
}
