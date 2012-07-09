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
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : SplitButtonBase.Builder<CycleButton, CycleButton.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new CycleButton()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CycleButton component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CycleButton.Config config) : base(new CycleButton(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(CycleButton component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// A callback function that will be invoked each time the active menu items in the button's menu has changed. If this callback is not supplied, the SplitButton will instead fire the change event on active items change. The changeHandler function will be called with the following argument list: (SplitButton this, Ext.menu.CheckItem items).
			/// </summary>
            public virtual CycleButton.Builder ChangeHandler(string changeHandler)
            {
                this.ToComponent().ChangeHandler = changeHandler;
                return this as CycleButton.Builder;
            }
             
 			/// <summary>
			/// A css class which sets an image to be used as the static icon for this button. This icon will always be displayed regardless of which item is selected in the dropdown list. This overrides the default behavior of changing the button's icon to match the selected item's icon on change.
			/// </summary>
            public virtual CycleButton.Builder ForceIcon(string forceIcon)
            {
                this.ToComponent().ForceIcon = forceIcon;
                return this as CycleButton.Builder;
            }
             
 			/// <summary>
			/// A static string to prepend before the active items's text when displayed as the button's text (only applies when showText = true, defaults to '')
			/// </summary>
            public virtual CycleButton.Builder PrependText(string prependText)
            {
                this.ToComponent().PrependText = prependText;
                return this as CycleButton.Builder;
            }
             
 			/// <summary>
			/// True to display the active items's text as the button text (defaults to false).
			/// </summary>
            public virtual CycleButton.Builder ShowText(bool showText)
            {
                this.ToComponent().ShowText = showText;
                return this as CycleButton.Builder;
            }
             
 			/// <summary>
			/// False to prevent change active item after button click (defaults to true).
			/// </summary>
            public virtual CycleButton.Builder ToggleOnClick(bool toggleOnClick)
            {
                this.ToComponent().ToggleOnClick = toggleOnClick;
                return this as CycleButton.Builder;
            }
             
 			// /// <summary>
			// /// Client-side JavaScript Event Handlers
			// /// </summary>
            // public virtual TBuilder Listeners(CycleButtonListeners listeners)
            // {
            //    this.ToComponent().Listeners = listeners;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// Server-side Ajax Event Handlers
			// /// </summary>
            // public virtual TBuilder DirectEvents(CycleButtonDirectEvents directEvents)
            // {
            //    this.ToComponent().DirectEvents = directEvents;
            //    return this as TBuilder;
            // }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// This is normally called internally on button click, but can be called externally to advance the button's active item programmatically to the next one in the menu. If the current item is the last one in the menu the active item will be set to the first item in the menu.
			/// </summary>
            public virtual CycleButton.Builder ToggleSelected()
            {
                this.ToComponent().ToggleSelected();
                return this;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        public CycleButton.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.CycleButton(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public CycleButton.Builder CycleButton()
        {
            return this.CycleButton(new CycleButton());
        }

        /// <summary>
        /// 
        /// </summary>
        public CycleButton.Builder CycleButton(CycleButton component)
        {
            return new CycleButton.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public CycleButton.Builder CycleButton(CycleButton.Config config)
        {
            return new CycleButton.Builder(new CycleButton(config));
        }
    }
}