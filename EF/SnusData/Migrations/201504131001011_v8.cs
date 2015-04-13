namespace SnusData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Age", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Age", c => c.String(maxLength: 10));
        }
    }
}
