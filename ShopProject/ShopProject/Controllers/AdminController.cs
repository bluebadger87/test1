using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopProject.DataContext;
using ShopProject.Models;

/**
 * 
 * AdminController
 * 
 * ●Photo & ○Mail & @Json(ProductList-Del)
 * 
 * by beomcheol
 * 
 * 2018.09.05 Edit
 * 
 **/

namespace ShopProject.Controllers
{
   [Route("Shop")]
   public class AdminController : Controller
   {
      //Photo A
      private readonly IHostingEnvironment _environment;
      public AdminController(IHostingEnvironment environment)
      {
         _environment = environment;
      }
      //Photo Z

      /*******************************************************************************************
      ********************************************************************************************

      ●●●●●●●●●●●●●●●●●●●● View ●●●●●●●●●●●●●●●●●●●●

      ********************************************************************************************
      *******************************************************************************************/
      //●OrdertList
      [Route("ShopOrderList")]
      public IActionResult OrderList(int? Id, string OrderDelivery, string funnel, double scroll)
      {
         //adminでなければerrorページに
         if (HttpContext.Session.GetString("Session_UserAuthority") != "1")
         {
            return RedirectToAction("Index", "Home");
         }
         //Database 接続
         using (var db = new ShopDbContext())
         {
            // SelectでOrderDelivery情報を変更したら
            if (Id != null && OrderDelivery != null)
            {
               var order = db.Order.Where(o => o.OrderNo == Id).SingleOrDefault();
               order.OrderDelivery = OrderDelivery;
               db.Order.Update(order);
               db.SaveChanges();
            }
            // First -> orderSimpleListを呼ぶ
            var orderSimpleList = db.Order
            .Include(u => u.User)
            .OrderByDescending(s => s.OrderNo).ToList();
            // IF funnel条件があったら
            if (funnel != null)
            {
               orderSimpleList = orderSimpleList.Where(s => s.OrderDelivery.Equals(funnel)).ToList();
            }
            ViewBag.orderSimpleList = orderSimpleList;
            // Second -> orderSimpleListを呼ぶ
            var orderDetailList = db
                .OrderDetail
                .Include(p => p.Product)
                .OrderBy(d => d.OrderDetailProductNo).ToList();
            ViewBag.orderDetailList = orderDetailList;
            // 一番上 三つのBOX(card) OrderDelivery数を表す
            ViewBag.orderstatus1 = db.Order.Where(o => o.OrderDelivery.Equals("1")).Count();
            ViewBag.orderstatus2 = db.Order.Where(o => o.OrderDelivery.Equals("2")).Count();
            ViewBag.orderstatus3 = db.Order.Where(o => o.OrderDelivery.Equals("3")).Count();
            ViewBag.funnel = funnel;
            ViewBag.scroll = scroll;
            ViewBag.ScrollIndicator = "true";
            return View();
         }
      }



      //●ProductDetail
      [Route("ShopProductDetail")]
      public IActionResult ProductDetail(int? id, string searchString, string funnelDel)
      {
         //adminでなければerrorページに
         if (HttpContext.Session.GetString("Session_UserAuthority") != "1")
         {
            return RedirectToAction("Index", "Home");
         }
         //Database 接続
         using (var db = new ShopDbContext())
         {
            //Productデータを読む
            var model = db.Product
                .Include(p => p.ProductCategoryList)
                .SingleOrDefault(n => n.ProductNo.Equals(id));
            //ProductImagesデータを読む
            var images = db.ProductImages.Where(o => o.ProductImageNo.Equals(model.ProductImage)).OrderBy(o => o.DetailNo).ToList();
            ViewBag.image = images;
            //在庫の残量を求める
            var orderCount = db.OrderDetail.Where(k => k.OrderDetailProductNo.Equals(id)).Sum(c => c.OrderDetailQuantity);
            ViewBag.currentStock = model.ProductStock - orderCount;
            //Productに関する注文履歴を呼ぶ
            var purchaseHistory = db.OrderDetail
                .Include(o => o.Order)
                .Include(u => u.Order.User)
                .Include(p => p.Product)
                .Where(k => k.OrderDetailProductNo.Equals(id))
                .OrderByDescending(s => s.OrderDetailNo).ToList();
            ViewBag.purchaseHistory = purchaseHistory;
            ViewBag.searchString = searchString;
            ViewBag.funnelDel = funnelDel;
            ViewBag.ScrollIndicator = "true";
            return View(model);
         }
      }



