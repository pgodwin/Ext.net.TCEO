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
    public abstract partial class MultiSelectBase<T>
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
                
                list.Add("storeID", new ConfigOption("storeID", new SerializationOptions("store", JsonMode.ToClientID), "", this.StoreID ));
                list.Add("store", new ConfigOption("store", new SerializationOptions("store>Primary"), null, this.Store ));
                list.Add("itemsProxy", new ConfigOption("itemsProxy", new SerializationOptions("store", JsonMode.Raw), "", this.ItemsProxy ));
                list.Add("displayField", new ConfigOption("displayField", null, "", this.DisplayField ));
                list.Add("valueField", new ConfigOption("valueField", null, "", this.ValueField ));
                list.Add("allowBlank", new ConfigOption("allowBlank", null, true, this.AllowBlank ));
                list.Add("maxLength", new ConfigOption("maxLength", null, -1, this.MaxLength ));
                list.Add("minLength", new ConfigOption("minLength", null, 0, this.MinLength ));
                list.Add("maxLengthText", new ConfigOption("maxLengthText", null, "", this.MaxLengthText ));
                list.Add("minLengthText", new ConfigOption("minLengthText", null, "", this.MinLengthText ));
                list.Add("blankText", new ConfigOption("blankText", null, "", this.BlankText ));
                list.Add("copy", new ConfigOption("copy", null, false, this.Copy ));
                list.Add("allowDuplicates", new ConfigOption("allowDuplicates", new SerializationOptions("allowDup"), false, this.AllowDuplicates ));
                list.Add("allowTrash", new ConfigOption("allowTrash", null, false, this.AllowTrash ));
                list.Add("legend", new ConfigOption("legend", null, "", this.Legend ));
                list.Add("delimiter", new ConfigOption("delimiter", null, ",", this.Delimiter ));
                list.Add("dragGroup", new ConfigOption("dragGroup", null, "", this.DragGroup ));
                list.Add("dropGroup", new ConfigOption("dropGroup", null, "", this.DropGroup ));
                list.Add("appendOnly", new ConfigOption("appendOnly", null, false, this.AppendOnly ));
                list.Add("sortField", new ConfigOption("sortField", null, "", this.SortField ));
                list.Add("direction", new ConfigOption("direction", new SerializationOptions(JsonMode.ToLower), SortDirection.ASC, this.Direction ));
                list.Add("submitText", new ConfigOption("submitText", null, true, this.SubmitText ));
                list.Add("fireSelectOnLoad", new ConfigOption("fireSelectOnLoad", null, false, this.FireSelectOnLoad ));
                list.Add("multiSelect", new ConfigOption("multiSelect", null, true, this.MultiSelect ));
                list.Add("keepSelectionOnClick", new ConfigOption("keepSelectionOnClick", new SerializationOptions(JsonMode.ToLower), KeepSelectionMode.Always, this.KeepSelectionOnClick ));
                list.Add("bodyStyle", new ConfigOption("bodyStyle", null, "", this.BodyStyle ));
                list.Add("bottomBar", new ConfigOption("bottomBar", new SerializationOptions("bbar", typeof(ItemCollectionJsonConverter)), null, this.BottomBar ));
                list.Add("topBar", new ConfigOption("topBar", new SerializationOptions("tbar", typeof(ItemCollectionJsonConverter)), null, this.TopBar ));

                return list;
            }
        }
    }
}