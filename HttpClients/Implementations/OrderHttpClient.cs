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
}