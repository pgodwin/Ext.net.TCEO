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
    public partial class FormLayout
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : AnchorLayout.Builder<FormLayout, FormLayout.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new FormLayout()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(FormLayout component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(FormLayout.Config config) : base(new FormLayout(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(FormLayout component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True to hide field labels by default (defaults to false).
			/// </summary>
            public virtual FormLayout.Builder HideLabels(bool hideLabels)
            {
                this.ToComponent().HideLabels = hideLabels;
                return this as FormLayout.Builder;
            }
             
 			/// <summary>
			/// A CSS class to add to the div wrapper that contains each field label and field element (the default class is 'x-form-item' and itemCls will be added to that)
			/// </summary>
            public virtual FormLayout.Builder ItemCls(string itemCls)
            {
                this.ToComponent().ItemCls = itemCls;
                return this as FormLayout.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public FormLayout.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.FormLayout(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public FormLayout.Builder FormLayout()
        {
            return this.FormLayout(new FormLayout());
        }

        /// <summary>
        /// 
        /// </summary>
        public FormLayout.Builder FormLayout(FormLayout component)
        {
            return new FormLayout.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public FormLayout.Builder FormLayout(FormLayout.Config config)
        {
            return new FormLayout.Builder(new FormLayout(config));
        }
    }
}