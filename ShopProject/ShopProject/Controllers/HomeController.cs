using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopProject.DataContext;
using ShopProject.Models;
using ShopProject.ViewModels;

/**
 * 
 * HomeController
 * 
 * ●Paging & ●Mail & ○DB Lock
 * 
 * by beomcheol
 * 
 * 2018.09.05 Edit
 * 
 **/

namespace ShopProject.Controllers
{
   public class HomeController : Controller
   {
      // ProductOrderEnd DBLock
      private readonly Object _thisLock = new Object();

      /*******************************************************************************************
      ********************************************************************************************

      ●●●●●●●●●●●●●●●●●●●● View ●●●●●●●●●●●●●●●●●●●●

      ********************************************************************************************
      *******************************************************************************************/
      //●Index
      public IActionResult Index()
      {
         using (var db = new ShopDbContext())
         {
            //DBに初期値のデータを入れる
            ProductImages.Initialize(db);
            ProductCategoryList.Initialize(db);
            Product.Initialize(db);
            Country.Initialize(db);
            State.Initialize(db);
            City.Initialize(db);
            Models.User.Initialize(db);
            //Index画面に表す6個を呼び出す
            var model = db.Product.OrderByDescending(n => n.ProductNo).Take(6).ToList();
            return View(model);
         }
      }


      //●ProductCart
      public IActionResult ProductCart()
      {
         var cartlist = HttpContext.Session.GetObjectFromJson<List<CartSession>>("cart");
         if (cartlist == null)
         {
            return View();
         }
         using (var db = new ShopDbContext())
         {
            //CartSessionをViewBagに渡す (数量を表すため)
            ViewBag.MapCartSession = HttpContext.Session.GetObjectFromJson<List<CartSession>>("cart");
            //CartSessionにある商品のdetail情報を持ってくる 
            var model = new List<Product>();
            var currentStock = new List<int>();
            foreach (var cart in cartlist)
            {
               //cart 商品の情報
               model.Add(db.Product.Where(s => s.ProductNo.Equals(cart.ProductId))
                        .Include(L => L.ProductCategoryList)
                        .SingleOrDefault());
               //cart 商品の注文できる数量
               int wholeStock = db.Product.Where(o => o.ProductNo.Equals(cart.ProductId)).Select(o => o.ProductStock).Single();
               var orderCount = db.OrderDetail.Where(o => o.OrderDetailProductNo.Equals(cart.ProductId)).Sum(o => o.OrderDetailQuantity);
               currentStock.Add(wholeStock - orderCount);
            }
            //数量の Select Dropdown
            ViewBag.currentStock = currentStock;
            ViewBag.sessionUserNo = HttpContext.Session.GetInt32("Session_UserNo");
            return View(model);
         }
      }



      //●ProductDetail
      public IActionResult ProductDetail(int? id, int page, string search, string sort, double scroll)
      {
         using (var db = new ShopDbContext())
         {
            //Productデータを読む
            var model = db.Product.Include(L => L.ProductCategoryList).
                        SingleOrDefault(m => m.ProductNo.Equals(id));
            //3個のProductImagesを読む
            var images = db.ProductImages.Where(o => o.ProductImageNo.Equals(model.ProductImage)).OrderBy(o => o.DetailNo).ToList();
            ViewBag.image = images;
            //注文された量を求めてViewBagで残っている在庫を渡す
            var orderCount = db.OrderDetail.Where(k => k.OrderDetailProductNo.Equals(id)).Sum(c => c.OrderDetailQuantity);
            ViewBag.CurrentStock = model.ProductStock - orderCount;
            //全てのComment & Score ViewBagに渡す  *DefaultIfEmpty()!!!*
            var comment = db.ProductComment.Include(o => o.User).Where(o => o.CommentProductNo.Equals(id) && o.CommentDel.Equals("1")).ToList();
            var score = db.ProductComment.Where(o => o.CommentProductNo.Equals(id) && o.CommentDel.Equals("1")).DefaultIfEmpty().Average(o => o.CommnetScore);
            ViewBag.comment = comment;
            ViewBag.socre = Math.Round(score, 1);
            //Reviewが書けるかどうかを確認
            var orderConf = db.OrderDetail.Include(o => o.Order).Include(o => o.Product).Include(o => o.Order.User)
                .Where(o => o.OrderDetailProductNo.Equals(id) && o.Order.OrderUserNo.Equals(HttpContext.Session.GetInt32("Session_UserNo"))).ToList();
            var commentConf = db.ProductComment.Include(o => o.User)
                .Where(o => o.CommentProductNo.Equals(id) && o.CommentUserNo.Equals(HttpContext.Session.GetInt32("Session_UserNo")) && o.CommentDel.Equals("1")).ToList();
            ViewBag.orderConf = orderConf;
            ViewBag.commentConf = commentConf;
            //検索条件を維持する
            ViewBag.page = page;
            ViewBag.search = search;
            ViewBag.sort = sort;
            ViewBag.ScrollIndicator = "true";
            ViewBag.scroll = scroll;
            return View(model);
         }
      }


