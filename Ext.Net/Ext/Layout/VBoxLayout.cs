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

namespace Ext.Net
{
    /// <summary>
    /// A layout that arranges items vertically
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:VBoxLayout runat=\"server\"></{0}:VBoxLayout>")]
    [Designer(typeof(EmptyDesigner))]
    [ToolboxBitmap(typeof(VBoxLayout), "Build.ToolboxIcons.Layout.bmp")]
    [Description("A layout that arranges items vertically")]
    public partial class VBoxLayout : BoxLayout
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public VBoxLayout() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("4. Layout")]
		[Description("")]
        public override string LayoutType
        {
            get
            {
                return "vbox";
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption(JsonMode.Object)]
        [Browsable(false)]
		[Description("")]
        protected internal override LayoutConfig LayoutConfig
        {
            get
            {
                return new VBoxLayoutConfig(
                    this.Align,
                    this.DefaultMargins,
                    this.Padding,
                    this.Pack,
                    this.ScrollOffset,
                    this.RenderHidden,
                    this.ExtraCls);
            }
        }
        
        /// <summary>
        /// Controls how the child items of the container are aligned.
        /// </summary>
        [Meta]
        [Category("7. VBoxLayout")]
        [DefaultValue(VBoxAlign.Left)]
        [Description("Controls how the child items of the container are aligned.")]
        public virtual VBoxAlign Align
        {
            get
            {
                object obj = this.ViewState["Align"];
                return (obj == null) ? VBoxAlign.Left : (VBoxAlign)obj;
            }
            set
            {
                this.ViewState["Align"] = value;
            }
        }
    }
}