using Domain.Models;

namespace Domain.DTOs.OrderDTOS;

public class OrderCreationDto
{
    public DateOnly PurchaseDate { get; set; }
    
    public string DeliveryMethod { get; set; }
    
    public CustomerInfo Customer { get; set; }
    
    public List<int> ProductIds { get; set; }
    
    
    public OrderCreationDto(DateOnly purchaseDate, string deliveryMethod, CustomerInfo customer, List<int> productIds )
    {
        PurchaseDate = purchaseDate;
        DeliveryMethod = deliveryMethod;
        Customer = customer;
        ProductIds = productIds;
    }
}