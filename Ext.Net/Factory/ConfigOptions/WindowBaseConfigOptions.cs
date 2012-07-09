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
    public abstract partial class WindowBase
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
                
                list.Add("animateTarget", new ConfigOption("animateTarget", null, "", this.AnimateTarget ));
                list.Add("closable", new ConfigOption("closable", null, true, this.Closable ));
                list.Add("closeAction", new ConfigOption("closeAction", new SerializationOptions(JsonMode.ToLower), CloseAction.Hide, this.CloseAction ));
                list.Add("constrain", new ConfigOption("constrain", null, false, this.Constrain ));
                list.Add("constrainHeader", new ConfigOption("constrainHeader", null, false, this.ConstrainHeader ));
                list.Add("defaultButton", new ConfigOption("defaultButton", null, "", this.DefaultButton ));
                list.Add("defaultRenderTo", new ConfigOption("defaultRenderTo", new SerializationOptions(JsonMode.ToLower), DefaultRenderTo.Body, this.DefaultRenderTo ));
                list.Add("draggable", new ConfigOption("draggable", null, true, this.Draggable ));
                list.Add("expandOnShowProxy", new ConfigOption("expandOnShowProxy", new SerializationOptions("expandOnShow"), true, this.ExpandOnShowProxy ));
                list.Add("hiddenProxy", new ConfigOption("hiddenProxy", new SerializationOptions("hidden"), true, this.HiddenProxy ));
                list.Add("maximizable", new ConfigOption("maximizable", null, false, this.Maximizable ));
                list.Add("maximized", new ConfigOption("maximized", null, false, this.Maximized ));
                list.Add("height", new ConfigOption("height", null, Unit.Empty, this.Height ));
                list.Add("minHeight", new ConfigOption("minHeight", null, Unit.Pixel(100), this.MinHeight ));
                list.Add("width", new ConfigOption("width", null, Unit.Empty, this.Width ));
                list.Add("minWidth", new ConfigOption("minWidth", null, Unit.Pixel(200), this.MinWidth ));
                list.Add("minimizable", new ConfigOption("minimizable", null, false, this.Minimizable ));
                list.Add("modal", new ConfigOption("modal", null, false, this.Modal ));
                list.Add("onEsc", new ConfigOption("onEsc", new SerializationOptions(JsonMode.Raw), "Ext.emptyFn", this.OnEsc ));
                list.Add("plain", new ConfigOption("plain", null, false, this.Plain ));
                list.Add("resizable", new ConfigOption("resizable", null, true, this.Resizable ));
                list.Add("resizeHandles", new ConfigOption("resizeHandles", null, "all", this.ResizeHandles ));
                list.Add("initCenterProxy", new ConfigOption("initCenterProxy", new SerializationOptions("initCenter"), true, this.InitCenterProxy ));
                list.Add("renderToProxy", new ConfigOption("renderToProxy", new SerializationOptions("renderTo"), "", this.RenderToProxy ));

                return list;
            }
        }
    }
}