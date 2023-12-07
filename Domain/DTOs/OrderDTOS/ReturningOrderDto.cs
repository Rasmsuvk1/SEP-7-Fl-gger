using Domain.Models;

namespace Domain.DTOs.OrderDTOS;

public class ReturningOrderDto
{
    public int OrderId { get; set; }
    public string CustomerName{ get; set; }
    public string Email{ get; set; }
    public string Tlf{ get; set; }
    public string Address{ get; set; }
    
    public string ShippingMethod { get; set; }
    
    public DateOnly PurchaseDate { get; set; }
    public List<Product> Products{ get; set; }

    public ReturningOrderDto(int orderId, string customerName, string email, string tlf, string address, string shippingMethod, DateOnly purchaseDate, List<Product> products)
    {
        OrderId = orderId;
        CustomerName = customerName;
        Email = email;
        Tlf = tlf;
        Address = address;
        ShippingMethod = shippingMethod;
        PurchaseDate = purchaseDate;
        Products = products;
    }

    public ReturningOrderDto() { }
    
    
}