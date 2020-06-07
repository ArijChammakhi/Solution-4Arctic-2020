namespace Solution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arouja : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meubles", "DatePublication", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Meubles", "DatePublication");
        }
    }
}
