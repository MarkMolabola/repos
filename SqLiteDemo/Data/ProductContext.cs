using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqLiteDemo.Model;

namespace SqLiteDemo.Data
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
           
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(GetProducts());
            base.OnModelCreating(modelBuilder);

        }
        private Product[] GetProducts()
        {
            return new Product[]
            {
                new Product {Id=1, Name = "Laptop", Price = 999.99m, Description = "A high-performance laptop.", stock = 10 },
                new Product { Id=2,Name = "Smartphone", Price = 699.99m, Description = "A latest model smartphone.", stock = 25 },
                new Product {Id=3, Name = "Tablet", Price = 399.99m, Description = "A lightweight tablet.", stock = 15 },
                new Product { Id=4,Name = "Headphones", Price = 199.99m, Description = "Noise-cancelling headphones.", stock = 30 },
                new Product {Id=5, Name = "Smartwatch", Price = 299.99m, Description = "A smartwatch with various features.", stock = 20 }
            };
        }
    }
}
