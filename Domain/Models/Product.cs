using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public class Product
{
    
    [Key]
    [Column ("productid")]
    public int ProductId { get; set;}
    
    [Column ("colorname")]
    public string ColorName { get; set;}
    
    [Column ("category")]
    public string Category { get; set; }
    
    [Column ("surface")]
    public string? Surface { get; set; }
    
    [Column ("shine")]
    public string? Shine { get; set; }
    
    [Column ("amount")]
    public double Amount { get; set; }
    
    [Column ("price")]
    public double Price { get; set; }
    
    [Column ("expiredate")]
    public DateOnly ExpireDate { get; set; }
    
    //Need to insert these into the DB:
    [Column ("imgurl")]
    public string IMGUrl { get; set; }
    
    [Column ("isavailable")]
    public bool IsAvailable { get; set; }
    

    public Product(string colorName, string category, double amount, double price, DateOnly expireDate, string imgUrl)
    {
        ColorName = colorName;
        Category = category;
        Surface = null;
        Shine = null;
        Amount = amount;
        Price = price;
        ExpireDate = expireDate;
        IMGUrl = imgUrl;
        IsAvailable = true;
    }

    public Product(string colorName, string category, string? surface, string? shine, double amount, double price, DateOnly expireDate, string imgUrl)
    {
        ColorName = colorName;
        Category = category;
        Surface = surface;
        Shine = shine;
        Amount = amount;
        Price = price;
        ExpireDate = expireDate;
        IMGUrl = imgUrl;
        IsAvailable = true;
    }

    public Product()
    {
    }

    public void changeAvailability()
    {
        IsAvailable = false;
    }
}