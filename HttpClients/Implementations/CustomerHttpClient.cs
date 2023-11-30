using System.Net.Http.Json;
using System.Text.Json;
using Domain.DTOs.CustomerDTOS;
using Domain.Models;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class CustomerHttpClient : ICustomerSerivce
{
    private readonly HttpClient client;

    public CustomerHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<CustomerInfo> CreateAsync(CustomerCreationDto dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/customer", dto);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        CustomerInfo customerInfo = JsonSerializer.Deserialize<CustomerInfo>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return customerInfo;
    }
}