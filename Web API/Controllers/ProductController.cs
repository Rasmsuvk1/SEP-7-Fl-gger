using Application.Ilogic;
using Domain.DTOs;
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
    public async Task<ActionResult<Product>> CreateAsync(ProductCreationDto dto)
    {
        try
        {
            Product productDto = new Product(dto.ColorName, dto.Category, dto.Surface, dto.Shine, dto.Amount, dto.Price,
                dto.ExpireDate, dto.IMGUrl);
            Product product = await productLogic.CreateAsync(productDto);
            return Created($"/Product/{product.ColorName}", product);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetListAsync([FromQuery] string? category,[FromQuery] int? productItem, [FromQuery] string? priceStart, [FromQuery] string? color, [FromQuery] int listSize, [FromQuery] int pageNumber)
    {
        if (listSize < 1)
        {
            //So the list doesnt return a negative size or with a size of 0;
            listSize = 10;
        }
        try
        {
            ProductListDto dto = new ProductListDto(category, priceStart, color, listSize, pageNumber, productItem);
            List<Product> productList = await productLogic.GetListAsync(dto);
            return Ok(productList);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return StatusCode(500, e.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult<List<int>>> UpdateSalesStatusAsync(List<int> ints)
    {
        try
        {
            ProductSaleStatusDto dto = new ProductSaleStatusDto(ints);
            Console.WriteLine(dto.GetIndexes().Count);
            ProductSaleStatusDto updated = await productLogic.UpdateSaleStatusAsync(dto);
            return Created($"/Product/{updated.Indexes}", updated.Indexes);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return StatusCode(500, e.Message);
        }
        
    }
}