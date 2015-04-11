namespace SnusData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Coments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.Int(nullable: false),
                        Text = c.String(nullable: false, maxLength: 10),
                        Products_Id = c.Int(nullable: false),
                        Product_Id = c.Int(),
                        Users_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.Users", t => t.Users_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.Users_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 10),
                        Description = c.String(maxLength: 10),
                        Count = c.Int(nullable: false),
                        Type_Id = c.Int(nullable: false),
                        Nicotine = c.String(nullable: false, maxLength: 10),
                        Rating = c.Int(nullable: false),
                        Type_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Types", t => t.Type_Id1)
                .Index(t => t.Type_Id1);
            
            CreateTable(
                "dbo.File",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Path = c.String(nullable: false, maxLength: 10),
                        Name = c.String(nullable: false, maxLength: 10),
                        Description = c.String(nullable: false, maxLength: 10),
                        FileType_Id = c.String(nullable: false, maxLength: 10),
                        FileType_Id1 = c.Int(),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Types", t => t.FileType_Id1)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.FileType_Id1)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 10),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 10),
                        SecondName = c.String(nullable: false, maxLength: 10),
                        Age = c.String(nullable: false, maxLength: 10),
                        Role_Id = c.String(nullable: false),
                        Sex = c.String(maxLength: 10),
                        Email = c.String(nullable: false, maxLength: 10),
                        Password = c.String(nullable: false, maxLength: 10),
                        Location_Id = c.Int(nullable: false),
                        CurrentOrder_Id = c.Long(nullable: false),
                        TypeId = c.Int(nullable: false),
                        CurrentOrder_Id1 = c.Long(),
                        Location_Id1 = c.Int(),
                        Role_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.CurrentOrder_Id1)
                .ForeignKey("dbo.Locations", t => t.Location_Id1)
                .ForeignKey("dbo.Roles", t => t.Role_Id1)
                .ForeignKey("dbo.Types", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.TypeId)
                .Index(t => t.CurrentOrder_Id1)
                .Index(t => t.Location_Id1)
                .Index(t => t.Role_Id1);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Create_Date = c.String(nullable: false, maxLength: 10),
                        UserId = c.Int(nullable: false),
                        Users_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Users_Id)
                .Index(t => t.UserId)
                .Index(t => t.Users_Id);
            
            CreateTable(
                "dbo.Order_Item",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Long(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        Past_Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Country_Id = c.Int(nullable: false),
                        Address = c.String(nullable: false, maxLength: 10),
                        Telephone = c.String(maxLength: 10),
                        Country_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id1)
                .Index(t => t.Country_Id1);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 10),
                        City_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_id)
                .Index(t => t.City_id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "TypeId", "dbo.Types");
            DropForeignKey("dbo.Users", "Role_Id1", "dbo.Roles");
            DropForeignKey("dbo.Orders", "Users_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Location_Id1", "dbo.Locations");
            DropForeignKey("dbo.Locations", "Country_Id1", "dbo.Countries");
            DropForeignKey("dbo.Countries", "City_id", "dbo.Cities");
            DropForeignKey("dbo.Users", "CurrentOrder_Id1", "dbo.Orders");
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.Order_Item", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Order_Item", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Coments", "Users_Id", "dbo.Users");
            DropForeignKey("dbo.Products", "Type_Id1", "dbo.Types");
            DropForeignKey("dbo.File", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.File", "FileType_Id1", "dbo.Types");
            DropForeignKey("dbo.Coments", "Product_Id", "dbo.Products");
            DropIndex("dbo.Countries", new[] { "City_id" });
            DropIndex("dbo.Locations", new[] { "Country_Id1" });
            DropIndex("dbo.Order_Item", new[] { "ProductId" });
            DropIndex("dbo.Order_Item", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "Users_Id" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "Role_Id1" });
            DropIndex("dbo.Users", new[] { "Location_Id1" });
            DropIndex("dbo.Users", new[] { "CurrentOrder_Id1" });
            DropIndex("dbo.Users", new[] { "TypeId" });
            DropIndex("dbo.File", new[] { "Product_Id" });
            DropIndex("dbo.File", new[] { "FileType_Id1" });
            DropIndex("dbo.Products", new[] { "Type_Id1" });
            DropIndex("dbo.Coments", new[] { "Users_Id" });
            DropIndex("dbo.Coments", new[] { "Product_Id" });
            DropTable("dbo.Roles");
            DropTable("dbo.Countries");
            DropTable("dbo.Locations");
            DropTable("dbo.Order_Item");
            DropTable("dbo.Orders");
            DropTable("dbo.Users");
            DropTable("dbo.Types");
            DropTable("dbo.File");
            DropTable("dbo.Products");
            DropTable("dbo.Coments");
            DropTable("dbo.Cities");
        }
    }
}
