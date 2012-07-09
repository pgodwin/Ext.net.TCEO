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
    public partial class MouseDistanceSensorDirectEvents : ComponentDirectEvents
    {
        private ComponentDirectEvent far;

        /// <summary>
        /// 
        /// </summary>
        [ListenerArgument(0, "item", typeof(MouseDistanceSensor), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("far", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent Far
        {
            get
            {
                if (this.far == null)
                {
                    this.far = new ComponentDirectEvent();
                }

                return this.far;
            }
        }

        private ComponentDirectEvent near;

        /// <summary>
        /// 
        /// </summary>
        [ListenerArgument(0, "item", typeof(MouseDistanceSensor), "this")]
        [ListenerArgument(1, "sensorEl", typeof(object), "sensor element")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("near", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent Near
        {
            get
            {
                if (this.near == null)
                {
                    this.near = new ComponentDirectEvent();
                }

                return this.near;
            }
        }

        private ComponentDirectEvent distance;

        /// <summary>
        /// 
        /// </summary>
        [ListenerArgument(0, "item", typeof(MouseDistanceSensor), "this")]
        [ListenerArgument(1, "distance", typeof(int), "distance in pixel")]
        [ListenerArgument(2, "rdistance", typeof(decimal), "relative distance")]
        [ListenerArgument(3, "sensorEl", typeof(object), "sensor element")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("distance", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent Distance
        {
            get
            {
                if (this.distance == null)
                {
                    this.distance = new ComponentDirectEvent();
                }

                return this.distance;
            }
        }
    }
}
