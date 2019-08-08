using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopProject.DataContext;
using ShopProject.Models;

/**
 * 
 * UserController
 * 
 * @Json(Select-Dropdown) & @Json(Login-Modal) & ●sha256Hash
 * 
 * by beomcheol
 * 
 * 2018.09.05 Edit
 * 
 **/

namespace ShopProject.Controllers
{
    [Route("ShopU")]
    public class UserController : Controller
    {
        /*******************************************************************************************
        ********************************************************************************************

        ●●●●●●●●●●●●●●●●●●●● View ●●●●●●●●●●●●●●●●●●●●

        ********************************************************************************************
        *******************************************************************************************/
        //●UserModify
        [Route("UserModify")]
        public IActionResult UserModify()
        {
            //sessionを利用してUser情報を持ってくる
            var userNo = HttpContext.Session.GetInt32("Session_UserNo");
            if (userNo == null)
            {
                return RedirectToAction("Index", "Home");
            }
            using (var db = new ShopDbContext())
            {
                var model = db.User.SingleOrDefault(m => m.UserNo.Equals(userNo));
                return View(model);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("UserModify")]
        public IActionResult UserModify(User model)
        {
            //全部入力したら
            if (ModelState.IsValid)
            {
                using (var db = new ShopDbContext())
                {
                    // 入力したpasswordをhash値(MD5)に変更 
                    //using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                    //{
                    //    UTF8Encoding utf8 = new UTF8Encoding();
                    //    byte[] data = md5.ComputeHash(utf8.GetBytes(model.UserPassword1));
                    //    string hashpassword = Convert.ToBase64String(data);
                    //    model.UserPassword1 = hashpassword;
                    //    model.UserPassword2 = hashpassword;
                    //}
                    // 入力したpasswordをhash値(SHA256)に変更 
                    using (var sha256Hash = SHA256.Create())
                    {
                        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(model.UserPassword1));
                        StringBuilder builder = new StringBuilder();
                        for (int i = 0; i < bytes.Length; i++)
                        {
                            builder.Append(bytes[i].ToString("x2"));
                        }
                        string hashpassword = builder.ToString();
                        model.UserPassword1 = hashpassword;
                        model.UserPassword2 = hashpassword;
                    }
                    model.UserUpd = DateTime.Now;
                    db.User.Update(model);
                    return Redirect("UserMypage");
                }
            }
            //全部入力しなかったら
            return View(model);
        }



        //●UserMypage
        [Route("UserMypage")]
        public IActionResult UserMypage()
        {
            //loginしていないとUserMypageに入れない
            if (HttpContext.Session.GetInt32("Session_UserNo") == null)
            {
                return RedirectToAction("Index", "Home");
            }
            int id = (int)HttpContext.Session.GetInt32("Session_UserNo");
            using (var db = new ShopDbContext())
            {
                //User情報
                var model = db.User.SingleOrDefault(u => u.UserNo.Equals(id));
                //2重 注文履歴 Table
                var simpleOrderHistory = db.Order
                    .Where(u => u.OrderUserNo.Equals(id)).OrderByDescending(u => u.OrderInp).ToList();
                ViewBag.simpleOrderHistory = simpleOrderHistory;
                var simpleDetailHistory = db.OrderDetail
                   .Include(o => o.Order)
                   .Include(u => u.Order.User)
                   .Include(p => p.Product)
                   .OrderBy(o => o.OrderDetailProductNo)
                   .ToList();
                ViewBag.simpleDetailHistory = simpleDetailHistory;
                ViewBag.ScrollIndicator = "true";
                return View(model);
            }
        }