      //●ProductList
      public IActionResult ProductList(int? page, string search, string sort)
      {
         using (var db = new ShopDbContext())
         {
            /*
             * Paging & Pagination A
             */
            //OrderDetail List ViewBagに渡す (CartをDisabledするため)
            var ordercount = db.OrderDetail.ToList();
            ViewBag.ordercount = ordercount;
            // 画面に表示するリスト数
            int outputcount = 6;
            // 画面に表示するbutton数  <<1,2,3,4,5>>
            int outputblock = 5;
            // page
            if (page == null || page == 0)
               page = 1;
            // search
            if (search == null)
               search = "";
            ViewData["search"] = search;
            // 初期値ProductLIst
            var model = db.Product.Where(s => s.ProductName.Contains(search)).OrderByDescending(p => p.ProductNo).Skip(outputcount * (page.Value - 1)).Take(outputcount);
            // Sort
            if (!string.IsNullOrWhiteSpace(sort))
            {
               switch (sort)
               {
                  case "ProductName_ASC":
                     model = db.Product.Where(s => s.ProductName.Contains(search)).OrderBy(p => p.ProductName).Skip(outputcount * (page.Value - 1)).Take(outputcount);
                     break;
                  case "ProductName_DESC":
                     model = db.Product.Where(s => s.ProductName.Contains(search)).OrderByDescending(p => p.ProductName).Skip(outputcount * (page.Value - 1)).Take(outputcount);
                     break;
                  case "ProductPrice_ASC":
                     model = db.Product.Where(s => s.ProductName.Contains(search)).OrderBy(p => p.ProductPrice).Skip(outputcount * (page.Value - 1)).Take(outputcount);
                     break;
                  case "ProductPrice_DESC":
                     model = db.Product.Where(s => s.ProductName.Contains(search)).OrderByDescending(p => p.ProductPrice).Skip(outputcount * (page.Value - 1)).Take(outputcount);
                     break;
                  default:
                     model = db.Product.Where(s => s.ProductName.Contains(search)).OrderByDescending(p => p.ProductUpd).Skip(outputcount * (page.Value - 1)).Take(outputcount);
                     break;
               }
            }
            ViewData["sort"] = sort;

            // currentpage
            ViewData["currentpage"] = page;
            // currentblock
            int currentblock = 1;
            if (page % outputblock == 0)
            {
               currentblock = (int)page / outputblock;
            }
            else
            {
               currentblock = (int)page / outputblock + 1;
            }
            ViewData["currentblock"] = currentblock;

            // totalpage & totalblockを求める (A)
            int totalpage = db.Product.Where(s => s.ProductName.Contains(search)).Count() / outputcount;
            int totalblock;
            if (db.Product.Where(s => s.ProductName.Contains(search)).Count() % outputcount == 0)
            {
               // (14page = 84/6)  &&  (15page = 90/6)  &&  (16page = 96/6)
               ViewData["totalpage"] = totalpage;
               if (totalpage % outputblock == 0)
               {
                  // 3block = 15page/5
                  totalblock = totalpage / outputblock;
                  ViewData["totalblock"] = totalblock;
               }
               else
               {
                  // 3block = 14page/5  &&  4block = 16page/5
                  totalblock = totalpage / outputblock + 1;
                  ViewData["totalblock"] = totalblock;
               }
            }
            else
            {
               // (15page = 89/6)  &&  (16page = 91/6)
               totalpage = totalpage + 1;
               ViewData["totalpage"] = totalpage;
               if (totalpage % outputblock == 0)
               {
                  // 3block = 15page/5
                  totalblock = totalpage / outputblock;
                  ViewData["totalblock"] = totalblock;
               }
               else
               {
                  // 3block = 14page/5  &&  4block = 16page/5
                  totalblock = totalpage / outputblock + 1;
                  ViewData["totalblock"] = totalblock;
               }
            }
            // totalpage & totalblockを求める (Z)

            // prev & next blockPage
            if (currentblock >= 1)
            {
               ViewData["prevblock"] = (currentblock - 2) * outputblock + 1;
               if (currentblock == 1)
               {
                  ViewData["prevblock"] = null;
               }
            }
            if (currentblock <= totalblock)
            {
               ViewData["nextblock"] = (currentblock) * outputblock + 1;
               if (currentblock == totalblock)
               {
                  ViewData["nextblock"] = null;
               }
            }
            /*
             * Paging & Pagination Z
             */
            return View(model.ToList());
         }
      }



