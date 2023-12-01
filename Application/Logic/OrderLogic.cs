using System.Runtime.CompilerServices;
using Application.Idao;
using Application.Ilogic;
using Domain.DTOs;
using Domain.DTOs.OrderDTOS;
using Domain.Models;


namespace Application.Logic;

public class OrderLogic : IOrderLogic
{
    private readonly IOrderDao orderDao;
    
    public OrderLogic(IOrderDao orderDao)
    {
        this.orderDao = orderDao;
    }
    
    public async Task<Order> CreateAsync(OrderCreationDto orderToCreate)
    {
        return await orderDao.CreateAsync(orderToCreate);
    }

    public async Task<List<Order>> GetAsync(GetOrderDto dto)
    {
        return await orderDao.GetAsync(dto);
    }

}