using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace _05ADOnet.Controllers
{
    public class LoginController : Controller
    {
        SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString);                

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string id, string pwd)
        {            
            //string sql = "select * from tStudent where fEmail=@fEmail and fStuId=@fStuId";
            string sql = "select * from tStudent where fEmail = @fEmail and fStuID = @fStuID";
            SqlCommand cmd = new SqlCommand(sql,Conn);
            cmd.Parameters.AddWithValue("@fEmail",id);
            cmd.Parameters.AddWithValue("@fStuId", pwd);
            SqlDataReader rd;//專門在讀資料的
            Conn.Open();
            rd=cmd.ExecuteReader();
            if (rd.Read()) {//rd.Read()寫一次，指標就會移到下一筆，有讀到資料=true；沒讀到資料=false
                Session["id"] = rd["fStuId"].ToString();//Session內的值，會到把瀏覽器關掉或登出網址為止，都不會消失
                Conn.Close();
                return RedirectToAction("Index","Home");
            }
            Conn.Close();
            ViewBag.LoginErr="帳號或密碼有誤!!";
            return View();            
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index","Home");
        }

    }
}