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
    /// <summary>
    /// This class represents the primary interface of a component based grid control.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:GridPanel runat=\"server\" Title=\"Title\" Height=\"300\"></{0}:GridPanel>")]
    [ToolboxBitmap(typeof(GridPanel), "Build.ToolboxIcons.GridPanel.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("This class represents the primary interface of a component based grid control.")]
    public partial class GridPanel : GridPanelBase
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public GridPanel() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "netgrid";
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
                return "Ext.net.GridPanel";
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

                if (this.IsCommandColumnPresented || this.RegisterAllResources)
                {
                    baseList.Capacity += 1;
                    baseList.Add(new ClientStyleItem("Ext.Net.Build.Ext.Net.ux.plugins.commandcolumn.commandcolumn-embedded.css", "/ux/plugins/commandcolumn/commandcolumn.css"));
                }

                if (this.IsHeaderRowPresented || this.RegisterAllResources)
                {
                    baseList.Capacity += 1;
                    baseList.Add(new ClientStyleItem("Ext.Net.Build.Ext.Net.ux.extensions.multiheader.css.multiheader-embedded.css", "/ux/extensions/multiheader/css/commandcolumn.css"));
                }

                if(this.IsRatingColumnPresented || this.RegisterAllResources)
                {
                    baseList.Capacity += 2;
                    baseList.Add(new ClientScriptItem("Ext.Net.Build.Ext.Net.ux.plugins.ratingcolumn.ratingcolumn.js", "/ux/plugins/ratingcolumn/ratingcolumn.js"));
                    baseList.Add(new ClientStyleItem("Ext.Net.Build.Ext.Net.ux.plugins.ratingcolumn.resources.css.ratingcolumn-embedded.css", "/ux/plugins/ratingcolumn/resources/css/ratingcolumn.css"));
                }
                
                return baseList;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        [Description("")]
        protected override void OnBeforeClientInit(Observable sender)
        {
            base.OnBeforeClientInit(sender);

            if (this.StoreID.IsNotEmpty() && this.Store.Primary != null)
            {
                throw new Exception(string.Format("Please do not set both the StoreID property on {0} and <Store> inner property at the same time.", this.ID));
            }
            
            this.CheckColumns();

            if (this.SelectionMemoryProxy && this.MemoryIDField.IsEmpty() && (this.Store.Primary != null || this.StoreID.IsNotEmpty()))
            {
                Store store = this.Store.Primary??(ControlUtils.FindControl(this, this.StoreID) as Store);

                if (store != null && store.Reader.Count > 0)
                {
                    string id = store.Reader.Reader.IDField;
            
                    if (id.IsNotEmpty())
                    {
                        this.MemoryIDField = id;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public void RegisterColumnPlugins()
        {
            RequestManager.EnsureDirectEvent();
            this.Call("initColumnPlugins", new JRawValue(this.GetColumnPlugins()), true);
        }

        private void CheckColumns()
        {
            string plugins = this.GetColumnPlugins();

            if (plugins.Length > 2)
            {
                this.CustomConfig.Add(new ConfigItem("columnPlugins", plugins, ParameterMode.Raw));
            }
        }

        private bool IsCommandColumnPresented
        {
            get
            {
                for (int i = 0; i < this.ColumnModel.Columns.Count; i++)
                {
                    CommandColumn cmdCol = this.ColumnModel.Columns[i] as CommandColumn;
                    ImageCommandColumn imgCmdCol = this.ColumnModel.Columns[i] as ImageCommandColumn;
                    Column column = this.ColumnModel.Columns[i] as Column;

                    if (column != null && column.Commands.Count > 0 && imgCmdCol == null)
                    {
                        return true;
                    }

                    if (cmdCol != null || imgCmdCol != null)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        private bool IsRatingColumnPresented
        {
            get
            {
                for (int i = 0; i < this.ColumnModel.Columns.Count; i++)
                {
                    RatingColumn ratingCol = this.ColumnModel.Columns[i] as RatingColumn;

                    if (ratingCol != null)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        private bool IsHeaderRowPresented
        {
            get
            {
                return this.View.Count > 0 && this.View[0].HeaderRows.Count > 0;
            }
        }

        private string GetColumnPlugins()
        {
            StringBuilder sb = new StringBuilder("[");
            for (int i = 0; i < this.ColumnModel.Columns.Count; i++)
            {
                CommandColumn cmdCol = this.ColumnModel.Columns[i] as CommandColumn;
                ImageCommandColumn imgCmdCol = this.ColumnModel.Columns[i] as ImageCommandColumn;
                Column column = this.ColumnModel.Columns[i] as Column;

                if (column != null && column.Commands.Count > 0 && imgCmdCol == null)
                {
                    continue;
                }

                if (cmdCol != null || imgCmdCol != null)
                {
                    sb.Append(i + ",");
                    continue;
                }

                CheckColumn cc = this.ColumnModel.Columns[i] as CheckColumn;

                if (cc != null && cc.Editable)
                {
                    sb.Append(i + ",");
                    continue;
                }

                RatingColumn rc = this.ColumnModel.Columns[i] as RatingColumn;

                if (rc != null && rc.Editable)
                {
                    sb.Append(i + ",");
                    continue;
                }
            }

            if (sb[sb.Length - 1] == ',')
            {
                sb.Remove(sb.Length - 1, 1);
            }

            sb.Append("]");

            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        [Description("")]
        protected override void OnAfterClientInit(Observable sender)
        {
            base.OnAfterClientInit(sender);

            this.CheckAutoExpand();
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void CheckAutoExpand()
        {
            if (this.AutoExpandColumn.IsNotEmpty())
            {
                if (this.AutoExpandColumn.Test("^\\d+$"))
                {
                    return;
                }

                bool found = false;
                
                foreach (ColumnBase column in this.ColumnModel.Columns)
                {
                    if (column.ColumnID == this.AutoExpandColumn)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    throw new ArgumentException("The AutoExpand Column with ID='".ConcatWith(this.AutoExpandColumn,"' was not found."));
                }
            }
        }

        private GridPanelListeners listeners;

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
        public GridPanelListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new GridPanelListeners();
                }

                return this.listeners;
            }
        }

        private GridPanelDirectEvents directEvents;

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
        public GridPanelDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new GridPanelDirectEvents();
                }

                return this.directEvents;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="postDataKey"></param>
        /// <param name="postCollection"></param>
        /// <returns></returns>
        [Description("")]        
        protected override bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            bool result = base.LoadPostData(postDataKey, postCollection);
            string val = postCollection[this.ConfigID.ConcatWith("_SM")];

            if (val != null && this.SelectionModel.Primary != null)
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.MissingMemberHandling = MissingMemberHandling.Ignore;
                StringReader sr = new StringReader(val);
                
                if (this.SelectionModel.Primary is RowSelectionModel)
                {
                    SelectedRowCollection ids = (SelectedRowCollection)serializer.Deserialize(sr, typeof(SelectedRowCollection));
                    (this.SelectionModel.Primary as RowSelectionModel).SetSelection(ids);
                } 
                else if (this.SelectionModel.Primary is CellSelectionModel)
                {
                    SelectedCellSerializable cell = (SelectedCellSerializable)serializer.Deserialize(sr, typeof(SelectedCellSerializable));

                    if (cell != null)
                    {
                        CellSelectionModel sm = this.SelectionModel.Primary as CellSelectionModel;
                        sm.SelectedCell.RowIndex = cell.RowIndex;
                        sm.SelectedCell.ColIndex = cell.ColIndex;
                        sm.SelectedCell.RecordID = cell.RecordID;
                        sm.SelectedCell.Name = cell.Name;
                        sm.SelectedCell.Value = cell.Value;
                    }
                }
            }

            return result;
        }
    }
}