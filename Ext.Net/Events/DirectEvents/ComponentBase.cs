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
    [ToolboxItem(false)]
    [TypeConverter(typeof(DirectEventsConverter))]
    public abstract partial class ComponentBaseDirectEvents : ComponentDirectEvents
    {
        private ComponentDirectEvent added;

        /// <summary>
        /// Fires when a component is added to an Ext.Container
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [ListenerArgument(1, "ownerCt", typeof(Container), "Container which holds the component")]
        [ListenerArgument(2, "index", typeof(int), "Position at which the component was added")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("added", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a component is added to an Ext.Container")]
        public virtual ComponentDirectEvent Added
        {
            get
            {
                if (this.added == null)
                {
                    this.added = new ComponentDirectEvent();
                }

                return this.added;
            }
        }

        private ComponentDirectEvent afterRender;

        /// <summary>
        /// Fires after the component rendering is finished. The afterrender event is fired after this Component has been rendered, been postprocesed by any afterRender method defined for the Component, and, if stateful, after state has been restored.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("afterrender", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the component rendering is finished. The afterrender event is fired after this Component has been rendered, been postprocesed by any afterRender method defined for the Component, and, if stateful, after state has been restored.")]
        public virtual ComponentDirectEvent AfterRender
        {
            get
            {
                if (this.afterRender == null)
                {
                    this.afterRender = new ComponentDirectEvent();
                }

                return this.afterRender;
            }
        }
        
        private ComponentDirectEvent beforeDestroy;

        /// <summary>
        /// Fires before the component is destroyed. Return false to stop the destroy.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforedestroy", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the component is destroyed. Return false to stop the destroy.")]
        public virtual ComponentDirectEvent BeforeDestroy
        {
            get
            {
                if (this.beforeDestroy == null)
                {
                    this.beforeDestroy = new ComponentDirectEvent();
                }

                return this.beforeDestroy;
            }
        }

        private ComponentDirectEvent beforeHide;

        /// <summary>
        /// Fires before the component is hidden. Return false to stop the hide.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforehide", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the component is hidden. Return false to stop the hide.")]
        public virtual ComponentDirectEvent BeforeHide
        {
            get
            {
                if (this.beforeHide == null)
                {
                    this.beforeHide = new ComponentDirectEvent();
                }

                return this.beforeHide;
            }
        }

        private ComponentDirectEvent beforeRender;

        /// <summary>
        /// Fires before the component is rendered. Return false to stop the render.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforerender", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the component is rendered. Return false to stop the render.")]
        public virtual ComponentDirectEvent BeforeRender
        {
            get
            {
                if (this.beforeRender == null)
                {
                    this.beforeRender = new ComponentDirectEvent();
                }

                return this.beforeRender;
            }
        }

        private ComponentDirectEvent beforeShow;

        /// <summary>
        /// Fires before the component is shown. Return false to stop the show.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeshow", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the component is shown. Return false to stop the show.")]
        public virtual ComponentDirectEvent BeforeShow
        {
            get
            {
                if (this.beforeShow == null)
                {
                    this.beforeShow = new ComponentDirectEvent();
                }

                return this.beforeShow;
            }
        }

        private ComponentDirectEvent beforeStateRestore;

        /// <summary>
        /// Fires before the state of the component is restored. Return false to stop the restore.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [ListenerArgument(1, "state", typeof(object), "The hash of state values")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforestaterestore", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the state of the component is restored. Return false to stop the restore.")]
        public virtual ComponentDirectEvent BeforeStateRestore
        {
            get
            {
                if (this.beforeStateRestore == null)
                {
                    this.beforeStateRestore = new ComponentDirectEvent();
                }

                return this.beforeStateRestore;
            }
        }

        private ComponentDirectEvent beforeStateSave;

        /// <summary>
        /// Fires before the state of the component is saved to the configured state provider. Return false to stop the save.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [ListenerArgument(1, "state", typeof(object), "The hash of state values")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforestatesave", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the state of the component is saved to the configured state provider. Return false to stop the save.")]
        public virtual ComponentDirectEvent BeforeStateSave
        {
            get
            {
                if (this.beforeStateSave == null)
                {
                    this.beforeStateSave = new ComponentDirectEvent();
                }

                return this.beforeStateSave;
            }
        }

        private ComponentDirectEvent destroy;

        /// <summary>
        /// Fires after the component is destroyed.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("destroy", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the component is destroyed.")]
        public virtual ComponentDirectEvent Destroy
        {
            get
            {
                if (this.destroy == null)
                {
                    this.destroy = new ComponentDirectEvent();
                }

                return this.destroy;
            }
        }

        private ComponentDirectEvent disable;

        /// <summary>
        /// Fires after the component is disabled.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("disable", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the component is disabled.")]
        public virtual ComponentDirectEvent Disable
        {
            get
            {
                if (this.disable == null)
                {
                    this.disable = new ComponentDirectEvent();
                }

                return this.disable;
            }
        }

        private ComponentDirectEvent enable;

        /// <summary>
        /// Fires after the component is enabled.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("enable", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the component is enabled.")]
        public virtual ComponentDirectEvent Enable
        {
            get
            {
                if (this.enable == null)
                {
                    this.enable = new ComponentDirectEvent();
                }

                return this.enable;
            }
        }

        private ComponentDirectEvent hide;

        /// <summary>
        /// Fires after the component is hidden.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("hide", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the component is hidden.")]
        public virtual ComponentDirectEvent Hide
        {
            get
            {
                if (this.hide == null)
                {
                    this.hide = new ComponentDirectEvent();
                }

                return this.hide;
            }
        }

        private ComponentDirectEvent render;

        /// <summary>
        /// Fires after the component is rendered.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("render", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the component is rendered.")]
        public virtual ComponentDirectEvent Render
        {
            get
            {
                if (this.render == null)
                {
                    this.render = new ComponentDirectEvent();
                }

                return this.render;
            }
        }

        private ComponentDirectEvent removed;

        /// <summary>
        /// Fires after the component is rendered.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [ListenerArgument(1, "ownerCt", typeof(Container), "Container which holds the component")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("removed", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the component is rendered.")]
        public virtual ComponentDirectEvent Removed
        {
            get
            {
                if (this.removed == null)
                {
                    this.removed = new ComponentDirectEvent();
                }

                return this.removed;
            }
        }

        private ComponentDirectEvent show;

        /// <summary>
        /// Fires after the component is shown.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("show", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the component is shown.")]
        public virtual ComponentDirectEvent Show
        {
            get
            {
                if (this.show == null)
                {
                    this.show = new ComponentDirectEvent();
                }

                return this.show;
            }
        }

        private ComponentDirectEvent stateRestore;

        /// <summary>
        /// Fires after the state of the component is restored.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [ListenerArgument(1, "state", typeof(object), "The hash of state values")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("staterestore", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the state of the component is restored.")]
        public virtual ComponentDirectEvent StateRestore
        {
            get
            {
                if (this.stateRestore == null)
                {
                    this.stateRestore = new ComponentDirectEvent();
                }

                return this.stateRestore;
            }
        }

        private ComponentDirectEvent stateSave;

        /// <summary>
        /// Fires after the state of the component is saved to the configured state provider.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [ListenerArgument(1, "state", typeof(object), "The hash of state values")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("statesave", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the state of the component is saved to the configured state provider.")]
        public virtual ComponentDirectEvent StateSave
        {
            get
            {
                if (this.stateSave == null)
                {
                    this.stateSave = new ComponentDirectEvent();
                }

                return this.stateSave;
            }
        }
    }
}