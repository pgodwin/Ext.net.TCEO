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
    public partial class Anchor
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : LayoutItem.Builder<Anchor, Anchor.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new Anchor()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Anchor component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Anchor.Config config) : base(new Anchor(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(Anchor component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True if component should be rendered as a Form Field with a Field Label and Label separator (defaults to false).
			/// </summary>
            public virtual Anchor.Builder IsFormField(bool isFormField)
            {
                this.ToComponent().IsFormField = isFormField;
                return this as Anchor.Builder;
            }
             
 			/// <summary>
			/// Horizontal Anchor value. Can be a Percentage (1-100%), an Offset (Any positive or negative integer value), a Sides value (Valid values are 'right' (or 'r') and 'bottom' (or 'b').).
			/// </summary>
            public virtual Anchor.Builder Horizontal(string horizontal)
            {
                this.ToComponent().Horizontal = horizontal;
                return this as Anchor.Builder;
            }
             
 			/// <summary>
			/// Vertical Anchor value. Can be a Percentage (1-100%), an Offset (Any positive or negative integer value), a Sides value (Valid values are 'right' (or 'r') and 'bottom' (or 'b').).
			/// </summary>
            public virtual Anchor.Builder Vertical(string vertical)
            {
                this.ToComponent().Vertical = vertical;
                return this as Anchor.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public Anchor.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.Anchor(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public Anchor.Builder Anchor()
        {
            return this.Anchor(new Anchor());
        }

        /// <summary>
        /// 
        /// </summary>
        public Anchor.Builder Anchor(Anchor component)
        {
            return new Anchor.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public Anchor.Builder Anchor(Anchor.Config config)
        {
            return new Anchor.Builder(new Anchor(config));
        }
    }
}