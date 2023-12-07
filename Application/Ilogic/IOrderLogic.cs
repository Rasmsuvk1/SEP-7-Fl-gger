using Domain.DTOs.OrderDTOS;
using Domain.Models;

namespace Application.Ilogic;

public interface IOrderLogic
{
    Task<Order> CreateAsync(OrderCreationDto dto);
    
    Task<List<ReturningOrderDto>> GetAsync(GetOrderDto dto);
}