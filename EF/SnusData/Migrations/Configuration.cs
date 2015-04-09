namespace SnusData.Migrations
{
    using SnusData.Entitys;
    using System;
    using System.Collections;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SnusData.Entitys.SnusDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SnusData.Entitys.SnusDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            try
            {
                context.Roles.AddOrUpdate(x => x.Name,
                    new Roles() { Name = "admin" },
                    new Roles() { Name = "customer" });

                context.Types.AddOrUpdate(new FileType() { Name = "image", Id = 1 },
                                            new FileType() { Name = "document", Id = 2},
                                            new ProductType() { Name = "Snus", Id = 3 });

                context.City.AddOrUpdate(
                    new City() { Name = "Kiev" },
                    new City() { Name = "Minsk" });
                context.Country.AddOrUpdate(
                    new Country() { Name = "Uckraine" },
                    new Country() { Name = "Belorus" });
                context.Locations.AddOrUpdate(
                    new Locations() { Telephone = "094949403", Id = 1 },
                    new Locations() { Telephone = "094949403", Id = 2 });
                //context.Files.AddOrUpdate(new File() { Description = "i image", Name = "File2", Path = "catch//loc2al" });
                //context.Products.AddOrUpdate(
                //    new Product() { Name = "Snus1", Count = 5, Description = "Some description 1", Type_Id = 3 },
                //    new Product() { Name = "Snus2", Count = 5, Description = "Some description 2", Type_Id = 3 },
                //    new Product() { Name = "Snus3", Count = 5, Description = "Some description 3", Type_Id = 3 },
                //    new Product() { Name = "Snus4", Count = 5, Description = "Some description 4", Type_Id = 3 },
                //    new Product() { Name = "Snus5", Count = 5, Description = "Some description 5", Type_Id = 3 });
            }
            catch (Exception e)
            {

            }
        }
    }
}
