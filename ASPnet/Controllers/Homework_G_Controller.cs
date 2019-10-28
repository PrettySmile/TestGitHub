using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPnet.Controllers
{
    public class Homework_G_Controller : Controller
    {
        // GET: Homework_G_
        public ActionResult Index()
        {
            return View();
        }

        public string Index(string idCard)
        {
            Boolean isPass;
            isPass = isCheckLength(idCard);
            if (!isPass) return "格式有誤";
            isPass = isCheckHeaderEnglish(idCard);
            if (!isPass) return "格式有誤";
            isPass = isCheckGender(idCard);
            if (!isPass) return "格式有誤";
            isPass = isCheckBody(idCard);
            if (!isPass) return "格式有誤";
            isPass = isCheckLegitimate(idCard);
            if (!isPass) return "此身分證字號不正確";
            return "這是合法的身分證字號";
        }

        private Boolean isCheckLength(string idCard)
        {
            if (idCard.Length != 10)return false;
            return true;
        }

        private Boolean isCheckHeaderEnglish(string idCard)
        {
            string headerEnglish = idCard.Substring(0, 1);
            byte[] array = System.Text.Encoding.ASCII.GetBytes(headerEnglish);
            int asciicode;
            for (int i = 0; i < array.Length; i++)
            {
                asciicode = (int)(array[i]);
                if (!(asciicode >= 65 && asciicode <= 90)) return false;
            }
            return true;
        }

        //Teacher
        //private Boolean isCheckHeaderEnglish(string idCard)
        //{
        //    string eng = "ABCDEFGHJKLMNPQRSTUVXYWZIO";
        //    string w = idCard.Substring(0, 1);
        //    for (int i = 0; i < eng.Length; i++)
        //    {
        //        //if (eng.Contains(w))
        //        //{
        //        //    return true;
        //        //}
        //        if (eng.IndexOf(w) >= 0)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}


        private Boolean isCheckGender(string idCard)
        {
            string gender = idCard.Substring(1, 1);
            if (!(gender.Equals("1") || gender.Equals("2"))) return false;            
            return true;
        }

        private Boolean isCheckBody(string idCard)
        {
            string body = idCard.Substring(2,8);
            byte[] array = System.Text.Encoding.ASCII.GetBytes(body);
            int asciicode;
            for (int i=0; i<array.Length; i++)
            {
                asciicode = (int)(array[i]);
                if (!(asciicode >= 48 && asciicode <= 57)) return false;
            }                        
            return true;
        }

        private Boolean isCheckLegitimate(string idCard)
        {
            string headerEnglish = idCard.Substring(0, 1);
            string numStr = turnHeaderEnglisht2NumStr(headerEnglish);
            idCard = idCard.Replace(headerEnglish, numStr);
            int[] odds = new int[] {1,9,8,7,6,5,4,3,2,1,1};
            int result = 0;
            int val;
            for (int i=0; i< idCard.Length; i++)
            {                
                val = Convert.ToInt32((idCard[i]));                
                result += val * odds[i];
            }
            if (result % 10 != 0) return false;
            return true;
        }

        private string turnHeaderEnglisht2NumStr(string headerEnglish)
        {
            const string eng = "ABCDEFGHJKLMNPQRSTUVXYWZIO";
            int index = eng.IndexOf(headerEnglish);
            return 10 + index + "";
        }
    }
}