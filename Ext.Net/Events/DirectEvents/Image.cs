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
    public partial class ImageDirectEvents : BoxComponentDirectEvents
    {
        private ComponentDirectEvent complete;

        /// <summary>
        /// Fires after the image is loaded.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("complete", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the image is loaded.")]
        public virtual ComponentDirectEvent Complete
        {
            get
            {
                if (this.complete == null)
                {
                    this.complete = new ComponentDirectEvent();
                }

                return this.complete;
            }
        }

        private ComponentDirectEvent beforeLoad;

        /// <summary>
        /// Fires before the image is loaded.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeload", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the image is loaded.")]
        public virtual ComponentDirectEvent BeforeLoad
        {
            get
            {
                if (this.beforeLoad == null)
                {
                    this.beforeLoad = new ComponentDirectEvent();
                }

                return this.beforeLoad;
            }
        }

        private ComponentDirectEvent resizerResize;

        /// <summary>
        /// Fired after a resizer resize.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [ListenerArgument(1, "width", typeof(int), "width")]
        [ListenerArgument(2, "height", typeof(int), "height")]
        [ListenerArgument(3, "e", typeof(object), "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("resizerresize", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired after a resizer resize.")]
        public virtual ComponentDirectEvent ResizerResize
        {
            get
            {
                if (this.resizerResize == null)
                {
                    this.resizerResize = new ComponentDirectEvent();
                }

                return this.resizerResize;
            }
        }

        private ComponentDirectEvent resizerBeforeResize;

        /// <summary>
        /// Fired before resize is allowed. Set enabled to false to cancel resize.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [ListenerArgument(1, "e", typeof(object), "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("resizerbeforeresize", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired before resize is allowed. Set resizer.enabled to false to cancel resize.")]
        public virtual ComponentDirectEvent ResizerBeforeResize
        {
            get
            {
                if (this.resizerBeforeResize == null)
                {
                    this.resizerBeforeResize = new ComponentDirectEvent();
                }

                return this.resizerBeforeResize;
            }
        }

        private ComponentDirectEvent pan;

        /// <summary>
        /// Fired after a pan.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [ListenerArgument(1, "x", typeof(int), "x")]
        [ListenerArgument(2, "y", typeof(int), "yDeylta")]
        [ListenerArgument(3, "xDelta", typeof(int), "xDelta")]
        [ListenerArgument(4, "yDelta", typeof(int), "yDelta")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("pan", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired after a pan")]
        public virtual ComponentDirectEvent Pan
        {
            get
            {
                if (this.pan == null)
                {
                    this.pan = new ComponentDirectEvent();
                }

                return this.pan;
            }
        }

        private ComponentDirectEvent click;

        /// <summary>
        /// Fired after a click.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [ListenerArgument(1, "e", typeof(object), "e")]
        [ListenerArgument(2, "t", typeof(object), "t")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("click", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired after a click")]
        public virtual ComponentDirectEvent Click
        {
            get
            {
                if (this.click == null)
                {
                    this.click = new ComponentDirectEvent();
                }

                return this.click;
            }
        }

        private ComponentDirectEvent dblClick;

        /// <summary>
        /// Fired after a double click.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [ListenerArgument(1, "e", typeof(object), "e")]
        [ListenerArgument(2, "t", typeof(object), "t")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("dblclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired after a double click")]
        public virtual ComponentDirectEvent DblClick
        {
            get
            {
                if (this.dblClick == null)
                {
                    this.dblClick = new ComponentDirectEvent();
                }

                return this.dblClick;
            }
        }
    }
}