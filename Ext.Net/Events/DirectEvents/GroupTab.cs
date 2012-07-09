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
    public partial class GroupTabDirectEvents : ContainerDirectEvents
    {
        private ComponentDirectEvent activate;

        /// <summary>
        /// Fires after tab is activated.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("activate", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after tab is activated.")]
        public virtual ComponentDirectEvent Activate
        {
            get
            {
                if (this.activate == null)
                {
                    this.activate = new ComponentDirectEvent();
                }

                return this.activate;
            }
        }

        private ComponentDirectEvent deactivate;

        /// <summary>
        /// Fires after tab is deactivated.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("deactivate", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after tab is deactivated.")]
        public virtual ComponentDirectEvent Deactivate
        {
            get
            {
                if (this.deactivate == null)
                {
                    this.deactivate = new ComponentDirectEvent();
                }

                return this.deactivate;
            }
        }

        private ComponentDirectEvent changeMainItem;

        /// <summary>
        /// Fires after main item is changed.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [ListenerArgument(1, "newItem", typeof(Component), "newItem")]
        [ListenerArgument(2, "oldItem", typeof(Component), "oldItem")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("changemainitem", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after main item is changed.")]
        public virtual ComponentDirectEvent ChangeMainItem
        {
            get
            {
                if (this.changeMainItem == null)
                {
                    this.changeMainItem = new ComponentDirectEvent();
                }

                return this.changeMainItem;
            }
        }

        private ComponentDirectEvent beforeTabChange;

        /// <summary>
        /// Fires before tab is changed.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [ListenerArgument(1, "newTab", typeof(Component), "newTab")]
        [ListenerArgument(2, "tab", typeof(Component), "tab")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforetabchange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before tab is changed.")]
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

        private ComponentDirectEvent tabChange;

        /// <summary>
        /// Fires after tab is changed.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [ListenerArgument(1, "tab", typeof(Component), "tab")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("tabchange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after tab is changed.")]
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
    }
}