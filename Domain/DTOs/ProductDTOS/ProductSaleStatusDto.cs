using Domain.Models;

namespace Domain.DTOs;

public class ProductSaleStatusDto
{
    public List<int> Indexes = new List<int>();


    public ProductSaleStatusDto(List<int> indexes)
    {
        Indexes = indexes;
    }
    public void AddIndex(int i)
    {
        Indexes.Add(i);
    }

    public List<int> GetIndexes()
    {
        return Indexes;
    }

}