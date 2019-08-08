using ShopProject.DataContext;
using System.Collections.Generic;
using System.Linq;

namespace ShopProject.Models
{
   public class ProductImages
   {
      public int Id { get; set; }
      public int DetailNo { get; set; }
      public int ProductImageNo { get; set; }
      public string ProductImageName { get; set; }

      public static void Initialize(ShopDbContext context)
      {
         var t = context.Set<ProductImages>();
         if (t.Any() == false)
         {
            var pro = new List<ProductImages>();
            pro.Add(new ProductImages() { DetailNo = 1, ProductImageNo = 1, ProductImageName = "basicImage1_1.png" });
            pro.Add(new ProductImages() { DetailNo = 2, ProductImageNo = 1, ProductImageName = "basicImage1_2.png" });
            pro.Add(new ProductImages() { DetailNo = 3, ProductImageNo = 1, ProductImageName = "basicImage1_3.png" });
            pro.Add(new ProductImages() { DetailNo = 1, ProductImageNo = 2, ProductImageName = "basicImage2_1.png" });
            pro.Add(new ProductImages() { DetailNo = 2, ProductImageNo = 2, ProductImageName = "basicImage2_2.png" });
            pro.Add(new ProductImages() { DetailNo = 3, ProductImageNo = 2, ProductImageName = "basicImage2_3.png" });
            pro.Add(new ProductImages() { DetailNo = 1, ProductImageNo = 3, ProductImageName = "basicImage3_1.png" });
            pro.Add(new ProductImages() { DetailNo = 2, ProductImageNo = 3, ProductImageName = "basicImage3_2.png" });
            pro.Add(new ProductImages() { DetailNo = 3, ProductImageNo = 3, ProductImageName = "basicImage3_3.png" });
            pro.Add(new ProductImages() { DetailNo = 1, ProductImageNo = 4, ProductImageName = "basicImage4_1.png" });
            pro.Add(new ProductImages() { DetailNo = 2, ProductImageNo = 4, ProductImageName = "basicImage4_2.png" });
            pro.Add(new ProductImages() { DetailNo = 3, ProductImageNo = 4, ProductImageName = "basicImage4_3.png" });
            pro.Add(new ProductImages() { DetailNo = 1, ProductImageNo = 5, ProductImageName = "basicImage5_1.png" });
            pro.Add(new ProductImages() { DetailNo = 2, ProductImageNo = 5, ProductImageName = "basicImage5_2.png" });
            pro.Add(new ProductImages() { DetailNo = 3, ProductImageNo = 5, ProductImageName = "basicImage5_3.png" });
            pro.Add(new ProductImages() { DetailNo = 1, ProductImageNo = 6, ProductImageName = "basicImage6_1.png" });
            pro.Add(new ProductImages() { DetailNo = 2, ProductImageNo = 6, ProductImageName = "basicImage6_2.png" });
            pro.Add(new ProductImages() { DetailNo = 3, ProductImageNo = 6, ProductImageName = "basicImage6_3.png" });
            pro.Add(new ProductImages() { DetailNo = 1, ProductImageNo = 7, ProductImageName = "basicImage7_1.png" });
            pro.Add(new ProductImages() { DetailNo = 2, ProductImageNo = 7, ProductImageName = "basicImage7_2.png" });
            pro.Add(new ProductImages() { DetailNo = 3, ProductImageNo = 7, ProductImageName = "basicImage7_3.png" });
            pro.Add(new ProductImages() { DetailNo = 1, ProductImageNo = 8, ProductImageName = "basicImage8_1.png" });
            pro.Add(new ProductImages() { DetailNo = 2, ProductImageNo = 8, ProductImageName = "basicImage8_2.png" });
            pro.Add(new ProductImages() { DetailNo = 3, ProductImageNo = 8, ProductImageName = "basicImage8_3.png" });
            pro.Add(new ProductImages() { DetailNo = 1, ProductImageNo = 9, ProductImageName = "basicImage9_1.png" });
            pro.Add(new ProductImages() { DetailNo = 2, ProductImageNo = 9, ProductImageName = "basicImage9_2.png" });
            pro.Add(new ProductImages() { DetailNo = 3, ProductImageNo = 9, ProductImageName = "basicImage9_3.png" });
            pro.Add(new ProductImages() { DetailNo = 1, ProductImageNo = 10, ProductImageName = "basicImage10_1.png" });
            pro.Add(new ProductImages() { DetailNo = 2, ProductImageNo = 10, ProductImageName = "basicImage10_2.png" });
            pro.Add(new ProductImages() { DetailNo = 3, ProductImageNo = 10, ProductImageName = "basicImage10_3.png" });
            pro.Add(new ProductImages() { DetailNo = 1, ProductImageNo = 11, ProductImageName = "basicImage11_1.png" });
            pro.Add(new ProductImages() { DetailNo = 2, ProductImageNo = 11, ProductImageName = "basicImage11_2.png" });
            pro.Add(new ProductImages() { DetailNo = 3, ProductImageNo = 11, ProductImageName = "basicImage11_3.png" });
            pro.Add(new ProductImages() { DetailNo = 1, ProductImageNo = 12, ProductImageName = "basicImage12_1.png" });
            pro.Add(new ProductImages() { DetailNo = 2, ProductImageNo = 12, ProductImageName = "basicImage12_2.png" });
            pro.Add(new ProductImages() { DetailNo = 3, ProductImageNo = 12, ProductImageName = "basicImage12_3.png" });
            pro.Add(new ProductImages() { DetailNo = 1, ProductImageNo = 13, ProductImageName = "basicImage13_1.png" });
            pro.Add(new ProductImages() { DetailNo = 2, ProductImageNo = 13, ProductImageName = "basicImage13_2.png" });
            pro.Add(new ProductImages() { DetailNo = 3, ProductImageNo = 13, ProductImageName = "basicImage13_3.png" });
            pro.Add(new ProductImages() { DetailNo = 1, ProductImageNo = 14, ProductImageName = "basicImage14_1.jpg" });
            pro.Add(new ProductImages() { DetailNo = 2, ProductImageNo = 14, ProductImageName = "basicImage14_2.jpg" });
            pro.Add(new ProductImages() { DetailNo = 3, ProductImageNo = 14, ProductImageName = "basicImage14_3.jpg" });
            pro.Add(new ProductImages() { DetailNo = 1, ProductImageNo = 15, ProductImageName = "basicImage15_1.jpg" });
            pro.Add(new ProductImages() { DetailNo = 2, ProductImageNo = 15, ProductImageName = "basicImage15_2.jpg" });
            pro.Add(new ProductImages() { DetailNo = 3, ProductImageNo = 15, ProductImageName = "basicImage15_3.jpg" });
            pro.Add(new ProductImages() { DetailNo = 1, ProductImageNo = 16, ProductImageName = "basicImage16_1.PNG" });
            pro.Add(new ProductImages() { DetailNo = 2, ProductImageNo = 16, ProductImageName = "basicImage16_2.png" });
            pro.Add(new ProductImages() { DetailNo = 3, ProductImageNo = 16, ProductImageName = "basicImage16_3.png" });
            pro.Add(new ProductImages() { DetailNo = 1, ProductImageNo = 17, ProductImageName = "basicImage17_1.png" });
            pro.Add(new ProductImages() { DetailNo = 2, ProductImageNo = 17, ProductImageName = "basicImage17_2.png" });
            pro.Add(new ProductImages() { DetailNo = 3, ProductImageNo = 17, ProductImageName = "basicImage17_3.png" });
            pro.Add(new ProductImages() { DetailNo = 1, ProductImageNo = 18, ProductImageName = "basicImage18_1.png" });
            pro.Add(new ProductImages() { DetailNo = 2, ProductImageNo = 18, ProductImageName = "basicImage18_2.png" });
            pro.Add(new ProductImages() { DetailNo = 3, ProductImageNo = 18, ProductImageName = "basicImage18_3.png" });
            pro.Add(new ProductImages() { DetailNo = 1, ProductImageNo = 19, ProductImageName = "basicImage19_1.png" });
            pro.Add(new ProductImages() { DetailNo = 2, ProductImageNo = 19, ProductImageName = "basicImage19_2.png" });
            pro.Add(new ProductImages() { DetailNo = 3, ProductImageNo = 19, ProductImageName = "basicImage19_3.png" });
            pro.Add(new ProductImages() { DetailNo = 1, ProductImageNo = 20, ProductImageName = "basicImage20_1.png" });
            pro.Add(new ProductImages() { DetailNo = 2, ProductImageNo = 20, ProductImageName = "basicImage20_2.png" });
            pro.Add(new ProductImages() { DetailNo = 3, ProductImageNo = 20, ProductImageName = "basicImage20_3.png" });
            pro.Add(new ProductImages() { DetailNo = 1, ProductImageNo = 21, ProductImageName = "basicImage21_1.png" });
            pro.Add(new ProductImages() { DetailNo = 2, ProductImageNo = 21, ProductImageName = "basicImage21_2.png" });
            pro.Add(new ProductImages() { DetailNo = 3, ProductImageNo = 21, ProductImageName = "basicImage21_3.png" });
            pro.Add(new ProductImages() { DetailNo = 1, ProductImageNo = 22, ProductImageName = "basicImage22_1.png" });
            pro.Add(new ProductImages() { DetailNo = 2, ProductImageNo = 22, ProductImageName = "basicImage22_2.png" });
            pro.Add(new ProductImages() { DetailNo = 3, ProductImageNo = 22, ProductImageName = "basicImage22_3.png" });
            pro.Add(new ProductImages() { DetailNo = 1, ProductImageNo = 23, ProductImageName = "basicImage23_1.png" });
            pro.Add(new ProductImages() { DetailNo = 2, ProductImageNo = 23, ProductImageName = "basicImage23_2.png" });
            pro.Add(new ProductImages() { DetailNo = 3, ProductImageNo = 23, ProductImageName = "basicImage23_3.png" });
            pro.Add(new ProductImages() { DetailNo = 1, ProductImageNo = 24, ProductImageName = "basicImage24_1.png" });
            pro.Add(new ProductImages() { DetailNo = 2, ProductImageNo = 24, ProductImageName = "basicImage24_2.png" });
            pro.Add(new ProductImages() { DetailNo = 3, ProductImageNo = 24, ProductImageName = "basicImage24_3.png" });
            pro.Add(new ProductImages() { DetailNo = 1, ProductImageNo = 25, ProductImageName = "basicImage25_1.png" });
            pro.Add(new ProductImages() { DetailNo = 2, ProductImageNo = 25, ProductImageName = "basicImage25_2.png" });
            pro.Add(new ProductImages() { DetailNo = 3, ProductImageNo = 25, ProductImageName = "basicImage25_3.png" });
            pro.Add(new ProductImages() { DetailNo = 1, ProductImageNo = 26, ProductImageName = "basicImage26_1.png" });
            pro.Add(new ProductImages() { DetailNo = 2, ProductImageNo = 26, ProductImageName = "basicImage26_2.png" });
            pro.Add(new ProductImages() { DetailNo = 3, ProductImageNo = 26, ProductImageName = "basicImage26_3.png" });
            pro.Add(new ProductImages() { DetailNo = 1, ProductImageNo = 27, ProductImageName = "basicImage27_1.png" });
            pro.Add(new ProductImages() { DetailNo = 2, ProductImageNo = 27, ProductImageName = "basicImage27_2.png" });
            pro.Add(new ProductImages() { DetailNo = 3, ProductImageNo = 27, ProductImageName = "basicImage27_3.png" });
            pro.Add(new ProductImages() { DetailNo = 1, ProductImageNo = 28, ProductImageName = "basicImage28_1.png" });
            pro.Add(new ProductImages() { DetailNo = 2, ProductImageNo = 28, ProductImageName = "basicImage28_2.png" });
            pro.Add(new ProductImages() { DetailNo = 3, ProductImageNo = 28, ProductImageName = "basicImage28_3.png" });
            pro.Add(new ProductImages() { DetailNo = 1, ProductImageNo = 29, ProductImageName = "basicImage29_1.png" });
            pro.Add(new ProductImages() { DetailNo = 2, ProductImageNo = 29, ProductImageName = "basicImage29_2.png" });
            pro.Add(new ProductImages() { DetailNo = 3, ProductImageNo = 29, ProductImageName = "basicImage29_3.png" });
            pro.Add(new ProductImages() { DetailNo = 1, ProductImageNo = 30, ProductImageName = "basicImage30_1.png" });
            pro.Add(new ProductImages() { DetailNo = 2, ProductImageNo = 30, ProductImageName = "basicImage30_2.png" });
            pro.Add(new ProductImages() { DetailNo = 3, ProductImageNo = 30, ProductImageName = "basicImage30_3.png" });
            pro.Add(new ProductImages() { DetailNo = 1, ProductImageNo = 31, ProductImageName = "basicImage31_1.png" });
            pro.Add(new ProductImages() { DetailNo = 2, ProductImageNo = 31, ProductImageName = "basicImage31_2.png" });
            pro.Add(new ProductImages() { DetailNo = 3, ProductImageNo = 31, ProductImageName = "basicImage31_3.png" });
            pro.Add(new ProductImages() { DetailNo = 1, ProductImageNo = 32, ProductImageName = "basicImage32_1.png" });
            pro.Add(new ProductImages() { DetailNo = 2, ProductImageNo = 32, ProductImageName = "basicImage32_2.png" });
            pro.Add(new ProductImages() { DetailNo = 3, ProductImageNo = 32, ProductImageName = "basicImage32_3.png" });
            pro.Add(new ProductImages() { DetailNo = 1, ProductImageNo = 33, ProductImageName = "basicImage33_1.png" });
            pro.Add(new ProductImages() { DetailNo = 2, ProductImageNo = 33, ProductImageName = "basicImage33_2.png" });
            pro.Add(new ProductImages() { DetailNo = 3, ProductImageNo = 33, ProductImageName = "basicImage33_3.png" });
            pro.Add(new ProductImages() { DetailNo = 1, ProductImageNo = 34, ProductImageName = "basicImage34_1.png" });
            pro.Add(new ProductImages() { DetailNo = 2, ProductImageNo = 34, ProductImageName = "basicImage34_2.png" });
            pro.Add(new ProductImages() { DetailNo = 3, ProductImageNo = 34, ProductImageName = "basicImage34_3.png" });
            pro.Add(new ProductImages() { DetailNo = 1, ProductImageNo = 35, ProductImageName = "basicImage35_1.jpg" });
            pro.Add(new ProductImages() { DetailNo = 2, ProductImageNo = 35, ProductImageName = "basicImage35_2.jpg" });
            pro.Add(new ProductImages() { DetailNo = 3, ProductImageNo = 35, ProductImageName = "basicImage35_3.jpg" });
            pro.Add(new ProductImages() { DetailNo = 1, ProductImageNo = 36, ProductImageName = "basicImage36_1.jpg" });
            pro.Add(new ProductImages() { DetailNo = 2, ProductImageNo = 36, ProductImageName = "basicImage36_2.jpg" });
            pro.Add(new ProductImages() { DetailNo = 3, ProductImageNo = 36, ProductImageName = "basicImage36_3.jpg" });
            pro.Add(new ProductImages() { DetailNo = 1, ProductImageNo = 37, ProductImageName = "basicImage37_1.PNG" });
            pro.Add(new ProductImages() { DetailNo = 2, ProductImageNo = 37, ProductImageName = "basicImage37_2.png" });
            pro.Add(new ProductImages() { DetailNo = 3, ProductImageNo = 37, ProductImageName = "basicImage37_3.png" });
            pro.Add(new ProductImages() { DetailNo = 1, ProductImageNo = 38, ProductImageName = "basicImage38_1.png" });
            pro.Add(new ProductImages() { DetailNo = 2, ProductImageNo = 38, ProductImageName = "basicImage38_2.png" });
            pro.Add(new ProductImages() { DetailNo = 3, ProductImageNo = 38, ProductImageName = "basicImage38_3.png" });
            pro.Add(new ProductImages() { DetailNo = 1, ProductImageNo = 39, ProductImageName = "basicImage39_1.png" });
            pro.Add(new ProductImages() { DetailNo = 2, ProductImageNo = 39, ProductImageName = "basicImage39_2.png" });
            pro.Add(new ProductImages() { DetailNo = 3, ProductImageNo = 39, ProductImageName = "basicImage39_3.png" });
            pro.Add(new ProductImages() { DetailNo = 1, ProductImageNo = 40, ProductImageName = "basicImage40_1.png" });
            pro.Add(new ProductImages() { DetailNo = 2, ProductImageNo = 40, ProductImageName = "basicImage40_2.png" });
            pro.Add(new ProductImages() { DetailNo = 3, ProductImageNo = 40, ProductImageName = "basicImage40_3.png" });
            pro.Add(new ProductImages() { DetailNo = 1, ProductImageNo = 41, ProductImageName = "basicImage41_1.png" });
            pro.Add(new ProductImages() { DetailNo = 2, ProductImageNo = 41, ProductImageName = "basicImage41_2.png" });
            pro.Add(new ProductImages() { DetailNo = 3, ProductImageNo = 41, ProductImageName = "basicImage41_3.png" });
            context.ProductImages.AddRange(pro);
            context.SaveChanges();
         }
      }
   }
}