        //●UserRegister
        [Route("UserRegister")]
        public IActionResult UserRegister()
        {
            if (HttpContext.Session.GetInt32("Session_UserNo") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            using (var db = new ShopDbContext())
            {
                var country = db.Country.ToList();
                ViewBag.countryList = country;
            }
            return View();
        }
        //＠getstatebyid -> Route("getstatebyid")] 必要!!
        [Route("getstatebyid")]
        public IActionResult getstatebyid(int id)
        {
            using (var db = new ShopDbContext())
            {
                List<State> list = new List<State>();
                list = db.State.Where(k => k.CountryId == id).ToList();
                list.Insert(0, new State { StateId = 0, Statename = " -- Select -- " });
                return Json(new SelectList(list, "StateId", "Statename"));
            }
        }
        //＠getstatebyid2 -> Route("getstatebyid2")] 必要!!
        [Route("getstatebyid2")]
        public IActionResult getstatebyid2(int id)
        {
            using (var db = new ShopDbContext())
            {
                List<City> list = new List<City>();
                list = db.City.Where(k => k.StateId == id).ToList();
                list.Insert(0, new City { CityId = 0, Cityname = " -- Select -- " });
                return Json(new SelectList(list, "CityId", "Cityname"));
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("UserRegister")]
        public IActionResult UserRegister(User model)
        {
            //全部入力したら
            if (ModelState.IsValid)
            {
                using (var db = new ShopDbContext())
                {
                    //ID 重複 Check
                    var checkUser = db.User.SingleOrDefault(u => u.UserId.Equals(model.UserId));
                    if (checkUser != null)
                    {
                        ModelState.AddModelError(string.Empty, "すでに存在するIDです");
                        return View(model);
                    }
                    // sha256Hash hashing password 
                    using (var sha256Hash = SHA256.Create())
                    {
                        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(model.UserPassword1));
                        StringBuilder builder = new StringBuilder();
                        for (int i = 0; i < bytes.Length; i++)
                        {
                            builder.Append(bytes[i].ToString("x2"));
                        }
                        string hashpassword = builder.ToString();
                        model.UserPassword1 = hashpassword;
                        model.UserPassword2 = hashpassword;
                    }
                    model.UserDel = "1";
                    model.UserAuthority = "2";
                    model.UserUpd = DateTime.Now;
                    model.UserInp = DateTime.Now;
                    db.User.Add(model);
                    db.SaveChanges();
                    //Save Session
                    HttpContext.Session.SetInt32("Session_UserNo", model.UserNo);
                    HttpContext.Session.SetString("Session_UserId", model.UserId);
                    HttpContext.Session.SetString("Session_UserAuthority", model.UserAuthority);
                    return RedirectToAction("Index", "Home");
                }
            }
            using (var db = new ShopDbContext())
            {
                var country = db.Country.ToList();
                ViewBag.countryList = country;
            }
            //全部入力しなかったら
            return View(model);
        }




        /*******************************************************************************************
        ********************************************************************************************

        ○○○○○○○○○○○○○○○○○○○○ No View ○○○○○○○○○○○○○○○○○○○○

        ********************************************************************************************
        *******************************************************************************************/
        //○UserDelete
        [HttpPost]
        [Route("UserDelete")]
        public IActionResult UserDelete()
        {
            //sessionを利用して情報を持ってくる
            var userNo = HttpContext.Session.GetInt32("Session_UserNo");
            using (var db = new ShopDbContext())
            {
                var model = db.User.SingleOrDefault(m => m.UserNo.Equals(userNo));
                model.UserDel = "0";
                model.UserUpd = DateTime.Now;
                db.User.Update(model);
                db.SaveChanges();
                //remove session
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "Home");
            }
        }



        //○UserLogout
        [Route("UserLogout")]
        public IActionResult UserLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }



        //＠UserLoginModal
        [HttpPost]
        [Route("UserLoginModal")]
        public JsonResult UserLoginModal(string id, string password)
        {
            int result = 4;
            if (id != null && password != null)
            {
                using (var db = new ShopDbContext())
                {
                    using (var sha256Hash = SHA256.Create())
                    {
                        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                        StringBuilder builder = new StringBuilder();
                        for (int i = 0; i < bytes.Length; i++)
                        {
                            builder.Append(bytes[i].ToString("x2"));
                        }
                        string hashpassword = builder.ToString();
                        password = hashpassword;
                    }
                    //Login情報をdbで検索
                    var checkUser = db.User.SingleOrDefault(u => u.UserId.Equals(id) && u.UserPassword1.Equals(password) && u.UserDel.Equals("1"));
                    //Login情報があったら
                    if (checkUser != null)
                    {
                        HttpContext.Session.SetInt32("Session_UserNo", checkUser.UserNo);
                        HttpContext.Session.SetString("Session_UserId", checkUser.UserId);
                        HttpContext.Session.SetString("Session_UserAuthority", checkUser.UserAuthority);
                        //adminである場合 -> adminPageに
                        if (checkUser.UserAuthority.Equals("1"))
                        {
                            result = 1;
                            return Json(result);
                        }
                        //adminでないと -> LoginPageに来る前のPageに移動
                        result = 2;
                        return Json(result);
                    }
                    //Login直前のページを覚え続ける
                    result = 3;
                    return Json(result);
                }
            }
            return Json(result);
        }
    }
}
