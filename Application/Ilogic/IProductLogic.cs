using Domain.DTOs;
using Domain.Models;

namespace Application.Ilogic;

public interface IProductLogic
{
    Task<Product> CreateAsync(Product productToCreate);

    Task<List<Product>> GetListAsync(ProductListDto dto);
}