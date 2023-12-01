using Domain.DTOs.CustomerDTOS;
using Domain.Models;

namespace Application.Idao;

public interface ICustomerDao
{
    Task<CustomerInfo> CreateAsync(CustomerCreationDto customerToCreate);
    Task<CustomerInfo> GetCustomerAsync(GetCustomerDto dto);
}