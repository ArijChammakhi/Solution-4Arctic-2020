namespace Solution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contrat1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contrats",
                c => new
                    {
                        ClientID = c.String(nullable: false, maxLength: 128),
                        AnnonceId = c.Int(nullable: false),
                        DateContrat = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DateFinContrat = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Description = c.String(),
                        PrixContrat = c.Single(nullable: false),
                        motif = c.Int(nullable: false),
                        Annonce_IdAnnonce = c.Int(),
                    })
                .PrimaryKey(t => new { t.ClientID, t.AnnonceId })
                .ForeignKey("dbo.Annonces", t => t.Annonce_IdAnnonce)
                .ForeignKey("dbo.Users", t => t.ClientID, cascadeDelete: true)
                .Index(t => t.ClientID)
                .Index(t => t.Annonce_IdAnnonce);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contrats", "ClientID", "dbo.Users");
            DropForeignKey("dbo.Contrats", "Annonce_IdAnnonce", "dbo.Annonces");
            DropIndex("dbo.Contrats", new[] { "Annonce_IdAnnonce" });
            DropIndex("dbo.Contrats", new[] { "ClientID" });
            DropTable("dbo.Contrats");
        }
    }
}
