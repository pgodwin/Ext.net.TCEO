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
    public partial class PanelDirectEvents : ContainerDirectEvents
    {
        private ComponentDirectEvent activate;

        /// <summary>
        /// Fires after the Panel has been visually activated. Note that Panels do not directly support being activated, but some Panel subclasses do (like Ext.Window). Panels which are child Components of a TabPanel fire the activate and deactivate events under the control of the TabPanel.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Panel), "The Panel that has been activated.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("activate", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the Panel has been visually activated. Note that Panels do not directly support being activated, but some Panel subclasses do (like Ext.Window). Panels which are child Components of a TabPanel fire the activate and deactivate events under the control of the TabPanel.")]
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

        private ComponentDirectEvent beforeClose;

        /// <summary>
        /// Fires before the Panel is closed. Note that Panels do not directly support being closed, but some Panel subclasses do (like Ext.Window). This event only applies to such subclasses. A handler can return false to cancel the close.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Panel), "The Panel being closed.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeclose", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the Panel is closed. Note that Panels do not directly support being closed, but some Panel subclasses do (like Ext.Window). This event only applies to such subclasses. A handler can return false to cancel the close.")]
        public virtual ComponentDirectEvent BeforeClose
        {
            get
            {
                if (this.beforeClose == null)
                {
                    this.beforeClose = new ComponentDirectEvent();
                }

                return this.beforeClose;
            }
        }

        private ComponentDirectEvent beforeCollapse;

        /// <summary>
        /// Fires before the Panel is collapsed. A handler can return false to cancel the collapse.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Panel), "the Panel being collapsed.")]
        [ListenerArgument(1, "animate", typeof(bool), "True if the collapse is animated, else false.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforecollapse", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the Panel is collapsed. A handler can return false to cancel the collapse.")]
        public virtual ComponentDirectEvent BeforeCollapse
        {
            get
            {
                if (this.beforeCollapse == null)
                {
                    this.beforeCollapse = new ComponentDirectEvent();
                }

                return this.beforeCollapse;
            }
        }

        private ComponentDirectEvent beforeExpand;

        /// <summary>
        /// Fires before the Panel is expanded. A handler can return false to cancel the expand.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Panel), "The Panel that has been activated.")]
        [ListenerArgument(1, "animate", typeof(bool), "True if the expand is animated, else false.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeexpand", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the Panel is expanded. A handler can return false to cancel the expand.")]
        public virtual ComponentDirectEvent BeforeExpand
        {
            get
            {
                if (this.beforeExpand == null)
                {
                    this.beforeExpand = new ComponentDirectEvent();
                }

                return this.beforeExpand;
            }
        }

        private ComponentDirectEvent bodyResize;

        /// <summary>
        /// Fires after the Panel has been resized.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Panel), "The Panel which has been resized.")]
        [ListenerArgument(1, "width", typeof(int), "The Panel's new width.")]
        [ListenerArgument(2, "height", typeof(int), "The Panel's new height.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("bodyresize", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the Panel has been resized.")]
        public virtual ComponentDirectEvent BodyResize
        {
            get
            {
                if (this.bodyResize == null)
                {
                    this.bodyResize = new ComponentDirectEvent();
                }

                return this.bodyResize;
            }
        }

        private ComponentDirectEvent close;

        /// <summary>
        /// Fires after the Panel is closed. Note that Panels do not directly support being closed, but some Panel subclasses do (like Ext.Window).
        /// </summary>
        [ListenerArgument(0, "item", typeof(Panel), "The Panel that has been closed.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("close", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the Panel is closed. Note that Panels do not directly support being closed, but some Panel subclasses do (like Ext.Window).")]
        public virtual ComponentDirectEvent Close
        {
            get
            {
                if (this.close == null)
                {
                    this.close = new ComponentDirectEvent();
                }

                return this.close;
            }
        }

        private ComponentDirectEvent collapse;

        /// <summary>
        /// Fires after the Panel has been collapsed.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Panel), "The Panel that has been collapsed.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("collapse", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the Panel has been collapsed.")]
        public virtual ComponentDirectEvent Collapse
        {
            get
            {
                if (this.collapse == null)
                {
                    this.collapse = new ComponentDirectEvent();
                }

                return this.collapse;
            }
        }

        private ComponentDirectEvent deactivate;

        /// <summary>
        /// Fires after the Panel has been visually deactivated. Note that Panels do not directly support being deactivated, but some Panel subclasses do (like Ext.Window). Panels which are child Components of a TabPanel fire the activate and deactivate events under the control of the TabPanel.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Panel), "The Panel that has been deactivated.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("deactivate", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the Panel has been visually deactivated. Note that Panels do not directly support being deactivated, but some Panel subclasses do (like Ext.Window). Panels which are child Components of a TabPanel fire the activate and deactivate events under the control of the TabPanel.")]
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

        private ComponentDirectEvent expand;

        /// <summary>
        /// Fires after the Panel has been expanded.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Panel), "The Panel that has been expanded.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("expand", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the Panel has been expanded.")]
        public virtual ComponentDirectEvent Expand
        {
            get
            {
                if (this.expand == null)
                {
                    this.expand = new ComponentDirectEvent();
                }

                return this.expand;
            }
        }

        private ComponentDirectEvent titleChange;

        /// <summary>
        /// Fires after the Panel title has been set or changed.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Panel), "The Panel which has had its title changed.")]
        [ListenerArgument(1, "title", typeof(string), "new title.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("titlechange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the Panel title has been set or changed.")]
        public virtual ComponentDirectEvent TitleChange
        {
            get
            {
                if (this.titleChange == null)
                {
                    this.titleChange = new ComponentDirectEvent();
                }

                return this.titleChange;
            }
        }

        private ComponentDirectEvent beforeUpdate;

        /// <summary>
        /// Fires before iframe loading.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Panel), "this")]
        [ListenerArgument(1, "url", typeof(string), "url")]
        [ListenerArgument(2, "iframe", typeof(object), "iframe")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeupdate", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before iframe loading.")]
        public virtual ComponentDirectEvent BeforeUpdate
        {
            get
            {
                if (this.beforeUpdate == null)
                {
                    this.beforeUpdate = new ComponentDirectEvent();
                }

                return this.beforeUpdate;
            }
        }

        private ComponentDirectEvent update;

        /// <summary>
        /// Fired after successful update is made.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Panel), "this")]
        [ListenerArgument(1, "iframe", typeof(object), "iframe")]
        [ListenerArgument(2, "url", typeof(string), "url")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("update", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired after successful update is made.")]
        public virtual ComponentDirectEvent Update
        {
            get
            {
                if (this.update == null)
                {
                    this.update = new ComponentDirectEvent();
                }

                return this.update;
            }
        }

        private ComponentDirectEvent failure;

        /// <summary>
        /// Fired on update failure.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Panel), "this")]
        [ListenerArgument(1, "iframe", typeof(object), "iframe")]
        [ListenerArgument(2, "url", typeof(string), "url")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("failure", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired on update failure.")]
        public virtual ComponentDirectEvent Failure
        {
            get
            {
                if (this.failure == null)
                {
                    this.failure = new ComponentDirectEvent();
                }

                return this.failure;
            }
        }

        private ComponentDirectEvent iconChange;

        /// <summary>
        /// Fires after the Panel icon class has been set or changed.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Panel), "this")]
        [ListenerArgument(1, "newCls", typeof(string))]
        [ListenerArgument(2, "oldCls", typeof(string))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("iconchange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the Panel icon class has been set or changed.")]
        public virtual ComponentDirectEvent IconChange
        {
            get
            {
                if (this.iconChange == null)
                {
                    this.iconChange = new ComponentDirectEvent();
                }

                return this.iconChange;
            }
        }
    }
}