using ShopProject.DataContext;
using System.Linq;

namespace ShopProject.Models
{
   public class ProductCategoryList
   {
      public int Id { get; set; }
      public string Name { get; set; }

      public static void Initialize(ShopDbContext context)
      {
         var t = context.Set<ProductCategoryList>();
         if (t.Any() == false)
         {
            t.AddRange(
                new ProductCategoryList() { Name = "" },
                new ProductCategoryList() { Name = "Bed" },
                new ProductCategoryList() { Name = "Chair" },
                new ProductCategoryList() { Name = "Desk" },
                new ProductCategoryList() { Name = "Light" },
                new ProductCategoryList() { Name = "Hanger" },
                new ProductCategoryList() { Name = "Sofa" },
                new ProductCategoryList() { Name = "ETC" });
            context.SaveChanges();
         }
      }
   }
}
