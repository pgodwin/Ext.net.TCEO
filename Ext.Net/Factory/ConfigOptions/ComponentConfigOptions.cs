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
    public abstract partial class Component
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
                
                list.Add("bin", new ConfigOption("bin", new SerializationOptions("bin", typeof(ItemCollectionJsonConverter), int.MinValue), null, this.Bin ));
                list.Add("contentEl", new ConfigOption("contentEl", null, "", this.ContentEl ));
                list.Add("html", new ConfigOption("html", new SerializationOptions("html"), "", this.Html ));
                list.Add("defaultAnchor", new ConfigOption("defaultAnchor", null, null, this.DefaultAnchor ));
                list.Add("anchorProxy", new ConfigOption("anchorProxy", new SerializationOptions("anchor"), null, this.AnchorProxy ));
                list.Add("columnWidthProxy", new ConfigOption("columnWidthProxy", new SerializationOptions("columnWidth", JsonMode.Raw), "0", this.ColumnWidthProxy ));
                list.Add("isFormField", new ConfigOption("isFormField", null, false, this.IsFormField ));
                list.Add("labelSeparator", new ConfigOption("labelSeparator", null, ":", this.LabelSeparator ));
                list.Add("labelStyle", new ConfigOption("labelStyle", null, "", this.LabelStyle ));
                list.Add("hideLabels", new ConfigOption("hideLabels", null, false, this.HideLabels ));
                list.Add("labelAlign", new ConfigOption("labelAlign", new SerializationOptions(JsonMode.ToLower), LabelAlign.Left, this.LabelAlign ));
                list.Add("labelWidth", new ConfigOption("labelWidth", null, 100, this.LabelWidth ));
                list.Add("labelPad", new ConfigOption("labelPad", null, 5, this.LabelPad ));
                list.Add("flex", new ConfigOption("flex", null, 0, this.Flex ));
                list.Add("rowHeightProxy", new ConfigOption("rowHeightProxy", new SerializationOptions("rowHeight", JsonMode.Raw), "0", this.RowHeightProxy ));
                list.Add("additionalConfig", new ConfigOption("additionalConfig", new SerializationOptions(JsonMode.UnrollObject), null, this.AdditionalConfig ));
                list.Add("contextMenuIDProxy", new ConfigOption("contextMenuIDProxy", new SerializationOptions("contextMenuId"), "", this.ContextMenuIDProxy ));
                list.Add("allowDomMove", new ConfigOption("allowDomMove", null, true, this.AllowDomMove ));
                list.Add("applyToProxy", new ConfigOption("applyToProxy", new SerializationOptions("applyTo"), "", this.ApplyToProxy ));
                list.Add("autoEl", new ConfigOption("autoEl", new SerializationOptions(JsonMode.Object), null, this.AutoEl ));
                list.Add("autoShow", new ConfigOption("autoShow", null, false, this.AutoShow ));
                list.Add("clearCls", new ConfigOption("clearCls", null, "x-form-clear-left", this.ClearCls ));
                list.Add("cls", new ConfigOption("cls", null, "", this.Cls ));
                list.Add("ctCls", new ConfigOption("ctCls", null, "", this.CtCls ));
                list.Add("disabled", new ConfigOption("disabled", null, false, this.Disabled ));
                list.Add("selectable", new ConfigOption("selectable", null, true, this.Selectable ));
                list.Add("disabledClass", new ConfigOption("disabledClass", null, "", this.DisabledClass ));
                list.Add("fieldLabel", new ConfigOption("fieldLabel", null, "", this.FieldLabel ));
                list.Add("hidden", new ConfigOption("hidden", null, false, this.Hidden ));
                list.Add("hideLabel", new ConfigOption("hideLabel", null, false, this.HideLabel ));
                list.Add("hideMode", new ConfigOption("hideMode", new SerializationOptions(JsonMode.ToLower), HideMode.Display, this.HideMode ));
                list.Add("hideParent", new ConfigOption("hideParent", null, false, this.HideParent ));
                list.Add("itemCls", new ConfigOption("itemCls", null, "", this.ItemCls ));
                list.Add("overCls", new ConfigOption("overCls", null, "", this.OverCls ));
                list.Add("pType", new ConfigOption("pType", new SerializationOptions("ptype"), "", this.PType ));
                list.Add("ref", new ConfigOption("ref", null, "", this.Ref ));
                list.Add("renderToProxy", new ConfigOption("renderToProxy", new SerializationOptions("renderTo"), "", this.RenderToProxy ));
                list.Add("stateEvents", new ConfigOption("stateEvents", new SerializationOptions(typeof(StringArrayJsonConverter)), null, this.StateEvents ));
                list.Add("stateID", new ConfigOption("stateID", new SerializationOptions("stateId"), "", this.StateID ));
                list.Add("stateful", new ConfigOption("stateful", null, true, this.Stateful ));
                list.Add("styleSpec", new ConfigOption("styleSpec", new SerializationOptions("style"), "", this.StyleSpec ));
                list.Add("plugins", new ConfigOption("plugins", new SerializationOptions("plugins", typeof(ItemCollectionJsonConverter)), null, this.Plugins ));
                list.Add("getState", new ConfigOption("getState", new SerializationOptions(JsonMode.Raw), null, this.GetState ));
                list.Add("autoFocus", new ConfigOption("autoFocus", null, false, this.AutoFocus ));
                list.Add("autoFocusDelay", new ConfigOption("autoFocusDelay", null, 10, this.AutoFocusDelay ));

                return list;
            }
        }
    }
}