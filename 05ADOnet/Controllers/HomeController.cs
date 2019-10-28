using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace _05ADOnet.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString);
        SqlCommand Cmd = new SqlCommand();

        private void executeSql(string sql)
        {
            this.Cmd.CommandText = sql;
            this.Cmd.Connection = this.Conn;
            this.Conn.Open();
            this.Cmd.ExecuteNonQuery();//執行，不做query
            this.Conn.Close();
        }

        private DataTable querySql(string sql)
        {
            SqlDataAdapter adp = new SqlDataAdapter(sql, this.Conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            return ds.Tables[0];
        }

        // GET: Home
        public ActionResult Index()
        {
            DataTable dt = querySql("select * from tStudent");
            
            return View(dt);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string fStuId, string fName, string fEmail, int fScore)
        {
            string sql = "Insert into tStudent values(@fStuId,@fName,@fEmail,@fScore)";
            
            this.Cmd.Parameters.AddWithValue("@fStuId",fStuId);
            this.Cmd.Parameters.AddWithValue("@fName", fName);
            this.Cmd.Parameters.AddWithValue("@fEmail", fEmail);
            this.Cmd.Parameters.AddWithValue("@fScore", fScore);

            executeSql(sql);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(string fStuId)
        {
            string sql = "delete from tStudent where fStuId=@fStuId";
            this.Cmd.Parameters.AddWithValue("@fStuId", fStuId);
            executeSql(sql);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string fStuId)
        {
            this.Cmd.Parameters.AddWithValue("@fStuId",fStuId);
            DataTable dt = querySql("select * from tStudent ");
            return View(dt);
        }

        [HttpPost]
        public ActionResult Edit(string fStuId, string fName, string fEmail, int fScore)
        {
            string sql = "update tStudent set fName=@fName,fEmail=@fEmail,fScore=@fScore where fStuId = @fStuId";
            this.Cmd.Parameters.AddWithValue("@fStuId", fStuId);
            this.Cmd.Parameters.AddWithValue("@fName", fName);
            this.Cmd.Parameters.AddWithValue("@fEmail", fEmail);
            this.Cmd.Parameters.AddWithValue("@fScore", fScore);
            executeSql(sql);
            return RedirectToAction("Index");
        }

    }
}