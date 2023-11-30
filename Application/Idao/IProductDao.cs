using Domain.DTOs;
using Domain.Models;

namespace Application.Idao;

public interface IProductDao
{
    Task<Product> CreateAsync(Product productToCreate);
    Task<List<Product>> GetListAsync(ProductListDto dto);
    Task<ProductSaleStatusDto> UpdateSaleStatusAsync(ProductSaleStatusDto dto);
}