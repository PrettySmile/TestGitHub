using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _02Controller.Models;

namespace _02Controller.Controllers
{
    //複雜模型繫結
    public class ComplexBindController : Controller
    {
        // GET: ComplexBind
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            ViewBag.PId = product.PId;
            ViewBag.PName = product.PName;
            ViewBag.Price = product.Price;
            return View();
        }
    }
}