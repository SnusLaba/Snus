namespace SnusData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v6 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "CurrentOrder_Id");
            DropColumn("dbo.Users", "Location_Id");
            DropColumn("dbo.Users", "Role_Id");
            RenameColumn(table: "dbo.Users", name: "CurrentOrder_Id1", newName: "CurrentOrder_Id");
            RenameColumn(table: "dbo.Users", name: "Location_Id1", newName: "Location_Id");
            RenameColumn(table: "dbo.Users", name: "Role_Id1", newName: "Role_Id");
            RenameIndex(table: "dbo.Users", name: "IX_CurrentOrder_Id1", newName: "IX_CurrentOrder_Id");
            RenameIndex(table: "dbo.Users", name: "IX_Location_Id1", newName: "IX_Location_Id");
            RenameIndex(table: "dbo.Users", name: "IX_Role_Id1", newName: "IX_Role_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Users", name: "IX_Role_Id", newName: "IX_Role_Id1");
            RenameIndex(table: "dbo.Users", name: "IX_Location_Id", newName: "IX_Location_Id1");
            RenameIndex(table: "dbo.Users", name: "IX_CurrentOrder_Id", newName: "IX_CurrentOrder_Id1");
            RenameColumn(table: "dbo.Users", name: "Role_Id", newName: "Role_Id1");
            RenameColumn(table: "dbo.Users", name: "Location_Id", newName: "Location_Id1");
            RenameColumn(table: "dbo.Users", name: "CurrentOrder_Id", newName: "CurrentOrder_Id1");
            AddColumn("dbo.Users", "Role_Id", c => c.Int());
            AddColumn("dbo.Users", "Location_Id", c => c.Int());
            AddColumn("dbo.Users", "CurrentOrder_Id", c => c.Long());
        }
    }
}
