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
using System.Web;

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
    public partial class ResourceManager
    {
        private static object Session(string name)
        {
            if (HttpContext.Current.Session != null)
            {
                return HttpContext.Current.Session[name];
            }

            return null;
        }
        
        private string directEventUrl = null;

        /// <summary>
        /// Gets or Set the default Url to make all DirectEvent requests to if no &lt;form> is available on the Page, or DirectEvent Type='Load'. Can be set at Page level in ResourceManager, Session[\"Ext.Net.DirectEventUrl\"], Application[\"Ext.Net.DirectEventUrl\"] and web.config.
        /// </summary>
        [Category("Config Options")]
        [DefaultValue("")]
        [Description("Gets or Set the default Url to make all DirectEvent requests to if no &lt;form> is available on the Page, or DirectEvent Type='Load'. Can be set at Page level in ResourceManager, Session[\"Ext.Net.DirectEventUrl\"], Application[\"Ext.Net.DirectEventUrl\"] and web.config.")]
        public virtual string DirectEventUrl
        {
            get
            {
                if (this.directEventUrl != null)
                {
                    return this.directEventUrl;
                }

                if (!this.DesignMode && HttpContext.Current != null)
                {
                    string token = "Ext.Net.DirectEventUrl";

                    object obj = HttpContext.Current.Application[token];

                    if (obj == null)
                    {
                        obj = Session(token);
                    }

                    if (obj != null && obj is string)
                    {
                        return (string)obj;
                    }
                }

                return GlobalConfig.Settings.DirectEventUrl;
            }
            set
            {
                this.directEventUrl = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("url")]
        [DefaultValue("")]
        [Description("")]
        protected virtual string DirectEventUrlProxy
        {
            get
            {
                if (this.DirectEventUrl.IsNotEmpty())
                {
                    return this.ResolveUrl(this.DirectEventUrl);
                }

                return this.DirectEventUrl;
            }
        }

        private object ajaxViewStateMode = null;

        /// <summary>
        /// Specifies whether the ViewState should be returned and updated on the client during an DirectEvent. The Default value is to Exclude the ViewState from the Response. Can be set at Page level in ResourceManager, Session[\"Ext.Net.AjaxViewStateMode\"], Application[\"Ext.Net.AjaxViewStateMode\"] and web.config.
        /// </summary>
        [Category("Config Options")]
        [DefaultValue(typeof(Ext.Net.ViewStateMode), "Inherit")]
        [Description("Specifies whether the ViewState should be returned and updated on the client during an DirectEvent. The Default value is to Exclude the ViewState from the Response. Can be set at Page level in ResourceManager, Session[\"Ext.Net.AjaxViewStateMode\"], Application[\"Ext.Net.AjaxViewStateMode\"] and web.config.")]
        public virtual ViewStateMode AjaxViewStateMode
        {
            get
            {
                if (this.ajaxViewStateMode != null)
                {
                    return (ViewStateMode)this.ajaxViewStateMode;
                }

                if (!this.DesignMode && HttpContext.Current != null)
                {
                    string token = "Ext.Net.AjaxViewStateMode";

                    object obj = HttpContext.Current.Application[token];

                    if (obj == null)
                    {
                        obj = Session(token);
                    }

                    if (obj != null && obj is ViewStateMode)
                    {
                        return (ViewStateMode)obj;
                    }
                }
                else
                {
                    return WebConfigUtils.GetAjaxViewStateFromWebConfig(this.Site);
                }

                return GlobalConfig.Settings.AjaxViewStateMode;
            }
            set
            {
                this.ajaxViewStateMode = value;
            }
        }

        private object directMethodProxy = null;

        /// <summary>
        /// Specifies ajax method proxies creation. The Default value is to Create the proxy for each ajax method. Can be set at Page level in ResourceManager, Session[\"Ext.Net.DirectMethodProxy\"], Application[\"Ext.Net.DirectMethodProxy\"] and web.config.
        /// </summary>
        [Category("Config Options")]
        [DefaultValue(ClientProxy.Default)]
        [Description("Specifies ajax method proxies creation. The Default value is to Create the proxy for each ajax method. Can be set at Page level in ResourceManager, Session[\"Ext.Net.DirectMethodProxy\"], Application[\"Ext.Net.DirectMethodProxy\"] and web.config.")]
        public virtual ClientProxy DirectMethodProxy
        {
            get
            {
                if (this.directMethodProxy != null)
                {
                    return (ClientProxy)this.directMethodProxy;
                }

                if (!this.DesignMode && HttpContext.Current != null)
                {
                    string token = "Ext.Net.DirectMethodProxy";

                    object obj = HttpContext.Current.Application[token];

                    if (obj == null)
                    {
                        obj = Session(token);
                    }

                    if (obj != null && obj is ClientProxy)
                    {
                        return (ClientProxy)obj;
                    }
                }
                else
                {
                    return WebConfigUtils.GetDirectMethodProxyFromWebConfig(this.Site);
                }

                return GlobalConfig.Settings.DirectMethodProxy;
            }
            set
            {
                this.directMethodProxy = value;
            }
        }
        
        private object idMode = null;

        /// <summary>
        /// Gets or Sets the IDMode. Can be set at Page level in ResourceManager, Session[\"Ext.Net.IDMode\"], Application[\"Ext.Net.IDMode\"] and web.config.
        /// </summary>
        [Category("Config Options")]
        [DefaultValue(IDMode.Inherit)]
        [Description("Gets or Sets the IDMode. Can be set at Page level in ResourceManager, Session[\"Ext.Net.IDMode\"], Application[\"Ext.Net.IDMode\"] and web.config.")]
        public override IDMode IDMode
        {
            get
            {
                if (this.idMode != null)
                {
                    return (IDMode)this.idMode;
                }

                if (!this.DesignMode && HttpContext.Current != null)
                {
                    string token = "Ext.Net.IDMode";

                    object obj = HttpContext.Current.Application[token];

                    if (obj == null)
                    {
                        obj = Session(token);
                    }

                    if (obj != null && obj is IDMode)
                    {
                        return (IDMode)obj;
                    }
                }
                else
                {
                    return WebConfigUtils.GetIDModeFromWebConfig(this.Site);
                }

                return GlobalConfig.Settings.IDMode;
            }
            set
            {
                this.idMode = value;
            }
        }

        private bool? gzip;
        
        /// <summary>
        /// Specifies whether the Ext.NET ResourceManager will output GZip Embedded JavaScript and Css Resources. Default is 'True'. Can be set within Session[\"Ext.Net.GZip\"], Application[\"Ext.Net.GZip\"] and web.config.
        /// </summary>
        [Category("Config Options")]
        [DefaultValue(true)]
        [Description("Specifies whether the Ext.NET ResourceManager will output GZip Embedded JavaScript and Css Resources. Default is 'True'. Can be set within Session[\"Ext.Net.GZip\"], Application[\"Ext.Net.GZip\"] and web.config.")]
        public virtual bool GZip
        {
            get
            {
                if (this.gzip != null)
                {
                    return (bool)this.gzip;
                }

                if (!this.DesignMode && HttpContext.Current != null)
                {
                    string token = "Ext.Net.GZip";
                    object obj = HttpContext.Current.Application[token];

                    if (obj == null)
                    {
                        obj = Session(token);
                    }

                    if (obj != null && obj is bool)
                    {
                        return (bool)obj;
                    }
                }

                return GlobalConfig.Settings.GZip;
            }
            set
            {
                this.gzip = value;
            }
        }

        private bool? cleanResourceUrl;

        /// <summary>
        /// Specifies whether the Ext.NET ResourceManager will output 'clean' Url's when linking to Embedded Resources. Default is 'True'. Can be set at Page level in ResourceManager, Session[\"Ext.Net.CleanResourceUrl\"], Application[\"Ext.Net.CleanResourceUrl\"] and web.config.
        /// </summary>
        [Category("Config Options")]
        [DefaultValue(true)]
        [Description("Specifies whether the Ext.NET ResourceManager will output 'clean' Url's when linking to Embedded Resources. Default is 'True'. Can be set at Page level in ResourceManager, Session[\"Ext.Net.CleanResourceUrl\"], Application[\"Ext.Net.CleanResourceUrl\"] and web.config.")]
        public virtual bool CleanResourceUrl
        {
            get
            {
                if (this.cleanResourceUrl != null)
                {
                    return (bool)this.cleanResourceUrl;
                }

                if (!this.DesignMode && HttpContext.Current != null)
                {
                    string token = "Ext.Net.CleanResourceUrl";

                    object obj = HttpContext.Current.Application[token];

                    if (obj == null)
                    {
                        obj = Session(token);
                    }

                    if (obj != null && obj is bool)
                    {
                        return (bool)obj;
                    }
                }

                return GlobalConfig.Settings.CleanResourceUrl;
            }
            set
            {
                this.cleanResourceUrl = value;
            }
        }


        private object initScriptMode = null;

        /// <summary>
        /// Gets or Sets the InitScriptMode. Can be set at Page level in ResourceManager, Session[\"Ext.Net.InitScriptMode\"], Application[\"Ext.Net.InitScriptMode\"] and web.config.
        /// </summary>
        [Category("Config Options")]
        [DefaultValue(InitScriptMode.Inline)]
        [Description("Gets or Sets the InitScriptMode. Can be set at Page level in ResourceManager, Session[\"Ext.Net.InitScriptMode\"], Application[\"Ext.Net.InitScriptMode\"] and web.config.")]
        public virtual InitScriptMode InitScriptMode
        {
            get
            {
                if (this.initScriptMode != null)
                {
                    return (InitScriptMode)this.initScriptMode;
                }

                if (!this.DesignMode && HttpContext.Current != null)
                {
                    string token = "Ext.Net.InitScriptMode";

                    object obj = HttpContext.Current.Application[token];

                    if (obj == null)
                    {
                        obj = Session(token);
                    }

                    if (obj != null && obj is InitScriptMode)
                    {
                        return (InitScriptMode)obj;
                    }
                }
                else
                {
                    return WebConfigUtils.GetInitScriptModeFromWebConfig(this.Site);
                }

                return GlobalConfig.Settings.InitScriptMode;
            }
            set
            {
                this.initScriptMode = value;
            }
        }

        private object renderScripts = null;

        /// <summary>
        /// Determines how or if the required Scripts should be rendered to the Page. Can be set at Page level in ResourceManager, Session[\"Ext.Net.RenderScripts\"], Application[\"Ext.Net.RenderScripts\"] and web.config.
        /// </summary>
        [Category("Config Options")]
        [DefaultValue(ResourceLocationType.Embedded)]
        [Description("Determines how or if the required Scripts should be rendered to the Page. Can be set at Page level in ResourceManager, Session[\"Ext.Net.RenderScripts\"], Application[\"Ext.Net.RenderScripts\"] and web.config.")]
        public virtual ResourceLocationType RenderScripts
        {
            get
            {
                if (this.renderScripts != null)
                {
                    return (ResourceLocationType)this.renderScripts;
                }

                if (!this.DesignMode && HttpContext.Current != null)
                {
                    string token = "Ext.Net.RenderScripts";

                    object obj = HttpContext.Current.Application[token];

                    if (obj == null)
                    {
                        obj = Session(token);
                    }

                    if (obj != null && obj is ResourceLocationType)
                    {
                        return (ResourceLocationType)obj;
                    }
                }

                return GlobalConfig.Settings.RenderScripts;
            }
            set
            {
                this.renderScripts = value;
            }
        }

        private object renderStyles = null;

        /// <summary>
        /// Determines how or if the required Styles should be rendered to the Page. Can be set at Page level in ResourceManager, Session[\"Ext.Net.RenderStyles\"], Application[\"Ext.Net.RenderStyles\"] and web.config.
        /// </summary>
        [Category("Config Options")]
        [DefaultValue(ResourceLocationType.Embedded)]
        [Description("Determines how or if the required Styles should be rendered to the Page. Can be set at Page level in ResourceManager, Session[\"Ext.Net.RenderStyles\"], Application[\"Ext.Net.RenderStyles\"] and web.config.")]
        public virtual ResourceLocationType RenderStyles
        {
            get
            {
                if (this.renderStyles != null)
                {
                    return (ResourceLocationType)this.renderStyles;
                }

                if (!this.DesignMode && HttpContext.Current != null)
                {
                    string token = "Ext.Net.RenderStyles";

                    object obj = HttpContext.Current.Application[token];

                    if (obj == null)
                    {
                        obj = Session(token);
                    }

                    if (obj != null && obj is ResourceLocationType)
                    {
                        return (ResourceLocationType)obj;
                    }
                }

                return GlobalConfig.Settings.RenderStyles;
            }
            set
            {
                this.renderStyles = value;
            }
        }

        private string resourcePath = null;

        /// <summary>
        /// Gets the prefix of the Url path to the base ~/Ext.Net/ folder containing the resources files for this project. The path can be Absolute or Relative. Can be set at Page level in ResourceManager, Session[\"Ext.Net.ResourcePath\"], Application[\"Ext.Net.ResourcePath\"] and web.config.
        /// </summary>
        [Category("Config Options")]
        [DefaultValue("~/Ext.Net/")]
        [Description("Gets the prefix of the Url path to the base ~/Ext.Net/ folder containing the resources files for this project. The path can be Absolute or Relative. Can be set at Page level in ResourceManager, Session[\"Ext.Net.ResourcePath\"], Application[\"Ext.Net.ResourcePath\"] and web.config.")]
        public virtual string ResourcePath
        {
            get
            {
                if (this.resourcePath != null)
                {
                    return (string)this.resourcePath;
                }

                if (!this.DesignMode && HttpContext.Current != null)
                {
                    string token = "Ext.Net.ResourcePath";

                    object obj = HttpContext.Current.Application[token];

                    if (obj == null)
                    {
                        obj = Session(token);
                    }

                    if (obj != null && obj is string)
                    {
                        return (string)obj;
                    }
                }

                return GlobalConfig.Settings.ResourcePath;
            }
            set
            {
                this.resourcePath = value;
            }
        }

        private object scriptMode = null;

        /// <summary>
        /// Specifies whether the Scripts should be rendered in Release or Debug mode. Default is Release. Can be set at Page level in ResourceManager, Session[\"Ext.Net.ScriptMode\"], Application[\"Ext.Net.ScriptMode\"] and web.config.
        /// </summary>
        [Category("Config Options")]
        [DefaultValue(ScriptMode.Release)]
        [Description("Specifies whether the Scripts should be rendered in Release or Debug mode. Default is Release. Can be set at Page level in ResourceManager, Session[\"Ext.Net.ScriptMode\"], Application[\"Ext.Net.ScriptMode\"] and web.config.")]
        public virtual ScriptMode ScriptMode
        {
            get
            {
                if (this.scriptMode != null)
                {
                    return (ScriptMode)this.scriptMode;
                }

                if (!this.DesignMode && HttpContext.Current != null)
                {
                    string token = "Ext.Net.ScriptMode";

                    object obj = HttpContext.Current.Application[token];

                    if (obj == null)
                    {
                        obj = Session(token);
                    }

                    if (obj != null && obj is ScriptMode)
                    {
                        return (ScriptMode)obj;
                    }
                }
                else
                {
                    return WebConfigUtils.GetScriptModeFromWebConfig(this.Site);
                }

                return GlobalConfig.Settings.ScriptMode;
            }
            set
            {
                this.scriptMode = value;
            }
        }

        private bool? sourceFormatting;

        /// <summary>
        /// Specifies whether the scripts rendered to the page should be formatted. 'True' = formatting, 'False' = minified/compressed. Default is 'False'. Can be set at Page level in ResourceManager, Session[\"Ext.Net.SourceFormatting\"], Application[\"Ext.Net.SourceFormatting\"] and web.config.
        /// </summary>
        [Category("Config Options")]
        [DefaultValue(false)]
        [Description("Specifies whether the scripts rendered to the page should be formatted. 'True' = formatting, 'False' = minified/compressed. Default is 'False'. Can be set at Page level in ResourceManager, Session[\"Ext.Net.SourceFormatting\"], Application[\"Ext.Net.SourceFormatting\"] and web.config.")]
        public virtual bool SourceFormatting
        {
            get
            {
                if (this.sourceFormatting != null)
                {
                    return (bool)this.sourceFormatting;
                }

                if (!this.DesignMode && HttpContext.Current != null)
                {
                    string token = "Ext.Net.SourceFormatting";

                    object obj = HttpContext.Current.Application[token];

                    if (obj == null)
                    {
                        obj = Session(token);
                    }

                    if (obj != null && obj is bool)
                    {
                        return (bool)obj;
                    }
                }

                return GlobalConfig.Settings.SourceFormatting;
            }
            set
            {
                this.sourceFormatting = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="theme"></param>
        /// <returns></returns>
        [Description("")]
        public virtual string GetThemeUrl(Theme theme)
        {
            ResourceLocationType type = this.RenderStyles;

            if (theme == Theme.Default)
            {
                switch (type)
                {
                    case ResourceLocationType.Embedded:
                        return this.GetWebResourceUrl(ResourceManager.ASSEMBLYSLUG + ".extjs.resources.css.ext-all-embedded.css");
                    case ResourceLocationType.File:
                        return this.ConvertToFilePath(ResourceManager.ASSEMBLYSLUG + ".extjs.resources.css.ext-all.css");
                    case ResourceLocationType.CacheFly:
                    case ResourceLocationType.CacheFlyAndFile:
                        return this.GetCacheFlyLink("resources/css/ext-all.css");
                }
            }
            
            foreach (ClientStyleItem item in this.GetStyles())
            {
                if (item.Theme.Equals(theme))
                {
                    switch (type)
                    {
                        case ResourceLocationType.Embedded:
                            return this.GetWebResourceUrl(item.Type, item.PathEmbedded);
                        case ResourceLocationType.File:
                            return this.ResourcePath.ConcatWith(item.Path);
                        case ResourceLocationType.CacheFly:
                            if (item.CacheFly.IsEmpty())
                            {
                                return this.GetWebResourceUrl(item.Type, item.PathEmbedded);
                            }

                            return item.CacheFly;
                        case ResourceLocationType.CacheFlyAndFile:
                            if (item.CacheFly.IsEmpty())
                            {
                                return this.ResourcePath.ConcatWith(item.Path);
                            }

                            return item.CacheFly;
                    }
                }
            }

            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="theme"></param>
        [Description("")]
        public void SetTheme(Theme theme)
        {
            this.Theme = theme;
            base.AddScript("Ext.net.ResourceMgr.setTheme(\"{0}\");", this.GetThemeUrl(theme));
        }

        private object theme = null;

        /// <summary>
        /// Gets or Sets the current Theme. Can be set at Page level in ResourceManager, Session[\"Ext.Net.Theme\"], Application[\"Ext.Net.Theme\"] and web.config.
        /// </summary>
        [Category("Config Options")]
        [DefaultValue(Theme.Default)]
        [Description("Gets or Sets the current Theme. Can be set at Page level in ResourceManager, Session[\"Ext.Net.Theme\"], Application[\"Ext.Net.Theme\"] and web.config.")]
        public virtual Theme Theme
        {
            get
            {
                if (this.theme != null)
                {
                    return (Theme)this.theme;
                }

                if (!this.DesignMode && HttpContext.Current != null)
                {
                    string token = "Ext.Net.Theme";

                    object obj = HttpContext.Current.Application[token];

                    if (obj == null)
                    {
                        obj = Session(token);
                    }

                    if (obj != null && obj is Theme)
                    {
                        return (Theme)obj;
                    }
                }

                return GlobalConfig.Settings.Theme;
            }
            set
            {
                this.theme = value;
            }
        }

        private object scriptAdapter = null;

        /// <summary>
        /// Gets or Sets the current script Adapter. Can be set at Page level in ResourceManager, Session[\"Ext.Net.ScriptAdapter\"], Application[\"Ext.Net.ScriptAdapter\"] and web.config.
        /// </summary>
        [Category("Config Options")]
        [DefaultValue(ScriptAdapter.Ext)]
        [Description("Gets or Sets the current script Adapter. Can be set at Page level in ResourceManager, Session[\"Ext.Net.ScriptAdapter\"], Application[\"Ext.Net.ScriptAdapter\"] and web.config.")]
        public virtual ScriptAdapter ScriptAdapter
        {
            get
            {
                if (this.scriptAdapter != null)
                {
                    return (ScriptAdapter)this.scriptAdapter;
                }

                if (!this.DesignMode && HttpContext.Current != null)
                {
                    string token = "Ext.Net.ScriptAdapter";

                    object obj = HttpContext.Current.Application[token];

                    if (obj == null)
                    {
                        obj = Session(token);
                    }

                    if (obj != null && obj is ScriptAdapter)
                    {
                        return (ScriptAdapter)obj;
                    }
                }
                else
                {
                    return WebConfigUtils.GetScriptAdapterFromWebConfig(this.Site);
                }

                return GlobalConfig.Settings.ScriptAdapter;
            }
            set
            {
                this.scriptAdapter = value;
            }
        }

        private object stateProvider = null;

        /// <summary>
        /// Gets or Sets the current script Adapter. Can be set at Page level in ResourceManager, Session[\"Ext.Net.ScriptAdapter\"], Application[\"Ext.Net.ScriptAdapter\"] and web.config.
        /// </summary>
        [Category("Config Options")]
        [DefaultValue(StateProvider.PostBack)]
        [Description("Gets or Sets the current script Adapter. Can be set at Page level in ResourceManager, Session[\"Ext.Net.ScriptAdapter\"], Application[\"Ext.Net.ScriptAdapter\"] and web.config.")]
        public virtual StateProvider StateProvider
        {
            get
            {
                if (this.stateProvider != null)
                {
                    return (StateProvider)this.stateProvider;
                }

                if (this.IsMVC && (this.stateProvider == null || (StateProvider)this.stateProvider == StateProvider.PostBack))
                {
                    this.stateProvider = StateProvider.None;
                    return (StateProvider)this.stateProvider;
                }

                if (!this.DesignMode && HttpContext.Current != null)
                {
                    string token = "Ext.Net.StateProvider";

                    object obj = HttpContext.Current.Application[token];

                    if (obj == null)
                    {
                        obj = Session(token);
                    }

                    if (obj != null && obj is StateProvider)
                    {
                        this.stateProvider = (StateProvider)obj;
                        return (StateProvider)this.stateProvider;
                    }
                }
                else
                {
                    this.stateProvider = WebConfigUtils.GetStateProviderFromWebConfig(this.Site);
                    return (StateProvider)this.stateProvider;
                }

                this.stateProvider = GlobalConfig.Settings.StateProvider;
                return (StateProvider)this.stateProvider;
            }
            set
            {
                this.stateProvider = value;
            }
        }

        private bool? quickTips;

        /// <summary>
        /// Specifies whether to render the QuickTips. Provides attractive and customizable tooltips for any element. 'True' = QuickTips enabled, 'False' = QuickTips disabled. Default is 'True'. Can be set at Page level in ResourceManager, Session[\"Ext.Net.QuickTips\"], Application[\"Ext.Net.QuickTips\"] and web.config.
        /// </summary>
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue(true)]
        [Description("Specifies whether to render the QuickTips. Provides attractive and customizable tooltips for any element. 'True' = QuickTips enabled, 'False' = QuickTips disabled. Default is 'True'. Can be set at Page level in ResourceManager, Session[\"Ext.Net.QuickTips\"], Application[\"Ext.Net.QuickTips\"] and web.config.")]
        public virtual bool QuickTips
        {
            get
            {
                if (this.quickTips != null)
                {
                    return (bool)this.quickTips;
                }

                if (!this.DesignMode && HttpContext.Current != null)
                {
                    string token = "Ext.Net.QuickTips";

                    object obj = HttpContext.Current.Application[token];

                    if (obj == null)
                    {
                        obj = Session(token);
                    }

                    if (obj != null && obj is bool)
                    {
                        return (bool)obj;
                    }
                }

                return GlobalConfig.Settings.QuickTips;
            }
            set
            {
                this.quickTips = value;
            }
        }

        private string locale;

        /// <summary>
        /// Specifies language of the ExtJS resources to use.
        /// </summary>
        [Category("Config Options")]
        [DefaultValue("")]
        [Description("Specifies language of the ExtJS resources to use.")]
        public virtual string Locale
        {
            get
            {
                if (this.locale != null)
                {
                    return this.locale;
                }

                if (!this.DesignMode && HttpContext.Current != null)
                {
                    string token = "Ext.Net.Locale";

                    object obj = HttpContext.Current.Application[token];

                    if (obj == null)
                    {
                        obj = Session(token);
                    }

                    if (obj != null && obj is string)
                    {

                        return (string)obj;
                    }
                }

                string cfgLocale = GlobalConfig.Settings.Locale;

                if (cfgLocale.IsEmpty())
                {
                    cfgLocale = (this.Page != null) ? System.Threading.Thread.CurrentThread.CurrentUICulture.ToString() : "";
                }

                return cfgLocale;
            }
            set
            {
                this.locale = value;
            }
        }

        private string directMethodNamespace;

        /// <summary>
        /// Specifies a custom namespace prefix to use for the DirectMethods.
        /// </summary>
        [Category("Config Options")]
        [DefaultValue("Ext.net.DirectMethods")]
        [Description("Specifies a custom namespace prefix to use for the DirectMethods.")]
        public virtual string DirectMethodNamespace
        {
            get
            {
                if (this.directMethodNamespace.IsNotEmpty())
                {
                    return this.directMethodNamespace;
                }

                if (!this.DesignMode && HttpContext.Current != null)
                {
                    string token = "Ext.Net.DirectMethodNamespace";

                    object obj = HttpContext.Current.Application[token];

                    if (obj == null)
                    {
                        obj = Session(token);
                    }

                    if (obj != null && obj is string)
                    {
                        return (string)obj;
                    }
                }

                return GlobalConfig.Settings.DirectMethodNamespace;
            }
            set
            {
                this.directMethodNamespace = value;
            }
        }

        private bool? disableViewState;

        /// <summary>
        /// Remove ViewState data from page's rendering.
        /// </summary>
        [Category("Config Options")]
        [DefaultValue(false)]
        [Description("Remove ViewState data from page's rendering.")]
        public virtual bool DisableViewState
        {
            get
            {
                if (this.disableViewState != null)
                {
                    return (bool)this.disableViewState;
                }

                if (!this.DesignMode && HttpContext.Current != null)
                {
                    string token = "Ext.Net.DisableViewState";

                    object obj = HttpContext.Current.Application[token];

                    if (obj == null)
                    {
                        obj = Session(token);
                    }

                    if (obj != null && obj is bool)
                    {
                        return (bool)obj;
                    }
                }

                return GlobalConfig.Settings.DisableViewState;
            }
            set
            {
                this.disableViewState = value;

                if (!this.DesignMode)
                {
                    ResourceManager.DisableViewStateStatic = value;
                }
            }
        }

        private bool? rethrowAjaxExceptions;
        
        /// <summary>
        /// Rethrow ajax exceptions from catch sections. Default is 'False'. Can be set within Session[\"Ext.Net.RethrowAjaxExceptions\"], Application[\"Ext.Net.RethrowAjaxExceptions\"] and web.config.
        /// </summary>
        [Category("Config Options")]
        [DefaultValue(false)]
        [Description("Rethrow ajax exceptions from catch sections. Default is 'False'. Can be set within Session[\"Ext.Net.RethrowAjaxExceptions\"], Application[\"Ext.Net.RethrowAjaxExceptions\"] and web.config.")]
        public virtual bool RethrowAjaxExceptions
        {
            get
            {
                if (this.rethrowAjaxExceptions != null)
                {
                    return (bool)this.rethrowAjaxExceptions;
                }

                if (!this.DesignMode && HttpContext.Current != null)
                {
                    string token = "Ext.Net.RethrowAjaxExceptions";
                    object obj = HttpContext.Current.Application[token];

                    if (obj == null)
                    {
                        obj = Session(token);
                    }

                    if (obj != null && obj is bool)
                    {
                        return (bool)obj;
                    }
                }

                return GlobalConfig.Settings.RethrowAjaxExceptions;
            }
            set
            {
                this.rethrowAjaxExceptions = value;
            }
        }

        private bool? showWarningOnAjaxFailure;

        /// <summary>
        /// Show warning dialog on ajax event failureDefault is 'True'. Can be set within Session[\"Ext.Net.ShowWarningOnAjaxFailure\"], Application[\"Ext.Net.ShowWarningOnAjaxFailure\"] and web.config.
        /// </summary>
        [Category("Config Options")]
        [DefaultValue(true)]
        [Description("Show warning dialog on ajax event failureDefault is 'True'. Can be set within Session[\"Ext.Net.ShowWarningOnAjaxFailure\"], Application[\"Ext.Net.ShowWarningOnAjaxFailure\"] and web.config.")]
        public virtual bool ShowWarningOnAjaxFailure
        {
            get
            {
                if (this.showWarningOnAjaxFailure != null)
                {
                    return (bool)this.showWarningOnAjaxFailure;
                }

                if (!this.DesignMode && HttpContext.Current != null)
                {
                    string token = "Ext.Net.ShowWarningOnAjaxFailure";
                    object obj = HttpContext.Current.Application[token];

                    if (obj == null)
                    {
                        obj = Session(token);
                    }

                    if (obj != null && obj is bool)
                    {
                        return (bool)obj;
                    }
                }

                return GlobalConfig.Settings.ShowWarningOnAjaxFailure;
            }
            set
            {
                this.showWarningOnAjaxFailure = value;
            }
        }

        private bool? manageEventsViewState;

        /// <summary>
        /// If true then load/save event's viewstate. Can be set within Session[\"Ext.Net.ManageEventsViewState\"], Application[\"Ext.Net.ManageEventsViewState\"] and web.config.
        /// </summary>
        [Category("Config Options")]
        [DefaultValue(false)]
        [Description("If true then load/save event's viewstate. Can be set within Session[\"Ext.Net.ManageEventsViewState\"], Application[\"Ext.Net.ManageEventsViewState\"] and web.config.")]
        public virtual bool ManageEventsViewState
        {
            get
            {
                if (this.manageEventsViewState != null)
                {
                    return (bool)this.manageEventsViewState;
                }

                if (!this.DesignMode && HttpContext.Current != null)
                {
                    string token = "Ext.Net.ManageEventsViewState";
                    object obj = HttpContext.Current.Application[token];

                    if (obj == null)
                    {
                        obj = Session(token);
                    }

                    if (obj != null && obj is bool)
                    {
                        return (bool)obj;
                    }
                }

                return GlobalConfig.Settings.ManageEventsViewState;
            }
            set
            {
                this.manageEventsViewState = value;
            }
        }

        private DebugConsole? debugConsole;

        /// <summary>
        /// Gets or Sets the current debug module. Can be set at Page level in ResourceManager, Session[\"Ext.Net.Debug\"], Application[\"Ext.Net.Debug\"] and web.config.
        /// </summary>
        [Category("Config Options")]
        [DefaultValue(DebugConsole.None)]
        [Description("Gets or Sets the current debug module. Can be set at Page level in ResourceManager, Session[\"Ext.Net.Debug\"], Application[\"Ext.Net.Debug\"] and web.config.")]
        public virtual DebugConsole DebugConsole
        {
            get
            {
                if (this.debugConsole != null)
                {
                    return this.debugConsole.Value;
                }

                if (!this.DesignMode && HttpContext.Current != null)
                {
                    string token = "Ext.Net.DebugConsole";

                    object obj = HttpContext.Current.Application[token];

                    if (obj == null)
                    {
                        obj = Session(token);
                    }

                    if (obj != null && obj is DebugConsole)
                    {
                        return (DebugConsole)obj;
                    }
                }
                else
                {
                    return WebConfigUtils.GetDebugFromWebConfig(this.Site);
                }

                return GlobalConfig.Settings.DebugConsole;
            }
            set
            {
                this.debugConsole = value;
            }
        }

        private object lazyMode = null;

        /// <summary>
        /// Gets or Sets the LazyMode. Can be set at Page level in ResourceManager, Session[\"Ext.Net.LazyMode\"], Application[\"Ext.Net.LazyMode\"] and web.config.
        /// </summary>
        [Category("Config Options")]
        [DefaultValue(LazyMode.Inherit)]
        [Description("Gets or Sets the LazyMode. Can be set at Page level in ResourceManager, Session[\"Ext.Net.LazyMode\"], Application[\"Ext.Net.LazyMode\"] and web.config.")]
        public override LazyMode LazyMode
        {
            get
            {
                if (this.lazyMode != null)
                {
                    return (LazyMode)this.lazyMode;
                }

                if (!this.DesignMode && HttpContext.Current != null)
                {
                    string token = "Ext.Net.LazyMode";

                    object obj = HttpContext.Current.Application[token];

                    if (obj == null)
                    {
                        obj = Session(token);
                    }

                    if (obj != null && obj is LazyMode)
                    {
                        return (LazyMode)obj;
                    }
                }
                else
                {
                    return WebConfigUtils.GetLazyModeFromWebConfig(this.Site);
                }

                return GlobalConfig.Settings.LazyMode;
            }
            set
            {
                this.lazyMode = value;
            }
        }

        private bool? submitDisabled;

        /// <summary>
        /// If false then disabled fileds will not be submitted. Can be set within Session[\"Ext.Net.SubmitDisabled\"], Application[\"Ext.Net.SubmitDisabled\"] and web.config.
        /// </summary>
        [Category("Config Options")]
        [DefaultValue(true)]
        [Description("If false then disabled fileds will not be submitted. Can be set within Session[\"Ext.Net.SubmitDisabled\"], Application[\"Ext.Net.SubmitDisabled\"] and web.config.")]
        public virtual bool SubmitDisabled
        {
            get
            {
                if (this.submitDisabled != null)
                {
                    return (bool)this.submitDisabled;
                }

                if (!this.DesignMode && HttpContext.Current != null)
                {
                    string token = "Ext.Net.SubmitDisabled";
                    object obj = HttpContext.Current.Application[token];

                    if (obj == null)
                    {
                        obj = Session(token);
                    }

                    if (obj != null && obj is bool)
                    {
                        return (bool)obj;
                    }
                }

                return GlobalConfig.Settings.SubmitDisabled;
            }
            set
            {
                this.submitDisabled = value;
            }
        }

        private string _namespace;

        /// <summary>
        /// 
        /// </summary>
        [Category("Config Options")]
        [DefaultValue("")]
        [Description("")]
        public override string Namespace
        {
            get
            {
                if (this._namespace != null)
                {
                    return this._namespace;
                }

                if (!this.DesignMode && HttpContext.Current != null)
                {
                    string token = "Ext.Net.Namespace";

                    object obj = HttpContext.Current.Application[token];

                    if (obj == null)
                    {
                        obj = Session(token);
                    }

                    if (obj != null && obj is string)
                    {

                        return (string)obj;
                    }
                }

                return GlobalConfig.Settings.Namespace;
            }
            set
            {
                this._namespace = value;
            }
        }

        private string licenseKey;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual string LicenseKey
        {
            get
            {
                if (this.licenseKey != null)
                {
                    return this.licenseKey;
                }

                if (!this.DesignMode && HttpContext.Current != null)
                {
                    string token = "Ext.Net.LicenseKey";

                    object obj = HttpContext.Current.Application[token];

                    if (obj == null)
                    {
                        obj = ResourceManager.Session(token);
                    }

                    if (obj != null && obj is string)
                    {
                        return (string)obj;
                    }
                }

                return GlobalConfig.Settings.LicenseKey;
            }
            set
            {
                this.licenseKey = value;
            }
        }
    }
}