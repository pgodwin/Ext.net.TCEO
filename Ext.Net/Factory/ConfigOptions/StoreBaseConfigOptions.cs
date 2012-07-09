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
    public abstract partial class StoreBase
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
                
                list.Add("autoDestroy", new ConfigOption("autoDestroy", null, false, this.AutoDestroy ));
                list.Add("autoLoadProxy", new ConfigOption("autoLoadProxy", new SerializationOptions("autoLoad"), false, this.AutoLoadProxy ));
                list.Add("restful", new ConfigOption("restful", null, false, this.Restful ));
                list.Add("saveAllFields", new ConfigOption("saveAllFields", null, true, this.SaveAllFields ));
                list.Add("autoSave", new ConfigOption("autoSave", null, false, this.AutoSave ));
                list.Add("autoLoadParamsProxy", new ConfigOption("autoLoadParamsProxy", new SerializationOptions("autoLoad", typeof(AutoLoadParamsJsonConverter)), null, this.AutoLoadParamsProxy ));
                list.Add("proxy", new ConfigOption("proxy", new SerializationOptions("proxy>Proxy"), null, this.Proxy ));
                list.Add("updateProxy", new ConfigOption("updateProxy", new SerializationOptions("updateProxy>Proxy"), null, this.UpdateProxy ));
                list.Add("reader", new ConfigOption("reader", new SerializationOptions("reader>Reader"), null, this.Reader ));
                list.Add("pruneModifiedRecords", new ConfigOption("pruneModifiedRecords", null, false, this.PruneModifiedRecords ));
                list.Add("remoteSort", new ConfigOption("remoteSort", null, false, this.RemoteSort ));
                list.Add("sortInfo", new ConfigOption("sortInfo", new SerializationOptions(JsonMode.Object), null, this.SortInfo ));
                list.Add("warningOnDirty", new ConfigOption("warningOnDirty", null, true, this.WarningOnDirty ));
                list.Add("dirtyWarningTitle", new ConfigOption("dirtyWarningTitle", null, "Uncommitted Changes", this.DirtyWarningTitle ));
                list.Add("dirtyWarningText", new ConfigOption("dirtyWarningText", null, "You have uncommitted changes.  Are you sure you want to load/reload data?", this.DirtyWarningText ));
                list.Add("refreshAfterSaving", new ConfigOption("refreshAfterSaving", new SerializationOptions("refreshAfterSave", JsonMode.Value), RefreshAfterSavingMode.Auto, this.RefreshAfterSaving ));
                list.Add("useIdConfirmation", new ConfigOption("useIdConfirmation", new SerializationOptions("useIdConfirmation", JsonMode.Value), false, this.UseIdConfirmation ));
                list.Add("directEventConfig", new ConfigOption("directEventConfig", new SerializationOptions(JsonMode.ObjectAllowEmpty), null, this.DirectEventConfig ));
                list.Add("groupField", new ConfigOption("groupField", null, "", this.GroupField ));
                list.Add("groupDir", new ConfigOption("groupDir", new SerializationOptions(JsonMode.ToLower), SortDirection.Default, this.GroupDir ));
                list.Add("groupOnSort", new ConfigOption("groupOnSort", null, false, this.GroupOnSort ));
                list.Add("remoteGroup", new ConfigOption("remoteGroup", null, false, this.RemoteGroup ));
                list.Add("showWarningOnFailure", new ConfigOption("showWarningOnFailure", null, true, this.ShowWarningOnFailure ));
                list.Add("skipIdForNewRecords", new ConfigOption("skipIdForNewRecords", null, true, this.SkipIdForNewRecords ));

                return list;
            }
        }
    }
}