using ShopProject.DataContext;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ShopProject.Models
{
   public class Country
   {
      [Key]
      public int CountryId { get; set; }
      public string Countryname { get; set; }

      public static void Initialize(ShopDbContext context)
      {
         var t = context.Set<Country>();
         if (t.Any() == false)
         {
            t.AddRange(
                new Country() { Countryname = "America" },
                new Country() { Countryname = "Japan" },
                new Country() { Countryname = "Korea" },
                new Country() { Countryname = "China" });
            context.SaveChanges();
         }
      }
   }
}
