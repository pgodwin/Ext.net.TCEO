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
using System.Web;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Cookies : ScriptClass
    {
        /// <summary>
        /// 
        /// </summary>
        public override string InstanceOf
        {
            get
            {
                return "Ext.util.Cookies";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToScript()
        {
            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="args"></param>
        protected virtual void CallCookies(string name, params object[] args)
        {
            this.Call(name, args);
        }

        /// <summary>
        /// Removes a cookie with the provided name from the browser if found by setting its expiration date to sometime in the past.
        /// </summary>
        /// <param name="name">The name of the cookie to remove</param>
        public static void Clear(string name)
        {
            new Cookies().Call("clear", name);
        }

        /// <summary>
        /// Retrieves cookie value that are accessible by the current page. If a cookie does not exist, get() returns null.
        /// </summary>
        /// <param name="name">The name of the cookie to get</param>
        /// <returns>Returns the cookie value for the specified name; null if the cookie name does not exist.</returns>
        public static string GetValue(string name)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[name];
            if (cookie != null)
            {
                return cookie.Value;
            }

            return null;
        }

        /// <summary>
        ///  Retrieves cookie that are accessible by the current page. If a cookie does not exist, get() returns null.
        /// </summary>
        /// <param name="name">The name of the cookie to get</param>
        /// <returns>Returns the cookie for the specified name; null if the cookie name does not exist.</returns>
        public static HttpCookie GetCookie(string name)
        {
            return HttpContext.Current.Request.Cookies[name];
        }

        /// <summary>
        /// Create a cookie with the specified name and value. Additional settings for the cookie may be optionally specified (for example: expiration, access restriction, SSL).
        /// </summary>
        /// <param name="name">The name of the cookie to set.</param>
        /// <param name="value">The value to set for the cookie.</param>
        /// <param name="expires">Specify an expiration date the cookie is to persist until. Note that the specified Date object will be converted to Greenwich Mean Time (GMT).</param>
        /// <param name="path">Setting a path on the cookie restricts access to pages that match that path. Defaults to all pages ('/').</param>
        /// <param name="domain">Setting a domain restricts access to pages on a given domain (typically used to allow cookie access across subdomains). For example, "ext.net" will create a cookie that can be accessed from any subdomain of ext.net, including www.ext.net, support.ext.net, etc.</param>
        /// <param name="secure">Specify true to indicate that the cookie should only be accessible via SSL on a page using the HTTPS protocol. Defaults to false. Note that this will only work if the page calling this code uses the HTTPS protocol, otherwise the cookie will be created with default options.</param>
        public static void Set(string name, object value, DateTime expires, string path, string domain, bool secure)
        {
            new Cookies().Call("set", name, value, new JRawValue(Ext.Net.Utilities.DateTimeUtils.DateNetToJs(expires)), path, domain, secure);
        }
    }
}
