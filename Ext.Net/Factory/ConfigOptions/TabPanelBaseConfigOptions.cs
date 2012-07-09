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
    public abstract partial class TabPanelBase
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
                
                list.Add("visibleIndex", new ConfigOption("visibleIndex", new SerializationOptions("activeTab"), -1, this.VisibleIndex ));
                list.Add("animScroll", new ConfigOption("animScroll", null, true, this.AnimScroll ));
                list.Add("autoTabSelector", new ConfigOption("autoTabSelector", null, "div.x-tab", this.AutoTabSelector ));
                list.Add("autoTabs", new ConfigOption("autoTabs", null, false, this.AutoTabs ));
                list.Add("baseCls", new ConfigOption("baseCls", null, "x-tab-panel", this.BaseCls ));
                list.Add("deferredRender", new ConfigOption("deferredRender", null, true, this.DeferredRender ));
                list.Add("enableTabScroll", new ConfigOption("enableTabScroll", null, false, this.EnableTabScroll ));
                list.Add("layoutOnTabChange", new ConfigOption("layoutOnTabChange", null, false, this.LayoutOnTabChange ));
                list.Add("minTabWidth", new ConfigOption("minTabWidth", null, Unit.Pixel(30), this.MinTabWidth ));
                list.Add("plain", new ConfigOption("plain", null, false, this.Plain ));
                list.Add("resizeTabs", new ConfigOption("resizeTabs", null, false, this.ResizeTabs ));
                list.Add("scrollDuration", new ConfigOption("scrollDuration", null, 0.35f, this.ScrollDuration ));
                list.Add("scrollIncrement", new ConfigOption("scrollIncrement", null, 100, this.ScrollIncrement ));
                list.Add("scrollRepeatInterval", new ConfigOption("scrollRepeatInterval", null, 400, this.ScrollRepeatInterval ));
                list.Add("tabMargin", new ConfigOption("tabMargin", null, Unit.Pixel(2), this.TabMargin ));
                list.Add("tabAlignProxy", new ConfigOption("tabAlignProxy", new SerializationOptions("tabAlign", JsonMode.ToLower), TabAlign.Left, this.TabAlignProxy ));
                list.Add("tabCls", new ConfigOption("tabCls", null, "", this.TabCls ));
                list.Add("tabPosition", new ConfigOption("tabPosition", new SerializationOptions(JsonMode.ToLower), TabPosition.Top, this.TabPosition ));
                list.Add("tabWidth", new ConfigOption("tabWidth", null, Unit.Pixel(120), this.TabWidth ));
                list.Add("wheelIncrement", new ConfigOption("wheelIncrement", null, 20, this.WheelIncrement ));
                list.Add("defaultTabMenu", new ConfigOption("defaultTabMenu", new SerializationOptions("defaultTabMenu", typeof(ItemCollectionJsonConverter)), null, this.DefaultTabMenu ));

                return list;
            }
        }
    }
}