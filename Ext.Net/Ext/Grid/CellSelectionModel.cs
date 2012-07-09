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

using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// This class provides the basic implementation for single cell selection in a grid.
    /// The object stored as the selection and returned by getSelectedCell contains the following properties:
    ///     record : Ext.data.record
    ///         The Record which provides the data for the row containing the selection
    ///     cell : Ext.data.record
    ///         An object containing the following properties:
    ///              rowIndex : Number
    ///                 The index of the selected row
    ///             cellIndex : Number
    ///                 The index of the selected cell
    ///  Note that due to possible column reordering, the cellIndex should not be used as an index into
    ///  the Record's data. Instead, the name of the selected field should be determined in order to
    ///  retrieve the data value from the record by name:
    ///
    ///     var fieldName = grid.getColumnModel().getDataIndex(cellIndex);
    ///     var data = record.get(fieldName);
    /// </summary>
    [Meta]
    [ToolboxItem(false)]
    [Description("This class provides the basic implementation for single cell selection in a grid. The object stored as the selection and returned by getSelectedCell contains the following properties:")]
    public partial class CellSelectionModel : AbstractSelectionModel
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public CellSelectionModel() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.grid.CellSelectionModel";
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

        private CellSelectionModelListeners listeners;

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
        public CellSelectionModelListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new CellSelectionModelListeners();
                }

                return this.listeners;
            }
        }

        private CellSelectionModelDirectEvents directEvents;

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
        public CellSelectionModelDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new CellSelectionModelDirectEvents();
                }

                return this.directEvents;
            }
        }

        private SelectedCell selectedCell;

        /// <summary>
        /// Selected cell
        /// </summary>
        [Meta]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("selectedData", JsonMode.Object)]
        [ViewStateMember]
        [Description("Selected cell")]
        public SelectedCell SelectedCell
        {
            get
            {
                if (this.selectedCell == null)
                {
                    this.selectedCell = new SelectedCell();
                }

                return this.selectedCell;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Description("")]
        public void Clear()
        {
            this.SelectedCell.RowIndex = -1;
            this.SelectedCell.ColIndex = -1;
            this.SelectedCell.RecordID = "";
            this.SelectedCell.Name = "";
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override void UpdateSelection()
        {
            if (this.SelectedCell.RowIndex<0 &&
               this.SelectedCell.ColIndex < 0 &&
               this.SelectedCell.RecordID.IsEmpty() &&
               this.SelectedCell.Name.IsEmpty())
            {
                this.Call("clearSelections");
                this.CallGrid("clearMemory");
            }
            else
            {
                string sc = new ClientConfig().Serialize(this.SelectedCell);

                this.Set("selectedData", new JRawValue(sc));

                this.CallGrid("doSelection");
            }
        }

        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Clears all selections.
        /// </summary>
        [Meta]
        [Description("Clears all selections.")]
        public virtual void ClearSelections()
        {
            this.Call("clearSelections");
        }

        /// <summary>
        /// Clears all selections.
        /// </summary>
        /// <param name="notify">true to prevent the gridview from being notified about the change.</param>
        [Meta]
        [Description("Clears all selections.")]
        public virtual void ClearSelections(bool notify)
        {
            this.Call("clearSelections", notify);
        }

        /// <summary>
        /// Selects a cell.
        /// </summary>
        /// <param name="rowIndex">The row index of the cell</param>
        /// <param name="collIndex ">The column index of the cell</param>
        [Meta]
        [Description("Selects a range of rows. All rows in between startRow and endRow are also selected.")]
        public virtual void Select(int rowIndex, int collIndex)
        {
            this.Call("select", rowIndex, collIndex);
        }
    }
}