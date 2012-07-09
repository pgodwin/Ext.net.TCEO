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
    public partial class JsonReader
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : DataReader.Builder<JsonReader, JsonReader.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new JsonReader()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(JsonReader component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(JsonReader.Config config) : base(new JsonReader(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(JsonReader component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// [id] Name of the property within a row object that contains a record identifier value. Defaults to id
			/// </summary>
            public virtual JsonReader.Builder IDProperty(string iDProperty)
            {
                this.ToComponent().IDProperty = iDProperty;
                return this as JsonReader.Builder;
            }
             
 			/// <summary>
			/// Name of the property which contains the Array of row objects.
			/// </summary>
            public virtual JsonReader.Builder Root(string root)
            {
                this.ToComponent().Root = root;
                return this as JsonReader.Builder;
            }
             
 			/// <summary>
			/// Name of the property from which to retrieve the success attribute used by forms.
			/// </summary>
            public virtual JsonReader.Builder SuccessProperty(string successProperty)
            {
                this.ToComponent().SuccessProperty = successProperty;
                return this as JsonReader.Builder;
            }
             
 			/// <summary>
			/// The DomQuery path from which to retrieve the total number of records in the dataset. This is only needed if the whole dataset is not passed in one go, but is being paged from the remote server.
			/// </summary>
            public virtual JsonReader.Builder TotalProperty(string totalProperty)
            {
                this.ToComponent().TotalProperty = totalProperty;
                return this as JsonReader.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public JsonReader.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.JsonReader(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public JsonReader.Builder JsonReader()
        {
            return this.JsonReader(new JsonReader());
        }

        /// <summary>
        /// 
        /// </summary>
        public JsonReader.Builder JsonReader(JsonReader component)
        {
            return new JsonReader.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public JsonReader.Builder JsonReader(JsonReader.Config config)
        {
            return new JsonReader.Builder(new JsonReader(config));
        }
    }
}