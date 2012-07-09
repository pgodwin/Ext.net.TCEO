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
    public partial class HeaderRow
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : StateManagedItem.Builder<HeaderRow, HeaderRow.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new HeaderRow()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(HeaderRow component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(HeaderRow.Config config) : base(new HeaderRow(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(HeaderRow component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			// /// <summary>
			// /// 
			// /// </summary>
            // public virtual TBuilder Columns(HeaderColumnCollection columns)
            // {
            //    this.ToComponent().Columns = columns;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual HeaderRow.Builder Cls(string cls)
            {
                this.ToComponent().Cls = cls;
                return this as HeaderRow.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public HeaderRow.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.HeaderRow(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public HeaderRow.Builder HeaderRow()
        {
            return this.HeaderRow(new HeaderRow());
        }

        /// <summary>
        /// 
        /// </summary>
        public HeaderRow.Builder HeaderRow(HeaderRow component)
        {
            return new HeaderRow.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public HeaderRow.Builder HeaderRow(HeaderRow.Config config)
        {
            return new HeaderRow.Builder(new HeaderRow(config));
        }
    }
}