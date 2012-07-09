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
    public partial class RadioGroup
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public RadioGroup(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit RadioGroup.Config Conversion to RadioGroup
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator RadioGroup(RadioGroup.Config config)
        {
            return new RadioGroup(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : CheckboxGroupBase.Config 
        { 
			/*  Implicit RadioGroup.Config Conversion to RadioGroup.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator RadioGroup.Builder(RadioGroup.Config config)
			{
				return new RadioGroup.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string defaultType = "Radio";

			/// <summary>
			/// The default type of content Container represented by this object as registered in Ext.ComponentMgr (defaults to 'radio').
			/// </summary>
			[DefaultValue("Radio")]
			public virtual string DefaultType 
			{ 
				get
				{
					return this.defaultType;
				}
				set
				{
					this.defaultType = value;
				}
			}
        
			private RadioGroupListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public RadioGroupListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new RadioGroupListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private RadioGroupDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public RadioGroupDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new RadioGroupDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			        
			private ItemsCollection<Radio> items = null;

			/// <summary>
			/// Items collection
			/// </summary>
			public ItemsCollection<Radio> Items
			{
				get
				{
					if (this.items == null)
					{
						this.items = new ItemsCollection<Radio>();
					}
			
					return this.items;
				}
			}
			
			private bool automaticGrouping = true;

			/// <summary>
			/// Automatic grouping (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AutomaticGrouping 
			{ 
				get
				{
					return this.automaticGrouping;
				}
				set
				{
					this.automaticGrouping = value;
				}
			}

			private string groupName = "";

			/// <summary>
			/// The field's HTML name attribute.
			/// </summary>
			[DefaultValue("")]
			public virtual string GroupName 
			{ 
				get
				{
					return this.groupName;
				}
				set
				{
					this.groupName = value;
				}
			}

        }
    }
}