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

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(MouseDistanceSensor), "Build.ToolboxIcons.Plugin.bmp")]    
    [Description("")]
    public partial class MouseDistanceSensor : Plugin
    {
        /// <summary>
		/// 
		/// </summary>
		[Description("")]
        public MouseDistanceSensor()
        {
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
                baseList.Capacity += 1;

                baseList.Add(new ClientScriptItem(typeof(MouseDistanceSensor), "Ext.Net.Build.Ext.Net.ux.plugins.mousedistancesensor.mousedistancesensor.js", "/ux/plugins/mousedistancesensor/mousedistancesensor.js"));

                return baseList;
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
                return "Ext.ux.MouseDistanceSensor";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. MouseDistanceSensor")]
        [DefaultValue(100)]
        [Description("")]
        public virtual int Threshold
        {
            get
            {
                object obj = this.ViewState["Threshold"];
                return (obj == null) ? 100 : (int)obj;
            }
            set
            {
                this.ViewState["Threshold"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. MouseDistanceSensor")]
        [DefaultValue(true)]
        [Description("")]
        public virtual bool Opacity
        {
            get
            {
                object obj = this.ViewState["Opacity"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["Opacity"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [NotifyParentProperty(true)]
        [Category("3. MouseDistanceSensor")]
        [DefaultValue(0)]
        [Description("")]
        public virtual decimal MinOpacity
        {
            get
            {
                object obj = this.ViewState["MinOpacity"];
                return (obj == null) ? 0 : (decimal)obj;
            }
            set
            {
                if (value > 1 || value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", value, "The value must be greater than or equals to 0 and less than or equal to 1.0.");
                }

                this.ViewState["MinOpacity"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [NotifyParentProperty(true)]
        [Category("3. MouseDistanceSensor")]
        [DefaultValue(1)]
        [Description("")]
        public virtual decimal MaxOpacity
        {
            get
            {
                object obj = this.ViewState["MaxOpacity"];
                return (obj == null) ? 1 : (decimal)obj;
            }
            set
            {
                if (value > 1 || value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", value, "The value must be greater than or equals to 0 and less than or equal to 1.0.");
                }

                this.ViewState["MaxOpacity"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [NotifyParentProperty(true)]
        [Category("3. MouseDistanceSensor")]
        [DefaultValue("")]
        [Description("")]
        public virtual string SensorElement
        {
            get
            {
                return (string)this.ViewState["SensorElement"] ?? "";
            }
            set
            {
                this.ViewState["SensorElement"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("getSensorEls", JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected virtual string SensorElementProxy
        {
            get
            {
                string sensor = this.SensorElement;
                string template = "function(){{return Ext.net.getEl({0}); }}";

                if (sensor.IsNotEmpty())
                {
                    string s = this.ParseTarget(sensor);

                    if (s.StartsWith("\""))
                    {
                        return template.FormatWith(s);
                    }

                    return template.FormatWith(TokenUtils.ParseAndNormalize(s));
                }

                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [NotifyParentProperty(true)]
        [Category("3. MouseDistanceSensor")]
        [DefaultValue("")]
        [Description("")]
        public virtual string ConstrainElement
        {
            get
            {
                return (string)this.ViewState["ConstrainElement"] ?? "";
            }
            set
            {
                this.ViewState["ConstrainElement"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("getConstrainEls", JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected virtual string ConstrainElementProxy
        {
            get
            {
                string constrain = this.ConstrainElement;
                string template = "function(){{return Ext.net.getEl({0}); }}";

                if (constrain.IsNotEmpty())
                {
                    string c = this.ParseTarget(constrain);

                    if (c.StartsWith("\""))
                    {
                        return template.FormatWith(c);
                    }

                    return template.FormatWith(TokenUtils.ParseAndNormalize(c));
                }

                return "";
            }
        }

        private MouseDistanceSensorListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ViewStateMember]
        [Description("Client-side JavaScript Event Handlers")]
        public MouseDistanceSensorListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new MouseDistanceSensorListeners();
                }

                return this.listeners;
            }
        }

        private MouseDistanceSensorDirectEvents directEvents;

        /// <summary>
        /// Server-side Ajax Event Handlers
        /// </summary>
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]
        [ViewStateMember]
        [Description("Server-side Ajax Event Handlers")]
        public MouseDistanceSensorDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new MouseDistanceSensorDirectEvents();
                }

                return this.directEvents;
            }
        }
    }
}