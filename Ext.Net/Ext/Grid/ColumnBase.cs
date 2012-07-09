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
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public abstract partial class ColumnBase : StateManagedItem
    {
        /// <summary>
        /// True to wrap cell text (excluding header) if required
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("")]
        public virtual bool Wrap
        {
            get
            {
                object obj = this.ViewState["Wrap"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Wrap"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. ColumnBase")]
        [DefaultValue(false)]
        [Description("")]
        public virtual bool Locked
        {
            get
            {
                object obj = this.ViewState["Locked"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Locked"] = value;
            }
        }

        /// <summary>
        /// optional) Set the CSS text-align property of the column. Defaults to undefined.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("2. ColumnBase")]
        [DefaultValue(Alignment.Left)]
        [Description("(optional) Set the CSS text-align property of the column. Defaults to undefined.")]
        public virtual Alignment Align
        {
            get
            {
                object obj = this.ViewState["Align"];
                return (obj == null) ? Alignment.Left : (Alignment)obj;
            }
            set
            {
                this.ViewState["Align"] = value;
            }
        }

        /// <summary>
        /// (optional) Set custom CSS for all table cells in the column (excluding headers). Defaults to undefined.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. ColumnBase")]
        [DefaultValue("")]
        [Description("(optional) Set custom CSS for all table cells in the column (excluding headers). Defaults to undefined.")]
        public virtual string Css
        {
            get
            {
                object obj = this.ViewState["Css"];
                return (obj == null) ? "" : (string)obj;
            }
            set
            {
                this.ViewState["Css"] = value;
            }
        }

        /// <summary>
        /// (optional) The name of the field in the grid's Store's Record definition from which
        /// to draw the column's value. If not specified, the column's index is used as an index
        /// into the Record's data Array.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. ColumnBase")]
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

        private EditorCollection editor;

        /// <summary>
        /// (optional) The Field to use when editing values in this column if editing is supported by the grid.
        /// </summary>
        [Meta]
        [Category("2. ColumnBase")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("(optional) The Ext.form.Field to use when editing values in this column if editing is supported by the grid.")]
        public virtual EditorCollection Editor
        {
            get
            {
                if (this.editor == null)
                {
                    editor = new EditorCollection();
                    editor.AfterItemAdd += Editor_AfterItemAdd;
                    editor.AfterItemRemove += Editor_AfterItemRemove;
                }

                return editor;
            }
        }

        internal void Editor_AfterItemAdd(Field item)
        {
            if (this.ParentGrid == null)
            {
                return;
            }

            if (!this.ParentGrid.Controls.Contains(item))
            {
                this.ParentGrid.Controls.Add(item);
            }

            if (!this.ParentGrid.LazyItems.Contains(item))
            {
                this.ParentGrid.LazyItems.Add(item);
            }
        }

        internal void Editor_AfterItemRemove(Field item)
        {
            if (this.ParentGrid == null)
            {
                return;
            }

            if (this.ParentGrid.Controls.Contains(item))
            {
                this.ParentGrid.Controls.Remove(item);
            }

            if (this.ParentGrid.LazyItems.Contains(item))
            {
                this.ParentGrid.LazyItems.Remove(item);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("editor", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected virtual string EditorProxy
        {
            get
            {
                if (this.Editor.Count == 0)
                {
                    return "";
                }

                string template = "";

                if (!this.IsSerialize)
                {
                    template = "{{{0}_ClientInit}}";

                    template = string.Format(template, this.Editor.Editor.ClientID);

                    if (this.EditorOptions.IsDefault)
                    {
                        return template;
                    }
                }
                else
                {
                    template = this.Editor.Editor.ToConfig();

                    if (this.EditorOptions.IsDefault)
                    {
                        return template;
                    }
                }
                
                return "new Ext.grid.GridEditor(Ext.apply({{field:{0}}}, {1}))".FormatWith(template, this.EditorOptions.Serialize());
            }
        }

        private GridEditorOptions editorOptions;

        /// <summary>
        /// Editor options
        /// </summary>
        [Meta]
        [Category("2. ColumnBase")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Editor options")]
        public virtual GridEditorOptions EditorOptions
        {
            get
            {
                if (this.editorOptions == null)
                {
                    editorOptions = new GridEditorOptions();
                }

                return editorOptions;
            }
        }

        /// <summary>
        /// (optional) True if the column width cannot be changed. Defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. ColumnBase")]
        [DefaultValue(false)]
        [Description("(optional) True if the column width cannot be changed. Defaults to false.")]
        public virtual bool Fixed
        {
            get
            {
                object obj = this.ViewState["Fixed"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Fixed"] = value;
            }
        }

        /// <summary>
        /// The header text to display in the Grid view.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. ColumnBase")]
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
        /// (optional) True to hide the column. Defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. ColumnBase")]
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

        /// <summary>
        /// (optional) Specify as false to prevent the user from hiding this column. Defaults to true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. ColumnBase")]
        [DefaultValue(true)]
        [Description("(optional) Specify as false to prevent the user from hiding this column. Defaults to true.")]
        public virtual bool Hideable
        {
            get
            {
                object obj = this.ViewState["Hideable"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["Hideable"] = value;
            }
        }

        /// <summary>
        /// (optional) Defaults to the column's initial ordinal position. A name which identifies
        /// this column. The id is used to create a CSS class name which is applied to all table
        /// cells (including headers) in that column. The class name takes the form of
        /// 
        /// x-grid3-td-id
        ///
        ///
        /// Header cells will also recieve this class name, but will also have the class x-grid3-hd,
        /// so to target header cells, use CSS selectors such as:
        /// 
        /// .x-grid3-hd.x-grid3-td-id
        /// 
        /// The AutoExpandColumn grid config option references the column via this identifier.
        /// </summary>
        [Meta]
        [ConfigOption("id")]
        [Category("2. ColumnBase")]
        [DefaultValue("")]
        [Description("(optional) Defaults to the column's initial ordinal position. A name which identifies this column. The id is used to create a CSS class name which is applied to all table cells (including headers) in that column.")]
        public virtual string ColumnID
        {
            //If the name of this property as ID then VS throws compiler error if same Column ID exists in another Component on the Page.
            get
            {
                object obj = this.ViewState["ColumnID"];
                return (obj == null) ? "" : (string)obj;
            }
            set
            {
                this.ViewState["ColumnID"] = value;
            }
        }

        /// <summary>
        /// (optional) True to disable the column menu. Defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. ColumnBase")]
        [DefaultValue(false)]
        [Description("(optional) True to disable the column menu. Defaults to false.")]
        public virtual bool MenuDisabled
        {
            get
            {
                object obj = this.ViewState["MenuDisabled"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["MenuDisabled"] = value;
            }
        }

        /// <summary>
        /// (optional) A function used to generate HTML markup for a cell given the cell's data value.
        /// If not specified, the default renderer uses the raw data value.
        /// 
        /// Sets the rendering (formatting) function for a column. 
        /// See Ext.util.Format for some default formatting functions.
        ///
        /// The render function is called with the following parameters:
        ///     value : Object
        ///         The data value for the cell.
        ///     metadata : Object
        ///         An object in which you may set the following attributes:
        ///         
        ///         css : String
        ///             A CSS class name to add to the cell's TD element.
        ///         attr : String
        ///             An HTML attribute definition string to apply to the data container element
        ///              within the table cell (e.g. 'style="color:red;"').
        ///     
        ///     record : Ext.data.record
        ///         The Ext.data.Record from which the data was extracted.
        ///     rowIndex : Number
        ///         Row index
        ///     colIndex : Number
        ///         Column index
        ///     store : Ext.data.Store
        ///         The Ext.data.Store object from which the Record was extracted.
        /// Returns:
        ///     void
        /// </summary>

        private Renderer renderer;

        /// <summary>
        /// (optional) A function used to generate HTML markup for a cell given the cell's data value. If not specified, the default renderer uses the raw data value.
        /// </summary>
        [Meta]
        [ConfigOption(typeof(RendererJsonConverter))]
        [Category("2. ColumnBase")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ViewStateMember]
        [Description("(optional) A function used to generate HTML markup for a cell given the cell's data value. If not specified, the default renderer uses the raw data value.")]
        public virtual Renderer Renderer
        {
            get
            {
                if (this.renderer == null)
                {
                    this.renderer = new Renderer();
                }

                return this.renderer;
            }
            set
            {
                this.renderer = value;
            }
        }

        private Renderer groupRenderer;

        /// <summary>
        /// (optional) A function used to generate HTML markup for a cell given the cell's data value."
        /// </summary>
        [Meta]
        [ConfigOption(typeof(RendererJsonConverter))]
        [Category("2. ColumnBase")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ViewStateMember]
        [Description("(optional) A function used to generate HTML markup for a cell given the cell's data value.")]
        public virtual Renderer GroupRenderer
        {
            get
            {
                if (this.groupRenderer == null)
                {
                    this.groupRenderer = new Renderer();
                }

                return this.groupRenderer;
            }
            set
            {
                this.groupRenderer = value;
            }
        }

        /// <summary>
        /// (optional) False to disable grouping by this column. Defaults to true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. ColumnBase")]
        [DefaultValue(true)]
        [Description("(optional) False to disable grouping by this column. Defaults to true.")]
        public virtual bool Groupable
        {
            get
            {
                object obj = this.ViewState["Groupable"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["Groupable"] = value;
            }
        }

        /// <summary>
        /// (optional) False to disable column resizing. Defaults to true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. ColumnBase")]
        [DefaultValue(true)]
        [Description("(optional) False to disable column resizing. Defaults to true.")]
        public virtual bool Resizable
        {
            get
            {
                object obj = this.ViewState["Resizable"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["Resizable"] = value;
            }
        }

        /// <summary>
        /// The scope (this reference) in which to execute the renderer. Defaults to the Column configuration object.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("2. ColumnBase")]
        [DefaultValue("")]
        [Description("The scope (this reference) in which to execute the renderer. Defaults to the Column configuration object.")]
        public virtual string Scope
        {
            get
            {
                object obj = this.ViewState["Scope"];
                return (obj == null) ? "" : (string)obj;
            }
            set
            {
                this.ViewState["Scope"] = value;
            }
        }

        /// <summary>
        /// (optional) True if sorting is to be allowed on this column. Defaults to the value
        /// of the defaultSortable property. Whether local/remote sorting is used is 
        /// specified in Ext.data.Store.remoteSort.
        /// </summary>
        [Meta]        
        [Category("2. ColumnBase")]
        [DefaultValue(true)]
        [Description("(optional) True if sorting is to be allowed on this column. Defaults to the value of the defaultSortable property. Whether local/remote sorting is used is specified in Ext.data.Store.remoteSort.")]
        public virtual bool Sortable
        {
            get
            {
                object obj = this.ViewState["Sortable"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["Sortable"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(null)]
        [ConfigOption("sortable")]
        protected virtual bool? SortableProxy
        {
            get
            {
                if (this.ViewState["Sortable"] == null)
                {
                    return null;
                }

                if (this.ParentGrid != null && this.ParentGrid.ColumnModel.DefaultSortable == this.Sortable)
                {
                    return null;
                }

                return this.Sortable;
            }
        }

        /// <summary>
        /// (optional) A text string to use as the column header's tooltip. If Quicktips are enabled,
        /// this value will be used as the text of the quick tip, otherwise it will be set as the
        /// header's HTML title attribute. Defaults to ''.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. ColumnBase")]
        [DefaultValue("")]
        [Description("(optional) A text string to use as the column header's tooltip. If Quicktips are enabled, this value will be used as the text of the quick tip, otherwise it will be set as the header's HTML title attribute. Defaults to ''.")]
        public virtual string Tooltip
        {
            get
            {
                object obj = this.ViewState["Tooltip"];
                return (obj == null) ? "" : (string)obj;
            }
            set
            {
                this.ViewState["Tooltip"] = value;
            }
        }

        /// <summary>
        /// (optional) The initial width in pixels of the column. Using this instead of Ext.grid.GridPanel.autoSizeColumns is more efficient.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. ColumnBase")]
        [DefaultValue(typeof(Unit), "100")]
        [Description("(optional) The initial width in pixels of the column. Using this instead of Ext.grid.Grid.autoSizeColumns is more efficient.")]
        public virtual Unit Width
        {
            get
            {
                object obj = this.ViewState["Width"];
                return (obj == null) ? Unit.Pixel(100) : (Unit)obj;
            }
            set
            {
                this.ViewState["Width"] = value;
            }
        }

        /// <summary>
        /// Optional. Defaults to true, enabling the configured editor. Set to false to initially disable editing on this column. 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. ColumnBase")]
        [DefaultValue(true)]
        [Description("Optional. Defaults to true, enabling the configured editor. Set to false to initially disable editing on this column.")]
        public virtual bool Editable
        {
            get
            {
                object obj = this.ViewState["Editable"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["Editable"] = value;
            }
        }

        /// <summary>
        /// Optional. If the grid is being rendered by an Ext.grid.GroupingView, this option may be used to specify the text to display when there is an empty group value. Defaults to the Ext.grid.GroupingView.emptyGroupText.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. ColumnBase")]
        [DefaultValue("")]
        [Description("Optional. If the grid is being rendered by an Ext.grid.GroupingView, this option may be used to specify the text to display when there is an empty group value. Defaults to the Ext.grid.GroupingView.emptyGroupText.")]
        public virtual string EmptyGroupText
        {
            get
            {
                object obj = this.ViewState["EmptyGroupText"];
                return (obj == null) ? "" : (string)obj;
            }
            set
            {
                this.ViewState["EmptyGroupText"] = value;
            }
        }

        /// <summary>
        /// Optional. If the grid is being rendered by an Ext.grid.GroupingView, this option may be used to specify the text with which to prefix the group field value in the group header line. See also groupRenderer and Ext.grid.GroupingView.showGroupName.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. ColumnBase")]
        [DefaultValue("")]
        [Description("Optional. If the grid is being rendered by an Ext.grid.GroupingView, this option may be used to specify the text with which to prefix the group field value in the group header line. See also groupRenderer and Ext.grid.GroupingView.showGroupName.")]
        public virtual string GroupName
        {
            get
            {
                object obj = this.ViewState["GroupName"];
                return (obj == null) ? "" : (string)obj;
            }
            set
            {
                this.ViewState["GroupName"] = value;
            }
        }

        private ConfigItemCollection customConfig;

        /// <summary>
        /// Collection of custom js config
        /// </summary>
        [Meta]
        [ConfigOption("-", typeof(CustomConfigJsonConverter))]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Collection of custom js config")]
        public virtual ConfigItemCollection CustomConfig
        {
            get
            {
                if (this.customConfig == null)
                {
                    this.customConfig = new ConfigItemCollection();
                }

                return this.customConfig;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected bool IsSerialize { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public GridPanelBase ParentGrid { get; internal set; }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual string Serialize()
        {
            this.IsSerialize = true;
            string config = new ClientConfig().SerializeInternal(this, this.ParentGrid);
            this.IsSerialize = false;

            return config;
        }
    }
}