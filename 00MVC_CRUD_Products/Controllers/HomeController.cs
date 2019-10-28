using _00MVC_CRUD_Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _00MVC_CRUD_Products.Controllers
{
    public class HomeController : Controller
    {
        dbProductEntities db = new dbProductEntities();
        
        // GET: Home
        public ActionResult Index()//首頁
        {
            IEnumerable<tProduct> products = db.tProduct.ToList();
            //var products = db.tProduct.ToList();//var=動態型別的變數            
            return View(db.tProduct.ToList());
        }
        
        //讀設使用GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string fId, string fName, decimal fPrice, HttpPostedFileBase fImg)
        {
            //處理圖檔上傳
            string fileName = "";
            if (fImg != null)
            {
                if (fImg.ContentLength > 0)
                {
                    fileName = System.IO.Path.GetFileName(fImg.FileName);
                    fImg.SaveAs(Server.MapPath("~/images/"+fileName));//MapPath:把邏輯路徑，轉成實體路徑。//將檔案存到Images資料夾下
                }
            }

            //新增至db
            //步驟1，先將東西丟至module
            tProduct product = new tProduct();
            product.fId = fId;
            product.fName = fName;
            product.fPrice = fPrice;
            product.fImg = fileName;
            db.tProduct.Add(product);
            //步驟2，存至db
            //多出來的做新增
            //不一樣的做修改
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string fId)
        {
            var product = db.tProduct.Where(m => m.fId == fId).FirstOrDefault();
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(string fId, string fName, decimal fPrice, HttpPostedFileBase fImg,string oldImg)
        {
            //處理圖檔上傳
            string fileName = "";
            if (fImg != null)
            {
                if (fImg.ContentLength > 0)
                {
                    System.IO.File.Delete(Server.MapPath("~/images/" + oldImg));//刪掉既有的圖檔
                    fileName = System.IO.Path.GetFileName(fImg.FileName);
                    fImg.SaveAs(Server.MapPath("~/images/" + fileName));//MapPath:把邏輯路徑，轉成實體路徑。//將檔案存到Images資料夾下                    
                }
            }
            else
            {
                fileName = oldImg;
            }

            //新增至db
            //步驟1，先將東西丟至module
            var product = db.tProduct.Where(m => m.fId == fId).FirstOrDefault();
            product.fName = fName;
            product.fPrice = fPrice;
            product.fImg = fileName;
            //步驟2，存至db
            //多出來的做新增
            //不一樣的做修改
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string fId)
        {
            var product = db.tProduct.Where(m=>m.fId==fId).FirstOrDefault();//Lambda
            string fileName = product.fImg;
            if (fileName != "")
            {
                //刪除指定圖檔
                System.IO.File.Delete(Server.MapPath("~/images/"+fileName));
            }
            db.tProduct.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}