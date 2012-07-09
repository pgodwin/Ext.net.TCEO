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
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    /// <summary>
    /// This is a layout specifically designed for creating forms.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:FormLayout runat=\"server\"><Anchors><{0}:Anchor><{0}:TextField runat=\"server\" FieldLabel=\"Field1\" /></{0}:Anchor></Anchors></{0}:FormLayout>")]
    [Designer(typeof(EmptyDesigner))]
    [ToolboxBitmap(typeof(FormLayout), "Build.ToolboxIcons.Layout.bmp")]
    [Description("This is a layout specifically designed for creating forms.")]
    public partial class FormLayout : AnchorLayout
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public FormLayout() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("4. Layout")]
		[Description("")]
        public override string LayoutType
        {
            get
            {
                return "form";
            }
        }

        /// <summary>
        /// True to show/hide the field label when the field is hidden. Defaults to true. 
        /// </summary>
        [ConfigOption]
        [DefaultValue(true)]
        [Description("True to show/hide the field label when the field is hidden. Defaults to true.")]
        public virtual bool TrackLabels
        {
            get
            {
                object obj = this.ViewState["TrackLabels"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["TrackLabels"] = value;
            }
        }
        
        /// <summary>
        /// A CSS style specification string to add to each field element in this layout (defaults to '').
        /// </summary>
        [NotifyParentProperty(true)]
        [Description("A CSS style specification string to add to each field element in this layout (defaults to '').")]
        public virtual string ElementStyle
        {
            get
            {
                return (string)this.ViewState["ElementStyle"] ?? "";
            }
            set
            {
                this.ViewState["ElementStyle"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.Object)]
        [Browsable(false)]
        [DefaultValue(null)]
        [Description("")]
        protected internal override LayoutConfig LayoutConfig
        {
            get
            {
                return new FormLayoutConfig(
                    this.TrackLabels,
                    this.ElementStyle, 
                    this.LabelSeparator, 
                    this.LabelStyle, 
                    this.RenderHidden,
                    this.ExtraCls);
            }
        }

        /// <summary>
        /// True to hide field labels by default (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. FormLayout")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to hide field labels by default (defaults to false).")]
        public override bool HideLabels
        {
            get
            {
                object obj = this.ViewState["HideLabels"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["HideLabels"] = value;
            }
        }

        /// <summary>
        /// A CSS class to add to the div wrapper that contains each field label and field element (the default class is 'x-form-item' and itemCls will be added to that)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. FormLayout")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A CSS class to add to the div wrapper that contains each field label and field element (the default class is 'x-form-item' and itemCls will be added to that)")]
        public override string ItemCls
        {
            get
            {
                return (string)this.ViewState["ItemCls"] ?? "";
            }
            set
            {
                this.ViewState["ItemCls"] = value;
            }
        }
    }
}