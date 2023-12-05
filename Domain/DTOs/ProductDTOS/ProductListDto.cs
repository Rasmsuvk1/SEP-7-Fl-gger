namespace Domain.DTOs;

public class ProductListDto
{
    public string? Category;
    //Either "high" or "low" to sort the list based on price
    public string? PriceStart;

    public string? Color;

    public int? ProductItem;

    public int ListSize;

    public int PageNumber;
    


    public ProductListDto(string? category, string? priceStart, string? color, int listSize, int pageNumber, int? productItem)
    {
        Category = category;
        PriceStart = priceStart;
        Color = color;
        ListSize = listSize;
        PageNumber = pageNumber;
        ProductItem = productItem;
    }

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