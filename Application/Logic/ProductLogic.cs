using Application.Idao;
using Application.Ilogic;
using Domain.Models;

namespace Application.Logic;

public class ProductLogic : IProductLogic
{
    private readonly IProductDao productDao;

    public ProductLogic(IProductDao productDao)
    {
        this.productDao = productDao;
    }
    
    public Task<Product> CreateAsync(Product productToCreate)
    {
       return productDao.CreateAsync(productToCreate);
    }
}