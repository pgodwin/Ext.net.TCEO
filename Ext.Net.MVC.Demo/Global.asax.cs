using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Ext.Net.MVC.Demo
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_AuthenticateRequest(object sender, System.EventArgs e)
        {
            string url = HttpContext.Current.Request.RawUrl.ToLower();
            if(url.Contains("ext.axd"))
            {
                HttpContext.Current.SkipAuthorization = true;
            }
            else if (url.Contains("returnurl=/default.aspx") || url.Contains("returnurl=%2fdefault.aspx"))
            {
                Response.Redirect(url.Replace("returnurl=/default.aspx", "r=/").Replace("returnurl=%2fdefault.aspx", "r=/"));
            }
        } 

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.IgnoreRoute("{exclude}/{extnet}/ext.axd");

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );

            /**/

            routes.MapRoute(
              "Default2",
              "{controller}.mvc/{action}/{id}",
              new { action = "Index", id = "" }
            );

            routes.MapRoute(
              "Root",
              "",
              new { controller = "Home", action = "Index", id = "" }
            );
        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
        }
    }
}