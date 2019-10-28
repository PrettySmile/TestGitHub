using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPnet.Controllers
{
    public class _01VarController : Controller
    {
        // GET: _01Var
        public string Index()
        {
            string w = "Hello World";
            return w;
        }

        public string boolIndex(string name,bool isBoy)
        {
            string result = "";
            if (isBoy)
            {
                result = "先生";
            }
            else
            {
                result = "女士";
            }
            return name+result+" 您好!";
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

        public string ifStatement(int age)
        {
            //0-6歲免票, 7-20歲半票, 21歲以上全票
            if (age > 20)
                return "全票";
            else if (age > 6)
                return "半票";
            else if (age >= 0)
                return "免票";

            return "年齡輸入錯誤";

        }
    }
}