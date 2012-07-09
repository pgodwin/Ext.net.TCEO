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
using System.Drawing;
using System.Drawing.Design;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// Plugin which can be attached to any Ext.Toolbar instance. Provides ability to reorder toolbar items with drag and drop.
    /// </summary>
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(ToolbarReorderer), "Build.ToolboxIcons.Plugin.bmp")]
    [ToolboxData("<{0}:ToolbarReorderer runat=\"server\" />")]
    [Description("Plugin which can be attached to any Ext.Toolbar instance. Provides ability to reorder toolbar items with drag and drop.")]
    public partial class ToolbarReorderer : Plugin
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override List<ResourceItem> Resources
        {
            get
            {
                List<ResourceItem> baseList = base.Resources;
                baseList.Capacity += 1;

                baseList.Add(new ClientScriptItem(typeof(ToolbarReorderer), "Ext.Net.Build.Ext.Net.ux.plugins.toolbarreorderer.toolbarreorderer.js", "/ux/plugins/toolbarreorderer/toolbarreorderer.js"));

                return baseList;
            }
        }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.ux.ToolbarReorderer";
            }
        }
        
        /// <summary>
        /// If set to true, the rearranging of the toolbar items is animated
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. ToolbarReorderer")]
        [DefaultValue(true)]
        [Description("If set to true, the rearranging of the toolbar items is animated")]
        public virtual bool Animate
        {
            get
            {
                object obj = this.ViewState["Animate"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["Animate"] = value;
            }
        }

        /// <summary>
        /// The duration of the animation used to move other toolbar items out of the way
        /// </summary>
        [Meta]
        [Category("3. ToolbarReorderer")]
        [DefaultValue(0.2)]
        [Description("The duration of the animation used to move other toolbar items out of the way")]
        public virtual double AnimationDuration
        {
            get
            {
                object obj = this.ViewState["AnimationDuration"];
                return (obj == null) ? 0.2 : (double)obj;
            }
            set
            {
                this.ViewState["AnimationDuration"] = value;
            }
        }

        /// <summary>
        /// True to make every toolbar draggable unless reorderable is specifically set to false. This defaults to false
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. ToolbarReorderer")]
        [DefaultValue(false)]
        [Description("True to make every toolbar draggable unless reorderable is specifically set to false. This defaults to false")]
        public virtual bool DefaultReorderable
        {
            get
            {
                object obj = this.ViewState["DefaultReorderable"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["DefaultReorderable"] = value;
            }
        }

        private ToolbarReordererListeners listeners;

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
        public ToolbarReordererListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new ToolbarReordererListeners();
                }

                return this.listeners;
            }
        }


        private ToolbarReordererDirectEvents directEvents;

        /// <summary>
        /// Server-side DirectEvent Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]
        [ViewStateMember]
        [Description("Server-side DirectEventHandlers")]
        public ToolbarReordererDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new ToolbarReordererDirectEvents();
                }

                return this.directEvents;
            }
        }
    }
}