using System.Net.Http.Json;
using System.Text.Json;
using Domain.DTOs.OrderDTOS;
using Domain.Models;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class OrderHttpClient : IOrderService
{
    private readonly HttpClient client;

    public OrderHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<Order> CreateAsync(OrderCreationDto dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/Order", dto);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        Order order = JsonSerializer.Deserialize<Order>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return order ;
    }

    public async Task<List<ReturningOrderDto>> GetCustomerAsync(int? orderId, int? customerId, DateOnly? purchaseDate, string? name)
    {
        string uri = $"http://localhost:5075/Order?";
        if(orderId > 0)
        {
            uri += $"orderId={orderId}";
        }
        if (customerId > 0)
        {
            uri += $"customerId={customerId}";
        }
        if (purchaseDate != null)
        {
            uri += $"purchaseDate={purchaseDate}";
        }
        if (!string.IsNullOrEmpty(name))
        {
            uri += $"name={name}";
        }
        HttpResponseMessage response = await client.GetAsync(uri);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        List<ReturningOrderDto> returnOrder = JsonSerializer.Deserialize<List<ReturningOrderDto>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return returnOrder;
    }
}