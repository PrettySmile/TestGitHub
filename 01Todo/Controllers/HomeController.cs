using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _01Todo.Models;

namespace _01Todo.Controllers
{
    public class HomeController : Controller
    {
        TodoContext db = new TodoContext();

        // GET: Home
        public ActionResult Index()
        {
            //TodoContext db = new TodoContext();
            var todoes2 = db.ToDoes.OrderBy(m => m.Date).ToList();

            var todoes = from t in db.ToDoes
                         orderby t.Date
                         select t;

            return View(todoes2);
            //return View(todoes.ToList());
        }

        //回應一個view的actoin，不是寫入資料庫的action
        //沒有標[HttpPost]，預設就是用get
        public ActionResult Create()
        {
            return View();
        }

        //標[HttpPost]的意義是為了view的from，因為method是post
        [HttpPost]
        public ActionResult Create(string Title, string Image, DateTime Date)
        {
            ToDo todo = new ToDo();
            todo.Title = Title;
            todo.Image = Image;
            todo.Date = Date;

            //TodoContext db = new TodoContext();
            db.ToDoes.Add(todo);
            db.SaveChanges();//insert into todes values(XXXXX)

            ViewBag.Title2 = Title;
            ViewBag.Image = Image;
            ViewBag.Date = Date;
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            //兩種撰寫方式todo | todo2
            var todo = db.ToDoes.Where(m=>m.ID== id).FirstOrDefault();//FirstOrDefault:傳回第一個，如果沒有傳回預設值

            var todo2 = from t in db.ToDoes
                        where t.ID == id
                        select t;

            db.ToDoes.Remove(todo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //建立2個Edit Action，一個為get方法，一個為post方法
        public ActionResult Edit(int id)
        {
            var todo = db.ToDoes.Where(m=>m.ID==id).FirstOrDefault();
            return View(todo);
        }

        [HttpPost]
        public ActionResult Edit(int Id, string Title, string Image, DateTime Date)
        {
            var todo = db.ToDoes.Where(m => m.ID == Id).FirstOrDefault();
            todo.Title = Title;
            todo.Image = Image;
            todo.Date = Date;            
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }    

}