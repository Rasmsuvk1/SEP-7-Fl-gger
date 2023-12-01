using Domain.DTOs.CustomerDTOS;
using Domain.Models;

namespace Application.Ilogic;

public interface ICustomerLogic
{
    
    Task<CustomerInfo> CreateAsync(CustomerCreationDto customerToCreate);

    Task<CustomerInfo> GetCustomerAsync(GetCustomerDto dto);
}