namespace Solution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abofix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abonnements", "State", c => c.String());
            DropColumn("dbo.Abonnements", "Prix");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Abonnements", "Prix", c => c.Single(nullable: false));
            DropColumn("dbo.Abonnements", "State");
        }
    }
}
