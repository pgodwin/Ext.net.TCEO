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
    public partial class ResizableListeners : ComponentListeners
    {
        private ComponentListener beforeResize;

        /// <summary>
        /// Fired before resize is allowed. Set enabled to false to cancel resize.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Resizable), "this")]
        [ListenerArgument(1, "e", typeof(object), "The mousedown event")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeresize", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired before resize is allowed. Set enabled to false to cancel resize.")]
        public virtual ComponentListener BeforeResize
        {
            get
            {
                if (this.beforeResize == null)
                {
                    this.beforeResize = new ComponentListener();
                }

                return this.beforeResize;
            }
        }

        private ComponentListener resize;

        /// <summary>
        /// Fired after a resize.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Resizable), "this")]
        [ListenerArgument(1, "width", typeof(int), "The new width")]
        [ListenerArgument(2, "height", typeof(int), "The new height")]
        [ListenerArgument(3, "e", typeof(object), "The mousedown event")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("resize", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired after a resize.")]
        public virtual ComponentListener Resize
        {
            get
            {
                if (this.resize == null)
                {
                    this.resize = new ComponentListener();
                }

                return this.resize;
            }
        }
    }
}