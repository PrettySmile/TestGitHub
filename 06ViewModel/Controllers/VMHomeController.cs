using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _06ViewModel.Models;
using _06ViewModel.ViewModels;

namespace _06ViewModel.Controllers
{
    public class VMHomeController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        // GET: VMHome
        public ActionResult Index(int jobTitleID= 1)
        {
            ViewBag.jobTitle = db.職稱.Where(m=>m.職稱代碼== jobTitleID).FirstOrDefault().職稱1;
            ViewBag.jobTitleID = jobTitleID;

            EmpTitle et = new EmpTitle() {
                Employee = db.員工.Where(m=>m.職稱== jobTitleID).ToList(),
                JobTitle = db.職稱.ToList()
            };            

            return View(et);
        }

        public ActionResult Create(int? jobTitleID)//int? 允許是null值的意思
        {
            if (jobTitleID == null)return RedirectToAction("Index");
            ViewBag.jobTitleID = jobTitleID;
            return View();
        }

        [HttpPost]
        public ActionResult Create(員工 emp, int jobTitleID)
        {
            emp.職稱 = jobTitleID;
            db.員工.Add(emp);
            db.SaveChanges();
            return RedirectToAction("Index", new { jobTitleID=jobTitleID });
            //return RedirectToAction("Index", jobTitleID);
        }

        public ActionResult Details(int? id, int jobTitleID)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.jobTitle = db.職稱.Where(m => m.職稱代碼 == jobTitleID).FirstOrDefault().職稱1;
            ViewBag.jobTitleID = jobTitleID;
            EmpTitle et = new EmpTitle() {
                Employee = db.員工.Where(m=>m.員工編號==id).ToList(),
                JobTitle = db.職稱.Where(m=>m.職稱代碼== jobTitleID).ToList()
            };
            return View(et);
        }

        public ActionResult Delete(int id,int jobTitleID)
        {
            員工 emp = db.員工.Where(m => m.員工編號 == id).FirstOrDefault();
            db.員工.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("Index", new { jobTitleID=jobTitleID });
        }

    }
}