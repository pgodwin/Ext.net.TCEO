using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Ext.Net.MVC
{
    public static class HtmlHelperExtensions
    {
        // Renders the partial view with the parent's view data
        public static string RenderExtPartial(this HtmlHelper htmlHelper, string partialViewName)
        {
            return htmlHelper.RenderExtPartial(partialViewName, htmlHelper.ViewData, null, IDMode.Explicit, null);
        }

        public static string RenderExtPartial(this HtmlHelper htmlHelper, string partialViewName, IDMode idMode)
        {
            return htmlHelper.RenderExtPartial(partialViewName, htmlHelper.ViewData, null, idMode, null);
        }

        // Renders the partial view with the parent's view data
        public static string RenderExtPartial(this HtmlHelper htmlHelper, string partialViewName, string id)
        {
            return htmlHelper.RenderExtPartial(partialViewName, htmlHelper.ViewData, null, IDMode.Explicit, id);
        }

        public static string RenderExtPartial(this HtmlHelper htmlHelper, string partialViewName, IDMode idMode, string id)
        {
            return htmlHelper.RenderExtPartial(partialViewName, htmlHelper.ViewData, null, idMode, id);
        }

        // Renders the partial view with the given view data
        public static string RenderExtPartial(this HtmlHelper htmlHelper, string partialViewName, ViewDataDictionary viewData)
        {
            return htmlHelper.RenderExtPartial(partialViewName, viewData, null, IDMode.Explicit, null);
        }

        public static string RenderExtPartial(this HtmlHelper htmlHelper, string partialViewName, ViewDataDictionary viewData, IDMode idMode)
        {
            return htmlHelper.RenderExtPartial(partialViewName, viewData, null, idMode, null);
        }

        // Renders the partial view with the given view data
        public static string RenderExtPartial(this HtmlHelper htmlHelper, string partialViewName, ViewDataDictionary viewData, string id)
        {
            return htmlHelper.RenderExtPartial(partialViewName, viewData, null, IDMode.Explicit, id);
        }

        // Renders the partial view with an empty view data and the given model
        public static string RenderExtPartial(this HtmlHelper htmlHelper, string partialViewName, object model)
        {
            return htmlHelper.RenderExtPartial(partialViewName, htmlHelper.ViewData, model, IDMode.Explicit, null);
        }

        public static string RenderExtPartial(this HtmlHelper htmlHelper, string partialViewName, object model, IDMode idMode)
        {
            return htmlHelper.RenderExtPartial(partialViewName, htmlHelper.ViewData, model, idMode, null);
        }

        // Renders the partial view with an empty view data and the given model
        public static string RenderExtPartial(this HtmlHelper htmlHelper, string partialViewName, object model, string id)
        {
            return htmlHelper.RenderExtPartial(partialViewName, htmlHelper.ViewData, model, IDMode.Explicit, id);
        }

        // Renders the partial view with a copy of the given view data plus the given model
        public static string RenderExtPartial(this HtmlHelper htmlHelper, string partialViewName, object model, ViewDataDictionary viewData)
        {
            return htmlHelper.RenderExtPartial(partialViewName, viewData, model, IDMode.Explicit, null);
        }

        public static string RenderExtPartial(this HtmlHelper htmlHelper, string partialViewName, ViewDataDictionary viewData, object model, IDMode idMode, string id)
        {
            return htmlHelper.RenderExtPartial(partialViewName, viewData, model, null, IDMode.Explicit, id);
        }

        public static string RenderExtPartial(this HtmlHelper htmlHelper, string partialViewName, ViewDataDictionary viewData, object model, TempDataDictionary tempData, IDMode idMode, string id)
        {
            if (String.IsNullOrEmpty(partialViewName))
            {
                throw new ArgumentException("Value cannot be null or empty.", "partialViewName");
            }

            return new PartialViewRenderer().Render(htmlHelper.ViewContext, partialViewName, viewData, model, tempData, idMode, id);
        }
    }
}