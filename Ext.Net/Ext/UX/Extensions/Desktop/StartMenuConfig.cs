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

using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public partial class StartMenuConfig : StateManagedItem, IIcon
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public StartMenuConfig() { }

        private Desktop desktop;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public StartMenuConfig(Desktop desktop)
        {
            this.desktop = desktop;
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Category("2. StartMenuConfig")]
        [DefaultValue(Icon.None)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual Icon Icon
        {
            get
            {
                object obj = this.ViewState["Icon"];
                return (obj == null) ? Icon.None : (Icon)obj;
            }
            set
            {
                this.ViewState["Icon"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Category("2. StartMenuConfig")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string IconCls
        {
            get
            {
                return (string)this.ViewState["IconCls"] ?? "";
            }
            set
            {
                this.ViewState["IconCls"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("iconCls")]
        [DefaultValue("")]
		[Description("")]
        protected string IconClsProxy
        {
            get
            {
                if (this.Icon != Icon.None)
                {
                    return "icon-{0}".FormatWith(this.Icon.ToString().ToLower());
                }

                return this.IconCls;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. StartMenuConfig")]
        [DefaultValue(300)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual int Width
        {
            get
            {
                object obj = this.ViewState["Width"];
                return obj == null ? 300 : (int)obj;
            }
            set
            {
                this.ViewState["Width"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. StartMenuConfig")]
        [DefaultValue(100)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual int ToolsWidth
        {
            get
            {
                object obj = this.ViewState["ToolsWidth"];
                return obj == null ? 100 : (int)obj;
            }
            set
            {
                this.ViewState["ToolsWidth"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. StartMenuConfig")]
        [DefaultValue(300)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual int Height
        {
            get
            {
                object obj = this.ViewState["Height"];
                return obj == null ? 300 : (int)obj;
            }
            set
            {
                this.ViewState["Height"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. StartMenuConfig")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string Title
        {
            get
            {
                return (string)this.ViewState["Title"] ?? "";
            }
            set
            {
                this.ViewState["Title"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. StartMenuConfig")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual bool Shadow
        {
            get
            {
                object obj = this.ViewState["Shadow"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["Shadow"] = value;
            }
        }

        ItemsCollection<Component> toolItems;

        /// <summary>
        /// Collection of Tool items
        /// </summary>
        [Meta]
        [ConfigOption("toolItems", typeof(ItemCollectionJsonConverter))]
        [Category("2. StartMenuConfig")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Collection of Tool items")]
        public virtual ItemsCollection<Component> ToolItems
        {
            get
            {
                if (this.toolItems == null)
                {
                    this.toolItems = new ItemsCollection<Component>();
                    this.toolItems.AfterItemAdd += this.AfterStartMenuItemAdd;
                    this.toolItems.AfterItemRemove += this.AfterStartMenuItemRemove;
                    this.toolItems.SingleItemMode = false;
                }

                return this.toolItems;
            }
        }

        ItemsCollection<Component> items;

        /// <summary>
        /// Items collection
        /// </summary>
        [Meta]
        [ConfigOption("items", typeof(ItemCollectionJsonConverter))]
        [Category("2. StartMenuConfig")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Items collection")]
        public virtual ItemsCollection<Component> Items
        {
            get
            {
                if (this.items == null)
                {
                    this.items = new ItemsCollection<Component>();
                    this.items.AfterItemAdd += this.AfterStartMenuItemAdd;
                    this.items.AfterItemRemove += this.AfterStartMenuItemRemove;
                    this.items.SingleItemMode = false;
                }

                return this.items;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void AfterStartMenuItemAdd(Component item)
        {
            if (!this.desktop.Controls.Contains(item))
            {
                this.desktop.Controls.Add(item);
            }

            if (!this.desktop.LazyItems.Contains(item))
            {
                this.desktop.LazyItems.Add(item);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void AfterStartMenuItemRemove(Component item)
        {
            if (this.desktop.Controls.Contains(item))
            {
                this.desktop.Controls.Remove(item);
            }

            if (this.desktop.LazyItems.Contains(item))
            {
                this.desktop.LazyItems.Remove(item);
            }
        }

        List<Icon> IIcon.Icons
        {
            get
            {
                List<Icon> icons = new List<Icon>(1);
                icons.Add(this.Icon);

                return icons;
            }
        }
    }
}