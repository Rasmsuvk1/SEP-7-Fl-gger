using Domain.DTOs.CustomerDTOS;
using Domain.DTOs.OrderDTOS;
using Domain.Models;

namespace Application.Idao;

public interface IOrderDao
{
    Task<Order> CreateAsync(OrderCreationDto orderToCreate);
    Task<List<ReturningOrderDto>> GetAsync(GetOrderDto dto);
}