using Application.Ilogic;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers;
[ApiController]
[Route("[controller]")]

public class ProductController : ControllerBase
{
    private readonly IProductLogic productLogic;

    public ProductController(IProductLogic productLogic)
    {
        this.productLogic = productLogic;
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateAsync(Product dto)
    {
        try
        {
            //Product dto = new Product("Navy Blue", "Room", 2.5, 275, new DateOnly(224,11,29), "https://flugger-vanlose.dk/wp-content/uploads/2022/01/proeve.png");
            Product product = await productLogic.CreateAsync(dto);
            return Created($"/users/{product.ColorName}", product);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}