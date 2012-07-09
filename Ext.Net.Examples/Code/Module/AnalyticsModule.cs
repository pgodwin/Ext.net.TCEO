using System;
using System.Globalization;
using System.Web;

using Ext.Net.Utilities;

namespace Ext.Net.Examples
{
    public class AnalyticsModule : IHttpModule
    {
        public void Init(HttpApplication app)
        {
            app.ReleaseRequestState += RequestFilter;
        }

        private void RequestFilter(object sender, EventArgs e)
        {
            if (HttpContext.Current == null || HttpContext.Current.Response == null)
            {
                return;
            }

            HttpResponse response = HttpContext.Current.Response;

            if (!RequestManager.IsAjaxRequest)
            {
                object marker = HttpContext.Current.Items[ResourceManager.FilterMarker];
                string url = HttpContext.Current.Request.FilePath;                
                bool isExample = url.StartsWith("/Examples/", true, CultureInfo.InvariantCulture) && url.EndsWith(".aspx");

                if (marker != null && (bool)marker && isExample)
                {
                    if (response.ContentType.IsNotEmpty() && response.ContentType.Equals("text/html", StringComparison.InvariantCultureIgnoreCase))
                    {
                        response.Filter = new AnalyticsFilter(response.Filter);
                    }
                }
            }
        }

        public void Dispose() { }
    }
}
