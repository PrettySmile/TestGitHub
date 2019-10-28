using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPnet.Controllers
{
    public class Homework_E_Controller : Controller
    {
        // GET: Homework_E_
        public ActionResult Index()
        {
            return View();
        }

        public string q1(int n)//10
        {
            for(int i=2; i*i<=n; i++)//i=2 4<=10; i=3 9<=10 i=4 -
            {
                if (n % i == 0)
                {                    
                    return n + "不是質數";
                }
            }
            return n + "是質數";
        }        

        public void q2(int x, int y)
        {
            int k = 0;
            int cX = x;
            int cY = y;
            while (cX%cY!=0)
            {
                k = cX % cY;
                cX = cY;
                cY = k;
            }                    
            Response.Write(x+"及"+y+"之最大公因數為"+cY);
        }

        //public string q3(string str)
        //{
        //    string originStr = str;
        //    string turnStr = turnString(str);
        //    if (originStr.Equals(turnStr))
        //    {
        //        return originStr+"是迴文";
        //    }
        //    else
        //    {
        //        return originStr+"不是迴文";
        //    }
        //}

        //public string turnString(string str)
        //{
        //    string result = "";
        //    for (int i = str.Length-1; i >=0; i--)
        //    {
        //        result += str[i];                
        //    }
        //    return result;
        //}

        public string q3_2(string str)
        {
            for(int i=0,j=str.Length-1; i<str.Length; i++,j--)
            {
                string a = str.Substring(i,1);
                string b = str.Substring(j,1);
                if (!a.Equals(b))
                {
                    return str + "不是迴文";
                }
            }
            return str + "是迴文";
        }

        public void q3_3(int a)
        {            
            int kk;
            int k=a;
            //string resultStr = "";
            int result=0;
            int aLength = a.ToString().Length;
            for(int i= aLength; i>0; i--)
            {
                kk = k % 10;
                k = k / 10;
                if (k == 0)
                {
                    result += kk;
                }
                else
                {
                    result += (int)(kk * Math.Pow(10, k.ToString().Length));
                }            
            }
            if (a == result)
            {
                Response.Write(a+ "是迴文");
            }
            else
            {
                Response.Write(a + "不是迴文");
            }
            //while (k > 0)
            //{                
            //    kk = k % 10;
            //    k = k / 10;
            //    //resultStr += kk;
            //}
            //Response.Write(resultStr);
        }

        public void q3_4(int n)
        {
            int r = 0, q = 0, nn = n;
            int result = 0;
            do
            {
                r = nn % 10;
                result += r;
                q = nn / 10;
                nn = q;
                if (q != 0)
                {
                    result *= 10;
                }
                else
                {
                    break;
                }               
            } while (q != 0);
            if(result==n)
            {
                Response.Write(n + "是迴文");
            }
            else
            {
                Response.Write(n + "不是迴文");
            }
        }
    }
}