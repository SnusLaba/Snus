namespace SnusData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Count", c => c.Int());
            AlterColumn("dbo.Products", "Type_Id", c => c.Int());
            AlterColumn("dbo.Products", "Rating", c => c.Int());
            AlterColumn("dbo.Users", "SecondName", c => c.String(maxLength: 10));
            AlterColumn("dbo.Users", "Role_Id", c => c.Int());
            AlterColumn("dbo.Users", "Email", c => c.String(maxLength: 10));
            AlterColumn("dbo.Users", "Password", c => c.String(maxLength: 10));
            AlterColumn("dbo.Users", "Location_Id", c => c.Int());
            AlterColumn("dbo.Users", "CurrentOrder_Id", c => c.Long());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "CurrentOrder_Id", c => c.Long(nullable: false));
            AlterColumn("dbo.Users", "Location_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Users", "Role_Id", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "SecondName", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Products", "Rating", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Type_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Count", c => c.Int(nullable: false));
        }
    }
}
