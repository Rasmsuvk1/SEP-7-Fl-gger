using Application.Idao;
using Application.Ilogic;
using Domain.DTOs.CustomerDTOS;
using Domain.Models;

namespace Application.Logic;

public class CustomerLogic : ICustomerLogic
{

    private readonly ICustomerDao dao;
    
    public CustomerLogic(ICustomerDao dao)
    {
        this.dao = dao;
    }
    
    
    public async Task<CustomerInfo> CreateAsync(CustomerCreationDto customerToCreate)
    {
        return await dao.CreateAsync(customerToCreate);
    }

    public async Task<CustomerInfo> GetCustomerAsync(GetCustomerDto dto)
    {
        return await dao.GetCustomerAsync(dto);
    }
}