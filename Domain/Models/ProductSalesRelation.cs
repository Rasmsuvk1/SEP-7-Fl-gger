using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public class ProductSalesRelation
{
    [Key] 
    [Column ("psr")]
    public string psr { get; set; }
   
   [Column ("orderId")]
   public string orderid { get; set; }

   [Column("productId")] 
   public string productId { get; set; }
   
   public ProductSalesRelation(string psr, string orderid, string productId)
   {
       this.psr = psr;
       this.orderid = orderid;
       this.productId = productId;
   }
}