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

using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    /// <summary>
    /// Basic hyperlink field.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:HyperLink runat=\"server\" Text=\"HyperLink\" />")]
    [ToolboxBitmap(typeof(HyperLink), "Build.ToolboxIcons.HyperLink.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("Basic hyperlink field.")]
    public partial class HyperLink : Label
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public HyperLink() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "nethyperlink";
            }
        }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.net.HyperLink";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Ignore)]
        [Category("6. Hyperlink")]
        [DefaultValue("")]
        [DirectEventUpdate(MethodName = "SetImageUrl")]
        [Description("")]
        public virtual string ImageUrl
        {
            get
            {
                return (string)this.ViewState["ImageUrl"] ?? "";
            }
            set
            {
                this.ViewState["ImageUrl"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("imageUrl")]
        [DefaultValue("")]
		[Description("")]
        protected virtual string ImageUrlProxy
        {
            get
            {
                return this.ResolveUrlLink(this.ImageUrl);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Ignore)]
        [Category("6. Hyperlink")]
        [DefaultValue("")]
        [DirectEventUpdate(MethodName = "SetNavigateUrl")]
        [Description("")]
        public virtual string NavigateUrl
        {
            get
            {
                return (string)this.ViewState["NavigateUrl"] ?? "";
            }
            set
            {
                this.ViewState["NavigateUrl"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("url")]
        [DefaultValue("")]
		[Description("")]
        protected virtual string NavigateUrlProxy
        {
            get 
            {
                return this.ResolveUrlLink(this.NavigateUrl);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [TypeConverter(typeof(TargetConverter))]
        [Category("6. Hyperlink")]
        [DefaultValue("")]
        [DirectEventUpdate(MethodName = "SetTarget")]
        [Description("")]
        public virtual string Target
        {
            get
            {
                return (string)this.ViewState["Target"] ?? "";
            }
            set
            {
                this.ViewState["Target"] = value;
            }
        }


        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        [Description("")]
        protected virtual void SetNavigateUrl(string url)
        {
            this.Call("setUrl", this.ResolveUrlLink(url));
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void SetImageUrl(string url)
        {
            this.Call("setImageUrl", this.ResolveUrlLink(url));
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void SetTarget(string target)
        {
            this.Call("setTarget", target);
        }
    }
}