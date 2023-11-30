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
       Console.WriteLine(dto.Name);
        throw new NotImplementedException();
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetListAsync([FromQuery]string? name, [FromQuery]string? tlf, [FromQuery]string? email )
    {
        if (name == null && tlf == null && email == null)
        {
            throw new Exception("No information was provided");
        }
        GetCustomerDto dto = new GetCustomerDto(name, tlf, email);
        throw new NotImplementedException();
    }

}