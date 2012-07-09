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
    public partial class RecordField
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public RecordField(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit RecordField.Config Conversion to RecordField
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator RecordField(RecordField.Config config)
        {
            return new RecordField(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : StateManagedItem.Config 
        { 
			/*  Implicit RecordField.Config Conversion to RecordField.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator RecordField.Builder(RecordField.Config config)
			{
				return new RecordField.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool allowBlank = true;

			/// <summary>
			/// Used for validating a record, defaults to true. An empty value here will cause Ext.data.Record.isValid to evaluate to false.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AllowBlank 
			{ 
				get
				{
					return this.allowBlank;
				}
				set
				{
					this.allowBlank = value;
				}
			}

			private string name = "";

			/// <summary>
			/// The name by which the field is referenced within the Record. This is referenced by, for example the DataIndex property in column definition objects passed to ColumnModel
			/// </summary>
			[DefaultValue("")]
			public virtual string Name 
			{ 
				get
				{
					return this.name;
				}
				set
				{
					this.name = value;
				}
			}

			private string mapping = "";

			/// <summary>
			/// (Optional) A path specification for use by the Reader implementation that is creating the Record to access the data value from the data object. If an JsonReader is being used, then this is a string containing the javascript expression to reference the data relative to the Record item's root. If an XmlReader is being used, this is an Ext.DomQuery path to the data item relative to the Record element. If the mapping expression is the same as the field name, this may be omitted.
			/// </summary>
			[DefaultValue("")]
			public virtual string Mapping 
			{ 
				get
				{
					return this.mapping;
				}
				set
				{
					this.mapping = value;
				}
			}

			private string serverMapping = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string ServerMapping 
			{ 
				get
				{
					return this.serverMapping;
				}
				set
				{
					this.serverMapping = value;
				}
			}

			private RecordFieldType type = RecordFieldType.Auto;

			/// <summary>
			/// The data type for conversion to displayable value
			/// </summary>
			[DefaultValue(RecordFieldType.Auto)]
			public virtual RecordFieldType Type 
			{ 
				get
				{
					return this.type;
				}
				set
				{
					this.type = value;
				}
			}

			private SortTypeMethod sortType = SortTypeMethod.None;

			/// <summary>
			/// Sort method
			/// </summary>
			[DefaultValue(SortTypeMethod.None)]
			public virtual SortTypeMethod SortType 
			{ 
				get
				{
					return this.sortType;
				}
				set
				{
					this.sortType = value;
				}
			}

			private SortDirection sortDir = SortDirection.Default;

			/// <summary>
			/// (Optional) Initial direction to sort
			/// </summary>
			[DefaultValue(SortDirection.Default)]
			public virtual SortDirection SortDir 
			{ 
				get
				{
					return this.sortDir;
				}
				set
				{
					this.sortDir = value;
				}
			}

			private EmptyValue submitEmptyValue = EmptyValue.Undefined;

			/// <summary>
			/// Empty value representation during submit (default value as Undedefined)
			/// </summary>
			[DefaultValue(EmptyValue.Undefined)]
			public virtual EmptyValue SubmitEmptyValue 
			{ 
				get
				{
					return this.submitEmptyValue;
				}
				set
				{
					this.submitEmptyValue = value;
				}
			}
        
			private JFunction customSortType = null;

			/// <summary>
			/// A function which converts a Field's value to a comparable value in order to ensure correct sort ordering.
			/// </summary>
			public JFunction CustomSortType
			{
				get
				{
					if (this.customSortType == null)
					{
						this.customSortType = new JFunction();
					}
			
					return this.customSortType;
				}
			}
			        
			private JFunction convert = null;

			/// <summary>
			/// (Optional) A function which converts the value provided by the Reader into an object that will be stored in the Record.
			/// </summary>
			public JFunction Convert
			{
				get
				{
					if (this.convert == null)
					{
						this.convert = new JFunction();
					}
			
					return this.convert;
				}
			}
			
			private string dateFormat = "";

			/// <summary>
			/// (Optional) A format String for the Date.parseDate function
			/// </summary>
			[DefaultValue("")]
			public virtual string DateFormat 
			{ 
				get
				{
					return this.dateFormat;
				}
				set
				{
					this.dateFormat = value;
				}
			}

			private string defaultValue = "";

			/// <summary>
			/// (Optional) The default value passed to the Reader when the field does not exist in the data object
			/// </summary>
			[DefaultValue("")]
			public virtual string DefaultValue 
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

			private bool isComplex = false;

			/// <summary>
			/// True to render this property as complex object
			/// </summary>
			[DefaultValue(false)]
			public virtual bool IsComplex 
			{ 
				get
				{
					return this.isComplex;
				}
				set
				{
					this.isComplex = value;
				}
			}

			private bool useNull = false;

			/// <summary>
			/// (Optional) Use when converting received data into a Number type (either int or float). If the value cannot be parsed, null will be used if useNull is true, otherwise the value will be 0. Defaults to false
			/// </summary>
			[DefaultValue(false)]
			public virtual bool UseNull 
			{ 
				get
				{
					return this.useNull;
				}
				set
				{
					this.useNull = value;
				}
			}

        }
    }
}