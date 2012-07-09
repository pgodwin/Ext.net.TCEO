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
    public partial class RowSelectionModel
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : AbstractSelectionModel.Builder<RowSelectionModel, RowSelectionModel.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new RowSelectionModel()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(RowSelectionModel component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(RowSelectionModel.Config config) : base(new RowSelectionModel(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(RowSelectionModel component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True to allow selection of only one row at a time (defaults to false).
			/// </summary>
            public virtual RowSelectionModel.Builder SingleSelect(bool singleSelect)
            {
                this.ToComponent().SingleSelect = singleSelect;
                return this as RowSelectionModel.Builder;
            }
             
 			/// <summary>
			/// False to turn off moving the editor to the next cell when the enter key is pressed.
			/// </summary>
            public virtual RowSelectionModel.Builder MoveEditorOnEnter(bool moveEditorOnEnter)
            {
                this.ToComponent().MoveEditorOnEnter = moveEditorOnEnter;
                return this as RowSelectionModel.Builder;
            }
             
 			// /// <summary>
			// /// Client-side JavaScript Event Handlers
			// /// </summary>
            // public virtual TBuilder Listeners(RowSelectionModelListeners listeners)
            // {
            //    this.ToComponent().Listeners = listeners;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// Server-side Ajax Event Handlers
			// /// </summary>
            // public virtual TBuilder DirectEvents(RowSelectionModelDirectEvents directEvents)
            // {
            //    this.ToComponent().DirectEvents = directEvents;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// 
			// /// </summary>
            // public virtual TBuilder SelectedRows(SelectedRowCollection selectedRows)
            // {
            //    this.ToComponent().SelectedRows = selectedRows;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// 
			// /// </summary>
            // public virtual TBuilder SelectedRow(SelectedRow selectedRow)
            // {
            //    this.ToComponent().SelectedRow = selectedRow;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual RowSelectionModel.Builder SelectedIndex(int selectedIndex)
            {
                this.ToComponent().SelectedIndex = selectedIndex;
                return this as RowSelectionModel.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual RowSelectionModel.Builder SelectedRecordID(string selectedRecordID)
            {
                this.ToComponent().SelectedRecordID = selectedRecordID;
                return this as RowSelectionModel.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// 
			/// </summary>
            public virtual RowSelectionModel.Builder UpdateSelection()
            {
                this.ToComponent().UpdateSelection();
                return this;
            }
            
 			/// <summary>
			/// Clears all selections.
			/// </summary>
            public virtual RowSelectionModel.Builder ClearSelections()
            {
                this.ToComponent().ClearSelections();
                return this;
            }
            
 			/// <summary>
			/// Deselects a range of rows. All rows in between startRow and endRow are also deselected.
			/// </summary>
            public virtual RowSelectionModel.Builder DeselectRange(int startRow, int endRow)
            {
                this.ToComponent().DeselectRange(startRow, endRow);
                return this;
            }
            
 			/// <summary>
			/// Deselects a row.
			/// </summary>
            public virtual RowSelectionModel.Builder DeselectRow(int row)
            {
                this.ToComponent().DeselectRow(row);
                return this;
            }
            
 			/// <summary>
			/// Deselects a row.
			/// </summary>
            public virtual RowSelectionModel.Builder SelectAll()
            {
                this.ToComponent().SelectAll();
                return this;
            }
            
 			/// <summary>
			/// Selects the first row in the grid.
			/// </summary>
            public virtual RowSelectionModel.Builder SelectFirstRow()
            {
                this.ToComponent().SelectFirstRow();
                return this;
            }
            
 			/// <summary>
			/// Select the last row.
			/// </summary>
            public virtual RowSelectionModel.Builder SelectLastRow()
            {
                this.ToComponent().SelectLastRow();
                return this;
            }
            
 			/// <summary>
			/// Select the last row.
			/// </summary>
            public virtual RowSelectionModel.Builder SelectLastRow(bool keepExisting)
            {
                this.ToComponent().SelectLastRow(keepExisting);
                return this;
            }
            
 			/// <summary>
			/// Selects the row immediately following the last selected row.
			/// </summary>
            public virtual RowSelectionModel.Builder SelectNext()
            {
                this.ToComponent().SelectNext();
                return this;
            }
            
 			/// <summary>
			/// Selects the row immediately following the last selected row.
			/// </summary>
            public virtual RowSelectionModel.Builder SelectNext(bool keepExisting)
            {
                this.ToComponent().SelectNext(keepExisting);
                return this;
            }
            
 			/// <summary>
			/// Selects the row that precedes the last selected row.
			/// </summary>
            public virtual RowSelectionModel.Builder SelectPrevious()
            {
                this.ToComponent().SelectPrevious();
                return this;
            }
            
 			/// <summary>
			/// Selects the row immediately following the last selected row.
			/// </summary>
            public virtual RowSelectionModel.Builder SelectPrevious(bool keepExisting)
            {
                this.ToComponent().SelectPrevious(keepExisting);
                return this;
            }
            
 			/// <summary>
			/// Selects a range of rows. All rows in between startRow and endRow are also selected.
			/// </summary>
            public virtual RowSelectionModel.Builder SelectRange(int startRow, int endRow)
            {
                this.ToComponent().SelectRange(startRow, endRow);
                return this;
            }
            
 			/// <summary>
			/// Selects a range of rows. All rows in between startRow and endRow are also selected.
			/// </summary>
            public virtual RowSelectionModel.Builder SelectRange(int startRow, int endRow, bool keepExisting)
            {
                this.ToComponent().SelectRange(startRow, endRow, keepExisting);
                return this;
            }
            
 			/// <summary>
			/// Select rows by id.
			/// </summary>
            public virtual RowSelectionModel.Builder SelectById(object id, bool keepExisting)
            {
                this.ToComponent().SelectById(id, keepExisting);
                return this;
            }
            
 			/// <summary>
			/// Select rows by id.
			/// </summary>
            public virtual RowSelectionModel.Builder SelectById(object id)
            {
                this.ToComponent().SelectById(id);
                return this;
            }
            
 			/// <summary>
			/// Select rows by id.
			/// </summary>
            public virtual RowSelectionModel.Builder SelectById(object[] ids, bool keepExisting)
            {
                this.ToComponent().SelectById(ids, keepExisting);
                return this;
            }
            
 			/// <summary>
			/// Select rows by id.
			/// </summary>
            public virtual RowSelectionModel.Builder SelectById(object[] ids)
            {
                this.ToComponent().SelectById(ids);
                return this;
            }
            
 			/// <summary>
			/// Selects a row.
			/// </summary>
            public virtual RowSelectionModel.Builder SelectRow(int row)
            {
                this.ToComponent().SelectRow(row);
                return this;
            }
            
 			/// <summary>
			/// Selects a row.
			/// </summary>
            public virtual RowSelectionModel.Builder SelectRow(int row, bool keepExisting)
            {
                this.ToComponent().SelectRow(row, keepExisting);
                return this;
            }
            
 			/// <summary>
			/// Selects multiple rows.
			/// </summary>
            public virtual RowSelectionModel.Builder SelectRows(int[] rows, bool keepExisting)
            {
                this.ToComponent().SelectRows(rows, keepExisting);
                return this;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        public RowSelectionModel.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.RowSelectionModel(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public RowSelectionModel.Builder RowSelectionModel()
        {
            return this.RowSelectionModel(new RowSelectionModel());
        }

        /// <summary>
        /// 
        /// </summary>
        public RowSelectionModel.Builder RowSelectionModel(RowSelectionModel component)
        {
            return new RowSelectionModel.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public RowSelectionModel.Builder RowSelectionModel(RowSelectionModel.Config config)
        {
            return new RowSelectionModel.Builder(new RowSelectionModel(config));
        }
    }
}