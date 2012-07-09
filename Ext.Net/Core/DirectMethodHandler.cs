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
using System.Web;

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class DirectMethodHandler : IHttpHandler
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public bool IsReusable
        {
            get { return true; }
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

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void ProcessRequest(HttpContext context)
        {
            DirectResponse responseObject = new DirectResponse(true);

            try
            {
                HandlerMethods handler = HandlerMethods.GetHandlerMethods(context, context.Request.FilePath);
                string methodName = HandlerMethods.GetMethodName(context);

                if (handler == null)
                {
                    throw new Exception("The Method '{0}' has not been defined.".FormatWith(context.Request.FilePath));
                }

                if (methodName.IsEmpty())
                {
                    throw new Exception("No methodName has been set in the configuration.");
                }

                DirectMethod directMethod = handler.GetStaticMethod(methodName);

                if (directMethod == null)
                {
                    throw new Exception("The static DirectMethod '{0}' has not been defined.".FormatWith(methodName));
                }

                responseObject.Result = directMethod.Invoke();
            }
            catch (Exception e)
            {
                if (HandlerMethods.RethrowException(context))
                {
                    throw e;
                }

                responseObject.Success = false;
                responseObject.ErrorMessage = IsDebugging ? e.ToString() : e.Message; 
            }

            context.Response.Cache.SetNoServerCaching();
            context.Response.Cache.SetMaxAge(TimeSpan.Zero);
            context.Response.Write(responseObject.ToString());
            context.Response.End();
        }
    }
}