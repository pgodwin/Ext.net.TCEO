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
using System.ComponentModel;
using System.Xml;

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class StoreRefreshDataEventArgs : EventArgs
    {
        private readonly XmlNode parameters;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public StoreRefreshDataEventArgs() { }

        internal StoreRefreshDataEventArgs(XmlNode parameters)
        {
            this.parameters = parameters;
        }

        private int total = -1;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public int Total
        {
           get
           {
               return total;
           }
            set
            {
                total = value;
            }
        }

        private ParameterCollection p;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ParameterCollection Parameters
        {
            get
            {
                if (p != null)
                {
                    return p;
                }

                if (this.parameters == null)
                {
                    return new ParameterCollection();
                }

                p = ResourceManager.XmlToParams(this.parameters);

                return p;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public int Start
        {
            get
            {
                if (this.Parameters["start"].IsNotEmpty())
                {
                    return int.Parse(this.Parameters["start"]);
                }

                return -1;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public int Limit
        {
            get
            {
                if (this.Parameters["limit"].IsNotEmpty())
                {
                    return int.Parse(this.Parameters["limit"]);
                }

                return -1;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Sort
        {
            get
            {
                if (this.Parameters["sort"].IsNotEmpty())
                {
                    return this.Parameters["sort"];
                }

                return "";
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public SortDirection Dir
        {
            get
            {
                if (this.Parameters["dir"].IsNotEmpty())
                {
                    return (SortDirection)Enum.Parse(typeof(SortDirection), this.Parameters["dir"], true);
                }

                return SortDirection.Default;
            }
        }
    }
}
