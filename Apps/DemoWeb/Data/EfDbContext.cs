using DemoWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoWeb.Data
{
    public class EfDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=den1.mssql7.gear.host;Initial Catalog=efdemo;User ID=efdemo;Password=Em0r-9jW8r?Z");
        }
    }
}
