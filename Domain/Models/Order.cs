using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Order
{
    [Key]
    public int OrderId { get; set; }
    public DateOnly PurchaseDate { get; set; }
    public string DeliveryMethod { get; set; }
    public CustomerInfo CustomerId { get; set; }

    public List<Product> Products { get; set; } = new List<Product>();

    public Order(DateOnly purchaseDate, string deliveryMethod, CustomerInfo customerId, List<Product> products )
    {
        PurchaseDate = purchaseDate;
        DeliveryMethod = deliveryMethod;
        CustomerId = customerId;
        Products = products;
    }

    public Order(){}
}