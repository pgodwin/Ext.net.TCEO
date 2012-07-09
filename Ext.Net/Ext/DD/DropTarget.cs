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
using System.Web.UI;
using Ext.Net.Utilities;
using System.Drawing;

namespace Ext.Net
{
    /// <summary>
    /// This class provides a container DD instance that allows dragging of multiple child source nodes.
    /// </summary>
    [ToolboxItem(true)]
    [Designer(typeof(EmptyDesigner))]
    [ToolboxData("<{0}:DropTarget runat=\"server\"></{0}:DropTarget>")]
    [ToolboxBitmap(typeof(DropTarget), "Build.ToolboxIcons.DragDrop.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("This class provides a container DD instance that allows dragging of multiple child source nodes.")]
    public partial class DropTarget : DDTarget
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
                return "Ext.dd.DropTarget";
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string ToScript(Control owner)
        {
            //if (this.Target.IsEmpty())
            //{
            //    throw new Exception("You should define Target");
            //}

            return "this.{0}=new Ext.net.ProxyDDCreator({{target: {1}, config: {2}, type: {3}}});".FormatWith(
                      this.ClientID,
                      this.ParsedTarget,
                      new ClientConfig().Serialize(this, true),
                      this.InstanceOf
                   );

            //return "this.{0}=new {1}({2},{3});".FormatWith(this.ClientID, this.InstanceOf, string.Concat("Ext.net.getEl(", TokenUtils.ParseAndNormalize(this.Target), ")"), new ClientConfig().Serialize(this, true));
        }

        /// <summary>
        /// A named drag drop group to which this object belongs. If a group is specified, then this object will only interact with other drag drop objects in the same group (defaults to undefined).
        /// </summary>
        [ConfigOption("ddGroup")]
        [Category("5. DropTarget")]
        [DefaultValue("")]
        [Description("A named drag drop group to which this object belongs. If a group is specified, then this object will only interact with other drag drop objects in the same group (defaults to undefined).")]
        public override string Group
        {
            get
            {
                return (string)this.ViewState["Group"] ?? "";
            }
            set
            {
                this.ViewState["Group"] = value;
            }
        }

        /// <summary>
        /// The CSS class returned to the drag source when drop is allowed (defaults to "x-dd-drop-ok").
        /// </summary>
        [ConfigOption]
        [Category("5. DropTarget")]
        [DefaultValue("x-dd-drop-ok")]
        [Description("The CSS class returned to the drag source when drop is allowed (defaults to \"x-dd-drop-ok\").")]
        public virtual string DropAllowed
        {
            get
            {
                return (string)this.ViewState["DropAllowed"] ?? "x-dd-drop-ok";
            }
            set
            {
                this.ViewState["DropAllowed"] = value;
            }
        }

        /// <summary>
        /// The CSS class returned to the drag source when drop is not allowed (defaults to "x-dd-drop-nodrop").
        /// </summary>
        [ConfigOption]
        [Category("5. DropTarget")]
        [DefaultValue("x-dd-drop-nodrop")]
        [Description("The CSS class returned to the drag source when drop is not allowed (defaults to \"x-dd-drop-nodrop\").")]
        public virtual string DropNotAllowed
        {
            get
            {
                return (string)this.ViewState["DropNotAllowed"] ?? "x-dd-drop-nodrop";
            }
            set
            {
                this.ViewState["DropNotAllowed"] = value;
            }
        }

        /// <summary>
        /// The CSS class applied to the drop target element while the drag source is over it (defaults to "").
        /// </summary>
        [ConfigOption]
        [Category("5. DropTarget")]
        [DefaultValue("")]
        [Description("The CSS class applied to the drop target element while the drag source is over it (defaults to \"\").")]
        public virtual string OverClass
        {
            get
            {
                return (string)this.ViewState["OverClass"] ?? "";
            }
            set
            {
                this.ViewState["OverClass"] = value;
            }
        }

        /// <summary>
        /// True to register this container with the Scrollmanager for auto scrolling during drag operations.
        /// </summary>
        [ConfigOption]
        [Category("5. DropTarget")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to register this container with the Scrollmanager for auto scrolling during drag operations.")]
        public virtual bool ContainerScroll
        {
            get
            {
                object obj = this.ViewState["ContainerScroll"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["ContainerScroll"] = value;
            }
        }

        private JFunction notifyDrop;

        /// <summary>
        /// The function a Ext.dd.DragSource calls once to notify this drop target that the dragged item has been dropped on it. This method has no default implementation and returns false, so you must provide an implementation that does something to process the drop event and returns true so that the drag source's repair action does not run.
        /// Parameters:
        ///    source : The drag source that was dragged over this drop target
        ///    e : The event
        ///    data : An object containing arbitrary data supplied by the drag source
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("5. DropTarget")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("The function a Ext.dd.DragSource calls once to notify this drop target that the dragged item has been dropped on it. This method has no default implementation and returns false, so you must provide an implementation that does something to process the drop event and returns true so that the drag source's repair action does not run.")]
        public virtual JFunction NotifyDrop
        {
            get
            {
                if (this.notifyDrop == null)
                {
                    this.notifyDrop = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.notifyDrop.Args = new string[] {"source", "e", "data"};
                    }
                }

                return this.notifyDrop;
            }
        }

        private JFunction notifyEnter;

        /// <summary>
        /// The function a Ext.dd.DragSource calls once to notify this drop target that the source is now over the target. This default implementation adds the CSS class specified by overClass (if any) to the drop element and returns the dropAllowed config value. This method should be overridden if drop validation is required.
        /// Parameters:
        ///    source : The drag source that was dragged over this drop target
        ///    e : The event
        ///    data : An object containing arbitrary data supplied by the drag source
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("5. DropTarget")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("The function a Ext.dd.DragSource calls once to notify this drop target that the source is now over the target. This default implementation adds the CSS class specified by overClass (if any) to the drop element and returns the dropAllowed config value. This method should be overridden if drop validation is required.")]
        public virtual JFunction NotifyEnter
        {
            get
            {
                if (this.notifyEnter == null)
                {
                    this.notifyEnter = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.notifyEnter.Args = new string[] {"source", "e", "data"};
                    }
                }

                return this.notifyEnter;
            }
        }

