﻿using System;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    internal class 設定本控制器常用的ViewBag資料Attribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.Message = "Your application description page.1212121212";
        }
    }
}