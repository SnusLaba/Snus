namespace SnusData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Locations", "Country_Id1", "dbo.Countries");
            DropIndex("dbo.Locations", new[] { "Country_Id1" });
            DropColumn("dbo.Locations", "Country_Id");
            DropColumn("dbo.Locations", "Country_Id1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locations", "Country_Id1", c => c.Int());
            AddColumn("dbo.Locations", "Country_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Locations", "Country_Id1");
            AddForeignKey("dbo.Locations", "Country_Id1", "dbo.Countries", "Id");
        }
    }
}
