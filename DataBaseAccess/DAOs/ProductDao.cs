using Application.Idao;
using Domain.Models;

namespace DataBaseAccess.DAOs;

public class ProductDao : IProductDao
{
    public Task<Product> CreateAsync(Product productToCreate)
    {
        Console.WriteLine("I tried to create product: " + productToCreate.ColorName);
        return Task.FromResult(productToCreate);
    }
}