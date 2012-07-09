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
using System.Drawing;
using System.Text;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Designer(typeof(EmptyDesigner))]
    [ToolboxBitmap(typeof(Desktop), "Build.ToolboxIcons.Desktop.bmp")]
    [ToolboxData("<{0}:Desktop runat=\"server\"></{0}:Desktop>")]
    [Description("")]
    public partial class Desktop : Component
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Desktop() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override List<ResourceItem> Resources
        {
            get
            {
                List<ResourceItem> baseList = base.Resources;
                baseList.Capacity += 2;

                baseList.Add(new ClientStyleItem(typeof(Desktop), "Ext.Net.Build.Ext.Net.ux.extensions.desktop.css.desktop-embedded.css", "/ux/extensions/desktop/css/desktop.css"));
                baseList.Add(new ClientScriptItem(typeof(Desktop), "Ext.Net.Build.Ext.Net.ux.extensions.desktop.js.Desktop.js", "/ux/extensions/desktop/js/Desktop.js"));

                return baseList;
            }
        }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.app.App";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.Ignore)]
        [Description("")]
        protected internal override string RenderToProxy
        {
            get
            {
                return "";
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void Render(HtmlTextWriter writer)
        {
            this.SimpleRender(writer);
            
            writer.Write("<div id=\"x-desktop\">");

            if (this.Shortcuts.Count>0)
            {
                writer.Write("<dl id=\"x-shortcuts\">");
            }

            foreach (DesktopShortcut shortcut in this.Shortcuts)
            {
                if (shortcut.ModuleID.IsEmpty() && shortcut.ShortcutID.IsEmpty())
                {
                    throw new ArgumentNullException("Shortcut", "You must specify ModuleID or ShortcutID for shortcut");
                }

                string sUrl = this.ResourceManager.GetWebResourceUrl("Ext.Net.Build.Ext.Net.extjs.resources.images.default.s.gif");

                writer.Write("<dt id=\"");
                writer.Write(shortcut.ModuleID.IsEmpty() ? shortcut.ShortcutID : shortcut.ModuleID);
                writer.Write("-shortcut\"");

                if (shortcut.ShortcutID.IsNotEmpty())
                {
                    writer.Write(" ext:custom=\"true\"");
                }

                if (shortcut.X.IsNotEmpty() && shortcut.Y.IsNotEmpty())
                {
                    writer.Write(" ext:X=\"");
                    writer.Write(shortcut.X);
                    writer.Write("\"");

                    writer.Write(" ext:Y=\"");
                    writer.Write(shortcut.Y);
                    writer.Write("\"");
                }

                writer.Write(">");
                writer.Write("<a href=\"#\"><img src=\"");
                writer.Write(sUrl);
                writer.Write("\"");

                if (shortcut.IconCls.IsNotEmpty())
                {
                    writer.Write(" class=\"");
                    writer.Write(shortcut.IconCls);
                    writer.Write("\"");
                }
                
                writer.Write("/><div class=\"x-shortcut-text\">");
                writer.Write(shortcut.Text);
                writer.Write("</div></a></dt>");
            }

            if (this.Shortcuts.Count > 0)
            {
                writer.Write("</dl>");
            }

            foreach (Control control in this.Controls)
            {
                control.RenderControl(writer);
            }

            writer.Write("</div>");
            writer.Write("<div id=\"ux-taskbar\"><div id=\"ux-taskbar-start\"></div><div id=\"ux-taskbuttons-panel\"></div><div class=\"x-clear\"></div></div>");
        }

        private ITemplate content = null;

        /// <summary>
        /// 
        /// </summary>
        [TemplateInstance(TemplateInstance.Single)]
        [MergableProperty(false)]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        [Browsable(false)]
        [Description("")]
        public ITemplate Content
        {
            get 
            { 
                return this.content; 
            }
            set 
            { 
                this.content = value; 
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (!this.DesignMode)
            {
                Desktop existingInstance = Desktop.GetCurrent(this.Page);

                if (existingInstance != null && !DesignMode)
                {
                    throw new InvalidOperationException("Only one desktop is allowed");
                }

                this.Page.Items[typeof(Desktop)] = this;

                if (this.content != null)
                {
                    this.content.InstantiateIn(this);
                }
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static Desktop GetCurrent(Page page)
        {
            if (page == null)
            {
                throw new ArgumentNullException("page");
            }

            return page.Items[typeof(Desktop)] as Desktop;
        }

        private DesktopModulesCollection modules;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ViewStateMember]
        [Description("")]
        public DesktopModulesCollection Modules
        {
            get
            {
                if (this.modules == null)
                {
                    this.modules = new DesktopModulesCollection();
                }

                return this.modules;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void PageLoadComplete(object sender, EventArgs e)
        {
            base.PageLoadComplete(sender, e);

            foreach (DesktopModule module in this.Modules)
            {
                if (module.Launcher.Text.IsNotEmpty())
                {
                    this.Controls.Add(module.Launcher);
                    this.LazyItems.Add(module.Launcher);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("getModules", JsonMode.Raw)]
        [Description("")]
        protected string ModulesProxy
        {
            get
            {
                StringBuilder sb = new StringBuilder(256);
                sb.Append("function(){return [");

                bool commaNeed = false;

                foreach (DesktopModule module in this.Modules)
                {
                    if (commaNeed)
                    {
                        sb.Append(",");
                    }

                    commaNeed = true;

                    sb.Append("new Ext.app.Module(");
                    sb.Append(new ClientConfig().Serialize(module));
                    sb.Append(")");
                }
                    
                sb.Append("];}");

                return sb.ToString();
            }
        }

        private StartMenuConfig startMenu;

        /// <summary>
        /// 
        /// </summary>
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ViewStateMember]
        [Description("")]
        public StartMenuConfig StartMenu
        {
            get
            {
                if (this.startMenu == null)
                {
                    this.startMenu = new StartMenuConfig(this);
                }

                return this.startMenu;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("getStartConfig", JsonMode.Raw)]
        [Description("")]
        protected string StartMenuProxy
        {
            get
            {
                if (this.StartMenu.Icon != Icon.None)
                {
                    this.ResourceManager.RegisterIcon(this.StartMenu.Icon);
                }

                return new JFunction("return ".ConcatWith(new ClientConfig().Serialize(this.StartMenu), ";")).ToScript();
            }
        }

        private StartButtonConfig startButton;

        /// <summary>
        /// 
        /// </summary>
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ViewStateMember]
        [Description("")]
        public StartButtonConfig StartButton
        {
            get
            {
                if (this.startButton == null)
                {
                    this.startButton = new StartButtonConfig();
                }

                return this.startButton;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("getStartButtonConfig", JsonMode.Raw)]
        [Description("")]
        protected string StartButtonProxy
        {
            get
            {
                if (this.StartButton.Icon != Icon.None)
                {
                    this.ResourceManager.RegisterIcon(this.StartButton.Icon);
                }

                return new JFunction("return ".ConcatWith(new ClientConfig().Serialize(this.StartButton), ";")).ToScript();
            }
        }

        private DesktopShortcuts shortcuts;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ViewStateMember]
        [Description("")]
        public DesktopShortcuts Shortcuts
        {
            get
            {
                if (this.shortcuts == null)
                {
                    this.shortcuts = new DesktopShortcuts();
                }

                return this.shortcuts;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. Desktop")]
        [DefaultValue(1)]
        [Description("")]
        public virtual int XTickSize
        {
            get
            {
                object obj = this.ViewState["XTickSize"];
                return obj == null ? 1 : (int)obj;
            }
            set
            {
                this.ViewState["XTickSize"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. Desktop")]
        [DefaultValue(1)]
        [Description("")]
        public virtual int YTickSize
        {
            get
            {
                object obj = this.ViewState["YTickSize"];
                return obj == null ? 1 : (int)obj;
            }
            set
            {
                this.ViewState["YTickSize"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. Desktop")]
        [DefaultValue("")]
        [DirectEventUpdate(MethodName = "SetBackgroundColor")]
        [Description("")]
        public virtual string BackgroundColor
        {
            get
            {
                return (string)this.ViewState["BackgroundColor"] ?? "";
            }
            set
            {
                this.ViewState["BackgroundColor"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. Desktop")]
        [DefaultValue("")]
        [DirectEventUpdate(MethodName = "SetShortcutTextColor")]
        [Description("")]
        public string ShortcutTextColor
        {
            get
            {
                return (string)this.ViewState["ShortcutTextColor"] ?? "";
            }
            set
            {
                this.ViewState["ShortcutTextColor"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. Desktop")]
        [DefaultValue("")]
        [DirectEventUpdate(MethodName = "SetWallpaper")]
        [Description("")]
        public string Wallpaper
        {
            get
            {
                return (string)this.ViewState["Wallpaper"] ?? "";
            }
            set
            {
                this.ViewState["Wallpaper"] = value;
            }
        }

        /// <summary>
        /// The maximum length of Ext.ux.TaskBar.TaskButton's text to allow before truncating
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. Desktop")]
        [DefaultValue(12)]
        [Description("The maximum length of Ext.ux.TaskBar.TaskButton's text to allow before truncating")]
        public int TextLengthToTruncate
        {
            get
            {
                object obj = this.ViewState["TextLengthToTruncate"];
                return obj == null ? 12 : (int)obj;
            }
            set
            {
                this.ViewState["TextLengthToTruncate"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="args"></param>
        [Description("")]
        protected internal virtual void CallDesktop(string name, params object[] args)
        {
            this.CallTemplate("{0}.getDesktop().{1}({2});", name, args);
        }


        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        protected virtual void SetWallpaper(string url)
        {
            this.CallDesktop("setWallpaper", url.IsEmpty() ? "" : this.Page.ResolveUrl(url));
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void SetBackgroundColor(string color)
        {
            this.CallDesktop("setBackgroundColor", color);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void SetShortcutTextColor(string color)
        {
            this.CallDesktop("setFontColor", color);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void Tile()
        {
            this.CallDesktop("tile");
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void Cascade()
        {
            this.CallDesktop("cascade");
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void SetTickSize(int tickSize)
        {
            this.CallDesktop("setTickSize", tickSize);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void SetTickSize(int xTickSize, int yTickSize)
        {
            this.CallDesktop("setTickSize", xTickSize, yTickSize);
        }

        private DesktopListeners listeners;

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
        public DesktopListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new DesktopListeners();
                }

                return this.listeners;
            }
        }


        private DesktopDirectEvents directEvents;

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
        public DesktopDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new DesktopDirectEvents();
                }

                return this.directEvents;
            }
        }
    }
}