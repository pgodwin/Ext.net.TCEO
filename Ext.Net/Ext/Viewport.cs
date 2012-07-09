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
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// A specialized content Container representing the viewable application area (the browser viewport).
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:Viewport runat=\"server\" Layout=\"border\"><Items><{0}:Panel runat=\"server\" Height=\"100\" Title=\"North\" Region=\"North\" Collapsible=\"True\" Split=\"True\"><Items></Items></{0}:Panel><{0}:Panel runat=\"server\" Layout=\"Fit\" Title=\"East\" Width=\"175\" Region=\"East\" Collapsible=\"true\" Split=\"true\"><Items><{0}:TabPanel runat=\"server\" ActiveTabIndex=\"0\" Border=\"false\" TabPosition=\"Bottom\" Title=\"Title\"><Items><{0}:Panel runat=\"server\" Title=\"Tab 1\"><Items></Items></{0}:Panel><{0}:Panel runat=\"server\" Title=\"Tab 2\"><Items></Items></{0}:Panel></Items></{0}:TabPanel></Items></{0}:Panel><{0}:Panel runat=\"server\" Height=\"100\" Title=\"South\" Region=\"South\" Collapsible=\"true\" Split=\"true\"><Items></Items></{0}:Panel><{0}:Panel runat=\"server\" Title=\"West\" Width=\"175\" Region=\"West\" Collapsible=\"true\" Split=\"true\" Layout=\"accordion\"><Items><{0}:Panel runat=\"server\" Border=\"false\" Collapsed=\"True\" Icon=\"FolderGo\" Title=\"Item 1\"><Items></Items></{0}:Panel><{0}:Panel runat=\"server\" Border=\"false\" Collapsed=\"true\" Icon=\"FolderWrench\" Title=\"Item 2\"><Items></Items></{0}:Panel></Items></{0}:Panel><{0}:Panel runat=\"server\" Layout=\"Fit\" Title=\"Center\" Region=\"Center\"><Items><{0}:TabPanel runat=\"server\" ActiveTabIndex=\"0\" Border=\"false\" Title=\"Center\"><Items><{0}:Panel runat=\"server\" Closable=\"true\" Title=\"Tab 1\"><Items></Items></{0}:Panel><{0}:Panel runat=\"server\" Title=\"Tab 2\"><Items></Items></{0}:Panel></Items></{0}:TabPanel></Items></{0}:Panel></Items></{0}:Viewport>")]
    [ToolboxBitmap(typeof(Viewport), "Build.ToolboxIcons.Viewport.bmp")]
    [Designer(typeof(ViewportDesigner))]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [DefaultProperty("Body")]
    [Description("A specialized content Container representing the viewable application area (the browser viewport).")]
    public partial class Viewport : ViewportBase
    {
        /// <summary>
        /// Create a new Viewport
        /// </summary>
        [Description("Create a new Viewport")]
        public Viewport() { }


        /*  Events
           -----------------------------------------------------------------------------------------------*/
        
        private ContainerListeners listeners;

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
        public ContainerListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new ContainerListeners();
                }

                return this.listeners;
            }
        }

        private ContainerDirectEvents directEvents;

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
        public ContainerDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new ContainerDirectEvents();
                }

                return this.directEvents;
            }
        }
    }
}