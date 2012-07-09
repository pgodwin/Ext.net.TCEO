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

using System.ComponentModel;
using System.Web;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public abstract partial class Node : StateManagedItem
    {
        private static readonly object idCounter = new object();
            
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected Node() { }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public int GetID()
        {
            lock (idCounter)
            {
                object obj = HttpContext.Current.Items["_uniqueTreeNodeID"];
                int id = 0;

                if (obj != null)
                {
                    id = (int)obj;
                    id++;
                }

                HttpContext.Current.Items["_uniqueTreeNodeID"] = id;

                return id;
            }
        }

        private readonly string autoID="";

        /// <summary>
        /// The id for this node. If one is not specified, one is generated.
        /// </summary>
        [ConfigOption("id")]
        [Category("2. Node")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The id for this node. If one is not specified, one is generated.")]
        public virtual string NodeID
        {
            get
            {
                return (string)this.ViewState["NodeID"] ?? this.autoID;
            }
            set 
            { 
                this.ViewState["NodeID"] = value; 
            }
        }

        /// <summary>
        /// True if this node is a leaf and does not have children
        /// </summary>
        [ConfigOption]
        [Category("2. Node")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True if this node is a leaf and does not have children")]
        public virtual bool Leaf
        {
            get
            {
                object obj = this.ViewState["Leaf"];
                return (obj == null) ? false : (bool) obj;
            }
            set 
            { 
                this.ViewState["Leaf"] = value; 
            }
        }
    }
}