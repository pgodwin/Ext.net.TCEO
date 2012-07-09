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
        new public abstract partial class Config : BoxComponentBase.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string activeItem = "";

			/// <summary>
			/// A string component id of the component that should be initially activated within the content Container's layout on render.
			/// </summary>
			[DefaultValue("")]
			public virtual string ActiveItem 
			{ 
				get
				{
					return this.activeItem;
				}
				set
				{
					this.activeItem = value;
				}
			}

			private int activeIndex = -1;

			/// <summary>
			/// A numeric index of the component that should be initially activated within the content Container's layout on render.
			/// </summary>
			[DefaultValue(-1)]
			public virtual int ActiveIndex 
			{ 
				get
				{
					return this.activeIndex;
				}
				set
				{
					this.activeIndex = value;
				}
			}

			private bool autoDestroy = true;

			/// <summary>
			/// If true the content Container will automatically destroy any contained component that is removed from it, else destruction must be handled manually (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AutoDestroy 
			{ 
				get
				{
					return this.autoDestroy;
				}
				set
				{
					this.autoDestroy = value;
				}
			}

			private bool autoDoLayout = false;

			/// <summary>
			/// If true .doLayout() is called after render. Default is false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AutoDoLayout 
			{ 
				get
				{
					return this.autoDoLayout;
				}
				set
				{
					this.autoDoLayout = value;
				}
			}

			private int bufferResize = 50;

			/// <summary>
			/// When set to true (50 milliseconds) or a number of milliseconds, the layout assigned for this container will buffer the frequency it calculates and does a re-layout of components. This is useful for heavy containers or containers with a large quantity of sub-components for which frequent layout calls would be expensive. Defaults to 50.
			/// </summary>
			[DefaultValue(50)]
			public virtual int BufferResize 
			{ 
				get
				{
					return this.bufferResize;
				}
				set
				{
					this.bufferResize = value;
				}
			}

			private string defaultType = "Panel";

			/// <summary>
			/// The default type of content Container represented by this object as registered in Ext.ComponentMgr (defaults to 'panel').
			/// </summary>
			[DefaultValue("Panel")]
			public virtual string DefaultType 
			{ 
				get
				{
					return this.defaultType;
				}
				set
				{
					this.defaultType = value;
				}
			}
        
			private ParameterCollection defaults = null;

			/// <summary>
			/// A config object that will be applied to all components added to this content Container either via the items config or via the add or insert methods. The defaults config can contain any number of name/value property pairs to be added to each items, and should be valid for the types of items being added to the content Container. For example, to automatically apply padding to the body of each of a set of contained Ext.Panel items, you could pass: defaults: {bodyStyle:'padding:15px'}.
			/// </summary>
			public ParameterCollection Defaults
			{
				get
				{
					if (this.defaults == null)
					{
						this.defaults = new ParameterCollection();
					}
			
					return this.defaults;
				}
			}
			
			private bool hideBorders = false;

			/// <summary>
			/// True to hide the borders of each contained component, false to defer to the component's existing border settings (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool HideBorders 
			{ 
				get
				{
					return this.hideBorders;
				}
				set
				{
					this.hideBorders = value;
				}
			}

			private bool monitorResize = false;

			/// <summary>
			/// True to automatically monitor window resize events to handle anything that is sensitive to the current size of the viewport. This value is typically managed by the chosen layout and should not need to be set manually.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool MonitorResize 
			{ 
				get
				{
					return this.monitorResize;
				}
				set
				{
					this.monitorResize = value;
				}
			}

			private bool forceLayout = false;

			/// <summary>
			/// If true the container will force a layout initially even if hidden or collapsed. This option is useful for forcing forms to render in collapsed or hidden containers. (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool ForceLayout 
			{ 
				get
				{
					return this.forceLayout;
				}
				set
				{
					this.forceLayout = value;
				}
			}
        
			private ItemsCollection<Component> items = null;

			/// <summary>
			/// Items Collection
			/// </summary>
			public ItemsCollection<Component> Items
			{
				get
				{
					if (this.items == null)
					{
						this.items = new ItemsCollection<Component>();
					}
			
					return this.items;
				}
			}
			
			private string layout = "";

			/// <summary>
			/// The layout type to be used in this container.
			/// </summary>
			[DefaultValue("")]
			public virtual string Layout 
			{ 
				get
				{
					return this.layout;
				}
				set
				{
					this.layout = value;
				}
			}
        
			private LayoutConfigCollection layoutConfig = null;

			/// <summary>
			/// This is a config object containing properties specific to the chosen layout (to be used in conjunction with the layout config value)
			/// </summary>
			public LayoutConfigCollection LayoutConfig
			{
				get
				{
					if (this.layoutConfig == null)
					{
						this.layoutConfig = new LayoutConfigCollection();
					}
			
					return this.layoutConfig;
				}
			}
			
        }
    }
}