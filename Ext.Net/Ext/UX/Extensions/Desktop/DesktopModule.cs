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
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public partial class DesktopModule : StateManagedItem
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public DesktopModule() { }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("id")]
        [Category("2. DesktopModule")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string ModuleID
        {
            get
            {
                return (string)this.ViewState["ModuleID"] ?? "";
            }
            set
            {
                this.ViewState["ModuleID"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Category("2. DesktopModule")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string WindowID
        {
            get
            {
                return (string)this.ViewState["WindowID"] ?? "";
            }
            set
            {
                this.ViewState["WindowID"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("windowID")]
        [DefaultValue("")]
		[Description("")]
        protected string WindowProxy
        {
            get
            {
                if (this.WindowID.IsEmpty())
                {
                    return "";
                }
                Control control = ControlUtils.FindControl(this.Owner, this.WindowID, true);

                if (control != null)
                {
                    return control.ClientID;
                }
                
                throw new InvalidOperationException("The DesktopWindow with the ID of '{0}' was not found".FormatWith(this.WindowID));
            }
        }
        
        private MenuItem launcher;

        /// <summary>
        /// 
        /// </summary>
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("")]
        public MenuItem Launcher
        {
            get
            {
                if (this.launcher == null)
                {
                    this.launcher = new MenuItem();
                }

                return this.launcher;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [DefaultValue("")]
        [ConfigOption("launcher",JsonMode.Raw)]
		[Description("")]
        protected string LauncherProxy
        {
            get
            {
                if (this.launcher.Text.IsEmpty())
                {
                    return "";
                }

                return "{".ConcatWith(this.Launcher.ClientID, "_ClientInit}");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. DesktopModule")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual bool AutoRun
        {
            get
            {
                object obj = this.ViewState["AutoRun"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["AutoRun"] = value;
            }
        }

    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class DesktopModulesCollection : StateManagedCollection<DesktopModule> { }
}