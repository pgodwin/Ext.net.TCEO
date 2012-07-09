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
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;

using Ext.Net.Utilities;
using Newtonsoft.Json;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
    public partial class XControl
    {
        /*  Resource Manager
            -----------------------------------------------------------------------------------------------*/

        private ResourceManager resourceManager;

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        protected virtual internal ResourceManager SafeResourceManager
        {
            get
            {
                if (this.resourceManager != null && !this.IsDynamic)
                {
                    return this.resourceManager;
                }

                if (!this.DesignMode)
                {
                    if (this.Page != null)
                    {
                        this.resourceManager = ResourceManager.GetInstance(this.Page);
                    }
                    else if (HttpContext.Current != null)
                    {
                        this.resourceManager = ResourceManager.GetInstance(HttpContext.Current);
                    }

                    if (this.resourceManager != null)
                    {
                        return this.resourceManager;
                    }
                }

                if (this is ResourceManager)
                {
                    return this as ResourceManager;
                }

                if (this.Page != null)
                {
                    this.resourceManager = ControlUtils.FindControlByTypeName(this.Page, "Ext.Net.ResourceManagerProxy") as ResourceManager;

                    if (this.resourceManager != null)
                    {
                        return this.resourceManager;
                    }

                    this.resourceManager = (ResourceManager)ControlUtils.FindControlByTypeName(this.Page, "Ext.Net.ResourceManager");
                }

                return this.resourceManager;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool HasResourceManager
        {
            get
            {
                return this.SafeResourceManager != null;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public virtual ResourceManager ResourceManager
        {
            get
            {
                ResourceManager rm = this.SafeResourceManager;

                if (rm == null && this.DesignMode)
                {
                    return new ResourceManager();
                }

                if (rm == null)
                {
                    throw new InvalidOperationException(string.Concat(
                                                            "The ResourceManager Control is missing from this Page.",
                                                            Environment.NewLine,
                                                            Environment.NewLine,
                                                            "Please add the following ResourceManager tag inside the <body> or <form runat=\"server\"> of this Page.",
                                                            Environment.NewLine,
                                                            Environment.NewLine,
                                                            "Example",
                                                            Environment.NewLine,
                                                            Environment.NewLine,
                                                            "    <ext:ResourceManager runat=\"server\" />"));
                }

                return this.resourceManager;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual List<ResourceItem> Resources
        {
            get
            {
                return new List<ResourceItem>(0);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public List<T> GetCustomResources<T>() where T : ResourceItem
        {
            List<ResourceItem> items = this.Resources;
            List<T> list = new List<T>();

            int position = 0;

            foreach (ResourceItem item in items)
            {
                if (item is T)
                {
                    // Little "sort" operation to ensure that 'Ext.Net' resources figure at top of partial dependencies list 
                    if (item.PathEmbedded.Contains(ResourceManager.ASSEMBLYSLUG))
                    {
                        list.Insert(position++, (T)item);
                    }
                    else
                    {
                        list.Add((T)item);
                    }
                    
                }
            }

            foreach (ResourceItem item in items)
            {
                if (item is T)
                {
                    list.Add((T)item);
                }
            }

            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void SetResources()
        {
            if (X.IsAjaxRequest && !this.IsDynamic && !(this is ResourceManager) && !RequestManager.IsMicrosoftAjaxRequest)
            {
                this.RegisterCustomScripts();
                return;
            }
            
            if (!this.IsParentDeferredRender)
            {
                this.OnClientInit(false);

                bool isAsync = RequestManager.IsMicrosoftAjaxRequest;

                if (isAsync && this.IsInUpdatePanelRefresh && !(this is Layout))
                {
                    if (this is Observable && this.IsLazy)
                    {
                        this.ResourceManager.RegisterClientInitScript(this.ClientInitID, this.ClientInitScript);
                    }
                    else
                    {
                        string destroyCheck = "if(Ext.query(\"div#{0}_Container.AsyncRender\").length>0){{Ext.net.ResourceMgr.destroyCmp(\"{0}\");{1}}}";

                        this.ResourceManager.RegisterClientInitScript(this.ClientInitID, destroyCheck.FormatWith(this.ClientID, this.ClientInitScript));
                    }
                }

                if (!isAsync)
                {
                    this.ResourceManager.RegisterClientInitScript(this.ClientInitID, this.ClientInitScript);
                }

                if (this is IIcon)
                {
                    foreach (Icon icon in ((IIcon)this).Icons ?? new List<Icon>(0))
                    {
                        if (icon != Icon.None && this.ResourceManager.RenderStyles != ResourceLocationType.None)
                        {
                            this.ResourceManager.RegisterIcon(icon);
                        }
                    }
                }

                Theme theme = this.ResourceManager.Theme;

                foreach (ClientStyleItem item in this.GetThemes())
                {
                    if (item.Theme.Equals(theme))
                    {
                        switch (this.ResourceManager.RenderStyles)
                        {
                            case ResourceLocationType.Embedded:
                                this.ResourceManager.RegisterThemeIncludeInternal(item.Type, item.PathEmbedded);
                                break;
                            case ResourceLocationType.File:
                                this.ResourceManager.RegisterThemeIncludeInternal(item.PathEmbedded, this.ResourceManager.ResourcePath.ConcatWith(item.Path));
                                break;
                            case ResourceLocationType.CacheFly:
                                if (item.CacheFly.IsEmpty())
                                {
                                    this.ResourceManager.RegisterThemeIncludeInternal(item.Type, item.PathEmbedded);
                                }

                                this.ResourceManager.RegisterThemeIncludeInternal(item.PathEmbedded, item.CacheFly);
                                break;
                            case ResourceLocationType.CacheFlyAndFile:
                                if (item.CacheFly.IsEmpty())
                                {
                                    this.ResourceManager.RegisterThemeIncludeInternal(item.PathEmbedded, this.ResourceManager.ResourcePath.ConcatWith(item.Path));
                                }

                                this.ResourceManager.RegisterThemeIncludeInternal(item.PathEmbedded, item.CacheFly);
                                break;
                        }
                    }
                }

                if (!this.IsDynamic)
                {
                    this.RegisterStyles();
                    this.RegisterScripts();
                }
            }

            this.RegisterCustomScripts();
        }

        internal void RegisterStyles()
        {
            this.RegisterStyles(null);
        }

        internal void RegisterStyles(ResourceManager rm)
        {
            this.RegisterStyles(this.GetStyles(), rm);
        }

        internal void RegisterStyles(List<ClientStyleItem> styles, ResourceManager rm)
        {
            rm = rm ?? this.ResourceManager;

            foreach (ClientStyleItem item in styles)
            {
                if (item.Theme.Equals(Theme.Default))
                {
                    switch (rm.RenderStyles)
                    {
                        case ResourceLocationType.Embedded:
                            rm.RegisterClientStyleIncludeInternal(item.Type, item.PathEmbedded);
                            break;
                        case ResourceLocationType.File:
                            rm.RegisterClientStyleIncludeInternal(item.PathEmbedded, rm.ResourcePath.ConcatWith(item.Path));
                            break;
                        case ResourceLocationType.CacheFly:
                            if (item.CacheFly.IsEmpty())
                            {
                                rm.RegisterClientStyleIncludeInternal(item.Type, item.PathEmbedded);
                            }

                            rm.RegisterClientStyleIncludeInternal(item.PathEmbedded, item.CacheFly);
                            break;
                        case ResourceLocationType.CacheFlyAndFile:
                            if (item.CacheFly.IsEmpty())
                            {
                                rm.RegisterClientStyleIncludeInternal(item.PathEmbedded, rm.ResourcePath.ConcatWith(item.Path));
                            }

                            rm.RegisterClientStyleIncludeInternal(item.PathEmbedded, item.CacheFly);
                            break;
                    }
                }
            }
        }

        internal void RegisterScripts()
        {
            this.RegisterScripts(null);
        }

        internal void RegisterScripts(ResourceManager rm)
        {
            this.RegisterScripts(this.GetScripts(), rm);
        }

        internal void RegisterScripts(List<ClientScriptItem> scripts, ResourceManager rm)
        {
            rm = rm ?? this.ResourceManager;

            foreach (ClientScriptItem item in scripts)
            {
                if (rm.RenderScripts == ResourceLocationType.Embedded || rm.RenderScripts == ResourceLocationType.CacheFly)
                {
                    if (rm.ScriptMode == ScriptMode.Release || item.PathEmbeddedDebug.IsEmpty())
                    {
                        rm.RegisterClientScriptIncludeInternal(item.Type, item.PathEmbedded);
                    }
                    else
                    {
                        rm.RegisterClientScriptIncludeInternal(item.Type, item.PathEmbeddedDebug);
                    }
                }
                else if (rm.RenderScripts == ResourceLocationType.File || rm.RenderScripts == ResourceLocationType.CacheFlyAndFile)
                {
                    if (rm.ScriptMode == ScriptMode.Release || item.PathDebug.IsEmpty())
                    {
                        rm.RegisterClientScriptIncludeInternal(item.PathEmbedded, rm.ResourcePath.ConcatWith(item.Path));
                    }
                    else
                    {
                        rm.RegisterClientScriptIncludeInternal(item.PathEmbedded, rm.ResourcePath.ConcatWith(item.PathDebug));
                    }
                }
            }
        }

        internal void RegisterCustomScripts()
        {
            foreach (KeyValuePair<long, string> proxyScript in this.ProxyScripts)
            {
                this.ResourceManager.RegisterOnReadyScript(proxyScript.Key, proxyScript.Value);
            }
        }

		/// <summary>
		/// Get css resources
		/// </summary>
		[Description("")]
        public List<ClientStyleItem> GetStyles()
        {
            return this.GetCustomResources<ClientStyleItem>();
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public List<ClientStyleItem> GetThemes()
        {
            List<ClientStyleItem> styles = this.GetCustomResources<ClientStyleItem>();
            List<ClientStyleItem> themes = new List<ClientStyleItem>();

            foreach (ClientStyleItem style in styles)
            {
                if (style.Theme != Theme.Default)
                {
                    themes.Add(style);
                }
            }

            return themes;
        }

		/// <summary>
		/// Get script resources
		/// </summary>
		[Description("")]
        public List<ClientScriptItem> GetScripts()
        {
            return this.GetCustomResources<ClientScriptItem>();
        }
        
        private SortedList<long, string> proxyScripts = null;

        internal SortedList<long, string> ProxyScripts
        {
            get
            {
                if (this.proxyScripts == null)
                {
                    this.proxyScripts = new SortedList<long, string>();
                }

                return this.proxyScripts;
            }
        }

        /// <summary>
        /// Get generated and added javascript methods calling
        /// </summary>
        /// <returns></returns>
        public string GetGeneratedScripts()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (KeyValuePair<long, string> proxyScript in this.ProxyScripts)
            {
                if (proxyScript.Value.IsNotEmpty())
                {
                    sb.Append(proxyScript.Value);
                }
            }

            return sb.ToString();
        }
    }
}