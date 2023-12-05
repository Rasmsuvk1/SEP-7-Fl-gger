using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IProductService
{
    public Task<Product> CreateAsync(ProductCreationDto dto);

    public  Task<List<Product>> GetAsync(ProductListDto dto);

    public Task<List<int>> UpdateSalesStatusAsync(List<int> ints);
    
}