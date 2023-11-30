using Application.Idao;
using Application.Ilogic;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class ProductLogic : IProductLogic
{
    private readonly IProductDao productDao;

    public ProductLogic(IProductDao productDao)
    {
        this.productDao = productDao;
    }
    
    public async Task<Product> CreateAsync(Product productToCreate)
    {
       return await productDao.CreateAsync(productToCreate);
    }

    public async Task<List<Product>> GetListAsync(ProductListDto dto)
    {
        return await productDao.GetListAsync(dto);
    }

    public async Task<ProductSaleStatusDto> UpdateSaleStatusAsync(ProductSaleStatusDto dto)
    {
        return await productDao.UpdateSaleStatusAsync(dto);
    }
}