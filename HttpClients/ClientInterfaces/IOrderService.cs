using Domain.DTOs.OrderDTOS;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IOrderService
{
    public Task<Order> CreateAsync(OrderCreationDto dto);
}