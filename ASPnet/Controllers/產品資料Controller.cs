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
    public class 產品資料Controller : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();

        // GET: 產品資料
        public ActionResult Index()
        {
            var 產品資料 = db.產品資料.Include(產 => 產.供應商).Include(產 => 產.產品類別);
            return View(產品資料.ToList());
        }

        // GET: 產品資料/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            產品資料 產品資料 = db.產品資料.Find(id);
            if (產品資料 == null)
            {
                return HttpNotFound();
            }
            return View(產品資料);
        }

        // GET: 產品資料/Create
        public ActionResult Create()
        {
            ViewBag.供應商編號 = new SelectList(db.供應商, "供應商編號", "供應商1");
            ViewBag.類別編號 = new SelectList(db.產品類別, "類別編號", "類別名稱");
            return View();
        }

        // POST: 產品資料/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "產品編號,產品,供應商編號,類別編號,單位數量,單價,庫存量,已訂購量,安全存量,不再銷售")] 產品資料 產品資料)
        {
            if (ModelState.IsValid)
            {
                db.產品資料.Add(產品資料);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.供應商編號 = new SelectList(db.供應商, "供應商編號", "供應商1", 產品資料.供應商編號);
            ViewBag.類別編號 = new SelectList(db.產品類別, "類別編號", "類別名稱", 產品資料.類別編號);
            return View(產品資料);
        }

        // GET: 產品資料/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            產品資料 產品資料 = db.產品資料.Find(id);
            if (產品資料 == null)
            {
                return HttpNotFound();
            }
            ViewBag.供應商編號 = new SelectList(db.供應商, "供應商編號", "供應商1", 產品資料.供應商編號);
            ViewBag.類別編號 = new SelectList(db.產品類別, "類別編號", "類別名稱", 產品資料.類別編號);
            return View(產品資料);
        }

        // POST: 產品資料/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "產品編號,產品,供應商編號,類別編號,單位數量,單價,庫存量,已訂購量,安全存量,不再銷售")] 產品資料 產品資料)
        {
            if (ModelState.IsValid)
            {
                db.Entry(產品資料).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.供應商編號 = new SelectList(db.供應商, "供應商編號", "供應商1", 產品資料.供應商編號);
            ViewBag.類別編號 = new SelectList(db.產品類別, "類別編號", "類別名稱", 產品資料.類別編號);
            return View(產品資料);
        }

        // GET: 產品資料/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            產品資料 產品資料 = db.產品資料.Find(id);
            if (產品資料 == null)
            {
                return HttpNotFound();
            }
            return View(產品資料);
        }

        // POST: 產品資料/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            產品資料 產品資料 = db.產品資料.Find(id);
            db.產品資料.Remove(產品資料);
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
