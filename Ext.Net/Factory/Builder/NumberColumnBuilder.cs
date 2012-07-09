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
    public partial class NumberColumn
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : Column.Builder<NumberColumn, NumberColumn.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new NumberColumn()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(NumberColumn component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(NumberColumn.Config config) : base(new NumberColumn(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(NumberColumn component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// A formatting string as used by Ext.util.Format.number to format a numeric value for this Column (defaults to '0,000.00').
			/// </summary>
            public virtual NumberColumn.Builder Format(string format)
            {
                this.ToComponent().Format = format;
                return this as NumberColumn.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public NumberColumn.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.NumberColumn(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public NumberColumn.Builder NumberColumn()
        {
            return this.NumberColumn(new NumberColumn());
        }

        /// <summary>
        /// 
        /// </summary>
        public NumberColumn.Builder NumberColumn(NumberColumn component)
        {
            return new NumberColumn.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public NumberColumn.Builder NumberColumn(NumberColumn.Config config)
        {
            return new NumberColumn.Builder(new NumberColumn(config));
        }
    }
}