        private JFunction notifyOut;

        /// <summary>
        /// The function a Ext.dd.DragSource calls once to notify this drop target that the source has been dragged out of the target without dropping. This default implementation simply removes the CSS class specified by overClass (if any) from the drop element.
        /// Parameters:
        ///    source : The drag source that was dragged over this drop target
        ///    e : The event
        ///    data : An object containing arbitrary data supplied by the drag source
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("5. DropTarget")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("The function a Ext.dd.DragSource calls once to notify this drop target that the source has been dragged out of the target without dropping. This default implementation simply removes the CSS class specified by overClass (if any) from the drop element.")]
        public virtual JFunction NotifyOut
        {
            get
            {
                if (this.notifyOut == null)
                {
                    this.notifyOut = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.notifyOut.Args = new string[] {"source", "e", "data"};
                    }
                }

                return this.notifyOut;
            }
        }

        private JFunction notifyOver;

        /// <summary>
        /// The function a Ext.dd.DragSource calls continuously while it is being dragged over the target. This method will be called on every mouse movement while the drag source is over the drop target. This default implementation simply returns the dropAllowed config value.
        /// Parameters:
        ///    source : The drag source that was dragged over this drop target
        ///    e : The event
        ///    data : An object containing arbitrary data supplied by the drag source
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("5. DropTarget")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("The function a Ext.dd.DragSource calls continuously while it is being dragged over the target. This method will be called on every mouse movement while the drag source is over the drop target. This default implementation simply returns the dropAllowed config value.")]
        public virtual JFunction NotifyOver
        {
            get
            {
                if (this.notifyOver == null)
                {
                    this.notifyOver = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.notifyOver.Args = new string[] {"source", "e", "data"};
                    }
                }

                return this.notifyOver;
            }
        }
    }
}