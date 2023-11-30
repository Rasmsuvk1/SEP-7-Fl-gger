using System.Net.Http.Json;
using System.Text.Json;
using Domain.DTOs;
using Domain.Models;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class ProductHttpClient : IProductService
{
    private readonly HttpClient client;

    public ProductHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<Product> CreateAsync(ProductListDto dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/products", dto);
          string content = await response.Content.ReadAsStringAsync();
          if (!response.IsSuccessStatusCode)
          {
              throw new Exception(content);
          }

          Product product = JsonSerializer.Deserialize<Product>(content, new JsonSerializerOptions
          {
            PropertyNameCaseInsensitive = true
          })!; 
          return product;
    }
}