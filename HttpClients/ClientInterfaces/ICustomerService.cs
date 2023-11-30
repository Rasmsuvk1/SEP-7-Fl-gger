using Domain.DTOs.CustomerDTOS;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface ICustomerSerivce
{
    public Task<CustomerInfo> CreateAsync(CustomerCreationDto dto);
}