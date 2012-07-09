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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    public partial class CheckMenuItem
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public CheckMenuItem(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit CheckMenuItem.Config Conversion to CheckMenuItem
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator CheckMenuItem(CheckMenuItem.Config config)
        {
            return new CheckMenuItem(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : MenuItemBase.Config 
        { 
			/*  Implicit CheckMenuItem.Config Conversion to CheckMenuItem.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator CheckMenuItem.Builder(CheckMenuItem.Config config)
			{
				return new CheckMenuItem.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool _checked = false;

			/// <summary>
			/// True to initialize this checkbox as checked (defaults to false). Note that if this checkbox is part of a radio group (group = true) only the last item in the group that is initialized with checked = true will be rendered as checked.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Checked 
			{ 
				get
				{
					return this._checked;
				}
				set
				{
					this._checked = value;
				}
			}

			private string group = "";

			/// <summary>
			/// All check items with the same group name will automatically be grouped into a single-select radio button group (defaults to '').
			/// </summary>
			[DefaultValue("")]
			public virtual string Group 
			{ 
				get
				{
					return this.group;
				}
				set
				{
					this.group = value;
				}
			}

			private string groupClass = "";

			/// <summary>
			/// The default CSS class to use for radio group check items (defaults to \"x-menu-group-item\")
			/// </summary>
			[DefaultValue("")]
			public virtual string GroupClass 
			{ 
				get
				{
					return this.groupClass;
				}
				set
				{
					this.groupClass = value;
				}
			}

			private string checkHandler = "";

			/// <summary>
			/// A function that handles the checkchange event.
			/// </summary>
			[DefaultValue("")]
			public virtual string CheckHandler 
			{ 
				get
				{
					return this.checkHandler;
				}
				set
				{
					this.checkHandler = value;
				}
			}
        
			private CheckMenuItemListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public CheckMenuItemListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new CheckMenuItemListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private CheckMenuItemDirectEvents directEvents = null;

			/// <summary>
			/// Server-side DirectEventHandlers
			/// </summary>
			public CheckMenuItemDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new CheckMenuItemDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}