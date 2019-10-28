using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _04EF.Models;

namespace _04EF.Controllers
{    
    public class ValidationController : Controller
    {
        dbStudentEntities db = new dbStudentEntities();
        // GET: Validation
        public ActionResult Index()
        {
            return View(db.tStudent.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tStudent stu)
        {
            //true = Module的驗證器，完全通過
            if (ModelState.IsValid) { 
                db.tStudent.Add(stu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stu);
        }

        public ActionResult Delete(string id)
        {
            var stu = (from m in db.tStudent
                      where m.fStuId==id
                      select m).FirstOrDefault();
            //var stu = db.tStudent.Where(m=>m.fStuId==id).FirstOrDefault();
            db.tStudent.Remove(stu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}