using Application.Idao;
using DataBaseAccess.DBContext;
using Domain.DTOs.OrderDTOS;
using Domain.Models;

namespace DataBaseAccess.DAOs;

public class OrderDao : IOrderDao
{
    
    private readonly DatabaseContext _context;
    
    public OrderDao(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<Order> CreateAsync(OrderCreationDto orderToCreate)
    {
        try
        {
            //Creating the order:
            Order creationOrder = new Order(orderToCreate.PurchaseDate, orderToCreate.DeliveryMethod,
                orderToCreate.Customer.CustomerId);
            await _context.sale.AddAsync(creationOrder);
            await _context.SaveChangesAsync();

            List<ProductSalesRelation> newPSR = new List<ProductSalesRelation>();
            //Creating the products in the order
            foreach (var productId in orderToCreate.ProductIds)
            {
                newPSR.Add(new ProductSalesRelation(creationOrder.OrderId,productId));
            }
            await _context.productSalesRelations.AddRangeAsync(newPSR);
            await _context.SaveChangesAsync();
            return creationOrder;
        }catch(Exception e)
        {
            Console.WriteLine(e.Message);
            throw new Exception("Error creating new Order!");
        }
    }
    
    public Task<List<Order>> GetAsync(GetOrderDto dto)
    {
        throw new NotImplementedException();
    }
}