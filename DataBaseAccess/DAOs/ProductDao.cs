using Application.Idao;
using DataBaseAccess.DBContext;
using Domain.DTOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseAccess.DAOs;

public class ProductDao : IProductDao
{
    
    private readonly DatabaseContext _context;
    
    public ProductDao(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<Product> CreateAsync(Product productToCreate)
    {
        try
        {
            await _context.product.AddAsync(productToCreate);
            await _context.SaveChangesAsync();
            return productToCreate;
        }catch(Exception e)
        {
          Console.WriteLine(e.Message);
          throw new Exception("Error creating new product!");
        }
        
    }

    /*Method that gets the list of products. Queries are added if the dto has information  */
    public async Task<List<Product>> GetListAsync(ProductListDto dto)
    {
        var query = _context.product.AsQueryable();

        // Filtering the list we are returning:
        if (!string.IsNullOrEmpty(dto.Category))
        {
            query = query.Where(p => p.Category == dto.Category);
        }

        if (!string.IsNullOrEmpty(dto.Color))
        {
            query = query.Where(p => p.ColorName == dto.Color);
        }
        if (!string.IsNullOrEmpty(dto.PriceStart))
        {
            if (dto.PriceStart.Equals("Low"))
            {
                query = query.OrderBy(p => p.Price);    
            }else if (dto.PriceStart.Equals("High"))
            {
                query = query.OrderByDescending(p => p.Price);
            }
        }
        else
        {
           query = query.OrderBy(p => p.ProductId);
        }
        

        var products = await query 
            .Skip((dto.PageNumber - 1) * dto.ListSize)//Skips the first entries specified by the list and pagenumber
            .Take(dto.ListSize)// specifies how many list entries we want
            .ToListAsync();

        return products;
    }

    public Task<ProductSaleStatusDto> UpdateSaleStatusAsync(ProductSaleStatusDto dto)
    {
        ProductSaleStatusDto returnDto = new ProductSaleStatusDto(new List<int>());
       
        /*foreach (var i in dto.Indexes)
        {
           Product? product = products.Find(product => product.ProductId == i);
           if (product != null)
           {
               product.changeAvailability();
               returnDto.AddIndex(i);
               Console.WriteLine("I updated product with id: " + product?.ProductId); 
           }
        }*/
        return Task.FromResult(dto);
    }
}