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
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public partial class TreeGrid : TreePanel
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public TreeGrid() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "treegrid";
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
                return "Ext.ux.tree.TreeGrid";
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override List<ResourceItem> Resources
        {
            get
            {
                List<ResourceItem> baseList = base.Resources;
                baseList.Capacity += 2;

                baseList.Add(new ClientScriptItem(typeof(TreeGrid), "Ext.Net.Build.Ext.Net.ux.extensions.treegrid.treegrid.js", "/ux/extensions/treegrid/treegrid.js"));
                baseList.Add(new ClientStyleItem(typeof(TreeGrid), "Ext.Net.Build.Ext.Net.ux.extensions.treegrid.resources.css.treegrid.css", "/ux/extensions/treegrid/resources/css/treegrid.css"));

                return baseList;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static string TreeGridNodeUI
        {
            get
            {
                return "Ext.ux.tree.TreeGridNodeUI";
            }
        }

        /// <summary>
        /// The index (or data index) of a column in this tree grid that should expand to fill unused space
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. TreeGrid")]
        [DefaultValue("")]
        [Description("The index (or data index) of a column in this tree grid that should expand to fill unused space")]
        public virtual string AutoExpandColumn
        {
            get
            {
                return (string)this.ViewState["AutoExpandColumn"] ?? "";
            }
            set
            {
                this.ViewState["AutoExpandColumn"] = value;
            }
        }

        /// <summary>
        /// The maximum width the autoExpandColumn can have (if enabled). Defaults to 1000.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. TreeGrid")]
        [DefaultValue(typeof(Unit), "1000")]
        [Description("The maximum width the autoExpandColumn can have (if enabled). Defaults to 1000.")]
        public virtual Unit AutoExpandMax
        {
            get
            {
                return this.UnitPixelTypeCheck(ViewState["AutoExpandMax"], Unit.Pixel(1000), "AutoExpandMax");
            }
            set
            {
                this.ViewState["AutoExpandMax"] = value;
            }
        }

        /// <summary>
        /// The minimum width the autoExpandColumn can have (if enabled). defaults to 50.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. TreeGrid")]
        [DefaultValue(typeof(Unit), "50")]
        [Description("The minimum width the autoExpandColumn can have (if enabled). defaults to 50.")]
        public virtual Unit AutoExpandMin
        {
            get
            {
                return this.UnitPixelTypeCheck(ViewState["AutoExpandMin"], Unit.Pixel(50), "AutoExpandMin");
            }
            set
            {
                this.ViewState["AutoExpandMin"] = value;
            }
        }

        private TreeGridColumnCollection columns;

        /// <summary>
        /// An array of column configuration objects
        /// </summary>
        [Meta]
        [ConfigOption("columns", JsonMode.AlwaysArray)]
        [Category("8. TreeGrid")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An array of column configuration objects")]
        public virtual TreeGridColumnCollection Columns
        {
            get
            {
                if (this.columns == null)
                {
                    this.columns = new TreeGridColumnCollection();
                }

                return this.columns;
            }
        }

        /// <summary>
        /// false to hide the root node (defaults to true)
        /// </summary>
        [ConfigOption]
        [Category("7. TreePanel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("false to hide the root node (defaults to true)")]
        public override bool RootVisible
        {
            get
            {
                object obj = this.ViewState["RootVisible"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["RootVisible"] = value;
            }
        }

        /// <summary>
        /// True to use Vista-style arrows in the tree (defaults to false)
        /// </summary>
        [ConfigOption]
        [Category("7. TreePanel")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to use Vista-style arrows in the tree (defaults to false)")]
        public override bool UseArrows
        {
            get
            {
                object obj = this.ViewState["UseArrows"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["UseArrows"] = value;
            }
        }

        /// <summary>
        /// False to disable tree lines (defaults to true)
        /// </summary>
        [ConfigOption]
        [Category("7. TreePanel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("False to disable tree lines (defaults to true)")]
        public override bool Lines
        {
            get
            {
                object obj = this.ViewState["Lines"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Lines"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        [Category("8. TreeGrid")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("")]
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
        /// 
        /// </summary>
        [ConfigOption]
        [Category("8. TreeGrid")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual bool EnableSort
        {
            get
            {
                object obj = this.ViewState["EnableSort"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["EnableSort"] = value;
            }
        }

        /// <summary>   
        /// 
        /// </summary>
        [ConfigOption]
        [Category("8. TreeGrid")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual bool ReserveScrollOffset
        {
            get
            {
                object obj = this.ViewState["ReserveScrollOffset"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["ReserveScrollOffset"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        [Category("8. TreeGrid")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual bool EnableHdMenu
        {
            get
            {
                object obj = this.ViewState["EnableHdMenu"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["EnableHdMenu"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        [Category("8. TreeGrid")]
        [DefaultValue("Columns")]
        [Localizable(true)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string ColumnsText
        {
            get
            {
                return (string)this.ViewState["ColumnsText"] ?? "Columns";
            }
            set
            {
                this.ViewState["ColumnsText"] = value;
            }
        }

        /// <summary>
        /// True to hide the grid's header (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetHideHeaders")]
        [Category("8. TreeGrid")]
        [DefaultValue(false)]
        [Description("True to hide the grid's header (defaults to false).")]
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
        /// Show/Hide the grid's header.
        /// </summary>
        /// <param name="hide"></param>
        [Description("Show/Hide the grid's header.")]
        internal virtual void SetHideHeaders(bool hide)
        {
            RequestManager.EnsureDirectEvent();

            this.AddScript("this.el.child('.x-grid3-header').dom.style.display = \"{1}\";", this.ClientID, hide ? "none" : "block");
        }

        /// <summary>
        /// Scroll tree to the top
        /// </summary>
        [Description("Scroll tree to the top")]
        public void ScrollToTop()
        {
            this.Call("scrollToTop");
        }

        /// <summary>
        /// Show/hide a column
        /// </summary>
        [Description("Show/hide a column")]
        public void SetColumnVisible(int index, bool visible)
        {
            this.Call("setColumnVisible", index, visible);
        }

        /// <summary>
        /// Update columns widths
        /// </summary>
        [Description("Update columns widths")]
        public void UpdateColumnWidths()
        {
            this.Call("updateColumnWidths");
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void OnPreRender(EventArgs e)
        {
            foreach (TreeGridColumn column in this.Columns)
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
    }
}
