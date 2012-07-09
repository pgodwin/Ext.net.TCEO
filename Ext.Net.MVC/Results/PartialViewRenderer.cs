using System;
using System.Net;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;
using System.Web.UI;
using Ext.Net.Utilities;

namespace Ext.Net.MVC
{
    public class PartialViewRenderer
    {
        public virtual string Render(ControllerContext context, string viewName, ViewDataDictionary viewData, object model, IDMode idMode, string controlId)
        {
            return this.Render(context, viewName, viewData, model, new TempDataDictionary(), idMode, controlId);
        }

        public virtual string Render(ControllerContext context, string viewName, ViewDataDictionary viewData, object model, TempDataDictionary tempData, IDMode idMode, string controlId)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (String.IsNullOrEmpty(viewName))
            {
                viewName = context.RouteData.GetRequiredString("action");
            }

            //string path = PartialViewResult.FindView(context, viewName);
            string id = controlId ?? "ID_" + Guid.NewGuid().ToString().Replace("-", "");
            string ct = "ID_" + Guid.NewGuid().ToString().Replace("-", "");

            ViewDataDictionary newViewData = null;

            if (model == null)
            {
                if (viewData == null)
                {
                    newViewData = new ViewDataDictionary();
                }
                else
                {
                    newViewData = new ViewDataDictionary(viewData);
                }
            }
            else
            {
                if (viewData == null)
                {
                    newViewData = new ViewDataDictionary(model);
                }
                else
                {
                    newViewData = new ViewDataDictionary(viewData) { Model = model };
                }
            }

            ViewEngineResult result = ViewEngines.Engines.FindPartialView(context, viewName);
            IView view = result.View;
            string path = ((WebFormView)view).ViewPath;

            ViewContext viewContext = new ViewContext(context, view, newViewData, tempData ?? new TempDataDictionary(), context.HttpContext.Response.Output);

            PartialViewPage pageHolder = new PartialViewPage
            {
                ViewData = newViewData,
                ViewContext = viewContext
            };
			
			var curRM = HttpContext.Current.Items[typeof(ResourceManager)];
			HttpContext.Current.Items[typeof(ResourceManager)] = null;
			object oldPageRM = null;

            if (context.HttpContext.CurrentHandler is Page)
            {
                oldPageRM = ((Page)HttpContext.Current.CurrentHandler).Items[typeof(ResourceManager)];
                ((Page) HttpContext.Current.CurrentHandler).Items[typeof (ResourceManager)] = null;
            }

            ResourceManager rm = new ResourceManager();
            rm.RenderScripts = ResourceLocationType.None;
            rm.RenderStyles = ResourceLocationType.None;
            rm.IDMode = idMode;
            pageHolder.Controls.Add(rm);
            Panel p = new Panel { ID = id, IDMode = idMode, Border = false, Header = false };
            pageHolder.Controls.Add(p);

            ViewUserControl uc = (ViewUserControl)pageHolder.LoadControl(path);
            uc.ID = id + "_UC";
            uc.ViewData = newViewData;
            p.ContentControls.Add(uc);

            pageHolder.InitHelpers();

            string wScript = DefaultScriptBuilder.Create(p).Build(RenderMode.RenderTo, ct, null, true, true);            
            string script = string.Format("<div id=\"{0}\"></div><script type=\"text/javascript\">Ext.onReady(function(){{{1}}});</script>", ct, wScript);

            IDisposable disposable = view as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
			
			HttpContext.Current.Items[typeof(ResourceManager)] = curRM;
			if (context.HttpContext.CurrentHandler is Page)
            {
                ((Page)HttpContext.Current.CurrentHandler).Items[typeof(ResourceManager)] = oldPageRM;
            }

            return script;
        }

        protected virtual string FindView(ControllerContext context, string viewName)
        {
            string controller = context.RouteData.GetRequiredString("controller");

            var viewLocationFormats = new[] {
                "~/Views/{1}/{0}.ascx",
                "~/Views/Shared/{0}.ascx"
            };

            foreach (string viewLocationFormat in viewLocationFormats)
            {
                var path = string.Format(viewLocationFormat, viewName, controller);

                if (PartialViewResult.FileExists(path))
                {
                    return path;
                }
            }

            throw new InvalidOperationException(String.Format("The partial view '{0}' could not be found.", viewName));
        }

        protected virtual bool FileExists(string virtualPath)
        {
            try
            {
                object viewInstance = BuildManager.CreateInstanceFromVirtualPath(virtualPath, typeof(object));

                return viewInstance != null;
            }
            catch (HttpException he)
            {
                if (he.GetHttpCode() == (int)HttpStatusCode.NotFound)
                {
                    return false;
                }

                throw;
            }
            catch
            {
                return false;
            }
        }

        private static string cacheBuster = "";

        private static string CacheBuster
        {
            get
            {
                if (cacheBuster.IsEmpty())
                {
                    cacheBuster = new ResourceManager().CacheBuster;
                }

                return cacheBuster;
            }
        }

        public static string GetWebResourceUrl(Type type, string resourceName, ControllerContext context)
        {
            var page = new Page();
            
            if (resourceName.StartsWith(ResourceManager.ASSEMBLYSLUG))
            {
                var buster = (resourceName.EndsWith(".js") || resourceName.EndsWith(".css")) ? "?v=".ConcatWith(CacheBuster) : "";
                var urlHelper = new UrlHelper(context.RequestContext);

                return urlHelper.Content(("~/{0}/ext.axd{1}".FormatWith(resourceName.Replace(ResourceManager.ASSEMBLYSLUG, "").Replace('.', '/').ReplaceLastInstanceOf("/", "-"), buster)));
            }

            return HttpUtility.HtmlAttributeEncode(page.ClientScript.GetWebResourceUrl(type, resourceName));
        }
    }
}
