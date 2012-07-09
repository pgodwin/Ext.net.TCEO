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
    public abstract partial class ColumnBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TColumnBase, TBuilder> : StateManagedItem.Builder<TColumnBase, TBuilder>
            where TColumnBase : ColumnBase
            where TBuilder : Builder<TColumnBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TColumnBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Wrap(bool wrap)
            {
                this.ToComponent().Wrap = wrap;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Locked(bool locked)
            {
                this.ToComponent().Locked = locked;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// (optional) Set the CSS text-align property of the column. Defaults to undefined.
			/// </summary>
            public virtual TBuilder Align(Alignment align)
            {
                this.ToComponent().Align = align;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// (optional) Set custom CSS for all table cells in the column (excluding headers). Defaults to undefined.
			/// </summary>
            public virtual TBuilder Css(string css)
            {
                this.ToComponent().Css = css;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// (optional) The name of the field in the grid's Ext.data.Store's Ext.data.Record definition from which to draw the column's value. If not specified, the column's index is used as an index into the Record's data Array.
			/// </summary>
            public virtual TBuilder DataIndex(string dataIndex)
            {
                this.ToComponent().DataIndex = dataIndex;
                return this as TBuilder;
            }
             
 			// /// <summary>
			// /// (optional) The Ext.form.Field to use when editing values in this column if editing is supported by the grid.
			// /// </summary>
            // public virtual TBuilder Editor(EditorCollection editor)
            // {
            //    this.ToComponent().Editor = editor;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// Editor options
			// /// </summary>
            // public virtual TBuilder EditorOptions(GridEditorOptions editorOptions)
            // {
            //    this.ToComponent().EditorOptions = editorOptions;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// (optional) True if the column width cannot be changed. Defaults to false.
			/// </summary>
            public virtual TBuilder Fixed(bool _fixed)
            {
                this.ToComponent().Fixed = _fixed;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The header text to display in the Grid view.
			/// </summary>
            public virtual TBuilder Header(string header)
            {
                this.ToComponent().Header = header;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// (optional) True to hide the column. Defaults to false.
			/// </summary>
            public virtual TBuilder Hidden(bool hidden)
            {
                this.ToComponent().Hidden = hidden;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// (optional) Specify as false to prevent the user from hiding this column. Defaults to true.
			/// </summary>
            public virtual TBuilder Hideable(bool hideable)
            {
                this.ToComponent().Hideable = hideable;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// (optional) Defaults to the column's initial ordinal position. A name which identifies this column. The id is used to create a CSS class name which is applied to all table cells (including headers) in that column.
			/// </summary>
            public virtual TBuilder ColumnID(string columnID)
            {
                this.ToComponent().ColumnID = columnID;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// (optional) True to disable the column menu. Defaults to false.
			/// </summary>
            public virtual TBuilder MenuDisabled(bool menuDisabled)
            {
                this.ToComponent().MenuDisabled = menuDisabled;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// (optional) A function used to generate HTML markup for a cell given the cell's data value. If not specified, the default renderer uses the raw data value.
			/// </summary>
            public virtual TBuilder Renderer(Renderer renderer)
            {
                this.ToComponent().Renderer = renderer;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// (optional) A function used to generate HTML markup for a cell given the cell's data value.
			/// </summary>
            public virtual TBuilder GroupRenderer(Renderer groupRenderer)
            {
                this.ToComponent().GroupRenderer = groupRenderer;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// (optional) False to disable grouping by this column. Defaults to true.
			/// </summary>
            public virtual TBuilder Groupable(bool groupable)
            {
                this.ToComponent().Groupable = groupable;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// (optional) False to disable column resizing. Defaults to true.
			/// </summary>
            public virtual TBuilder Resizable(bool resizable)
            {
                this.ToComponent().Resizable = resizable;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The scope (this reference) in which to execute the renderer. Defaults to the Column configuration object.
			/// </summary>
            public virtual TBuilder Scope(string scope)
            {
                this.ToComponent().Scope = scope;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// (optional) True if sorting is to be allowed on this column. Defaults to the value of the defaultSortable property. Whether local/remote sorting is used is specified in Ext.data.Store.remoteSort.
			/// </summary>
            public virtual TBuilder Sortable(bool sortable)
            {
                this.ToComponent().Sortable = sortable;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// (optional) A text string to use as the column header's tooltip. If Quicktips are enabled, this value will be used as the text of the quick tip, otherwise it will be set as the header's HTML title attribute. Defaults to ''.
			/// </summary>
            public virtual TBuilder Tooltip(string tooltip)
            {
                this.ToComponent().Tooltip = tooltip;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// (optional) The initial width in pixels of the column. Using this instead of Ext.grid.Grid.autoSizeColumns is more efficient.
			/// </summary>
            public virtual TBuilder Width(Unit width)
            {
                this.ToComponent().Width = width;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Optional. Defaults to true, enabling the configured editor. Set to false to initially disable editing on this column.
			/// </summary>
            public virtual TBuilder Editable(bool editable)
            {
                this.ToComponent().Editable = editable;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Optional. If the grid is being rendered by an Ext.grid.GroupingView, this option may be used to specify the text to display when there is an empty group value. Defaults to the Ext.grid.GroupingView.emptyGroupText.
			/// </summary>
            public virtual TBuilder EmptyGroupText(string emptyGroupText)
            {
                this.ToComponent().EmptyGroupText = emptyGroupText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Optional. If the grid is being rendered by an Ext.grid.GroupingView, this option may be used to specify the text with which to prefix the group field value in the group header line. See also groupRenderer and Ext.grid.GroupingView.showGroupName.
			/// </summary>
            public virtual TBuilder GroupName(string groupName)
            {
                this.ToComponent().GroupName = groupName;
                return this as TBuilder;
            }
             
 			// /// <summary>
			// /// Collection of custom js config
			// /// </summary>
            // public virtual TBuilder CustomConfig(ConfigItemCollection customConfig)
            // {
            //    this.ToComponent().CustomConfig = customConfig;
            //    return this as TBuilder;
            // }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }        
    }
}