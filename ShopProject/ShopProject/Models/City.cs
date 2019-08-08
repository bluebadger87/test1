using ShopProject.DataContext;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ShopProject.Models
{
   public class City
   {
      [Key]
      public int CityId { get; set; }
      public string Cityname { get; set; }
      public int StateId { get; set; }
      [ForeignKey("StateId")]
      public State State { get; set; }

      public static void Initialize(ShopDbContext context)
      {
         var t = context.Set<City>();
         if (t.Any() == false)
         {
            t.AddRange(
                new City() { StateId = 1, Cityname = "Winchester" },
                new City() { StateId = 1, Cityname = "Sundown" },
                new City() { StateId = 1, Cityname = "Dry Lake" },
                new City() { StateId = 1, Cityname = "White Hills" },
                new City() { StateId = 2, Cityname = "Waddell" },
                new City() { StateId = 2, Cityname = "Gilbert" },
                new City() { StateId = 2, Cityname = "Mesa" },
                new City() { StateId = 2, Cityname = "Chandler" },
                new City() { StateId = 3, Cityname = "Coronado" },
                new City() { StateId = 3, Cityname = "National City" },
                new City() { StateId = 3, Cityname = "Hillcrest" },
                new City() { StateId = 3, Cityname = "Ocean Beach" },
                new City() { StateId = 4, Cityname = "Seward Park" },
                new City() { StateId = 4, Cityname = "Mount Baker" },
                new City() { StateId = 4, Cityname = "Madrona" },
                new City() { StateId = 4, Cityname = "Stevens" },
                new City() { StateId = 5, Cityname = "Nagano" },
                new City() { StateId = 5, Cityname = "Shinjuku" },
                new City() { StateId = 5, Cityname = "Chiba" },
                new City() { StateId = 5, Cityname = "Minato" },
                new City() { StateId = 6, Cityname = "Higasinari" },
                new City() { StateId = 6, Cityname = "kita" },
                new City() { StateId = 6, Cityname = "Nishinari" },
                new City() { StateId = 6, Cityname = "Matubara" },
                new City() { StateId = 7, Cityname = "Nakamura" },
                new City() { StateId = 7, Cityname = "Shouwa" },
                new City() { StateId = 7, Cityname = "Mizuho" },
                new City() { StateId = 7, Cityname = "Atuta" },
                new City() { StateId = 8, Cityname = "Nakata" },
                new City() { StateId = 8, Cityname = "Suma" },
                new City() { StateId = 8, Cityname = "Aina" },
                new City() { StateId = 8, Cityname = "Hyogo" },
                new City() { StateId = 9, Cityname = "Zamsil" },
                new City() { StateId = 9, Cityname = "Sinlim" },
                new City() { StateId = 9, Cityname = "Gangnam" },
                new City() { StateId = 9, Cityname = "Myeongdong" },
                new City() { StateId = 10, Cityname = "Gaya" },
                new City() { StateId = 10, Cityname = "Gunam" },
                new City() { StateId = 10, Cityname = "Hadan" },
                new City() { StateId = 10, Cityname = "Beomil" },
                new City() { StateId = 11, Cityname = "Seomnam" },
                new City() { StateId = 11, Cityname = "Bundang" },
                new City() { StateId = 11, Cityname = "Anyang" },
                new City() { StateId = 11, Cityname = "Guacheon" },
                new City() { StateId = 12, Cityname = "Andeok" },
                new City() { StateId = 12, Cityname = "Unjin" },
                new City() { StateId = 12, Cityname = "Hanlim" },
                new City() { StateId = 12, Cityname = "Dodu" },
                new City() { StateId = 13, Cityname = "Nanyuanxiang" },
                new City() { StateId = 13, Cityname = "Nizhuang" },
                new City() { StateId = 13, Cityname = "Xidiancun" },
                new City() { StateId = 13, Cityname = "Liqiaozhen" },
                new City() { StateId = 14, Cityname = "ShekKipMei" },
                new City() { StateId = 14, Cityname = "PakTin" },
                new City() { StateId = 14, Cityname = "OmYau" },
                new City() { StateId = 14, Cityname = "UnChau" },
                new City() { StateId = 15, Cityname = "Xinjiamiao" },
                new City() { StateId = 15, Cityname = "Mawang" },
                new City() { StateId = 15, Cityname = "Qujiang" },
                new City() { StateId = 15, Cityname = "Tumen" },
                new City() { StateId = 16, Cityname = "Lantan" },
                new City() { StateId = 16, Cityname = "HsiHu" },
                new City() { StateId = 16, Cityname = "Wufeng " },
                new City() { StateId = 16, Cityname = "Taichung" });
            context.SaveChanges();
         }
      }
   }
}
