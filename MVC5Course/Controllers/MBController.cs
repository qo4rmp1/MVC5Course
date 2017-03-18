using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class MBController : Controller
    {
        // GET: MB
        public ActionResult Index()
        {
            return View();
        }
        /*
         新增檢視
         選擇Create->LoginVM Model->空白
         */
        public ActionResult Form1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Form1(FormCollection form)
        {
            return Content(form["UserName"]);
            /*
             這兩者的值都一樣,但不建議使用Request.Form
             return Content(Request.Form["UserName"]);
             return Content(form["UserName"]);
             */
        }
    }
}