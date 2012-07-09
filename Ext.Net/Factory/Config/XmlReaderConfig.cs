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
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public XmlReader(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit XmlReader.Config Conversion to XmlReader
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator XmlReader(XmlReader.Config config)
        {
            return new XmlReader(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : DataReader.Config 
        { 
			/*  Implicit XmlReader.Config Conversion to XmlReader.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator XmlReader.Builder(XmlReader.Config config)
			{
				return new XmlReader.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string iDPath = "";

			/// <summary>
			/// The DomQuery path relative from the record element to the element that contains a record identifier value.
			/// </summary>
			[DefaultValue("")]
			public virtual string IDPath 
			{ 
				get
				{
					return this.iDPath;
				}
				set
				{
					this.iDPath = value;
				}
			}

			private string record = "";

			/// <summary>
			/// The DomQuery path to the repeated element which contains record information.
			/// </summary>
			[DefaultValue("")]
			public virtual string Record 
			{ 
				get
				{
					return this.record;
				}
				set
				{
					this.record = value;
				}
			}

			private string success = "";

			/// <summary>
			/// The DomQuery path to the success attribute used by forms.
			/// </summary>
			[DefaultValue("")]
			public virtual string Success 
			{ 
				get
				{
					return this.success;
				}
				set
				{
					this.success = value;
				}
			}

			private string totalProperty = "";

			/// <summary>
			/// The DomQuery path from which to retrieve the total number of records in the dataset. This is only needed if the whole dataset is not passed in one go, but is being paged from the remote server.
			/// </summary>
			[DefaultValue("")]
			public virtual string TotalProperty 
			{ 
				get
				{
					return this.totalProperty;
				}
				set
				{
					this.totalProperty = value;
				}
			}

        }
    }
}