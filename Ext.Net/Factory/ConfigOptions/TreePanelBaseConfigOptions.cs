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
    public abstract partial class TreePanelBase
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
                
                list.Add("allowLeafDrop", new ConfigOption("allowLeafDrop", null, false, this.AllowLeafDrop ));
                list.Add("animate", new ConfigOption("animate", null, true, this.Animate ));
                list.Add("containerScroll", new ConfigOption("containerScroll", null, false, this.ContainerScroll ));
                list.Add("dDAppendOnly", new ConfigOption("dDAppendOnly", new SerializationOptions("ddAppendOnly"), false, this.DDAppendOnly ));
                list.Add("dDGroup", new ConfigOption("dDGroup", new SerializationOptions("ddGroup"), "", this.DDGroup ));
                list.Add("dDScroll", new ConfigOption("dDScroll", new SerializationOptions("ddScroll"), false, this.DDScroll ));
                list.Add("dragConfigProxy", new ConfigOption("dragConfigProxy", new SerializationOptions("dragConfig", JsonMode.Raw), "", this.DragConfigProxy ));
                list.Add("dropConfigProxy", new ConfigOption("dropConfigProxy", new SerializationOptions("dropConfig", JsonMode.Raw), "", this.DropConfigProxy ));
                list.Add("enableDD", new ConfigOption("enableDD", null, false, this.EnableDD ));
                list.Add("enableDrag", new ConfigOption("enableDrag", null, false, this.EnableDrag ));
                list.Add("enableDrop", new ConfigOption("enableDrop", null, false, this.EnableDrop ));
                list.Add("highlightColor", new ConfigOption("highlightColor", new SerializationOptions("hlColor"), "C3DAF9", this.HighlightColor ));
                list.Add("highlightDrop", new ConfigOption("highlightDrop", new SerializationOptions("hlDrop"), true, this.HighlightDrop ));
                list.Add("lines", new ConfigOption("lines", null, true, this.Lines ));
                list.Add("pathSeparator", new ConfigOption("pathSeparator", null, "/", this.PathSeparator ));
                list.Add("activeEditor", new ConfigOption("activeEditor", null, "", this.ActiveEditor ));
                list.Add("loader", new ConfigOption("loader", new SerializationOptions("loader>Primary"), null, this.Loader ));
                list.Add("rootVisible", new ConfigOption("rootVisible", null, true, this.RootVisible ));
                list.Add("selectionModel", new ConfigOption("selectionModel", new SerializationOptions("selModel>Primary"), null, this.SelectionModel ));
                list.Add("singleExpand", new ConfigOption("singleExpand", null, false, this.SingleExpand ));
                list.Add("trackMouseOver", new ConfigOption("trackMouseOver", null, true, this.TrackMouseOver ));
                list.Add("useArrows", new ConfigOption("useArrows", null, false, this.UseArrows ));
                list.Add("noLeafIcon", new ConfigOption("noLeafIcon", null, false, this.NoLeafIcon ));
                list.Add("editors", new ConfigOption("editors", new SerializationOptions("editors", typeof(ItemCollectionJsonConverter)), null, this.Editors ));
                list.Add("selectionSubmitConfig", new ConfigOption("selectionSubmitConfig", new SerializationOptions(JsonMode.Object), null, this.SelectionSubmitConfig ));
                list.Add("sorter", new ConfigOption("sorter", new SerializationOptions(JsonMode.Object), null, this.Sorter ));
                list.Add("directEventConfig", new ConfigOption("directEventConfig", new SerializationOptions(JsonMode.Object), null, this.DirectEventConfig ));
                list.Add("mode", new ConfigOption("mode", new SerializationOptions(JsonMode.ToLower), TreePanelMode.Local, this.Mode ));
                list.Add("remoteJson", new ConfigOption("remoteJson", null, false, this.RemoteJson ));
                list.Add("localActions", new ConfigOption("localActions", new SerializationOptions(typeof(StringArrayJsonConverter)), null, this.LocalActions ));
                list.Add("nodes", new ConfigOption("nodes", new SerializationOptions(JsonMode.Raw), "", this.Nodes ));

                return list;
            }
        }
    }
}