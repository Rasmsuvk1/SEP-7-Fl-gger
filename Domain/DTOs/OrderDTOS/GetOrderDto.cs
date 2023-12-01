namespace Domain.DTOs.OrderDTOS;

public class GetOrderDto
{
    public int? OrderId;

    public int? CustomerId;

    public DateOnly? PurchaseDate;

    public string? Name;


    public GetOrderDto(int? orderId, int? customerId, DateOnly? purchaseDate, string? name)
    {
        OrderId = orderId;
        CustomerId = customerId;
        PurchaseDate = purchaseDate;
        Name = name;
    }
}