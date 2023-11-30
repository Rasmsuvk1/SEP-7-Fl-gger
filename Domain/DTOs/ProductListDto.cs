namespace Domain.DTOs;

public class ProductListDto
{
    public string? Category;
    //Either "high" or "low" to sort the list based on price
    public string? PriceStart;

    public string? Color;

    public void setCategory(string? category)
    {
        Category = category;

    }
    public void setPrice(string? priceStart)
    {
        PriceStart = priceStart;

    }
    public void setColor(string? color)
    {
        Color = color;
    }
    
    

}