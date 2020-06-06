namespace Solution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fk : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Annonces",
                c => new
                    {
                        IdAnnonce = c.Int(nullable: false, identity: true),
                        DateAnnonce = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Titre = c.String(),
                        type = c.Int(nullable: false),
                        statut = c.Int(nullable: false),
                        Type_Dannonce = c.String(),
                        Description = c.String(),
                        PrixAchat = c.Single(nullable: false),
                        LoyerMensuel = c.Single(nullable: false),
                        Localisation = c.String(),
                        ImageBi = c.String(),
                        SizeImage = c.Long(nullable: false),
                        ChargeMensuel = c.Single(nullable: false),
                        NombreDeChambre = c.Int(nullable: false),
                        jardin = c.String(),
                        typeStudio = c.Int(nullable: false),
                        Etage = c.Int(nullable: false),
                        Ascensseur = c.Boolean(nullable: false),
                        CuisineEquipe = c.Boolean(nullable: false),
                        Superficie = c.Single(nullable: false),
                        UserID = c.String(maxLength: 128),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.IdAnnonce)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID);
            
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
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Cin = c.Long(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Address = c.String(),
                        image = c.String(),
                        role = c.String(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(precision: 7, storeType: "datetime2"),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Meubles",
                c => new
                    {
                        IdMeuble = c.Int(nullable: false, identity: true),
                        Titre = c.String(),
                        Adresse = c.String(),
                        DatePublication = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Image = c.String(),
                        PrixM = c.Single(nullable: false),
                        Description = c.String(),
                        UserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IdMeuble)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .Index(t => t.UserId)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.Interesses", "UserID", "dbo.Users");
            DropForeignKey("dbo.IdentityUserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.Meubles", "UserID", "dbo.Users");
            DropForeignKey("dbo.IdentityUserLogins", "User_Id", "dbo.Users");
            DropForeignKey("dbo.IdentityUserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.Annonces", "UserID", "dbo.Users");
            DropForeignKey("dbo.Interesses", "IdAnnonce", "dbo.Annonces");
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "UserId" });
            DropIndex("dbo.Meubles", new[] { "UserID" });
            DropIndex("dbo.IdentityUserLogins", new[] { "User_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "UserId" });
            DropIndex("dbo.Interesses", new[] { "IdAnnonce" });
            DropIndex("dbo.Interesses", new[] { "UserID" });
            DropIndex("dbo.Annonces", new[] { "UserID" });
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.Meubles");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.Interesses");
            DropTable("dbo.Annonces");
        }
    }
}
