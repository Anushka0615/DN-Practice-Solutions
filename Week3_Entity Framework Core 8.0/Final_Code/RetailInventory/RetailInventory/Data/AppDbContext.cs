using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RetailInventory.Models;
using System.IO;

namespace RetailInventory.Data
{
    public class AppDbContext : DbContext
    {
        private readonly string _connectionString;

        public AppDbContext()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())       // 🔹 this points to your project root
                .AddJsonFile("appsettings.json", optional: false);  // 🔹 load connection string

            var config = builder.Build();
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
