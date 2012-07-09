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
    public partial class ComponentMenuItem
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public ComponentMenuItem(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit ComponentMenuItem.Config Conversion to ComponentMenuItem
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator ComponentMenuItem(ComponentMenuItem.Config config)
        {
            return new ComponentMenuItem(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : MenuItemBase.Config 
        { 
			/*  Implicit ComponentMenuItem.Config Conversion to ComponentMenuItem.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator ComponentMenuItem.Builder(ComponentMenuItem.Config config)
			{
				return new ComponentMenuItem.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			        
			private ItemsCollection<Component> component = null;

			/// <summary>
			/// 
			/// </summary>
			public ItemsCollection<Component> Component
			{
				get
				{
					if (this.component == null)
					{
						this.component = new ItemsCollection<Component>();
					}
			
					return this.component;
				}
			}
			
			private TargetElement componentElement = TargetElement.Auto;

			/// <summary>
			/// The element of component which will be used during menu item rendering
			/// </summary>
			[DefaultValue(TargetElement.Auto)]
			public virtual TargetElement ComponentElement 
			{ 
				get
				{
					return this.componentElement;
				}
				set
				{
					this.componentElement = value;
				}
			}

			private bool shift = true;

			/// <summary>
			/// If true then element will be shiffted on horizontal, the icon place will be visible
			/// </summary>
			[DefaultValue(true)]
			public virtual bool Shift 
			{ 
				get
				{
					return this.shift;
				}
				set
				{
					this.shift = value;
				}
			}

			private string target = "";

			/// <summary>
			/// The target element which will be placed to toolbar.
			/// </summary>
			[DefaultValue("")]
			public virtual string Target 
			{ 
				get
				{
					return this.target;
				}
				set
				{
					this.target = value;
				}
			}

			private bool hideOnClick = false;

			/// <summary>
			/// True to hide the containing menu after this item is clicked (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public override bool HideOnClick 
			{ 
				get
				{
					return this.hideOnClick;
				}
				set
				{
					this.hideOnClick = value;
				}
			}

        }
    }
}