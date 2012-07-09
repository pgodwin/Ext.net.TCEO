using System.Web.Mvc;

namespace Ext.Net.MVC.Demo.Controllers
{
    [Authorize]
    public class OrderController : BaseDataController
    {
        public ActionResult OrderDetails()
        {
            ViewData["orderID"] = HttpContext.Request["orderID"] ?? "";
            return this.View();
        }

        public ActionResult OrderList()
        {
            return this.View();
        }
    }
}
