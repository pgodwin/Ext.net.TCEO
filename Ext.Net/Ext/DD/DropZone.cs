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
using System.Drawing;

namespace Ext.Net
{
    /// <summary>
    /// This class provides a container DD instance that allows dropping on multiple child target nodes.
    /// By default, this class requires that child nodes accepting drop are registered with Ext.dd.Registry. However a simpler way to allow a DropZone to manage any number of target elements is to configure the DropZone with an implementation of getTargetFromEvent which interrogates the passed mouse event to see if it has taken place within an element, or class of elements. This is easily done by using the event's getTarget method to identify a node based on a Ext.DomQuery selector.
    /// Once the DropZone has detected through calling getTargetFromEvent, that the mouse is over a drop target, that target is passed as the first parameter to onNodeEnter, onNodeOver, onNodeOut, onNodeDrop. You may configure the instance of DropZone with implementations of these methods to provide application-specific behaviour for these events to update both application state, and UI state.
    /// </summary>
    [ToolboxItem(true)]
    [Designer(typeof(EmptyDesigner))]
    [ToolboxData("<{0}:DropZone runat=\"server\"></{0}:DropZone>")]
    [ToolboxBitmap(typeof(DropZone), "Build.ToolboxIcons.DragDrop.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("This class provides a container DD instance that allows dropping on multiple child target nodes.")]
    public partial class DropZone : DropTarget
    {
        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.dd.DropZone";
            }
        }

        private JFunction getTargetFromEvent;

        /// <summary>
        /// Returns a custom data object associated with the DOM node that is the target of the event. By default this looks up the event target in the Ext.dd.Registry, although you can override this method to provide your own custom lookup.
        /// Parameters:
        ///    e : The event
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("6. DropZone")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Returns a custom data object associated with the DOM node that is the target of the event. By default this looks up the event target in the Ext.dd.Registry, although you can override this method to provide your own custom lookup.")]
        public virtual JFunction GetTargetFromEvent
        {
            get
            {
                if (this.getTargetFromEvent == null)
                {
                    this.getTargetFromEvent = new JFunction();
                    if (!this.DesignMode)
                    {
                        this.getTargetFromEvent.Args = new string[] {"e"};
                    }
                }

                return this.getTargetFromEvent;
            }
        }

        private JFunction onContainerDrop;

        /// <summary>
        /// Called when the DropZone determines that a Ext.dd.DragSource has been dropped on it, but not on any of its registered drop nodes. The default implementation returns false, so it should be overridden to provide the appropriate processing of the drop event if you need the drop zone itself to be able to accept drops. It should return true when valid so that the drag source's repair action does not run.
        /// Parameters:
        ///   source : The drag source that was dragged over this drop zone 
        ///   e      : The event
        ///   data   : An object containing arbitrary data supplied by the drag source
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("6. DropZone")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Called when the DropZone determines that a Ext.dd.DragSource has been dropped on it, but not on any of its registered drop nodes. The default implementation returns false, so it should be overridden to provide the appropriate processing of the drop event if you need the drop zone itself to be able to accept drops. It should return true when valid so that the drag source's repair action does not run.")]
        public virtual JFunction OnContainerDrop
        {
            get
            {
                if (this.onContainerDrop == null)
                {
                    this.onContainerDrop = new JFunction();
                    if (!this.DesignMode)
                    {
                        this.onContainerDrop.Args = new string[] {"source", "e", "data"};
                    }
                }

                return this.onContainerDrop;
            }
        }

        private JFunction onContainerOver;

        /// <summary>
        /// Called while the DropZone determines that a Ext.dd.DragSource is being dragged over it, but not over any of its registered drop nodes. The default implementation returns this.dropNotAllowed, so it should be overridden to provide the proper feedback if necessary.
        /// Parameters:
        ///   source : The drag source that was dragged over this drop zone 
        ///   e      : The event
        ///   data   : An object containing arbitrary data supplied by the drag source
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("6. DropZone")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Called while the DropZone determines that a Ext.dd.DragSource is being dragged over it, but not over any of its registered drop nodes. The default implementation returns this.dropNotAllowed, so it should be overridden to provide the proper feedback if necessary.")]
        public virtual JFunction OnContainerOver
        {
            get
            {
                if (this.onContainerOver == null)
                {
                    this.onContainerOver = new JFunction();
                    if (!this.DesignMode)
                    {
                        this.onContainerOver.Args = new string[] {"source", "e", "data"};
                    }
                }

                return this.onContainerOver;
            }
        }

        private JFunction onNodeDrop;

        /// <summary>
        /// Called when the DropZone determines that a Ext.dd.DragSource has been dropped onto the drop node. The default implementation returns false, so it should be overridden to provide the appropriate processing of the drop event and return true so that the drag source's repair action does not run.
        /// Parameters:
        ///   nodeData : The custom data associated with the drop node (this is the same value returned from getTargetFromEvent for this node)
        ///   source   : The drag source that was dragged over this drop zone 
        ///   e        : The event
        ///   data     : An object containing arbitrary data supplied by the drag source
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("6. DropZone")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Called when the DropZone determines that a Ext.dd.DragSource has been dropped onto the drop node. The default implementation returns false, so it should be overridden to provide the appropriate processing of the drop event and return true so that the drag source's repair action does not run.")]
        public virtual JFunction OnNodeDrop
        {
            get
            {
                if (this.onNodeDrop == null)
                {
                    this.onNodeDrop = new JFunction();
                    if (!this.DesignMode)
                    {
                        this.onNodeDrop.Args = new string[] {"nodeData", "source", "e", "data"};
                    }
                }

                return this.onNodeDrop;
            }
        }

        private JFunction onNodeEnter;

        /// <summary>
        /// Called when the DropZone determines that a Ext.dd.DragSource has entered a drop node that has either been registered or detected by a configured implementation of getTargetFromEvent. This method has no default implementation and should be overridden to provide node-specific processing if necessary.
        /// Parameters:
        ///   nodeData : The custom data associated with the drop node (this is the same value returned from getTargetFromEvent for this node)
        ///   source   : The drag source that was dragged over this drop zone 
        ///   e        : The event
        ///   data     : An object containing arbitrary data supplied by the drag source
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("6. DropZone")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Called when the DropZone determines that a Ext.dd.DragSource has entered a drop node that has either been registered or detected by a configured implementation of getTargetFromEvent. This method has no default implementation and should be overridden to provide node-specific processing if necessary.")]
        public virtual JFunction OnNodeEnter
        {
            get
            {
                if (this.onNodeEnter == null)
                {
                    this.onNodeEnter = new JFunction();
                    if (!this.DesignMode)
                    {
                        this.onNodeEnter.Args = new string[] {"nodeData", "source", "e", "data"};
                    }
                }

                return this.onNodeEnter;
            }
        }

        private JFunction onNodeOut;

        /// <summary>
        /// Called when the DropZone determines that a Ext.dd.DragSource has been dragged out of the drop node without dropping. This method has no default implementation and should be overridden to provide node-specific processing if necessary.
        /// Parameters:
        ///   nodeData : The custom data associated with the drop node (this is the same value returned from getTargetFromEvent for this node)
        ///   source   : The drag source that was dragged over this drop zone 
        ///   e        : The event
        ///   data     : An object containing arbitrary data supplied by the drag source
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("6. DropZone")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Called when the DropZone determines that a Ext.dd.DragSource has been dragged out of the drop node without dropping. This method has no default implementation and should be overridden to provide node-specific processing if necessary.")]
        public virtual JFunction OnNodeOut
        {
            get
            {
                if (this.onNodeOut == null)
                {
                    this.onNodeOut = new JFunction();
                    if (!this.DesignMode)
                    {
                        this.onNodeOut.Args = new string[] {"nodeData", "source", "e", "data"};
                    }
                }

                return this.onNodeOut;
            }
        }

        private JFunction onNodeOver;

        /// <summary>
        /// Called while the DropZone determines that a Ext.dd.DragSource is over a drop node that has either been registered or detected by a configured implementation of getTargetFromEvent. The default implementation returns this.dropNotAllowed, so it should be overridden to provide the proper feedback.
        /// Parameters:
        ///   nodeData : The custom data associated with the drop node (this is the same value returned from getTargetFromEvent for this node)
        ///   source   : The drag source that was dragged over this drop zone 
        ///   e        : The event
        ///   data     : An object containing arbitrary data supplied by the drag source
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("6. DropZone")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Called while the DropZone determines that a Ext.dd.DragSource is over a drop node that has either been registered or detected by a configured implementation of getTargetFromEvent. The default implementation returns this.dropNotAllowed, so it should be overridden to provide the proper feedback.")]
        public virtual JFunction OnNodeOver
        {
            get
            {
                if (this.onNodeOver == null)
                {
                    this.onNodeOver = new JFunction();
                    if (!this.DesignMode)
                    {
                        this.onNodeOver.Args = new string[] {"nodeData", "source", "e", "data"};
                    }
                }

                return this.onNodeOver;
            }
        }
    }
}