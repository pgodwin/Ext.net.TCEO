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
using System.Web.UI;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class TabPanelDirectEvents : PanelDirectEvents
    {
        private ComponentDirectEvent beforeTabChange;

        /// <summary>
        /// Fires before the active tab changes. Handlers can return false to cancel the tab change.
        /// </summary>
        [ListenerArgument(0, "item", typeof(TabPanel), "this")]
        [ListenerArgument(1, "newTab", typeof(Panel), "The tab being activated")]
        [ListenerArgument(2, "currentTab", typeof(Panel), "The current active tab")]
        [ListenerArgument(3, "index", typeof(Panel), "The index of the tab being activated (available for TabStrip only)")]
        [ListenerArgument(4, "activeIndex", typeof(Panel), "The index of the current active tab (available for TabStrip only)")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforetabchange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the active tab changes. Handlers can return false to cancel the tab change.")]
        public virtual ComponentDirectEvent BeforeTabChange 
        {
            get
            {
                if (this.beforeTabChange == null)
                {
                    this.beforeTabChange = new ComponentDirectEvent();
                }

                return this.beforeTabChange;
            }
        }

        private ComponentDirectEvent contextMenu;

        /// <summary>
        /// Fires when the original browser contextmenu event originated from a tab element.
        /// </summary>
        [ListenerArgument(0, "item", typeof(TabPanel), "this")]
        [ListenerArgument(1, "tab", typeof(Panel), "The target tab")]
        [ListenerArgument(2, "e", typeof(object), "EventObject")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("contextmenu", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the original browser contextmenu event originated from a tab element.")]
        public virtual ComponentDirectEvent ContextMenu 
        {
            get
            {
                if (this.contextMenu == null)
                {
                    this.contextMenu = new ComponentDirectEvent();
                }

                return this.contextMenu;
            }
        }

        private ComponentDirectEvent tabChange;

        /// <summary>
        /// Fires after the active tab has changed.
        /// </summary>
        [ListenerArgument(0, "item", typeof(TabPanel), "this")]
        [ListenerArgument(1, "tab", typeof(Panel), "The new active tab")]
        [ListenerArgument(2, "index", typeof(Panel), "The index of the new active tab (available for TabStrip only)")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("tabchange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the active tab has changed.")]
        public virtual ComponentDirectEvent TabChange 
        {
            get
            {
                if (this.tabChange == null)
                {
                    this.tabChange = new ComponentDirectEvent();
                }

                return this.tabChange;
            }
        }

        private ComponentDirectEvent beforeTabClose;

        /// <summary>
        /// 
        /// </summary>
        [ListenerArgument(0, "item", typeof(PanelBase), "tabpanel")]
        [ListenerArgument(1, "tab", typeof(PanelBase), "tab")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforetabclose", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent BeforeTabClose
        {
            get
            {
                if (this.beforeTabClose == null)
                {
                    this.beforeTabClose = new ComponentDirectEvent();
                }

                return this.beforeTabClose;
            }
        }

        private ComponentDirectEvent beforeTabHide;

        /// <summary>
        /// 
        /// </summary>
        [ListenerArgument(0, "item", typeof(PanelBase), "tabpanel")]
        [ListenerArgument(1, "tab", typeof(PanelBase), "tab")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforetabhide", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent BeforeTabHide
        {
            get
            {
                if (this.beforeTabHide == null)
                {
                    this.beforeTabHide = new ComponentDirectEvent();
                }

                return this.beforeTabHide;
            }
        }

        private ComponentDirectEvent tabClose;

        /// <summary>
        /// 
        /// </summary>
        [ListenerArgument(0, "item", typeof(PanelBase), "tabpanel")]
        [ListenerArgument(1, "tab", typeof(PanelBase), "tab")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("tabclose", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent TabClose
        {
            get
            {
                if (this.tabClose == null)
                {
                    this.tabClose = new ComponentDirectEvent();
                }

                return this.tabClose;
            }
        }

        private ComponentDirectEvent beforeTabMenuShow;

        /// <summary>
        /// 
        /// </summary>
        [ListenerArgument(0, "item", typeof(TabPanel), "el")]
        [ListenerArgument(0, "tab", typeof(PanelBase), "tab")]
        [ListenerArgument(0, "menu", typeof(MenuBase), "menu")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforetabmenushow", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent BeforeTabMenuShow
        {
            get
            {
                if (this.beforeTabMenuShow == null)
                {
                    this.beforeTabMenuShow = new ComponentDirectEvent();
                }

                return this.beforeTabMenuShow;
            }
        }
    }
}