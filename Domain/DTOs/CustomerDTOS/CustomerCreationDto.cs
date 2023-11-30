namespace Domain.DTOs.CustomerDTOS;

public class CustomerCreationDto
{
    public string Name { get; set; }
    
    public string Email { get; set; }
    
    public char Tlf { get; set; }

    public string address { get; set; }
    
    public CustomerCreationDto(string name, string email, char tlf, string address)
    {
        Name = name;
        Email = email;
        Tlf = tlf;
        this.address = address;
    }
}