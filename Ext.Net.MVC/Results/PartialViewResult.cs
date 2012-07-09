using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;
using System.Web.UI;
using Ext.Net;
using Ext.Net.Utilities;

namespace Ext.Net.MVC
{
    public class PartialViewResult : ViewResultBase
    {
        private RenderMode renderMode = RenderMode.RenderTo;
        private IDMode idMode = IDMode.Explicit;
        private bool wrapByScriptTag=true;

        public string ContainerId
        {
            get; set;
        }

        public IDMode IDMode
        {
            get { return idMode; }
            set { idMode = value; }
        }

        public RenderMode RenderMode
        {
            get { return renderMode; }
            set { renderMode = value; }
        }

        public string ControlId
        {
            get; set;
        }

        public bool WrapByScriptTag
        {
            get { return wrapByScriptTag; }
            set { wrapByScriptTag = value; }
        }

        public bool SingleControl
        {
            get; set;
        }

        public string ControlToRender
        {
            get;
            set;
        }

        public Panel.Config PanelConfig
        {
            get;
            set;
        }

        public PartialViewResult()
        {
        }

        public PartialViewResult(string containerId)
        {
            this.ContainerId = containerId;
        }

        public PartialViewResult(string containerId, RenderMode renderMode)
        {
            this.ContainerId = containerId;
            this.RenderMode = renderMode;
        }

        public PartialViewResult(string containerId, RenderMode renderMode, string controlId)
        {
            this.ContainerId = containerId;
            this.RenderMode = renderMode;
            this.ControlId = controlId;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (String.IsNullOrEmpty(this.ViewName))
            {
                ViewName = context.RouteData.GetRequiredString("action");
            }

            
            string id = this.ControlId ?? "ID_"+Guid.NewGuid().ToString().Replace("-", "");
            string ct = this.ContainerId ?? "Ext.getBody()";

            ViewDataDictionary dict = new ViewDataDictionary(ViewData);

            ViewEngineResult result = null;

            if (View == null)
            {
                result = this.ViewEngineCollection.FindPartialView(context, this.ViewName);
                //result = this.FindView(context);
                View = result.View;
            }

            string path = ((WebFormView)View).ViewPath;

            ViewContext viewContext = new ViewContext(context, View, ViewData, TempData, context.HttpContext.Response.Output);

            PartialViewPage pageHolder = new PartialViewPage
            {
                ViewData = dict,
                ViewContext = viewContext
            };
			
			var curRM = HttpContext.Current.Items[typeof(ResourceManager)];
			HttpContext.Current.Items[typeof(ResourceManager)] = null;

            ResourceManager rm = new ResourceManager();
            rm.RenderScripts = ResourceLocationType.None;
            rm.RenderStyles = ResourceLocationType.None;
            rm.IDMode = this.IDMode;
            pageHolder.Controls.Add(rm);
            
            ViewUserControl uc = (ViewUserControl)pageHolder.LoadControl(path);
            uc.ID = id+"_UC";
            uc.ViewData = ViewData;

            XControl controlToRender = null;            
            if (this.ControlToRender.IsEmpty() && !this.SingleControl)
            {
                Panel p;
                if(this.PanelConfig != null)
                {
                    p = new Panel(this.PanelConfig);
                    p.ID = id;
                    p.IDMode = this.IDMode;
                }
                else
                {
                    p = new Panel { ID = id, IDMode = this.IDMode, Border = false, Header = false };
                }
                
                pageHolder.Controls.Add(p);
                p.ContentControls.Add(uc);
                controlToRender = p;
            }
            else
            {
                pageHolder.Controls.Add(uc);
                XControl c = null;

                if (this.SingleControl)
                {
                    c = Ext.Net.Utilities.ControlUtils.FindControl<XControl>(uc);
                }
                else
                {
                    c = Ext.Net.Utilities.ControlUtils.FindControl<XControl>(pageHolder, this.ControlToRender);
                }

                if (c == null)
                {
                    if (this.SingleControl)
                    {
                        throw new Exception("Cannot find the Ext.Net control in the view");
                    }
                    else
                    {
                        throw new Exception("Cannot find the control with ID=" + this.ControlToRender);
                    }
                }

                controlToRender = c;

                if (controlToRender.IDMode == IDMode.Inherit)
                {
                    controlToRender.IDMode = this.IDMode;
                }
            }

            pageHolder.InitHelpers();

            string script = controlToRender.ToScript(this.RenderMode, ct, true);

            if(X.IsAjaxRequest)
            {
                script = "<Ext.Net.Direct.Response>" + script + "</Ext.Net.Direct.Response>";
            }
            else if(this.WrapByScriptTag)
            {
                script = "<script type=\"text/javascript\">" + script + "</script>";
            }

            IDisposable disposable = View as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
			
			HttpContext.Current.Items[typeof(ResourceManager)] = curRM;

            context.HttpContext.Response.Write(script);
        }

        public static string FindView(ControllerContext context, string viewName)
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

        protected override ViewEngineResult FindView(ControllerContext context)
        {
            ViewEngineResult result = ViewEngineCollection.FindPartialView(context, ViewName);
            if (result.View != null)
            {
                return result;
            }

            // we need to generate an exception containing all the locations we searched
            StringBuilder locationsText = new StringBuilder();
            foreach (string location in result.SearchedLocations)
            {
                locationsText.AppendLine();
                locationsText.Append(location);
            }
            throw new InvalidOperationException(String.Format(CultureInfo.CurrentUICulture,
                "The partial view '{0}' could not be found. The following locations were searched:{1}", ViewName, locationsText));
        }

        public static bool FileExists(string virtualPath)
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

    }
}
