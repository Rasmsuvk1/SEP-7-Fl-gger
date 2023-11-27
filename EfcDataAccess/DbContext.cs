using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EfcDataAccess;

public class DbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<CustomerInfo> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = ../EfcDataAccess/Database.db");
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);            
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<CustomerInfo>()
            .HasKey(info =>  info.CustomerId);
        
        modelBuilder.Entity<Product>()
            .HasKey(product => product.ProductId);

        modelBuilder.Entity<Order>()
            .HasKey(order => order.OrderId);
        
    }
    
}