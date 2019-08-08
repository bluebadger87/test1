using ShopProject.DataContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ShopProject.Models
{
    public class Product
    {
        [Key]
        public int ProductNo { get; set; }
        [DisplayName("Category")]
        public int ProductCategory { get; set; }
        [Required]
        [DisplayName("Name")]
        public string ProductName { get; set; }
        [Required]
        [DisplayName("Price")]
        public int ProductPrice { get; set; }
        [Required]
        [DisplayName("Stock")]
        public int ProductStock { get; set; }
        [DisplayName("Remarks")]
        public string ProductRemark { get; set; }
        [DisplayName("Delete")]
        public string ProductDel { get; set; }
        [DisplayName("Image")]
        public int ProductImage { get; set; }
        public string ProductMainImage { get; set; }
        [DisplayName("DataInputDate")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ProductInp { get; set; }
        [DisplayName("DataUpdateDate")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ProductUpd { get; set; }
        [ForeignKey("ProductCategory")]
        public ProductCategoryList ProductCategoryList { get; set; }
        [ForeignKey("ProductImage")]
        public ProductImages ProductImages { get; set; }

        public static void Initialize(ShopDbContext context)
        {
            var t = context.Set<Product>();
            if (t.Any() == false)
            {
                var pro = new List<Product>();
                pro.Add(new Product() { ProductDel = "1", ProductImage = 1, ProductCategory = 1, ProductMainImage = "basicImage1_1.png", ProductName = "bend", ProductPrice = 1000, ProductStock = 5, ProductInp = DateTime.Now });
                pro.Add(new Product() { ProductDel = "1", ProductImage = 2, ProductCategory = 2, ProductMainImage = "basicImage2_1.png", ProductName = "cacao", ProductPrice = 2000, ProductStock = 5, ProductInp = DateTime.Now });
                pro.Add(new Product() { ProductDel = "1", ProductImage = 3, ProductCategory = 3, ProductMainImage = "basicImage3_1.png", ProductName = "korea", ProductPrice = 1200, ProductStock = 5, ProductInp = DateTime.Now });
                pro.Add(new Product() { ProductDel = "1", ProductImage = 4, ProductCategory = 7, ProductMainImage = "basicImage4_1.png", ProductName = "japan", ProductPrice = 1400, ProductStock = 5, ProductInp = DateTime.Now });
                pro.Add(new Product() { ProductDel = "1", ProductImage = 5, ProductCategory = 6, ProductMainImage = "basicImage5_1.png", ProductName = "water", ProductPrice = 1030, ProductStock = 5, ProductInp = DateTime.Now });
                pro.Add(new Product() { ProductDel = "1", ProductImage = 6, ProductCategory = 5, ProductMainImage = "basicImage6_1.png", ProductName = "smart", ProductPrice = 110, ProductStock = 5, ProductInp = DateTime.Now });
                pro.Add(new Product() { ProductDel = "1", ProductImage = 7, ProductCategory = 4, ProductMainImage = "basicImage7_1.png", ProductName = "mouse", ProductPrice = 150, ProductStock = 5, ProductInp = DateTime.Now });
                pro.Add(new Product() { ProductDel = "1", ProductImage = 8, ProductCategory = 3, ProductMainImage = "basicImage8_1.png", ProductName = "notebook", ProductPrice = 10200, ProductStock = 5, ProductInp = DateTime.Now });
                pro.Add(new Product() { ProductDel = "1", ProductImage = 9, ProductCategory = 2, ProductMainImage = "basicImage9_1.png", ProductName = "desktop", ProductPrice = 10230, ProductStock = 5, ProductInp = DateTime.Now });
                pro.Add(new Product() { ProductDel = "1", ProductImage = 10, ProductCategory = 1, ProductMainImage = "basicImage10_1.png", ProductName = "pen", ProductPrice = 13000, ProductStock = 5, ProductInp = DateTime.Now });
                pro.Add(new Product() { ProductDel = "1", ProductImage = 11, ProductCategory = 2, ProductMainImage = "basicImage11_1.png", ProductName = "a4", ProductPrice = 1040, ProductStock = 5, ProductInp = DateTime.Now });
                pro.Add(new Product() { ProductDel = "1", ProductImage = 12, ProductCategory = 3, ProductMainImage = "basicImage12_1.png", ProductName = "water", ProductPrice = 2200, ProductStock = 5, ProductInp = DateTime.Now });
                pro.Add(new Product() { ProductDel = "1", ProductImage = 13, ProductCategory = 4, ProductMainImage = "basicImage13_1.png", ProductName = "kusuri", ProductPrice = 1988, ProductStock = 5, ProductInp = DateTime.Now });
                pro.Add(new Product() { ProductDel = "1", ProductImage = 14, ProductCategory = 5, ProductMainImage = "basicImage14_1.jpg", ProductName = "medicine", ProductPrice = 1000, ProductStock = 5, ProductInp = DateTime.Now });
                pro.Add(new Product() { ProductDel = "1", ProductImage = 15, ProductCategory = 6, ProductMainImage = "basicImage15_1.jpg", ProductName = "glass", ProductPrice = 10406, ProductStock = 5, ProductInp = DateTime.Now });
                pro.Add(new Product() { ProductDel = "1", ProductImage = 16, ProductCategory = 7, ProductMainImage = "basicImage16_1.PNG", ProductName = "mouse2", ProductPrice = 1090, ProductStock = 5, ProductInp = DateTime.Now });
                pro.Add(new Product() { ProductDel = "1", ProductImage = 17, ProductCategory = 1, ProductMainImage = "basicImage17_1.png", ProductName = "paper", ProductPrice = 899, ProductStock = 5, ProductInp = DateTime.Now });
                pro.Add(new Product() { ProductDel = "1", ProductImage = 18, ProductCategory = 2, ProductMainImage = "basicImage18_1.png", ProductName = "shirt", ProductPrice = 1800, ProductStock = 5, ProductInp = DateTime.Now });
                pro.Add(new Product() { ProductDel = "1", ProductImage = 19, ProductCategory = 3, ProductMainImage = "basicImage19_1.png", ProductName = "watch", ProductPrice = 100000, ProductStock = 5, ProductInp = DateTime.Now });
                pro.Add(new Product() { ProductDel = "1", ProductImage = 20, ProductCategory = 4, ProductMainImage = "basicImage20_1.png", ProductName = "reading", ProductPrice = 1300, ProductStock = 5, ProductInp = DateTime.Now });
                pro.Add(new Product() { ProductDel = "1", ProductImage = 21, ProductCategory = 5, ProductMainImage = "basicImage21_1.png", ProductName = "monitor", ProductPrice = 1800, ProductStock = 5, ProductInp = DateTime.Now });
                pro.Add(new Product() { ProductDel = "1", ProductImage = 22, ProductCategory = 1, ProductMainImage = "basicImage22_1.png", ProductName = "bend", ProductPrice = 1000, ProductStock = 5, ProductInp = DateTime.Now });
                pro.Add(new Product() { ProductDel = "1", ProductImage = 23, ProductCategory = 2, ProductMainImage = "basicImage23_1.png", ProductName = "cacao", ProductPrice = 2000, ProductStock = 5, ProductInp = DateTime.Now });
                pro.Add(new Product() { ProductDel = "1", ProductImage = 24, ProductCategory = 3, ProductMainImage = "basicImage24_1.png", ProductName = "korea", ProductPrice = 1200, ProductStock = 5, ProductInp = DateTime.Now });
                pro.Add(new Product() { ProductDel = "1", ProductImage = 25, ProductCategory = 7, ProductMainImage = "basicImage25_1.png", ProductName = "japan", ProductPrice = 1400, ProductStock = 5, ProductInp = DateTime.Now });
                pro.Add(new Product() { ProductDel = "1", ProductImage = 26, ProductCategory = 6, ProductMainImage = "basicImage26_1.png", ProductName = "water", ProductPrice = 1030, ProductStock = 5, ProductInp = DateTime.Now });
                pro.Add(new Product() { ProductDel = "1", ProductImage = 27, ProductCategory = 5, ProductMainImage = "basicImage27_1.png", ProductName = "smart", ProductPrice = 110, ProductStock = 5, ProductInp = DateTime.Now });
                pro.Add(new Product() { ProductDel = "1", ProductImage = 28, ProductCategory = 4, ProductMainImage = "basicImage28_1.png", ProductName = "mouse", ProductPrice = 150, ProductStock = 5, ProductInp = DateTime.Now });
                pro.Add(new Product() { ProductDel = "1", ProductImage = 29, ProductCategory = 3, ProductMainImage = "basicImage29_1.png", ProductName = "notebook", ProductPrice = 10200, ProductStock = 5, ProductInp = DateTime.Now });
                pro.Add(new Product() { ProductDel = "1", ProductImage = 30, ProductCategory = 2, ProductMainImage = "basicImage30_1.png", ProductName = "desktop", ProductPrice = 10230, ProductStock = 5, ProductInp = DateTime.Now });
                pro.Add(new Product() { ProductDel = "1", ProductImage = 31, ProductCategory = 1, ProductMainImage = "basicImage31_1.png", ProductName = "pen", ProductPrice = 13000, ProductStock = 5, ProductInp = DateTime.Now });
                pro.Add(new Product() { ProductDel = "1", ProductImage = 32, ProductCategory = 2, ProductMainImage = "basicImage32_1.png", ProductName = "a4", ProductPrice = 1040, ProductStock = 5, ProductInp = DateTime.Now });
                pro.Add(new Product() { ProductDel = "1", ProductImage = 33, ProductCategory = 3, ProductMainImage = "basicImage33_1.png", ProductName = "water", ProductPrice = 2200, ProductStock = 5, ProductInp = DateTime.Now });
                pro.Add(new Product() { ProductDel = "1", ProductImage = 34, ProductCategory = 4, ProductMainImage = "basicImage34_1.png", ProductName = "kusuri", ProductPrice = 1988, ProductStock = 5, ProductInp = DateTime.Now });
                pro.Add(new Product() { ProductDel = "1", ProductImage = 35, ProductCategory = 5, ProductMainImage = "basicImage35_1.jpg", ProductName = "medicine", ProductPrice = 1000, ProductStock = 5, ProductInp = DateTime.Now });
                pro.Add(new Product() { ProductDel = "1", ProductImage = 36, ProductCategory = 6, ProductMainImage = "basicImage36_1.jpg", ProductName = "glass", ProductPrice = 10406, ProductStock = 5, ProductInp = DateTime.Now });
                pro.Add(new Product() { ProductDel = "1", ProductImage = 37, ProductCategory = 7, ProductMainImage = "basicImage37_1.PNG", ProductName = "mouse2", ProductPrice = 1090, ProductStock = 5, ProductInp = DateTime.Now });
                pro.Add(new Product() { ProductDel = "1", ProductImage = 38, ProductCategory = 1, ProductMainImage = "basicImage38_1.png", ProductName = "paper", ProductPrice = 899, ProductStock = 5, ProductInp = DateTime.Now });
                pro.Add(new Product() { ProductDel = "1", ProductImage = 39, ProductCategory = 2, ProductMainImage = "basicImage39_1.png", ProductName = "shirt", ProductPrice = 1800, ProductStock = 5, ProductInp = DateTime.Now });
                pro.Add(new Product() { ProductDel = "1", ProductImage = 40, ProductCategory = 3, ProductMainImage = "basicImage40_1.png", ProductName = "watch", ProductPrice = 100000, ProductStock = 5, ProductInp = DateTime.Now });
                pro.Add(new Product() { ProductDel = "1", ProductImage = 41, ProductCategory = 4, ProductMainImage = "basicImage41_1.png", ProductName = "reading", ProductPrice = 1300, ProductStock = 5, ProductInp = DateTime.Now });
                context.AddRange(pro);
                context.SaveChanges();
            }
        }
    }
}
