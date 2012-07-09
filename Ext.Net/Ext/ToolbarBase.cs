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
    public abstract partial class ToolbarBase : ContainerBase
    {
        /// <summary>
        /// The default type of content Container represented by this object as registered in Ext.ComponentMgr (defaults to 'panel').
        /// </summary>
        [Meta]
        [Category("5. Container")]
        [DefaultValue("Button")]
        [NotifyParentProperty(true)]
        [Description("The default type of content Container represented by this object as registered in Ext.ComponentMgr (defaults to 'panel').")]
        public override string DefaultType
        {
            get
            {
                return (string)this.ViewState["DefaultType"] ?? "Button";
            }
            set
            {
                this.ViewState["DefaultType"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("defaultType")]
        [DefaultValue("button")]
        [Description("")]
        protected virtual string DefaultTypeProxy
        {
            get
            {
                return base.DefaultTypeProxy;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override bool UseDefaultLayout
        {
            get
            {
                return false;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected override void OnPreRender(EventArgs e)
        {
            if (this.Flat && (!Ext.Net.X.IsAjaxRequest || this.IsDynamic))
            {
                this.Cls = this.Cls.ConcatWith(this.Cls.IsEmpty() ? "" : " ", "x-inline-toolbar");
            }

            if (this.Items.Count == 1 && !(this.Items[0] is Layout))
            {
                //workaround for creating array always in ItemCollectionJsonConverter
                this.Items.Add(new ToolbarSpacer());
            }

            base.OnPreRender(e);
        }

        /// <summary>
        /// True to use flat style.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Toolbar")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to use flat style.")]
        public virtual bool Flat
        {
            get
            {
                object obj = this.ViewState["Flat"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Flat"] = value;
            }
        }

        /// <summary>
        /// True to use classic (none-flat) style.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Toolbar")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to use classic (none-flat) style.")]
        public virtual bool ClassicButtonStyle
        {
            get
            {
                object obj = this.ViewState["ClassicButtonStyle"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["ClassicButtonStyle"] = value;
            }
        }

        /// <summary>
        /// Defaults to false. Configure <tt>true</tt> to make the toolbar provide a button which activates a dropdown Menu to show items which overflow the Toolbar's width.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Toolbar")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Defaults to false. Configure <tt>true</tt> to make the toolbar provide a button which activates a dropdown Menu to show items which overflow the Toolbar's width.")]
        public virtual bool EnableOverflow
        {
            get
            {
                object obj = this.ViewState["EnableOverflow"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["EnableOverflow"] = value;
            }
        }
    }
}