      //●ProductList
      [Route("ShopProductList")]
      [HttpGet]
      public IActionResult ProductList(string searchString, string funnelDel)
      {
         //adminでなければerrorページに
         if (HttpContext.Session.GetString("Session_UserAuthority") != "1")
         {
            return RedirectToAction("Index", "Home");
         }
         //Database 接続
         using (var db = new ShopDbContext())
         {
            //ProductListを呼ぶ
            var model = db.Product.Include(L => L.ProductCategoryList).ToList();
            if (string.IsNullOrEmpty(searchString))
               searchString = "";
            if (string.IsNullOrEmpty(funnelDel))
               funnelDel = "";
            model = db.Product.Include(L => L.ProductCategoryList)
                    .Where(S => S.ProductName.Contains(searchString))
                    .Where(D => D.ProductDel.Contains(funnelDel))
                    .OrderByDescending(o => o.ProductNo).ToList();
            // JavaのMapperに該当 -> cart数量の時はsessionListを利用した
            var currentStock = new Dictionary<int, int>();
            foreach (var item in model)
            {
               var orderCount = db.OrderDetail.Where(o => o.OrderDetailProductNo.Equals(item.ProductNo)).Sum(o => o.OrderDetailQuantity);
               currentStock.Add(item.ProductNo, ((item.ProductStock) - (orderCount)));
            }
            ViewBag.currentStock = currentStock;
            ViewBag.searchString = searchString;
            ViewBag.funnelDel = funnelDel;
            ViewBag.ScrollIndicator = "true";
            return View(model);
         }
      }
      //＠AjaxProductDel 
      [HttpPost]
      [Route("AjaxProductDel")]
      public IActionResult AjaxProductDel(int? id)
      {
         var result = 0;
         using (var db = new ShopDbContext())
         {
            var model = db.Product.Where(o => o.ProductNo.Equals(id)).SingleOrDefault();
            if (model.ProductDel.Equals("1"))
            {
               model.ProductDel = "0";
            }
            else
            {
               model.ProductDel = "1";
               result = 1;
            }
            db.Update(model);
            db.SaveChanges();
         }
         return Json(result);
      }
      //＠AjaxCheckProductDel 
      [HttpPost]
      [Route("AjaxCheckProductDel")]
      public IActionResult AjaxCheckProductDel(List<int> check)
      {
         var checklist = new List<int>();
         using (var db = new ShopDbContext())
         {
            foreach (var item in check)
            {
               var model = db.Product.SingleOrDefault(m => m.ProductNo == item);
               model.ProductDel = "0";
               model.ProductUpd = DateTime.Now;
               db.Product.Update(model);
               db.SaveChanges();
            }
            return Ok();
         }
      }
      //＠AjaxCheckProductExist
      [HttpPost]
      [Route("AjaxCheckProductExist")]
      public IActionResult AjaxCheckProductExist(List<int> check)
      {
         var checklist = new List<int>();
         using (var db = new ShopDbContext())
         {
            foreach (var item in check)
            {
               var model = db.Product.SingleOrDefault(m => m.ProductNo == item);
               model.ProductDel = "1";
               model.ProductUpd = DateTime.Now;
               db.Product.Update(model);
               db.SaveChanges();
            }
            return Ok();
         }
      }



