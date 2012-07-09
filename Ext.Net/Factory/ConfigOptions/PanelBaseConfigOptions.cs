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
    public abstract partial class PanelBase
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
                
                list.Add("renderToProxy", new ConfigOption("renderToProxy", new SerializationOptions("renderTo"), "", this.RenderToProxy ));
                list.Add("animCollapse", new ConfigOption("animCollapse", null, true, this.AnimCollapse ));
                list.Add("autoLoadProxy", new ConfigOption("autoLoadProxy", new SerializationOptions("autoLoad", JsonMode.Raw), "", this.AutoLoadProxy ));
                list.Add("baseCls", new ConfigOption("baseCls", null, "", this.BaseCls ));
                list.Add("bottomBar", new ConfigOption("bottomBar", new SerializationOptions("bbar", typeof(ItemCollectionJsonConverter)), null, this.BottomBar ));
                list.Add("closable", new ConfigOption("closable", null, false, this.Closable ));
                list.Add("closeAction", new ConfigOption("closeAction", new SerializationOptions(JsonMode.ToLower), CloseAction.Close, this.CloseAction ));
                list.Add("topBar", new ConfigOption("topBar", new SerializationOptions("tbar", typeof(ItemCollectionJsonConverter)), null, this.TopBar ));
                list.Add("footerBar", new ConfigOption("footerBar", new SerializationOptions("fbar", typeof(ItemCollectionJsonConverter)), null, this.FooterBar ));
                list.Add("bodyBorder", new ConfigOption("bodyBorder", null, true, this.BodyBorder ));
                list.Add("bodyCssClass", new ConfigOption("bodyCssClass", null, "", this.BodyCssClass ));
                list.Add("bodyStyle", new ConfigOption("bodyStyle", null, "", this.BodyStyle ));
                list.Add("borderProxy", new ConfigOption("borderProxy", new SerializationOptions("border"), true, this.BorderProxy ));
                list.Add("buttonAlign", new ConfigOption("buttonAlign", new SerializationOptions(JsonMode.ToLower), Alignment.Right, this.ButtonAlign ));
                list.Add("buttons", new ConfigOption("buttons", new SerializationOptions("buttons", typeof(ItemCollectionJsonConverter)), null, this.Buttons ));
                list.Add("collapseFirst", new ConfigOption("collapseFirst", null, true, this.CollapseFirst ));
                list.Add("collapsed", new ConfigOption("collapsed", null, false, this.Collapsed ));
                list.Add("collapsedCls", new ConfigOption("collapsedCls", null, "", this.CollapsedCls ));
                list.Add("collapsible", new ConfigOption("collapsible", null, false, this.Collapsible ));
                list.Add("draggable", new ConfigOption("draggable", null, false, this.Draggable ));
                list.Add("draggableConfigProxy", new ConfigOption("draggableConfigProxy", new SerializationOptions("draggable", JsonMode.Raw), "", this.DraggableConfigProxy ));
                list.Add("elements", new ConfigOption("elements", null, "", this.Elements ));
                list.Add("floating", new ConfigOption("floating", null, false, this.Floating ));
                list.Add("footer", new ConfigOption("footer", null, false, this.Footer ));
                list.Add("frame", new ConfigOption("frame", null, false, this.Frame ));
                list.Add("header", new ConfigOption("header", null, true, this.Header ));
                list.Add("headerAsText", new ConfigOption("headerAsText", null, true, this.HeaderAsText ));
                list.Add("hideCollapseTool", new ConfigOption("hideCollapseTool", null, false, this.HideCollapseTool ));
                list.Add("iconClsProxy", new ConfigOption("iconClsProxy", new SerializationOptions("iconCls"), "", this.IconClsProxy ));
                list.Add("keyMap", new ConfigOption("keyMap", new SerializationOptions("keys", JsonMode.Array), null, this.KeyMap ));
                list.Add("maskDisabled", new ConfigOption("maskDisabled", null, true, this.MaskDisabled ));
                list.Add("minButtonWidth", new ConfigOption("minButtonWidth", null, Unit.Pixel(75), this.MinButtonWidth ));
                list.Add("shadow", new ConfigOption("shadow", new SerializationOptions(typeof(ShadowJsonConverter)), ShadowMode.Sides, this.Shadow ));
                list.Add("shadowOffset", new ConfigOption("shadowOffset", null, 4, this.ShadowOffset ));
                list.Add("shim", new ConfigOption("shim", null, true, this.Shim ));
                list.Add("padding", new ConfigOption("padding", null, 0, this.Padding ));
                list.Add("paddingSummary", new ConfigOption("paddingSummary", new SerializationOptions("padding"), "", this.PaddingSummary ));
                list.Add("title", new ConfigOption("title", null, "", this.Title ));
                list.Add("titleCollapse", new ConfigOption("titleCollapse", null, false, this.TitleCollapse ));
                list.Add("tools", new ConfigOption("tools", new SerializationOptions(JsonMode.AlwaysArray), null, this.Tools ));
                list.Add("unstyled", new ConfigOption("unstyled", null, false, this.Unstyled ));
                list.Add("preventBodyReset", new ConfigOption("preventBodyReset", null, false, this.PreventBodyReset ));

                return list;
            }
        }
    }
}