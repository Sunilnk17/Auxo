using System;
using Auxo.Models;
using Microsoft.EntityFrameworkCore;

namespace Auxo.Repository;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Parts> Parts { get; set; }

    public DbSet<Orders> Orders { get; set; }

    public DbSet<OrderDetails> OrderDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Parts>().HasData(
            new Parts
            {
                Id = 1,
                Description = "Wire",
                Price = 5.99,
                Quantity = 5
            },
            new Parts
            {
                Id = 2,
                Description = "Brake Fluid",
                Price = 4.90,
                Quantity = 20
            },
            new Parts
            {
                Id = 3,
                Description = "Engine Oil",
                Price = 15.00,
                Quantity = 12
            }
        );
    }

}
