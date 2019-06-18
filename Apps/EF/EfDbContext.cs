using EF.Models;
using Microsoft.EntityFrameworkCore;

namespace EF
{
    public class EfDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=den1.mssql7.gear.host;Database=efdemo;User ID=efdemo;Password=Em0r-9jW8r?Z");
        }
    }
}
