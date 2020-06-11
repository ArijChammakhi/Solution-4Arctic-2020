namespace Solution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contrat : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAnnonceContrat",
                c => new
                    {
                        Utilisateurs = c.Int(nullable: false),
                        Annonces = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Utilisateurs, t.Annonces })
                .ForeignKey("dbo.Annonces", t => t.Utilisateurs, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Annonces, cascadeDelete: true)
                .Index(t => t.Utilisateurs)
                .Index(t => t.Annonces);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAnnonceContrat", "Annonces", "dbo.Users");
            DropForeignKey("dbo.UserAnnonceContrat", "Utilisateurs", "dbo.Annonces");
            DropIndex("dbo.UserAnnonceContrat", new[] { "Annonces" });
            DropIndex("dbo.UserAnnonceContrat", new[] { "Utilisateurs" });
            DropTable("dbo.UserAnnonceContrat");
        }
    }
}
