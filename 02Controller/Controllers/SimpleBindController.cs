using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02Controller.Controllers
{
    public class SimpleBindController : Controller
    {
        //簡單模型繫結
        //Controller跟view之間做某個動作，如何做

        // GET: SimpleBind
        public ActionResult Create()
        {
            return View();
        }

        //參數就是簡單模型繫結，在html把物件的name定義成是參數名稱，自動會做繫結
        [HttpPost]
        public ActionResult Create(string PId, string PName, int Price)
        {
            ViewBag.PId = PId;
            ViewBag.PName = PName;
            ViewBag.Price = Price;
            return View();
        }
    }
}