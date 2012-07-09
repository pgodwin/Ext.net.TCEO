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
    public partial class HeaderColumn
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : StateManagedItem.Builder<HeaderColumn, HeaderColumn.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new HeaderColumn()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(HeaderColumn component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(HeaderColumn.Config config) : base(new HeaderColumn(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(HeaderColumn component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The target element which will be placed to the header.
			/// </summary>
            public virtual HeaderColumn.Builder Target(string target)
            {
                this.ToComponent().Target = target;
                return this as HeaderColumn.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual HeaderColumn.Builder AutoWidthElement(bool autoWidthElement)
            {
                this.ToComponent().AutoWidthElement = autoWidthElement;
                return this as HeaderColumn.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual HeaderColumn.Builder AutoWidthCorrection(int autoWidthCorrection)
            {
                this.ToComponent().AutoWidthCorrection = autoWidthCorrection;
                return this as HeaderColumn.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual HeaderColumn.Builder Cls(string cls)
            {
                this.ToComponent().Cls = cls;
                return this as HeaderColumn.Builder;
            }
             
 			// /// <summary>
			// /// 
			// /// </summary>
            // public virtual TBuilder Component(ItemsCollection<Component> component)
            // {
            //    this.ToComponent().Component = component;
            //    return this as TBuilder;
            // }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public HeaderColumn.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.HeaderColumn(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public HeaderColumn.Builder HeaderColumn()
        {
            return this.HeaderColumn(new HeaderColumn());
        }

        /// <summary>
        /// 
        /// </summary>
        public HeaderColumn.Builder HeaderColumn(HeaderColumn component)
        {
            return new HeaderColumn.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public HeaderColumn.Builder HeaderColumn(HeaderColumn.Config config)
        {
            return new HeaderColumn.Builder(new HeaderColumn(config));
        }
    }
}