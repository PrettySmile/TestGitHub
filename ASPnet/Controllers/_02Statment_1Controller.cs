using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPnet.Controllers
{
    public class _02Statment_1Controller : Controller
    {
        // GET: _02Statment_1
        public ActionResult Index()
        {
            return View();
        }

        public string switchStatement(string color)
        {
            string a = "";
            switch (color)
            {
                case "黃":
                    a = "黃色";
                    break;
                case "綠":
                    a = "綠色";
                    break;
                case "紅":
                    a = "紅色";
                    break;
                default:
                    a = "這不是黃緣紅!";
                    break;
            }


            return a;

        }

        public void ifStatement(int age)
        {
            //0-6歲免票, 7-20歲半票, 21歲以上全票
            //if (age > 20)
            //    return "全票";
            //else if (age > 6)
            //    return "半票";
            //else if (age >= 0)
            //    return "免票";
            Response.Write("123");
            return;

        }


        public void poker()
        {
            string imgPath = "";
            for(int i=1; i<=52; i++)
            {
                imgPath += "<img src='../poker_img/"+i+".gif'/>";
            }
            Response.Write(imgPath);
        }
    }
}