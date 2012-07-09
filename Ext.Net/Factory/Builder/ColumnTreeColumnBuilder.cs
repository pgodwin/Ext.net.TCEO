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
    public partial class ColumnTreeColumn
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : StateManagedItem.Builder<ColumnTreeColumn, ColumnTreeColumn.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ColumnTreeColumn()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ColumnTreeColumn component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ColumnTreeColumn.Config config) : base(new ColumnTreeColumn(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ColumnTreeColumn component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual ColumnTreeColumn.Builder DataIndex(string dataIndex)
            {
                this.ToComponent().DataIndex = dataIndex;
                return this as ColumnTreeColumn.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual ColumnTreeColumn.Builder Header(string header)
            {
                this.ToComponent().Header = header;
                return this as ColumnTreeColumn.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual ColumnTreeColumn.Builder Cls(string cls)
            {
                this.ToComponent().Cls = cls;
                return this as ColumnTreeColumn.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual ColumnTreeColumn.Builder Width(int width)
            {
                this.ToComponent().Width = width;
                return this as ColumnTreeColumn.Builder;
            }
             
 			/// <summary>
			/// (optional) A function used to generate HTML markup for a node.
			/// </summary>
            public virtual ColumnTreeColumn.Builder Renderer(Renderer renderer)
            {
                this.ToComponent().Renderer = renderer;
                return this as ColumnTreeColumn.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public ColumnTreeColumn.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ColumnTreeColumn(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public ColumnTreeColumn.Builder ColumnTreeColumn()
        {
            return this.ColumnTreeColumn(new ColumnTreeColumn());
        }

        /// <summary>
        /// 
        /// </summary>
        public ColumnTreeColumn.Builder ColumnTreeColumn(ColumnTreeColumn component)
        {
            return new ColumnTreeColumn.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ColumnTreeColumn.Builder ColumnTreeColumn(ColumnTreeColumn.Config config)
        {
            return new ColumnTreeColumn.Builder(new ColumnTreeColumn(config));
        }
    }
}