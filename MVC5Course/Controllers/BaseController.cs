using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    //加上BaseController,全部套用授權
    [Authorize]
    //最好加上 abstract,這樣才不會有人使用Url:/Base/連到這個controller
    //但BaseController也沒有Action,所以頂多實作HandleUnknownAction
    public class BaseController : Controller
    {
        public ProductRepository pro = RepositoryHelper.GetProductRepository();

        //當Controller找不到Action時,實作HandleUnknownAction,將之導向至首頁
        //也可固定導向至別的Controller/Action(ex:this.RedirectToAction("About", "Home"))
        protected override void HandleUnknownAction(string actionName)
        {
            this.Redirect("/").ExecuteResult(this.ControllerContext);
            //base.HandleUnknownAction(actionName);
        }
        /*
         * 原則上BaseController不會有action,但也可以有
        // GET: Base
        public ActionResult Index()
        {
            return View();
        }
        */
    }
}