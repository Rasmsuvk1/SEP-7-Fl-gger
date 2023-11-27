using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Product
{
    
    [Key]
    public int ProductId { get; set;}
    public string ColorName { get; set;}
    public string Category { get; set; }
    public string? Surface { get; set; }
    public string? Shine { get; set; }
    public double Amount { get; set; }
    public double Price { get; set; }
    public DateOnly ExpireDate { get; set; }
    
    public string IMGUrl { get; set; }

    public Product(string colorName, string category, double amount, double price, DateOnly expireDate, string imgUrl)
    {
        ColorName = colorName;
        Category = category;
        Amount = amount;
        Price = price;
        ExpireDate = expireDate;
        IMGUrl = imgUrl;
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
    }

    public Product()
    {
    }
}