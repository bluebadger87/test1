using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopProject.Models
{
   public class ProductComment
   {
      [Key]
      public int CommentId { get; set; }
      public string CommnetContent { get; set; }
      public double CommnetScore { get; set; }
      public DateTime CommentUpdDate { get; set; }
      public DateTime CommentInpDate { get; set; }
      public int CommentUserNo { get; set; }
      public int CommentProductNo { get; set; }
      public string CommentDel { get; set; }
      [ForeignKey("CommentUserNo")]
      public User User { get; set; }
      [ForeignKey("CommentProductNo")]
      public Product Product { get; set; }
   }
}
