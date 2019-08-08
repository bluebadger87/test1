using ShopProject.DataContext;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ShopProject.Models
{
   public class State
   {
      [Key]
      public int StateId { get; set; }
      public string Statename { get; set; }
      public int CountryId { get; set; }
      [ForeignKey("CountryId")]
      public Country Country { get; set; }

      public static void Initialize(ShopDbContext context)
      {
         var t = context.Set<State>();
         if (t.Any() == false)
         {
            t.AddRange(
                new State() { CountryId = 1, Statename = "LasVegas" },
                new State() { CountryId = 1, Statename = "Phoenix" },
                new State() { CountryId = 1, Statename = "SanDiego" },
                new State() { CountryId = 1, Statename = "Seattle" },
                new State() { CountryId = 2, Statename = "Tokyo" },
                new State() { CountryId = 2, Statename = "Osaka" },
                new State() { CountryId = 2, Statename = "Nagoya" },
                new State() { CountryId = 2, Statename = "Kobe" },
                new State() { CountryId = 3, Statename = "Seoul" },
                new State() { CountryId = 3, Statename = "Busan" },
                new State() { CountryId = 3, Statename = "Kyeongi" },
                new State() { CountryId = 3, Statename = "Jeju" },
                new State() { CountryId = 4, Statename = "Beijing" },
                new State() { CountryId = 4, Statename = "HongKong" },
                new State() { CountryId = 4, Statename = "Sian" },
                new State() { CountryId = 4, Statename = "Taiwan" });
            context.SaveChanges();
         }
      }
   }
}
