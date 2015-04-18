namespace SnusData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v13 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Coments", "Products_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Coments", "Products_Id", c => c.Int(nullable: false));
        }
    }
}
