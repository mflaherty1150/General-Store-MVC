using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeneralStoreMVC.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GeneralStoreMVC.Data;

public class GeneralStoreDbContext : DbContext
{
    public GeneralStoreDbContext(DbContextOptions<GeneralStoreDbContext> options) : base(options)
    {

    }

    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<TransactionEntity> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<CustomerEntity>().HasData(
            new CustomerEntity
            {
                Id = 1001,
                Name = "Wayne Enterprises",
                Email = "batman4ever@wayne.org"
            },
            new CustomerEntity
            {
                Id = 1002,
                Name = "Palmer Technology",
                Email = "scienceiscool@gmail.com"
            },
            new CustomerEntity
            {
                Id = 1003,
                Name = "ACME Incorporated",
                Email = "anvil4life@icloud.com"
            },
            new CustomerEntity
            {
                Id = 1004,
                Name = "Ace Chemicals",
                Email = "thejokerrises@outlool.com"
            },
            new CustomerEntity
            {
                Id = 1005,
                Name = "Queen Industries",
                Email = "greenarrow98@queenindustries.org"
            },
            new CustomerEntity
            {
                Id = 1006,
                Name = "Queen Industries",
                Email = "greenarrow98@queenindustries.org"
            },
            new CustomerEntity
            {
                Id = 1007,
                Name = "Tony Stark",
                Email = "ironman@marvel.org"
            },
            new CustomerEntity
            {
                Id = 1008,
                Name = "Peter Parker",
                Email = "friendlyspider@marvel.org"
            },
            new CustomerEntity
            {
                Id = 1009,
                Name = "Bruce Banner",
                Email = "hulkoutgreen@marvel.org"
            }
        );

        modelBuilder.Entity<ProductEntity>().HasData(
            new ProductEntity
            {
                Id = 1001,
                Name = "Apple Airpods Max",
                QuantityInStock = 98,
                Price = 499.99,
            },
            new ProductEntity
            {
                Id = 1002,
                Name = "Apple Airpods Pro",
                QuantityInStock = 48,
                Price = 199.99,
            },
            new ProductEntity
            {
                Id = 1003,
                Name = "Apple MacBook Pro 14 M3 Pro",
                QuantityInStock = 61,
                Price = 1999.99,
            },
            new ProductEntity
            {
                Id = 1004,
                Name = "Ipad Pro 12.9",
                QuantityInStock = 78,
                Price = 1299.99,
            },
            new ProductEntity
            {
                Id = 1005,
                Name = "Ipad 10.9 10th Gen",
                QuantityInStock = 50,
                Price = 499.99,
            },
            new ProductEntity
            {
                Id = 1006,
                Name = "Playstation 5",
                QuantityInStock = 55,
                Price = 499.99,
            },
            new ProductEntity
            {
                Id = 1007,
                Name = "The Amazing Spiderman 2",
                QuantityInStock = 35,
                Price = 69.99,
            },
            new ProductEntity
            {
                Id = 1008,
                Name = "Diablo IV",
                QuantityInStock = 42,
                Price = 69.99,
            },
            new ProductEntity
            {
                Id = 1009,
                Name = "Horizon Forbidden West Complete Edition",
                QuantityInStock = 101,
                Price = 69.99,
            },
            new ProductEntity
            {
                Id = 1010,
                Name = "PS5 Purple Controller",
                QuantityInStock = 108,
                Price = 69.99,
            },
            new ProductEntity
            {
                Id = 1011,
                Name = "Nintendo Switch",
                QuantityInStock = 104,
                Price = 299.99,
            }
        );

        modelBuilder.Entity<TransactionEntity>().HasData(
            new TransactionEntity
            {
                Id = 1001,
                Quantity = 3,
                DateOfTransaction = DateTime.Now,
                CustomerId = 1001,
                ProductId = 1004
            },
            new TransactionEntity
            {
                Id = 1002,
                Quantity = 1,
                DateOfTransaction = DateTime.Now,
                CustomerId = 1004,
                ProductId = 1001
            },
            new TransactionEntity
            {
                Id = 1003,
                Quantity = 3,
                DateOfTransaction = DateTime.Now,
                CustomerId = 1002,
                ProductId = 1011
            },
            new TransactionEntity
            {
                Id = 1004,
                Quantity = 2,
                DateOfTransaction = DateTime.Now,
                CustomerId = 1008,
                ProductId = 1010
            },
            new TransactionEntity
            {
                Id = 1005,
                Quantity = 8,
                DateOfTransaction = DateTime.Now,
                CustomerId = 1008,
                ProductId = 1003
            },
            new TransactionEntity
            {
                Id = 1006,
                Quantity = 6,
                DateOfTransaction = DateTime.Now,
                CustomerId = 1002,
                ProductId = 1007
            },
            new TransactionEntity
            {
                Id = 1007,
                Quantity = 10,
                DateOfTransaction = DateTime.Now,
                CustomerId = 1006,
                ProductId = 1009
            }
        );
    }
}
