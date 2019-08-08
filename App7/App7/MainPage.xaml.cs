using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App7
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var dt = new DataTable();
            dt.Columns.Add("ItemName", typeof(string));
            dt.Columns.Add("Cost", typeof(int));
            dt.Columns.Add("Category", typeof(string));

            var row = dt.NewRow();
            row["ItemName"] = "레드불";
            row["Cost"] = 1000;
            row["Category"] = "음료수";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["ItemName"] = "핫식스";
            row["Cost"] = 2000;
            row["Category"] = "음료수";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["ItemName"] = "월드콘";
            row["Cost"] = 3000;
            row["Category"] = "아이스크림";
            dt.Rows.Add(row);

            ListView_ShopItems.ItemsSource = dt.Select();

            //ListView_ShopItems.ItemsSource = new List<ShopItem>()
            //{
            //    new ShopItem(){ ItemName="핫식스", Cost=1000, Category="음료수"},
            //    new ShopItem(){ ItemName="레드불", Cost=1000, Category="음료수"},
            //    new ShopItem(){ ItemName="몬스터", Cost=3000, Category="음료수"},
            //    new ShopItem(){ ItemName="조스바", Cost=1200, Category="아이스크림"},
            //    new ShopItem(){ ItemName="메로나", Cost=1500, Category="아이스크림"},
            //    new ShopItem(){ ItemName="월드콘", Cost=2000, Category="아이스크림"},
            //    new ShopItem(){ ItemName="환타", Cost=500, Category="음료수"}
            //};
        }
    }
}
