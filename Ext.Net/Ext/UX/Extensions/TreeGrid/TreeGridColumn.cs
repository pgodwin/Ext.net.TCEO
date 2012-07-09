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
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public partial class TreeGridColumn: StateManagedItem
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public TreeGridColumn() { }

        /// <summary>
        /// Set the CSS text-align property of the column. Defaults to 'left'.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("6. ListView")]
        [DefaultValue(TextAlign.Left)]
        [NotifyParentProperty(true)]
        [Description("Set the CSS text-align property of the column. Defaults to 'left'.")]
        public virtual TextAlign Align
        {
            get
            {
                object obj = this.ViewState["Align"];
                return (obj == null) ? TextAlign.Left : (TextAlign)obj;
            }
            set
            {
                this.ViewState["Align"] = value;
            }
        }

        /// <summary>
        /// Optional. This option can be used to add a CSS class to the cell of each row for this column.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. ListView")]
        [DefaultValue(null)]
        [Description("Optional. This option can be used to add a CSS class to the cell of each row for this column.")]
        public virtual string Cls
        {
            get
            {
                object obj = this.ViewState["Cls"];
                return (obj == null) ? null : (string)obj;
            }
            set
            {
                this.ViewState["Cls"] = value;
            }
        }

        /// <summary>
        /// (optional) The name of the field in the grid's Store's Record definition from which
        /// to draw the column's value. If not specified, the column's index is used as an index
        /// into the Record's data Array.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. ListView")]
        [DefaultValue(null)]
        [Description("(optional) The name of the field in the grid's Ext.data.Store's Ext.data.Record definition from which to draw the column's value. If not specified, the column's index is used as an index into the Record's data Array.")]
        public virtual string DataIndex
        {
            get
            {
                object obj = this.ViewState["DataIndex"];
                return (obj == null) ? null : (string)obj;
            }
            set
            {
                this.ViewState["DataIndex"] = value;
            }
        }

        /// <summary>
        /// The header text to display in the Grid view.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. ListView")]
        [DefaultValue("")]
        [Description("The header text to display in the Grid view.")]
        public virtual string Header
        {
            get
            {
                object obj = this.ViewState["Header"];
                return (obj == null) ? "" : (string)obj;
            }
            set
            {
                this.ViewState["Header"] = value;
            }
        }

        /// <summary>
        /// Specify a string to pass as the configuration string for Ext.XTemplate. By default an Ext.XTemplate will be implicitly created using the dataIndex.
        /// </summary>
        [Meta]
        [ConfigOption("tpl")]
        [Category("6. ListView")]
        [DefaultValue("")]
        [Description("Specify a string to pass as the configuration string for Ext.XTemplate. By default an Ext.XTemplate will be implicitly created using the dataIndex.")]
        public virtual string Template
        {
            get
            {
                object obj = this.ViewState["TemplateString"];
                return (obj == null) ? "" : (string)obj;
            }
            set
            {
                this.ViewState["TemplateString"] = value;
            }
        }

        private XTemplate template;

        /// <summary>
        /// An XTemplate to use to process a Record's data to produce a column's rendered value.
        /// </summary>
        [Meta]
        [Category("3. TemplateColumn")]
        [ConfigOption("tpl", typeof(LazyControlJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An XTemplate to use to process a Record's data to produce a column's rendered value.")]
        public virtual XTemplate XTemplate
        {
            get
            {
                if (this.template == null)
                {
                    this.template = new XTemplate();
                }

                return this.template;
            }
        }

        /// <summary>
        /// Percentage of the container width this column should be allocated. Columns that have no width specified will be allocated with an equal percentage to fill 100% of the container width. To easily take advantage of the full container width, leave the width of at least one column undefined. Note that if you do not want to take up the full width of the container, the width of every column needs to be explicitly defined.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. ListView")]
        [DefaultValue(0.0)]
        [Description("Percentage of the container width this column should be allocated. Columns that have no width specified will be allocated with an equal percentage to fill 100% of the container width. To easily take advantage of the full container width, leave the width of at least one column undefined. Note that if you do not want to take up the full width of the container, the width of every column needs to be explicitly defined.")]
        public virtual double Width
        {
            get
            {
                object obj = this.ViewState["Width"];
                return (obj == null) ? 0.0 : (double)obj;
            }
            set
            {
                this.ViewState["Width"] = value;
            }
        }

        /// <summary>
        /// Sort method
        /// </summary>
        [Meta]
        [ConfigOption(typeof(ToLowerCamelCase))]
        [Category("Config Options")]
        [DefaultValue(SortTypeMethod.None)]
        [Description("Sort method")]
        public virtual SortTypeMethod SortType
        {
            get
            {
                object obj = this.ViewState["SortType"];
                return (obj == null) ? SortTypeMethod.None : (SortTypeMethod)obj;
            }
            set
            {
                this.ViewState["SortType"] = value;
            }
        }

        /// <summary>
        /// (optional) True to hide the column. Defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. ListView")]
        [DefaultValue(false)]
        [Description("(optional) True to hide the column. Defaults to false.")]
        public virtual bool Hidden
        {
            get
            {
                object obj = this.ViewState["Hidden"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Hidden"] = value;
            }
        }

    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class TreeGridColumnCollection : StateManagedCollection<TreeGridColumn> { }
}