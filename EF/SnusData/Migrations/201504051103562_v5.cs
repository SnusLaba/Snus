namespace SnusData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "Type_Id");
            RenameColumn(table: "dbo.Products", name: "Type_Id1", newName: "Type_Id");
            RenameIndex(table: "dbo.Products", name: "IX_Type_Id1", newName: "IX_Type_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Products", name: "IX_Type_Id", newName: "IX_Type_Id1");
            RenameColumn(table: "dbo.Products", name: "Type_Id", newName: "Type_Id1");
            AddColumn("dbo.Products", "Type_Id", c => c.Int());
        }
    }
}
