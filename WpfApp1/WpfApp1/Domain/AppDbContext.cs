using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Domain.Entities;

namespace WpfApp1.Domain
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<CartProducts> cartProducts { get; set; }


        public AppDbContext(DbContextOptions options) : base(options)
        {
            // Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(GetProducts());
            modelBuilder.Entity<Category>().HasData(GetCategories());
            modelBuilder.Entity<CartProducts>().HasData(GetCartProducts());
            base.OnModelCreating(modelBuilder);
        }

        private List<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "Category 1"
                },
                new Category
                {
                    Id = 2,
                    Name = "Category 2"
                },
                new Category
                {
                    Id = 3,
                    Name = "Category 3"
                }
            };
        }
        private List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Picture = "https://lh3.googleusercontent.com/proxy/bjKBGwiL9iEaL29dQsFVoo-SxtLSu0TxIcWiEUgTWLf4cZ5zBRqwXeemAOWc9z5cG90t7txblPx1xXVYCZnpPT_32NPK4d9gFMfD2xsWXGiOvyfR-ysYNO-UMPubpo7lkgWHck6ZyUA",
                    CategoryId = 1,
                    Description = "Some description of the product 1",
                    Price = 120,
                    Title = "Product 1"
                },
                new Product
                {
                    Id = 2,
                    Picture = "https://lh3.googleusercontent.com/proxy/bjKBGwiL9iEaL29dQsFVoo-SxtLSu0TxIcWiEUgTWLf4cZ5zBRqwXeemAOWc9z5cG90t7txblPx1xXVYCZnpPT_32NPK4d9gFMfD2xsWXGiOvyfR-ysYNO-UMPubpo7lkgWHck6ZyUA",
                    CategoryId = 2,
                    Description = "Some description of the product 2",
                    Price = 130,
                    Title = "Product 2"
                },
                new Product
                {
                    Id = 3,
                    Picture = "https://atlas-content-cdn.pixelsquid.com/stock-images/smart-balance-original-butter-L6OZEqD-600.jpg",
                    CategoryId = 3,
                    Description = "Some description of the product 3",
                    Price = 100,
                    Title = "Product 3"
                },
                new Product
                {
                    Id = 4,
                    Picture = "https://atlas-content-cdn.pixelsquid.com/stock-images/smart-balance-original-butter-L6OZEqD-600.jpg",
                    CategoryId = 2,
                    Description = "Some description of the product 4",
                    Price = 222,
                    Title = "Product 4"
                }
            };
        }

        private List<CartProducts> GetCartProducts()
        {
            return new List<CartProducts>
            {

            };
        }

        public class CartProducts
        {
        }
    }
}
