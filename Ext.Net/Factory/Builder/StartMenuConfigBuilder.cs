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
    public partial class StartMenuConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : StateManagedItem.Builder<StartMenuConfig, StartMenuConfig.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new StartMenuConfig()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(StartMenuConfig component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(StartMenuConfig.Config config) : base(new StartMenuConfig(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(StartMenuConfig component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual StartMenuConfig.Builder Icon(Icon icon)
            {
                this.ToComponent().Icon = icon;
                return this as StartMenuConfig.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual StartMenuConfig.Builder IconCls(string iconCls)
            {
                this.ToComponent().IconCls = iconCls;
                return this as StartMenuConfig.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual StartMenuConfig.Builder Width(int width)
            {
                this.ToComponent().Width = width;
                return this as StartMenuConfig.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual StartMenuConfig.Builder ToolsWidth(int toolsWidth)
            {
                this.ToComponent().ToolsWidth = toolsWidth;
                return this as StartMenuConfig.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual StartMenuConfig.Builder Height(int height)
            {
                this.ToComponent().Height = height;
                return this as StartMenuConfig.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual StartMenuConfig.Builder Title(string title)
            {
                this.ToComponent().Title = title;
                return this as StartMenuConfig.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual StartMenuConfig.Builder Shadow(bool shadow)
            {
                this.ToComponent().Shadow = shadow;
                return this as StartMenuConfig.Builder;
            }
             
 			// /// <summary>
			// /// Collection of Tool items
			// /// </summary>
            // public virtual TBuilder ToolItems(ItemsCollection<Component> toolItems)
            // {
            //    this.ToComponent().ToolItems = toolItems;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// Items collection
			// /// </summary>
            // public virtual TBuilder Items(ItemsCollection<Component> items)
            // {
            //    this.ToComponent().Items = items;
            //    return this as TBuilder;
            // }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public StartMenuConfig.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.StartMenuConfig(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public StartMenuConfig.Builder StartMenuConfig()
        {
            return this.StartMenuConfig(new StartMenuConfig());
        }

        /// <summary>
        /// 
        /// </summary>
        public StartMenuConfig.Builder StartMenuConfig(StartMenuConfig component)
        {
            return new StartMenuConfig.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public StartMenuConfig.Builder StartMenuConfig(StartMenuConfig.Config config)
        {
            return new StartMenuConfig.Builder(new StartMenuConfig(config));
        }
    }
}