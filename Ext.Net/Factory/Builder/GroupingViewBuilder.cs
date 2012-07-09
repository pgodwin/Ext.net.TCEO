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
    public partial class GroupingView
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : GridView.Builder<GroupingView, GroupingView.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new GroupingView()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(GroupingView component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(GroupingView.Config config) : base(new GroupingView(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(GroupingView component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The text to display when there is an empty group value.
			/// </summary>
            public virtual GroupingView.Builder EmptyGroupText(string emptyGroupText)
            {
                this.ToComponent().EmptyGroupText = emptyGroupText;
                return this as GroupingView.Builder;
            }
             
 			/// <summary>
			/// False to disable grouping functionality (defaults to true).
			/// </summary>
            public virtual GroupingView.Builder EnableGrouping(bool enableGrouping)
            {
                this.ToComponent().EnableGrouping = enableGrouping;
                return this as GroupingView.Builder;
            }
             
 			/// <summary>
			/// True to enable the grouping control in the column menu.
			/// </summary>
            public virtual GroupingView.Builder EnableGroupingMenu(bool enableGroupingMenu)
            {
                this.ToComponent().EnableGroupingMenu = enableGroupingMenu;
                return this as GroupingView.Builder;
            }
             
 			/// <summary>
			/// True to allow the user to turn off grouping.
			/// </summary>
            public virtual GroupingView.Builder EnableNoGroups(bool enableNoGroups)
            {
                this.ToComponent().EnableNoGroups = enableNoGroups;
                return this as GroupingView.Builder;
            }
             
 			/// <summary>
			/// Text displayed in the grid header menu for grouping by a column (defaults to 'Group By This Field').
			/// </summary>
            public virtual GroupingView.Builder GroupByText(string groupByText)
            {
                this.ToComponent().GroupByText = groupByText;
                return this as GroupingView.Builder;
            }
             
 			/// <summary>
			/// The template used to render the group header. See Ext.XTemplate for information on how to format data using a template.
			/// </summary>
            public virtual GroupingView.Builder GroupTextTpl(string groupTextTpl)
            {
                this.ToComponent().GroupTextTpl = groupTextTpl;
                return this as GroupingView.Builder;
            }
             
 			/// <summary>
			/// The text with which to prefix the group field value in the group header line.
			/// </summary>
            public virtual GroupingView.Builder Header(string header)
            {
                this.ToComponent().Header = header;
                return this as GroupingView.Builder;
            }
             
 			/// <summary>
			/// True to hide the column that is currently grouped.
			/// </summary>
            public virtual GroupingView.Builder HideGroupedColumn(bool hideGroupedColumn)
            {
                this.ToComponent().HideGroupedColumn = hideGroupedColumn;
                return this as GroupingView.Builder;
            }
             
 			/// <summary>
			/// True to skip refreshing the view when new rows are added (defaults to false).
			/// </summary>
            public virtual GroupingView.Builder IgnoreAdd(bool ignoreAdd)
            {
                this.ToComponent().IgnoreAdd = ignoreAdd;
                return this as GroupingView.Builder;
            }
             
 			/// <summary>
			/// True to display the name for each set of grouped rows (defaults to true).
			/// </summary>
            public virtual GroupingView.Builder ShowGroupName(bool showGroupName)
            {
                this.ToComponent().ShowGroupName = showGroupName;
                return this as GroupingView.Builder;
            }
             
 			/// <summary>
			/// Text displayed in the grid header for enabling/disabling grouping (defaults to 'Show in Groups').
			/// </summary>
            public virtual GroupingView.Builder ShowGroupsText(string showGroupsText)
            {
                this.ToComponent().ShowGroupsText = showGroupsText;
                return this as GroupingView.Builder;
            }
             
 			/// <summary>
			/// True to start all groups collapsed.
			/// </summary>
            public virtual GroupingView.Builder StartCollapsed(bool startCollapsed)
            {
                this.ToComponent().StartCollapsed = startCollapsed;
                return this as GroupingView.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// Collapses all grouped rows.
			/// </summary>
            public virtual GroupingView.Builder CollapseAllGroups()
            {
                this.ToComponent().CollapseAllGroups();
                return this;
            }
            
 			/// <summary>
			/// Expands all grouped rows.
			/// </summary>
            public virtual GroupingView.Builder ExpandAllGroups()
            {
                this.ToComponent().ExpandAllGroups();
                return this;
            }
            
 			/// <summary>
			/// Toggles all groups if no value is passed, otherwise sets the expanded state of all groups to the value passed.
			/// </summary>
            public virtual GroupingView.Builder ToggleAllGroups(bool expanded)
            {
                this.ToComponent().ToggleAllGroups(expanded);
                return this;
            }
            
 			/// <summary>
			/// Toggles all groups
			/// </summary>
            public virtual GroupingView.Builder ToggleAllGroups()
            {
                this.ToComponent().ToggleAllGroups();
                return this;
            }
            
 			/// <summary>
			/// Toggles the specified group if no value is passed, otherwise sets the expanded state of the group to the value passed.
			/// </summary>
            public virtual GroupingView.Builder ToggleGroup(string groupId, bool expanded)
            {
                this.ToComponent().ToggleGroup(groupId, expanded);
                return this;
            }
            
 			/// <summary>
			/// Toggles the specified group
			/// </summary>
            public virtual GroupingView.Builder ToggleGroup(string groupId)
            {
                this.ToComponent().ToggleGroup(groupId);
                return this;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        public GroupingView.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.GroupingView(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public GroupingView.Builder GroupingView()
        {
            return this.GroupingView(new GroupingView());
        }

        /// <summary>
        /// 
        /// </summary>
        public GroupingView.Builder GroupingView(GroupingView component)
        {
            return new GroupingView.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public GroupingView.Builder GroupingView(GroupingView.Config config)
        {
            return new GroupingView.Builder(new GroupingView(config));
        }
    }
}