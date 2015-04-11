using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SnusData.Entitys
{
    public class SnusDb : DbContext
    {
        public SnusDb(): base("DefaultConnection")
        {
        }
        public virtual DbSet<Coments> Coments { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Order_Item> Order_Items { get; set; }

        public void Save()
        {
            SaveChanges();
        }

    }
}
