using Domain.DTOs.CustomerDTOS;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface ICustomerService
{
    public Task<CustomerInfo> CreateAsync(CustomerCreationDto dto);
}