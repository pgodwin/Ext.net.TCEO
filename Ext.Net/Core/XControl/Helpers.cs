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
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;

using Ext.Net.Utilities;
using Newtonsoft.Json;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
    public partial class XControl : IScriptable
    {
        /*  Design and Debug
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual bool IsDebugging
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


        /*  Helpers
            -----------------------------------------------------------------------------------------------*/

        private static ClientScriptItem extNetDataItem;
        
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected static ClientScriptItem ExtNetDataItem
        {
            get
            {
                if (extNetDataItem == null)
                {
                    extNetDataItem = new ClientScriptItem(
                        "Ext.Net.Build.Ext.Net.extnet.extnet-data.js",
                        "Ext.Net.Build.Ext.Net.extnet.extnet-data-debug.js",
                        "/extnet/extnet-data.js",
                        "/extnet/extnet-data-debug.js");
                }

                return extNetDataItem;
            }
        }

        private XmlNode submitConfig;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected internal XmlNode SubmitConfig
        {
            get
            {
                if (this.submitConfig == null)
                {
                    string submitDirectEventConfig = this.Page.Request["submitDirectEventConfig"];

                    if (submitDirectEventConfig.IsNotEmpty())
                    {
                        this.submitConfig = JsonConvert.DeserializeXmlNode(submitDirectEventConfig);
                    }
                }

                return this.submitConfig;
            }
        }

        private readonly Dictionary<string, object> callbackValues = new Dictionary<string, object>();

        internal Dictionary<string, object> CallbackValues
        {
            get { return callbackValues; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool IsAjaxRequestInitiator
        {
            get
            {
                if (!RequestManager.IsAjaxRequest || this.IsDynamic)
                {
                    return false;
                }

                if (this.Page == null)
                {
                    return false;
                }

                string ea = "";

                try
                {
                    ea = this.Page.Request["__EVENTARGUMENT"];
                }
                catch (Exception)
                {
                    try
                    {
                        ea = HttpContext.Current.Request["__EVENTARGUMENT"];
                    }
                    catch (Exception)
                    {
                    }
                }

                if (ea.IsEmpty())
                {
                    XmlNode cfg = this.SubmitConfig;
                    if (cfg == null)
                    {
                        return false;
                    }

                    XmlNode eventArgumentNode = this.SubmitConfig.SelectSingleNode("config/__EVENTARGUMENT");

                    if (eventArgumentNode == null)
                    {
                        return false;
                    }

                    ea = eventArgumentNode.InnerText;

                    if (string.IsNullOrEmpty(ea))
                    {
                        return false;
                    }
                }

                string[] args = ea.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);

                if (args.Length != 3)
                {
                    return false;
                }

                string controlID = args[0];

                return this.ClientID == controlID;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual string ParseTarget(string target)
        {
            string parsedTarget = TokenUtils.ParseTokens(target, this);

            if (TokenUtils.IsRawToken(parsedTarget))
            {
                return TokenUtils.ReplaceRawToken(parsedTarget);
            }

            return "\"".ConcatWith(parsedTarget, "\"");
        }


        /*  Helper Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual bool HasLayout()
        {
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual bool HasContent()
        {
            if (this is IContent)
            {
                return ((IContent)this).ContentEl.IsNotEmpty();
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected Unit UnitPixelTypeCheck(object obj, Unit defaultValue, string propertyName)
        {
            Unit temp = (obj == null) ? defaultValue : (Unit)obj;

            if (temp.Type != UnitType.Pixel)
            {
                throw new InvalidCastException("The Unit Type for the {0} {1} property must be of Type 'Pixel'. Example: Unit.Pixel(150) or '150px'.".FormatWith(this.ID, propertyName));
            }

            return temp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public virtual string ResolveUrlLink(string url)
        {
            return this.ResolveClientUrl(url);
        }


        /*  Helper Properties
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Does this object currently represent it's default state.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Does this object currently represent it's default state.")]
        public virtual bool IsDefault
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool IsLazy
        {
            get
            {
                if (this is Observable && this.Parent is ILazyItems)
                {
                    return (this.Parent as ILazyItems).LazyItems.Contains((Observable)this);
                }

                return false;
            }
        }

        private bool isDynamicLazy;

        internal bool IsDynamicLazy
        {
            get
            {
                return this.isDynamicLazy;
            }
            set
            {
                this.isDynamicLazy = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public virtual bool IsLayout
        {
            get
            {
                return this is Layout;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public virtual string ContainerID
        {
            get
            {
                return this.ClientID.ConcatWith("_Container");
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual string ContainerStyle
        {
            get
            {
                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool IsInHead
        {
            get
            {
                return ReflectionUtils.IsInTypeOf(this, typeof(System.Web.UI.HtmlControls.HtmlHead));
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public virtual bool IsInLayout
        {
            get
            {
                return this.Parent is Layout;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public virtual bool IsMVC
        {
            get
            {
                return ReflectionUtils.IsTypeOf(this.Page, "System.Web.Mvc.ViewPage");
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public virtual bool IsInForm
        {
            get
            {
                return (this.ParentForm != null);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public virtual System.Web.UI.HtmlControls.HtmlForm ParentForm
        {
            get
            {
                return (HtmlForm)ReflectionUtils.GetTypeOfParent(this, typeof(System.Web.UI.HtmlControls.HtmlForm));
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public virtual Component ParentComponent
        {
            get
            {
                return (Component)ReflectionUtils.GetTypeOfParent(this, typeof(Component));
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public virtual Component ParentComponentNotLayout
        {
            get
            {
                Component parent = this.ParentComponent;

                while (parent != null && parent is Layout)
                {
                    parent = parent.ParentComponent;
                }

                return parent;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public virtual XControl ParentWebControl
        {
            get
            {
                return (XControl)ReflectionUtils.GetTypeOfParent(this, typeof(XControl));
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public virtual Component ParentComponentNotLazy
        {
            get
            {
                Component parent = this.ParentComponent;

                if (this.IsLazy)
                {
                    while (parent != null && parent.IsLazy)
                    {
                        parent = parent.ParentComponent;
                    }
                }

                return parent;
            }
        }

        internal virtual bool IsDeferredRender
        {
            get
            {
                return false;
            }
        }

        internal virtual bool IsParentDeferredRender
        {
            get
            {
                for (Control parent = this.Parent; parent != null; parent = parent.Parent)
                {
                    if (parent is XControl)
                    {
                        if (((XControl)parent).IsDeferredRender)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
        }
    }
}