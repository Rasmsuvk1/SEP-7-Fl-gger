using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public class CustomerInfo
{
    [Key]
    [Column("customerid")]
    public int CustomerId { get; set; }
    
    [Column("name")]
    public string Name { get; set; }
    
    [Column("email")]
    public string Email { get; set; }
    
    [Column("tlf")]
    public string Tlf { get; set; }
    
    [Column("address")]
    public string address { get; set; }

    public CustomerInfo(string name, string email, string tlf, string address)
    {
        Name = name;
        Email = email;
        Tlf = tlf;
        this.address = address;
    }
    
    public CustomerInfo(){}
}
