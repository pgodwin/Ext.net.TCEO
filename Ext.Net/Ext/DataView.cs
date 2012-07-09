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

using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Web.UI;

using Ext.Net.Utilities;
using Newtonsoft.Json;

namespace Ext.Net
{
    [Meta]
    [ToolboxData("<{0}:DataView runat=\"server\"></{0}:DataView>")]
    [ToolboxBitmap(typeof(DataView), "Build.ToolboxIcons.DataView.bmp")]
    [Designer(typeof(EmptyDesigner))]
    public partial class DataView : DataViewBase, IXPostBackDataHandler
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public DataView() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "dataview";
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
                return "Ext.DataView";
            }
        }

        private DataViewListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ViewStateMember]
        [Description("Client-side JavaScript Event Handlers")]
        public DataViewListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new DataViewListeners();
                }

                return this.listeners;
            }
        }

        private DataViewDirectEvents directEvents;

        /// <summary>
        /// Server-side Ajax Event Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]
        [ViewStateMember]
        [Description("Server-side Ajax Event Handlers")]
        public DataViewDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new DataViewDirectEvents();
                }

                return this.directEvents;
            }
        }


        private SelectedRowCollection selectedRows;

        /// <summary>
        /// 
        /// </summary>
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ConfigOption("selectedData", JsonMode.AlwaysArray)]
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

		/// <summary>
		/// 
		/// </summary>
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

        private bool hasLoadPostData = false;

        /// <summary>
        /// 
        /// </summary>
        protected virtual bool HasLoadPostData
        {
            get
            {
                return this.hasLoadPostData;
            }
            set
            {
                this.hasLoadPostData = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        bool IXPostBackDataHandler.HasLoadPostData
        {
            get
            {
                return this.HasLoadPostData;
            }
            set
            {
                this.HasLoadPostData = value;
            }
        }

        bool IPostBackDataHandler.LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            this.HasLoadPostData = true;

            string val = postCollection[this.ConfigID.ConcatWith("_SN")];

            if (val != null)
            {
                this.selectedRows = JSON.Deserialize<SelectedRowCollection>(val);
            }

            return false;
        }

        void IPostBackDataHandler.RaisePostDataChangedEvent() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void UpdateSelection()
        {
            if (this.SelectedRows.Count == 0)
            {
                this.Call("clearSelections");
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
                this.Call("doSelection");
            }
        }
    }
}
