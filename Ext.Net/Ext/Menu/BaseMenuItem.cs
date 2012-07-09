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

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public abstract partial class BaseMenuItem : Component
    {
        /// <summary>
        /// The CSS class to use when the item becomes activated (defaults to \"x-menu-item-active\").
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. BaseItem")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The CSS class to use when the item becomes activated (defaults to \"x-menu-item-active\").")]
        public virtual string ActiveClass
        {
            get
            {
                return (string)this.ViewState["ActiveClass"] ?? "";
            }
            set
            {
                this.ViewState["ActiveClass"] = value;
            }
        }

        /// <summary>
        /// True if this item can be visually activated (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. BaseItem")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True if this item can be visually activated (defaults to false).")]
        public virtual bool CanActivate
        {
            get
            {
                object obj = this.ViewState["CanActivate"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["CanActivate"] = value;
            }
        }

        /// <summary>
        /// A function that will handle the click event of this menu item (defaults to undefined).
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("4. BaseItem")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A function that will handle the click event of this menu item (defaults to undefined).")]
        public virtual string Handler
        {
            get
            {
                return (string)this.ViewState["Handler"] ?? "";
            }
            set
            {
                this.ViewState["Handler"] = value;
            }
        }

        /// <summary>
        /// The scope (this reference) in which the handler function will be called.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("4. BaseItem")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The scope (this reference) in which the handler function will be called.")]
        public virtual string Scope
        {
            get
            {
                return (string)this.ViewState["Scope"] ?? "";
            }
            set
            {
                this.ViewState["Scope"] = value;
            }
        }

        /// <summary>
        /// Length of time in milliseconds to wait before hiding after a click (defaults to 100).
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("4. BaseItem")]
        [DefaultValue(100)]
        [NotifyParentProperty(true)]
        [Description("Length of time in milliseconds to wait before hiding after a click (defaults to 100).")]
        public virtual int HideDelay
        {
            get
            {
                object obj = this.ViewState["HideDelay"];
                return (obj == null) ? 100 : (int)obj;
            }
            set
            {
                this.ViewState["HideDelay"] = value;
            }
        }

        /// <summary>
        /// True to hide the containing menu after this item is clicked (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. BaseItem")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to hide the containing menu after this item is clicked (defaults to true).")]
        public virtual bool HideOnClick
        {
            get
            {
                object obj = this.ViewState["HideOnClick"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["HideOnClick"] = value;
            }
        }
    }
}