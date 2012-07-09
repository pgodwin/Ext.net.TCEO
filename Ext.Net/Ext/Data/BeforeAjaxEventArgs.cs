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

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class BeforeDirectEventArgs : EventArgs
    {
        private readonly string action;
        private readonly string data;
        private readonly XmlNode parameters;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public BeforeDirectEventArgs() { }

        internal BeforeDirectEventArgs(string action, string data, XmlNode parameters)
        {
            this.action = action;
            this.data = data;
            this.parameters = parameters;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Action
        {
            get { return action; }
        }

        private StoreDataHandler dataHandler;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public StoreDataHandler Data
        {
            get
            {
                if (dataHandler == null)
                {
                    dataHandler = new StoreDataHandler(data);
                }

                return dataHandler;
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

                p = new ParameterCollection();

                if (this.parameters == null)
                {
                    return p;
                }

                p = ResourceManager.XmlToParams(this.parameters);

                //foreach (XmlNode param in this.parameters.ChildNodes)
                //{
                //    p.Add(new Parameter(param.Name, param.InnerXml));
                //}

                return p;
            }
        }
    }
}