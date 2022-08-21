using Mango.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new Product()
            {
                ProductId = 1,
                Name = "Steak",
                Price = 24,
                Description = "Juicy Steak and Chunky Chips",
                ImageUrl = "https://andrewmmango.blob.core.windows.net/mango/Steak.jpg",
                CategoryName = "Mains"
            });
            modelBuilder.Entity<Product>().HasData(new Product()
            {
                ProductId = 2,
                Name = "Double Bacon Cheese Burger",
                Price = 14,
                Description = "Bacon Double Cheese Burger Served with Fries or Chunky Chips",
                ImageUrl = "https://andrewmmango.blob.core.windows.net/mango/BaconCheeseBurger.jpg",
                CategoryName = "Mains"
            });
            modelBuilder.Entity<Product>().HasData(new Product()
            {
                ProductId = 3,
                Name = "Lasagne",
                Price = 12,
                Description = "Taste of Italy",
                ImageUrl = "https://andrewmmango.blob.core.windows.net/mango/lasagne.jpg",
                CategoryName = "Mains"
            });
            modelBuilder.Entity<Product>().HasData(new Product()
            {
                ProductId = 4,
                Name = "Beer Battered Cod & Chips",
                Price = 14,
                Description = "Traditional favourite",
                ImageUrl = "https://andrewmmango.blob.core.windows.net/mango/CodChips.jpg",
                CategoryName = "Mains"
            });
        }
    }
}
