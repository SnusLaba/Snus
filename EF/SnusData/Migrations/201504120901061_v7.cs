namespace SnusData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Count", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Nicotine", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Rating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Rating", c => c.Int());
            AlterColumn("dbo.Products", "Nicotine", c => c.String(maxLength: 10));
            AlterColumn("dbo.Products", "Count", c => c.Int());
        }
    }
}
