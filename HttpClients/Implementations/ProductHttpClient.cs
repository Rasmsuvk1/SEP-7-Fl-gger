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

    public async Task<Product> CreateAsync(ProductCreationDto dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/Product", dto);
          string content = await response.Content.ReadAsStringAsync();

          Product product = JsonSerializer.Deserialize<Product>(content, new JsonSerializerOptions
          {
            PropertyNameCaseInsensitive = true
          })!; 
          return product;
    }

    public async Task<List<Product>> GetAsync(ProductListDto dto)
    {
        
        string uri = $"http://localhost:5075/Product?listSize={dto.ListSize}&pageNumber={dto.PageNumber}";
        if (!string.IsNullOrEmpty(dto.Category))
        {
            uri += $"&category={dto.Category}";
        }
        if(!string.IsNullOrEmpty(dto.PriceStart))
        {
            uri += $"&priceStart={dto.PriceStart}";
        }
        if(!string.IsNullOrEmpty(dto.Color))
        {
            uri += $"&color={dto.Color}";
        }
        if(dto.ProductItem > 0)
        {
            uri += $"&productItem={dto.ProductItem}";
        }
       

        HttpResponseMessage response = await client.GetAsync(uri);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        List<Product> post = JsonSerializer.Deserialize<List<Product>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return post;
    }
}