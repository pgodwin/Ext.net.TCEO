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
    public abstract partial class ComboBoxBase<T>
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
                
                list.Add("allQuery", new ConfigOption("allQuery", null, "", this.AllQuery ));
                list.Add("clearFilterOnReset", new ConfigOption("clearFilterOnReset", null, true, this.ClearFilterOnReset ));
                list.Add("displayField", new ConfigOption("displayField", null, "", this.DisplayField ));
                list.Add("forceSelection", new ConfigOption("forceSelection", null, true, this.ForceSelection ));
                list.Add("handleHeight", new ConfigOption("handleHeight", null, Unit.Pixel(8), this.HandleHeight ));
                list.Add("hiddenID", new ConfigOption("hiddenID", new SerializationOptions("hiddenId"), "", this.HiddenID ));
                list.Add("hiddenValue", new ConfigOption("hiddenValue", null, "", this.HiddenValue ));
                list.Add("hiddenName", new ConfigOption("hiddenName", null, "", this.HiddenName ));
                list.Add("itemSelector", new ConfigOption("itemSelector", null, "", this.ItemSelector ));
                list.Add("lazyInit", new ConfigOption("lazyInit", null, true, this.LazyInit ));
                list.Add("lazyRender", new ConfigOption("lazyRender", null, false, this.LazyRender ));
                list.Add("fireSelectOnLoad", new ConfigOption("fireSelectOnLoad", null, false, this.FireSelectOnLoad ));
                list.Add("listAlign", new ConfigOption("listAlign", null, "", this.ListAlign ));
                list.Add("listClass", new ConfigOption("listClass", null, "", this.ListClass ));
                list.Add("listWidth", new ConfigOption("listWidth", null, Unit.Empty, this.ListWidth ));
                list.Add("loadingText", new ConfigOption("loadingText", null, "Loading...", this.LoadingText ));
                list.Add("maxHeight", new ConfigOption("maxHeight", null, Unit.Pixel(300), this.MaxHeight ));
                list.Add("minHeight", new ConfigOption("minHeight", null, Unit.Pixel(90), this.MinHeight ));
                list.Add("minChars", new ConfigOption("minChars", null, 4, this.MinChars ));
                list.Add("minListWidth", new ConfigOption("minListWidth", null, Unit.Pixel(70), this.MinListWidth ));
                list.Add("mode", new ConfigOption("mode", new SerializationOptions(JsonMode.ToLower), DataLoadMode.Remote, this.Mode ));
                list.Add("pageSize", new ConfigOption("pageSize", null, 0, this.PageSize ));
                list.Add("queryDelay", new ConfigOption("queryDelay", null, 500, this.QueryDelay ));
                list.Add("queryParam", new ConfigOption("queryParam", null, "query", this.QueryParam ));
                list.Add("resizable", new ConfigOption("resizable", null, false, this.Resizable ));
                list.Add("selectedClass", new ConfigOption("selectedClass", null, "", this.SelectedClass ));
                list.Add("shadow", new ConfigOption("shadow", new SerializationOptions(typeof(ShadowJsonConverter)), ShadowMode.Sides, this.Shadow ));
                list.Add("enableShadow", new ConfigOption("enableShadow", new SerializationOptions("shadow"), true, this.EnableShadow ));
                list.Add("selectOnFocusProxy", new ConfigOption("selectOnFocusProxy", new SerializationOptions("selectOnFocus"), false, this.SelectOnFocusProxy ));
                list.Add("template", new ConfigOption("template", new SerializationOptions("tpl", typeof(LazyControlJsonConverter)), null, this.Template ));
                list.Add("transform", new ConfigOption("transform", null, "", this.Transform ));
                list.Add("title", new ConfigOption("title", null, "", this.Title ));
                list.Add("triggerAction", new ConfigOption("triggerAction", new SerializationOptions(JsonMode.ToLower), TriggerAction.Query, this.TriggerAction ));
                list.Add("typeAhead", new ConfigOption("typeAhead", null, false, this.TypeAhead ));
                list.Add("typeAheadDelay", new ConfigOption("typeAheadDelay", null, 250, this.TypeAheadDelay ));
                list.Add("valueField", new ConfigOption("valueField", null, "", this.ValueField ));
                list.Add("valueNotFoundText", new ConfigOption("valueNotFoundText", null, "", this.ValueNotFoundText ));
                list.Add("storeID", new ConfigOption("storeID", new SerializationOptions("store", JsonMode.ToClientID), "", this.StoreID ));
                list.Add("store", new ConfigOption("store", new SerializationOptions("store>Primary"), null, this.Store ));
                list.Add("alwaysMergeItems", new ConfigOption("alwaysMergeItems", null, true, this.AlwaysMergeItems ));
                list.Add("itemsProxy", new ConfigOption("itemsProxy", new SerializationOptions("store", JsonMode.Raw), "", this.ItemsProxy ));
                list.Add("mergeItems", new ConfigOption("mergeItems", new SerializationOptions("mergeItems", JsonMode.Raw), "", this.MergeItems ));
                list.Add("submitValueProxy", new ConfigOption("submitValueProxy", new SerializationOptions("submitValue", JsonMode.Raw), "", this.SubmitValueProxy ));
                list.Add("getListParent", new ConfigOption("getListParent", new SerializationOptions(JsonMode.Raw), null, this.GetListParent ));

                return list;
            }
        }
    }
}