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
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:ListView runat=\"server\"></{0}:ListView>")]
    [ToolboxBitmap(typeof(ListView), "Build.ToolboxIcons.ListView.bmp")]
    [Designer(typeof(EmptyDesigner))]
    public partial class ListView : DataView
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public ListView() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "listview";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.ListView";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override void CheckProperties()
        {
            //do not remove
        }

        /// <summary>
        /// Specify true to enable the columns to be resizable (defaults to true).
        /// </summary>
        [Meta]
        [Category("6. ListView")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Specify true to enable the columns to be resizable (defaults to true).")]
        public virtual bool ColumnResize
        {
            get
            {
                object obj = this.ViewState["ColumnResize"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["ColumnResize"] = value;
            }
        }

        /// <summary>
        /// The minimum percentage to allot for any column (defaults to .05)
        /// </summary>
        [Meta]
        [Category("6. ListView")]
        [DefaultValue(0.05)]
        [Description("The minimum percentage to allot for any column (defaults to .05)")]
        public virtual double MinPct
        {
            get
            {
                object obj = this.ViewState["MinPct"];
                return (obj == null) ? 0.05 : (double)obj;
            }
            set
            {
                this.ViewState["MinPct"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("columnResize", JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected string ColumnResizeProxy
        {
            get
            {
                if (this.MinPct != 0.05)
                {
                    return "{".ConcatWith(JSON.Serialize(this.MinPct), "}");
                }

                if (!this.ColumnResize)
                {
                    return JSON.Serialize(this.ColumnResize);
                }

                return "";
            }
        }

        /// <summary>
        /// Specify true to enable the columns to be sortable (defaults to true).
        /// </summary>
        [Meta]
        [Category("6. ListView")]
        [ConfigOption]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Specify true to enable the columns to be sortable (defaults to true).")]
        public virtual bool ColumnSort
        {
            get
            {
                object obj = this.ViewState["ColumnSort"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["ColumnSort"] = value;
            }
        }

        private ListViewColumnCollection columns;

        /// <summary>
        /// An array of column configuration objects
        /// </summary>
        [Meta]
        [ConfigOption("columns", JsonMode.AlwaysArray)]
        [Category("6. ListView")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An array of column configuration objects")]
        public virtual ListViewColumnCollection Columns
        {
            get
            {
                if (this.columns == null)
                {
                    this.columns = new ListViewColumnCollection();
                }

                return this.columns;
            }
        }

        /// <summary>
        /// true to hide the header row (defaults to false so the header row will be shown).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. ListView")]
        [DefaultValue(false)]
        [Description("true to hide the header row (defaults to false so the header row will be shown).")]
        public virtual bool HideHeaders
        {
            get
            {
                object obj = this.ViewState["HideHeaders"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["HideHeaders"] = value;
            }
        }

        /// <summary>
        /// By default will defer accounting for the configured scrollOffset for 10 milliseconds. Specify true to account for the configured scrollOffset immediately.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. ListView")]
        [DefaultValue(false)]
        [Description("By default will defer accounting for the configured scrollOffset for 10 milliseconds. Specify true to account for the configured scrollOffset immediately.")]
        public virtual bool ReserveScrollOffset
        {
            get
            {
                object obj = this.ViewState["ReserveScrollOffset"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["ReserveScrollOffset"] = value;
            }
        }

        /// <summary>
        /// The amount of space to reserve for the scrollbar (defaults to 19 pixels)
        /// </summary>
        [Meta]
        [Category("6. ListView")]
        [DefaultValue(19)]
        [Description("The amount of space to reserve for the scrollbar (defaults to 19 pixels)")]
        public virtual int ScrollOffset 
        {
            get
            {
                object obj = this.ViewState["ScrollOffset"];
                return (obj == null) ? 19 : (int)obj;
            }
            set
            {
                this.ViewState["ScrollOffset"] = value;
            }
        }

        /// <summary>
        /// The CSS class applied when over a row (defaults to 'x-list-over').
        /// An example overriding the default styling:
        /// .x-list-over {background-color: orange;}
        /// </summary>
        [Meta]
        [Category("6. ListView")]
        [DefaultValue("x-list-over")]
        [NotifyParentProperty(true)]
        [Description("The CSS class applied when over a row (defaults to 'x-list-over').")]
        public override string OverClass
        {
            get
            {
                object obj = this.ViewState["OverClass"];
                return (obj == null) ? "x-list-over" : (string)obj;
            }
            set
            {
                this.ViewState["OverClass"] = value;
            }
        }

        /// <summary>
        /// The CSS class applied to a selected row (defaults to 'x-list-selected'). An example overriding the default styling:
        /// .x-list-selected {background-color: yellow;}
        /// </summary>
        [Meta]
        [Category("6. ListView")]
        [DefaultValue("x-list-selected")]
        [NotifyParentProperty(true)]
        [Description("The CSS class applied to a selected row (defaults to 'x-list-selected'). ")]
        public override string SelectedClass
        {
            get
            {
                object obj = this.ViewState["SelectedClass"];
                return (obj == null) ? "x-list-selected" : (string)obj;
            }
            set
            {
                this.ViewState["SelectedClass"] = value;
            }
        }

        /// <summary>
        /// Set this property to true to disable the header click handler disabling sort (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. ListView")]
        [DefaultValue(false)]
        [Description("Set this property to true to disable the header click handler disabling sort (defaults to false).")]
        public virtual bool DisableHeaders
        {
            get
            {
                object obj = this.ViewState["DisableHeaders"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["DisableHeaders"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected override void OnPreRender(EventArgs e)
        {
            foreach (ListViewColumn column in this.Columns)
            {
                XTemplate tpl = column.XTemplate;

                if (tpl.Html.IsNotEmpty())
                {
                    this.Controls.Add(tpl);
                    this.LazyItems.Add(tpl);
                }
            }
            base.OnPreRender(e);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            this.Template.Visible = false;
        }

        /// <summary>
        /// Sets the header for a column.
        /// </summary>
        /// <param name="index">The column index</param>
        /// <param name="header">The new header</param>
        [Description("Sets the header for a column.")]
        public void SetColumnHeader(int index, string header)
        {
            this.Call("setColumnHeader", index, header);
        }

        /// <summary>
        /// Sets the header for a column.
        /// </summary>
        /// <param name="dataIndex">The column data index</param>
        /// <param name="header">The new header</param>
        [Description("Sets the header for a column.")]
        public void SetColumnHeader(string dataIndex, string header)
        {
            this.Call("setColumnHeader", dataIndex, header);
        }
    }
}