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
using System.Text;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [ToolboxItem(false)]
    [Description("")]
    public partial class ColumnModel : LazyObservable, IIcon
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public ColumnModel() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                if (this.ParentGrid.View.Count > 0 && this.ParentGrid.View[0] is LockingGridView)
                {
                    return "Ext.ux.grid.LockingColumnModel";
                }
                return "Ext.grid.ColumnModel";
            }
        }

        private GridPanelBase parentGrid;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public GridPanelBase ParentGrid
        {
            get
            {
                return this.parentGrid;
            }
            internal set
            {
                this.parentGrid = value;
            }
        }

        /// <summary>
        /// Default sortable of columns which have no sortable specified (defaults to true). This property shall preferably be configured through the defaults config property.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. ColumnModel")]
        [DefaultValue(true)]
        [Description("Default sortable of columns which have no sortable specified (defaults to false). This property shall preferably be configured through the defaults config property.")]
        public virtual bool DefaultSortable
        {
            get
            {
                object obj = this.ViewState["DefaultSortable"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["DefaultSortable"] = value;
            }
        }

        /// <summary>
        /// The width of columns which have no width specified (defaults to 100). This property shall preferably be configured through the defaults config property.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. ColumnModel")]
        [DefaultValue(100)]
        [Description("The width of columns which have no width specified (defaults to 100). This property shall preferably be configured through the defaults config property.")]
        public virtual int DefaultWidth
        {
            get
            {
                object obj = this.ViewState["DefaultWidth"];
                return (obj == null) ? 100 : (int)obj;
            }
            set
            {
                this.ViewState["DefaultWidth"] = value;
            }
        }

        private ParameterCollection defaults;

        /// <summary>
        /// Object literal which will be used to apply Ext.grid.Column configuration options to all columns. Configuration options specified with individual column configs will supersede these defaults.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ArrayToObject)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Object literal which will be used to apply Ext.grid.Column configuration options to all columns. Configuration options specified with individual column configs will supersede these defaults.")]
        public virtual ParameterCollection Defaults
        {
            get
            {
                if (this.defaults == null)
                {
                    this.defaults = new ParameterCollection(true);
                    this.defaults.Owner = this;
                    this.defaults.AfterItemAdd += Defaults_AfterItemAdd;
                }

                return this.defaults;
            }
        }

        void Defaults_AfterItemAdd(Parameter item)
        {
            item.CamelName = true;
        }
        
        private ColumnCollection columns;

        /// <summary>
        /// The columns to use when rendering the grid (required).
        /// </summary>
        [Meta]
        [ConfigOption("columns", JsonMode.AlwaysArray)]
        [Category("3. ColumnModel")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The columns to use when rendering the grid (required).")]
        public virtual ColumnCollection Columns
        {
            get
            {
                if (this.columns == null)
                {
                    this.columns = new ColumnCollection();
                    this.columns.AfterItemAdd += Columns_AfterItemAdd;
                    this.columns.AfterItemRemove += Columns_AfterItemRemove;
                }

                return this.columns;
            }
        }

        private void Columns_AfterItemRemove(ColumnBase item)
        {
            if (item.Editor.Count > 0)
            {
                item.Editor_AfterItemRemove(item.Editor.Editor);
            }

            TemplateColumn tc = item as TemplateColumn;
            if (tc != null)
            {
                if (this.ParentGrid.Controls.Contains(tc.Template))
                {
                    this.ParentGrid.Controls.Remove(tc.Template);
                }

                if (this.ParentGrid.LazyItems.Contains(tc.Template))
                {
                    this.ParentGrid.LazyItems.Remove(tc.Template);
                }
            }
        }

        void Columns_AfterItemAdd(ColumnBase item)
        {
            item.ParentGrid = this.ParentGrid;

            if (item.Editor.Count > 0)
            {
                item.Editor_AfterItemAdd(item.Editor.Editor);
            }

            TemplateColumn tc = item as TemplateColumn;
            if (tc != null)
            {
                if (!this.ParentGrid.Controls.Contains(tc.Template))
                {
                    this.ParentGrid.Controls.Add(tc.Template);
                }

                if (!this.ParentGrid.LazyItems.Contains(tc.Template))
                {
                    this.ParentGrid.LazyItems.Add(tc.Template);
                }
            }
        }

        private ColumnListeners listeners;


        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Client-side JavaScript Event Handlers")]
        public ColumnListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new ColumnListeners();
                }

                return this.listeners;
            }
        }

        private ColumnDirectEvents directEvents;

        /// <summary>
        /// Server-side Ajax Event Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]
        [Description("Server-side Ajax Event Handlers")]
        public ColumnDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new ColumnDirectEvents();
                }

                return this.directEvents;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public string Serialize()
        {
            StringBuilder sb = new StringBuilder();
            bool comma = false;
            sb.Append("[");

            foreach (ColumnBase column in this.Columns)
            {
                if (comma)
                {
                    sb.Append(",");
                }

                sb.Append(column.Serialize());

                comma = true;
            }

            sb.Append("]");

            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="args"></param>
        [Description("")]
        protected virtual void CallColumnModel(string name, params object[] args)
        {
            StringBuilder sb = new StringBuilder();

            if (args != null && args.Length > 0)
            {
                foreach (object arg in args)
                {
                    sb.AppendFormat("{0},", JSON.Serialize(arg));
                }
            }

            string script = "{0}.getColumnModel().{1}({2});".FormatWith(this.ParentGrid.ClientID, name, sb.ToString().LeftOfRightmostOf(','));

            this.AddScript(script);
        }


        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Moves a column from one position to another.
        /// </summary>
        [Meta]
        [Description("Moves a column from one position to another.")]
        public virtual void MoveColumn(int oldIndex, int newIndex)
        {
            this.CallColumnModel("moveColumn", oldIndex, newIndex);
        }


        /// <summary>
        /// Sets the header for a column.
        /// </summary>
        [Meta]
        [Description("Sets the header for a column.")]
        public virtual void SetColumnHeader(int columnIndex, string header)
        {
            this.CallColumnModel("setColumnHeader", columnIndex, header);
        }

        /// <summary>
        /// Sets the tooltip for a column.
        /// </summary>
        [Meta]
        [Description("Sets the tooltip for a column.")]
        public virtual void SetColumnTooltip(int columnIndex, string tooltip)
        {
            this.CallColumnModel("setColumnTooltip", columnIndex, tooltip);
        }

        /// <summary>
        /// Sets the width for a column.
        /// </summary>
        [Meta]
        [Description("Sets the width for a column.")]
        public virtual void SetColumnWidth(int columnIndex, int width)
        {
            this.CallColumnModel("setColumnWidth", columnIndex, width);
        }

        /// <summary>
        /// Sets the dataIndex for a column.
        /// </summary>
        [Meta]
        [Description("Sets the dataIndex for a column.")]
        public virtual void SetDataIndex(int columnIndex, string dataIndex)
        {
            this.CallColumnModel("setDataIndex", columnIndex, dataIndex);
            
            if (RequestManager.IsAjaxRequest)
            {
                this.ParentGrid.RefreshView();
            }
        }

        /// <summary>
        /// Sets if a column is editable.
        /// </summary>
        [Meta]
        [Description("Sets if a column is editable.")]
        public virtual void SetEditable(int columnIndex, bool editable)
        {
            this.CallColumnModel("setEditable", columnIndex, editable);
        }

        /// <summary>
        /// Sets the editor for a column.
        /// </summary>
        [Meta]
        [Description("Sets the editor for a column.")]
        public virtual void SetEditor(int columnIndex, Field editor)
        {
            this.CallColumnModel("setEditor", columnIndex, new JRawValue(editor.ToConfig(LazyMode.Instance)));
        }

        /// <summary>
        /// Sets the editor for a column.
        /// </summary>
        [Meta]
        [Description("Sets the editor for a column.")]
        public virtual void SetEditor(int columnIndex, Field editor, GridEditorOptions options)
        {
            if (options == null || options.IsDefault)
            {
                this.SetEditor(columnIndex, editor);
                return;
            }

            string editorCfg = "new Ext.grid.GridEditor(Ext.apply({{field:{0}}}, {1}))".FormatWith(editor.ToConfig(), options.Serialize());
            this.CallColumnModel("setEditor", columnIndex, new JRawValue(editorCfg));
        }

        /// <summary>
        /// Sets if a column is hidden.
        /// </summary>
        [Meta]
        [Description("Sets if a column is hidden.")]
        public virtual void SetHidden(int columnIndex, bool hidden)
        {
            this.CallColumnModel("setHidden", columnIndex, hidden);
        }

        /// <summary>
        /// Sets if a column is locked.
        /// </summary>
        [Meta]
        [Description("Sets if a column is locked.")]
        public virtual void SetLocked(int columnIndex, bool locked)
        {
            this.CallColumnModel("setLocked", columnIndex, locked);
        }

        /// <summary>
        /// Sets if a column is locked.
        /// </summary>
        [Meta]
        [Description("Sets if a column is locked.")]
        public virtual void SetLocked(int columnIndex, bool locked, bool suppressEvent)
        {
            this.CallColumnModel("setLocked", columnIndex, locked, suppressEvent);
        }

        /// <summary>
        /// Sets the rendering (formatting) function for a column. See Ext.util.Format for some default formatting functions.
        /// Parameters:
        ///     col : Number
        ///         The column index
        ///     fn : Function
        ///         The function to use to process the cell's raw data to return HTML markup for the grid view. 
        ///         The render function is called with the following parameters:
        ///             value : Object
        ///                 The data value for the cell.
        ///             metadata : Object
        ///                 An object in which you may set the following attributes:
        ///                     css : String
        ///                         A CSS class name to add to the cell's TD element.
        ///                     attr : String
        ///                         An HTML attribute definition string to apply to the data container element within the table cell (e.g. 'style="color:red;"').
        ///             record : Ext.data.record
        ///                 The Ext.data.Record from which the data was extracted.
        ///             rowIndex : Number
        ///                 Row index
        ///             colIndex : Number
        ///                 Column index
        ///             store : Ext.data.Store
        ///                 The Ext.data.Store object from which the Record was extracted.
        ///     Returns:
        ///         void
        /// </summary>
        [Meta]
        [Description("Sets the rendering (formatting) function for a column.")]
        public virtual void SetRenderer(int columnIndex, Renderer renderer)
        {
            this.CallColumnModel("setRenderer", columnIndex, new JRawValue(renderer.ToConfigString()));
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Description("")]
        public virtual void RegisterCommandStyleRules()
        {
            this.ResourceManager.RegisterClientStyleInclude("Ext.Net.Build.Ext.Net.ux.plugins.commandcolumn.commandcolumn.css");
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public List<Icon> Icons
        {
            get
            {
                List<Icon> icons = new List<Icon>();

                foreach (ColumnBase column in this.Columns)
                {
                    if(column is IIcon)
                    {
                        icons.AddRange(((IIcon)column).Icons);
                    }
                }

                return icons;
            }
        }
    }
}