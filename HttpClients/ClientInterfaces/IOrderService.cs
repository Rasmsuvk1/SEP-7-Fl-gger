using Domain.DTOs.OrderDTOS;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IOrderService
{
    public Task<Order> CreateAsync(OrderCreationDto dto);

    public Task<List<ReturningOrderDto>> GetCustomerAsync(int? orderId, int? customerId, DateOnly? purchaseDate, string? name);

}