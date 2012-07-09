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
using System.Configuration;
using System.Web.UI.Design;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class WebConfigUtils
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static IDMode GetIDModeFromWebConfig(ISite site)
        {
            IDMode idMode = IDMode.Inherit;

            GlobalConfig extnet = GetExtNetSection(site);

            if (extnet != null)
            {
                idMode = extnet.IDMode;
            }

            return idMode;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static InitScriptMode GetInitScriptModeFromWebConfig(ISite site)
        {
            InitScriptMode mode = InitScriptMode.Inline;

            GlobalConfig extnet = GetExtNetSection(site);

            if (extnet != null)
            {
                mode = extnet.InitScriptMode;
            }

            return mode;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static Theme GetThemeFromWebConfig(ISite site)
        {
            Theme theme = Theme.Default;

            GlobalConfig config = GetExtNetSection(site);

            if (config != null)
            {
                theme = config.Theme;
            }

            return theme;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static ScriptMode GetScriptModeFromWebConfig(ISite site)
        {
            ScriptMode mode = ScriptMode.Release;

            GlobalConfig config = GetExtNetSection(site);

            if (config != null)
            {
                mode = config.ScriptMode;
            }

            return mode;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static ViewStateMode GetAjaxViewStateFromWebConfig(ISite site)
        {
            ViewStateMode mode = ViewStateMode.Inherit;

            GlobalConfig config = GetExtNetSection(site);

            if (config != null)
            {
                mode = config.AjaxViewStateMode;
            }

            return mode;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static string GetLocaleFromWebConfig(ISite site)
        {
            string locale = "Invariant";
            GlobalConfig config = GetExtNetSection(site);

            if (config != null)
            {
                locale = config.Locale;
            }

            return locale;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static ClientProxy GetDirectMethodProxyFromWebConfig(ISite site)
        {
            ClientProxy mode = ClientProxy.Default;

            GlobalConfig config = GetExtNetSection(site);

            if (config != null)
            {
                mode = config.DirectMethodProxy;
            }

            return mode;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static ScriptAdapter GetScriptAdapterFromWebConfig(ISite site)
        {
            ScriptAdapter scriptAdapter = ScriptAdapter.Ext;

            GlobalConfig extnet = GetExtNetSection(site);

            if (extnet != null)
            {
                scriptAdapter = extnet.ScriptAdapter;
            }

            return scriptAdapter;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static StateProvider GetStateProviderFromWebConfig(ISite site)
        {
            StateProvider stateProvider = StateProvider.PostBack;

            GlobalConfig extnet = GetExtNetSection(site);

            if (extnet != null)
            {
                stateProvider = extnet.StateProvider;
            }

            return stateProvider;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static GlobalConfig GetExtNetSection(ISite site)
        {
            if (site != null)
            {
                IWebApplication app = (IWebApplication)site.GetService(typeof(IWebApplication));

                if (app != null)
                {
                    Configuration config = app.OpenWebConfiguration(true);

                    if (config != null)
                    {
                        ConfigurationSection section = config.GetSection("extnet");

                        if (section != null)
                        {
                            return section as GlobalConfig;
                        }
                    }
                }
            }

            return null;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static DebugConsole GetDebugFromWebConfig(ISite site)
        {
            DebugConsole debug = DebugConsole.None;

            GlobalConfig extnet = GetExtNetSection(site);

            if (extnet != null)
            {
                debug = extnet.DebugConsole;
            }

            return debug;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static LazyMode GetLazyModeFromWebConfig(ISite site)
        {
            LazyMode lazyMode = LazyMode.Inherit;

            GlobalConfig extnet = GetExtNetSection(site);

            if (extnet != null)
            {
                lazyMode = extnet.LazyMode;
            }

            return lazyMode;
        }
    }
}