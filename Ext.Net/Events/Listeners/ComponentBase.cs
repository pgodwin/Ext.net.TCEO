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
    [TypeConverter(typeof(ListenersConverter))]
    public abstract partial class ComponentBaseListeners : ComponentListeners
    {
        private ComponentListener added;

        /// <summary>
        /// Fires when a component is added to an Ext.Container
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [ListenerArgument(1, "ownerCt", typeof(Container), "Container which holds the component")]
        [ListenerArgument(2, "index", typeof(int), "Position at which the component was added")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("added", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a component is added to an Ext.Container")]
        public virtual ComponentListener Added
        {
            get
            {
                if (this.added == null)
                {
                    this.added = new ComponentListener();
                }

                return this.added;
            }
        }

        private ComponentListener afterRender;

        /// <summary>
        /// Fires after the component rendering is finished. The afterrender event is fired after this Component has been rendered, been postprocesed by any afterRender method defined for the Component, and, if stateful, after state has been restored.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("afterrender", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the component rendering is finished. The afterrender event is fired after this Component has been rendered, been postprocesed by any afterRender method defined for the Component, and, if stateful, after state has been restored.")]
        public virtual ComponentListener AfterRender
        {
            get
            {
                if (this.afterRender == null)
                {
                    this.afterRender = new ComponentListener();
                }

                return this.afterRender;
            }
        }
        
        private ComponentListener beforeDestroy;

        /// <summary>
        /// Fires before the component is destroyed. Return false to stop the destroy.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforedestroy", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the component is destroyed. Return false to stop the destroy.")]
        public virtual ComponentListener BeforeDestroy
        {
            get
            {
                if (this.beforeDestroy == null)
                {
                    this.beforeDestroy = new ComponentListener();
                }

                return this.beforeDestroy;
            }
        }

        private ComponentListener beforeHide;

        /// <summary>
        /// Fires before the component is hidden. Return false to stop the hide.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforehide", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the component is hidden. Return false to stop the hide.")]
        public virtual ComponentListener BeforeHide
        {
            get
            {
                if (this.beforeHide == null)
                {
                    this.beforeHide = new ComponentListener();
                }

                return this.beforeHide;
            }
        }

        private ComponentListener beforeRender;

        /// <summary>
        /// Fires before the component is rendered. Return false to stop the render.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforerender", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the component is rendered. Return false to stop the render.")]
        public virtual ComponentListener BeforeRender
        {
            get
            {
                if (this.beforeRender == null)
                {
                    this.beforeRender = new ComponentListener();
                }

                return this.beforeRender;
            }
        }

        private ComponentListener beforeShow;

        /// <summary>
        /// Fires before the component is shown. Return false to stop the show.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeshow", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the component is shown. Return false to stop the show.")]
        public virtual ComponentListener BeforeShow
        {
            get
            {
                if (this.beforeShow == null)
                {
                    this.beforeShow = new ComponentListener();
                }

                return this.beforeShow;
            }
        }

        private ComponentListener beforeStateRestore;

        /// <summary>
        /// Fires before the state of the component is restored. Return false to stop the restore.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [ListenerArgument(1, "state", typeof(object), "The hash of state values")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforestaterestore", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the state of the component is restored. Return false to stop the restore.")]
        public virtual ComponentListener BeforeStateRestore
        {
            get
            {
                if (this.beforeStateRestore == null)
                {
                    this.beforeStateRestore = new ComponentListener();
                }

                return this.beforeStateRestore;
            }
        }

        private ComponentListener beforeStateSave;

        /// <summary>
        /// Fires before the state of the component is saved to the configured state provider. Return false to stop the save.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [ListenerArgument(1, "state", typeof(object), "The hash of state values")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforestatesave", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the state of the component is saved to the configured state provider. Return false to stop the save.")]
        public virtual ComponentListener BeforeStateSave
        {
            get
            {
                if (this.beforeStateSave == null)
                {
                    this.beforeStateSave = new ComponentListener();
                }

                return this.beforeStateSave;
            }
        }

        private ComponentListener destroy;

        /// <summary>
        /// Fires after the component is destroyed.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("destroy", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the component is destroyed.")]
        public virtual ComponentListener Destroy
        {
            get
            {
                if (this.destroy == null)
                {
                    this.destroy = new ComponentListener();
                }

                return this.destroy;
            }
        }

        private ComponentListener disable;

        /// <summary>
        /// Fires after the component is disabled.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("disable", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the component is disabled.")]
        public virtual ComponentListener Disable
        {
            get
            {
                if (this.disable == null)
                {
                    this.disable = new ComponentListener();
                }

                return this.disable;
            }
        }

        private ComponentListener enable;

        /// <summary>
        /// Fires after the component is enabled.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("enable", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the component is enabled.")]
        public virtual ComponentListener Enable
        {
            get
            {
                if (this.enable == null)
                {
                    this.enable = new ComponentListener();
                }

                return this.enable;
            }
        }

        private ComponentListener hide;

        /// <summary>
        /// Fires after the component is hidden.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("hide", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the component is hidden.")]
        public virtual ComponentListener Hide
        {
            get
            {
                if (this.hide == null)
                {
                    this.hide = new ComponentListener();
                }

                return this.hide;
            }
        }

        private ComponentListener render;

        /// <summary>
        /// Fires after the component is rendered.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("render", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the component is rendered.")]
        public virtual ComponentListener Render
        {
            get
            {
                if (this.render == null)
                {
                    this.render = new ComponentListener();
                }

                return this.render;
            }
        }

        private ComponentListener removed;

        /// <summary>
        /// Fires when a component is removed from an Ext.Container
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [ListenerArgument(1, "ownerCt", typeof(Container), "Container which holds the component")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("removed", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a component is removed from an Ext.Container")]
        public virtual ComponentListener Removed
        {
            get
            {
                if (this.removed == null)
                {
                    this.removed = new ComponentListener();
                }

                return this.removed;
            }
        }

        private ComponentListener show;

        /// <summary>
        /// Fires after the component is shown.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("show", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the component is shown.")]
        public virtual ComponentListener Show
        {
            get
            {
                if (this.show == null)
                {
                    this.show = new ComponentListener();
                }

                return this.show;
            }
        }

        private ComponentListener stateRestore;

        /// <summary>
        /// Fires after the state of the component is restored.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [ListenerArgument(1, "state", typeof(object), "The hash of state values")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("staterestore", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the state of the component is restored.")]
        public virtual ComponentListener StateRestore
        {
            get
            {
                if (this.stateRestore == null)
                {
                    this.stateRestore = new ComponentListener();
                }

                return this.stateRestore;
            }
        }

        private ComponentListener stateSave;

        /// <summary>
        /// Fires after the state of the component is saved to the configured state provider.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Component), "this")]
        [ListenerArgument(1, "state", typeof(object), "The hash of state values")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("statesave", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the state of the component is saved to the configured state provider.")]
        public virtual ComponentListener StateSave
        {
            get
            {
                if (this.stateSave == null)
                {
                    this.stateSave = new ComponentListener();
                }

                return this.stateSave;
            }
        }
    }
}