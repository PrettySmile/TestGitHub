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
    public class DefaultController : Controller
    {
        //SqlConnection: Miscrosoft為了sql server建立的物件，要連到其他資料庫的話有其他物件。
        SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        private DataTable querySql(string sql)
        {
            SqlDataAdapter adp = new SqlDataAdapter(sql, this.Conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            return ds.Tables[0];
        }

        public string ShowEmployee()
        {
            string sql = "select 員工編號,姓名,稱呼,職稱 from 員工";
            DataTable dt = querySql(sql);
            string str = "";
            //方法一
            for(int i=0; i<dt.Rows.Count; i++)
            {
                str += "員工編號:" + dt.Rows[i]["員工編號"] + "<br>";
                str += "姓名:" + dt.Rows[i]["姓名"] + "<br>";
                str += "稱呼:" + dt.Rows[i]["稱呼"] + "<br>";
                str += "職稱:" + dt.Rows[i]["職稱"] + "<hr>";
            }
            //方法二
            foreach (DataRow row in dt.Rows)
            {
                str += "員工編號:" + row["員工編號"] + "<br>";
                str += "姓名:" + row["姓名"] + "<br>";
                str += "稱呼:" + row["稱呼"] + "<br>";
                str += "職稱:" + row["職稱"] + "<hr>";
            }
            return str;
        }

        public string ShowProduct()
        {
            string sql = "select 產品,單價,庫存量 from 產品資料 where 單價>30 order by 單價,庫存量 desc";
            DataTable dt = querySql(sql);
            string str = "";
            foreach (DataRow row in dt.Rows)
            {
                str += "產品:" + row["產品"] + "<br/>";
                str += "單價:" + row["單價"] + "<br/>";
                str += "庫存量:" + row["庫存量"] + "<hr/>";
            }
            return str;
        }

        public string ShowCustomerByAddress(string keyword)
        {
            //string sql = "select 公司名稱,連絡人,連絡人職稱,地址 from 客戶 where 地址 like '%"+keyword+"%'";
            string sql = "select 公司名稱,連絡人,連絡人職稱,地址 from 客戶 where 地址 like @keyword";
            SqlDataAdapter adp = new SqlDataAdapter(sql, this.Conn);
            adp.SelectCommand.Parameters.AddWithValue("@keyword"/*自取名稱*/,"%"+keyword+"%");
            DataSet ds = new DataSet();
            adp.Fill(ds);

            DataTable dt = ds.Tables[0];
            string str = "";
            foreach (DataRow row in dt.Rows)
            {
                str += "公司:" + row["公司名稱"] + "<br/>";
                str += "姓名:" + row["連絡人"] + row["連絡人職稱"] + "<br/>";
                str += "地址:" + row["地址"] + "<hr/>";
            }
            return str;
        }
    }
}