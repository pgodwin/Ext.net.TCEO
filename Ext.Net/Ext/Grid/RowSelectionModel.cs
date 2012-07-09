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
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    /// <summary>
    /// The default SelectionModel used by Ext.grid.GridPanel. It supports multiple
    /// selections and keyboard selection/navigation. The objects stored as selections
    /// and returned by getSelected, and getSelections are the Records which provide
    /// the data for the selected rows.
    /// </summary>
    [Meta]
    [ToolboxItem(false)]
    [Description("The default SelectionModel used by Ext.grid.Grid. It supports multiple selections and keyboard selection/navigation. The objects stored as selections and returned by getSelected, and getSelections are the Records which provide the data for the selected rows.")]
    public partial class RowSelectionModel : AbstractSelectionModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public RowSelectionModel() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.grid.RowSelectionModel";
            }
        }

        /// <summary>
        /// True to allow selection of only one row at a time (defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue(false)]
        [Description("True to allow selection of only one row at a time (defaults to false).")]
        public virtual bool SingleSelect
        {
            get
            {
                object obj = this.ViewState["SingleSelect"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["SingleSelect"] = value;
            }
        }

        /// <summary>
        /// False to turn off moving the editor to the next cell when the enter key is pressed
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue(true)]
        [Description("False to turn off moving the editor to the next cell when the enter key is pressed.")]
        public virtual bool MoveEditorOnEnter
        {
            get
            {
                object obj = this.ViewState["MoveEditorOnEnter"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["MoveEditorOnEnter"] = value;
            }
        }

        private RowSelectionModelListeners listeners;

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
        public RowSelectionModelListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new RowSelectionModelListeners();
                }

                return this.listeners;
            }
        }

        private RowSelectionModelDirectEvents directEvents;

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
        public RowSelectionModelDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new RowSelectionModelDirectEvents();
                }

                return this.directEvents;
            }
        }

        private SelectedRowCollection selectedRows;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ConfigOption("selectedData",JsonMode.AlwaysArray)]
        [ViewStateMember]
        [Description("")]
        public SelectedRowCollection SelectedRows
        {
            get
            {
                if (this.selectedRows == null)
                {
                    this.selectedRows = new SelectedRowCollection();
                }

                return this.selectedRows;
            }
        }

        internal void SetSelection(SelectedRowCollection rows)
        {
            this.selectedRows = rows;
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Description("")]
        public SelectedRow SelectedRow
        {
            get
            {
                if (this.SingleSelect)
                {
                    if (this.SelectedRows.Count > 0)
                    {
                        return this.SelectedRows[0];
                    }
                }

                return null;

            }
            set
            {
                if (this.SingleSelect)
                {
                    this.SelectedRows.Clear();
                    this.SelectedRows.Add(value);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue(-1)]
        [Description("")]
        public int SelectedIndex
        {
            get
            {
                if (this.SingleSelect)
                {
                    if (this.SelectedRows.Count > 0)
                    {
                        return this.SelectedRows[0].RowIndex;
                    }
                }

                return -1;
                
            }
            set
            {
                if (this.SingleSelect)
                {
                    this.SelectedRows.Clear();
                    this.SelectedRows.Add(new SelectedRow(value));
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue("")]
        [Description("")]
        public string SelectedRecordID
        {
            get
            {
                if (this.SingleSelect)
                {
                    if (this.SelectedRows.Count > 0)
                    {
                        return this.SelectedRows[0].RecordID;
                    }
                }

                return "";

            }
            set
            {
                if (this.SingleSelect)
                {
                    this.SelectedRows.Clear();
                    this.SelectedRows.Add(new SelectedRow(value));
                }
            }
        }

        /// <summary>
        /// The list of selectors of the ignore targets
        /// </summary>
        [ConfigOption(typeof(StringArrayJsonConverter))]
        [TypeConverter(typeof(StringArrayConverter))]
        [DefaultValue(null)]
        [Description("The list of selectors of the ignore targets")]
        public virtual string[] IgnoreTargets
        {
            get
            {
                object obj = this.ViewState["IgnoreTargets"];
                return (obj == null) ? null : (string[])obj;
            }
            set
            {
                this.ViewState["IgnoreTargets"] = value;
            }
        }



        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Description("")]
        public override void UpdateSelection()
        {
            if (this.SelectedRows.Count == 0)
            {
                this.Call("clearSelections");
                this.CallGrid("clearMemory");
            }
            else
            {
                bool comma = false;
                StringBuilder temp = new StringBuilder();
                temp.Append("[");

                foreach (SelectedRow row in this.SelectedRows)
                {
                    if (comma)
                    {
                        temp.Append(",");
                    }

                    temp.Append(new ClientConfig().Serialize(row));

                    comma = true;
                }
                temp.Append("]");

                this.Set("selectedData", new JRawValue(temp.ToString()));
                this.CallGrid("doSelection");
            }
        }

        /// <summary>
        /// Clears all selections.
        /// </summary>
        [Meta]
        [Description("Clears all selections.")]
        public virtual void ClearSelections()
        {
            this.SelectedRows.Clear();
            this.Call("clearSelections");
        }

        /// <summary>
        /// Deselects a range of rows. All rows in between startRow and endRow are also deselected.
        /// </summary>
        /// <param name="startRow">The index of the first row in the range</param>
        /// <param name="endRow">The index of the last row in the range</param>
        [Meta]
        [Description("Deselects a range of rows. All rows in between startRow and endRow are also deselected.")]
        public virtual void DeselectRange(int startRow, int endRow)
        {
            this.Call("deselectRange", startRow, endRow);
        }

        /// <summary>
        /// Deselects a row.
        /// </summary>
        /// <param name="row">The index of the row to deselect</param>
        [Meta]
        [Description("Deselects a row.")]
        public virtual void DeselectRow(int row)
        {
            this.Call("deselectRow", row);
        }

        /// <summary>
        /// Deselects a row.
        /// </summary>
        [Meta]
        [Description("Deselects a row.")]
        public virtual void SelectAll()
        {
            this.Call("selectAll");
        }

        /// <summary>
        /// Selects the first row in the grid.
        /// </summary>
        [Meta]
        [Description("Selects the first row in the grid.")]
        public virtual void SelectFirstRow()
        {
            this.Call("selectFirstRow");
        }

        /// <summary>
        /// Select the last row.
        /// </summary>
        [Meta]
        [Description("Select the last row.")]
        public virtual void SelectLastRow()
        {
            this.Call("selectLastRow");
        }

        /// <summary>
        /// Select the last row.
        /// </summary>
        /// <param name="keepExisting">True to keep existing selections</param>
        [Meta]
        [Description("Select the last row.")]
        public virtual void SelectLastRow(bool keepExisting)
        {
            this.Call("selectLastRow", keepExisting);
        }
        
        /// <summary>
        /// Selects the row immediately following the last selected row.
        /// </summary>
        [Meta]
        [Description("Selects the row immediately following the last selected row.")]
        public virtual void SelectNext()
        {
            this.Call("selectNext");
        }

        /// <summary>
        /// Selects the row immediately following the last selected row.
        /// </summary>
        /// <param name="keepExisting">True to keep existing selections</param>
        [Meta]
        [Description("Selects the row immediately following the last selected row.")]
        public virtual void SelectNext(bool keepExisting)
        {
            this.Call("selectLastRow", keepExisting);
        }

        /// <summary>
        /// Selects the row that precedes the last selected row.
        /// </summary>
        [Meta]
        [Description("Selects the row that precedes the last selected row.")]
        public virtual void SelectPrevious()
        {
            this.Call("selectPrevious");
        }

        /// <summary>
        /// Selects the row that precedes the last selected row.
        /// </summary>
        /// <param name="keepExisting">Selects the row that precedes the last selected row.</param>
        [Meta]
        [Description("Selects the row immediately following the last selected row.")]
        public virtual void SelectPrevious(bool keepExisting)
        {
            this.Call("selectPrevious", keepExisting);
        }

        /// <summary>
        /// Selects a range of rows. All rows in between startRow and endRow are also selected.
        /// </summary>
        /// <param name="startRow">The index of the first row in the range</param>
        /// <param name="endRow">The index of the last row in the range</param>
        [Meta]
        [Description("Selects a range of rows. All rows in between startRow and endRow are also selected.")]
        public virtual void SelectRange(int startRow, int endRow)
        {
            this.Call("selectRange", startRow, endRow);
        }

        /// <summary>
        /// Selects a range of rows. All rows in between startRow and endRow are also selected.
        /// </summary>
        /// <param name="startRow">The index of the first row in the range</param>
        /// <param name="endRow">The index of the last row in the range</param>
        /// <param name="keepExisting">True to retain existing selections</param>
        [Meta]
        [Description("Selects a range of rows. All rows in between startRow and endRow are also selected.")]
        public virtual void SelectRange(int startRow, int endRow, bool keepExisting)
        {
            this.Call("selectRange", startRow, endRow, keepExisting);
        }

        /// <summary>
        /// Select row by id.
        /// </summary>
        /// <param name="id">The id of the record to select</param>
        /// <param name="keepExisting">True to keep existing selections</param>
        [Meta]
        [Description("Select rows by id.")]
        public virtual void SelectById(object id, bool keepExisting)
        {
            this.Call("selectById", id, keepExisting);
        }

        /// <summary>
        /// Select row by id.
        /// </summary>
        /// <param name="id">The id of the record to select</param>
        [Meta]
        [Description("Select rows by id.")]
        public virtual void SelectById(object id)
        {
            this.Call("selectById", id);
        }

        /// <summary>
        /// Select rows by id.
        /// </summary>
        /// <param name="ids">The array of ids of record to select</param>
        /// <param name="keepExisting">True to keep existing selections</param>
        [Meta]
        [Description("Select rows by id.")]
        public virtual void SelectById(object[] ids, bool keepExisting)
        {
            this.Call("selectById", ids, keepExisting);
        }

        /// <summary>
        /// Select rows by id.
        /// </summary>
        /// <param name="ids">The array of ids of record to select</param>
        [Meta]
        [Description("Select rows by id.")]
        public virtual void SelectById(object[] ids)
        {
            this.Call("selectById", ids);
        }


        /// <summary>
        /// Selects a row.
        /// </summary>
        /// <param name="row">The index of the row to select</param>
        [Meta]
        [Description("Selects a row.")]
        public virtual void SelectRow(int row)
        {
            this.Call("selectRow", row);
        }

        /// <summary>
        /// Selects a row.
        /// </summary>
        /// <param name="row">The index of the row to select</param>
        /// <param name="keepExisting">True to keep existing selections</param>
        [Meta]
        [Description("Selects a row.")]
        public virtual void SelectRow(int row, bool keepExisting)
        {
            this.Call("selectRow", row, keepExisting);
        }

        /// <summary>
        /// Selects multiple rows.
        /// </summary>
        /// <param name="rows">Array of the indexes of the row to select</param>
        /// <param name="keepExisting">True to keep existing selections (defaults to false)</param>
        [Meta]
        [Description("Selects multiple rows.")]
        public virtual void SelectRows(int[] rows, bool keepExisting)
        {
            this.Call("selectRows", rows, keepExisting);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class SelectedRowCollection : StateManagedCollection<SelectedRow>
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override bool CreateOnLoading
        {
            get
            {
                return true;
            }
        }
    }
}