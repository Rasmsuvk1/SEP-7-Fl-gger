using Domain.Models;

namespace Domain.DTOs.OrderDTOS;

public class OrderCreation
{
    public DateOnly PurchaseDate { get; set; }
    
    public string DeliveryMethod { get; set; }
    
    public CustomerInfo Customer { get; set; }
    
    public List<int> ProductIds { get; set; }
    
    
    public OrderCreation(DateOnly purchaseDate, string deliveryMethod, CustomerInfo customerId, List<int> productIds )
    {
        PurchaseDate = purchaseDate;
        DeliveryMethod = deliveryMethod;
        Customer = customerId;
        ProductIds = productIds;
    }
}