using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopProject.Models
{
   public class OrderDetail
   {
      [Key]
      public int OrderDetailNo { get; set; }
      public int OrderDetailOrderNo { get; set; }
      [DisplayName("ProductNo")]
      public int OrderDetailProductNo { get; set; }
      public int OrderDetailQuantity { get; set; }
      [DataType(DataType.Date)]
      [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
      public DateTime OrderDetailInp { get; set; }
      [ForeignKey("OrderDetailOrderNo")]
      public Order Order { get; set; }
      [ForeignKey("OrderDetailProductNo")]
      public Product Product { get; set; }
   }
}

