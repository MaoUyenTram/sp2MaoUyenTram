using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using System.Data.Entity;
using Website.Models;
using Website.App_Start;
using System.Web.Helpers;
using System.Security.Claims;
using System.Web.Optimization;

namespace Website
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //Database.SetInitializer(new DropCreateDatabaseAlways<WebsiteContext>());
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Name;
            Application["Sessions"] = -1;
        }

        //src = https://stackoverflow.com/questions/8336810/deny-direct-url-access-to-action-method
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
        public class NoDirectAccessAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                if (filterContext.HttpContext.Request.UrlReferrer == null ||
                            filterContext.HttpContext.Request.Url.Host != filterContext.HttpContext.Request.UrlReferrer.Host)
                {
                    filterContext.Result = new RedirectToRouteResult(new
                                   RouteValueDictionary(new { controller = "Questions", action = "Index", area = "" }));
                }
            }
        }

        void Session_Start()
        {
            Application["Sessions"] = (int)Application["Sessions"] + 1;
            //HttpContext.Current.Session["uid"] = null;
        }
        void Session_End()
        {
            Application["Sessions"] = (int)Application["Sessions"] - 1;
        }
    }
}