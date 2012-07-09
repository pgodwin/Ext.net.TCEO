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
    public partial class GroupTabPanelDirectEvents : ContainerDirectEvents
    {
        private ComponentDirectEvent beforeGroupChange;

        /// <summary>
        /// Fires before the active group changes. Handlers can return false to cancel the tab change.
        /// </summary>
        [ListenerArgument(0, "item", typeof(GroupTabPanel), "this")]
        [ListenerArgument(1, "newGroup", typeof(GroupTab), "The group being activated")]
        [ListenerArgument(2, "currentGroup", typeof(GroupTab), "The current active group")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforegroupchange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the active group changes. Handlers can return false to cancel the tab change.")]
        public virtual ComponentDirectEvent BeforeGroupChange
        {
            get
            {
                if (this.beforeGroupChange == null)
                {
                    this.beforeGroupChange = new ComponentDirectEvent();
                }

                return this.beforeGroupChange;
            }
        }

        private ComponentDirectEvent groupChange;

        /// <summary>
        /// Fires after the active group has changed.
        /// </summary>
        [ListenerArgument(0, "item", typeof(GroupTabPanel), "this")]
        [ListenerArgument(1, "group", typeof(GroupTab), "The new active group")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("groupchange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the active group has changed.")]
        public virtual ComponentDirectEvent GroupChange
        {
            get
            {
                if (this.groupChange == null)
                {
                    this.groupChange = new ComponentDirectEvent();
                }

                return this.groupChange;
            }
        }
    }
}