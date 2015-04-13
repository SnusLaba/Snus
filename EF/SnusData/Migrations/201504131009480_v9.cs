namespace SnusData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v9 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Age", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Age", c => c.Int(nullable: false));
        }
    }
}
