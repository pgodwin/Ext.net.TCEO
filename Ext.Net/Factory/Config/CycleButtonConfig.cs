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
    public partial class CycleButton
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public CycleButton(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit CycleButton.Config Conversion to CycleButton
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator CycleButton(CycleButton.Config config)
        {
            return new CycleButton(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : SplitButtonBase.Config 
        { 
			/*  Implicit CycleButton.Config Conversion to CycleButton.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator CycleButton.Builder(CycleButton.Config config)
			{
				return new CycleButton.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string changeHandler = "";

			/// <summary>
			/// A callback function that will be invoked each time the active menu items in the button's menu has changed. If this callback is not supplied, the SplitButton will instead fire the change event on active items change. The changeHandler function will be called with the following argument list: (SplitButton this, Ext.menu.CheckItem items).
			/// </summary>
			[DefaultValue("")]
			public virtual string ChangeHandler 
			{ 
				get
				{
					return this.changeHandler;
				}
				set
				{
					this.changeHandler = value;
				}
			}

			private string forceIcon = "";

			/// <summary>
			/// A css class which sets an image to be used as the static icon for this button. This icon will always be displayed regardless of which item is selected in the dropdown list. This overrides the default behavior of changing the button's icon to match the selected item's icon on change.
			/// </summary>
			[DefaultValue("")]
			public virtual string ForceIcon 
			{ 
				get
				{
					return this.forceIcon;
				}
				set
				{
					this.forceIcon = value;
				}
			}

			private string prependText = "";

			/// <summary>
			/// A static string to prepend before the active items's text when displayed as the button's text (only applies when showText = true, defaults to '')
			/// </summary>
			[DefaultValue("")]
			public virtual string PrependText 
			{ 
				get
				{
					return this.prependText;
				}
				set
				{
					this.prependText = value;
				}
			}

			private bool showText = false;

			/// <summary>
			/// True to display the active items's text as the button text (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool ShowText 
			{ 
				get
				{
					return this.showText;
				}
				set
				{
					this.showText = value;
				}
			}

			private bool toggleOnClick = true;

			/// <summary>
			/// False to prevent change active item after button click (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ToggleOnClick 
			{ 
				get
				{
					return this.toggleOnClick;
				}
				set
				{
					this.toggleOnClick = value;
				}
			}
        
			private CycleButtonListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public CycleButtonListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new CycleButtonListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private CycleButtonDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public CycleButtonDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new CycleButtonDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}