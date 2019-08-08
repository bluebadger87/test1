using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ShopProject.Models
{
   public class Order
   {
      [Key]
      [DisplayName("OrderNo")]
      public int OrderNo { get; set; }
      [DisplayName("UserNo")]
      public int OrderUserNo { get; set; }
      [DisplayName("TotalPrice")]
      public int OrderTotalPrice { get; set; }
      [DisplayName("Delivery")]
      public string OrderDelivery { get; set; }
      [DataType(DataType.Date)]
      [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
      [DisplayName("DataInputDate")]
      public DateTime OrderInp { get; set; }
      [ForeignKey("OrderUserNo")]
      public User User { get; set; }
   }
}



