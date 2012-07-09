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
using System.Web.UI;
using System.Drawing;

namespace Ext.Net
{
    /// <summary>
    /// A Flash Component
    /// </summary>
    [Meta]
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(FlashComponent), "Build.ToolboxIcons.FlashComponent.bmp")]
    [ToolboxData("<{0}:FlashComponent runat=\"server\"></{0}:FlashComponent>")]
    [Designer(typeof(EmptyDesigner))]
    [Description("A Flash Component")]
    public partial class FlashComponent : BoxComponentBase
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public FlashComponent() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "flash";
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
                return "Ext.FlashComponent";
            }
        }

        /// <summary>
        /// The background color. Defaults to '#ffffff' (white).
        /// </summary>
        [Meta]
        [Category("5. FlashComponent")]
        [DefaultValue("#ffffff")]
        [NotifyParentProperty(true)]
        [Description("The background color. Defaults to '#ffffff' (white).")]
        public virtual string BackgroundColor
        {
            get
            {
                return (string)this.ViewState["BackgroundColor"] ?? "#ffffff";
            }
            set
            {
                this.ViewState["BackgroundColor"] = value;
            }
        }

        /// <summary>
        /// True to prompt the user to install flash if not installed. Note that this uses Ext.FlashComponent.EXPRESS_INSTALL_URL, which should be set to the local resource. Defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. FlashComponent")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to prompt the user to install flash if not installed. Note that this uses Ext.FlashComponent.EXPRESS_INSTALL_URL, which should be set to the local resource. Defaults to false.")]
        public virtual bool ExpressInstall 
        {
            get
            {
                object obj = this.ViewState["ExpressInstall"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["ExpressInstall"] = value;
            }
        }

        /// <summary>
        /// Indicates the version the flash content was published for. Defaults to '9.0.45'.
        /// </summary>
        [Meta]
        [Category("5. FlashComponent")]
        [DefaultValue("9.0.45")]
        [Description("Indicates the version the flash content was published for. Defaults to '9.0.45'.")]
        public virtual string FlashVersion
        {
            get
            {
                return (string)this.ViewState["FlashVersion"] ?? "9.0.45";
            }
            set
            {
                this.ViewState["FlashVersion"] = value;
            }
        }

        /// <summary>
        /// The URL of the swf object to include. Defaults to undefined.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Ignore)]
        [Category("5. FlashComponent")]
        [DefaultValue("")]
        [Description("The URL of the swf object to include. Defaults to undefined.")]
        public virtual string Url
        {
            get
            {
                return (string)this.ViewState["Url"] ?? "";
            }
            set
            {
                this.ViewState["Url"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("url")]
        [DefaultValue("")]
		[Description("")]
        protected virtual string UrlProxy
        {
            get
            {
                return this.ResolveUrlLink(this.Url);
            }
        }

        private ParameterCollection flashVars;

        /// <summary>
        /// A set of key value pairs to be passed to the flash object as flash variables.
        /// </summary>
        [Meta]
        [Category("5. FlashComponent")]
        [ConfigOption(JsonMode.ArrayToObject)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("A set of key value pairs to be passed to the flash object as flash variables.")]
        public virtual ParameterCollection FlashVars
        {
            get
            {
                if (this.flashVars == null)
                {
                    this.flashVars = new ParameterCollection();
                    this.flashVars.Owner = this;
                }

                return this.flashVars;
            }
        }

        private ParameterCollection flashParams;

        /// <summary>
        /// A set of key value pairs to be passed to the flash object as parameters.
        /// </summary>
        [Meta]
        [Category("5. FlashComponent")]
        [ConfigOption(JsonMode.ArrayToObject)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("A set of key value pairs to be passed to the flash object as parameters.")]
        public virtual ParameterCollection FlashParams
        {
            get
            {
                if (this.flashParams == null)
                {
                    this.flashParams = new ParameterCollection();
                    this.flashParams.Owner = this;
                }

                return this.flashParams;
            }
        }

        private FlashComponentListeners listeners;

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
        public FlashComponentListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new FlashComponentListeners();
                }

                return this.listeners;
            }
        }

        private FlashComponentDirectEvents directEvents;

        /// <summary>
        /// Server-side Ajax Event Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]
        [ViewStateMember]
        [Description("Server-side Ajax Event Handlers")]
        public FlashComponentDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new FlashComponentDirectEvents();
                }

                return this.directEvents;
            }
        }
    }
}