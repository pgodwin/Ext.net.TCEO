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
    public partial class GenericPlugin
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : Plugin.Builder<GenericPlugin, GenericPlugin.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new GenericPlugin()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(GenericPlugin component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(GenericPlugin.Config config) : base(new GenericPlugin(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(GenericPlugin component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The JavaScript class name. Used to create a 'new' instance of the object.
			/// </summary>
            public virtual GenericPlugin.Builder InstanceName(string instanceName)
            {
                this.ToComponent().InstanceName = instanceName;
                return this as GenericPlugin.Builder;
            }
             
 			/// <summary>
			/// The file path to the required JavaScript file.
			/// </summary>
            public virtual GenericPlugin.Builder Path(string path)
            {
                this.ToComponent().Path = path;
                return this as GenericPlugin.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public GenericPlugin.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.GenericPlugin(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public GenericPlugin.Builder GenericPlugin()
        {
            return this.GenericPlugin(new GenericPlugin());
        }

        /// <summary>
        /// 
        /// </summary>
        public GenericPlugin.Builder GenericPlugin(GenericPlugin component)
        {
            return new GenericPlugin.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public GenericPlugin.Builder GenericPlugin(GenericPlugin.Config config)
        {
            return new GenericPlugin.Builder(new GenericPlugin(config));
        }
    }
}