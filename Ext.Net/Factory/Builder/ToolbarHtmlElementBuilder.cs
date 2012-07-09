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
    public partial class ToolbarHtmlElement
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : ToolbarItem.Builder<ToolbarHtmlElement, ToolbarHtmlElement.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ToolbarHtmlElement()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ToolbarHtmlElement component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ToolbarHtmlElement.Config config) : base(new ToolbarHtmlElement(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ToolbarHtmlElement component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The target element which will be placed to toolbar.
			/// </summary>
            public virtual ToolbarHtmlElement.Builder Target(string target)
            {
                this.ToComponent().Target = target;
                return this as ToolbarHtmlElement.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public ToolbarHtmlElement.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ToolbarHtmlElement(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public ToolbarHtmlElement.Builder ToolbarHtmlElement()
        {
            return this.ToolbarHtmlElement(new ToolbarHtmlElement());
        }

        /// <summary>
        /// 
        /// </summary>
        public ToolbarHtmlElement.Builder ToolbarHtmlElement(ToolbarHtmlElement component)
        {
            return new ToolbarHtmlElement.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ToolbarHtmlElement.Builder ToolbarHtmlElement(ToolbarHtmlElement.Config config)
        {
            return new ToolbarHtmlElement.Builder(new ToolbarHtmlElement(config));
        }
    }
}