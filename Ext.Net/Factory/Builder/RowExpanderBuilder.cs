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
    public partial class RowExpander
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : Plugin.Builder<RowExpander, RowExpander.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new RowExpander()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(RowExpander component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(RowExpander.Config config) : base(new RowExpander(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(RowExpander component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			// /// <summary>
			// /// The template string to use to display each item in the dropdown list.
			// /// </summary>
            // public virtual TBuilder Template(XTemplate template)
            // {
            //    this.ToComponent().Template = template;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// 
			// /// </summary>
            // public virtual TBuilder Component(ItemsCollection<Component> component)
            // {
            //    this.ToComponent().Component = component;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// Recreate component on each row expand
			/// </summary>
            public virtual RowExpander.Builder RecreateComponent(bool recreateComponent)
            {
                this.ToComponent().RecreateComponent = recreateComponent;
                return this as RowExpander.Builder;
            }
             
 			/// <summary>
			/// Swallow row body's events
			/// </summary>
            public virtual RowExpander.Builder SwallowBodyEvents(bool swallowBodyEvents)
            {
                this.ToComponent().SwallowBodyEvents = swallowBodyEvents;
                return this as RowExpander.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual RowExpander.Builder ColumnPosition(int columnPosition)
            {
                this.ToComponent().ColumnPosition = columnPosition;
                return this as RowExpander.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual RowExpander.Builder EnableCaching(bool enableCaching)
            {
                this.ToComponent().EnableCaching = enableCaching;
                return this as RowExpander.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual RowExpander.Builder ExpandOnEnter(bool expandOnEnter)
            {
                this.ToComponent().ExpandOnEnter = expandOnEnter;
                return this as RowExpander.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual RowExpander.Builder ExpandOnDblClick(bool expandOnDblClick)
            {
                this.ToComponent().ExpandOnDblClick = expandOnDblClick;
                return this as RowExpander.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual RowExpander.Builder LazyRender(bool lazyRender)
            {
                this.ToComponent().LazyRender = lazyRender;
                return this as RowExpander.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual RowExpander.Builder SingleExpand(bool singleExpand)
            {
                this.ToComponent().SingleExpand = singleExpand;
                return this as RowExpander.Builder;
            }
             
 			// /// <summary>
			// /// Client-side JavaScript Event Handlers
			// /// </summary>
            // public virtual TBuilder Listeners(RowExpanderListeners listeners)
            // {
            //    this.ToComponent().Listeners = listeners;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// Server-side DirectEventHandlers
			// /// </summary>
            // public virtual TBuilder DirectEvents(RowExpanderDirectEvents directEvents)
            // {
            //    this.ToComponent().DirectEvents = directEvents;
            //    return this as TBuilder;
            // }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// Toggle (expand/collapse) row
			/// </summary>
            public virtual RowExpander.Builder ToggleRow(int row)
            {
                this.ToComponent().ToggleRow(row);
                return this;
            }
            
 			/// <summary>
			/// Expand all rows
			/// </summary>
            public virtual RowExpander.Builder ExpandAll()
            {
                this.ToComponent().ExpandAll();
                return this;
            }
            
 			/// <summary>
			/// Collapse all rows
			/// </summary>
            public virtual RowExpander.Builder CollapseAll()
            {
                this.ToComponent().CollapseAll();
                return this;
            }
            
 			/// <summary>
			/// Expand row
			/// </summary>
            public virtual RowExpander.Builder ExpandRow(int row)
            {
                this.ToComponent().ExpandRow(row);
                return this;
            }
            
 			/// <summary>
			/// Collapse row
			/// </summary>
            public virtual RowExpander.Builder CollapseRow(int row)
            {
                this.ToComponent().CollapseRow(row);
                return this;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        public RowExpander.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.RowExpander(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public RowExpander.Builder RowExpander()
        {
            return this.RowExpander(new RowExpander());
        }

        /// <summary>
        /// 
        /// </summary>
        public RowExpander.Builder RowExpander(RowExpander component)
        {
            return new RowExpander.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public RowExpander.Builder RowExpander(RowExpander.Config config)
        {
            return new RowExpander.Builder(new RowExpander(config));
        }
    }
}