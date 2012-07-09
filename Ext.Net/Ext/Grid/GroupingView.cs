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

using System.ComponentModel;

namespace Ext.Net
{
    /// <summary>
    /// Adds the ability for single level grouping to the grid.
    /// </summary>
    [Meta]
    [Description("Adds the ability for single level grouping to the grid.")]
    public partial class GroupingView : GridView
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public GroupingView() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.grid.GroupingView";
            }
        }

        /// <summary>
        /// The text to display when there is an empty group value.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Localizable(true)]
        [Category("4. GroupingView")]
        [DefaultValue("")]
        [Description("The text to display when there is an empty group value.")]
        public virtual string EmptyGroupText
        {
            get
            {
                return (string)this.ViewState["EmptyGroupText"] ?? "";
            }
            set
            {
                this.ViewState["EmptyGroupText"] = value;
            }
        }

        /// <summary>
        /// False to disable grouping functionality (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. GroupingView")]
        [DefaultValue(true)]
        [Description("False to disable grouping functionality (defaults to true).")]
        public virtual bool EnableGrouping
        {
            get
            {
                object obj = this.ViewState["EnableGrouping"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["EnableGrouping"] = value;
            }
        }

        /// <summary>
        /// True to enable the grouping control in the column menu.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. GroupingView")]
        [DefaultValue(true)]
        [Description("True to enable the grouping control in the column menu.")]
        public virtual bool EnableGroupingMenu
        {
            get
            {
                object obj = this.ViewState["EnableGroupingMenu"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["EnableGroupingMenu"] = value;
            }
        }

        /// <summary>
        /// True to allow the user to turn off grouping.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. GroupingView")]
        [DefaultValue(true)]
        [Description("True to allow the user to turn off grouping.")]
        public virtual bool EnableNoGroups
        {
            get
            {
                object obj = this.ViewState["EnableNoGroups"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["EnableNoGroups"] = value;
            }
        }

        /// <summary>
        /// Text displayed in the grid header menu for grouping by a column (defaults to 'Group By This Field').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Localizable(true)]
        [Category("4. GroupingView")]
        [DefaultValue("Group By This Field")]
        [Description("Text displayed in the grid header menu for grouping by a column (defaults to 'Group By This Field').")]
        public virtual string GroupByText
        {
            get
            {
                return (string)this.ViewState["GroupByText"] ?? "Group By This Field";
            }
            set
            {
                this.ViewState["GroupByText"] = value;
            }
        }

        /// <summary>
        /// The template used to render the group header. See Ext.XTemplate for information on how to format data using a template.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. GroupingView")]
        [DefaultValue("")]
        [Description("The template used to render the group header. See Ext.XTemplate for information on how to format data using a template.")]
        public virtual string GroupTextTpl
        {
            get
            {
                return (string)this.ViewState["GroupTextTpl"] ?? "";
            }
            set
            {
                this.ViewState["GroupTextTpl"] = value;
            }
        }

        /// <summary>
        /// The text with which to prefix the group field value in the group header line.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Localizable(true)]
        [Category("4. GroupingView")]
        [DefaultValue("")]
        [Description("The text with which to prefix the group field value in the group header line.")]
        public virtual string Header
        {
            get
            {
                return (string)this.ViewState["Header"] ?? "";
            }
            set
            {
                this.ViewState["Header"] = value;
            }
        }

        /// <summary>
        /// True to hide the column that is currently grouped.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. GroupingView")]
        [DefaultValue(false)]
        [Description("True to hide the column that is currently grouped.")]
        public virtual bool HideGroupedColumn
        {
            get
            {
                object obj = this.ViewState["HideGroupedColumn"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["HideGroupedColumn"] = value;
            }
        }

        /// <summary>
        /// True to skip refreshing the view when new rows are added (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. GroupingView")]
        [DefaultValue(false)]
        [Description("True to skip refreshing the view when new rows are added (defaults to false).")]
        public virtual bool IgnoreAdd
        {
            get
            {
                object obj = this.ViewState["IgnoreAdd"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["IgnoreAdd"] = value;
            }
        }

        /// <summary>
        /// True to display the name for each set of grouped rows (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. GroupingView")]
        [DefaultValue(true)]
        [Description("True to display the name for each set of grouped rows (defaults to true).")]
        public virtual bool ShowGroupName
        {
            get
            {
                object obj = this.ViewState["ShowGroupName"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["ShowGroupName"] = value;
            }
        }

        /// <summary>
        /// Text displayed in the grid header for enabling/disabling grouping (defaults to 'Show in Groups').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Localizable(true)]
        [Category("4. GroupingView")]
        [DefaultValue("Show in Groups")]
        [Description("Text displayed in the grid header for enabling/disabling grouping (defaults to 'Show in Groups').")]
        public virtual string ShowGroupsText
        {
            get
            {
                return (string)this.ViewState["ShowGroupsText"] ?? "Show in Groups";
            }
            set
            {
                this.ViewState["ShowGroupsText"] = value;
            }
        }

        /// <summary>
        /// True to start all groups collapsed.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. GroupingView")]
        [DefaultValue(false)]
        [Description("True to start all groups collapsed.")]
        public virtual bool StartCollapsed
        {
            get
            {
                object obj = this.ViewState["StartCollapsed"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["StartCollapsed"] = value;
            }
        }

        /// <summary>
        /// Collapses all grouped rows.
        /// </summary>
        [Meta]
        [Description("Collapses all grouped rows.")]
        public virtual void CollapseAllGroups()
        {
            RequestManager.EnsureDirectEvent();
            this.Call("collapseAllGroups");
        }

        /// <summary>
        /// Expands all grouped rows.
        /// </summary>
        [Meta]
        [Description("Expands all grouped rows.")]
        public virtual void ExpandAllGroups()
        {
            RequestManager.EnsureDirectEvent();
            this.Call("expandAllGroups");
        }

        /// <summary>
        /// Toggles all groups if no value is passed, otherwise sets the expanded state of all groups to the value passed.
        /// </summary>
        /// <param name="expanded">sets the expanded state of all groups to the value passed</param>
        [Meta]
        [Description("Toggles all groups if no value is passed, otherwise sets the expanded state of all groups to the value passed.")]
        public virtual void ToggleAllGroups(bool expanded)
        {
            RequestManager.EnsureDirectEvent();
            this.Call("toggleAllGroups", expanded);
        }

        /// <summary>
        /// Toggles all groups
        /// </summary>
        [Meta]
        [Description("Toggles all groups")]
        public virtual void ToggleAllGroups()
        {
            RequestManager.EnsureDirectEvent();
            this.Call("toggleAllGroups");
        }

        /// <summary>
        /// Toggles the specified group if no value is passed, otherwise sets the expanded state of the group to the value passed.
        /// </summary>
        /// <param name="groupId">The groupId assigned to the group</param>
        /// <param name="expanded">sets the expanded state of all groups to the value passed</param>
        [Meta]
        [Description("Toggles the specified group if no value is passed, otherwise sets the expanded state of the group to the value passed.")]
        public virtual void ToggleGroup(string groupId, bool expanded)
        {
            RequestManager.EnsureDirectEvent();
            this.Call("toggleGroup", groupId, expanded);
        }

        /// <summary>
        /// Toggles the specified group
        /// </summary>
        /// <param name="groupId">The groupId assigned to the group</param>
        [Meta]
        [Description("Toggles the specified group")]
        public virtual void ToggleGroup(string groupId)
        {
            RequestManager.EnsureDirectEvent();
            this.Call("toggleGroup", groupId);
        }
    }
}