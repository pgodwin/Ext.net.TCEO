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
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public class UserControlRenderer
    {        
        private UserControlRenderer() 
        { 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userControlPath"></param>
        /// <param name="controlIdToRender"></param>
        /// <param name="mode"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public virtual string Build(string userControlPath, string controlIdToRender, RenderMode mode, string element)
        {
            return this.Build(userControlPath, controlIdToRender, mode, element, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userControlPath"></param>
        /// <param name="mode"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public virtual string Build(string userControlPath, RenderMode mode, string element)
        {
            return this.Build(userControlPath, null, mode, element, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userControlPath"></param>
        /// <param name="mode"></param>
        /// <param name="element"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public virtual string Build(string userControlPath, RenderMode mode, string element, int? index)
        {
            return this.Build(userControlPath, null, mode, element, index);
        }        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userControlPath"></param>
        /// <param name="controlIdToRender"></param>
        /// <param name="mode"></param>
        /// <param name="element"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public virtual string Build(string userControlPath, string controlIdToRender, RenderMode mode, string element, int? index)
        {
            string id = "ID_" + Guid.NewGuid().ToString().Replace("-", "");
            UserControl uc = UserControlRenderer.LoadControl(userControlPath, id);
            Page pageHolder = uc.Page;

            XControl controlToRender = null;
            if (controlIdToRender.IsEmpty())
            {
                Container ct = new Container { ID = id, IDMode = IDMode.Explicit };
                pageHolder.Controls.Add(ct);
                ct.ContentControls.Add(uc);
                controlToRender = ct;
            }
            else
            {
                pageHolder.Controls.Add(uc);
                XControl c = Ext.Net.Utilities.ControlUtils.FindControl<XControl>(pageHolder, controlIdToRender);
                if (c == null)
                {
                    throw new Exception("Cannot find the control with ID=" + controlIdToRender);
                }

                controlToRender = c;

                if (controlToRender.IDMode == IDMode.Inherit)
                {
                    controlToRender.IDMode = IDMode.Explicit;
                }
            }

            return index.HasValue ? controlToRender.ToScript(mode, element, index.Value, true) : controlToRender.ToScript(mode, element, true);
        }

        public static UserControl LoadControl(string userControlPath)
        {
            return UserControlRenderer.LoadControl<SelfRenderingPage>(userControlPath, null);
        }

        public static UserControl LoadControl<Page>(string userControlPath) where Page : System.Web.UI.Page, ISelfRenderingPage, new()
        {
            return UserControlRenderer.LoadControl<Page>(userControlPath, null);
        }

        public static UserControl LoadControl(string userControlPath, string id)
        {
            return UserControlRenderer.LoadControl<SelfRenderingPage>(userControlPath, null);
        }

        public static UserControl LoadControl<Page>(string userControlPath, string id) where Page : System.Web.UI.Page, ISelfRenderingPage, new()
        {
            System.Web.UI.Page pageHolder = (System.Web.UI.Page)new Page();

            ResourceManager rm = new ResourceManager();
            rm.RenderScripts = ResourceLocationType.None;
            rm.RenderStyles = ResourceLocationType.None;
            rm.IDMode = IDMode.Explicit;
            pageHolder.Controls.Add(rm);

            id = id ?? "ID_" + Guid.NewGuid().ToString().Replace("-", "");
            System.Web.UI.Control uc = pageHolder.LoadControl(userControlPath);
            uc.ID = id + "_UC";

            return (UserControl)uc;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userControlPath"></param>
        /// <param name="controlIdToRender"></param>
        /// <param name="mode"></param>
        /// <param name="element"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string ToScript(string userControlPath, string controlIdToRender, RenderMode mode, string element, int? index)
        {
            return new UserControlRenderer().Build(userControlPath, controlIdToRender, mode, element, index);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userControlPath"></param>
        /// <param name="controlIdToRender"></param>
        /// <param name="element"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string ToScript(string userControlPath, string controlIdToRender, string element, int? index)
        {
            return new UserControlRenderer().Build(userControlPath, controlIdToRender, RenderMode.RenderTo, element, index);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userControlPath"></param>
        /// <param name="mode"></param>
        /// <param name="element"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string ToScript(string userControlPath, RenderMode mode, string element, int? index)
        {
            return new UserControlRenderer().Build(userControlPath, mode, element, index);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userControlPath"></param>
        /// <param name="element"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string ToScript(string userControlPath, string element, int? index)
        {
            return new UserControlRenderer().Build(userControlPath, RenderMode.RenderTo, element, index);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userControlPath"></param>
        /// <param name="mode"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string ToScript(string userControlPath, RenderMode mode, string element)
        {
            return new UserControlRenderer().Build(userControlPath, mode, element);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userControlPath"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string ToScript(string userControlPath, string element)
        {
            return new UserControlRenderer().Build(userControlPath, RenderMode.RenderTo, element);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userControlPath"></param>
        /// <param name="controlIdToRender"></param>
        /// <param name="mode"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string ToScript(string userControlPath, string controlIdToRender, RenderMode mode, string element)
        {
            return new UserControlRenderer().Build(userControlPath, controlIdToRender, mode, element);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userControlPath"></param>
        /// <param name="controlIdToRender"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string ToScript(string userControlPath, string controlIdToRender, string element)
        {
            return new UserControlRenderer().Build(userControlPath, controlIdToRender, RenderMode.RenderTo, element);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userControlPath"></param>
        /// <param name="controlIdToRender"></param>
        /// <param name="mode"></param>
        /// <param name="element"></param>
        /// <param name="index"></param>
        public static void Render(string userControlPath, string controlIdToRender, RenderMode mode, string element, int? index)
        {
            UserControlRenderer.Render(UserControlRenderer.ToScript(userControlPath, controlIdToRender, mode, element, index));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userControlPath"></param>
        /// <param name="controlIdToRender"></param>
        /// <param name="element"></param>
        /// <param name="index"></param>
        public static void Render(string userControlPath, string controlIdToRender, string element, int? index)
        {
            UserControlRenderer.Render(UserControlRenderer.ToScript(userControlPath, controlIdToRender, element, index));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userControlPath"></param>
        /// <param name="mode"></param>
        /// <param name="element"></param>
        /// <param name="index"></param>
        public static void Render(string userControlPath, RenderMode mode, string element, int? index)
        {
            UserControlRenderer.Render(UserControlRenderer.ToScript(userControlPath, mode, element, index));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userControlPath"></param>
        /// <param name="element"></param>
        /// <param name="index"></param>
        public static void Render(string userControlPath, string element, int? index)
        {
            UserControlRenderer.Render(UserControlRenderer.ToScript(userControlPath, element, index));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userControlPath"></param>
        /// <param name="mode"></param>
        /// <param name="element"></param>
        public static void Render(string userControlPath, RenderMode mode, string element)
        {
            UserControlRenderer.Render(UserControlRenderer.ToScript(userControlPath, mode, element));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userControlPath"></param>
        /// <param name="element"></param>
        public static void Render(string userControlPath, string element)
        {
            UserControlRenderer.Render(UserControlRenderer.ToScript(userControlPath, element));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userControlPath"></param>
        /// <param name="controlIdToRender"></param>
        /// <param name="mode"></param>
        /// <param name="element"></param>
        public static void Render(string userControlPath, string controlIdToRender, RenderMode mode, string element)
        {
            UserControlRenderer.Render(UserControlRenderer.ToScript(userControlPath, controlIdToRender, mode, element));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userControlPath"></param>
        /// <param name="controlIdToRender"></param>
        /// <param name="element"></param>
        public static void Render(string userControlPath, string controlIdToRender, string element)
        {
            UserControlRenderer.Render(UserControlRenderer.ToScript(userControlPath, controlIdToRender, element));
        }

        private static void Render(string script)
        {
            ResourceManager rm = ResourceManager.GetInstance(HttpContext.Current);
            if (HttpContext.Current.CurrentHandler is Page && rm != null)
            {
                rm.AddScript(script);
            }
            else
            {
                new DirectResponse(script).Return();
            }
        }
    }
}