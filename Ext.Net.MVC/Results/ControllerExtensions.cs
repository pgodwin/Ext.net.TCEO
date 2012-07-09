using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ext.Net.MVC
{
    public static class ControllerExtensions
    {
        public static PartialViewResult PartialExtView(this System.Web.Mvc.Controller controller)
        {
            return PartialExtView(controller, null /* viewName */, null /* model */);
        }

        public static PartialViewResult PartialExtView(this System.Web.Mvc.Controller controller, object model)
        {
            return PartialExtView(controller, null /* viewName */, model);
        }

        public static PartialViewResult PartialExtView(this System.Web.Mvc.Controller controller, string viewName)
        {
            return PartialExtView(controller, viewName, null /* model */);
        }

        public static PartialViewResult PartialExtView(this System.Web.Mvc.Controller controller, string viewName, object model)
        {
            if (model != null)
            {
                controller.ViewData.Model = model;
            }

            return new PartialViewResult
            {
                ViewName = viewName,
                ViewData = controller.ViewData,
                TempData = controller.TempData
            };
        }
    }
}
