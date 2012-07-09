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
using System.Web.UI.WebControls;
using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Base Class for all Component Plugins. Add plugin to a Component using the .Plugins property or &lt;Plugins> node.
    /// </summary>
    [Meta]
    [ToolboxItem(false)]
    [Description("Base Class for all Component Plugins. Add plugin to a Component using the .Plugins property or <Plugins> node.")]
    public abstract partial class Plugin : LazyObservable 
    {
		/// <summary>
		/// 
		/// </summary>
        [ConfigOption(JsonMode.Ignore)]
		[Description("")]
        protected override string ConfigIDProxy
        {
            get
            {
                return base.ConfigIDProxy;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public override IDMode IDMode
        {
            get { return base.IDMode; }
            set { base.IDMode = value; }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public override Unit Width
        {
            get { return base.Width; }
            set { base.Width = value; }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public override Unit Height
        {
            get { return base.Height; }
            set { base.Height = value; }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public override bool EnableTheming
        {
            get { return base.EnableTheming; }
            set { base.EnableTheming = value; }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public override bool EnableViewState
        {
            get { return base.EnableViewState; }
            set { base.EnableViewState = value; }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public override string SkinID
        {
            get { return base.SkinID; }
            set { base.SkinID = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual bool Singleton
        {
            get
            {
                object obj = this.ViewState["Singleton"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Singleton"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            // render nothing
            this.SimpleRender(writer);
        }

        private Component pluginOwner;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected Component PluginOwner
        {
            get
            {
                return this.pluginOwner;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected internal virtual void PluginAdded()
        {
            this.pluginOwner = this.ParentComponent;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected internal virtual void PluginRemoved()
        {
        }
    }
}