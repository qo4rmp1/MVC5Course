﻿using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC5Course.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your application description page.1212121212";

      return View();
    }

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
    public ActionResult Login(LoginVM login, string ReturnUrl)  //使用強型別接收  //(string UserName, string PassWord)
    {
      if (ModelState.IsValid)
      {
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
  }
}