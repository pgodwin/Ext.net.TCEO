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
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ResourceManager
    {
        /*  PreClientInit
            -----------------------------------------------------------------------------------------------*/

        private List<string> scriptBeforeClientInitBag = new List<string>();

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public List<string> ScriptBeforeClientInitBag
        {
            get
            {
                return this.scriptBeforeClientInitBag;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="script"></param>
        [Description("")]
        public void RegisterBeforeClientInitScript(string script)
        {
            this.scriptBeforeClientInitBag.Add(script);
        }


        /*  ScriptClientSpecialInitBag
            -----------------------------------------------------------------------------------------------*/

        private InsertOrderedDictionary<string, string> scriptClientSpecialInitBag = new InsertOrderedDictionary<string, string>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [Description("")]
        public bool IsClientSpecialInitScriptRegistered(string key)
        {
            return this.scriptClientSpecialInitBag.ContainsKey(key);
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public InsertOrderedDictionary<string, string> ScriptClientSpecialInitBag
        {
            get
            {
                return this.scriptClientSpecialInitBag;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="script"></param>
        [Description("")]
        public void RegisterClientSpecialInitScript(string key, string script)
        {
            if (!this.IsClientSpecialInitScriptRegistered(key))
            {
                this.scriptClientSpecialInitBag.Add(key, script);
            }
        }


        /*  ClientInitScript
            -----------------------------------------------------------------------------------------------*/

        private InsertOrderedDictionary<string, string> scriptClientInitBag = new InsertOrderedDictionary<string, string>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [Description("")]
        public bool IsClientInitScriptRegistered(string key)
        {
            return this.scriptClientInitBag.ContainsKey(key);
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public InsertOrderedDictionary<string, string> ScriptClientInitBag
        {
            get
            {
                return this.scriptClientInitBag;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="script"></param>
        [Description("")]
        public void RegisterClientInitScript(string key, string script)
        {
            if (!this.IsClientInitScriptRegistered(key))
            {
                this.scriptClientInitBag.Add(key, script);
            }
        }


        /*  PostClientInit
            -----------------------------------------------------------------------------------------------*/

        private List<string> scriptAfterClientInitBag = new List<string>();

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public List<string> ScriptAfterClientInitBag
        {
            get
            {
                return this.scriptAfterClientInitBag;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="script"></param>
        [Description("")]
        public void RegisterAfterClientInitScript(string script)
        {
            this.scriptAfterClientInitBag.Add(script);
        }


        /*  onReady
            -----------------------------------------------------------------------------------------------*/
        private static long proxyScriptNumber;
        internal static long ScriptOrderNumber
        {
            get
            {
                return System.Threading.Interlocked.Increment(ref proxyScriptNumber);
            }
        }

        private readonly SortedList<long, string> scriptOnReadyBag = new SortedList<long, string>();

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public SortedList<long, string> ScriptOnReadyBag
        {
            get
            {
                return this.scriptOnReadyBag;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="script"></param>
        [Description("")]
        public void RegisterOnReadyScript(string script)
        {
            this.RegisterOnReadyScript(ResourceManager.ScriptOrderNumber, script);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <param name="script"></param>
        [Description("")]
        internal void RegisterOnReadyScript(long orderNumber, string script)
        {
            if (script.IsNotEmpty())
            {
                this.scriptOnReadyBag.Add(orderNumber, script);
            }
        }


        /*  onWindowResize
            -----------------------------------------------------------------------------------------------*/

        private InsertOrderedDictionary<string, string> scriptOnWindowResizeBag = new InsertOrderedDictionary<string, string>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [Description("")]
        public bool IsOnWindowResizeScriptRegistered(string key)
        {
            return this.scriptOnWindowResizeBag.ContainsKey(key);
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public InsertOrderedDictionary<string, string> ScriptOnWindowResizeBag
        {
            get
            {
                return this.scriptOnWindowResizeBag;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="script"></param>
        [Description("")]
        public void RegisterOnWindowResizeScript(string key, string script)
        {
            if (!this.IsOnWindowResizeScriptRegistered(key))
            {
                this.scriptOnWindowResizeBag.Add(key, script);
            }
        }


        /*  onTextResize
            -----------------------------------------------------------------------------------------------*/

        private InsertOrderedDictionary<string, string> scriptOnTextResizeBag = new InsertOrderedDictionary<string, string>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [Description("")]
        public bool IsOnTextResizeScriptRegistered(string key)
        {
            return this.scriptOnTextResizeBag.ContainsKey(key);
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public InsertOrderedDictionary<string, string> ScriptOnTextResizeBag
        {
            get
            {
                return this.scriptOnTextResizeBag;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="script"></param>
        [Description("")]
        public void RegisterOnTextResizeScript(string key, string script)
        {
            if (!this.IsOnTextResizeScriptRegistered(key))
            {
                this.scriptOnTextResizeBag.Add(key, script);
            }
        }


        /*  JavaScript - Blocks
            -----------------------------------------------------------------------------------------------*/

        private InsertOrderedDictionary<string, string> clientScriptBlock = new InsertOrderedDictionary<string, string>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [Description("")]
        public bool IsClientScriptBlockRegistered(string key)
        {
            return this.clientScriptBlock.ContainsKey(key);
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public InsertOrderedDictionary<string, string> ClientScriptBlockBag
        {
            get
            {
                return this.clientScriptBlock;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceName"></param>
        [Description("")]
        public void RegisterClientScriptBlock(string resourceName)
        {
            this.RegisterClientScriptBlock(resourceName, this.GetWebResourceAsString(resourceName));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="script"></param>
        [Description("")]
        public void RegisterClientScriptBlock(string key, string script)
        {
            if (!this.IsClientScriptBlockRegistered(key))
            {
                this.clientScriptBlock.Add(key, script);
            }
        }


        /*  JavaScript - Includes
            -----------------------------------------------------------------------------------------------*/

        private InsertOrderedDictionary<string, string> clientScriptIncludeBag = new InsertOrderedDictionary<string, string>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [Description("")]
        public bool IsClientScriptIncludeRegistered(string key)
        {
            return (this.clientScriptIncludeBag.ContainsKey(key) || this.clientScriptIncludeInternalBag.ContainsKey(key));
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public InsertOrderedDictionary<string, string> ClientScriptIncludeBag
        {
            get
            {
                return this.clientScriptIncludeBag;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceName"></param>
        [Description("")]
        public void RegisterClientScriptInclude(string resourceName)
        {
            this.RegisterClientScriptInclude(this.GetType(), resourceName, false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceName"></param>
        /// <param name="force"></param>
        [Description("")]
        public void RegisterClientScriptInclude(string resourceName, bool force)
        {
            this.RegisterClientScriptInclude(this.GetType(), resourceName, force);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="resourceName"></param>
        [Description("")]
        public void RegisterClientScriptInclude(Type type, string resourceName)
        {
            this.RegisterClientScriptInclude(resourceName, this.GetWebResourceUrl(type, resourceName), false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="resourceName"></param>
        /// <param name="force"></param>
        [Description("")]
        public void RegisterClientScriptInclude(Type type, string resourceName, bool force)
        {
            this.RegisterClientScriptInclude(resourceName, this.GetWebResourceUrl(type, resourceName), force);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="url"></param>
        [Description("")]
        public void RegisterClientScriptInclude(string key, string url)
        {
            this.RegisterClientScriptInclude(key, url, false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="url"></param>
        /// <param name="force"></param>
        [Description("")]
        public void RegisterClientScriptInclude(string key, string url, bool force)
        {
            if (!this.IsClientScriptIncludeRegistered(key))
            {
                if (!X.IsAjaxRequest)
                {
                    this.clientScriptIncludeBag.Add(key, this.ResolveUrl(url));
                }
                else
                {
                    this.RegisterClientScriptIncludeInternal(key, url, force);
                }
            }
        }


        /*  JavaScript - Includes Internal
            -----------------------------------------------------------------------------------------------*/

        private InsertOrderedDictionary<string, string> clientScriptIncludeInternalBag = new InsertOrderedDictionary<string, string>();

        internal bool IsClientScriptIncludeInternalRegistered(string key)
        {
            return (this.clientScriptIncludeInternalBag.ContainsKey(key) || this.clientScriptIncludeBag.ContainsKey(key));
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal InsertOrderedDictionary<string, string> ClientScriptIncludeInternalBag
        {
            get
            {
                return this.clientScriptIncludeInternalBag;
            }
        }

        internal void RegisterClientScriptIncludeInternal(string resourceName)
        {
            this.RegisterClientScriptIncludeInternal(this.GetType(), resourceName, false);
        }

        internal void RegisterClientScriptIncludeInternal(string resourceName, bool force)
        {
            this.RegisterClientScriptIncludeInternal(this.GetType(), resourceName);
        }

        internal void RegisterClientScriptIncludeInternal(Type type, string resourceName)
        {
            this.RegisterClientScriptIncludeInternal(resourceName, this.GetWebResourceUrl(type, resourceName), false);
        }

        internal void RegisterClientScriptIncludeInternal(Type type, string resourceName, bool force)
        {
            this.RegisterClientScriptIncludeInternal(resourceName, this.GetWebResourceUrl(type, resourceName), force);
        }

        internal void RegisterClientScriptIncludeInternal(string key, string url)
        {
            this.RegisterClientScriptIncludeInternal(key, url, false);
        }

        internal void RegisterClientScriptIncludeInternal(string key, string url, bool force)
        {
            if (!this.IsClientScriptIncludeInternalRegistered(key))
            {
                this.clientScriptIncludeInternalBag.Add(key, (force ? "_force_" : "") + this.ResolveUrl(url));
            }
        }


        /*  StyleSheet - Blocks
            -----------------------------------------------------------------------------------------------*/

        private InsertOrderedDictionary<string, string> clientStyleBlockBag = new InsertOrderedDictionary<string, string>();

        public bool IsClientStyleBlockRegistered(string key)
        {
            return this.clientStyleBlockBag.ContainsKey(key);
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public InsertOrderedDictionary<string, string> ClientStyleBlockBag
        {
            get
            {
                return this.clientStyleBlockBag;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceName"></param>
        [Description("")]
        public void RegisterClientStyleBlock(string resourceName)
        {
            this.RegisterClientStyleBlock(this.GetType(), resourceName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="resourceName"></param>
        [Description("")]
        public void RegisterClientStyleBlock(Type type, string resourceName)
        {
            this.RegisterClientStyleBlock(resourceName, this.GetWebResourceAsString(type, resourceName));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="styles"></param>
        [Description("")]
        public void RegisterClientStyleBlock(string key, string styles)
        {
            if (!this.IsClientStyleBlockRegistered(key))
            {
                if (!X.IsAjaxRequest)
                {
                    this.clientStyleBlockBag.Add(key, styles);
                }
                else
                {
                    this.RegisterClientStyleIncludeInternal(key, styles);
                }
            }
        }


        /*  StyleSheet - Includes
            -----------------------------------------------------------------------------------------------*/

        private InsertOrderedDictionary<string, string> clientStyleIncludeBag = new InsertOrderedDictionary<string, string>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsClientStyleIncludeRegistered(string key)
        {
            return this.clientStyleIncludeBag.ContainsKey(key);
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public InsertOrderedDictionary<string, string> ClientStyleIncludeBag
        {
            get
            {
                return this.clientStyleIncludeBag;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceName"></param>
        [Description("")]
        public void RegisterClientStyleInclude(string resourceName)
        {
            this.RegisterClientStyleInclude(this.GetType(), resourceName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="resourceName"></param>
        [Description("")]
        public void RegisterClientStyleInclude(Type type, string resourceName)
        {
            this.RegisterClientStyleInclude(resourceName, this.GetWebResourceUrl(type, resourceName));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="url"></param>
        [Description("")]
        public void RegisterClientStyleInclude(string key, string url)
        {
            if (!this.IsClientStyleIncludeRegistered(key))
            {
                this.clientStyleIncludeBag.Add(key, this.ResolveUrl(url));
            }
        }


        /*  StyleSheet - Includes Internal
            -----------------------------------------------------------------------------------------------*/

        private InsertOrderedDictionary<string, string> clientStyleIncludeInternalBag = new InsertOrderedDictionary<string, string>();
        private InsertOrderedDictionary<string, string> themeIncludeInternalBag = new InsertOrderedDictionary<string, string>();

        internal bool IsClientStyleIncludeInternalRegistered(string key)
        {
            return this.clientStyleIncludeInternalBag.ContainsKey(key);
        }

        internal bool IsThemeIncludeInternalRegistered(string key)
        {
            return this.themeIncludeInternalBag.ContainsKey(key);
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal InsertOrderedDictionary<string, string> ClientStyleIncludeInternalBag
        {
            get
            {
                return this.clientStyleIncludeInternalBag;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal InsertOrderedDictionary<string, string> ThemeIncludeInternalBag
        {
            get
            {
                return this.themeIncludeInternalBag;
            }
        }

        internal void RegisterClientStyleIncludeInternal(string resourceName)
        {
            this.RegisterClientStyleIncludeInternal(this.GetType(), resourceName);
        }

        internal void RegisterClientStyleIncludeInternal(Type type, string resourceName)
        {
            this.RegisterClientStyleIncludeInternal(resourceName, this.GetWebResourceUrl(type, resourceName));
        }

        internal void RegisterClientStyleIncludeInternal(string key, string url)
        {
            if (!this.IsClientStyleIncludeInternalRegistered(key))
            {
                this.clientStyleIncludeInternalBag.Add(key, this.ResolveUrl(url));
            }
        }

        internal void RegisterThemeIncludeInternal(Type type, string resourceName)
        {
            this.RegisterThemeIncludeInternal(resourceName, this.GetWebResourceUrl(type, resourceName));
        }

        internal void RegisterThemeIncludeInternal(string key, string url)
        {
            if (!this.IsThemeIncludeInternalRegistered(key))
            {
                this.themeIncludeInternalBag.Add(key, this.ResolveUrl(url));
            }
        }

        private static List<string> locales;

        internal static List<string> Locales
        {
            get
            {
                if (ResourceManager.locales == null)
                {
                    ResourceManager.locales = new List<string>("af bg ca cs da de el-GR en en-GB es fa fi fr fr-CA he hr hu id it ja ko lt lv mk nl no nn-NO pl pt pt-BR pt-PT ro ru sk sl sr sr-Cyrl-CS sv-SE th tr uk vi zh-CN zh-TW".Split(' '));
                }

                return ResourceManager.locales;
            }
        }

        private static List<CultureInfo> supportedCultures;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public static List<CultureInfo> SupportedCultures
        {
            get
            {
                if (ResourceManager.supportedCultures == null)
                {
                    List<CultureInfo> cultures = new List<CultureInfo>(ResourceManager.Locales.Count);

                    foreach (string c in ResourceManager.Locales)
                    {
                        cultures.Add(new CultureInfo(c));
                    }

                    ResourceManager.supportedCultures = cultures;
                }

                return ResourceManager.supportedCultures;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="culture"></param>
        /// <returns></returns>
        [Description("")]
        public static bool IsSupportedCulture(CultureInfo culture)
        {
            bool parent;

            return ResourceManager.IsSupportedCulture(culture, out parent);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="culture"></param>
        /// <param name="isParentSupported"></param>
        /// <returns></returns>
        [Description("")]
        public static bool IsSupportedCulture(CultureInfo culture, out bool isParentSupported)
        {
            string child = culture.ToString();
            string parent = (culture.IsNeutralCulture) ? culture.ToString() : culture.Parent.ToString();

            bool childSupport = ResourceManager.Locales.Contains(child);
            bool parentSupport = ResourceManager.Locales.Contains(parent);
            isParentSupported = !childSupport && parentSupport;

            return (childSupport || parentSupport);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [Description("")]
        public static bool IsSupportedCulture(string code)
        {
            bool parent;

            return ResourceManager.IsSupportedCulture(code, out parent);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="isParentSupported"></param>
        /// <returns></returns>
        [Description("")]
        public static bool IsSupportedCulture(string code, out bool isParentSupported)
        {
            isParentSupported = false;

            if (code == "Invariant")
            {
                return false;
            }

            try
            {
                return ResourceManager.IsSupportedCulture(new CultureInfo(code), out isParentSupported);
            }
            catch (ArgumentException)
            {
                return false;
            }
        }
    }
}