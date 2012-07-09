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

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(ValidationStatus), "Build.ToolboxIcons.Plugin.bmp")]
    [ToolboxData("<{0}:ValidationStatus runat=\"server\" />")]
    [Description("")]
    public partial class ValidationStatus : Plugin, IIcon
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ValidationStatus() { }

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

                baseList.Add(new ClientStyleItem(typeof(ValidationStatus), "Ext.Net.Build.Ext.Net.ux.plugins.validationstatus.css.validationstatus-embedded.css", "/ux/plugins/validationstatus/css/validationstatus.css"));
                baseList.Add(new ClientScriptItem(typeof(ValidationStatus), "Ext.Net.Build.Ext.Net.ux.plugins.validationstatus.validationstatus.js", "/ux/plugins/validationstatus/validationstatus.js"));

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
                return "Ext.ux.ValidationStatus";
            }
        }

        /// <summary>
        /// The FormPanel to use.
        /// </summary>
        [Meta]
        [ConfigOption("{raw}form", JsonMode.ToClientID)]
        [Category("3. ValidationStatus")]
        [DefaultValue("")]
        [IDReferenceProperty(typeof(FormPanel))]
        [NotifyParentProperty(true)]
        [Description("The FormPanel to use.")]
        public virtual string FormPanelID
        {
            get
            {
                return (string)ViewState["FormPanelID"] ?? "";
            }
            set
            {
                this.ViewState["FormPanelID"] = value;
            }
        }

        /// <summary>
        /// The error icon
        /// </summary>
        [Meta]
        [Category("3. ValidationStatus")]
        [DefaultValue(Icon.None)]
        [Description("The error icon")]
        public virtual Icon ErrorIcon
        {
            get
            {
                object obj = this.ViewState["ErrorIcon"];
                return (obj == null) ? Icon.None : (Icon)obj;
            }
            set
            {
                this.ViewState["ErrorIcon"] = value;
            }
        }

        /// <summary>
        /// The error icon css class
        /// </summary>
        [Meta]
        [Category("3. ValidationStatus")]
        [DefaultValue("x-status-error")]
        [IDReferenceProperty(typeof(Store))]
        [NotifyParentProperty(true)]
        [Description("The error icon css class")]
        public virtual string ErrorIconCls
        {
            get
            {
                return (string)ViewState["ErrorIconCls"] ?? "x-status-error";
            }
            set
            {
                this.ViewState["ErrorIconCls"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("errorIconCls")]
        [DefaultValue("")]
		[Description("")]
        protected virtual string ErrorIconClsProxy
        {
            get
            {
                if (this.ErrorIcon != Icon.None)
                {
                    return ResourceManager.GetIconClassName(this.ErrorIcon);
                }

                return this.ErrorIconCls;
            }
        }

        /// <summary>
        /// The error list css class
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. ValidationStatus")]
        [DefaultValue("x-status-error-list")]
        [IDReferenceProperty(typeof(Store))]
        [NotifyParentProperty(true)]
        [Description("The error list css class")]
        public virtual string ErrorListCls
        {
            get
            {
                return (string)ViewState["ErrorListCls"] ?? "x-status-error-list";
            }
            set
            {
                this.ViewState["ErrorListCls"] = value;
            }
        }

        /// <summary>
        /// The valid icon
        /// </summary>
        [Meta]
        [Category("3. ValidationStatus")]
        [DefaultValue(Icon.None)]
        [Description("The valid icon")]
        public virtual Icon ValidIcon
        {
            get
            {
                object obj = this.ViewState["ValidIcon"];
                return (obj == null) ? Icon.None : (Icon)obj;
            }
            set
            {
                this.ViewState["ValidIcon"] = value;
            }
        }

        /// <summary>
        /// The valid icon css class
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. ValidationStatus")]
        [DefaultValue("x-status-valid")]
        [IDReferenceProperty(typeof(Store))]
        [NotifyParentProperty(true)]
        [Description("The valid icon css class")]
        public virtual string ValidIconCls
        {
            get
            {
                return (string)ViewState["ValidIconCls"] ?? "x-status-valid";
            }
            set
            {
                this.ViewState["ValidIconCls"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("validIconCls")]
        [DefaultValue("")]
		[Description("")]
        protected virtual string ValidIconClsProxy
        {
            get
            {
                if (this.ValidIcon != Icon.None)
                {
                    return ResourceManager.GetIconClassName(this.ValidIcon);
                }

                return this.ValidIconCls;
            }
        }

        /// <summary>
        /// The text which shown when errors exist
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. ValidationStatus")]
        [DefaultValue("The form has errors (click for details...)")]
        [IDReferenceProperty(typeof(Store))]
        [NotifyParentProperty(true)]
        [Description("The text which shown when errors exist")]
        public virtual string ShowText
        {
            get
            {
                return (string)ViewState["ShowText"] ?? "The form has errors (click for details...)";
            }
            set
            {
                this.ViewState["ShowText"] = value;
            }
        }

        /// <summary>
        /// The text which hide error list when click on it
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. ValidationStatus")]
        [DefaultValue("Click again to hide the error list")]
        [NotifyParentProperty(true)]
        [Description("The text which hide error list when click on it")]
        public virtual string HideText
        {
            get
            {
                return (string)ViewState["HideText"] ?? "Click again to hide the error list";
            }
            set
            {
                this.ViewState["HideText"] = value;
            }
        }

        List<Icon> IIcon.Icons
        {
            get
            {
                List<Icon> icons = new List<Icon>(2);
                icons.Add(this.ErrorIcon);
                icons.Add(this.ValidIcon);
                return icons;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void StartMonitoring()
        {
            this.Call("startMonitoring");
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void StopMonitoring()
        {
            this.Call("stopMonitoring");
        }
    }
}