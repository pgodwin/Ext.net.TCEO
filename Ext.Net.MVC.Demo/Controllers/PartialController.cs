using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Ext.Net.MVC;

namespace Ext.Net.MVC.Demo.Controllers
{
    public class PartialController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult View1(string containerId)
        {
            PartialViewResult pr = new PartialViewResult(containerId);
            return pr;
        }

        public ActionResult View2(string containerId)
        {
            PartialViewResult pr = new PartialViewResult(containerId);
            pr.RenderMode = RenderMode.AddTo;
            pr.SingleControl = true;
            pr.WrapByScriptTag = false;
            return pr;
        }

        public ActionResult View3(string containerId)
        {
            PartialViewResult pr = new PartialViewResult(containerId);
            pr.RenderMode = RenderMode.AddTo;
            pr.SingleControl = true;
            pr.WrapByScriptTag = false;
            pr.ViewData["title"] = DateTime.Now.ToLongTimeString();
            pr.ViewData["html"] = DateTime.Now.ToLongTimeString();
            return pr;
        }

        public ActionResult View4()
        {
            PartialViewResult pr = new PartialViewResult();
            pr.SingleControl = true;
            pr.WrapByScriptTag = false;
            return pr;
        }
    }
}
