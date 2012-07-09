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

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class WindowActionList : ExtControlActionList
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public WindowActionList(IComponent component) : base(component) { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public bool InitCenter
        {
            get
            {
                return ((Window)this.Control).InitCenter;
            }
            set
            {
                this.GetPropertyByName("InitCenter").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public bool Hidden
        {
            get
            {
                return !((Window)this.Control).Hidden;
            }
            set
            {
                this.GetPropertyByName("Hidden").SetValue(this.Control, !value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public bool Closable
        {
            get
            {
                return ((Window)this.Control).Closable;
            }
            set
            {
                this.GetPropertyByName("Closable").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public bool Collapsible
        {
            get
            {
                return ((Window)this.Control).Collapsible;
            }
            set
            {
                this.GetPropertyByName("Collapsible").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public bool Maximizable
        {
            get
            {
                return ((Window)this.Control).Maximizable;
            }
            set
            {
                this.GetPropertyByName("Maximizable").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public bool Modal
        {
            get
            {
                return ((Window)this.Control).Modal;
            }
            set
            {
                this.GetPropertyByName("Modal").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public CloseAction CloseAction
        {
            get
            {
                return ((Window)this.Control).CloseAction;
            }
            set
            {
                this.GetPropertyByName("CloseAction").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Title
        {
            get
            {
                return ((Window)this.Control).Title;
            }
            set
            {
                this.GetPropertyByName("Title").SetValue(this.Control, value);
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
                return ((Window)this.Control).Height;
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
        public Unit MinHeight
        {
            get
            {
                return ((Window)this.Control).MinHeight;
            }
            set
            {
                this.GetPropertyByName("MinHeight").SetValue(this.Control, value);
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
                return ((Window)this.Control).Width;
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
        public Unit MinWidth
        {
            get
            {
                return ((Window)this.Control).MinWidth;
            }
            set
            {
                this.GetPropertyByName("MinWidth").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Unit PageX
        {
            get
            {
                return ((Window)this.Control).PageX;
            }
            set
            {
                this.GetPropertyByName("PageX").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Unit PageY
        {
            get
            {
                return ((Window)this.Control).PageY;
            }
            set
            {
                this.GetPropertyByName("PageY").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Icon Icon
        {
            get
            {
                return ((PanelBase)this.Control).Icon;
            }
            set
            {
                this.GetPropertyByName("Icon").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            this.AddHeaderItem(new DesignerActionHeaderItem("Positioning", "600"));
            this.AddHeaderItem(new DesignerActionHeaderItem("Actions", "700"));

            this.AddPropertyItem(new DesignerActionPropertyItem("Title", "Title", "500", "Change the Title of the Window"));
            this.AddPropertyItem(new DesignerActionPropertyItem("Width", "Width", "500", "Change the Width of the control"));
            this.AddPropertyItem(new DesignerActionPropertyItem("Height", "Height", "500", "Change the Height of the control"));
            this.AddPropertyItem(new DesignerActionPropertyItem("Icon", "Icon", "500", "Set an icon to use in the Title bar"));
            
            this.AddPropertyItem(new DesignerActionPropertyItem("Hidden", "Show on Page Load", "600", "Automatically show the window on Page Load"));
            this.AddPropertyItem(new DesignerActionPropertyItem("InitCenter", "Center on Page Load", "600", "Center this Window in the viewport on Page Load"));

            DesignerActionPropertyItem pageX = new DesignerActionPropertyItem("PageX", "PageX", "600", "The position in pixels from the left of the view port (browser window)");
            DesignerActionPropertyItem pageY = new DesignerActionPropertyItem("PageY", "PageY", "600", "The position in pixels from the addToStart of the view port (browser window)");

            if (this.InitCenter)
            {
                this.RemovePropertyItem(pageX);
                this.RemovePropertyItem(pageY);
            }
            else
            {
                this.AddPropertyItem(pageX);
                this.AddPropertyItem(pageY);
            }
            
            this.AddPropertyItem(new DesignerActionPropertyItem("Collapsible", "Collapsible", "700", "Allow the user to collapse the window"));
            this.AddPropertyItem(new DesignerActionPropertyItem("Closable", "Closable", "700", "Allow the user to close the window"));

            DesignerActionPropertyItem closeAction = new DesignerActionPropertyItem("CloseAction", "Close Action", "700", "'Close' to destroy the Window, 'Hide' to simply hide the window");
            DesignerActionPropertyItem maximizable = new DesignerActionPropertyItem("Maximizable", "Maximizable", "700", "Allow the user to maximize the window");
            DesignerActionPropertyItem modal = new DesignerActionPropertyItem("Modal", "Modal", "700", "Make the window modal and mask everything behind it when displayed");

            this.RemovePropertyItem(closeAction);
            this.RemovePropertyItem(maximizable);
            this.RemovePropertyItem(modal);

            if (this.Closable)
            {
                this.AddPropertyItem(closeAction);
                this.AddPropertyItem(maximizable);
                this.AddPropertyItem(modal);
            }
            else
            {
                this.RemovePropertyItem(closeAction);
                this.AddPropertyItem(maximizable);
                this.AddPropertyItem(modal);
            }

            return base.GetSortedActionItems();
        }
    }
}