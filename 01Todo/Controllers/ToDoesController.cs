using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _01Todo.Models;

namespace _01Todo.Controllers
{
    public class ToDoesController : Controller
    {

        // GET: ToDoes
        public ActionResult Index()
        {
            return View();
        }

    }
}
