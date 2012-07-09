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
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// A custom selection model that renders a column of checkboxes that can be toggled to select or deselect rows.
    /// </summary>
    [Meta]
    [ToolboxItem(false)]
    [Description("A custom selection model that renders a column of checkboxes that can be toggled to select or deselect rows.")]
    public partial class CheckboxSelectionModel : RowSelectionModel
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public CheckboxSelectionModel() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.grid.CheckboxSelectionModel";
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            this.BeforeClientInit += CheckboxSelModel_OnBeforeClientInit;
        }
        
        void CheckboxSelModel_OnBeforeClientInit(Observable sender)
        {
            base.OnBeforeClientInit(sender);

            if (this.SingleSelect)
            {
                this.HideCheckAll = true;
            }

            if (this.HideCheckAll && !this.DesignMode && !RequestManager.IsAjaxRequest)
            {
                this.Header = "&nbsp;";
                this.ResourceManager.RegisterClientStyleBlock("hide-checkall-fix" + this.ParentComponent.ClientID.GetHashCode(), "#".ConcatWith(this.ParentComponent.ClientID, " .x-grid3-hd-checker{background: transparent !important;}"));
            }
        }

        /// <summary>
        /// true if rows can only be selected by clicking on the checkbox column (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue(false)]
        [Description("true if rows can only be selected by clicking on the checkbox column (defaults to false).")]
        public virtual bool CheckOnly
        {
            get
            {
                object obj = this.ViewState["CheckOnly"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["CheckOnly"] = value;
            }
        }

        /// <summary>
        /// Any valid text or HTML fragment to display in the header cell for the checkbox column
        /// (defaults to '<div class="x-grid3-hd-checker"> </div>'). The default CSS class 
        /// of 'x-grid3-hd-checker' displays a checkbox in the header and provides support for 
        /// automatic check all/none behavior on header click. This string can be replaced by any 
        /// valid HTML fragment, including a simple text string (e.g., 'Select Rows'), but the 
        /// automatic check all/none behavior will only work if the 'x-grid3-hd-checker' class 
        /// is supplied.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue("<div class=\"x-grid3-hd-checker\"> </div>")]
        [Description("Any valid text or HTML fragment to display in the header cell for the checkbox column (defaults to '<div class='x-grid3-hd-checker'> </div>'). The default CSS class of 'x-grid3-hd-checker' displays a checkbox in the header and provides support for automatic check all/none behavior on header click. This string can be replaced by any valid HTML fragment, including a simple text string (e.g., 'Select Rows'), but the automatic check all/none behavior will only work if the 'x-grid3-hd-checker' class is supplied.")]
        public virtual string Header
        {
            get
            {
                return (string)this.ViewState["Header"] ?? "<div class=\"x-grid3-hd-checker\"> </div>";
            }
            set
            {
                this.ViewState["Header"] = value;
            }
        }

        /// <summary>
        /// True if the checkbox column is sortable (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue(false)]
        [Description("True if the checkbox column is sortable (defaults to false).")]
        public virtual bool Sortable
        {
            get
            {
                object obj = this.ViewState["Sortable"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Sortable"] = value;
            }
        }

        /// <summary>
        /// True if need hide the checkbox in the header (defaults to false).
        /// </summary>
        [Meta]
        [Category("Config Options")]
        [DefaultValue(false)]
        [Description("True if need hide the checkbox in the header (defaults to false).")]
        public virtual bool HideCheckAll
        {
            get
            {
                object obj = this.ViewState["HideCheckAll"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["HideCheckAll"] = value;
            }
        }

        /// <summary>
        /// False if need disable deselection
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue(true)]
        [Description("False if need disable deselection")]
        public virtual bool AllowDeselect
        {
            get
            {
                object obj = this.ViewState["AllowDeselect"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["AllowDeselect"] = value;
            }
        }

        /// <summary>
        /// The default width in pixels of the checkbox column (defaults to 20).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue(20)]
        [Description("The default width in pixels of the checkbox column (defaults to 20).")]
        new public virtual int Width
        {
            get
            {
                object obj = this.ViewState["Width"];
                return (obj == null) ? 20 : (int)obj;
            }
            set
            {
                this.ViewState["Width"] = value;
            }
        }

        /// <summary>
        /// RowSpan attribute for the checkbox table cell
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue(1)]
        [Description("RowSpan attribute for the checkbox table cell")]
        public virtual int RowSpan
        {
            get
            {
                object obj = this.ViewState["RowSpan"];
                return (obj == null) ? 1 : (int)obj;
            }
            set
            {
                this.ViewState["RowSpan"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue(0)]
        [Description("")]
        public int ColumnPosition
        {
            get
            {
                object obj = this.ViewState["ColumnPosition"];
                return obj != null ? (int)obj : 0;
            }
            set
            {
                this.ViewState["ColumnPosition"] = value;
            }
        }

        /// <summary>
        /// Selection mode
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("6. MultiSelect")]
        [DefaultValue(KeepSelectionMode.Always)]
        [Description("Selection Mode")]
        public virtual KeepSelectionMode KeepSelectionOnClick
        {
            get
            {
                object obj = this.ViewState["KeepSelectionOnClick"];
                return (obj == null) ? KeepSelectionMode.Always : (KeepSelectionMode)obj;
            }
            set
            {
                this.ViewState["KeepSelectionOnClick"] = value;
            }
        }

        private bool isAddedAsColumn = false;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            if (!this.Visible || this.isAddedAsColumn)
            {
                return;
            }

            GridPanel parent = this.ParentComponent as GridPanel;
            parent.ColumnModel.Columns.Insert(this.ColumnPosition, new ReferenceColumn(this.ClientID));
            this.isAddedAsColumn = true;
        }
    }
}
