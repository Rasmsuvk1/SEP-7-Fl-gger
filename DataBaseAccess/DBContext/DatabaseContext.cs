using System.ComponentModel.DataAnnotations.Schema;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseAccess.DBContext;

public class DatabaseContext : DbContext
{
    
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }
    
    public DbSet<CustomerInfo> customerinfo { get; set; }
    public DbSet<Product> product { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerInfo>()
            .ToTable("customerinfo", schema: "Flügger");
        modelBuilder.Entity<Product>()
            .ToTable("product", schema: "Flügger");
        
    }
    
}