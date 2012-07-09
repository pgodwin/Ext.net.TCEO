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

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class Mask : ScriptClass
    {
        /*  IScriptable
            -----------------------------------------------------------------------------------------------*/
        
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.net.Mask";
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string ToScript()
        {
            return this.currentConfig != null ? this.InstanceOf.ConcatWith(".show(", TokenUtils.ParseTokens(this.currentConfig.ToScript(), this.Page), ");") : "";
        }


        /*  Configure
            -----------------------------------------------------------------------------------------------*/

        private MaskConfig currentConfig = null;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual Mask Configure(MaskConfig config)
        {
            this.currentConfig = config;

            return this;
        }


        /*  Show
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void Show()
        {
            this.Render();
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void Show(MaskConfig config)
        {
            this.Configure(config).Show();
        }


        /*  Hide
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Hides the message box if it is displayed
        /// </summary>
        [Description("Hides the mask")]
        public void Hide()
        {
            this.Call("hide");
        }
    }

    /// <summary>
    /// A config object containing any or all of the following properties. If this object is not specified the status will be cleared using the defaults.
    /// </summary>
    [ToolboxItem(false)]
    [Description("A config object containing any or all of the following properties. If this object is not specified the status will be cleared using the defaults.")]
    public partial class MaskConfig : ExtObject
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual string ToScript()
        {
            return new ClientConfig().Serialize(this);
        }

        string msg = "";

        /// <summary>
        /// The title text
        /// </summary>
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The title text")]
        public virtual string Msg
        {
            get
            {
                return this.msg;
            }
            set
            {
                this.msg = value;
            }
        }

        string msgCls = "";

        /// <summary>
        /// An id or Element from which the message box should animate as it opens and closes (defaults to undefined)
        /// </summary>
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("An id or Element from which the message box should animate as it opens and closes (defaults to undefined)")]
        public virtual string MsgCls
        {
            get
            {
                return this.msgCls;
            }
            set
            {
                this.msgCls = value;
            }
        }

        string el = "";

        /// <summary>
        /// An id or Element from which the message box should animate as it opens and closes (defaults to undefined)
        /// </summary>
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("An element to mask")]
        public virtual string El
        {
            get
            {
                return this.el;
            }
            set
            {
                this.el = value;
            }
        }

        private Control control = null;

        /// <summary>
        /// A Control to mask
        /// </summary>
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("An element to mask")]
        public virtual Control Control
        {
            get
            {
                return this.control;
            }
            set
            {
                this.control = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("el", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected virtual string ElProxy
        {
            get
            {
                if (this.Control != null)
                {
                    if (this.Control is Component)
                    {
                        return this.Control.ClientID;
                    }

                    return "Ext.get(\"".ConcatWith(this.Control.ClientID, "\")");
                }

                return this.El;
            }
        }
    }
}