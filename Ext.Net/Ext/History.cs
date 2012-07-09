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
using System.Drawing;
using System.Text;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// History management component that allows you to register arbitrary tokens that signify application history state on navigation actions.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:History runat=\"server\"></{0}:History>")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [Designer(typeof(EmptyDesigner))]
    [ToolboxBitmap(typeof(History), "Build.ToolboxIcons.History.bmp")]
    [Description("History management component that allows you to register arbitrary tokens that signify application history state on navigation actions.")]
    public partial class History : Observable, ICustomConfigSerialization, IVirtual
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public History() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.History";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        [Description("")]
        public string ToScript(Control owner)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Ext.apply(Ext.History, {0});", new ClientConfig().Serialize(this, true));
            
            if (this.IsIdRequired)
            {
                sb.AppendFormat("this.{0} = Ext.History;", this.ClientID);
            }
            
            sb.Append("Ext.History.init();");

            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        [Description("")]
        public static History GetCurrent(Page page)
        {
            if (page == null)
            {
                throw new ArgumentNullException("page");
            }

            return page.Items[typeof(History)] as History;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (!this.DesignMode)
            {
                History existingInstance = History.GetCurrent(this.Page);

                if (existingInstance != null && !DesignMode)
                {
                    throw new InvalidOperationException("Only one History control is allowed");
                }

                this.Page.Items[typeof(History)] = this;
            }
        }

        /// <summary>
        /// False to don't render form tags. By default check ASP.NET form and if it is absent then render form.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. History")]
        [DefaultValue(true)]
        [Description("False to don't render form tags. By default check ASP.NET form and if it is absent then render form.")]
        public virtual bool RenderForm
        {
            get
            {
                object obj = this.ViewState["RenderForm"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["RenderForm"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        [Description("")]
        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);

            if (!this.IsInForm && this.RenderForm)
            {
                writer.Write("<form id=\"history-form\" class=\"x-hidden\">");
            }
            else
            {
                writer.Write("<div class=\"x-hidden\">");
            }

            writer.Write("<input type=\"hidden\" id=\"x-history-field\" /><iframe id=\"x-history-frame\"></iframe>");

            if (!this.IsInForm && this.RenderForm)
            {
                writer.Write("</form>");
            }
            else
            {
                writer.Write("</div>");
            }
        }

        private HistoryListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ViewStateMember]
        [Description("Client-side JavaScript Event Handlers")]
        public HistoryListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new HistoryListeners();
                }

                return this.listeners;
            }
        }


        private HistoryDirectEvents directEvents;

        /// <summary>
        /// Server-side DirectEvent Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]
        [ViewStateMember]
        [Description("Server-side DirectEventHandlers")]
        public HistoryDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new HistoryDirectEvents();
                }

                return this.directEvents;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="args"></param>
        [Meta]
        [Description("")]
        protected virtual void CallHistory(string name, params object[] args)
        {
            this.CallTemplate("Ext.History.{1}({2});", name, args);
        }

        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Add a new token to the history stack. This can be any arbitrary value, although it would commonly be the concatenation of a component id and another id marking the specifc history state of that component.
        /// </summary>
        [Meta]
        [Description("Add a new token to the history stack. This can be any arbitrary value, although it would commonly be the concatenation of a component id and another id marking the specifc history state of that component.")]
        public virtual void Add(string token, bool preventDuplicate)
        {
            this.CallHistory("add", token, preventDuplicate);
        }

        /// <summary>
        /// Add a new token to the history stack. This can be any arbitrary value, although it would commonly be the concatenation of a component id and another id marking the specifc history state of that component.
        /// </summary>
        [Meta]
        [Description("Add a new token to the history stack. This can be any arbitrary value, although it would commonly be the concatenation of a component id and another id marking the specifc history state of that component.")]
        public virtual void Add(string token)
        {
            this.CallHistory("add", token);
        }

        /// <summary>
        /// Programmatically steps back one step in browser history (equivalent to the user pressing the Back button).
        /// </summary>
        [Meta]
        [Description("Programmatically steps back one step in browser history (equivalent to the user pressing the Back button).")]
        public virtual void Back()
        {
            this.CallHistory("back");
        }

        /// <summary>
        /// Programmatically steps forward one step in browser history (equivalent to the user pressing the Forward button).
        /// </summary>
        [Meta]
        [Description("Programmatically steps forward one step in browser history (equivalent to the user pressing the Forward button).")]
        public virtual void Forward()
        {
            this.CallHistory("forward");
        }
    }
}