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
    public partial class ColumnModel
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : LazyObservable.Builder<ColumnModel, ColumnModel.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ColumnModel()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ColumnModel component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ColumnModel.Config config) : base(new ColumnModel(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ColumnModel component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Default sortable of columns which have no sortable specified (defaults to false). This property shall preferably be configured through the defaults config property.
			/// </summary>
            public virtual ColumnModel.Builder DefaultSortable(bool defaultSortable)
            {
                this.ToComponent().DefaultSortable = defaultSortable;
                return this as ColumnModel.Builder;
            }
             
 			/// <summary>
			/// The width of columns which have no width specified (defaults to 100). This property shall preferably be configured through the defaults config property.
			/// </summary>
            public virtual ColumnModel.Builder DefaultWidth(int defaultWidth)
            {
                this.ToComponent().DefaultWidth = defaultWidth;
                return this as ColumnModel.Builder;
            }
             
 			// /// <summary>
			// /// Object literal which will be used to apply Ext.grid.Column configuration options to all columns. Configuration options specified with individual column configs will supersede these defaults.
			// /// </summary>
            // public virtual TBuilder Defaults(ParameterCollection defaults)
            // {
            //    this.ToComponent().Defaults = defaults;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// The columns to use when rendering the grid (required).
			// /// </summary>
            // public virtual TBuilder Columns(ColumnCollection columns)
            // {
            //    this.ToComponent().Columns = columns;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// Client-side JavaScript Event Handlers
			// /// </summary>
            // public virtual TBuilder Listeners(ColumnListeners listeners)
            // {
            //    this.ToComponent().Listeners = listeners;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// Server-side Ajax Event Handlers
			// /// </summary>
            // public virtual TBuilder DirectEvents(ColumnDirectEvents directEvents)
            // {
            //    this.ToComponent().DirectEvents = directEvents;
            //    return this as TBuilder;
            // }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// Moves a column from one position to another.
			/// </summary>
            public virtual ColumnModel.Builder MoveColumn(int oldIndex, int newIndex)
            {
                this.ToComponent().MoveColumn(oldIndex, newIndex);
                return this;
            }
            
 			/// <summary>
			/// Sets the header for a column.
			/// </summary>
            public virtual ColumnModel.Builder SetColumnHeader(int columnIndex, string header)
            {
                this.ToComponent().SetColumnHeader(columnIndex, header);
                return this;
            }
            
 			/// <summary>
			/// Sets the tooltip for a column.
			/// </summary>
            public virtual ColumnModel.Builder SetColumnTooltip(int columnIndex, string tooltip)
            {
                this.ToComponent().SetColumnTooltip(columnIndex, tooltip);
                return this;
            }
            
 			/// <summary>
			/// Sets the width for a column.
			/// </summary>
            public virtual ColumnModel.Builder SetColumnWidth(int columnIndex, int width)
            {
                this.ToComponent().SetColumnWidth(columnIndex, width);
                return this;
            }
            
 			/// <summary>
			/// Sets the dataIndex for a column.
			/// </summary>
            public virtual ColumnModel.Builder SetDataIndex(int columnIndex, string dataIndex)
            {
                this.ToComponent().SetDataIndex(columnIndex, dataIndex);
                return this;
            }
            
 			/// <summary>
			/// Sets if a column is editable.
			/// </summary>
            public virtual ColumnModel.Builder SetEditable(int columnIndex, bool editable)
            {
                this.ToComponent().SetEditable(columnIndex, editable);
                return this;
            }
            
 			/// <summary>
			/// Sets the editor for a column.
			/// </summary>
            public virtual ColumnModel.Builder SetEditor(int columnIndex, Field editor)
            {
                this.ToComponent().SetEditor(columnIndex, editor);
                return this;
            }
            
 			/// <summary>
			/// Sets the editor for a column.
			/// </summary>
            public virtual ColumnModel.Builder SetEditor(int columnIndex, Field editor, GridEditorOptions options)
            {
                this.ToComponent().SetEditor(columnIndex, editor, options);
                return this;
            }
            
 			/// <summary>
			/// Sets if a column is hidden.
			/// </summary>
            public virtual ColumnModel.Builder SetHidden(int columnIndex, bool hidden)
            {
                this.ToComponent().SetHidden(columnIndex, hidden);
                return this;
            }
            
 			/// <summary>
			/// Sets if a column is locked.
			/// </summary>
            public virtual ColumnModel.Builder SetLocked(int columnIndex, bool locked)
            {
                this.ToComponent().SetLocked(columnIndex, locked);
                return this;
            }
            
 			/// <summary>
			/// Sets if a column is locked.
			/// </summary>
            public virtual ColumnModel.Builder SetLocked(int columnIndex, bool locked, bool suppressEvent)
            {
                this.ToComponent().SetLocked(columnIndex, locked, suppressEvent);
                return this;
            }
            
 			/// <summary>
			/// Sets the rendering (formatting) function for a column.
			/// </summary>
            public virtual ColumnModel.Builder SetRenderer(int columnIndex, Renderer renderer)
            {
                this.ToComponent().SetRenderer(columnIndex, renderer);
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual ColumnModel.Builder RegisterCommandStyleRules()
            {
                this.ToComponent().RegisterCommandStyleRules();
                return this;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        public ColumnModel.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ColumnModel(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public ColumnModel.Builder ColumnModel()
        {
            return this.ColumnModel(new ColumnModel());
        }

        /// <summary>
        /// 
        /// </summary>
        public ColumnModel.Builder ColumnModel(ColumnModel component)
        {
            return new ColumnModel.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ColumnModel.Builder ColumnModel(ColumnModel.Config config)
        {
            return new ColumnModel.Builder(new ColumnModel(config));
        }
    }
}