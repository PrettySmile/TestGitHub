using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02Controller.Controllers
{
    public class MultiFileUploadController : Controller
    {
        // GET: MultiFileUpload
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(HttpPostedFileBase[] photo)
        {
            string fileName = "";
            if (photo != null)
            {
                int a = 0;
                foreach(HttpPostedFileBase p in photo)
                {
                    a++;
                    if (p!=null && p.ContentLength > 0)
                    {
                        //fileName = p.FileName;
                        //fileName = Path.GetFileName(fileName);
                        fileName = DateTime.Now.ToString().Replace(":","").Replace("/","").Replace("上午","").Replace("下午", "") + a;
                        fileName += ".jpg";
                        p.SaveAs(Server.MapPath("~/Photos/" + fileName));
                    }
                }
            }
            return RedirectToAction("ShowPhotos");
        }

        public string ShowPhotos()
        {
            string show = "";

            DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/Photos"));

            FileInfo[] fInfo = dir.GetFiles();

            foreach (FileInfo result in fInfo)
            {
                show += "<a href='../Photos/" + result.Name + "'><img src='../Photos/" + result.Name + "' width='90' height='60' /></a>";
            }
            show += "<p><a href='Create'>返回</a><p>";
            return show;
        }
    }
}