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
    public partial class MenuCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : StateManagedItem.Builder<MenuCommand, MenuCommand.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new MenuCommand()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(MenuCommand component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(MenuCommand.Config config) : base(new MenuCommand(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(MenuCommand component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual MenuCommand.Builder CommandName(string commandName)
            {
                this.ToComponent().CommandName = commandName;
                return this as MenuCommand.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual MenuCommand.Builder Icon(Icon icon)
            {
                this.ToComponent().Icon = icon;
                return this as MenuCommand.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual MenuCommand.Builder IconCls(string iconCls)
            {
                this.ToComponent().IconCls = iconCls;
                return this as MenuCommand.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual MenuCommand.Builder Text(string text)
            {
                this.ToComponent().Text = text;
                return this as MenuCommand.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual MenuCommand.Builder Cls(string cls)
            {
                this.ToComponent().Cls = cls;
                return this as MenuCommand.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual MenuCommand.Builder CtCls(string ctCls)
            {
                this.ToComponent().CtCls = ctCls;
                return this as MenuCommand.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual MenuCommand.Builder Disabled(bool disabled)
            {
                this.ToComponent().Disabled = disabled;
                return this as MenuCommand.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual MenuCommand.Builder DisabledClass(string disabledClass)
            {
                this.ToComponent().DisabledClass = disabledClass;
                return this as MenuCommand.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual MenuCommand.Builder Hidden(bool hidden)
            {
                this.ToComponent().Hidden = hidden;
                return this as MenuCommand.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual MenuCommand.Builder OverCls(string overCls)
            {
                this.ToComponent().OverCls = overCls;
                return this as MenuCommand.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual MenuCommand.Builder ItemCls(string itemCls)
            {
                this.ToComponent().ItemCls = itemCls;
                return this as MenuCommand.Builder;
            }
             
 			// /// <summary>
			// /// 
			// /// </summary>
            // public virtual TBuilder Menu(CommandMenu menu)
            // {
            //    this.ToComponent().Menu = menu;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// A function that will handle the click event of this menu item (defaults to undefined).
			/// </summary>
            public virtual MenuCommand.Builder Handler(string handler)
            {
                this.ToComponent().Handler = handler;
                return this as MenuCommand.Builder;
            }
             
 			/// <summary>
			/// True to hide the containing menu after this item is clicked (defaults to true).
			/// </summary>
            public virtual MenuCommand.Builder HideOnClick(bool hideOnClick)
            {
                this.ToComponent().HideOnClick = hideOnClick;
                return this as MenuCommand.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public MenuCommand.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.MenuCommand(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public MenuCommand.Builder MenuCommand()
        {
            return this.MenuCommand(new MenuCommand());
        }

        /// <summary>
        /// 
        /// </summary>
        public MenuCommand.Builder MenuCommand(MenuCommand component)
        {
            return new MenuCommand.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public MenuCommand.Builder MenuCommand(MenuCommand.Config config)
        {
            return new MenuCommand.Builder(new MenuCommand(config));
        }
    }
}