      //●ProductOrderEnd
      public IActionResult ProductOrderEnd(int totalsum)
      {
         var cartlist = HttpContext.Session.GetObjectFromJson<List<CartSession>>("cart");
         if (cartlist == null)
         {
            return View();
         }
         using (var db = new ShopDbContext())
         {
            // DB lock
            lock (_thisLock)
            {
               //Orderにデータを入れる
               var order = new Order
               {
                  // var ordermail = new List<OrderDetail>();
                  OrderTotalPrice = totalsum,
                  OrderDelivery = "1",
                  OrderInp = DateTime.Now,
                  OrderUserNo = (int)HttpContext.Session.GetInt32("Session_UserNo")
               };
               db.Order.Add(order);
               db.SaveChanges(); // 重要 -> orderdetailにorderNoを入れるためにここでSave!!!
                                 //OrderDetailにデータを入れる
               foreach (var cartSession in cartlist)
               {
                  //購入できる商品の数を求める準備
                  int stock = db.Product.Where(s => s.ProductNo.Equals(cartSession.ProductId)).SingleOrDefault().ProductStock;
                  int orderedCount = db.OrderDetail.Where(s => s.OrderDetailProductNo.Equals(cartSession.ProductId)).Sum(c => c.OrderDetailQuantity);
                  int currentOrder = cartSession.ProductCount;
                  //購入できる商品の数比べる
                  if (stock - (orderedCount + currentOrder) < 0)
                  {
                     ViewBag.Message = "Not Enough Stock";
                     var removeorder = db.Order.Where(o => o.OrderNo.Equals(order.OrderNo)).First();
                     var removeorderdetail = db.OrderDetail.Where(o => o.OrderDetailOrderNo.Equals(order.OrderNo)).ToList();
                     db.Order.Remove(removeorder);
                     db.OrderDetail.RemoveRange(removeorderdetail);
                     db.SaveChanges();
                     return View();
                  }
                  var orderDetail = new OrderDetail();
                  orderDetail.OrderDetailOrderNo = order.OrderNo;
                  orderDetail.OrderDetailProductNo = cartSession.ProductId;
                  orderDetail.OrderDetailQuantity = cartSession.ProductCount;
                  orderDetail.OrderDetailInp = DateTime.Now;
                  db.OrderDetail.Add(orderDetail);
                  db.SaveChanges();
               }
               AutoSendMail(order);
            }
         }
         //Delete cart session
         HttpContext.Session.Remove("cart");
         HttpContext.Session.Remove("cartCount");
         return View();
      }




      /*******************************************************************************************
      ********************************************************************************************

      ○○○○○○○○○○○○○○○○○○○○ No View ○○○○○○○○○○○○○○○○○○○○

      ********************************************************************************************
      *******************************************************************************************/
      //○ClickCartInput
      public IActionResult ClickCartInput(int proNum, int id, int page, string search, string sort)
      {
         //臨時的にCartのproNoに値を保存
         if (proNum.Equals(0))
            proNum = 1;
         if (HttpContext.Session.GetObjectFromJson<List<CartSession>>("cart") == null)
         {
            var cart = new List<CartSession>();
            cart.Add(new CartSession() { ProductId = id, ProductCount = proNum });
            //Cart画面に現れるCartList
            HttpContext.Session.SetObjectAsJson("cart", cart);
            //Navbar Cart Count
            return RedirectToAction("ProductList", "Home", new { page = page, search = search, sort = sort });
         }
         else
         {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartSession>>("cart");
            // カートにある商品と同じものを選択したか確認
            foreach (var item in cart)
            {
               if (item.ProductId.Equals(id))
               {
                  item.ProductCount = item.ProductCount + proNum;
                  HttpContext.Session.SetObjectAsJson("cart", cart);
                  return RedirectToAction("ProductList", "Home", new { page = page, search = search, sort = sort });
               }
            }
            // カートにある商品と違うものを選択
            cart.Add(new CartSession() { ProductId = id, ProductCount = proNum });
            HttpContext.Session.SetObjectAsJson("cart", cart);
            return RedirectToAction("ProductList", "Home", new { page = page, search = search, sort = sort });
         }
      }



      //○CartChangeCount -> ProductCart画面(Select)
      public IActionResult CartChangeCount(int id, int cartCount)
      {
         List<CartSession> cart = HttpContext.Session.GetObjectFromJson<List<CartSession>>("cart");
         foreach (var item in cart)
         {
            if (item.ProductId.Equals(id))
            {
               item.ProductCount = cartCount;
            }
         }
         HttpContext.Session.SetObjectAsJson("cart", cart);
         return RedirectToAction("ProductCart", "Home");
      }



