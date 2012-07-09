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
    public partial class RequestManager
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected internal static void EnsureDirectEvent()
        {
            if (!RequestManager.IsAjaxRequest)
            {
                throw new InvalidOperationException("This operation requires an AjaxRequest");
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static bool IsAjaxRequest
        {
            get
            {
                if (HttpContext.Current != null && HttpContext.Current.Request != null)
                {
                    return RequestManager.HasXHeader(HttpContext.Current.Request) || RequestManager.HasInputFieldMarker(HttpContext.Current.Request);
                }

                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public static bool IsMicrosoftAjaxRequest
        {
            get
            {
                if (HttpContext.Current != null && HttpContext.Current.Request != null)
                {
                    return RequestManager.HasXMicrosoftAjaxHeader(HttpContext.Current.Request);
                }

                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Description("")]
        public static bool HasInputFieldMarker(HttpRequest request)
        {
            if (request == null)
            {
                return false;    
            }

            try
            {
                string marker = request.Form["__ExtNetDirectEventMarker"];

                if (marker.IsNotEmpty())
                {
                    if (marker.ToLower().Contains("delta=true"))
                    {
                        return true;
                    }
                }
            }
            catch (Exception)
            {
            }
            
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Description("")]
        public static bool HasXHeader(HttpRequest request)
        {
            string[] values = request.Headers.GetValues("X-Ext.Net");

            if (values != null)
            {
                foreach (string value in values)
                {
                    if (value.ToLower().Contains("delta=true"))
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Description("")]
        public static bool HasXMicrosoftAjaxHeader(HttpRequest request)
        {
            string[] values = HttpContext.Current.Request.Headers.GetValues("X-MicrosoftAjax");

            if (values != null)
            {
                foreach (string value in values)
                {
                    if (value.ToLower().Contains("delta=true"))
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        /*  User Agent Detection (browser)
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public static bool IsOpera
        {
            get
            {
                return (HttpContext.Current != null && (HttpContext.Current.Request.UserAgent ?? "").ToLower().Contains("opera"));
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static bool IsChrome
        {
            get
            {
                return (HttpContext.Current != null && (HttpContext.Current.Request.UserAgent ?? "").ToLower().Contains("chrome"));
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static bool IsWebKit
        {
            get
            {
                return (HttpContext.Current != null && (HttpContext.Current.Request.UserAgent ?? "").ToLower().Contains("webkit"));
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static bool IsSafari
        {
            get
            {
                return (HttpContext.Current != null && !RequestManager.IsChrome && (HttpContext.Current.Request.UserAgent ?? "").ToLower().Contains("safari"));
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static bool IsSafari3
        {
            get
            {
                return (HttpContext.Current != null && RequestManager.IsSafari && (HttpContext.Current.Request.UserAgent ?? "").ToLower().Contains("version/3"));
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static bool IsSafari4
        {
            get
            {
                return (HttpContext.Current != null && RequestManager.IsSafari && (HttpContext.Current.Request.UserAgent ?? "").ToLower().Contains("version/4"));
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static bool IsIE
        {
            get
            {
                return (HttpContext.Current != null && !RequestManager.IsOpera && (HttpContext.Current.Request.UserAgent ?? "").ToLower().Contains("msie"));
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static bool IsIE6
        {
            get
            {

                return (HttpContext.Current != null && RequestManager.IsIE && HttpContext.Current.Request.Browser.MajorVersion <= 6);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static bool IsIE7
        {
            get
            {
                return (HttpContext.Current != null && RequestManager.IsIE && (HttpContext.Current.Request.UserAgent ?? "").ToLower().Contains("msie 7"));
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static bool IsIE8
        {
            get
            {
                return (HttpContext.Current != null && RequestManager.IsIE && (HttpContext.Current.Request.UserAgent ?? "").ToLower().Contains("msie 8"));
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static bool IsGecko
        {
            get
            {
                return (HttpContext.Current != null && !RequestManager.IsWebKit && (HttpContext.Current.Request.UserAgent ?? "").ToLower().Contains("gecko"));
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static bool IsGecko3
        {
            get
            {
                return (HttpContext.Current != null && RequestManager.IsGecko && (HttpContext.Current.Request.UserAgent ?? "").ToLower().Contains("rv:1.9"));
            }
        }


        /*  User Agent Detection (operating system)
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public static bool IsWindows
        {
            get
            {
                string ua = (HttpContext.Current.Request.UserAgent ?? "").ToLower();
                return (HttpContext.Current != null && (ua.Contains("windows") || ua.Contains("win32")));
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static bool IsMac
        {
            get
            {
                string ua = (HttpContext.Current.Request.UserAgent ?? "").ToLower();
                return (HttpContext.Current != null && (ua.Contains("macintosh") || ua.Contains("mac os x")));
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static bool IsLinux
        {
            get
            {
                string ua = (HttpContext.Current.Request.UserAgent ?? "").ToLower();
                return (HttpContext.Current != null && ua.Contains("linux"));
            }
        }
    }
}