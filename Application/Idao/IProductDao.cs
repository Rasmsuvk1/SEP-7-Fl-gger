using Domain.Models;

namespace Application.Idao;

public interface IProductDao
{
    Task<Product> CreateAsync(Product productToCreate);
}