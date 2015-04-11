namespace SnusData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Nicotine", c => c.String(maxLength: 10));
            AlterColumn("dbo.Users", "Age", c => c.String(maxLength: 10));
            AlterColumn("dbo.Orders", "Create_Date", c => c.String(maxLength: 10));
            AlterColumn("dbo.Locations", "Address", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Locations", "Address", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Orders", "Create_Date", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Users", "Age", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Products", "Nicotine", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
