using Inventory.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Infrastructure.ModelBuilderExtensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Electronic"
                },
                new Category
                {
                    Id =2,
                    Name = "Furniture"
                }
            );
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "TV", Barcode = "123", Description ="smart tv", Weight =8, Status = ProductStatus.InStock, CategoryId = 1 },
                new Product { Id = 2, Name = "Phone", Barcode = "456", Description ="good phone", Weight =1, Status = ProductStatus.InStock, CategoryId = 1 },
                new Product { Id = 3, Name = "Laptop", Barcode = "432", Description ="hp laptop", Weight =3, Status = ProductStatus.Damaged, CategoryId = 1 },
                new Product { Id = 4, Name = "Couch", Barcode = "444", Description = "good furniture", Weight =90, Status = ProductStatus.Sold, CategoryId = 2 },
                new Product { Id = 5, Name = "Chair", Barcode = "777", Description ="good chair", Weight =56, Status = ProductStatus.Damaged, CategoryId = 2 }
            );
        }
    }
}
