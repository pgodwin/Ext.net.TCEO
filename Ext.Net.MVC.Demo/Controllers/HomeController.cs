using System.Collections.Generic;
using System.Web.Mvc;

namespace Ext.Net.MVC.Demo.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            this.ViewData["AppName"] = "<b>Northwind Traders</b> (1.0 RC)";
            this.ViewData["Username"] = this.HttpContext.User.Identity.Name;

            return this.View();
        }

        public ActionResult Dashboard()
        {
            List<string> items = new List<string>();
            
            items.Add("test");

            this.ViewData["Data"] = items;

            return this.View();
        }

        public ActionResult About()
        {
            return this.View();
        }

        public ActionResult Form()
        {
            return this.View();
        }

        public AjaxFormResult SaveForm(string txtName, string txtEmail, string txtComments)
        {

            AjaxFormResult result = new AjaxFormResult();

            result.Script = X.Msg.Alert("Success", "Bug report sent").ToScript();
            
            return result;
        }
    }
}
