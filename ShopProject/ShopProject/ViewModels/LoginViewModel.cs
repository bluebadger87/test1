using ShopProject.Models;
using System.ComponentModel.DataAnnotations;

namespace ShopProject.ViewModels
{
   public class LoginViewModel
   {
      [Required(ErrorMessage = "Insert your Id")]
      public string UserId { get; set; }
      [Required(ErrorMessage = "Insert your Password")]
      public string UserPassword1 { get; set; }
      public User User { get; set; }
   }
}
