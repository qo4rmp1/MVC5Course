using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC5Course.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [設定本控制器常用的ViewBag資料Attribute]
        public ActionResult About(string Msg = "")
        {
            if (Msg.Contains("err"))
            {
                throw new IndexOutOfRangeException("ex");
            }
            return View();
        }
        [僅在本機開發測試用Attribute]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Test()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginVM login, string ReturnUrl = "")  //使用強型別接收  //(string UserName, string PassWord)
        {
            if (ModelState.IsValid)
            {
                TempData["LoginResult"] = login;

                FormsAuthentication.RedirectFromLoginPage(login.UserName, false);
                if (ReturnUrl.StartsWith("/"))
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index");
                }//return Content(String.Format("{0}:{1}", login.UserName, login.PassWord));
            }
            else
            {
                return Content("Login Failed!");
            }
        }
        [HttpPost]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
        public ActionResult TestPage()
        {
            return View();
        }
    }
}