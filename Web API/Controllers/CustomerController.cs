using Application.Ilogic;
using Domain.DTOs.CustomerDTOS;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers;
[ApiController]
[Route("[controller]")]

public class CustomerController : ControllerBase
{
    private readonly ICustomerLogic customerLogic;

    public CustomerController(ICustomerLogic customerLogic)
    {
        this.customerLogic = customerLogic;
    }
    
    [HttpPost]
    public async Task<ActionResult<CustomerInfo>> CreateAsync(CustomerCreationDto dto)
    {
        try
        {
            CustomerInfo created = await customerLogic.CreateAsync(dto);
            return Created($"/Customer/{created.Name}", created);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetCustomerAsync([FromQuery] string? name, [FromQuery] string? tlf,
        [FromQuery] string? email)
    {
        if (name == null && tlf == null && email == null)
        {
            throw new Exception("No information was provided");
        }
        
        try
        {
            GetCustomerDto dto = new GetCustomerDto(name, tlf, email);
            CustomerInfo customer = await customerLogic.GetCustomerAsync(dto);
            return Ok(customer);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return StatusCode(500, e.Message);

        }
    }
}