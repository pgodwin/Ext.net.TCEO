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

using System.Configuration;
using System.ComponentModel;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class GlobalConfig : ConfigurationSection
    {
        private static GlobalConfig settings = ConfigurationManager.GetSection("extnet") as GlobalConfig;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static GlobalConfig Settings
        {
            get
            {
                if (settings == null)
                {
                    settings = new GlobalConfig();
                }

                return settings;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("ajaxViewStateMode", DefaultValue = ViewStateMode.Inherit, IsRequired = false)]
        [Description("")]
        public ViewStateMode AjaxViewStateMode
        {
            get
            {
                return (ViewStateMode)this["ajaxViewStateMode"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("directMethodProxy", DefaultValue = ClientProxy.Default, IsRequired = false)]
        [Description("")]
        public ClientProxy DirectMethodProxy
        {
            get
            {
                return (ClientProxy)this["directMethodProxy"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("idMode", DefaultValue = IDMode.Inherit, IsRequired = false)]
        [Description("")]
        public IDMode IDMode
        {
            get
            {
                return (IDMode)this["idMode"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("initScriptMode", DefaultValue = InitScriptMode.Inline, IsRequired = false)]
        [Description("")]
        public InitScriptMode InitScriptMode
        {
            get
            {
                return (InitScriptMode)this["initScriptMode"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("gzip", DefaultValue = true, IsRequired = false)]
        [Description("")]
        public bool GZip
        {
            get
            {
                return (bool)this["gzip"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("cleanResourceUrl", DefaultValue = true, IsRequired = false)]
        [Description("")]
        public bool CleanResourceUrl
        {
            get
            {
                return (bool)this["cleanResourceUrl"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("clientInitDirectMethods", DefaultValue = false, IsRequired = false)]
        [Description("")]
        public bool ClientInitDirectMethods
        {
            get
            {
                return (bool)this["clientInitDirectMethods"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("scriptAdapter", DefaultValue = ScriptAdapter.Ext, IsRequired = false)]
        [Description("")]
        public ScriptAdapter ScriptAdapter
        {
            get
            {
                return (ScriptAdapter)this["scriptAdapter"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("renderScripts", DefaultValue = ResourceLocationType.Embedded, IsRequired = false)]
        [Description("")]
        public ResourceLocationType RenderScripts
        {
            get
            {
                return (ResourceLocationType)this["renderScripts"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("renderStyles", DefaultValue = ResourceLocationType.Embedded, IsRequired = false)]
        [Description("")]
        public ResourceLocationType RenderStyles
        {
            get
            {
                return (ResourceLocationType)this["renderStyles"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("resourcePath", DefaultValue = "~/Ext.Net/", IsRequired = false)]
        [Description("")]
        public string ResourcePath
        {
            get
            {
                return (string)this["resourcePath"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("scriptMode", DefaultValue = ScriptMode.Release, IsRequired = false)]
        [Description("")]
        public ScriptMode ScriptMode
        {
            get
            {
                return (ScriptMode)this["scriptMode"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("sourceFormatting", DefaultValue = false, IsRequired = false)]
        [Description("")]
        public bool SourceFormatting
        {
            get
            {
                return (bool)this["sourceFormatting"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("stateProvider", DefaultValue = StateProvider.PostBack, IsRequired = false)]
        [Description("")]
        public StateProvider StateProvider
        {
            get
            {
                return (StateProvider)this["stateProvider"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("theme", DefaultValue = Theme.Default, IsRequired = false)]
        [Description("")]
        public Theme Theme
        {
            get
            {
                Theme theme = (Theme)this["theme"];
                return theme;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("quickTips", DefaultValue = true, IsRequired = false)]
        [Description("")]
        public bool QuickTips
        {
            get
            {
                return (bool)this["quickTips"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("directEventUrl", DefaultValue = "", IsRequired = false)]
        [Description("")]
        public string DirectEventUrl
        {
            get
            {
                return (string)this["directEventUrl"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("locale", DefaultValue = "", IsRequired = false)]
        [Description("")]
        public string Locale
        {
            get
            {
                return (string)this["locale"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("directMethodNamespace", DefaultValue = "Ext.net.DirectMethods", IsRequired = false)]
        [Description("")]
        public string DirectMethodNamespace
        {
            get
            {
                return (string)this["directMethodNamespace"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("disableViewState", DefaultValue = false, IsRequired = false)]
        [Description("")]
        public bool DisableViewState
        {
            get
            {
                return (bool)this["disableViewState"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("rethrowAjaxExceptions", DefaultValue = false, IsRequired = false)]
        [Description("")]
        public bool RethrowAjaxExceptions
        {
            get
            {
                return (bool)this["rethrowAjaxExceptions"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("showWarningOnAjaxFailure", DefaultValue = true, IsRequired = false)]
        [Description("")]
        public bool ShowWarningOnAjaxFailure
        {
            get
            {
                return (bool)this["showWarningOnAjaxFailure"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("manageEventsViewState", DefaultValue = false, IsRequired = false)]
        [Description("")]
        public bool ManageEventsViewState
        {
            get
            {
                return (bool)this["manageEventsViewState"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("debugConsole", DefaultValue = DebugConsole.None, IsRequired = false)]
        [Description("")]
        public DebugConsole DebugConsole
        {
            get
            {
                return (DebugConsole)this["debugConsole"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("designMode", DefaultValue = DesignMode.Enabled, IsRequired = false)]
        [Description("")]
        public DesignMode DesignMode
        {
            get
            {
                return (DesignMode)this["designMode"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("lazyMode", DefaultValue = LazyMode.Inherit, IsRequired = false)]
        [Description("")]
        public LazyMode LazyMode
        {
            get
            {
                return (LazyMode)this["lazyMode"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("submitDisabled", DefaultValue = true, IsRequired = false)]
        [Description("")]
        public bool SubmitDisabled
        {
            get
            {
                return (bool)this["submitDisabled"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("namespace", DefaultValue = "", IsRequired = false)]
        [Description("")]
        public string Namespace
        {
            get
            {
                return (string)this["namespace"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("licenseKey", DefaultValue = "", IsRequired = false)]
        [Description("")]
        public string LicenseKey
        {
            get
            {
                return (string)this["licenseKey"];
            }
        }

        //[ConfigurationProperty("settings")]
        //public ExtNetConfigurationElementCollection Settings
        //{
        //    get
        //    {
        //        return (ExtNetConfigurationElementCollection)this["settings"];
        //    }
        //}
    }

    //public partial class ExtNetConfigurationElement : ConfigurationElement
    //{
    //    [ConfigurationProperty("key", IsRequired = true)]
    //    public string Key
    //    {
    //        get
    //        {
    //            return this["key"] as string;
    //        }
    //    }

    //    [ConfigurationProperty("value", IsRequired = false)]
    //    public string Value
    //    {
    //        get
    //        {
    //            return this["value"] as string;
    //        }
    //    }
    //}

    //public partial class ExtNetConfigurationElementCollection : ConfigurationElementCollection
    //{
    //    public ExtNetConfigurationElement this[int index]
    //    {
    //        get
    //        {
    //            return (ExtNetConfigurationElement)base.BaseGet(index);
    //        }
    //        set
    //        {
    //            if (base.BaseGet(index) != null)
    //            {
    //                base.BaseRemoveAt(index);
    //            }
    //            this.BaseAdd(index, value);
    //        }
    //    }

    //    public ExtNetConfigurationElement this[string name]
    //    {
    //        get
    //        {
    //            object value = base.BaseGet(name);
    //            return (value == null) ? null : (ExtNetConfigurationElement)value;

    //            //return (ExtNetConfigurationElement)base.BaseGet(name);
    //        }
    //        set
    //        {
    //            if (base.BaseGet(name) != null)
    //            {
    //                base.BaseRemove(name);
    //            }
    //            this.BaseAdd(value);
    //        }
    //    }

    //    protected override ConfigurationElement CreateNewElement()
    //    {
    //        return new ExtNetConfigurationElement();
    //    }

    //    protected override object GetElementKey(ConfigurationElement element)
    //    {
    //        return ((ExtNetConfigurationElement)element).Key;
    //    }
    //}
}