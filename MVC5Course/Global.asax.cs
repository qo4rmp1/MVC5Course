using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVC5Course
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //因為這只要註冊一次, 統一寫在Global.asax.cs
            //清除所有引擎(WebForm引擎、Razor引擎)
            ViewEngines.Engines.Clear();
            //加入Razor引擎
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}
