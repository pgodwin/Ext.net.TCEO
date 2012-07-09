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
    public partial class WindowListeners : PanelListeners
    {
        private ComponentListener maximize;

        /// <summary>
        /// Fires after the window has been maximized.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Window), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("maximize", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the window has been maximized.")]
        public virtual ComponentListener Maximize
        {
            get
            {
                if (this.maximize == null)
                {
                    this.maximize = new ComponentListener();
                }

                return this.maximize;
            }
        }

        private ComponentListener minimize;

        /// <summary>
        /// Fires after the window has been minimized.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Window), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("minimize", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the window has been minimized.")]
        public virtual ComponentListener Minimize
        {
            get
            {
                if (this.minimize == null)
                {
                    this.minimize = new ComponentListener();
                }

                return this.minimize;
            }
        }

        private ComponentListener restore;

        /// <summary>
        /// Fires after the window has been restored to its original size after being maximized.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Window), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("restore", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the window has been restored to its original size after being maximized.")]
        public virtual ComponentListener Restore
        {
            get
            {
                if (this.restore == null)
                {
                    this.restore = new ComponentListener();
                }

                return this.restore;
            }
        }
    }
}