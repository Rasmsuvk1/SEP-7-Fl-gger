using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IProductService
{
    public Task<Product> CreateAsync(ProductListDto dto);
}