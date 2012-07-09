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
using System.Drawing;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// A specialized panel intended for use as an application window. Windows are floated and draggable by default, and also provide specific behavior like the ability to maximize and restore (with an event for minimizing, since the minimize behavior is application-specific). Windows can also be linked to a Ext.WindowGroup or managed by the Ext.WindowManager to provide grouping, activation, to front/back and other application-specific behavior.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:DesktopWindow runat=\"server\" Title=\"Title\" Collapsible=\"true\" Icon=\"Application\"><Items></Items></{0}:DesktopWindow>")]
    [ToolboxBitmap(typeof(DesktopWindow), "Build.ToolboxIcons.DesktopWindow.bmp")]
    [Designer(typeof(WindowDesigner))]
    [Description("A specialized panel intended for use as an application window. Windows are floated and draggable by default, and also provide specific behavior like the ability to maximize and restore (with an event for minimizing, since the minimize behavior is application-specific). Windows can also be linked to a Ext.WindowGroup or managed by the Ext.WindowManager to provide grouping, activation, to front/back and other application-specific behavior.")]
    public partial class DesktopWindow : Window
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public DesktopWindow() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "desktopwindow";
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
                return "Ext.net.DesktopWindow";
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        [Description("")]
        protected override void OnBeforeClientInit(Observable sender)
        {
            if (this.Maximizable)
            {
                this.CustomConfig.Add(new ConfigItem("maximizable", "true", ParameterMode.Raw));
            }

            if (this.Minimizable)
            {
                this.CustomConfig.Add(new ConfigItem("minimizable", "true", ParameterMode.Raw));
            }

            this.Hidden = true;

            base.OnBeforeClientInit(sender);
        }

        /// <summary>
        /// True to display the 'maximize' tool button and allow the user to maximize the window, false to hide the button and disallow maximizing the window (defaults to false). Note that when a window is maximized, the tool button will automatically change to a 'restore' button with the appropriate behavior already built-in that will restore the window to its previous size.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Ignore)]
        [Category("8. DesktopWindow")]
        [DefaultValue(true)]
        [Description("True to display the 'maximize' tool button and allow the user to maximize the window, false to hide the button and disallow maximizing the window (defaults to false). Note that when a window is maximized, the tool button will automatically change to a 'restore' button with the appropriate behavior already built-in that will restore the window to its previous size.")]
        public override bool Maximizable
        {
            get
            {
                object obj = this.ViewState["Maximizable"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["Maximizable"] = value;
            }
        }

        /// <summary>
        /// True to force rendering otherwise rendering will be performed before the first showing.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. DesktopWindow")]
        [DefaultValue(true)]
        [Description("True to force rendering otherwise rendering will be performed before the first showing.")]
        public virtual bool LazyRender
        {
            get
            {
                object obj = this.ViewState["LazyRender"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["LazyRender"] = value;
            }
        }

        /// <summary>
        /// False to skip task button showing
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. DesktopWindow")]
        [DefaultValue(true)]
        [Description("False to skip task button showing")]
        public virtual bool ShowInTaskbar
        {
            get
            {
                object obj = this.ViewState["ShowInTaskbar"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["ShowInTaskbar"] = value;
            }
        }

        /// <summary>
        /// True to display the 'minimize' tool button and allow the user to minimize the window, false to hide the button and disallow minimizing the window (defaults to false). Note that this button provides no implementation -- the behavior of minimizing a window is implementation-specific, so the minimize event must be handled and a custom minimize behavior implemented for this option to be useful.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Ignore)]
        [Category("8. DesktopWindow")]
        [DefaultValue(true)]
        [Description("True to display the 'minimize' tool button and allow the user to minimize the window, false to hide the button and disallow minimizing the window (defaults to false). Note that this button provides no implementation -- the behavior of minimizing a window is implementation-specific, so the minimize event must be handled and a custom minimize behavior implemented for this option to be useful.")]
        public override bool Minimizable
        {
            get
            {
                object obj = this.ViewState["Minimizable"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["Minimizable"] = value;
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
        public Desktop Desktop
        {
            get
            {
                if (this.DesignMode)
                {
                    return null;
                }

                return Desktop.GetCurrent(this.Page);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [DefaultValue("")]
        [ConfigOption(JsonMode.Raw)]
		[Description("")]
        protected internal string Manager
        {
            get
            {
                if (this.DesignMode)
                {
                    return "";
                }

                return this.Desktop.ClientID.ConcatWith(".desktop.getManager()");
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [DefaultValue("")]
        [ConfigOption("desktop", JsonMode.Raw)]
		[Description("")]
        protected internal string DesktopReference
        {
            get
            {
                if (this.DesignMode)
                {
                    return "";
                }

                return this.Desktop.ClientID.ConcatWith(".desktop");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Description("")]
        public override void Show()
        {
            this.AddScript("{0}.getDesktop().showWindow(\"{1}\");", this.Desktop.ClientID, this.ClientID);
        }
    }
}