      //○ClickCartDelete
      public IActionResult ClickCartDelete(int id)
      {
         //session cartを呼び出す
         List<CartSession> cart = HttpContext.Session.GetObjectFromJson<List<CartSession>>("cart");
         //session cartの列をidを参照して消す
         cart.RemoveAll(r => r.ProductId.Equals(id));
         //sessionの用意
         HttpContext.Session.SetObjectAsJson("cart", cart);
         return RedirectToAction("ProductCart", "Home");
      }



      //○AutoSendMail
      public IActionResult AutoSendMail(Order order) // orderを持ってきた理由はOrderNoが必要だったから
      {
         using (var db = new ShopDbContext())
         {
            //SendMail
            using (MailMessage mail = new MailMessage())
            {
               var orderinfo = db.Order.Include(u => u.User).Where(o => o.OrderNo.Equals(order.OrderNo)).SingleOrDefault();
               var orderdetail = db.OrderDetail.Include(o => o.Order).Include(o => o.Product).Where(o => o.OrderDetailOrderNo.Equals(order.OrderNo)).ToList();
               int no = 0;
               string repeat = "";
               foreach (var item in orderdetail)
               {
                  no = no + 1;
                  repeat = repeat + "<tr style=" + "padding:50px 3px;border-bottom:solid;" + "><td>　" + no + "　</td><td>　" +
                      "<img src=" + "http://" + Request.Host + "/images/" + item.Product.ProductMainImage + " style=" + "height:70px; width:70px" + ">" + "　</td>" +
                      "<td>　" + item.Product.ProductName + "　</td><td>　" + item.Product.ProductPrice + "円　</td>" +
                      "<td>　" + item.OrderDetailQuantity + "個　</td><td>　" + item.Product.ProductPrice * item.OrderDetailQuantity + "円　</td></tr>";
               }
               string text = "<h3><p>" + orderinfo.User.UserName + "様</p>" +
                              "<p>" + DateTime.Now + "注文が完了しました。</p>" +
                              "<p> ご注文ありがとうございます。</p></h3><br/>" +
                              "<table style=" + "text-align:center;font-size:15px;" + ">" +
                              "<tr style=" + "background-color:gainsboro;border-bottom:solid;" + ">" +
                              "<th>　no　</th><th>　写真　</th><th>　商品名　</th><th>　価格　</th><th>　個　</th><th>　合計　</th></tr>" +
                              repeat +
                              "<tr><td colspan=" + "3" + "></td><td></td><td>TotalPrice</td><td>" + orderinfo.OrderTotalPrice + "円</td></tr>" +
                              "</table><br/>";

               //Set Mail Info
               mail.From = new MailAddress("bluebadger8787@gmail.com");
               mail.To.Add(orderinfo.User.UserMail);
               //mail.To.Add(user.UserMail);
               mail.Subject = "注文が成功しました。ありがとうございます。";
               mail.IsBodyHtml = true;
               mail.Body = text;
               //Connect gmail
               SmtpClient smtp = new SmtpClient();
               smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
               smtp.Host = "smtp.gmail.com";
               smtp.Port = 587;
               smtp.Credentials = new NetworkCredential("bluebadger8787@gmail.com", "wjswk87!@!@");
               smtp.EnableSsl = true;
               //Send Mail
               smtp.Send(mail);
               ModelState.Clear();
               return View();
            }
         }
      }



      //○ProductCommentRegister
      public IActionResult ProductCommentRegister(int productId, double score, string comment, double scroll)
      {
         using (var db = new ShopDbContext())
         {
            var item = new ProductComment();
            item.CommentInpDate = DateTime.Now;
            item.CommentUpdDate = DateTime.Now;
            item.CommentUserNo = (int)HttpContext.Session.GetInt32("Session_UserNo");
            item.CommentProductNo = productId;
            item.CommnetContent = comment;
            item.CommnetScore = score;
            item.CommentDel = "1";
            db.ProductComment.Add(item);
            db.SaveChanges();
         }
         ViewBag.scroll = scroll;
         return RedirectToAction("ProductDetail", new { id = productId, scroll = scroll });
      }



      //○ProductCommentEdit
      public IActionResult ProductCommentEdit(int id, string comment, int score, int proId, string btn, double scroll)
      {
         using (var db = new ShopDbContext())
         {
            var aa = db.ProductComment.SingleOrDefault(o => o.CommentId.Equals(id));
            if (btn.Equals("modi"))
            {
               aa.CommnetContent = comment;
               aa.CommnetScore = score;
               aa.CommentUpdDate = DateTime.Now;
            }
            else
            {
               aa.CommentDel = "0";
               aa.CommentUpdDate = DateTime.Now;
            }
            db.ProductComment.Update(aa);
            db.SaveChanges();
            ViewBag.scroll = scroll;
         }
         return RedirectToAction("ProductDetail", "Home", new { id = proId, scroll = scroll });
      }



      //○Error
      public IActionResult Error()
      {
         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
      }
   }
}
