using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : Controller
    {
        // GET: AR
        public ActionResult Index()
        {
            return View("123");
        }
        public ActionResult View2()
        {
            return PartialView("Index");
        }
        public ActionResult View3()
        {
            return View();
        }
        //public ActionResult File1()
        //{
        //    return File(Server.MapPath("~/Content/a.jpg"), "image/png");
        //}
        //public ActionResult File2()
        //{
        //    return File(Server.MapPath("~/Content/a.jpg"), "image/png", "下載檔案.png");
        //}
        public ActionResult File1()
        {
            //return File(@"C:\Projects\MVC5Course\MVC5Course\Content\251178_medium.png", "image/png");
            return File(Server.MapPath("~/Content/a.jpg"), "image/jpeg");
        }
 
        public ActionResult File2()
        {
            //return File(@"C:\Projects\MVC5Course\MVC5Course\Content\251178_medium.png", "image/png");
            return File(Server.MapPath("~/Content/b.jpg"), "image/jpeg", "圖片下載.jpg");
        }
  
    }
}