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

using System.ComponentModel;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    [ToolboxItem(false)]
    [Description("The only required property is url. The optional properties nocache, text and scripts are shorthand for disableCaching, indicatorText and loadScripts and are used to set their associated property on this panel Updater instance.")]
    public partial class LoadConfig : BaseLoadConfig
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public LoadConfig() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public LoadConfig(string url)
        {
            this.Url = url;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public LoadConfig(string url, LoadMode mode)
        {
            this.Url = url;
            this.Mode = mode;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public LoadConfig(string url, LoadMode mode, bool noCache)
        {
            this.Url = url;
            this.Mode = mode;
            this.NoCache = noCache;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override bool IsDefault
        {
            get
            {
                return (this.Url.IsEmpty()
                    && this.Mode == LoadMode.Merge
                    && this.Callback.IsEmpty()
                    && this.Scope.IsEmpty()
                    && !this.ShowMask);
            }
        }

        //el : Ext.Element
        //The Element being updated.
        //success : Boolean
        //True for success, false for failure.
        //response : XMLHttpRequest
        //The XMLHttpRequest which processed the update.
        //options : Object
        //The config object passed to the update call.

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.ToLower)]
        [DefaultValue(LoadMode.Merge)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual LoadMode Mode
        {
            get
            {
                object obj = this.ViewState["Mode"];
                return (obj == null) ? LoadMode.Merge : (LoadMode)obj;
            }
            set
            {
                this.ViewState["Mode"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual bool PassParentSize
        {
            get
            {
                object obj = this.ViewState["PassParentSize"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["PassParentSize"] = value;
            }
        }

        /// <summary>
        /// Event which triggers loading process. Default value is render
        /// </summary>
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Event which triggers loading process. Default value is render")]
        public virtual string TriggerEvent
        {
            get
            {
                return ((string)this.ViewState["TriggerEvent"] ?? "").ToLowerInvariant();
            }
            set
            {
                this.ViewState["TriggerEvent"] = value;
            }
        }
        
        /// <summary>
        /// TriggerEvent's control
        /// </summary>
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("TriggerEvent's control")]
        public virtual string TriggerControl
        {
            get
            {
                return (string)this.ViewState["TriggerControl"] ?? "";
            }
            set
            {
                this.ViewState["TriggerControl"] = value;
            }
        }

        /// <summary>
        /// IFrame css style class
        /// </summary>
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("IFrame css style class")]
        public virtual string Cls
        {
            get
            {
                return (string)this.ViewState["Cls"] ?? "";
            }
            set
            {
                this.ViewState["Cls"] = value;
            }
        }

        /// <summary>
        /// If true then loading performs after reload function calling.
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("If true then loading performs after reload function calling.")]
        public virtual bool ManuallyTriggered
        {
            get
            {
                object obj = this.ViewState["ManuallyTriggered"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["ManuallyTriggered"] = value;
            }
        }

        /// <summary>
        /// Reload content on each show event.
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Reload content on each show event.")]
        public virtual bool ReloadOnEvent
        {
            get
            {
                object obj = this.ViewState["ReloadOnEvent"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["ReloadOnEvent"] = value;
            }
        }

        /// <summary>
        /// True to show the mask while iframe loading.
        /// </summary>
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to show the mask while iframe loading.")]
        public virtual bool ShowMask
        {
            get
            {
                object obj = this.ViewState["ShowMask"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["ShowMask"] = value;
            }
        }

        /// <summary>
        /// The IFrame LoadMask message.
        /// </summary>
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Localizable(true)]
        [Description("The IFrame LoadMask message.")]
        public virtual string MaskMsg
        {
            get
            {
                return (string)this.ViewState["MaskMsg"] ?? "";
            }
            set
            {
                this.ViewState["MaskMsg"] = value;
            }
        }

        /// <summary>
        /// The IFrame LoadMask css class.
        /// </summary>
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Localizable(true)]
        [Description("The IFrame LoadMask css class.")]
        public virtual string MaskCls
        {
            get
            {
                return (string)this.ViewState["MaskCls"] ?? "";
            }
            set
            {
                this.ViewState["MaskCls"] = value;
            }
        }

        /// <summary>
        /// True to monitor complete state of the iframe instead load event using.
        /// </summary>
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to monitor complete state of the iframe instead load event using.")]
        public virtual bool MonitorComplete
        {
            get
            {
                object obj = this.ViewState["MonitorComplete"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["MonitorComplete"] = value;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public enum LoadMode
    {
        /// <summary>
        /// 
        /// </summary>
        IFrame,

        /// <summary>
        /// 
        /// </summary>
        Merge
    }
}