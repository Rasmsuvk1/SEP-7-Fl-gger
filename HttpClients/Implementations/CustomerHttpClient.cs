using System.Net.Http.Json;
using System.Text.Json;
using Domain.DTOs.CustomerDTOS;
using Domain.Models;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class CustomerHttpClient : ICustomerService
{
    private readonly HttpClient client;

    public CustomerHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<CustomerInfo> CreateAsync(CustomerCreationDto dto)
    {
        try
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("/Customer", dto);
            string result = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Hey man");
                throw new Exception(result);
            }

            CustomerInfo customer = JsonSerializer.Deserialize<CustomerInfo>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
            return customer;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.InnerException);
            throw;
        }
        
    }
}