      //●ProductModify
      [Route("ShopProductModify")]
      public IActionResult ProductModify(int? id, string searchString, string funnelDel)
      {
         //adminでなければerrorページに
         if (HttpContext.Session.GetString("Session_UserAuthority") != "1")
         {
            return RedirectToAction("Index", "Home");
         }
         //Database 接続
         using (var db = new ShopDbContext())
         {
            //Productデータを読む
            var model = db.Product.SingleOrDefault(m => m.ProductNo.Equals(id));
            //ProductImagesデータを読む
            var images = db.ProductImages.Where(o => o.ProductImageNo.Equals(model.ProductImage)).OrderBy(o => o.DetailNo).Select(o => o.ProductImageName).Skip(1).Take(2).ToList();
            ViewBag.image = images;
            //categoryList dropdownlist 
            var categoryList = new SelectList(db.ProductCategoryList.ToList(), "Id", "Name");
            ViewData["ProductCategoryList"] = categoryList;
            ViewBag.searchString = searchString;
            ViewBag.funnelDel = funnelDel;
            return View(model);
         }
      }
      [HttpPost]
      [Route("ShopProductModify")]
      public IActionResult ProductModify(Product model, IFormFile file1, IFormFile file2, IFormFile file3, string searchString, string funnelDel, string del1, string del2, string del3)
      {
         //adminでなければerrorページに
         if (HttpContext.Session.GetString("Session_UserAuthority") != "1")
         {
            return RedirectToAction("Index", "Home");
         }
         //全部入力したら
         if (ModelState.IsValid)
         {
            using (var db = new ShopDbContext())
            {
               // image delete buttonを押したら ->
               if (del1 != null)
               {
                  var productImages = db.ProductImages.Where(o => o.ProductImageNo.Equals(model.ProductImage)).OrderBy(o => o.DetailNo).FirstOrDefault();
                  productImages.ProductImageName = "NoImage.PNG";
                  db.ProductImages.Update(productImages);
                  model.ProductMainImage = "NoImage.PNG";
               }
               if (del2 != null)
               {
                  var productImages = db.ProductImages.Where(o => o.ProductImageNo.Equals(model.ProductImage)).OrderBy(o => o.DetailNo).Skip(1).Take(1).FirstOrDefault();
                  productImages.ProductImageName = "NoImage.PNG";
                  db.ProductImages.Update(productImages);
               }
               if (del3 != null)
               {
                  var productImages = db.ProductImages.Where(o => o.ProductImageNo.Equals(model.ProductImage)).OrderBy(o => o.DetailNo).Skip(2).Take(1).FirstOrDefault();
                  productImages.ProductImageName = "NoImage.PNG";
                  db.ProductImages.Update(productImages);
               }
               //Imageを登録したら
               int fileNumber = 1;
               if (file1 != null)
               {
                  //Set file name
                  var fileNameSplit = file1.FileName.Split('.');
                  var fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + fileNameSplit[0] + "_" + fileNumber + "." + fileNameSplit[1];
                  //Set file Path
                  var filePath = Path.Combine(_environment.WebRootPath + "\\images", fileName);
                  //Input image
                  var fileStream = new FileStream(filePath, FileMode.Create);
                  file1.CopyTo(fileStream);
                  //productImages Db Set
                  var productImages = db.ProductImages.Where(o => o.ProductImageNo.Equals(model.ProductImage)).OrderBy(o => o.DetailNo).FirstOrDefault();
                  productImages.ProductImageName = fileName;
                  db.ProductImages.Update(productImages);
                  //Set productMainImage
                  model.ProductMainImage = fileName;
               }
               fileNumber++;
               if (file2 != null)
               {
                  //Set file name
                  var fileNameSplit = file2.FileName.Split('.');
                  var fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + fileNameSplit[0] + "_" + fileNumber + "." + fileNameSplit[1];
                  //Set file Path
                  var filePath = Path.Combine(_environment.WebRootPath + "\\images", fileName);
                  //Input image
                  var fileStream = new FileStream(filePath, FileMode.Create);
                  file2.CopyTo(fileStream);
                  //productImages Db Set
                  var productImages = db.ProductImages.Where(o => o.ProductImageNo.Equals(model.ProductImage)).OrderBy(o => o.DetailNo).Skip(1).Take(1).FirstOrDefault();
                  productImages.ProductImageName = fileName;
                  db.ProductImages.Update(productImages);
               }
               fileNumber++;
               if (file3 != null)
               {
                  //Set file name
                  var fileNameSplit = file3.FileName.Split('.');
                  var fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + fileNameSplit[0] + "_" + fileNumber + "." + fileNameSplit[1];
                  //Set file Path
                  var filePath = Path.Combine(_environment.WebRootPath + "\\images", fileName);
                  //Input image
                  var fileStream = new FileStream(filePath, FileMode.Create);
                  file3.CopyTo(fileStream);
                  //productImages Db Set
                  var productImages = db.ProductImages.Where(o => o.ProductImageNo.Equals(model.ProductImage)).OrderBy(o => o.DetailNo).Skip(2).Take(1).FirstOrDefault();
                  productImages.ProductImageName = fileName;
                  db.ProductImages.Update(productImages);
               }
               model.ProductUpd = DateTime.Now;
               db.Product.Update(model);
               db.SaveChanges();
               return RedirectToAction("ShopProductList", "Shop", new { searchString = searchString, funnelDel = funnelDel });
            }
         }
         //入力にerrorがあると
         using (var db = new ShopDbContext())
         {
            //Create categoryList dropdownlist 
            var categoryList = new SelectList(db.ProductCategoryList.ToList(), "Id", "Name");
            ViewData["ProductCategoryList"] = categoryList;
            ViewBag.searchString = searchString;
            ViewBag.funnelDel = funnelDel;
            return View(model);
         }
      }



