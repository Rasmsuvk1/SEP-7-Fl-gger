using Application.Idao;
using Domain.DTOs.OrderDTOS;
using Domain.Models;

namespace DataBaseAccess.DAOs;

public class OrderDao : IOrderDao
{
    public Task<Order> CreateAsync(OrderCreationDto orderToCreate)
    {
        throw new NotImplementedException();
    }
    
    public Task<List<Order>> GetAsync(GetOrderDto dto)
    {
        throw new NotImplementedException();
    }
}