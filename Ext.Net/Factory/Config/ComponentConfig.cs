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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    public abstract partial class Component
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : Observable.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			        
			private ItemsCollection<Observable> bin = null;

			/// <summary>
			/// 
			/// </summary>
			public ItemsCollection<Observable> Bin
			{
				get
				{
					if (this.bin == null)
					{
						this.bin = new ItemsCollection<Observable>();
					}
			
					return this.bin;
				}
			}
			
			private string html = "";

			/// <summary>
			/// An HTML fragment, or a DomHelper specification to use as the layout element content (defaults to '')
			/// </summary>
			[DefaultValue("")]
			public virtual string Html 
			{ 
				get
				{
					return this.html;
				}
				set
				{
					this.html = value;
				}
			}

			private string anchor = null;

			/// <summary>
			/// This config is only used when this Component is rendered by a Container which has been configured to use an AnchorLayout based layout manager
			/// </summary>
			[DefaultValue(null)]
			public virtual string Anchor 
			{ 
				get
				{
					return this.anchor;
				}
				set
				{
					this.anchor = value;
				}
			}

			private string defaultAnchor = null;

			/// <summary>
			/// The DefaultAnchor is applied as the Anchor config item to all child Items during render.
			/// </summary>
			[DefaultValue(null)]
			public virtual string DefaultAnchor 
			{ 
				get
				{
					return this.defaultAnchor;
				}
				set
				{
					this.defaultAnchor = value;
				}
			}

			private string anchorHorizontal = "";

			/// <summary>
			/// See Anchor property
			/// </summary>
			[DefaultValue("")]
			public virtual string AnchorHorizontal 
			{ 
				get
				{
					return this.anchorHorizontal;
				}
				set
				{
					this.anchorHorizontal = value;
				}
			}

			private string anchorVertical = "";

			/// <summary>
			/// See Anchor property
			/// </summary>
			[DefaultValue("")]
			public virtual string AnchorVertical 
			{ 
				get
				{
					return this.anchorVertical;
				}
				set
				{
					this.anchorVertical = value;
				}
			}

			private double columnWidth = 0.0;

			/// <summary>
			/// The ColumnWidth property is only used with ColumnLayout is used. The ColumnWidth property is always evaluated as a percentage, and must be a decimal value greater than 0 and less than 1.
			/// </summary>
			[DefaultValue(0.0)]
			public virtual double ColumnWidth 
			{ 
				get
				{
					return this.columnWidth;
				}
				set
				{
					this.columnWidth = value;
				}
			}

			private bool isFormField = false;

			/// <summary>
			/// True if component should be rendered as a Form Field with a Field Label and Label separator (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool IsFormField 
			{ 
				get
				{
					return this.isFormField;
				}
				set
				{
					this.isFormField = value;
				}
			}

			private string labelSeparator = ":";

			/// <summary>
			/// The separator to display after the text of each fieldLabel. This property may be configured at various levels.
			/// </summary>
			[DefaultValue(":")]
			public virtual string LabelSeparator 
			{ 
				get
				{
					return this.labelSeparator;
				}
				set
				{
					this.labelSeparator = value;
				}
			}

			private string labelStyle = "";

			/// <summary>
			/// A CSS style specification string to apply directly to this field's label. Defaults to the container's labelStyle value if set (eg, Ext.layout.FormLayout.labelStyle , or '').
			/// </summary>
			[DefaultValue("")]
			public virtual string LabelStyle 
			{ 
				get
				{
					return this.labelStyle;
				}
				set
				{
					this.labelStyle = value;
				}
			}

			private bool hideLabels = false;

			/// <summary>
			/// True to hide field labels by default (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool HideLabels 
			{ 
				get
				{
					return this.hideLabels;
				}
				set
				{
					this.hideLabels = value;
				}
			}

			private LabelAlign labelAlign = LabelAlign.Left;

			/// <summary>
			/// The default label alignment. The default value is empty string '' for left alignment, but specifying 'top' will align the labels above the fields.
			/// </summary>
			[DefaultValue(LabelAlign.Left)]
			public virtual LabelAlign LabelAlign 
			{ 
				get
				{
					return this.labelAlign;
				}
				set
				{
					this.labelAlign = value;
				}
			}

			private int labelWidth = 100;

			/// <summary>
			/// The default width in pixels of field labels (defaults to 100).
			/// </summary>
			[DefaultValue(100)]
			public virtual int LabelWidth 
			{ 
				get
				{
					return this.labelWidth;
				}
				set
				{
					this.labelWidth = value;
				}
			}

			private int labelPad = 5;

			/// <summary>
			/// The default padding in pixels for field labels (defaults to 5). labelPad only applies if labelWidth is also specified, otherwise it will be ignored.
			/// </summary>
			[DefaultValue(5)]
			public virtual int LabelPad 
			{ 
				get
				{
					return this.labelPad;
				}
				set
				{
					this.labelPad = value;
				}
			}

			private int flex = 0;

			/// <summary>
			/// NOTE: This property is only used when the parent Layout is HBoxLayout or VBoxLayout. This configuation option is to be applied to child items of the container managed by this layout. Each child item with a flex property will be flexed horizontally according to each item's relative flex value compared to the sum of all items with a flex value specified. Any child items that have either a flex = 0 or flex = undefined will not be 'flexed' (the initial size will not be changed).
			/// </summary>
			[DefaultValue(0)]
			public virtual int Flex 
			{ 
				get
				{
					return this.flex;
				}
				set
				{
					this.flex = value;
				}
			}

			private double rowHeight = 0.0;

			/// <summary>
			/// The ColumnWidth property is always evaluated as a percentage, and must be a decimal value greater than 0 and less than or equal to 1.0.
			/// </summary>
			[DefaultValue(0.0)]
			public virtual double RowHeight 
			{ 
				get
				{
					return this.rowHeight;
				}
				set
				{
					this.rowHeight = value;
				}
			}

			private bool allowDomMove = true;

			/// <summary>
			/// Whether the component can move the Dom node when rendering (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AllowDomMove 
			{ 
				get
				{
					return this.allowDomMove;
				}
				set
				{
					this.allowDomMove = value;
				}
			}

			private string applyTo = "";

			/// <summary>
			/// Specify the id of the element, a DOM element or an existing Element corresponding to a DIV that is already present in the document that specifies some structural markup for this component.
			/// </summary>
			[DefaultValue("")]
			public virtual string ApplyTo 
			{ 
				get
				{
					return this.applyTo;
				}
				set
				{
					this.applyTo = value;
				}
			}
        
			private DomObject autoEl = null;

			/// <summary>
			/// A tag name or DomHelper spec used to create the Element which will encapsulate this Component.
			/// </summary>
			public DomObject AutoEl
			{
				get
				{
					if (this.autoEl == null)
					{
						this.autoEl = new DomObject();
					}
			
					return this.autoEl;
				}
			}
			
			private bool autoShow = false;

			/// <summary>
			/// True if the component should check for hidden classes (e.g. 'x-hidden' or 'x-hide-display') and remove them on render (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AutoShow 
			{ 
				get
				{
					return this.autoShow;
				}
				set
				{
					this.autoShow = value;
				}
			}

			private string clearCls = "x-form-clear-left";

			/// <summary>
			/// The CSS class used to to apply to the special clearing div rendered directly after each form field wrapper to provide field clearing (defaults to 'x-form-clear-left').
			/// </summary>
			[DefaultValue("x-form-clear-left")]
			public virtual string ClearCls 
			{ 
				get
				{
					return this.clearCls;
				}
				set
				{
					this.clearCls = value;
				}
			}

			private string cls = "";

			/// <summary>
			/// An optional extra CSS class that will be added to this component's Element (defaults to ''). This can be useful for adding customized styles to the component or any of its children using standard CSS rules.
			/// </summary>
			[DefaultValue("")]
			public virtual string Cls 
			{ 
				get
				{
					return this.cls;
				}
				set
				{
					this.cls = value;
				}
			}

			private string ctCls = "";

			/// <summary>
			/// An optional extra CSS class that will be added to this component's container. This can be useful for adding customized styles to the container or any of its children using standard CSS rules.
			/// </summary>
			[DefaultValue("")]
			public virtual string CtCls 
			{ 
				get
				{
					return this.ctCls;
				}
				set
				{
					this.ctCls = value;
				}
			}

			private bool disabled = false;

			/// <summary>
			/// Render this component disabled (default is false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Disabled 
			{ 
				get
				{
					return this.disabled;
				}
				set
				{
					this.disabled = value;
				}
			}

			private bool selectable = true;

			/// <summary>
			/// Determines if this component is selectable. (default is true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool Selectable 
			{ 
				get
				{
					return this.selectable;
				}
				set
				{
					this.selectable = value;
				}
			}

			private string disabledClass = "";

			/// <summary>
			/// CSS class added to the component when it is disabled (defaults to 'x-item-disabled').
			/// </summary>
			[DefaultValue("")]
			public virtual string DisabledClass 
			{ 
				get
				{
					return this.disabledClass;
				}
				set
				{
					this.disabledClass = value;
				}
			}

			private string fieldLabel = "";

			/// <summary>
			/// The label text to display next to this Component (defaults to '').
			/// </summary>
			[DefaultValue("")]
			public virtual string FieldLabel 
			{ 
				get
				{
					return this.fieldLabel;
				}
				set
				{
					this.fieldLabel = value;
				}
			}

			private bool hidden = false;

			/// <summary>
			/// Render this component hidden (default is false). If true, the hide method will be called internally.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Hidden 
			{ 
				get
				{
					return this.hidden;
				}
				set
				{
					this.hidden = value;
				}
			}

			private bool hideLabel = false;

			/// <summary>
			/// true to completely hide the label element (label and separator). Defaults to false. By default, even if you do not specify a fieldLabel the space will still be reserved so that the field will line up with other fields that do have labels. Setting this to true will cause the field to not reserve that space.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool HideLabel 
			{ 
				get
				{
					return this.hideLabel;
				}
				set
				{
					this.hideLabel = value;
				}
			}

			private HideMode hideMode = HideMode.Display;

			/// <summary>
			/// How this component should be hidden. Supported values are 'visibility' (css visibility), 'offsets' (negative offset position) and 'display' (css display).
			/// </summary>
			[DefaultValue(HideMode.Display)]
			public virtual HideMode HideMode 
			{ 
				get
				{
					return this.hideMode;
				}
				set
				{
					this.hideMode = value;
				}
			}

			private bool hideParent = false;

			/// <summary>
			/// True to hide and show the component's container when hide/show is called on the component, false to hide and show the component itself (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool HideParent 
			{ 
				get
				{
					return this.hideParent;
				}
				set
				{
					this.hideParent = value;
				}
			}

			private string itemCls = "";

			/// <summary>
			/// An additional CSS class to apply to the div wrapping the form item element of this field.
			/// </summary>
			[DefaultValue("")]
			public virtual string ItemCls 
			{ 
				get
				{
					return this.itemCls;
				}
				set
				{
					this.itemCls = value;
				}
			}

			private string overCls = "";

			/// <summary>
			/// An optional extra CSS class that will be added to this component's Element when the mouse moves over the Element, and removed when the mouse moves out. (defaults to '').
			/// </summary>
			[DefaultValue("")]
			public virtual string OverCls 
			{ 
				get
				{
					return this.overCls;
				}
				set
				{
					this.overCls = value;
				}
			}

			private string pType = "";

			/// <summary>
			/// The registered ptype to create. This config option is not used when passing a config object into a constructor. This config option is used only when lazy instantiation is being used, and a Plugin is being specified not as a fully instantiated Component, but as a Component config object. The ptype will be looked up at render time up to determine what type of Plugin to create.
			/// </summary>
			[DefaultValue("")]
			public virtual string PType 
			{ 
				get
				{
					return this.pType;
				}
				set
				{
					this.pType = value;
				}
			}

			private string _ref = "";

			/// <summary>
			/// A path specification, relative to the Component's ownerCt specifying into which ancestor Container to place a named reference to this Component. The ancestor axis can be traversed by using '/' characters in the path.
			/// </summary>
			[DefaultValue("")]
			public virtual string Ref 
			{ 
				get
				{
					return this._ref;
				}
				set
				{
					this._ref = value;
				}
			}

			private string renderTo = "";

			/// <summary>
			/// The id of the node, a DOM node or an existing Element that will be the content Container to render this component into.
			/// </summary>
			[DefaultValue("")]
			public virtual string RenderTo 
			{ 
				get
				{
					return this.renderTo;
				}
				set
				{
					this.renderTo = value;
				}
			}

			private string[] stateEvents = null;

			/// <summary>
			/// An array of events that, when fired, should trigger this component to save its state (defaults to none). These can be any types of events supported by this component, including browser or custom events (e.g., ['click', 'customerchange']).
			/// </summary>
			[DefaultValue(null)]
			public virtual string[] StateEvents 
			{ 
				get
				{
					return this.stateEvents;
				}
				set
				{
					this.stateEvents = value;
				}
			}

			private string stateID = "";

			/// <summary>
			/// The unique id for this component to use for state management purposes (defaults to the component id).
			/// </summary>
			[DefaultValue("")]
			public virtual string StateID 
			{ 
				get
				{
					return this.stateID;
				}
				set
				{
					this.stateID = value;
				}
			}

			private bool stateful = true;

			/// <summary>
			/// A flag which causes the Component to attempt to restore the state of internal properties from a saved state on startup.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool Stateful 
			{ 
				get
				{
					return this.stateful;
				}
				set
				{
					this.stateful = value;
				}
			}

			private string styleSpec = "";

			/// <summary>
			/// A custom style specification to be applied to this component's Element.
			/// </summary>
			[DefaultValue("")]
			public virtual string StyleSpec 
			{ 
				get
				{
					return this.styleSpec;
				}
				set
				{
					this.styleSpec = value;
				}
			}
        
			private ItemsCollection<Plugin> plugins = null;

			/// <summary>
			/// An object or array of controls that inherit from IPlugin that will provide custom functionality for this component. The only requirement for a valid plugin is that it contain an init method that accepts a reference of type Ext.Component. When a component is created, if any plugins are available, the component will call the init method on each plugin, passing a reference to itself. Each plugin can then call methods or respond to events on the component as needed to provide its functionality.
			/// </summary>
			public ItemsCollection<Plugin> Plugins
			{
				get
				{
					if (this.plugins == null)
					{
						this.plugins = new ItemsCollection<Plugin>();
					}
			
					return this.plugins;
				}
			}
			
			private bool autoRender = true;

			/// <summary>
			/// Automatically render control on client during page load. Default is true.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AutoRender 
			{ 
				get
				{
					return this.autoRender;
				}
				set
				{
					this.autoRender = value;
				}
			}
        
			private ItemsCollection<ToolTip> toolTips = null;

			/// <summary>
			/// A collection of ToolTip configs used to add ToolTips to the Component
			/// </summary>
			public ItemsCollection<ToolTip> ToolTips
			{
				get
				{
					if (this.toolTips == null)
					{
						this.toolTips = new ItemsCollection<ToolTip>();
					}
			
					return this.toolTips;
				}
			}
			
			private bool autoFocus = false;

			/// <summary>
			/// True to automatically set the focus after render (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AutoFocus 
			{ 
				get
				{
					return this.autoFocus;
				}
				set
				{
					this.autoFocus = value;
				}
			}

			private int autoFocusDelay = 10;

			/// <summary>
			/// Focus delay (in milliseconds) when AutoFocus is true.
			/// </summary>
			[DefaultValue(10)]
			public virtual int AutoFocusDelay 
			{ 
				get
				{
					return this.autoFocusDelay;
				}
				set
				{
					this.autoFocusDelay = value;
				}
			}

        }
    }
}