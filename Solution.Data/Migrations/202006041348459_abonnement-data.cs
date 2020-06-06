namespace Solution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abonnementdata : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abonnements",
                c => new
                    {
                        IdAbonnement = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        type = c.Int(nullable: false),
                        Prix = c.Single(nullable: false),
                        DateDebut = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DateFin = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IdAbonnement)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Abonnements", "UserID", "dbo.Users");
            DropIndex("dbo.Abonnements", new[] { "UserID" });
            DropTable("dbo.Abonnements");
        }
    }
}
