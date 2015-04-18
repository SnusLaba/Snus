namespace SnusData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v12 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Coments", "Text", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Products", "Description", c => c.String(maxLength: 100));
            AlterColumn("dbo.File", "Path", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.File", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.File", "Description", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Types", "Name", c => c.String(maxLength: 100));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Users", "SecondName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Users", "Sex", c => c.String(maxLength: 100));
            AlterColumn("dbo.Users", "Email", c => c.String(maxLength: 100));
            AlterColumn("dbo.Users", "Password", c => c.String(maxLength: 100));
            AlterColumn("dbo.Orders", "Create_Date", c => c.String(maxLength: 100));
            AlterColumn("dbo.Locations", "Address", c => c.String(maxLength: 100));
            AlterColumn("dbo.Locations", "Telephone", c => c.String(maxLength: 100));
            AlterColumn("dbo.Roles", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Countries", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Countries", "Name", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Roles", "Name", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Locations", "Telephone", c => c.String(maxLength: 10));
            AlterColumn("dbo.Locations", "Address", c => c.String(maxLength: 10));
            AlterColumn("dbo.Orders", "Create_Date", c => c.String(maxLength: 10));
            AlterColumn("dbo.Users", "Password", c => c.String(maxLength: 10));
            AlterColumn("dbo.Users", "Email", c => c.String(maxLength: 10));
            AlterColumn("dbo.Users", "Sex", c => c.String(maxLength: 10));
            AlterColumn("dbo.Users", "SecondName", c => c.String(maxLength: 10));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Types", "Name", c => c.String(maxLength: 10));
            AlterColumn("dbo.File", "Description", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.File", "Name", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.File", "Path", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Products", "Description", c => c.String(maxLength: 10));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Coments", "Text", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
