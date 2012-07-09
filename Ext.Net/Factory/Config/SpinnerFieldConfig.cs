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
    public partial class SpinnerField
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public SpinnerField(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit SpinnerField.Config Conversion to SpinnerField
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator SpinnerField(SpinnerField.Config config)
        {
            return new SpinnerField(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : NumberFieldBase.Config 
        { 
			/*  Implicit SpinnerField.Config Conversion to SpinnerField.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator SpinnerField.Builder(SpinnerField.Config config)
			{
				return new SpinnerField.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool deferHeight = true;

			/// <summary>
			/// Increment Value
			/// </summary>
			[DefaultValue(true)]
			public virtual bool DeferHeight 
			{ 
				get
				{
					return this.deferHeight;
				}
				set
				{
					this.deferHeight = value;
				}
			}

			private double incrementValue = 1.0;

			/// <summary>
			/// Increment Value
			/// </summary>
			[DefaultValue(1.0)]
			public virtual double IncrementValue 
			{ 
				get
				{
					return this.incrementValue;
				}
				set
				{
					this.incrementValue = value;
				}
			}

			private double alternateIncrementValue = 5.0;

			/// <summary>
			/// Alerternate Increment Value
			/// </summary>
			[DefaultValue(5.0)]
			public virtual double AlternateIncrementValue 
			{ 
				get
				{
					return this.alternateIncrementValue;
				}
				set
				{
					this.alternateIncrementValue = value;
				}
			}

			private string triggerClass = "x-form-spinner-trigger";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("x-form-spinner-trigger")]
			public virtual string TriggerClass 
			{ 
				get
				{
					return this.triggerClass;
				}
				set
				{
					this.triggerClass = value;
				}
			}

			private string splitterClass = "x-form-spinner-splitter";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("x-form-spinner-splitter")]
			public virtual string SplitterClass 
			{ 
				get
				{
					return this.splitterClass;
				}
				set
				{
					this.splitterClass = value;
				}
			}

			private double defaultValue = 0.0;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(0.0)]
			public virtual double DefaultValue 
			{ 
				get
				{
					return this.defaultValue;
				}
				set
				{
					this.defaultValue = value;
				}
			}

			private bool accelerate = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Accelerate 
			{ 
				get
				{
					return this.accelerate;
				}
				set
				{
					this.accelerate = value;
				}
			}
        
			private SpinnerFieldListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public SpinnerFieldListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new SpinnerFieldListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private SpinnerFieldDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public SpinnerFieldDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new SpinnerFieldDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}