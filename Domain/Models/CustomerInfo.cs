using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class CustomerInfo
{
    [Key]
    public int CustomerId { get; set; }
    
    public string Name { get; set; }
    
    public string Email { get; set; }
    
    public char Tlf { get; set; }

    public string address { get; set; }

    public CustomerInfo(string name, string email, char tlf, string address)
    {
        Name = name;
        Email = email;
        Tlf = tlf;
        this.address = address;
    }
    
    public CustomerInfo(){}
}
