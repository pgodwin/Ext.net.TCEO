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
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// Ext.Net ResourceMangerProxy Control. Used when the ResourceManager is inaccessible.
    /// </summary>
    [ToolboxData("<{0}:ResourceManagerProxy runat=\"server\" />")]
    [Designer(typeof(ResourceManagerDesigner))]
    [ToolboxBitmap(typeof(ResourceManager), "Build.ToolboxIcons.ResourceManagerProxy.bmp")]
    [Description("Ext.Net ResourceMangerProxy Control. Used when the ResourceManager is inaccessible.")]
    public partial class ResourceManagerProxy : ResourceManager
    {
        private const string errorMessage = "This global property must be set in the ResourceManager";

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void OnInit(EventArgs e) { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override object SaveViewState()
        {
            return null;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void TrackViewState() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void LoadViewState(object savedState) { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void Render(HtmlTextWriter writer)
        {
            if (!this.DesignMode)
            {
                this.SimpleRender(writer);
            }
            else
            {
                base.Render(writer);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override void AddScript(string script)
        {
            this.ResourceManager.AddScript(script);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void OnPreRender(EventArgs e)
        {
            if (!this.DesignMode)
            {
                if (!RequestManager.IsAjaxRequest)
                {
                    this.RegisterEvents(this);
                    this.RegisterCustomListeners();
                    this.RegisterDirectEvents();
                }
            }
            else
            {
                base.OnPreRender(e);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public override string DirectEventUrl
        {
            get { return base.DirectEventUrl; }
            set
            {
                throw new InvalidOperationException(errorMessage);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public override ViewStateMode AjaxViewStateMode
        {
            get { return base.AjaxViewStateMode; }
            set
            {
                throw new InvalidOperationException(errorMessage);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public override ClientProxy DirectMethodProxy
        {
            get { return base.DirectMethodProxy; }
            set
            {
                throw new InvalidOperationException(errorMessage);
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
            set
            {
                throw new InvalidOperationException(errorMessage);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public override bool CleanResourceUrl
        {
            get { return base.CleanResourceUrl; }
            set
            {
                throw new InvalidOperationException(errorMessage);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public override InitScriptMode InitScriptMode
        {
            get { return base.InitScriptMode; }
            set
            {
                throw new InvalidOperationException(errorMessage);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public override ResourceLocationType RenderScripts
        {
            get { return base.RenderScripts; }
            set
            {
                throw new InvalidOperationException(errorMessage);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public override ResourceLocationType RenderStyles
        {
            get { return base.RenderStyles; }
            set
            {
                throw new InvalidOperationException(errorMessage);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public override string ResourcePath
        {
            get { return base.ResourcePath; }
            set
            {
                throw new InvalidOperationException(errorMessage);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public override ScriptMode ScriptMode
        {
            get { return base.ScriptMode; }
            set
            {
                throw new InvalidOperationException(errorMessage);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public override bool SourceFormatting
        {
            get { return base.SourceFormatting; }
            set
            {
                throw new InvalidOperationException(errorMessage);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public override Theme Theme
        {
            get { return base.Theme; }
            set
            {
                throw new InvalidOperationException(errorMessage);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public override ScriptAdapter ScriptAdapter
        {
            get { return base.ScriptAdapter; }
            set
            {
                throw new InvalidOperationException(errorMessage);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public override StateProvider StateProvider
        {
            get { return base.StateProvider; }
            set
            {
                throw new InvalidOperationException(errorMessage);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public override bool QuickTips
        {
            get { return base.QuickTips; }
            set
            {
                throw new InvalidOperationException(errorMessage);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public override string Locale
        {
            get { return base.Locale; }
            set
            {
                throw new InvalidOperationException(errorMessage);
            }
        }
    }
}