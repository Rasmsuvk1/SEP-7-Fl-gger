namespace Domain.DTOs.CustomerDTOS;

public class CustomerCreationDto
{
    public string Name { get; set; }
    
    public string Email { get; set; }
    
    public string Tlf { get; set; }

    public string address { get; set; }
    
    public CustomerCreationDto(string name, string email, string tlf, string address)
    {
        Name = name;
        Email = email;
        Tlf = tlf;
        this.address = address;
    }
    
    public CustomerCreationDto() { }
}