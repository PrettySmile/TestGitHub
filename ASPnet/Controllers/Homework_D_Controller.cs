using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPnet.Controllers
{
    public class Homework_D_Controller : Controller
    {
        // GET: Homework_D
        public ActionResult Index()
        {
            return View();
        }

        public void q1()
        {
            short a = 42;
            float b = 2.5f;

            Response.Write(a + b);
            Response.Write("</br>");
            Response.Write(a - b);
            Response.Write("</br>");
            Response.Write(a * b);
            Response.Write("</br>");
            Response.Write(a / b);
            Response.Write("</br>");
            Response.Write(a % b);
        }

        public double q2(double celsius)
        {
            return celsius * 9 / 5 + 32;
        }

        public void q3(int x, int y)
        {
            x = x + y;
            y = x - y;
            x = x - y;
            Response.Write("x=" + x + " ;y=" + y);
        }

        public string q4(int score)
        {
            string result = "";
            int num = score / 10;            
            switch (num)
            {
                case 10:
                case 9:
                    result = "優等";
                    break;
                case 8:
                    result = "甲等";
                    break;
                case 7:
                    result = "乙等";
                    break;
                case 6:
                    result = "丙等";
                    break;
                default:
                    result = "丁等";
                    break;
            }
            return result;
        }

        public void q5(int n)
        {
            for(int i=1; i<=n; i++)
            {
                if(i%5!=0)Response.Write(i+"<br/>");
            }
        }

        public void q6(int n)
        {
            int result = 0;
            for (int i = 1; i <= n; i++)
            {
                if (i % 3 != 0) result+=i;
            }
            Response.Write(result);
        }

        public void q7(int lineNum)
        {
            int i = 0;
            string result = "";
            while (lineNum>i)
            {
                i++;
                result = result + "*";
                Response.Write(result);
                Response.Write("<br/>");
            }            
        }

        public void q8()
        {
            for(int i=1; i<=9; i++)
            {
                for (int ii = 1; ii <= 9; ii++)
                {
                    Response.Write(i+"*"+ii+"="+(i*ii)+"<br/>");
                }
            }
        }

    }
}