      //●ProductRegister
      [Route("ShopProductRegister")]
      public IActionResult ProductRegister()
      {
         //adminでなければerrorページに
         if (HttpContext.Session.GetString("Session_UserAuthority") != "1")
         {
            return RedirectToAction("Index", "Home");
         }
         //Database 接続
         using (var db = new ShopDbContext())
         {
            //Create categoryList dropdownlist 
            var categoryList = new SelectList(db.ProductCategoryList.ToList(), "Id", "Name");
            ViewData["ProductCategoryList"] = categoryList;
         }
         var returnUrl = HttpContext.Request.Headers["Referer"];
         ViewBag.returnUrl = returnUrl;
         return View();
      }
      [HttpPost]
      [ValidateAntiForgeryToken]
      [Route("ShopProductRegister")]
      public IActionResult ProductRegister(Product model, List<IFormFile> file, string returnUrl)
      {
         //項目を全部入力したら
         if (ModelState.IsValid)
         {
            using (var db = new ShopDbContext())
            {
               int fileNumber = 0;
               //ProductImageを指定 -> これを指定しないとProductImagesに連結できない
               model.ProductImage = db.Product.OrderBy(o => o.ProductNo).ToList().Last().ProductImage + 1;
               model.ProductMainImage = "NoImage.PNG";
               model.ProductDel = "1";
               model.ProductInp = DateTime.Now;
               model.ProductUpd = DateTime.Now;
               //Imageを登録したらこっち
               if (file.Count() >= 1)
               {
                  foreach (var item in file)
                  {
                     var productImages = new ProductImages();
                     fileNumber++;
                     //Set file name
                     var fileNameSplit = item.FileName.Split('.');
                     var fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + fileNameSplit[0] + "_" + fileNumber + "." + fileNameSplit[1];
                     //Set file Path
                     var filePath = Path.Combine(_environment.WebRootPath + "\\images", fileName);
                     //Set productMainImage
                     if (fileNumber == 1)
                     {
                        model.ProductMainImage = fileName;
                     }
                     //Folderにimageを保存する
                     using (var fileStream = new FileStream(filePath, FileMode.Create))
                     {
                        item.CopyTo(fileStream);
                        //ProductImages tableにデータ入力
                        productImages.ProductImageNo = model.ProductImage;
                        productImages.ProductImageName = fileName;
                        productImages.DetailNo = fileNumber;
                        db.ProductImages.Add(productImages);
                     }
                  }
                  if (fileNumber != 3)
                  {
                     for (int j = fileNumber; j <= 3; j++)
                     {
                        var productImages = new ProductImages();
                        productImages.ProductImageNo = model.ProductImage;
                        productImages.ProductImageName = "NoImage.PNG";
                        db.ProductImages.Add(productImages);
                     }
                  }
               }
               //Imageがないと
               else
               {
                  for (int i = 0; i <= 2; i++)
                  {
                     var productImages = new ProductImages();
                     productImages.ProductImageName = "NoImage.PNG";
                     productImages.ProductImageNo = model.ProductImage;
                     db.ProductImages.Add(productImages);
                  }
               }
               //Databaseにproduct登録
               db.Product.Add(model);
               db.SaveChanges();
               return RedirectToAction("ProductDetail", "Admin", new { id = model.ProductNo });
            }
         }
         //一個でも入力しなかったら
         using (var db = new ShopDbContext())
         {
            //Create categoryList dropdownlist 
            var categoryList = new SelectList(db.ProductCategoryList.ToList(), "Id", "Name");
            ViewData["ProductCategoryList"] = categoryList;
         }
         ViewBag.returnUrl = returnUrl;
         return View(model);
      }



