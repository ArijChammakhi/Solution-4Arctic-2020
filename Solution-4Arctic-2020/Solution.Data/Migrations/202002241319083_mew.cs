namespace Solution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mew : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        OutDate = c.DateTime(nullable: false),
                        ImageUrl = c.String(),
                        Genre = c.String(),
                        ProducteurId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Producteurs", t => t.ProducteurId)
                .Index(t => t.ProducteurId);
            
            CreateTable(
                "dbo.Producteurs",
                c => new
                    {
                        ProducteurId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProducteurId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Films", "ProducteurId", "dbo.Producteurs");
            DropIndex("dbo.Films", new[] { "ProducteurId" });
            DropTable("dbo.Producteurs");
            DropTable("dbo.Films");
        }
    }
}
