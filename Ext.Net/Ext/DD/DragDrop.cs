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
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net.Utilities;
using Newtonsoft.Json;
using System.Drawing;

namespace Ext.Net
{
    /// <summary>
    /// Defines the interface and base operation of items that that can be dragged or can be drop targets. It was designed to be extended, overriding the event handlers for startDrag, onDrag, onDragOver and onDragOut. Up to three html elements can be associated with a DragDrop instance:
    ///    linked element: the element that is passed into the constructor. This is the element which defines the boundaries for interaction with other DragDrop objects.
    ///    handle element(s): The drag operation only occurs if the element that was clicked matches a handle element. By default this is the linked element, but there are times that you will want only a portion of the linked element to initiate the drag operation, and the setHandleElId() method provides a way to define this.
    ///    drag element: this represents the element that would be moved along with the cursor during a drag operation. By default, this is the linked element itself as in Ext.dd.DD. setDragElId() lets you define a separate element that would be moved, as in Ext.dd.DDProxy.
    /// </summary>
    [Description("Defines the interface and base operation of items that that can be dragged or can be drop targets.")]
    public abstract partial class DragDrop : Observable, ICustomConfigSerialization
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected new virtual bool DesignMode
        {
            get
            {
                try
                {
                    return HttpContext.Current == null;
                }
                catch (Exception)
                {
                    return true;
                }
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
                return "Ext.dd.DragDrop";
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption(JsonMode.Ignore)]
        [DefaultValue("")]
		[Description("")]
        protected override string ConfigIDProxy
        {
            get
            {
                return base.ConfigIDProxy;
            }
        }

        private Paddings defaultPadding;

        /// <summary>
        /// Provides default constraint padding to "constrainTo" elements (defaults to {left: 0, right:0, top:0, bottom:0}).
        /// </summary>
        [ConfigOption("defaultPadding", JsonMode.Raw)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Description("Provides default constraint padding to \"constrainTo\" elements (defaults to {left: 0, right:0, top:0, bottom:0}).")]
        //[DefaultValue("{top:0,right:0,bottom:0,left:0}")]
        [Category("3. DragDrop")]
        public Paddings DefaultPadding
        {
            get
            {
                if (this.defaultPadding == null)
                {
                    this.defaultPadding = new Paddings();
                }

                return this.defaultPadding;
            }
        }

        private DragDropGroups groups;

        /// <summary>
        /// The group defines a logical collection of DragDrop objects that are related. Instances only get events when interacting with other DragDrop object in the same group. This lets us define multiple groups using a single DragDrop subclass if we want.
        /// </summary>
        [ConfigOption("groups", JsonMode.Raw)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [DefaultValue(null)]
        [Category("3. DragDrop")]
        [Description("The group defines a logical collection of DragDrop objects that are related. Instances only get events when interacting with other DragDrop object in the same group. This lets us define multiple groups using a single DragDrop subclass if we want.")]
        public DragDropGroups Groups
        {
            get
            {
                if (this.groups == null)
                {
                    this.groups = new DragDropGroups();
                }

                return this.groups;
            }
        }

        /// <summary>
        /// By default, drags can only be initiated if the mousedown occurs in the region the linked element is. This is done in part to work around a bug in some browsers that mis-report the mousedown if the previous mouseup happened outside of the window. This property is set to true if outer handles are defined.
        /// </summary>
        [ConfigOption]
        [Category("3. DragDrop")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("By default, drags can only be initiated if the mousedown occurs in the region the linked element is. This is done in part to work around a bug in some browsers that mis-report the mousedown if the previous mouseup happened outside of the window. This property is set to true if outer handles are defined.")]
        public virtual bool HasOuterHandles
        {
            get
            {
                object obj = this.ViewState["HasOuterHandles"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["HasOuterHandles"] = value;
            }
        }

        /// <summary>
        /// ID of the element that is linked to this instance
        /// </summary>
        [Category("3. DragDrop")]
        [DefaultValue("")]
        [Description("ID of the element that is linked to this instance")]
        public virtual string Target
        {
            get
            {
                return (string)this.ViewState["Target"] ?? "";
            }
            set
            {
                this.ViewState["Target"] = value;
            }
        }

        /// <summary>
        /// The group of related DragDrop objects
        /// </summary>
        [Category("3. DragDrop")]
        [DefaultValue("default")]
        [Description("The group of related DragDrop objects")]
        public virtual string Group
        {
            get
            {
                return (string)this.ViewState["Group"] ?? "default";
            }
            set
            {
                this.ViewState["Group"] = value;
            }
        }

        /// <summary>
        /// Set to false to enable a DragDrop object to fire drag events while dragging over its own Element. Defaults to true - DragDrop objects do not by default fire drag events to themselves.
        /// </summary>
        [ConfigOption]
        [Category("3. DragDrop")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Set to false to enable a DragDrop object to fire drag events while dragging over its own Element. Defaults to true - DragDrop objects do not by default fire drag events to themselves.")]
        public virtual bool IgnoreSelf
        {
            get
            {
                object obj = this.ViewState["IgnoreSelf"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["IgnoreSelf"] = value;
            }
        }

        /// <summary>
        /// An Array of CSS class names for elements to be considered in valid as drag handles.
        /// </summary>
        [ConfigOption(typeof(StringArrayJsonConverter))]
        [TypeConverter(typeof(StringArrayConverter))]
        [Category("3. DragDrop")]
        [DefaultValue(null)]
        [Description("An Array of CSS class names for elements to be considered in valid as drag handles.")]
        public virtual string[] InvalidHandleClasses
        {
            get
            {
                object obj = this.ViewState["InvalidHandleClasses"];
                return (obj == null) ? null : (string[])obj;
            }
            set
            {
                this.ViewState["InvalidHandleClasses"] = value;
            }
        }

        /// <summary>
        /// An array who's items identify HTML tags to be considered invalid as drag handles.
        /// </summary>
        [TypeConverter(typeof(StringArrayConverter))]
        [Category("3. DragDrop")]
        [DefaultValue(null)]
        [Description("An array who's items identify HTML tags to be considered invalid as drag handles.")]
        public virtual string[] InvalidHandleTypes
        {
            get
            {
                object obj = this.ViewState["InvalidHandleTypes"];
                return (obj == null) ? null : (string[])obj;
            }
            set
            {
                this.ViewState["InvalidHandleTypes"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("invalidHandleTypes", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected virtual string InvalidHandleTypesProxy
        {
            get
            {
                if (this.InvalidHandleTypes == null || this.InvalidHandleTypes.Length == 0)
                {
                    return "";
                }

                StringBuilder sb = new StringBuilder();
                StringWriter sw = new StringWriter(sb);
                JsonTextWriter writer = new JsonTextWriter(sw);

                writer.WriteStartObject();

                foreach (string invalidHandleType in this.InvalidHandleTypes)
                {
                    writer.WritePropertyName(invalidHandleType);
                    writer.WriteValue(invalidHandleType);
                }

                writer.WriteEndObject();
                writer.Flush();

                return sw.GetStringBuilder().ToString();
            }
        }

        /// <summary>
        /// An array who's items identify the IDs of elements to be considered invalid as drag handles
        /// </summary>
        [TypeConverter(typeof(StringArrayConverter))]
        [Category("3. DragDrop")]
        [DefaultValue(null)]
        [Description("An array who's items identify the IDs of elements to be considered invalid as drag handles")]
        public virtual string[] InvalidHandleIds
        {
            get
            {
                object obj = this.ViewState["InvalidHandleIds"];
                return (obj == null) ? null : (string[])obj;
            }
            set
            {
                this.ViewState["InvalidHandleIds"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("invalidHandleIds", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected virtual string InvalidHandleIdsProxy
        {
            get
            {
                if (this.InvalidHandleIds == null || this.InvalidHandleIds.Length == 0)
                {
                    return "";
                }

                StringBuilder sb = new StringBuilder();
                StringWriter sw = new StringWriter(sb);
                JsonTextWriter writer = new JsonTextWriter(sw);

                writer.WriteStartObject();

                foreach (string invalidHandleId in this.InvalidHandleIds)
                {
                    writer.WritePropertyName(invalidHandleId);
                    writer.WriteValue(true);
                }

                writer.WriteEndObject();
                writer.Flush();

                return sw.GetStringBuilder().ToString();
            }
        }

        /// <summary>
        /// By default, all instances can be a drop target. This can be disabled by setting isTarget to false.
        /// </summary>
        [ConfigOption]
        [Category("3. DragDrop")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("By default, all instances can be a drop target. This can be disabled by setting isTarget to false.")]
        public virtual bool IsTarget
        {
            get
            {
                object obj = this.ViewState["IsTarget"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["IsTarget"] = value;
            }
        }

        /// <summary>
        /// Maintain offsets when we resetconstraints. Set to true when you want the position of the element relative to its parent to stay the same when the page changes
        /// </summary>
        [ConfigOption]
        [Category("3. DragDrop")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Maintain offsets when we resetconstraints. Set to true when you want the position of the element relative to its parent to stay the same when the page changes")]
        public virtual bool MaintainOffset
        {
            get
            {
                object obj = this.ViewState["MaintainOffset"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["MaintainOffset"] = value;
            }
        }

        /// <summary>
        /// When set to true, other DD objects in cooperating DDGroups do not receive notification events when this DD object is dragged over them. Defaults to false.
        /// </summary>
        [ConfigOption]
        [Category("3. DragDrop")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("When set to true, other DD objects in cooperating DDGroups do not receive notification events when this DD object is dragged over them. Defaults to false.")]
        public virtual bool MoveOnly
        {
            get
            {
                object obj = this.ViewState["MoveOnly"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["MoveOnly"] = value;
            }
        }

        /// <summary>
        /// An Array of CSS class names for elements to be considered in valid as drag handles.
        /// </summary>
        [ConfigOption(typeof(IntArrayJsonConverter))]
        [TypeConverter(typeof(IntArrayConverter))]
        [Category("3. DragDrop")]
        [DefaultValue(null)]
        [Description("An Array of CSS class names for elements to be considered in valid as drag handles.")]
        public virtual int[] Padding
        {
            get
            {
                object obj = this.ViewState["Padding"];
                return (obj == null) ? null : (int[])obj;
            }
            set
            {
                this.ViewState["Padding"] = value;
            }
        }

        /// <summary>
        /// By default the drag and drop instance will only respond to the primary button click (left button for a right-handed mouse). Set to true to allow drag and drop to start with any mouse click that is propogated by the browser
        /// </summary>
        [ConfigOption]
        [Category("3. DragDrop")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("By default the drag and drop instance will only respond to the primary button click (left button for a right-handed mouse). Set to true to allow drag and drop to start with any mouse click that is propogated by the browser")]
        public virtual bool PrimaryButtonOnly 
        {
            get
            {
                object obj = this.ViewState["PrimaryButtonOnly"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["PrimaryButtonOnly"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual string ToScript(Control owner)
        {
            return "this.{0}=new Ext.net.ProxyDDCreator({{target:{1},group:{2},config:{3},type:{4}}});".FormatWith(
                      this.ClientID,
                      this.ParsedTarget, 
                      JSON.Serialize(this.Group),
                      new ClientConfig().Serialize(this, true), 
                      this.InstanceOf);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual string ParsedTarget
        {
            get
            {
                string t = TokenUtils.ParseAndNormalize(this.Target);

                if (t.StartsWith("\""))
                {
                    return t;
                }

                return JSON.Serialize(t);
            }
        }

        /// <summary>
        /// Array of pixel locations the element will snap to if we specified a horizontal graduation/interval. This array is generated automatically when you define a tick interval.
        /// </summary>
        [ConfigOption(typeof(IntArrayJsonConverter))]
        [TypeConverter(typeof(IntArrayConverter))]
        [Category("3. DragDrop")]
        [DefaultValue(null)]
        [Description("Array of pixel locations the element will snap to if we specified a horizontal graduation/interval. This array is generated automatically when you define a tick interval.")]
        public virtual int[] XTicks
        {
            get
            {
                object obj = this.ViewState["XTicks"];
                return (obj == null) ? null : (int[])obj;
            }
            set
            {
                this.ViewState["XTicks"] = value;
            }
        }

        /// <summary>
        /// Array of pixel locations the element will snap to if we specified a vertical graduation/interval. This array is generated automatically when you define a tick interval.
        /// </summary>
        [ConfigOption(typeof(IntArrayJsonConverter))]
        [TypeConverter(typeof(IntArrayConverter))]
        [Category("3. DragDrop")]
        [DefaultValue(null)]
        [Description("Array of pixel locations the element will snap to if we specified a vertical graduation/interval. This array is generated automatically when you define a tick interval.")]
        public virtual int[] YTicks
        {
            get
            {
                object obj = this.ViewState["YTicks"];
                return (obj == null) ? null : (int[])obj;
            }
            set
            {
                this.ViewState["YTicks"] = value;
            }
        }

        private JFunction endDrag;

        /// <summary>
        /// Fired when we are done dragging the object
        /// Parameters:
        ///     e : the mouseup event
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("3. DragDrop")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Fired when we are done dragging the object")]
        public virtual JFunction EndDrag
        {
            get
            {
                if (this.endDrag == null)
                {
                    this.endDrag = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.endDrag.Args = new string[] { "e" };    
                    }
                }

                return this.endDrag;
            }
        }

        private JFunction onAvailable;

        /// <summary>
        /// Override the onAvailable method to do what is needed after the initial position was determined.
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("3. DragDrop")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Override the onAvailable method to do what is needed after the initial position was determined.")]
        public virtual JFunction OnAvailable
        {
            get
            {
                if (this.onAvailable == null)
                {
                    this.onAvailable = new JFunction();
                }

                return this.onAvailable;
            }
        }

        private JFunction onDrag;

        /// <summary>
        /// Abstract method called during the onMouseMove event while dragging an object.
        /// Parameters:
        ///     e : the mouseup event
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("3. DragDrop")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Abstract method called during the onMouseMove event while dragging an object.")]
        public virtual JFunction OnDrag
        {
            get
            {
                if (this.onDrag == null)
                {
                    this.onDrag = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.onDrag.Args = new string[] {"e"};
                    }
                }

                return this.onDrag;
            }
        }

        private JFunction onDragDrop;

        /// <summary>
        /// Abstract method called when this item is dropped on another DragDrop obj
        /// Parameters:
        ///     e  : the mouseup event
        ///     id : In POINT mode, the element id this was dropped on. In INTERSECT mode, an array of dd items this was dropped on.
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("3. DragDrop")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Abstract method called when this item is dropped on another DragDrop obj")]
        public virtual JFunction OnDragDrop
        {
            get
            {
                if (this.onDragDrop == null)
                {
                    this.onDragDrop = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.onDragDrop.Args = new string[] {"e", "id"};
                    }
                }

                return this.onDragDrop;
            }
        }

        private JFunction onDragEnter;

        /// <summary>
        /// Abstract method called when this element fist begins hovering over another DragDrop obj
        /// Parameters:
        ///     e  : the mouseup event
        ///     id : In POINT mode, the element id this is hovering over. In INTERSECT mode, an array of one or more dragdrop items being hovered over.
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("3. DragDrop")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Abstract method called when this element fist begins hovering over another DragDrop obj")]
        public virtual JFunction OnDragEnter
        {
            get
            {
                if (this.onDragEnter == null)
                {
                    this.onDragEnter = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.onDragEnter.Args = new string[] {"e", "id"};
                    }
                }

                return this.onDragEnter;
            }
        }

        private JFunction onDragOut;

        /// <summary>
        /// Abstract method called when we are no longer hovering over an element
        /// Parameters:
        ///     e  : the mouseup event
        ///     id : In POINT mode, the element id this was hovering over. In INTERSECT mode, an array of dd items that the mouse is no longer over.
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("3. DragDrop")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Abstract method called when we are no longer hovering over an element")]
        public virtual JFunction OnDragOut
        {
            get
            {
                if (this.onDragOut == null)
                {
                    this.onDragOut = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.onDragOut.Args = new string[] {"e", "id"};
                    }
                }

                return this.onDragOut;
            }
        }

        private JFunction onDragOver;

        /// <summary>
        /// Abstract method called when this element is hovering over another DragDrop obj
        /// Parameters:
        ///     e  : the mouseup event
        ///     id : In POINT mode, the element id this is hovering over. In INTERSECT mode, an array of dd items being hovered over.
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("3. DragDrop")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Abstract method called when this element is hovering over another DragDrop obj")]
        public virtual JFunction OnDragOver
        {
            get
            {
                if (this.onDragOver == null)
                {
                    this.onDragOver = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.onDragOver.Args = new string[] {"e", "id"};
                    }
                }

                return this.onDragOver;
            }
        }

        private JFunction onInvalidDrop;

        /// <summary>
        /// Abstract method called when this item is dropped on an area with no drop target
        /// Parameters:
        ///     e  : the mouseup event
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("3. DragDrop")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Abstract method called when this item is dropped on an area with no drop target")]
        public virtual JFunction OnInvalidDrop
        {
            get
            {
                if (this.onInvalidDrop == null)
                {
                    this.onInvalidDrop = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.onInvalidDrop.Args = new string[] {"e"};
                    }
                }

                return this.onInvalidDrop;
            }
        }

        private JFunction onMouseDown;

        /// <summary>
        /// Event handler that fires when a drag/drop obj gets a mousedown
        /// Parameters:
        ///     e  : the mousedown event
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("3. DragDrop")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Event handler that fires when a drag/drop obj gets a mousedown")]
        public virtual JFunction OnMouseDown
        {
            get
            {
                if (this.onMouseDown == null)
                {
                    this.onMouseDown = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.onMouseDown.Args = new string[] {"e"};
                    }
                }

                return this.onMouseDown;
            }
        }

        private JFunction onMouseUp;

        /// <summary>
        /// Event handler that fires when a drag/drop obj gets a mouseup
        /// Parameters:
        ///     e  : the mousedown event
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("3. DragDrop")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Event handler that fires when a drag/drop obj gets a mouseup")]
        public virtual JFunction OnMouseUp
        {
            get
            {
                if (this.onMouseUp == null)
                {
                    this.onMouseUp = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.onMouseUp.Args = new string[] {"e"};
                    }
                }

                return this.onMouseUp;
            }
        }
        private JFunction startDrag;

        /// <summary>
        /// Abstract method called after a drag/drop object is clicked and the drag or mousedown time thresholds have beeen met.
        /// Parameters:
        ///     x  : click location
        ///     y  : click location
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("3. DragDrop")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Event handler that fires when a drag/drop obj gets a mouseup")]
        public virtual JFunction StartDrag
        {
            get
            {
                if (this.startDrag == null)
                {
                    this.startDrag = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.startDrag.Args = new string[] {"x", "y"};
                    }
                }

                return this.startDrag;
            }
        }

        //public methods

        /// <summary>
        /// Lets you specify a css class of elements that will not initiate a drag
        /// </summary>
        /// <param name="cssClass">the class of the elements you wish to ignore</param>
        public void AddInvalidHandleClass(string cssClass)
        {
            this.Call("addInvalidHandleClass", cssClass);
        }

        /// <summary>
        /// Lets you to specify an element id for a child of a drag handle that should not initiate a drag
        /// </summary>
        /// <param name="id">the element id of the element you wish to ignore</param>
        public void AddInvalidHandleId(string id)
        {
            this.Call("addInvalidHandleId", id);
        }

        /// <summary>
        /// Allows you to specify a tag name that should not start a drag operation when clicked. This is designed to facilitate embedding links within a drag handle that do something other than start the drag.
        /// </summary>
        /// <param name="tagName">the type of element to exclude</param>
        public void AddInvalidHandleType(string tagName)
        {
            this.Call("addInvalidHandleType", tagName);
        }

        /// <summary>
        /// Add this instance to a group of related drag/drop objects. All instances belong to at least one group, and can belong to as many groups as needed.
        /// </summary>
        /// <param name="sGroup">the name of the group</param>
        public void AddToGroup(string sGroup)
        {
            this.Call("addToGroup", sGroup);
        }

        /// <summary>
        /// Applies the configuration parameters that were passed into the constructor. This is supposed to happen at each level through the inheritance chain. So a DDProxy implentation will execute apply config on DDProxy, DD, and DragDrop in order to get all of the parameters that are available in each object.
        /// </summary>
        public void ApplyConfig()
        {
            this.Call("applyConfig");
        }

        /// <summary>
        /// Clears any constraints applied to this instance. Also clears ticks since they can't exist independent of a constraint at this time.
        /// </summary>
        public void ClearConstraints()
        {
            this.Call("clearConstraints");
        }

        /// <summary>
        /// Clears any tick interval defined for this instance
        /// </summary>
        public void ClearTicks()
        {
            this.Call("clearTicks");
        }

        /// <summary>
        /// Initializes the drag drop object's constraints to restrict movement to a certain element.
        /// </summary>
        /// <param name="constrainTo">The element to constrain to.</param>
        /// <param name="pad">Pad provides a way to specify "padding" of the constraints</param>
        /// <param name="inContent">Constrain the draggable in the content box of the element (inside padding and borders)</param>
        public void ConstrainTo(string constrainTo, Paddings pad, bool inContent)
        {
            this.Call("constrainTo", 
                new JRawValue(string.Concat("Ext.net.getEl(", TokenUtils.ParseAndNormalize(constrainTo), ")")), 
                new JRawValue(pad.ToString()),
                inContent);
        }

        /// <summary>
        /// Initializes the drag drop object's constraints to restrict movement to a certain element.
        /// </summary>
        /// <param name="constrainTo">The element to constrain to.</param>
        public void ConstrainTo(string constrainTo)
        {
            this.Call("constrainTo",new JRawValue(string.Concat("Ext.net.getEl(", TokenUtils.ParseAndNormalize(constrainTo), ")")));
        }

        /// <summary>
        /// Lock this instance
        /// </summary>
        public void Lock()
        {
            this.Call("lock");
        }

        /// <summary>
        /// Remove's this instance from the supplied interaction group
        /// </summary>
        /// <param name="sGroup">The group to drop</param>
        public void RemoveFromGroup(string sGroup)
        {
            this.Call("removeFromGroup", sGroup);
        }

        /// <summary>
        /// Unsets an invalid css class
        /// </summary>
        /// <param name="cssClass">the class of the element(s) you wish to re-enable</param>
        public void RemoveInvalidHandleClass(string cssClass)
        {
            this.Call("removeInvalidHandleClass", cssClass);
        }

        /// <summary>
        /// Unsets an invalid handle id
        /// </summary>
        /// <param name="id">the id of the element to re-enable</param>
        public void RemoveInvalidHandleId(string id)
        {
            this.Call("removeInvalidHandleId", id);
        }

        /// <summary>
        /// Unsets an excluded tag name set by addInvalidHandleType
        /// </summary>
        /// <param name="tagName">the type of element to unexclude</param>
        public void RemoveInvalidHandleType(string tagName)
        {
            this.Call("removeInvalidHandleType", tagName);
        }

        /// <summary>
        /// resetConstraints must be called if you manually reposition a dd element.
        /// </summary>
        /// <param name="maintainOffset"></param>
        public void ResetConstraints(bool maintainOffset)
        {
            this.Call("resetConstraints", maintainOffset);
        }

        /// <summary>
        /// Allows you to specify that an element other than the linked element will be moved with the cursor during a drag
        /// </summary>
        /// <param name="id">the id of the element that will be used to initiate the drag</param>
        public void SetDragElId(string id)
        {
            this.Call("setDragElId", id);
        }

        /// <summary>
        /// Allows you to specify a child of the linked element that should be used to initiate the drag operation. An example of this would be if you have a content div with text and links. Clicking anywhere in the content area would normally start the drag operation. Use this method to specify that an element inside of the content div is the element that starts the drag operation.
        /// </summary>
        /// <param name="id">the id of the element that will be used to initiate the drag.</param>
        public void SetHandleElId(string id)
        {
            this.Call("setHandleElId", id);
        }

        /// <summary>
        /// Stores the initial placement of the linked element.
        /// </summary>
        /// <param name="diffX">the X offset, default 0</param>
        /// <param name="diffY">the Y offset, default 0</param>
        public void SetInitPosition(int diffX, int diffY)
        {
            this.Call("setInitPosition", diffX, diffY);
        }

        /// <summary>
        /// Allows you to set an element outside of the linked element as a drag handle
        /// </summary>
        /// <param name="id">id of the element that will be used to initiate the drag</param>
        public void SetOuterHandleElId(string id)
        {
            this.Call("setOuterHandleElId", id);
        }

        /// <summary>
        /// Configures the padding for the target zone in px. Effectively expands (or reduces) the virtual object size for targeting calculations. Supports css-style shorthand; if only one parameter is passed, all sides will have that padding, and if only two are passed, the top and bottom will have the first param, the left and right the second.
        /// </summary>
        /// <param name="iTop">Top pad</param>
        /// <param name="iRight">Right pad</param>
        /// <param name="iBot">Bot pad</param>
        /// <param name="iLeft">Left pad</param>
        public void SetPadding(int iTop, int iRight, int iBot, int iLeft)
        {
            this.Call("setPadding", iTop, iRight, iBot, iLeft);
        }

        /// <summary>
        /// By default, the element can be dragged any place on the screen. Use this method to limit the horizontal travel of the element. Pass in 0,0 for the parameters if you want to lock the drag to the y axis.
        /// </summary>
        /// <param name="iLeft">the number of pixels the element can move to the left</param>
        /// <param name="iRight">the number of pixels the element can move to the right</param>
        /// <param name="iTickSize">optional parameter for specifying that the element should move iTickSize pixels at a time.</param>
        public void SetXConstraint(int iLeft, int iRight, int iTickSize)
        {
            this.Call("setXConstraint", iLeft, iRight, iTickSize);
        }

        /// <summary>
        /// By default, the element can be dragged any place on the screen. Set this to limit the vertical travel of the element. Pass in 0,0 for the parameters if you want to lock the drag to the x axis.
        /// </summary>
        /// <param name="iUp">the number of pixels the element can move up</param>
        /// <param name="iDown">the number of pixels the element can move down</param>
        /// <param name="iTickSize">optional parameter for specifying that the element should move iTickSize pixels at a time.</param>
        public void SetYConstraint(int iUp, int iDown, int iTickSize)
        {
            this.Call("setYConstraint", iUp, iDown, iTickSize);
        }

        /// <summary>
        /// Unlock this instace
        /// </summary>
        public void Unlock()
        {
            this.Call("unlock");
        }

        /// <summary>
        /// Remove all drag and drop hooks for this element
        /// </summary>
        public void Unreg()
        {
            this.Call("unreg");
        }

        /// <summary>
        /// 
        /// </summary>
        public void Destroy()
        {
            this.Call("destroy");
        }
    }
}