      //●SendMail
      [Route("SendMail")]
      public IActionResult SendMail(Mail model)
      {
         //adminでなければerrorページに
         if (HttpContext.Session.GetString("Session_UserAuthority") != "1")
         {
            return RedirectToAction("Index", "Home");
         }
         if (model.To == null || model.Subject == null || model.Content == null)
         {
            return View(model);
         }
         //SendMail
         using (MailMessage mail = new MailMessage())
         {
            //Set Mail Info
            mail.From = new MailAddress("bluebadger8787@gmail.com");
            mail.To.Add(model.To);
            mail.Subject = model.Subject;
            mail.IsBodyHtml = false;
            mail.Body = model.Content;
            //Connect gmail
            SmtpClient smtp = new SmtpClient
            {
               DeliveryMethod = SmtpDeliveryMethod.Network,
               Host = "smtp.gmail.com",
               Port = 587,
               Credentials = new NetworkCredential("bluebadger8787@gmail.com", "wjswk87!@!@"),
               EnableSsl = true
            };
            //Send Mail
            smtp.Send(mail);
            ViewBag.Message = "Success";
            return View();
         }
      }



      //●UserDetail
      [Route("UserDetail")]
      public IActionResult UserDetail(int? id)
      {
         //adminでなければerrorページに
         if (HttpContext.Session.GetString("Session_UserAuthority") != "1")
         {
            return RedirectToAction("Index", "Home");
         }
         using (var db = new ShopDbContext())
         {
            //Input Viewbag simpleOrderHistory
            var simpleOrderHistory = db.Order
                .Where(u => u.OrderUserNo.Equals(id)).ToList();
            ViewBag.simpleOrderHistory = simpleOrderHistory;
            //Input Viewbag simpleDetailHistory
            var simpleDetailHistory = db.OrderDetail
               .Include(o => o.Order)
               .Include(u => u.Order.User)
               .Include(p => p.Product)
               .OrderByDescending(p => p.OrderDetailProductNo)
               .ToList();
            ViewBag.simpleDetailHistory = simpleDetailHistory;
            //Input Model
            var model = db.User.SingleOrDefault(u => u.UserNo.Equals(id));
            ViewBag.ScrollIndicator = "true";
            return View(model);
         }
      }



