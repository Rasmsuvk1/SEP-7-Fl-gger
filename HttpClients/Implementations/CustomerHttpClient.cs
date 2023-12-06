
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
        //Validate for special letters:
        dto.Name = dataValidation(dto.Name);
        dto.address = dataValidation(dto.address);
        dto.Email = dataValidation(dto.Email);
        dto.Tlf = dataValidation(dto.Tlf);
        
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


    private string dataValidation(string check)
    {
        string returnString = check;

        if (returnString.Contains("Ø") || returnString.Contains("ø"))
        {
            returnString = returnString.Replace("Ø", "OE");
            returnString = returnString.Replace("ø", "oe");
        }

        if (returnString.Contains("Æ") || returnString.Contains("æ"))
        {
            returnString = returnString.Replace("Æ", "AE");
            returnString = returnString.Replace("æ", "ae");
        }
        if (returnString.Contains("Å") || returnString.Contains("å"))
        {
            returnString = returnString.Replace("Å", "AA");
            returnString = returnString.Replace("å", "aa");
        }
        if (returnString.Contains("+45"))
        {
            returnString = returnString.Replace("+", "");
        }

        return returnString;
    }
}