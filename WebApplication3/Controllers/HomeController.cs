using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oracle.ManagedDataAccess.Client;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
public ActionResult Index()
{
    string conString = "User Id=Shop;Password=1234;Data Source=localhost:1521/XE;";
    var list = new List<MEMBERTBL>();
    using (OracleConnection conn = new OracleConnection(conString))
    {
        using (OracleCommand cmd = conn.CreateCommand())
        {
            conn.Open();
            // sql문
            cmd.CommandText = "SELECT * FROM MEMBERTBL WHERE MEMBERID=:id AND MEMBERNAME=:name";

            // parameter설정
            cmd.Parameters.Add(new OracleParameter("id", "sa"));
            cmd.Parameters.Add(new OracleParameter("name", "상길이"));

            // 출력되는 datatable을 list에 담음 
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                MEMBERTBL mem = new MEMBERTBL();
                mem.MEMBERID = reader.GetString(0);
                mem.MEMBERNAME = reader.GetString(1);
                mem.MEMBERADDRESS = reader["MEMBERADDRESS"].ToString();
                list.Add(mem);
            }
        }
    }
    return View(list);
}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}