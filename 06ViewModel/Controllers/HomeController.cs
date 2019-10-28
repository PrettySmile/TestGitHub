using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _06ViewModel.Models;
using System.Data.Entity;

namespace _06ViewModel.Controllers
{
    public class HomeController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();

        // GET: Home
        public ActionResult Index()
        {
            //select * from 員工 as a
            //    inner join 職稱 as b
            //    on a.職稱==b.職稱代碼

            //var aa = from b in db.職稱
            //         join c in db.員工
            //         on b.職稱代碼 equals c.職稱
            //         select new { c.員工編號, c.姓名, b.職稱1, c.出生日期 };
            //會看到join有兩種可能：第一種明明有關連，但還要寫join；第二種完全沒關連。

            //var aa = from b in db.職稱
            //         from c in db.員工                     
            //         select new { c.員工編號, c.姓名, b.職稱1, c.出生日期 };

            var aa = db.員工.Include(m=>m.職稱1); //用include取代inner join或join //職稱1=select * from 職稱
            var cc = db.員工.Join(db.職稱, 員=>員.職稱, 職=>職.職稱代碼, (員,職)=>員.職稱);

            return View(cc.ToList());
        }

        public ActionResult Create()
        {
            //直接寫法
            //ViewBag.職稱=db.職稱.ToList();

            ViewBag.職稱 = new SelectList(db.職稱,"職稱代碼"/*value*/,"職稱1");
            return View();
        }

        [HttpPost]
        public ActionResult Create(員工 emp)
        {
            db.員工.Add(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}