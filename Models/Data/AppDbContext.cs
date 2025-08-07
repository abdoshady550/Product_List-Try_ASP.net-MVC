using Asp.net_Web_Api.Entities;

using Microsoft.EntityFrameworkCore;

namespace Asp.net_Web_Api.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Product>(e =>
                       e.HasData(GetSeedProductData()));

            modelBuilder.Entity<Product>()
                          .Property(p => p.Price)
                          .HasColumnType("decimal(18,2)");


            ;


        }
        public static List<Product> GetSeedProductData()
        {
            return new List<Product>
            {
                new Product { Id = 1, Name = "Smartphone", Price = 699.99m, Quantity = 50 },
                new Product { Id = 2, Name = "T-Shirt", Price = 19.99m, Quantity = 200 },
                new Product { Id = 3, Name = "Fiction Novel", Price = 14.99m, Quantity = 100 },
                new Product { Id = 4, Name = "Microwave", Price = 120.00m, Quantity = 30 }
            };
        }
    }
}
