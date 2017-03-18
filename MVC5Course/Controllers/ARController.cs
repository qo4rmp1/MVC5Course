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
            /*
            講義P92
            PartialViewResult
            return PartialView();
            與 ViewResult 唯一的差異 ：不會載入 _Layout
            */
            return PartialView("Index");
        }
        public ActionResult View3()
        {
            return View();
        }
        public ActionResult File1()
        {
            return File(Server.MapPath("~/Content/a.jpg"), "image/jpeg");
        }
        public ActionResult File2()
        {
            return File(Server.MapPath("~/Content/b.jpg"), "image/jpeg", "下載檔案.jpg");
        }
        public ActionResult Redirect1()
        {
            //HTTP301永久轉址=>google SEO PageRaking才會繼續累加
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Redirect2()
        {
            //HTTP302暫時轉址
            return RedirectToActionPermanent("Index", "Home");
        }


    }
}