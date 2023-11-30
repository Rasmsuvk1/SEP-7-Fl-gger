using Application.Idao;
using Domain.DTOs;
using Domain.Models;

namespace DataBaseAccess.DAOs;

public class ProductDao : IProductDao
{
    private static List<Product> products = new List<Product>();
    public Task<Product> CreateAsync(Product productToCreate)
    {
        int index = products.Count;
        productToCreate.ProductId = index;
        products.Add(productToCreate);
        return Task.FromResult(productToCreate);
    }

    public Task<List<Product>> GetListAsync(ProductListDto dto)
    {
        
        return Task.FromResult(products);
    }

    public Task<ProductSaleStatusDto> UpdateSaleStatusAsync(ProductSaleStatusDto dto)
    {
        ProductSaleStatusDto returnDto = new ProductSaleStatusDto(new List<int>());
       
        foreach (var i in dto.Indexes)
        {
           Product? product = products.Find(product => product.ProductId == i);
           if (product != null)
           {
               product.changeAvailability();
               returnDto.AddIndex(i);
               Console.WriteLine("I updated product with id: " + product?.ProductId); 
           }
        }
        return Task.FromResult(dto);
    }
}