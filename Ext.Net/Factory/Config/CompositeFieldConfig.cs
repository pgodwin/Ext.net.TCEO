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
    public partial class CompositeField
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public CompositeField(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit CompositeField.Config Conversion to CompositeField
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator CompositeField(CompositeField.Config config)
        {
            return new CompositeField(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : Field.Config 
        { 
			/*  Implicit CompositeField.Config Conversion to CompositeField.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator CompositeField.Builder(CompositeField.Config config)
			{
				return new CompositeField.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool autoDoLayout = false;

			/// <summary>
			/// If true .doLayout() is called after render. Default is false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AutoDoLayout 
			{ 
				get
				{
					return this.autoDoLayout;
				}
				set
				{
					this.autoDoLayout = value;
				}
			}
        
			private JFunction buildLabel = null;

			/// <summary>
			/// Builds a label string from an array of subfield labels. Calls if CompositeField has no FieldLabel
			/// </summary>
			public JFunction BuildLabel
			{
				get
				{
					if (this.buildLabel == null)
					{
						this.buildLabel = new JFunction();
					}
			
					return this.buildLabel;
				}
			}
			        
			private ItemsCollection<Component> items = null;

			/// <summary>
			/// A Collection of Field Components.
			/// </summary>
			public ItemsCollection<Component> Items
			{
				get
				{
					if (this.items == null)
					{
						this.items = new ItemsCollection<Component>();
					}
			
					return this.items;
				}
			}
			
			private string defaultMargins = "0 5 0 0";

			/// <summary>
			/// The margins to apply by default to each field in the composite
			/// </summary>
			[DefaultValue("0 5 0 0")]
			public virtual string DefaultMargins 
			{ 
				get
				{
					return this.defaultMargins;
				}
				set
				{
					this.defaultMargins = value;
				}
			}

			private bool skipLastItemMargin = true;

			/// <summary>
			/// If true, the defaultMargins are not applied to the last item in the composite field set (defaults to true)
			/// </summary>
			[DefaultValue(true)]
			public virtual bool SkipLastItemMargin 
			{ 
				get
				{
					return this.skipLastItemMargin;
				}
				set
				{
					this.skipLastItemMargin = value;
				}
			}

			private bool combineErrors = true;

			/// <summary>
			/// True to combine errors from the individual fields into a single error message at the CompositeField level (defaults to true)
			/// </summary>
			[DefaultValue(true)]
			public virtual bool CombineErrors 
			{ 
				get
				{
					return this.combineErrors;
				}
				set
				{
					this.combineErrors = value;
				}
			}

			private string labelConnector = ", ";

			/// <summary>
			/// The string to use when joining segments of the built label together (defaults to ', ')
			/// </summary>
			[DefaultValue(", ")]
			public virtual string LabelConnector 
			{ 
				get
				{
					return this.labelConnector;
				}
				set
				{
					this.labelConnector = value;
				}
			}
        
			private ParameterCollection defaults = null;

			/// <summary>
			/// A config object that will be applied to all fields added to this CompositeField either via the items config. The defaults config can contain any number of name/value property pairs to be added to each items, and should be valid for the types of items being added to the CompositeField.
			/// </summary>
			public ParameterCollection Defaults
			{
				get
				{
					if (this.defaults == null)
					{
						this.defaults = new ParameterCollection();
					}
			
					return this.defaults;
				}
			}
			        
			private CompositeFieldListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public CompositeFieldListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new CompositeFieldListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private CompositeFieldDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public CompositeFieldDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new CompositeFieldDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}