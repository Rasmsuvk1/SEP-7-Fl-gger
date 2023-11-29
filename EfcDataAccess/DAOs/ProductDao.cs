using Domain.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class ProductDao
{
    private readonly DbContext context;

    public ProductDao(DbContext context)
    {
        this.context = context;
    }
    
    public async Task<Product> CreateAsync(Product product)
    {
        
        try
        {
            EntityEntry<Product> newUser = await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            return newUser.Entity;
        }
        catch (Exception ex)
        {
            // Handle the exception (log, throw, etc.)
            Console.WriteLine("Chaaaaaao");
            Console.WriteLine($"Error creating the product: {ex.Message}");
            throw; // Optionally rethrow the exception
        }
    }
}