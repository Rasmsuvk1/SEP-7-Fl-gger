using Application.Ilogic;
using Domain.DTOs;
using Domain.DTOs.CustomerDTOS;
using Domain.DTOs.OrderDTOS;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers;

[ApiController]
[Route("[controller]")]

public class OrderController : ControllerBase
{
    
    private readonly IOrderLogic orderLogic;
    private readonly IProductLogic productLogic;

    public OrderController(IOrderLogic orderLogic, IProductLogic productLogic)
    {
        this.orderLogic = orderLogic;
        this.productLogic = productLogic;
    }
    
    [HttpPost]
    public async Task<ActionResult<Order>> CreateAsync(OrderCreationDto dto)
    {
        try
        {
            Order created = await orderLogic.CreateAsync(dto);
            return Created($"/Order/{created.OrderId}", created);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    
    [HttpGet]
    public async Task<ActionResult<List<Order>>> GetCustomerAsync(int? orderId, int? customerId, DateOnly? purchaseDate, string? name)
    {
        
        try
        {
            GetOrderDto dto = new GetOrderDto(orderId, customerId, purchaseDate, name);
            List<Order> orders = await orderLogic.GetAsync(dto);
            return Ok(orders);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return StatusCode(500, e.Message);

        }
    }
    
    
    
    
    
}