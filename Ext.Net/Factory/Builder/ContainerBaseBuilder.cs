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
    public abstract partial class ContainerBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TContainerBase, TBuilder> : BoxComponentBase.Builder<TContainerBase, TBuilder>
            where TContainerBase : ContainerBase
            where TBuilder : Builder<TContainerBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TContainerBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// A string component id of the component that should be initially activated within the content Container's layout on render.
			/// </summary>
            public virtual TBuilder ActiveItem(string activeItem)
            {
                this.ToComponent().ActiveItem = activeItem;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A numeric index of the component that should be initially activated within the content Container's layout on render.
			/// </summary>
            public virtual TBuilder ActiveIndex(int activeIndex)
            {
                this.ToComponent().ActiveIndex = activeIndex;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// If true the content Container will automatically destroy any contained component that is removed from it, else destruction must be handled manually (defaults to true).
			/// </summary>
            public virtual TBuilder AutoDestroy(bool autoDestroy)
            {
                this.ToComponent().AutoDestroy = autoDestroy;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// If true .doLayout() is called after render. Default is false.
			/// </summary>
            public virtual TBuilder AutoDoLayout(bool autoDoLayout)
            {
                this.ToComponent().AutoDoLayout = autoDoLayout;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// When set to true (50 milliseconds) or a number of milliseconds, the layout assigned for this container will buffer the frequency it calculates and does a re-layout of components. This is useful for heavy containers or containers with a large quantity of sub-components for which frequent layout calls would be expensive. Defaults to 50.
			/// </summary>
            public virtual TBuilder BufferResize(int bufferResize)
            {
                this.ToComponent().BufferResize = bufferResize;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The default type of content Container represented by this object as registered in Ext.ComponentMgr (defaults to 'panel').
			/// </summary>
            public virtual TBuilder DefaultType(string defaultType)
            {
                this.ToComponent().DefaultType = defaultType;
                return this as TBuilder;
            }
             
 			// /// <summary>
			// /// A config object that will be applied to all components added to this content Container either via the items config or via the add or insert methods. The defaults config can contain any number of name/value property pairs to be added to each items, and should be valid for the types of items being added to the content Container. For example, to automatically apply padding to the body of each of a set of contained Ext.Panel items, you could pass: defaults: {bodyStyle:'padding:15px'}.
			// /// </summary>
            // public virtual TBuilder Defaults(ParameterCollection defaults)
            // {
            //    this.ToComponent().Defaults = defaults;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// True to hide the borders of each contained component, false to defer to the component's existing border settings (defaults to false).
			/// </summary>
            public virtual TBuilder HideBorders(bool hideBorders)
            {
                this.ToComponent().HideBorders = hideBorders;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to automatically monitor window resize events to handle anything that is sensitive to the current size of the viewport. This value is typically managed by the chosen layout and should not need to be set manually.
			/// </summary>
            public virtual TBuilder MonitorResize(bool monitorResize)
            {
                this.ToComponent().MonitorResize = monitorResize;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// If true the container will force a layout initially even if hidden or collapsed. This option is useful for forcing forms to render in collapsed or hidden containers. (defaults to false).
			/// </summary>
            public virtual TBuilder ForceLayout(bool forceLayout)
            {
                this.ToComponent().ForceLayout = forceLayout;
                return this as TBuilder;
            }
             
 			// /// <summary>
			// /// Items Collection
			// /// </summary>
            // public virtual TBuilder Items(ItemsCollection<Component> items)
            // {
            //    this.ToComponent().Items = items;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// The layout type to be used in this container.
			/// </summary>
            public virtual TBuilder Layout(string layout)
            {
                this.ToComponent().Layout = layout;
                return this as TBuilder;
            }
             
 			// /// <summary>
			// /// This is a config object containing properties specific to the chosen layout (to be used in conjunction with the layout config value)
			// /// </summary>
            // public virtual TBuilder LayoutConfig(LayoutConfigCollection layoutConfig)
            // {
            //    this.ToComponent().LayoutConfig = layoutConfig;
            //    return this as TBuilder;
            // }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// Adds a component to this container. Fires the beforeadd event before adding, then fires the add event after the component has been added. If the container is already rendered when add is called, you may need to call doLayout to refresh the view. This is required so that you can add multiple child components if needed while only refreshing the layout once.
			/// </summary>
            public virtual TBuilder Add(Component component)
            {
                this.ToComponent().Add(component);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Adds a range of components to this container.
			/// </summary>
            public virtual TBuilder Add(IEnumerable<Component> collection)
            {
                this.ToComponent().Add(collection);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Cascades down the component/container heirarchy from this component (called first), calling the specified function with each component. The scope (this) of function call will be the scope provided or the current component. The arguments to the function will be the args provided or the current component. If the function returns false at any point, the cascade is stopped on that branch.
			/// </summary>
            public virtual TBuilder Cascade(string function)
            {
                this.ToComponent().Cascade(function);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Cascades down the component/container heirarchy from this component (called first), calling the specified function with each component. The scope (this) of function call will be the scope provided or the current component. The arguments to the function will be the args provided or the current component. If the function returns false at any point, the cascade is stopped on that branch.
			/// </summary>
            public virtual TBuilder Cascade(string function, string scope)
            {
                this.ToComponent().Cascade(function, scope);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Cascades down the component/container heirarchy from this component (called first), calling the specified function with each component. The scope (this) of function call will be the scope provided or the current component. The arguments to the function will be the args provided or the current component. If the function returns false at any point, the cascade is stopped on that branch.
			/// </summary>
            public virtual TBuilder Cascade(string function, string scope, Dictionary<string, object> args)
            {
                this.ToComponent().Cascade(function, scope, args);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Force this container's layout to be recalculated. A call to this function is required after adding a new component to an already rendered container, or possibly after changing sizing/position properties of child components.
			/// </summary>
            public virtual TBuilder DoLayout()
            {
                this.ToComponent().DoLayout();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Force this container's layout to be recalculated. A call to this function is required after adding a new component to an already rendered container, or possibly after changing sizing/position properties of child components.
			/// </summary>
            public virtual TBuilder DoLayout(bool shallow)
            {
                this.ToComponent().DoLayout(shallow);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Force this container's layout to be recalculated. A call to this function is required after adding a new component to an already rendered container, or possibly after changing sizing/position properties of child components.
			/// </summary>
            public virtual TBuilder DoLayout(bool shallow, bool force)
            {
                this.ToComponent().DoLayout(shallow, force);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Inserts a Component into this Container at a specified index. Fires the beforeadd event before inserting, then fires the add event after the Component has been inserted.
			/// </summary>
            public virtual TBuilder Insert(int index, Component component)
            {
                this.ToComponent().Insert(index, component);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Inserts a Component into this Container at a specified index. Fires the beforeadd event before inserting, then fires the add event after the Component has been inserted.
			/// </summary>
            public virtual TBuilder Insert(int index, string id)
            {
                this.ToComponent().Insert(index, id);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Removes a component from this container. Fires the beforeremove event before removing, then fires the remove event after the component has been removed.
			/// </summary>
            public virtual TBuilder Remove(Component component)
            {
                this.ToComponent().Remove(component);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Removes a component from this container. Fires the beforeremove event before removing, then fires the remove event after the component has been removed.
			/// </summary>
            public virtual TBuilder Remove(Component component, bool destroy)
            {
                this.ToComponent().Remove(component, destroy);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Removes a component from this container. Fires the beforeremove event before removing, then fires the remove event after the component has been removed.
			/// </summary>
            public virtual TBuilder Remove(string id)
            {
                this.ToComponent().Remove(id);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Removes a component from this container. Fires the beforeremove event before removing, then fires the remove event after the component has been removed.
			/// </summary>
            public virtual TBuilder Remove(string id, bool destroy)
            {
                this.ToComponent().Remove(id, destroy);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Removes all components from this container.
			/// </summary>
            public virtual TBuilder RemoveAll()
            {
                this.ToComponent().RemoveAll();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Removes all components from this container.
			/// </summary>
            public virtual TBuilder RemoveAll(bool autoDestroy)
            {
                this.ToComponent().RemoveAll(autoDestroy);
                return this as TBuilder;
            }
            
        }        
    }
}