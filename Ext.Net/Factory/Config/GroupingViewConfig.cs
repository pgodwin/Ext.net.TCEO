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
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public GroupingView(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit GroupingView.Config Conversion to GroupingView
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator GroupingView(GroupingView.Config config)
        {
            return new GroupingView(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : GridView.Config 
        { 
			/*  Implicit GroupingView.Config Conversion to GroupingView.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator GroupingView.Builder(GroupingView.Config config)
			{
				return new GroupingView.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string emptyGroupText = "";

			/// <summary>
			/// The text to display when there is an empty group value.
			/// </summary>
			[DefaultValue("")]
			public virtual string EmptyGroupText 
			{ 
				get
				{
					return this.emptyGroupText;
				}
				set
				{
					this.emptyGroupText = value;
				}
			}

			private bool enableGrouping = true;

			/// <summary>
			/// False to disable grouping functionality (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableGrouping 
			{ 
				get
				{
					return this.enableGrouping;
				}
				set
				{
					this.enableGrouping = value;
				}
			}

			private bool enableGroupingMenu = true;

			/// <summary>
			/// True to enable the grouping control in the column menu.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableGroupingMenu 
			{ 
				get
				{
					return this.enableGroupingMenu;
				}
				set
				{
					this.enableGroupingMenu = value;
				}
			}

			private bool enableNoGroups = true;

			/// <summary>
			/// True to allow the user to turn off grouping.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableNoGroups 
			{ 
				get
				{
					return this.enableNoGroups;
				}
				set
				{
					this.enableNoGroups = value;
				}
			}

			private string groupByText = "Group By This Field";

			/// <summary>
			/// Text displayed in the grid header menu for grouping by a column (defaults to 'Group By This Field').
			/// </summary>
			[DefaultValue("Group By This Field")]
			public virtual string GroupByText 
			{ 
				get
				{
					return this.groupByText;
				}
				set
				{
					this.groupByText = value;
				}
			}

			private string groupTextTpl = "";

			/// <summary>
			/// The template used to render the group header. See Ext.XTemplate for information on how to format data using a template.
			/// </summary>
			[DefaultValue("")]
			public virtual string GroupTextTpl 
			{ 
				get
				{
					return this.groupTextTpl;
				}
				set
				{
					this.groupTextTpl = value;
				}
			}

			private string header = "";

			/// <summary>
			/// The text with which to prefix the group field value in the group header line.
			/// </summary>
			[DefaultValue("")]
			public virtual string Header 
			{ 
				get
				{
					return this.header;
				}
				set
				{
					this.header = value;
				}
			}

			private bool hideGroupedColumn = false;

			/// <summary>
			/// True to hide the column that is currently grouped.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool HideGroupedColumn 
			{ 
				get
				{
					return this.hideGroupedColumn;
				}
				set
				{
					this.hideGroupedColumn = value;
				}
			}

			private bool ignoreAdd = false;

			/// <summary>
			/// True to skip refreshing the view when new rows are added (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool IgnoreAdd 
			{ 
				get
				{
					return this.ignoreAdd;
				}
				set
				{
					this.ignoreAdd = value;
				}
			}

			private bool showGroupName = true;

			/// <summary>
			/// True to display the name for each set of grouped rows (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ShowGroupName 
			{ 
				get
				{
					return this.showGroupName;
				}
				set
				{
					this.showGroupName = value;
				}
			}

			private string showGroupsText = "Show in Groups";

			/// <summary>
			/// Text displayed in the grid header for enabling/disabling grouping (defaults to 'Show in Groups').
			/// </summary>
			[DefaultValue("Show in Groups")]
			public virtual string ShowGroupsText 
			{ 
				get
				{
					return this.showGroupsText;
				}
				set
				{
					this.showGroupsText = value;
				}
			}

			private bool startCollapsed = false;

			/// <summary>
			/// True to start all groups collapsed.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool StartCollapsed 
			{ 
				get
				{
					return this.startCollapsed;
				}
				set
				{
					this.startCollapsed = value;
				}
			}

        }
    }
}