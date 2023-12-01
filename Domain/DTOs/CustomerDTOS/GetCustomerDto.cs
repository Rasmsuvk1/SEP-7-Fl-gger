namespace Domain.DTOs.CustomerDTOS;

public class GetCustomerDto
{
    public string? Name { get; set; }
    public string? Tlf  { get; set; }
    public string? Email  { get; set; }

    public GetCustomerDto(string? name, string? tlf, string? email)
    {
        Name = name;
        Tlf = tlf;
        Email = email;
    }
}

