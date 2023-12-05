using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public class Order
{
    [Key]
    [Column ("orderid")]
    public int OrderId { get; set; }
    
    [Column ("purhasdedate")]
    public DateOnly PurchaseDate { get; set; }
    
    [Column ("deliverymethod")]
    public string DeliveryMethod { get; set; }
    
    [Column ("customerid")]
    public int CustomerId { get; set; }
    

    public Order(DateOnly purchaseDate, string deliveryMethod, int customerId )
    {
        PurchaseDate = purchaseDate;
        DeliveryMethod = deliveryMethod;
        CustomerId = customerId;
    }

    public Order(){}
}