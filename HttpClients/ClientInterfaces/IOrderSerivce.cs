using Domain.DTOs.OrderDTOS;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IOrderSerivce
{
    public Task<Order> CreateAsync(OrderCreationDto dto);
}