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
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// A menu item that wraps the choosen component.
    /// </summary>
    [Meta]
    [ToolboxItem(false)]
    [Description("A menu item that wraps the choosen component.")]
    public partial class ComponentMenuItem : MenuItemBase
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ComponentMenuItem()
        {
            this.AutoRender = false;
        }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                string xtype = "componentmenuitem";

                if (this.Component.Count > 0)
                {
                    if (this.Component[0] is ComboBox)
                    {
                        xtype = "combomenuitem";
                    }
                    else if (this.Component[0] is DateField)
                    {
                        xtype = "datefieldmenuitem";
                    }
                }

                return xtype;
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
                string className = "ComponentMenuItem";

                if (this.Component.Count > 0)
                {
                    if (this.Component[0] is ComboBox)
                    {
                        className = "ComboMenuItem";
                    }
                    else if (this.Component[0] is DateField)
                    {
                        className = "DateFieldMenuItem";
                    }
                }

                return "Ext.net." + className;
            }
        }

        ItemsCollection<Component> component;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Category("6. ComponentItem")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("component", typeof(ItemCollectionJsonConverter))]
        [Description("")]
        public virtual ItemsCollection<Component> Component
        {
            get
            {
                if (this.component == null)
                {
                    this.component = new ItemsCollection<Component>();
                    this.component.SingleItemMode = true;
                    this.component.AfterItemAdd += this.AfterItemAdd;
                    this.component.AfterItemRemove += this.AfterItemRemove;
                }

                return this.component;
            }
        }

        /// <summary>
        /// The element of component which will be used during menu item rendering
        /// </summary>
        [Meta]
        [Category("6. ComponentItem")]
        [DefaultValue(TargetElement.Auto)]
        [ConfigOption(JsonMode.ToLower)]
        [Description("The element of component which will be used during menu item rendering")]
        public virtual TargetElement ComponentElement
        {
            get
            {
                object obj = this.ViewState["ComponentElement"];
                return obj == null ? TargetElement.Auto : (TargetElement)obj;
            }
            set
            {
                this.ViewState["ComponentElement"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("target", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected string TargetProxy
        {
            get
            {
                if (this.Target.IsEmpty())
                {
                    return "";
                }

                return TokenUtils.ParseAndNormalize(this.Target, this);
            }
        }

        /// <summary>
        /// If true then element will be shiffted on horizontal, the icon place will be visible
        /// </summary>
        [Meta]
        [Category("6. ComponentItem")]
        [DefaultValue(true)]
        [ConfigOption]
        [Description("If true then element will be shiffted on horizontal, the icon place will be visible")]
        public virtual bool Shift
        {
            get
            {
                object obj = this.ViewState["Shift"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                this.ViewState["Shift"] = value;
            }
        }

        /// <summary>
        /// The target element which will be placed to toolbar.
        /// </summary>
        [Meta]
        [Category("6. ComponentItem")]
        [DefaultValue("")]
        [Description("The target element which will be placed to toolbar.")]
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

        /// <summary>
        /// True to hide the containing menu after this item is clicked (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. ComponentItem")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to hide the containing menu after this item is clicked (defaults to false).")]
        public override bool HideOnClick
        {
            get
            {
                object obj = this.ViewState["HideOnClick"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["HideOnClick"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Menu GetParentMenu(XControl control)
        {
            return (Menu)ReflectionUtils.GetTypeOfParent(this, typeof(Menu));
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public Menu ParentMenuNotLazy
        {
            get
            {
                Menu parent = this.GetParentMenu(this);

                while (parent != null && parent.IsLazy)
                {
                    parent = this.GetParentMenu(parent);
                }

                return parent;
            }
        }

        private ComboBox ComboBox
        {
            get
            {
                if (this.Component.Count > 0)
                {
                    return this.Component[0] as ComboBox;
                }

                return null;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public enum TargetElement
    {
        /// <summary>
        /// 
        /// </summary>
        Auto,

        /// <summary>
        /// 
        /// </summary>
        Element,

        /// <summary>
        /// 
        /// </summary>
        Wrap
    }
}