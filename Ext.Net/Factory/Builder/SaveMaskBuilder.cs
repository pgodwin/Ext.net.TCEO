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
    public partial class SaveMask
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : LoadMask.Builder<SaveMask, SaveMask.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new SaveMask()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(SaveMask component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(SaveMask.Config config) : base(new SaveMask(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(SaveMask component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The text to display in a centered saving message box (defaults to 'Saving...').
			/// </summary>
            public virtual SaveMask.Builder Msg(string msg)
            {
                this.ToComponent().Msg = msg;
                return this as SaveMask.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public SaveMask.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.SaveMask(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public SaveMask.Builder SaveMask()
        {
            return this.SaveMask(new SaveMask());
        }

        /// <summary>
        /// 
        /// </summary>
        public SaveMask.Builder SaveMask(SaveMask component)
        {
            return new SaveMask.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public SaveMask.Builder SaveMask(SaveMask.Config config)
        {
            return new SaveMask.Builder(new SaveMask(config));
        }
    }
}