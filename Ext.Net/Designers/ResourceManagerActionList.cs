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
using System.ComponentModel.Design;
using System.Web.UI.WebControls;
using System.Web.UI;
using System;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class ResourceManagerActionList : ExtControlActionList
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ResourceManagerActionList(IComponent component) : base(component) { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public bool HideInDesign
        {
            get
            {
                return ((ResourceManager)this.Control).HideInDesign;
            }
            set
            {
                this.GetPropertyByName("HideInDesign").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public bool CleanResourceUrl
        {
            get
            {
                return ((ResourceManager)this.Control).CleanResourceUrl;

            }
            set
            {
                this.GetPropertyByName("CleanResourceUrl").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ResourceLocationType RenderScripts
        {
            get
            {
                return ((ResourceManager)this.Control).RenderScripts;

            }
            set
            {
                this.GetPropertyByName("RenderScripts").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ResourceLocationType RenderStyles
        {
            get
            {
                return ((ResourceManager)this.Control).RenderStyles;

            }
            set
            {
                this.GetPropertyByName("RenderStyles").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string ResourcePath
        {
            get
            {
                return ((ResourceManager)this.Control).ResourcePath;

            }
            set
            {
                this.GetPropertyByName("ResourcePath").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ScriptMode ScriptMode
        {
            get
            {
                return ((ResourceManager)this.Control).ScriptMode;

            }
            set
            {
                this.GetPropertyByName("ScriptMode").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public bool SourceFormatting
        {
            get
            {
                return ((ResourceManager)this.Control).SourceFormatting;

            }
            set
            {
                this.GetPropertyByName("SourceFormatting").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Theme Theme
        {
            get
            {
                return ((ResourceManager)this.Control).Theme;

            }
            set
            {
                this.GetPropertyByName("Theme").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ScriptAdapter ScriptAdapter
        {
            get
            {
                return ((ResourceManager)this.Control).ScriptAdapter;

            }
            set
            {
                this.GetPropertyByName("ScriptAdapter").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public StateProvider StateProvider
        {
            get
            {
                return ((ResourceManager)this.Control).StateProvider;

            }
            set
            {
                this.GetPropertyByName("StateProvider").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public bool QuickTips
        {
            get
            {
                return ((ResourceManager)this.Control).QuickTips;

            }
            set
            {
                this.GetPropertyByName("QuickTips").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public bool DisableViewState
        {
            get
            {
                return ((ResourceManager)this.Control).DisableViewState;

            }
            set
            {
                this.GetPropertyByName("DisableViewState").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public InitScriptMode InitScriptMode
        {
            get
            {
                return ((ResourceManager)this.Control).InitScriptMode;

            }
            set
            {
                this.GetPropertyByName("InitScriptMode").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            this.AddPropertyItem(new DesignerActionPropertyItem("HideInDesign", "Hide", "", "Hide the Ext.Net ResourceManager during Design-Time editing"));

            this.AddPropertyItem(new DesignerActionPropertyItem("Theme", "Theme", "500", "Sets the current Theme"));

            this.AddPropertyItem(new DesignerActionPropertyItem("CleanResourceUrl", "CleanResourceUrl", "500", "Specifies whether the Ext.Net ResourceManager will output 'clean' Url's when linking to Embedded Resources"));
            this.AddPropertyItem(new DesignerActionPropertyItem("QuickTips", "QuickTips", "500", "Enable QuickTips"));
            this.AddPropertyItem(new DesignerActionPropertyItem("DisableViewState", "DisableViewState", "500", "Disable ViewState from the page rendering"));
            //this.AddPropertyItem(new DesignerActionPropertyItem("SourceFormatting", "SourceFormatting", "500", "Specifies whether the scripts rendered to the page should be formatted"));

            this.AddPropertyItem(new DesignerActionPropertyItem("ScriptMode", "ScriptMode", "500", "Specifies whether the Scripts should be rendered in Release or Debug mode"));

            this.AddPropertyItem(new DesignerActionPropertyItem("ScriptAdapter", "ScriptAdapter", "500", "Gets the current script Adapter"));
            this.AddPropertyItem(new DesignerActionPropertyItem("InitScriptMode", "InitScriptMode", "500", "Render config script into the page or as separate JavaScript file"));
            //this.AddPropertyItem(new DesignerActionPropertyItem("StateProvider", "StateProvider", "500", "Specifies the state provider"));

            this.AddPropertyItem(new DesignerActionPropertyItem("RenderStyles", "RenderStyles", "500", "Determines how or if the required Styles should be rendered to the Page"));

            this.AddPropertyItem(new DesignerActionPropertyItem("RenderScripts", "RenderScripts", "500", "Determines how or if the required Scripts should be rendered to the Page"));

            DesignerActionPropertyItem resourcePath = new DesignerActionPropertyItem("ResourcePath", "ResourcePath", "500", "Gets the prefix of the Url path to the base ~/Ext.Net/ folder containing the resources files for this project");

            if (this.RenderScripts == ResourceLocationType.File || this.RenderStyles == ResourceLocationType.File)
            {
                this.AddPropertyItem(resourcePath);
            }
            else
            {
                this.RemovePropertyItem(resourcePath);
            }

            return base.GetSortedActionItems();
        }
    }
}