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
        //Only gets available products
        query = query.Where(p => p.IsAvailable == true);

        // Filtering the list we are returning:
        if (!string.IsNullOrEmpty(dto.Category))
        {
            query = query.Where(p => p.Category == dto.Category);
        }

        if (!string.IsNullOrEmpty(dto.Color))
        {
            query = query.Where(p => p.ColorName.Contains(dto.Color));
        }
        if (dto.ProductItem > 0 )
        {//only used if we want to get on product
            query = query.Where(p => p.ProductId == dto.ProductItem); 
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

    public async Task<ProductSaleStatusDto> UpdateSaleStatusAsync(ProductSaleStatusDto dto)
    {
        try
        {
            // Fetch the products to be updated
            List<Product> productsToUpdate = await _context.product
                .Where(p => dto.Indexes.Contains(p.ProductId))
                .ToListAsync();

            // Update the sale status for each product
            foreach (var product in productsToUpdate)
            {
                product.IsAvailable = false; // Assuming you have a property like IsOnSale in your Product model
            }

            // Save changes to the database
            await _context.SaveChangesAsync();

            return dto;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw new Exception("Error updating sale status for products!");
        }
    }
}