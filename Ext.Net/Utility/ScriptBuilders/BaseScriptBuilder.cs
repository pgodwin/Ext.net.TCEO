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
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public abstract partial class BaseScriptBuilder
    {
        private readonly XControl control;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        [Description("")]
        protected BaseScriptBuilder(XControl control)
        {
            this.control = control;

            if (!this.control.HasOwnIDMode || this.control.IDMode == IDMode.Inherit)
            {
                this.control.IDMode = IDMode.Client;    
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public XControl Control
        {
            get
            {
                return this.control;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selfRendering"></param>
        /// <returns></returns>
        [Description("")]
        public abstract string Build(bool selfRendering);

        private Dictionary<string, string> scriptClientInitBag;
        private SortedList<long, string> scriptOnReadyBag;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public Dictionary<string, string> ScriptClientInitBag
        {
            get
            {
                if (this.scriptClientInitBag == null)
                {
                    this.scriptClientInitBag = new Dictionary<string, string>();
                }

                return this.scriptClientInitBag;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public SortedList<long, string> ScriptOnReadyBag
        {
            get
            {
                if (this.scriptOnReadyBag == null)
                {
                    this.scriptOnReadyBag = new SortedList<long, string>();
                }

                return this.scriptOnReadyBag;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected string script;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public virtual string Build()
        {
            return this.Build(false);
        }

        /// <summary>
        /// 
        /// </summary>
        public bool ForceResources
        {
            get;set;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="pageHolder"></param>
        [Description("")]
        protected void RegisterHtml(StringBuilder sb, Page pageHolder)
        {
            string html = BaseScriptBuilder.RenderControl(this.Control, pageHolder);

            if (!string.IsNullOrEmpty(html))
            {
                sb.Insert(0, html);
            }
        }

        private static Regex TopDynamic_RE = new Regex(string.Concat(XControl.TOP_DYNAMIC_CONTROL_TAG_S, "(.*?)", XControl.TOP_DYNAMIC_CONTROL_TAG_E), RegexOptions.Compiled | RegexOptions.Singleline);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <param name="pageHolder"></param>
        /// <returns></returns>
        [Description("")]
        public static string RenderControl(Control control, Page pageHolder)
        {
            if (pageHolder == null)
            {
                pageHolder = new SelfRenderingPage();
                pageHolder.Controls.Add(control);
            }

            StringWriter output = new StringWriter();
            HttpContext.Current.Server.Execute(pageHolder, output, true);

            StringBuilder sb = new StringBuilder();
            //MatchCollection mc = Regex.Matches(output.ToString(), string.Concat(XControl.TOP_DYNAMIC_CONTROL_TAG_S, "(.*?)", XControl.TOP_DYNAMIC_CONTROL_TAG_E), RegexOptions.Singleline);
            MatchCollection mc = TopDynamic_RE.Matches(output.ToString());

            foreach (Match m in mc)
            {
                sb.Append(m.Groups[1].Value);
            }

            return sb.ToString() ?? "";
        }

        private static Regex ClientInit_RE = new Regex(@"({)([\w\.]+)(_ClientInit})", RegexOptions.Compiled);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [Description("")]
        protected string Combine(string key)
        {
            string value = this.ScriptClientInitBag[key];

            if (value.IsNotEmpty())
            {
                //MatchCollection matches = Regex.Matches(value, @"({)([\w\.]+)(_ClientInit})");
                MatchCollection matches = ClientInit_RE.Matches(value);


                if (this.GetIsExcluded(key))
                {
                    return "";
                }
                
                if (matches.Count == 0)
                {
                    return value;
                }

                foreach (Match match in matches)
                {
                    string id = match.Value.Chop();

                    if (this.ScriptClientInitBag.ContainsKey(id))
                    {
                        value = value.Replace(match.Value, this.Combine(id));
                        this.LazyList.Add(id);
                    }
                }
            }

            return value;
        }

        private bool GetIsExcluded(string key)
        {
            return (this.LazyList.IndexOf(key) > -1);
        }

        private List<string> lazyList;

        private List<string> LazyList
        {
            get
            {
                if (this.lazyList == null)
                {
                    this.lazyList = new List<string>();
                }

                return this.lazyList;
            }
        }

        protected virtual void CheckIcon(XControl control, List<Icon> icons)
        {
            if (control is IIcon)
            {
                List<Icon> cIcons = ((IIcon)control).Icons;
                foreach (Icon icon in cIcons)
                {
                    if (!icons.Contains(icon) && icon != Icon.None)
                    {
                        icons.Add(icon);
                    }
                }
            }
        }

        private static string cacheBuster = "";

        private static string CacheBuster
        {
            get
            {
                if (cacheBuster.IsEmpty())
                {
                    cacheBuster = new ResourceManager().CacheBuster;
                }

                return cacheBuster;
            }
        }

        private static string GetWebResourceUrl(Type type, string resourceName)
        {
            if (resourceName.StartsWith(ResourceManager.ASSEMBLYSLUG))
            {
                var buster = "?v=" + CacheBuster;
                return VirtualPathUtility.ToAbsolute(("~{0}/ext.axd".FormatWith(resourceName.Replace(ResourceManager.ASSEMBLYSLUG, "").Replace('.', '/').ReplaceLastInstanceOf("/", "-")))) + buster;
            }
            return HttpUtility.HtmlAttributeEncode(new Page().ClientScript.GetWebResourceUrl(type, resourceName));
        }

        protected virtual void CheckResources(XControl control)
        {
            if (HttpContext.Current.CurrentHandler is Page && !(HttpContext.Current.CurrentHandler is ISelfRenderingPage) && !this.ForceResources)
            {
                return;
            }

            foreach (ClientScriptItem item in control.GetScripts())
            {
                if (!scriptsResources.ContainsKey(item.PathEmbedded))
                {
                    scriptsResources.Add(item.PathEmbedded, GetWebResourceUrl(item.Type, item.PathEmbedded));
                }
            }

            foreach (ClientStyleItem item in control.GetStyles())
            {
                if (!stylesResources.ContainsKey(item.PathEmbedded) && item.Theme.Equals(Theme.Default))
                {
                    stylesResources.Add(item.PathEmbedded, GetWebResourceUrl(item.Type, item.PathEmbedded));
                }
            }
        }

        protected InsertOrderedDictionary<string, string> scriptsResources = new InsertOrderedDictionary<string, string>();
        protected InsertOrderedDictionary<string, string> stylesResources = new InsertOrderedDictionary<string, string>();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="seed"></param>
        /// <param name="sb"></param>
        /// <returns></returns>
        [Description("")]
        protected List<XControl> FindControls(Control seed, bool searchOnly, StringBuilder sb, List<Icon> icons)
        {
            if (seed == null)
            {
                return null;
            }

            ResourceManager manager = ResourceManager.GetInstance(HttpContext.Current);

            if (icons == null)
            {
                icons = new List<Icon>();
            }

            if (sb != null && !searchOnly && manager != null)
            {
                try
                {
                    List<UserControl> userControls = ControlUtils.FindControls<UserControl>(this.Control);

                    foreach (UserControl userControl in userControls)
                    {
                        manager.AddDirectMethodControl(userControl, true);
                    }

                    string proxies = manager.BuildDirectMethodProxies(true);

                    foreach (UserControl userControl in userControls)
                    {
                        manager.RemoveDirectMethodControl(userControl, true);
                    }

                    if (!string.IsNullOrEmpty(proxies))
                    {
                        sb.Append(proxies);
                    }
                }
                catch (Exception e)
                {
                }
            }            

            if (ReflectionUtils.IsTypeOf(seed, typeof(XControl), false))
            {
                XControl ctrl = (XControl)seed;
                if (!searchOnly)
                {
                    this.CheckIcon(ctrl, icons);
                    this.CheckResources(ctrl);
                }
                ctrl.IsDynamic = true;
                ctrl.EnsureChildControlsInternal();
                if (!searchOnly)
                {
                    ctrl.CallOnPreRender();

                    ctrl.RegisterStyles(manager);
                    ctrl.RegisterScripts(manager);
                }
            }

            List<XControl> foundControls = new List<XControl>();

            foreach (Control control in seed.Controls)
            {
                if (this.ExcludeControl(seed, control))
                {
                    continue;
                }

                if (ReflectionUtils.IsTypeOf(control, typeof(XControl), false))
                {
                    XControl ctrl = (XControl)control;
                    if (!searchOnly)
                    {
                        this.CheckIcon(ctrl, icons);
                        this.CheckResources(ctrl);
                    }
                    foundControls.Add(ctrl);

                    ctrl.IsDynamic = true;
                    ctrl.EnsureChildControlsInternal();
                    if (!searchOnly)
                    {
                        ctrl.CallOnPreRender();

                        ctrl.RegisterStyles(manager);
                        ctrl.RegisterScripts(manager);
                    }
                }

                if (ControlUtils.HasControls(control))
                {
                    foundControls.AddRange(this.FindControls(control, searchOnly, null, icons));
                }
            }

            if (sb != null && !searchOnly && icons.Count > 0)
            {
                string[] arr = new string[icons.Count];
                for (int i = 0; i < icons.Count; i++)
                {
                    arr[i] = icons[i].ToString();
                }
                sb.Append("Ext.net.ResourceMgr.registerIcon(");
                sb.Append(JSON.Serialize(arr));
                sb.Append(");");
                sb.Append(script);
            }

            return foundControls;
        }

        protected virtual string RegisterResources(string script)
        {
            if (HttpContext.Current.CurrentHandler is Page && !(HttpContext.Current.CurrentHandler is ISelfRenderingPage) && !this.ForceResources)
            {
                return script;
            }

            if (this.scriptsResources.Count > 0 || this.stylesResources.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Ext.net.ResourceMgr.load([");
                bool comma = false;

                foreach (KeyValuePair<string, string> item in this.scriptsResources)
                {
                    if (comma)
                    {
                        sb.Append(",");
                    }

                    comma = true;
                    sb.Append("{url:").Append(JSON.Serialize(item.Value)).Append("}");
                }

                foreach (KeyValuePair<string, string> item in this.stylesResources)
                {
                    if (comma)
                    {
                        sb.Append(",");
                    }

                    comma = true;
                    sb.Append("{mode:\"css\",url:").Append(JSON.Serialize(item.Value)).Append("}");
                }

                sb.Append("], function(){");
                sb.Append(script);
                sb.Append("});");

                return sb.ToString();
            }

            return script;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        [Description("")]
        protected virtual bool ExcludeControl(Control parent, Control control)
        {
            return false;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public interface ISelfRenderingPage { }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class SelfRenderingPage : Page, ISelfRenderingPage
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public SelfRenderingPage()
        {
            this.EnableEventValidation = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        [Description("")]
        public override void VerifyRenderingInServerForm(Control control) { }
    }
}