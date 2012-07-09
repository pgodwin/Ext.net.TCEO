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
    /// Simple ImageButton class
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:ImageButton runat=\"server\" />")]
    [DefaultEvent("Click")]
    [DefaultProperty("ImageUrl")]
    [ToolboxBitmap(typeof(ImageButton), "Build.ToolboxIcons.ImageButton.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("Simple ImageButton class")]
    public partial class ImageButton : Button
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ImageButton() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "netimagebutton";
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
                return "Ext.net.ImageButton";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Ignore)]
        [Category("6. ImageButton")]
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
        [Category("6. ImageButton")]
        [DefaultValue("")]
        [DirectEventUpdate(MethodName = "SetOverImageUrl")]
        [Description("")]
        public virtual string OverImageUrl
        {
            get
            {
                return (string)this.ViewState["OverImageUrl"] ?? "";
            }
            set
            {
                this.ViewState["OverImageUrl"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("overImageUrl")]
        [DefaultValue("")]
		[Description("")]
        protected virtual string OverImageUrlProxy
        {
            get
            {
                return this.ResolveUrlLink(this.OverImageUrl);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Ignore)]
        [Category("6. ImageButton")]
        [DefaultValue("")]
        [DirectEventUpdate(MethodName = "SetDisabledImageUrl")]
        [Description("")]
        public virtual string DisabledImageUrl
        {
            get
            {
                return (string)this.ViewState["DisabledImageUrl"] ?? "";
            }
            set
            {
                this.ViewState["DisabledImageUrl"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("disabledImageUrl")]
        [DefaultValue("")]
		[Description("")]
        protected virtual string DisabledImageUrlProxy
        {
            get
            {
                return this.ResolveUrlLink(this.DisabledImageUrl);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Ignore)]
        [Category("6. ImageButton")]
        [DefaultValue("")]
        [DirectEventUpdate(MethodName = "SetPressedImageUrl")]
        [Description("")]
        public virtual string PressedImageUrl
        {
            get
            {
                return (string)this.ViewState["PressedImageUrl"] ?? "";
            }
            set
            {
                this.ViewState["PressedImageUrl"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("pressedImageUrl")]
        [DefaultValue("")]
		[Description("")]
        protected virtual string PressedImageUrlProxy
        {
            get
            {
                return this.ResolveUrlLink(this.PressedImageUrl);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("altText")]
        [Category("6. ImageButton")]
        [DefaultValue("")]
        [DirectEventUpdate(MethodName = "SetAltText")]
        [Description("")]
        public virtual string AlternateText
        {
            get
            {
                return (string)this.ViewState["AlternateText"] ?? "";
            }
            set
            {
                this.ViewState["AlternateText"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("6. ImageButton")]
        [DefaultValue(ImageAlign.NotSet)]
        [DirectEventUpdate(MethodName = "SetAlign")]
        [Description("")]
        public ImageAlign Align
        {
            get
            {
                object obj = this.ViewState["Align"];
                return (obj == null) ? ImageAlign.NotSet : (ImageAlign)obj;
            }
            set
            {
                this.ViewState["Align"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
		[Description("")]
        public override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

		/// <summary>
		/// 
		/// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
		[Description("")]
        public override Icon Icon
        {
            get { return base.Icon; }
            set { base.Icon = value; }
        }

		/// <summary>
		/// 
		/// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
		[Description("")]
        public override string IconCls
        {
            get { return base.IconCls; }
            set { base.IconCls = value; }
        }

		/// <summary>
		/// 
		/// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
		[Description("")]
        public override ButtonType Type
        {
            get { return base.Type; }
            set { base.Type = value; }
        }


        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        [Description("")]
        protected virtual void SetImageUrl(string url)
        {
            this.Call("setImageUrl", this.ResolveUrlLink(url));
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void SetDisabledImageUrl(string url)
        {
            this.Call("setDisabledImageUrl", this.ResolveUrlLink(url));
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void SetOverImageUrl(string url)
        {
            this.Call("setOverImageUrl", this.ResolveUrlLink(url));
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void SetPressedImageUrl(string url)
        {
            this.Call("setPressedImageUrl", this.ResolveUrlLink(url));
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void SetAltText(string altText)
        {
            this.Call("setAltText", altText);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void SetAlign(ImageAlign align)
        {
            this.Call("setAlign", align.ToString().ToLower());
        }
    }
}