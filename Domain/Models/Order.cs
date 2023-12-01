using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public class Order
{
    [Key]
    [Column ("orderid")]
    public int OrderId { get; set; }
    
    [Column ("purchasdedate")]
    public DateOnly PurchaseDate { get; set; }
    
    [Column ("deliverymethod")]
    public string DeliveryMethod { get; set; }
    
    [Column ("customerid")]
    public CustomerInfo Customer { get; set; }

    public List<Product> Products { get; set; } = new List<Product>();

    public Order(DateOnly purchaseDate, string deliveryMethod, CustomerInfo customerId, List<Product> products )
    {
        PurchaseDate = purchaseDate;
        DeliveryMethod = deliveryMethod;
        Customer = customerId;
        Products = products;
    }

    public Order(){}
}