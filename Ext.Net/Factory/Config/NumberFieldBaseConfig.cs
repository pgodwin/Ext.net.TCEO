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
    public abstract partial class NumberFieldBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : TextFieldBase.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			        
			private object emptyValue = null;

			/// <summary>
			/// The fields null value.
			/// </summary>
			public object EmptyValue
			{
				get
				{
					if (this.emptyValue == null)
					{
						this.emptyValue = new object();
					}
			
					return this.emptyValue;
				}
			}
			
			private InputType inputType = InputType.Text;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(InputType.Text)]
			public override InputType InputType 
			{ 
				get
				{
					return this.inputType;
				}
				set
				{
					this.inputType = value;
				}
			}

			private string text = "";

			/// <summary>
			/// The Text value to initialize this field with.
			/// </summary>
			[DefaultValue("")]
			public override string Text 
			{ 
				get
				{
					return this.text;
				}
				set
				{
					this.text = value;
				}
			}

			private double number = double.MinValue;

			/// <summary>
			/// The Number (double) to initialize this field with.
			/// </summary>
			[DefaultValue(double.MinValue)]
			public virtual double Number 
			{ 
				get
				{
					return this.number;
				}
				set
				{
					this.number = value;
				}
			}

			private bool allowDecimals = true;

			/// <summary>
			/// False to disallow decimal values (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AllowDecimals 
			{ 
				get
				{
					return this.allowDecimals;
				}
				set
				{
					this.allowDecimals = value;
				}
			}

			private bool trimTrailedZeros = true;

			/// <summary>
			/// False to disallow trim trailed zeros.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool TrimTrailedZeros 
			{ 
				get
				{
					return this.trimTrailedZeros;
				}
				set
				{
					this.trimTrailedZeros = value;
				}
			}

			private bool allowNegative = true;

			/// <summary>
			/// False to prevent entering a negative sign (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AllowNegative 
			{ 
				get
				{
					return this.allowNegative;
				}
				set
				{
					this.allowNegative = value;
				}
			}

			private string baseChars = "0123456789";

			/// <summary>
			/// The base set of characters to evaluate as valid numbers (defaults to '0123456789').
			/// </summary>
			[DefaultValue("0123456789")]
			public virtual string BaseChars 
			{ 
				get
				{
					return this.baseChars;
				}
				set
				{
					this.baseChars = value;
				}
			}

			private int decimalPrecision = 2;

			/// <summary>
			/// The maximum precision to display after the decimal separator (defaults to 2).
			/// </summary>
			[DefaultValue(2)]
			public virtual int DecimalPrecision 
			{ 
				get
				{
					return this.decimalPrecision;
				}
				set
				{
					this.decimalPrecision = value;
				}
			}

			private string decimalSeparator = ".";

			/// <summary>
			/// Character(s) to allow as the decimal separator (defaults to '.').
			/// </summary>
			[DefaultValue(".")]
			public virtual string DecimalSeparator 
			{ 
				get
				{
					return this.decimalSeparator;
				}
				set
				{
					this.decimalSeparator = value;
				}
			}

			private string maxText = "The maximum value for this field is {maxValue}";

			/// <summary>
			/// Error text to display if the maximum value validation fails (defaults to 'The maximum value for this field is {maxValue}').
			/// </summary>
			[DefaultValue("The maximum value for this field is {maxValue}")]
			public virtual string MaxText 
			{ 
				get
				{
					return this.maxText;
				}
				set
				{
					this.maxText = value;
				}
			}

			private Double maxValue = Double.MaxValue;

			/// <summary>
			/// The maximum allowed value (defaults to Double.MaxValue)
			/// </summary>
			[DefaultValue(Double.MaxValue)]
			public virtual Double MaxValue 
			{ 
				get
				{
					return this.maxValue;
				}
				set
				{
					this.maxValue = value;
				}
			}

			private string minText = "The minimum value for this field is {minValue}";

			/// <summary>
			/// Error text to display if the minimum value validation fails (defaults to 'The minimum value for this field is {minValue}').
			/// </summary>
			[DefaultValue("The minimum value for this field is {minValue}")]
			public virtual string MinText 
			{ 
				get
				{
					return this.minText;
				}
				set
				{
					this.minText = value;
				}
			}

			private Double minValue = Double.MinValue;

			/// <summary>
			/// The minimum allowed value (defaults to Double.MinValue)
			/// </summary>
			[DefaultValue(Double.MinValue)]
			public virtual Double MinValue 
			{ 
				get
				{
					return this.minValue;
				}
				set
				{
					this.minValue = value;
				}
			}

			private string nanText = "{value} is not a valid number";

			/// <summary>
			/// Error text to display if the value is not a valid number. For example, this can happen if a valid character like '.' or '-' is left in the field with no number (defaults to '{value} is not a valid number').
			/// </summary>
			[DefaultValue("{value} is not a valid number")]
			public virtual string NanText 
			{ 
				get
				{
					return this.nanText;
				}
				set
				{
					this.nanText = value;
				}
			}

        }
    }
}