namespace SnusData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v14 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Coments", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Coments", "User_Id", c => c.Int(nullable: false));
        }
    }
}
