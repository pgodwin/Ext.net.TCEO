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
    public partial class TextArea
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : TextFieldBase.Builder<TextArea, TextArea.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new TextArea()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TextArea component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TextArea.Config config) : base(new TextArea(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(TextArea component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The maximum width to allow when grow = true (defaults to 800).
			/// </summary>
            public virtual TextArea.Builder GrowMax(Unit growMax)
            {
                this.ToComponent().GrowMax = growMax;
                return this as TextArea.Builder;
            }
             
 			/// <summary>
			/// The minimum width to allow when grow = true (defaults to 60).
			/// </summary>
            public virtual TextArea.Builder GrowMin(Unit growMin)
            {
                this.ToComponent().GrowMin = growMin;
                return this as TextArea.Builder;
            }
             
 			/// <summary>
			/// True to prevent scrollbars from appearing regardless of how much text is in the field (equivalent to setting overflow: hidden, defaults to false).
			/// </summary>
            public virtual TextArea.Builder PreventScrollbars(bool preventScrollbars)
            {
                this.ToComponent().PreventScrollbars = preventScrollbars;
                return this as TextArea.Builder;
            }
             
 			// /// <summary>
			// /// Client-side JavaScript Event Handlers
			// /// </summary>
            // public virtual TBuilder Listeners(TextFieldListeners listeners)
            // {
            //    this.ToComponent().Listeners = listeners;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// Server-side Ajax Event Handlers
			// /// </summary>
            // public virtual TBuilder DirectEvents(TextFieldDirectEvents directEvents)
            // {
            //    this.ToComponent().DirectEvents = directEvents;
            //    return this as TBuilder;
            // }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public TextArea.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.TextArea(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public TextArea.Builder TextArea()
        {
            return this.TextArea(new TextArea());
        }

        /// <summary>
        /// 
        /// </summary>
        public TextArea.Builder TextArea(TextArea component)
        {
            return new TextArea.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public TextArea.Builder TextArea(TextArea.Config config)
        {
            return new TextArea.Builder(new TextArea(config));
        }
    }
}