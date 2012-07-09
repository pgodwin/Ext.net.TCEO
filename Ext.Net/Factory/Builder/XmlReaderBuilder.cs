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
    public partial class XmlReader
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : DataReader.Builder<XmlReader, XmlReader.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new XmlReader()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(XmlReader component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(XmlReader.Config config) : base(new XmlReader(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(XmlReader component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The DomQuery path relative from the record element to the element that contains a record identifier value.
			/// </summary>
            public virtual XmlReader.Builder IDPath(string iDPath)
            {
                this.ToComponent().IDPath = iDPath;
                return this as XmlReader.Builder;
            }
             
 			/// <summary>
			/// The DomQuery path to the repeated element which contains record information.
			/// </summary>
            public virtual XmlReader.Builder Record(string record)
            {
                this.ToComponent().Record = record;
                return this as XmlReader.Builder;
            }
             
 			/// <summary>
			/// The DomQuery path to the success attribute used by forms.
			/// </summary>
            public virtual XmlReader.Builder Success(string success)
            {
                this.ToComponent().Success = success;
                return this as XmlReader.Builder;
            }
             
 			/// <summary>
			/// The DomQuery path from which to retrieve the total number of records in the dataset. This is only needed if the whole dataset is not passed in one go, but is being paged from the remote server.
			/// </summary>
            public virtual XmlReader.Builder TotalProperty(string totalProperty)
            {
                this.ToComponent().TotalProperty = totalProperty;
                return this as XmlReader.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public XmlReader.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.XmlReader(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public XmlReader.Builder XmlReader()
        {
            return this.XmlReader(new XmlReader());
        }

        /// <summary>
        /// 
        /// </summary>
        public XmlReader.Builder XmlReader(XmlReader component)
        {
            return new XmlReader.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public XmlReader.Builder XmlReader(XmlReader.Config config)
        {
            return new XmlReader.Builder(new XmlReader(config));
        }
    }
}