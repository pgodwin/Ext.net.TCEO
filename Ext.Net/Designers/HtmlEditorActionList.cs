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

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class HtmlEditorActionList : ExtControlActionList
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public HtmlEditorActionList(IComponent component) : base(component) { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public bool EnableAlignments
        {
            get
            {
                return ((HtmlEditor)this.Control).EnableAlignments;
            }
            set
            {
                this.GetPropertyByName("EnableAlignments").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public bool EnableColors
        {
            get
            {
                return ((HtmlEditor)this.Control).EnableColors;
            }
            set
            {
                this.GetPropertyByName("EnableColors").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public bool EnableFont
        {
            get
            {
                return ((HtmlEditor)this.Control).EnableFont;
            }
            set
            {
                this.GetPropertyByName("EnableFont").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public bool EnableFontSize
        {
            get
            {
                return ((HtmlEditor)this.Control).EnableFontSize;
            }
            set
            {
                this.GetPropertyByName("EnableFontSize").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public bool EnableFormat
        {
            get
            {
                return ((HtmlEditor)this.Control).EnableFormat;
            }
            set
            {
                this.GetPropertyByName("EnableFormat").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public bool EnableLinks
        {
            get
            {
                return ((HtmlEditor)this.Control).EnableLinks;
            }
            set
            {
                this.GetPropertyByName("EnableLinks").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public bool EnableLists
        {
            get
            {
                return ((HtmlEditor)this.Control).EnableLists;
            }
            set
            {
                this.GetPropertyByName("EnableLists").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public bool EnableSourceEdit
        {
            get
            {
                return ((HtmlEditor)this.Control).EnableSourceEdit;
            }
            set
            {
                this.GetPropertyByName("EnableSourceEdit").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Unit Height
        {
            get
            {
                return ((HtmlEditor)this.Control).Height;
            }
            set
            {
                this.GetPropertyByName("Height").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Unit Width
        {
            get
            {
                return ((HtmlEditor)this.Control).Width;
            }
            set
            {
                this.GetPropertyByName("Width").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            this.AddPropertyItem(new DesignerActionPropertyItem("EnableFont", "Enable Fonts", "500", "Enable font selection. Not available in Safari."));
            this.AddPropertyItem(new DesignerActionPropertyItem("EnableFormat", "Enable Formatting", "500", "Enable the bold, italic and underline buttons."));
            this.AddPropertyItem(new DesignerActionPropertyItem("EnableFontSize", "Enable FontSize", "500", "Enable the increase/decrease font size buttons."));
            this.AddPropertyItem(new DesignerActionPropertyItem("EnableColors", "Enable Colors", "500", "Enable the fore/highlight color buttons."));
            this.AddPropertyItem(new DesignerActionPropertyItem("EnableAlignments", "Enable Alignments", "500", "Enable the left, center, right alignment buttons."));
            this.AddPropertyItem(new DesignerActionPropertyItem("EnableLinks", "Enable Hyperlinks", "500", "Enable the create link button."));
            this.AddPropertyItem(new DesignerActionPropertyItem("EnableLists", "Enable Lists", "500", "Enable the bullet and numbered list buttons."));
            this.AddPropertyItem(new DesignerActionPropertyItem("EnableSourceEdit", "Enable Source Editing", "500", "Enable the switch to source edit button."));

            this.AddPropertyItem(new DesignerActionPropertyItem("Width", "Width", "500", "Change the Width of the control"));
            this.AddPropertyItem(new DesignerActionPropertyItem("Height", "Height", "500", "Change the Height of the control"));

            return base.GetSortedActionItems();
        }
    }
}