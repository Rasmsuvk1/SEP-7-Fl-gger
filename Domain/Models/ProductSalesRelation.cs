using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public class ProductSalesRelation
{
    [Key] 
    [Column ("psr")]
    public int psr { get; set; }
   
   [Column ("orderid")]
   public int OrderId { get; set; }

   [Column("productid")] 
   public int ProductId { get; set; }
   
   public ProductSalesRelation( int orderId, int productId)
   {
       OrderId = orderId;
       ProductId = productId;
   }
}