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

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Tells the layout how an item should be anchored to the container. items added to an AnchorLayout accept an anchoring-specific config property of anchor which is a string containing two values: the horizontal anchor value and the vertical anchor value (for example, '100% 50%').
    /// </summary>
    [Meta]
    [Description("Tells the layout how an item should be anchored to the container. items added to an AnchorLayout accept an anchoring-specific config property of anchor which is a string containing two values: the horizontal anchor value and the vertical anchor value (for example, '100% 50%').")]
    public partial class Anchor : LayoutItem
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Anchor() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Anchor(Component component) 
        {
            this.Items.Add(component);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Anchor(Component component, string horizontal, string vertical)
        {
            this.Items.Add(component);
            this.Horizontal = horizontal;
            this.Vertical = vertical;
        }

        /// <summary>
        /// True if component should be rendered as a Form Field with a Field Label and Label separator (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. AnchorLayout")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True if component should be rendered as a Form Field with a Field Label and Label separator (defaults to false).")]
        public virtual bool IsFormField
        {
            get
            {
                object obj = this.ViewState["IsFormField"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["IsFormField"] = value;
            }
        }

        /// <summary>
        /// Horizontal Anchor value. Can be a Percentage (1-100%), an Offset (Any positive or negative integer value), a Sides value (Valid values are 'right' (or 'r') and 'bottom' (or 'b').).
        /// </summary>
        [Meta]
        [Category("6. AnchorLayout")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Horizontal Anchor value. Can be a Percentage (1-100%), an Offset (Any positive or negative integer value), a Sides value (Valid values are 'right' (or 'r') and 'bottom' (or 'b').).")]
        public virtual string Horizontal
        {
            get
            {
                string temp = (string)this.ViewState["Horizontal"] ?? "";

                if (this.Vertical.IsNotEmpty() && temp.IsEmpty())
                {
                    return "100%";
                }

                return temp;
            }
            set
            {
                this.ViewState["Horizontal"] = value;
            }
        }

        /// <summary>
        /// Vertical Anchor value. Can be a Percentage (1-100%), an Offset (Any positive or negative integer value), a Sides value (Valid values are 'right' (or 'r') and 'bottom' (or 'b').).
        /// </summary>
        [Meta]
        [Category("6. AnchorLayout")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Vertical Anchor value. Can be a Percentage (1-100%), an Offset (Any positive or negative integer value), a Sides value (Valid values are 'right' (or 'r') and 'bottom' (or 'b').).")]
        public virtual string Vertical
        {
            get
            {
                return (string)this.ViewState["Vertical"] ?? "";
            }
            set
            {
                this.ViewState["Vertical"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("anchor", JsonMode.Value)]
        [DefaultValue("")]
        [Browsable(false)]
        [Description("")]
        protected virtual string AnchorProxy
        {
            get
            {
                if (this.Vertical.IsEmpty() && this.Horizontal.IsNotEmpty())
                {
                    return this.Horizontal;
                }
                else if (this.Horizontal.IsNotEmpty() && this.Vertical.IsNotEmpty())
                {
                    return this.Horizontal.ConcatWith(" ", this.Vertical);
                }

                return "";
            }
        }
    }
}