using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASPnet.Models;

namespace ASPnet.Controllers
{
    public class 產品類別Controller : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();

        // GET: 產品類別
        public ActionResult Index()
        {
            return View(db.產品類別.ToList());
        }

        // GET: 產品類別/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            產品類別 產品類別 = db.產品類別.Find(id);
            if (產品類別 == null)
            {
                return HttpNotFound();
            }
            return View(產品類別);
        }

        // GET: 產品類別/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: 產品類別/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "類別編號,類別名稱,說明,圖片")] 產品類別 產品類別)
        {
            if (ModelState.IsValid)
            {
                db.產品類別.Add(產品類別);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(產品類別);
        }

        // GET: 產品類別/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            產品類別 產品類別 = db.產品類別.Find(id);
            if (產品類別 == null)
            {
                return HttpNotFound();
            }
            return View(產品類別);
        }

        // POST: 產品類別/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "類別編號,類別名稱,說明,圖片")] 產品類別 產品類別)
        {
            if (ModelState.IsValid)
            {
                db.Entry(產品類別).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(產品類別);
        }

        // GET: 產品類別/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            產品類別 產品類別 = db.產品類別.Find(id);
            if (產品類別 == null)
            {
                return HttpNotFound();
            }
            return View(產品類別);
        }

        // POST: 產品類別/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            產品類別 產品類別 = db.產品類別.Find(id);
            db.產品類別.Remove(產品類別);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
