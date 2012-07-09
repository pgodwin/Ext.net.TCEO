/********
 * This file is part of Ext.NET.
 *     
 * Ext.NET is free software: you can redistribute it and/or modify
 * it under the terms of the GNU AFFERO GENERAL PUBLIC LICENSE as 
 * published by the Free Software Foundation, either version 3 of the 
 * License, or (at your option) any later version.
 * 
 * Ext.NET is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU AFFERO GENERAL PUBLIC LICENSE for more details.
 * 
 * You should have received a copy of the GNU AFFERO GENERAL PUBLIC LICENSE
 * along with Ext.NET.  If not, see <http://www.gnu.org/licenses/>.
 *
 *
 * @version   : 1.2.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2011-09-12
 * @copyright : Copyright (c) 2006-2011, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : GNU AFFERO GENERAL PUBLIC LICENSE (AGPL) 3.0. 
 *              See license.txt and http://www.ext.net/license/.
 *              See AGPL License at http://www.gnu.org/licenses/agpl-3.0.txt
 ********/

using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Web;

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class DirectRequestModule : IHttpModule
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void Init(HttpApplication app)
        {
            app.PostAcquireRequestState += OnPostAcquireRequestState;
            app.PreSendRequestHeaders += RedirectPreSendRequestHeaders;
            app.ReleaseRequestState += AjaxRequestFilter;
        }

        void Application_Error(object sender, EventArgs e)
        {
            HttpApplication app = sender as HttpApplication;
            HttpContext context = app.Context;

            if (RequestManager.HasXHeader(context.Request))
            {
                DirectResponse responseObject = new DirectResponse(true);
                string error = null;

                if (HttpContext.Current != null)
                {
                    error = HttpContext.Current.Error != null ? HttpContext.Current.Error.ToString() : null;    
                }
                
                if (!ResourceManager.AjaxSuccess || error.IsNotEmpty())
                {
                    responseObject.Success = false;

                    if (error.IsNotEmpty())
                    {
                        responseObject.ErrorMessage = error;
                    }
                    else
                    {
                        responseObject.ErrorMessage = ResourceManager.AjaxErrorMessage;
                    }
                }

                app.Context.Response.Clear();
                app.Context.Response.ClearContent();
                app.Context.Response.ClearHeaders();
                app.Context.Response.StatusCode = (int)HttpStatusCode.OK;
                app.Context.Response.Write(responseObject.ToString());
                app.Context.Response.End();
                app.CompleteRequest();
            }
        }

        private void OnPostAcquireRequestState(object sender, EventArgs eventArgs)
        {
            HttpApplication app = (HttpApplication)sender;
            HttpRequest request = app.Context.Request;

            if (DirectMethod.IsStaticMethodRequest(request) && RequestManager.IsAjaxRequest)
            {
                this.ProcessRequest(app, request);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected static bool IsDebugging
        {
            get
            {
                bool result = false;

                if (HttpContext.Current != null)
                {
                    result = HttpContext.Current.IsDebuggingEnabled;
                }

                return result;
            }
        }

        private void ProcessRequest(HttpApplication app, HttpRequest request)
        {
            DirectResponse responseObject = new DirectResponse(true);

            try
            {
                HttpContext context = HttpContext.Current;
                
                // Get handler
                HandlerMethods handler = HandlerMethods.GetHandlerMethods(context, request.FilePath);

                if (handler == null)
                {
                    throw new Exception("The Method '{0}' has not been defined.".FormatWith(request.FilePath));
                }

                // Get method name to invoke
                string methodName = HandlerMethods.GetMethodName(context);

                if (methodName.IsEmpty())
                {
                    throw new Exception("No methodName has been set in the configuration.");
                }


                DirectMethod directMethod = handler.GetStaticMethod(methodName);

                if (directMethod == null)
                {
                    throw new Exception("The static DirectMethod '{0}' has not been defined.".FormatWith(directMethod));
                }

                object result = directMethod.Invoke();

                if (!ResourceManager.AjaxSuccess)
                {
                    responseObject.Success = false;
                    responseObject.ErrorMessage = ResourceManager.AjaxErrorMessage;
                }
                else
                {
                    responseObject.Result = result;
                    responseObject.Script = ResourceManager.GetInstanceScript();
                }
            }
            catch (Exception e)
            {
                if (HandlerMethods.RethrowException(HttpContext.Current))
                {
                    throw e;
                }

                responseObject.Success = false;
                responseObject.ErrorMessage = IsDebugging ? e.ToString() : e.Message;
            }

            app.Context.Response.Clear();
            app.Context.Response.ClearContent();
            app.Context.Response.ClearHeaders();
            app.Context.Response.StatusCode = 200;
            app.Context.Response.ContentType = "application/json";
            app.Context.Response.Charset = "utf-8";
            app.Context.Response.Cache.SetNoServerCaching();
            app.Context.Response.Cache.SetMaxAge(TimeSpan.Zero);
            app.Context.Response.Write(responseObject.ToString());
            app.CompleteRequest();
        }

        private void AjaxRequestFilter(object sender, EventArgs e)
        {
            if (HttpContext.Current == null || HttpContext.Current.Response == null)
            {
                return;
            }

            HttpResponse response = HttpContext.Current.Response;

            if (RequestManager.IsAjaxRequest)
            {
                if (response.ContentType.IsNotEmpty() && response.ContentType.Equals("text/html", StringComparison.InvariantCultureIgnoreCase))
                {
                    response.Filter = new AjaxRequestFilter(response.Filter);
                }
            }
            else
            {
                object marker = HttpContext.Current.Items[ResourceManager.FilterMarker];

                if (marker != null && (bool)marker)
                {
                    if (response.ContentType.IsNotEmpty() && response.ContentType.Equals("text/html", StringComparison.InvariantCultureIgnoreCase))
                    {
                        response.Filter = new InitScriptFilter(response.Filter);
                    }
                }
            }
        }

        private void RedirectPreSendRequestHeaders(object sender, EventArgs e)
        {
            HttpApplication app = sender as HttpApplication;
            HttpContext context = app.Context;

            if (context.Response.StatusCode == 302)
            {
                if (RequestManager.HasXHeader(context.Request) || RequestManager.HasInputFieldMarker(context.Request))
                {
                    string url = context.Response.RedirectLocation;
                    context.Response.StatusCode = 200;
                    context.Response.SuppressContent = false;
                    context.Response.ContentType = "text/html";
                    context.Response.Charset = "utf-8";
                    context.Response.ClearContent();

                    DirectResponse responseObject = new DirectResponse(true);

                    responseObject.Script = "window.location=\"".ConcatWith(url, "\";");

                    TextWriter writer = context.Response.Output;
                    writer.Write(responseObject.ToString());
                }
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void Dispose() { }
    }
}