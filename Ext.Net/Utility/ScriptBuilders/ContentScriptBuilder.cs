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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class ContentScriptBuilder : BaseScriptBuilder
    {
        private IList items;
        private IList layoutItems;
        private Control contentContainer;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected ContentScriptBuilder(XControl control) : base(control)
        {
            items = new List<object>(0);
            if (control is IItems)
            {
                items = ((IItems) control).ItemsList;

                if (items.Count == 1 && items[0] is Layout)
                {
                    layoutItems = ((Layout) items[0]).Items;
                }
                else
                {
                    layoutItems = items;
                }
            }

            if (control is IContent)
            {
                contentContainer = ((IContent) control).ContentContainer;
            }
        }

        /// <summary>
		/// 
		/// </summary>
        [Description("")]
        public override string Build(bool selfRendering)
        {
            return this.Build(selfRendering, false);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual string Build(bool selfRendering, bool forceResources)
        {
            this.ForceResources = forceResources;
            if (this.script == null)
            {
                Page pageHolder = null;
                this.Control.TopDynamicControl = true;
                this.Control.ForceIdRendering = true;

                if (selfRendering && this.Control.Page == null)
                {
                    pageHolder = new SelfRenderingPage();

                    ResourceManager rm = new ResourceManager();
                    rm.RenderScripts = ResourceLocationType.None;
                    rm.RenderStyles = ResourceLocationType.None;
                    rm.IDMode = IDMode.Client;
                    rm.IsDynamic = true;
                    pageHolder.Controls.Add(rm);

                    pageHolder.Controls.Add(this.Control);
                }
                else if (selfRendering && this.Control.Page is ISelfRenderingPage)
                {
                    pageHolder = this.Control.Page;
                    ResourceManager newMgr = Ext.Net.Utilities.ControlUtils.FindControl<ResourceManager>(pageHolder);
                    if (newMgr != null)
                    {
                        newMgr.IsDynamic = true;
                    }
                }

                StringBuilder sb = new StringBuilder();

                this.Control.ContentUpdated = this.Control.HasContent();
                ContainerBase container = this.Control as ContainerBase;
                if (container != null && container.Items.Count > 0)
                {
                    sb.AppendFormat("{0}.removeAll();", this.Control.ClientID);
                }

                List<XControl> childControls = this.FindControls(this.Control, selfRendering, sb, null);

                foreach (XControl c in childControls)
                {
                    if (c.Visible)
                    {
                        c.DeferInitScriptGeneration = selfRendering;
                        if (c.AutoDataBind)
                        {
                            c.DataBind();
                        }
                    }
                }

                if (selfRendering)
                {
                    this.RegisterHtml(sb, pageHolder);

                    foreach (XControl c in childControls)
                    {
                        c.DeferInitScriptGeneration = false;
                    }

                    List<XControl> newChildControls = this.FindControls(this.Control, false, sb, null);
                    newChildControls.Insert(0, this.Control);

                    foreach (XControl c in newChildControls)
                    {
                        if (!childControls.Contains(c) && (c.Visible || Object.ReferenceEquals(c, this.Control)))
                        {
                            if (c.AutoDataBind)
                            {
                                c.DataBind();
                            }
                        }
                    }

                    childControls = newChildControls;
                }

                foreach (XControl c in childControls)
                {
                    if (c.Visible)
                    {
                        c.OnClientInit(true);
                        c.RegisterBeforeAfterScript();
                    }
                }

                foreach (XControl c in childControls)
                {
                    if (c.Visible)
                    {
                        string initScript = c.BuildInitScript();
                        if (!string.IsNullOrEmpty(initScript))
                        {
                            if (this.layoutItems.Contains(c))
                            {
                                this.ScriptClientInitBag.Add(c.ClientInitID, this.Control.ClientID.ConcatWith(".add(", initScript, ");"));
                            }
                            else
                            {
                                this.ScriptClientInitBag.Add(c.ClientInitID, initScript);
                            }
                        }

                        c.AlreadyRendered = true;

                        foreach (KeyValuePair<long, string> proxyScript in c.ProxyScripts)
                        {
                            if (proxyScript.Value.IsNotEmpty())
                            {
                                this.ScriptOnReadyBag.Add(proxyScript.Key, proxyScript.Value);
                            }
                        }
                    }
                }

                if (this.ScriptClientInitBag.Count > 0)
                {
                    foreach (KeyValuePair<string, string> item in this.ScriptClientInitBag)
                    {
                        sb.Append(this.Combine(item.Key));
                    }
                }

                foreach (KeyValuePair<long, string> script in this.ScriptOnReadyBag)
                {
                    sb.Append(script.Value);
                }

                //if (selfRendering)
                //{
                //    this.RegisterHtml(sb, pageHolder);
                //}

                if (container != null && container.Items.Count > 0)
                {
                    sb.AppendFormat("{0}.doLayout();", this.Control.ClientID);
                }

                this.script = this.RegisterResources(sb.ToString());
            }

            return this.script;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override bool ExcludeControl(Control parent, Control control)
        {
            return Object.ReferenceEquals(this.Control, parent) && control != this.contentContainer && !this.items.Contains(control);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static ContentScriptBuilder Create(XControl control)
        {
            return new ContentScriptBuilder(control);
        }
    }
}