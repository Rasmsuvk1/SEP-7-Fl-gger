using Application.Idao;
using Domain.DTOs;
using Domain.Models;

namespace DataBaseAccess.DAOs;

public class ProductDao : IProductDao
{
    private List<Product> products = new List<Product>();
    public Task<Product> CreateAsync(Product productToCreate)
    {
        Console.WriteLine("I tried to create product: " + productToCreate.ColorName);
        return Task.FromResult(productToCreate);
    }

    public Task<List<Product>> GetListAsync(ProductListDto dto)
    {
        products.Add(new Product("Navy Blue", "Room", 1.5, 250, new DateOnly(2024,11,29), "https://flugger-vanlose.dk/wp-content/uploads/2022/01/proeve-500x471.png"));
        Console.WriteLine("I tried to return the list");
        return Task.FromResult(products);
    }

    public Task<ProductSaleStatusDto> UpdateSaleStatusAsync(ProductSaleStatusDto dto)
    {
        products.Add(new Product("Navy Blue", "Room", 1.5, 250, new DateOnly(2024,11,29), "https://flugger-vanlose.dk/wp-content/uploads/2022/01/proeve-500x471.png"));
        products[0].ProductId = 1;
        foreach (var i in dto.Indexes)
        {
           Product? product = products.Find(product => product.ProductId == i);
           if (product != null)
           {
               product.changeAvailability();
               Console.WriteLine("I updated product with id: " + product?.ProductId); 
           }
        }
        Console.WriteLine("I tried to update the list");
        return Task.FromResult(dto);
    }
}