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
using System.Drawing;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// A custom form used for detailed editing of events.
    /// This is pretty much a standard form that is simply pre-configured for the options needed by the calendar components. 
    /// It is also configured to automatically bind records of type Ext.calendar.EventRecord to and from the form.
    /// This form also provides custom events specific to the calendar so that other calendar components can be 
    /// easily notified when an event has been edited via this component.
    /// </summary>
    [Designer(typeof(EmptyDesigner))]
    [ToolboxBitmap(typeof(DayView), "Build.ToolboxIcons.CalendarPanel.bmp")]
    public partial class EventEditForm : EventEditFormBase
    {
        /// <summary>
        /// 
        /// </summary>
        public override ConfigOptionsExtraction ConfigOptionsExtraction
        {
            get
            {
                return Ext.Net.CalendarPanel.ConfigOptionsEngine;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public EventEditForm() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.calendar.EventEditForm";
            }
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
                return "eventeditform";
            }
        }

        private EventEditFormListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ViewStateMember]
        [Description("Client-side JavaScript Event Handlers")]
        public EventEditFormListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new EventEditFormListeners();
                }

                return this.listeners;
            }
        }

        private EventEditFormDirectEvents directEvents;

        /// <summary>
        /// Server-side Ajax Event Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]
        [ViewStateMember]
        [Description("Server-side Ajax Event Handlers")]
        public EventEditFormDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new EventEditFormDirectEvents();
                }

                return this.directEvents;
            }
        }
    }
}