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
        new public abstract partial class Builder<TComponent, TBuilder> : Observable.Builder<TComponent, TBuilder>
            where TComponent : Component
            where TBuilder : Builder<TComponent, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TComponent component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			// /// <summary>
			// /// 
			// /// </summary>
            // public virtual TBuilder Bin(ItemsCollection<Observable> bin)
            // {
            //    this.ToComponent().Bin = bin;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// An HTML fragment, or a DomHelper specification to use as the layout element content (defaults to '')
			/// </summary>
            public virtual TBuilder Html(string html)
            {
                this.ToComponent().Html = html;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// This config is only used when this Component is rendered by a Container which has been configured to use an AnchorLayout based layout manager
			/// </summary>
            public virtual TBuilder Anchor(string anchor)
            {
                this.ToComponent().Anchor = anchor;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The DefaultAnchor is applied as the Anchor config item to all child Items during render.
			/// </summary>
            public virtual TBuilder DefaultAnchor(string defaultAnchor)
            {
                this.ToComponent().DefaultAnchor = defaultAnchor;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// See Anchor property
			/// </summary>
            public virtual TBuilder AnchorHorizontal(string anchorHorizontal)
            {
                this.ToComponent().AnchorHorizontal = anchorHorizontal;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// See Anchor property
			/// </summary>
            public virtual TBuilder AnchorVertical(string anchorVertical)
            {
                this.ToComponent().AnchorVertical = anchorVertical;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The ColumnWidth property is only used with ColumnLayout is used. The ColumnWidth property is always evaluated as a percentage, and must be a decimal value greater than 0 and less than 1.
			/// </summary>
            public virtual TBuilder ColumnWidth(double columnWidth)
            {
                this.ToComponent().ColumnWidth = columnWidth;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True if component should be rendered as a Form Field with a Field Label and Label separator (defaults to false).
			/// </summary>
            public virtual TBuilder IsFormField(bool isFormField)
            {
                this.ToComponent().IsFormField = isFormField;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The separator to display after the text of each fieldLabel. This property may be configured at various levels.
			/// </summary>
            public virtual TBuilder LabelSeparator(string labelSeparator)
            {
                this.ToComponent().LabelSeparator = labelSeparator;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A CSS style specification string to apply directly to this field's label. Defaults to the container's labelStyle value if set (eg, Ext.layout.FormLayout.labelStyle , or '').
			/// </summary>
            public virtual TBuilder LabelStyle(string labelStyle)
            {
                this.ToComponent().LabelStyle = labelStyle;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to hide field labels by default (defaults to false).
			/// </summary>
            public virtual TBuilder HideLabels(bool hideLabels)
            {
                this.ToComponent().HideLabels = hideLabels;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The default label alignment. The default value is empty string '' for left alignment, but specifying 'top' will align the labels above the fields.
			/// </summary>
            public virtual TBuilder LabelAlign(LabelAlign labelAlign)
            {
                this.ToComponent().LabelAlign = labelAlign;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The default width in pixels of field labels (defaults to 100).
			/// </summary>
            public virtual TBuilder LabelWidth(int labelWidth)
            {
                this.ToComponent().LabelWidth = labelWidth;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The default padding in pixels for field labels (defaults to 5). labelPad only applies if labelWidth is also specified, otherwise it will be ignored.
			/// </summary>
            public virtual TBuilder LabelPad(int labelPad)
            {
                this.ToComponent().LabelPad = labelPad;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// NOTE: This property is only used when the parent Layout is HBoxLayout or VBoxLayout. This configuation option is to be applied to child items of the container managed by this layout. Each child item with a flex property will be flexed horizontally according to each item's relative flex value compared to the sum of all items with a flex value specified. Any child items that have either a flex = 0 or flex = undefined will not be 'flexed' (the initial size will not be changed).
			/// </summary>
            public virtual TBuilder Flex(int flex)
            {
                this.ToComponent().Flex = flex;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The ColumnWidth property is always evaluated as a percentage, and must be a decimal value greater than 0 and less than or equal to 1.0.
			/// </summary>
            public virtual TBuilder RowHeight(double rowHeight)
            {
                this.ToComponent().RowHeight = rowHeight;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Whether the component can move the Dom node when rendering (defaults to true).
			/// </summary>
            public virtual TBuilder AllowDomMove(bool allowDomMove)
            {
                this.ToComponent().AllowDomMove = allowDomMove;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Specify the id of the element, a DOM element or an existing Element corresponding to a DIV that is already present in the document that specifies some structural markup for this component.
			/// </summary>
            public virtual TBuilder ApplyTo(string applyTo)
            {
                this.ToComponent().ApplyTo = applyTo;
                return this as TBuilder;
            }
             
 			// /// <summary>
			// /// A tag name or DomHelper spec used to create the Element which will encapsulate this Component.
			// /// </summary>
            // public virtual TBuilder AutoEl(DomObject autoEl)
            // {
            //    this.ToComponent().AutoEl = autoEl;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// True if the component should check for hidden classes (e.g. 'x-hidden' or 'x-hide-display') and remove them on render (defaults to false).
			/// </summary>
            public virtual TBuilder AutoShow(bool autoShow)
            {
                this.ToComponent().AutoShow = autoShow;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The CSS class used to to apply to the special clearing div rendered directly after each form field wrapper to provide field clearing (defaults to 'x-form-clear-left').
			/// </summary>
            public virtual TBuilder ClearCls(string clearCls)
            {
                this.ToComponent().ClearCls = clearCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An optional extra CSS class that will be added to this component's Element (defaults to ''). This can be useful for adding customized styles to the component or any of its children using standard CSS rules.
			/// </summary>
            public virtual TBuilder Cls(string cls)
            {
                this.ToComponent().Cls = cls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An optional extra CSS class that will be added to this component's container. This can be useful for adding customized styles to the container or any of its children using standard CSS rules.
			/// </summary>
            public virtual TBuilder CtCls(string ctCls)
            {
                this.ToComponent().CtCls = ctCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Render this component disabled (default is false).
			/// </summary>
            public virtual TBuilder Disabled(bool disabled)
            {
                this.ToComponent().Disabled = disabled;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Determines if this component is selectable. (default is true).
			/// </summary>
            public virtual TBuilder Selectable(bool selectable)
            {
                this.ToComponent().Selectable = selectable;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// CSS class added to the component when it is disabled (defaults to 'x-item-disabled').
			/// </summary>
            public virtual TBuilder DisabledClass(string disabledClass)
            {
                this.ToComponent().DisabledClass = disabledClass;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The label text to display next to this Component (defaults to '').
			/// </summary>
            public virtual TBuilder FieldLabel(string fieldLabel)
            {
                this.ToComponent().FieldLabel = fieldLabel;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Render this component hidden (default is false). If true, the hide method will be called internally.
			/// </summary>
            public virtual TBuilder Hidden(bool hidden)
            {
                this.ToComponent().Hidden = hidden;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// true to completely hide the label element (label and separator). Defaults to false. By default, even if you do not specify a fieldLabel the space will still be reserved so that the field will line up with other fields that do have labels. Setting this to true will cause the field to not reserve that space.
			/// </summary>
            public virtual TBuilder HideLabel(bool hideLabel)
            {
                this.ToComponent().HideLabel = hideLabel;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// How this component should be hidden. Supported values are 'visibility' (css visibility), 'offsets' (negative offset position) and 'display' (css display).
			/// </summary>
            public virtual TBuilder HideMode(HideMode hideMode)
            {
                this.ToComponent().HideMode = hideMode;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to hide and show the component's container when hide/show is called on the component, false to hide and show the component itself (defaults to false).
			/// </summary>
            public virtual TBuilder HideParent(bool hideParent)
            {
                this.ToComponent().HideParent = hideParent;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An additional CSS class to apply to the div wrapping the form item element of this field.
			/// </summary>
            public virtual TBuilder ItemCls(string itemCls)
            {
                this.ToComponent().ItemCls = itemCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An optional extra CSS class that will be added to this component's Element when the mouse moves over the Element, and removed when the mouse moves out. (defaults to '').
			/// </summary>
            public virtual TBuilder OverCls(string overCls)
            {
                this.ToComponent().OverCls = overCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The registered ptype to create. This config option is not used when passing a config object into a constructor. This config option is used only when lazy instantiation is being used, and a Plugin is being specified not as a fully instantiated Component, but as a Component config object. The ptype will be looked up at render time up to determine what type of Plugin to create.
			/// </summary>
            public virtual TBuilder PType(string pType)
            {
                this.ToComponent().PType = pType;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A path specification, relative to the Component's ownerCt specifying into which ancestor Container to place a named reference to this Component. The ancestor axis can be traversed by using '/' characters in the path.
			/// </summary>
            public virtual TBuilder Ref(string _ref)
            {
                this.ToComponent().Ref = _ref;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The id of the node, a DOM node or an existing Element that will be the content Container to render this component into.
			/// </summary>
            public virtual TBuilder RenderTo(string renderTo)
            {
                this.ToComponent().RenderTo = renderTo;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An array of events that, when fired, should trigger this component to save its state (defaults to none). These can be any types of events supported by this component, including browser or custom events (e.g., ['click', 'customerchange']).
			/// </summary>
            public virtual TBuilder StateEvents(string[] stateEvents)
            {
                this.ToComponent().StateEvents = stateEvents;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The unique id for this component to use for state management purposes (defaults to the component id).
			/// </summary>
            public virtual TBuilder StateID(string stateID)
            {
                this.ToComponent().StateID = stateID;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A flag which causes the Component to attempt to restore the state of internal properties from a saved state on startup.
			/// </summary>
            public virtual TBuilder Stateful(bool stateful)
            {
                this.ToComponent().Stateful = stateful;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A custom style specification to be applied to this component's Element.
			/// </summary>
            public virtual TBuilder StyleSpec(string styleSpec)
            {
                this.ToComponent().StyleSpec = styleSpec;
                return this as TBuilder;
            }
             
 			// /// <summary>
			// /// An object or array of controls that inherit from IPlugin that will provide custom functionality for this component. The only requirement for a valid plugin is that it contain an init method that accepts a reference of type Ext.Component. When a component is created, if any plugins are available, the component will call the init method on each plugin, passing a reference to itself. Each plugin can then call methods or respond to events on the component as needed to provide its functionality.
			// /// </summary>
            // public virtual TBuilder Plugins(ItemsCollection<Plugin> plugins)
            // {
            //    this.ToComponent().Plugins = plugins;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// Automatically render control on client during page load. Default is true.
			/// </summary>
            public virtual TBuilder AutoRender(bool autoRender)
            {
                this.ToComponent().AutoRender = autoRender;
                return this as TBuilder;
            }
             
 			// /// <summary>
			// /// A collection of ToolTip configs used to add ToolTips to the Component
			// /// </summary>
            // public virtual TBuilder ToolTips(ItemsCollection<ToolTip> toolTips)
            // {
            //    this.ToComponent().ToolTips = toolTips;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// True to automatically set the focus after render (defaults to false).
			/// </summary>
            public virtual TBuilder AutoFocus(bool autoFocus)
            {
                this.ToComponent().AutoFocus = autoFocus;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Focus delay (in milliseconds) when AutoFocus is true.
			/// </summary>
            public virtual TBuilder AutoFocusDelay(int autoFocusDelay)
            {
                this.ToComponent().AutoFocusDelay = autoFocusDelay;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// Bubbles up the component/container heirarchy, calling the specified function with each component. The scope (this) of function call will be the scope provided or the current component. The arguments to the function will be the args provided or the current component. If the function returns false at any point, the bubble is stopped.
			/// </summary>
            public virtual TBuilder Bubble(string function)
            {
                this.ToComponent().Bubble(function);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Bubbles up the component/container heirarchy, calling the specified function with each component. The scope (this) of function call will be the scope provided or the current component. The arguments to the function will be the args provided or the current component. If the function returns false at any point, the bubble is stopped.
			/// </summary>
            public virtual TBuilder Bubble(string function, string scope)
            {
                this.ToComponent().Bubble(function, scope);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Bubbles up the component/container heirarchy, calling the specified function with each component. The scope (this) of function call will be the scope provided or the current component. The arguments to the function will be the args provided or the current component. If the function returns false at any point, the bubble is stopped.
			/// </summary>
            public virtual TBuilder Bubble(string function, string scope, Dictionary<string, object> args)
            {
                this.ToComponent().Bubble(function, scope, args);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder CallEl(string name, params object[] args)
            {
                this.ToComponent().CallEl(name, args);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Adds a CSS class to the component's underlying element.
			/// </summary>
            public virtual TBuilder AddClass(string cls)
            {
                this.ToComponent().AddClass(cls);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Adds a CSS class to the component's container.
			/// </summary>
            public virtual TBuilder AddContainerClass(string cls)
            {
                this.ToComponent().AddContainerClass(cls);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// More flexible version of setStyle for setting style properties.
			/// </summary>
            public virtual TBuilder ApplyStyles(string styles)
            {
                this.ToComponent().ApplyStyles(styles);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Destroys this component by purging any event listeners, removing the component's element from the DOM, removing the component from its Ext.Container (if applicable) and unregistering it from Ext.ComponentMgr. Destruction is generally handled automatically by the framework and this method should usually not need to be called directly.
			/// </summary>
            public virtual TBuilder Destroy()
            {
                this.ToComponent().Destroy();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Try to focus this component.
			/// </summary>
            public virtual TBuilder Focus()
            {
                this.ToComponent().Focus();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Try to focus this component.
			/// </summary>
            public virtual TBuilder Focus(bool selectText)
            {
                this.ToComponent().Focus(selectText);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Try to focus this component.
			/// </summary>
            public virtual TBuilder Focus(bool selectText, int delay)
            {
                this.ToComponent().Focus(selectText, delay);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Hide this component.
			/// </summary>
            public virtual TBuilder Hide()
            {
                this.ToComponent().Hide();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Removes a CSS class from the component's underlying element.
			/// </summary>
            public virtual TBuilder RemoveClass(string cls)
            {
                this.ToComponent().RemoveClass(cls);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Removes a CSS class from the component's container.
			/// </summary>
            public virtual TBuilder RemoveContainerClass(string cls)
            {
                this.ToComponent().RemoveContainerClass(cls);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Show this component.
			/// </summary>
            public virtual TBuilder Show()
            {
                this.ToComponent().Show();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Adds listeners to any Observable object (or Elements) which are automatically removed when this Component is destroyed.
			/// </summary>
            public virtual TBuilder Mon(Element el, string eventName, JFunction fn)
            {
                this.ToComponent().Mon(el, eventName, fn);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Adds listeners to any Observable object (or Elements) which are automatically removed when this Component is destroyed.
			/// </summary>
            public virtual TBuilder Mon(Observable el, string eventName, JFunction fn)
            {
                this.ToComponent().Mon(el, eventName, fn);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Adds listeners to any Observable object (or Elements) which are automatically removed when this Component is destroyed.
			/// </summary>
            public virtual TBuilder Mon(Element el, string eventName, JFunction fn, string scope)
            {
                this.ToComponent().Mon(el, eventName, fn, scope);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Adds listeners to any Observable object (or Elements) which are automatically removed when this Component is destroyed.
			/// </summary>
            public virtual TBuilder Mon(Observable el, string eventName, JFunction fn, string scope)
            {
                this.ToComponent().Mon(el, eventName, fn, scope);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Adds listeners to any Observable object (or Elements) which are automatically removed when this Component is destroyed.
			/// </summary>
            public virtual TBuilder Mon(Element el, string eventName, string fn, string scope, HandlerConfig options)
            {
                this.ToComponent().Mon(el, eventName, fn, scope, options);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Adds listeners to any Observable object (or Elements) which are automatically removed when this Component is destroyed.
			/// </summary>
            public virtual TBuilder Mon(Observable el, string eventName, string fn, string scope, HandlerConfig options)
            {
                this.ToComponent().Mon(el, eventName, fn, scope, options);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Removes listeners that were added by the Mon method.
			/// </summary>
            public virtual TBuilder Mun(Element el, string eventName, string fn)
            {
                this.ToComponent().Mun(el, eventName, fn);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Removes listeners that were added by the Mon method.
			/// </summary>
            public virtual TBuilder Mun(Observable el, string eventName, string fn)
            {
                this.ToComponent().Mun(el, eventName, fn);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Removes listeners that were added by the Mon method.
			/// </summary>
            public virtual TBuilder Mun(Element el, string eventName, string fn, string scope)
            {
                this.ToComponent().Mun(el, eventName, fn, scope);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Removes listeners that were added by the Mon method.
			/// </summary>
            public virtual TBuilder Mun(Observable el, string eventName, string fn, string scope)
            {
                this.ToComponent().Mun(el, eventName, fn, scope);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Update the html of the Body, optionally searching for and processing scripts.
			/// </summary>
            public virtual TBuilder Update(string html)
            {
                this.ToComponent().Update(html);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Update the html of the Body, optionally searching for and processing scripts.
			/// </summary>
            public virtual TBuilder Update(string html, bool loadScripts)
            {
                this.ToComponent().Update(html, loadScripts);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Update the html of the Body, optionally searching for and processing scripts.
			/// </summary>
            public virtual TBuilder Update(string html, bool loadScripts, string callback)
            {
                this.ToComponent().Update(html, loadScripts, callback);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Update the html of the Body, optionally searching for and processing scripts.
			/// </summary>
            public virtual TBuilder Update(string html, bool loadScripts, JFunction callback)
            {
                this.ToComponent().Update(html, loadScripts, callback);
                return this as TBuilder;
            }
            
        }        
    }
}