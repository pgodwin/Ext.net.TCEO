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
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace Ext.Net
{
    public abstract partial class GridPanelBase
    {
        /// <summary>
        /// 
        /// </summary>
		[Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[XmlIgnore]
        [JsonIgnore]
        public override ConfigOptionsCollection ConfigOptions
        {
            get
            {
                ConfigOptionsCollection list = base.ConfigOptions;
                
                list.Add("autoExpandColumn", new ConfigOption("autoExpandColumn", null, "", this.AutoExpandColumn ));
                list.Add("autoExpandMax", new ConfigOption("autoExpandMax", null, 1000, this.AutoExpandMax ));
                list.Add("autoExpandMin", new ConfigOption("autoExpandMin", null, 50, this.AutoExpandMin ));
                list.Add("clearEditorFilter", new ConfigOption("clearEditorFilter", null, true, this.ClearEditorFilter ));
                list.Add("columnLines", new ConfigOption("columnLines", null, false, this.ColumnLines ));
                list.Add("dDGroup", new ConfigOption("dDGroup", new SerializationOptions("ddGroup"), "GridDD", this.DDGroup ));
                list.Add("dDText", new ConfigOption("dDText", new SerializationOptions("ddText"), "{0} selected row{1}", this.DDText ));
                list.Add("deferRowRender", new ConfigOption("deferRowRender", null, true, this.DeferRowRender ));
                list.Add("disableSelection", new ConfigOption("disableSelection", null, false, this.DisableSelection ));
                list.Add("enableColumnHide", new ConfigOption("enableColumnHide", null, true, this.EnableColumnHide ));
                list.Add("enableColumnMove", new ConfigOption("enableColumnMove", null, true, this.EnableColumnMove ));
                list.Add("enableColumnResize", new ConfigOption("enableColumnResize", null, true, this.EnableColumnResize ));
                list.Add("enableDragDrop", new ConfigOption("enableDragDrop", null, false, this.EnableDragDrop ));
                list.Add("enableHdMenu", new ConfigOption("enableHdMenu", null, true, this.EnableHdMenu ));
                list.Add("hideHeaders", new ConfigOption("hideHeaders", null, false, this.HideHeaders ));
                list.Add("loadMask", new ConfigOption("loadMask", new SerializationOptions("loadMask", typeof(LoadMaskJsonConverter)), null, this.LoadMask ));
                list.Add("saveMask", new ConfigOption("saveMask", new SerializationOptions("saveMask", typeof(LoadMaskJsonConverter)), null, this.SaveMask ));
                list.Add("maxHeight", new ConfigOption("maxHeight", null, Unit.Pixel(400), this.MaxHeight ));
                list.Add("minColumnWidth", new ConfigOption("minColumnWidth", null, Unit.Pixel(25), this.MinColumnWidth ));
                list.Add("monitorWindowResize", new ConfigOption("monitorWindowResize", null, true, this.MonitorWindowResize ));
                list.Add("selectionModel", new ConfigOption("selectionModel", new SerializationOptions("sm>Primary"), null, this.SelectionModel ));
                list.Add("storeID", new ConfigOption("storeID", new SerializationOptions("store", JsonMode.ToClientID), "", this.StoreID ));
                list.Add("store", new ConfigOption("store", new SerializationOptions("store>Primary", 1), null, this.Store ));
                list.Add("stripeRows", new ConfigOption("stripeRows", null, false, this.StripeRows ));
                list.Add("trackMouseOver", new ConfigOption("trackMouseOver", null, false, this.TrackMouseOver ));
                list.Add("view", new ConfigOption("view", new SerializationOptions("view>View"), null, this.View ));
                list.Add("autoEncode", new ConfigOption("autoEncode", null, false, this.AutoEncode ));
                list.Add("clicksToEditProxy", new ConfigOption("clicksToEditProxy", new SerializationOptions("clicksToEdit", JsonMode.Raw), "", this.ClicksToEditProxy ));
                list.Add("fireSelectOnLoad", new ConfigOption("fireSelectOnLoad", null, false, this.FireSelectOnLoad ));
                list.Add("forceValidation", new ConfigOption("forceValidation", null, false, this.ForceValidation ));
                list.Add("selectionSavingBuffer", new ConfigOption("selectionSavingBuffer", null, 0, this.SelectionSavingBuffer ));
                list.Add("selectionMemoryProxy", new ConfigOption("selectionMemoryProxy", new SerializationOptions("selectionMemory"), true, this.SelectionMemoryProxy ));
                list.Add("memoryIDField", new ConfigOption("memoryIDField", null, "", this.MemoryIDField ));
                list.Add("getDragDropText", new ConfigOption("getDragDropText", new SerializationOptions(JsonMode.Raw), null, this.GetDragDropText ));
                list.Add("columnModel", new ConfigOption("columnModel", new SerializationOptions("cm", typeof(LazyControlJsonConverter)), null, this.ColumnModel ));

                return list;
            }
        }
    }
}