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
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
    public partial class XControl
    {
        internal const string TOP_DYNAMIC_CONTROL_TAG_S = "<Ext.Net.DynamicControlContent>";
        internal const string TOP_DYNAMIC_CONTROL_TAG_E = "</Ext.Net.DynamicControlContent>";


        /*  Properties
            -----------------------------------------------------------------------------------------------*/

        private bool isLast = false;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        internal virtual bool IsLast
        {
            get
            {
                return this.isLast;
            }
            set
            {
                this.isLast = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected internal virtual bool IsIdRequired
        {
            get
            {
                return !this.IsGeneratedID || this.ForceIdRendering;
            }
        }

        private bool isGeneratedID = true;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        internal virtual bool IsGeneratedID
        {
            get 
            { 
                return this.isGeneratedID; 
            }
            private set 
            { 
                this.isGeneratedID = value; 
            }
        }

        private bool forceIdRendering;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        internal virtual protected bool ForceIdRendering
        {
            get 
            { 
                return this.forceIdRendering; 
            }
            set 
            { 
                this.forceIdRendering = value; 
            }
        }

        private bool allowCallbackScriptMonitoring;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        internal virtual bool AllowCallbackScriptMonitoring
        {
            get
            {
                return this.allowCallbackScriptMonitoring;
            }
            set
            {
                this.allowCallbackScriptMonitoring = value;
            }
        }

        private bool alreadyRendered;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        internal bool AlreadyRendered
        {
            get
            {
                return this.alreadyRendered;
            }
            set
            {
                this.alreadyRendered = value;
            }
        }

        private bool isDynamic;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected internal bool IsDynamic
        {
            get
            {
                return this.isDynamic || this.TopDynamicControl;
            }
            set
            {
                this.isDynamic = value;
            }
        }

        private bool deferInitScriptGeneration;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected internal bool DeferInitScriptGeneration
        {
            get
            {
                return this.deferInitScriptGeneration;
            }
            set
            {
                this.deferInitScriptGeneration = value;
            }
        }


        private bool topDynamicControl;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected internal bool TopDynamicControl
        {
            get
            {
                return this.topDynamicControl;
            }
            set
            {
                this.topDynamicControl = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("1. XControl")]
        [Description("")]
        public virtual bool ContentUpdated
        {
            get
            {
                return this.contentUpdated;
            }
            internal set
            {
                this.contentUpdated = value;
            }
        }


        /*  Custom Events
            -----------------------------------------------------------------------------------------------*/

        string before = "";

        /// <summary>
        /// Adds the script directly before the ClientInitScript.
        /// </summary>
        /// <param name="script">The script</param>
        [Description("Adds the script directly before the ClientInitScript.")]
        public virtual void AddBeforeClientInitScript(string script)
        {
            this.before += script;
        }

        /// <summary>
        /// 
        /// </summary>
        public string BeforeScript
        {
            get
            {
                return this.before;
            }
        }

        string after = "";

        /// <summary>
        /// Adds the script directly after the ClientInitScript.
        /// </summary>
        [Description("Adds the script directly after the ClientInitScript.")]
        public virtual void AddAfterClientInitScript(string script)
        {
            this.after += script;
        }

        /// <summary>
        /// 
        /// </summary>
        public string AfterScript
        {
            get
            {
                return this.after;
            }
        }

        /*  Lifecycle
            -----------------------------------------------------------------------------------------------*/

        internal void EnsureChildControlsInternal()
        {
            this.EnsureChildControls();
        }

        private bool init = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reinit"></param>
        [Description("")]
        protected internal virtual void OnClientInit(bool reinit)
        {
            if ((this.init && !reinit) || this.DeferInitScriptGeneration)
            {
                return;
            }

            this.EnsureChildControls();

            if (!this.DesignMode && !(this is Layout))
            {
                if(!this.init)
                {
                     this.ResourceManager.RegisterInitID(this);
                }

                if (this is Observable)
                {
                    if (this.IsLazy)
                    {
                        if (this is LazyObservable)
                        {
                            Plugin p = this as Plugin;

                            if (p != null && p.Singleton)
                            {
                                this.clientInitScript = this.InstanceOf;
                            }
                            else if (!(this is ICustomConfigSerialization))
                            {
                                string template = "this.{0}=new {1}({2})";
                                this.clientInitScript = string.Format(template, this.ClientID, this.InstanceOf, this.InitialConfig);
                            }
                            else
                            {
                                this.clientInitScript = ((ICustomConfigSerialization) this).ToScript(this);
                            }
                        }
                        else
                        {
                            this.clientInitScript = this.LazyMode == LazyMode.Instance ? "new {0}({1})".FormatWith(this.InstanceOf, this.InitialConfig) : this.InitialConfig;
                        }
                    }
                    else
                    {
                        this.clientInitScript = this.GetClientConstructor();
                    }

                }
            }
            this.init = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            this.EnsureChildControls();

            if (this.DesignMode)
            {
                this.RegisterBeforeAfterScript();
            }
            else
            {
                if (this.Page != null)
                {
                    this.Page.PreLoad += PagePreLoad;
                    this.Page.LoadComplete += PageLoadComplete;
                }
            }

            this.AllowCallbackScriptMonitoring = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void PagePreLoad(object sender, EventArgs e) { }

        /// <summary>
        /// 
        /// </summary>
        public virtual Component ParentComponentNotLazyOrDynamic
        {
            get
            {
                Component parent = this.ParentComponent;

                if (this.IsLazy && !parent.TopDynamicControl)
                {
                    while (parent != null && parent.IsLazy && !parent.TopDynamicControl)
                    {
                        parent = parent.ParentComponent;
                    }
                }

                return parent;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void PageLoadComplete(object sender, EventArgs e) { }

        internal void RegisterBeforeAfterScript()
        {
            if (this.IsLazy && !this.DeferInitScriptGeneration)
            {
                Component parent = this.ParentComponentNotLazyOrDynamic;

                if (parent != null)
                {
                    parent.AddBeforeClientInitScript(this.before);
                    parent.AddAfterClientInitScript(this.after);
                }
                else
                {
                    this.ResourceManager.RegisterBeforeClientInitScript(this.before);
                    this.ResourceManager.RegisterAfterClientInitScript(this.after);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        [Description("")]
        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);

            if (this.ContainerStyle.IsNotEmpty())
            {
                string[] styles = this.ContainerStyle.Split(';');

                foreach (string style in styles)
                {
                    if (style.IsNotEmpty())
                    {
                        string[] parts = style.Split(':');

                        writer.AddStyleAttribute(parts[0], parts[1]);
                    }
                }
            }
        }

        internal virtual void ForcePreRender()
        {
            this.PreRenderAction();
        }

        private bool rendered;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void PreRenderAction()
        {
            if (this.Visible && !this.rendered)
            {
                this.SetResources();

                this.rendered = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        [Description("")]
        protected virtual void SimpleRender(HtmlTextWriter writer)
        {
            this.PreRenderAction();

            if (this.IsLast)
            {
                if (!RequestManager.IsAjaxRequest)
                {
                    this.ResourceManager.BaseRenderAction();
                }

                this.ResourceManager.RenderAction(writer);
            }
        }

        void ICompositeControlDesignerAccessor.RecreateChildControls()
        {
            this.RecreateChildControls();
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void RecreateChildControls()
        {
            this.CreateChildControls();
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            this.EnsureID();

            if (this is IContent)
            {
                this.Controls.Add(((IContent)this).ContentContainer);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        [Description("")]
        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            this.AddAttributesToRender(writer);
            writer.RenderBeginTag(this.DesignMode ? "div" : this is Layout ? "div:layout" : "div:container");
        }

        private bool preRendered;
        private bool contentUpdated;
        private bool isDataBound;

        internal void CallOnPreRender()
        {
            this.OnPreRender(EventArgs.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected override void OnPreRender(EventArgs e)
        {
            if (this.Visible && !this.preRendered)
            {
                if (this.Page != null && this is IPostBackDataHandler && !this.IsMVC)
                {
                    this.Page.RegisterRequiresPostBack(this);
                }

                if (!X.IsAjaxRequest && !this.IsDynamic && !(this is ResourceManager) && !RequestManager.IsMicrosoftAjaxRequest && !this.IsParentDeferredRender)
                {
                    this.RegisterBeforeAfterScript();
                }

                this.preRendered = true;
            }

            if (RequestManager.IsMicrosoftAjaxRequest)
            {
                if (this.AutoDataBind)
                {
                    this.DataBind();
                }

                this.PreRenderAction();
            }

            if (this.Page != null)
            {
                base.OnPreRender(e);
            }
        }


        /*  Render
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void Render(bool selfRendering)
        {
            if (this.Parent == null && this.ID.IsEmpty())
            {
                throw new ArgumentException("The ID must be set for the {0} Control.".FormatWith(this.GetType().ToString()));
            }

            if (!this.AlreadyRendered)
            {
                this.Visible = true;

                this.RenderScript(this.ToScript(selfRendering));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void Render(Control control)
        {
            if (control is ContainerBase && this is Component)
            {
                (control as ContainerBase).Items.Add(this as Component);
            }
            else
            {
                control.Controls.Add(this);
            }

            this.Render();
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void Render()
        {
            this.Render(this.Page == null);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void Render(string element, RenderMode mode)
        {
            this.Render(element, mode, this.Page == null);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void Render(string element, int index, RenderMode mode)
        {
            this.Render(element, index, mode, this.Page == null);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void Render(Control control, RenderMode mode)
        {
            this.Render(control, mode, this.Page == null);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void Render(Control control, int index, RenderMode mode)
        {
            this.Render(control, index, mode, this.Page == null);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void Render(string element, RenderMode mode, bool selfRendering)
        {
            if (!this.AlreadyRendered)
            {
                this.Visible = true;

                this.RenderScript(this.ToScript(mode, element, selfRendering));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void Render(string element, int index, RenderMode mode, bool selfRendering)
        {
            if (!this.AlreadyRendered)
            {
                this.Visible = true;

                this.RenderScript(this.ToScript(mode, element, index, selfRendering));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void Render(Control control, RenderMode mode, bool selfRendering)
        {
            this.Render(control.ClientID, mode, selfRendering);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void Render(Control control, int index, RenderMode mode, bool selfRendering)
        {
            this.Render(control.ClientID, index, mode, selfRendering);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void AddTo(string element)
        {
            this.Render(element, RenderMode.AddTo, this.Page == null);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void AddTo(Control control)
        {

            this.Render(control, control is ContainerBase ? RenderMode.AddTo : RenderMode.RenderTo, this.Page == null);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void AddTo(string element, bool selfRendering)
        {
            if (!this.AlreadyRendered)
            {
                this.Visible = true;

                this.RenderScript(this.ToScript(RenderMode.AddTo, element, selfRendering));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void AddTo(Control control, bool selfRendering)
        {
            this.Render(control.ClientID, control is ContainerBase ? RenderMode.AddTo : RenderMode.RenderTo, selfRendering);
        }


        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void InsertTo(int index, string element)
        {
            this.Render(element, index, RenderMode.InsertTo, this.Page == null);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void InsertTo(int index, Control control)
        {
            this.Render(control, index, RenderMode.InsertTo, this.Page == null);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void InsertTo(int index, string element, bool selfRendering)
        {
            if (!this.AlreadyRendered)
            {
                this.Visible = true;

                this.RenderScript(this.ToScript(RenderMode.InsertTo, element, index, selfRendering));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void InsertTo(int index, Control control, bool selfRendering)
        {
            this.Render(control.ClientID, index, RenderMode.InsertTo, selfRendering);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void Update()
        {
            if (this.IsLazy)
            {
                throw new Exception("The Lazy control ({0}) can not be updated.".FormatWith(this.ID));
            }

            if (!this.AlreadyRendered)
            {
                this.Visible = true;

                this.RenderScript(this.ToScript());
            }
        }

        protected virtual void RenderScript(string script)
        {
            ResourceManager rm = ResourceManager.GetInstance(HttpContext.Current);
            if (HttpContext.Current.CurrentHandler is Page && rm != null)
            {
                rm.AddScript(script);
            }
            else
            {
                new DirectResponse(script).Return();
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected override void OnDataBinding(EventArgs e)
        {
            base.OnDataBinding(e);
            this.IsDataBound = true;
        }

        private bool IsDataBound
        {
            get
            {
                return this.isDataBound;
            }
            set
            {
                this.isDataBound = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        [Description("")]
        protected override void Render(HtmlTextWriter writer)
        {
            if (this.Visible && !this.AlreadyRendered)
            {
                bool isAsync = RequestManager.IsMicrosoftAjaxRequest;

                if (!isAsync)
                {
                    if (this.AutoDataBind && !this.IsDataBound)
                    {
                        this.DataBind(true);
                    }

                    this.PreRenderAction();
                }

                if (!(this is IVirtual))
                {
                    if (isAsync
                        && this.IsInUpdatePanelRefresh
                        && !(this is Layout)
                        && this is Observable
                        && !this.IsLazy)
                    {
                        this.Attributes.Add("class", "AsyncRender");
                    }

                    this.HtmlRender(writer);
                }
            }
            else
            {
                if (this.Visible && this.IsDynamic)
                {
                    if (!(this is IVirtual))
                    {
                        this.HtmlRender(writer);
                    }
                }
            }

            if (this.IsLast)
            {
                if (!RequestManager.IsAjaxRequest)
                {
                    this.ResourceManager.BaseRenderAction();
                }

                this.ResourceManager.RenderAction(writer);
            }
        }

        private static Regex Div_Layout_RE = new Regex("<div:layout id=\"[^\"]+\"[^<]*>|</div:layout>", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static Regex Div_Body_RE = new Regex("<div:body id=\"[^\"]+_Content\"[^<]*>|</div:body>", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static Regex Div_Container_RE = new Regex("<div:container id=\"[^\"]+\"[^<]*>|</div:container>", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static Regex Div_ContainerBody_RE = new Regex("div:container|div:body", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static Regex DirectResponse_RE = new Regex("<Ext.Net.Direct.Response>.*</Ext.Net.Direct.Response>", RegexOptions.Compiled);
        private static Regex InitScriptWarning_RE = new Regex(InitScriptFilter.OPEN_WARNING_TAG + ".*" + InitScriptFilter.CLOSE_WARNING_TAG, RegexOptions.Compiled);        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        [Description("")]
        protected internal void HtmlRender(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder(256);
            base.Render(new HtmlTextWriter(new StringWriter(sb)));

            string html = sb.ToString().Trim();

            html = html.Replace("display:inline-block;", "");
            html = html.Replace(" style=\"\"", "");

            //html = Regex.Replace(html, "<div:layout id=\"[^\"]+\"[^<]*>|</div:layout>", "", RegexOptions.IgnoreCase);
            html = Div_Layout_RE.Replace(html, "");

            if (!this.HasContent())
            {
                //html = Regex.Replace(html, "<div:body id=\"[^\"]+_Content\"[^<]*>|</div:body>", "", RegexOptions.IgnoreCase);
                html = Div_Body_RE.Replace(html, "");
            }

            if (   this.IsLazy
                || (this.TopDynamicControl && this.ContentUpdated)
                || this.IsDynamicLazy 
                || (this.RemoveContainer && !RequestManager.IsMicrosoftAjaxRequest))
            {
                //html = Regex.Replace(html, "<div:container id=\"[^\"]+\"[^<]*>|</div:container>", "", RegexOptions.IgnoreCase); ;
                html = Div_Container_RE.Replace(html, ""); ;
            }

            // html = Regex.Replace(html, "div:container|div:body", "div", RegexOptions.IgnoreCase)
            //             .Replace("id=\"{0}\"".FormatWith(this.ClientID), "id=\"{0}\"".FormatWith(this.ContainerID));

            html = Div_ContainerBody_RE.Replace(html, "div")
                        .Replace("id=\"{0}\"".FormatWith(this.ClientID), "id=\"{0}\"".FormatWith(this.ContainerID));

            if (this.TopDynamicControl && html.IsNotEmpty() && (RequestManager.IsAjaxRequest || this.Page is ISelfRenderingPage))
            {
                //html = Regex.Replace(html, "<Ext.Net.Direct.Response>.*</Ext.Net.Direct.Response>", "");
                html = DirectResponse_RE.Replace(html, "");
                html = InitScriptWarning_RE.Replace(html, "");

                int start = html.IndexOf(InitScriptFilter.OPEN_SCRIPT_TAG);

                if (start >= 0)
                {
                    int end = html.IndexOf(InitScriptFilter.CLOSE_SCRIPT_TAG) + InitScriptFilter.CLOSE_SCRIPT_TAG.Length;
                    html = html.Remove(start, end - start);
                }

                string[] lines = html.Split(new string[] { "\r\n", "\n", "\r", "\t" }, StringSplitOptions.RemoveEmptyEntries);

                if (lines.Length == 0)
                {
                    return;
                }
                
                html = JSON.Serialize(lines).ConcatWith(".join('')");

                html = html.Replace("</script>", "<\\/script>");

                string domParent = "";

                if (this is Component)
                {
                    domParent = ((Component)this).RenderToProxy;

                    if (domParent.IsNotEmpty())
                    {
                        domParent = string.Concat("Ext.net.getEl(", this.ParseDomParent(domParent), ")");
                    }
                }

                if (domParent.IsEmpty())
                {
                    if (this.Page != null && this.Page.Form != null)
                    {
                        domParent = "Ext.get('".ConcatWith(this.Page.Form.ClientID, "')");
                    }
                    else
                    {
                        domParent = "Ext.getBody()";
                    }
                }

                if (this.ContentUpdated && this is IContent)
                {
                    sb.AppendFormat("{3}Ext.net.replaceContent({0},{1},{2});{4}", this.ClientID, JSON.Serialize(((IContent)this).ContentEl), html, XControl.TOP_DYNAMIC_CONTROL_TAG_S, XControl.TOP_DYNAMIC_CONTROL_TAG_E);
                }
                else
                {
                    sb.AppendFormat("{2}Ext.net.append({0},{1});{3}", domParent, html, XControl.TOP_DYNAMIC_CONTROL_TAG_S, XControl.TOP_DYNAMIC_CONTROL_TAG_E);
                }

                writer.Write(sb.ToString());
            }
            else
            {
                writer.Write(html);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Description("")]
        protected internal string ParseDomParent(string value)
        {
            if (value.ToString().StartsWith("<!token>"))
            {
                value = value.ToString().Substring(8);
            }
            else
            {
                value = TokenUtils.ParseTokens(value.ToString(), this);
            }

            string temp = value.ToString();

            if (temp.StartsWith("<string>"))
            {
                return temp.Substring(temp.StartsWith("<string><raw>") ? 13 : 8);
            }

            if (temp.StartsWith("<raw>"))
            {
                return temp.Substring(5);
            }

            return JSON.Serialize(temp);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public virtual bool SuspendScripting()
        {
            return this.ViewState.Suspend();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldValue"></param>
        [Description("")]
        public virtual void ResumeScripting(bool oldValue)
        {
            this.ViewState.Resume();
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void ResumeScripting()
        {
            this.ResumeScripting(true);
        }

        private bool registerAllResources;

        /// <summary>
        /// 
        /// </summary>
        [Category("1. XControl")]
        [DefaultValue(false)]
        [Description("")]
        public bool RegisterAllResources
        {
            get
            {
                return this.registerAllResources;
            }
            set
            {
                this.registerAllResources = value;
            }
        }
    }
}