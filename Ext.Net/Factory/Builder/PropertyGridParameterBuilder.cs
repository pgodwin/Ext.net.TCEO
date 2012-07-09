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
    public partial class PropertyGridParameter
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : BaseParameter.Builder<PropertyGridParameter, PropertyGridParameter.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new PropertyGridParameter()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(PropertyGridParameter component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(PropertyGridParameter.Config config) : base(new PropertyGridParameter(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(PropertyGridParameter component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			// /// <summary>
			// /// (optional) The Ext.form.Field to use when editing values in this column if editing is supported by the grid.
			// /// </summary>
            // public virtual TBuilder Editor(EditorCollection editor)
            // {
            //    this.ToComponent().Editor = editor;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual PropertyGridParameter.Builder DisplayName(string displayName)
            {
                this.ToComponent().DisplayName = displayName;
                return this as PropertyGridParameter.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public PropertyGridParameter.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.PropertyGridParameter(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public PropertyGridParameter.Builder PropertyGridParameter()
        {
            return this.PropertyGridParameter(new PropertyGridParameter());
        }

        /// <summary>
        /// 
        /// </summary>
        public PropertyGridParameter.Builder PropertyGridParameter(PropertyGridParameter component)
        {
            return new PropertyGridParameter.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public PropertyGridParameter.Builder PropertyGridParameter(PropertyGridParameter.Config config)
        {
            return new PropertyGridParameter.Builder(new PropertyGridParameter(config));
        }
    }
}