      //●UserList
      [Route("ShopUserList")]
      public IActionResult UserList(string searchString, string funnelDel)
      {
         //adminでなければerrorページに
         if (HttpContext.Session.GetString("Session_UserAuthority") != "1")
         {
            return RedirectToAction("Index", "Home");
         }
         //Database 接続
         using (var db = new ShopDbContext())
         {
            //List 出力 (ProductDel = 1)
            if (string.IsNullOrEmpty(searchString))
               searchString = "";
            if (string.IsNullOrEmpty(funnelDel))
               funnelDel = "";
            var model = db.User
                .Where(S => S.UserId.Contains(searchString))
                .Where(d => d.UserDel.Contains(funnelDel))
                .OrderByDescending(u => u.UserNo).ToList();
            ViewBag.searchString = searchString;
            ViewBag.funnelDel = funnelDel;
            ViewBag.ScrollIndicator = "true";
            return View(model);
         }
      }



      //●UserModify
      [Route("ShopUserModify")]
      public IActionResult UserModify(int? id)
      {
         //adminでなければerrorページに
         if (HttpContext.Session.GetString("Session_UserAuthority") != "1")
         {
            return RedirectToAction("Index", "Home");
         }
         //Database 接続
         using (var db = new ShopDbContext())
         {
            //データを読む
            var model = db.User.SingleOrDefault(m => m.UserNo.Equals(id));
            //データがないと
            if (model == null)
            {
               return NotFound();
            }
            return View(model);
         }
      }
      [HttpPost]
      [ValidateAntiForgeryToken]
      [Route("ShopUserModify")]
      public IActionResult UserModify(User model)
      {
         if (ModelState.IsValid)
         {
            using (var db = new ShopDbContext())
            {
               db.User.Update(model);
               db.SaveChanges();
               return RedirectToAction("ShopUserList", "Shop");
            }
         }
         return View(model);
      }




      /*******************************************************************************************
      ********************************************************************************************

      ○○○○○○○○○○○○○○○○○○○○ No View ○○○○○○○○○○○○○○○○○○○○

      ********************************************************************************************
      *******************************************************************************************/
      //○ProductDelete 
      [HttpPost]
      [ValidateAntiForgeryToken]
      [Route("ShopProductDelete")]
      public IActionResult ProductDelete(int? id, string searchString, string funnelDel, string btn)
      {
         //adminでなければerrorページに
         if (HttpContext.Session.GetString("Session_UserAuthority") != "1")
         {
            return RedirectToAction("Index", "Home");
         }
         var returnUrl = HttpContext.Request.Headers["Referer"];
         using (var db = new ShopDbContext())
         {
            var model = db.Product.SingleOrDefault(m => m.ProductNo == id);
            if (btn.Equals("Delete"))
               model.ProductDel = "0";
            else
               model.ProductDel = "1";
            model.ProductUpd = DateTime.Now;
            db.Product.Update(model);
            db.SaveChanges();
            return Redirect(returnUrl);
         }
      }



      //○UserDelete 
      [HttpPost]
      [ValidateAntiForgeryToken]
      [Route("ShopUserDelete")]
      public IActionResult UserDelete(int? id)
      {
         //adminでなければerrorページに
         if (HttpContext.Session.GetString("Session_UserAuthority") != "1")
         {
            return RedirectToAction("Index", "Home");
         }
         using (var db = new ShopDbContext())
         {
            //Userのdel情報を持ってくる
            var model = db.User.SingleOrDefault(m => m.UserNo == id);
            if (model.UserDel.Equals("1"))
               model.UserDel = "0";
            else
               model.UserDel = "1";
            model.UserUpd = DateTime.Now;
            db.User.Update(model);
            db.SaveChanges();
            var returnUrl = HttpContext.Request.Headers["Referer"];
            return Redirect(returnUrl);
         }
      }
   }
}