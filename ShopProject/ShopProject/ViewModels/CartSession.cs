using ShopProject.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopProject.ViewModels
{
   public class CartSession
   {
      public int ProductId { get; set; }
      public int ProductCount { get; set; }
      [ForeignKey("ProductId")]
      public Product Product { get; set; }
   }
}
