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
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public partial class ColumnTreeColumn : StateManagedItem
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ColumnTreeColumn() { }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("1. ColumnTreeColumn")]
        [DefaultValue(null)]
        [Description("")]
        public virtual string DataIndex
        {
            get
            {
                object obj = this.ViewState["DataIndex"];
                return (obj == null) ? null : (string)obj;
            }
            set
            {
                this.ViewState["DataIndex"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("1. ColumnTreeColumn")]
        [DefaultValue("")]
        [Description("")]
        public virtual string Header
        {
            get
            {
                object obj = this.ViewState["Header"];
                return (obj == null) ? "" : (string)obj;
            }
            set
            {
                this.ViewState["Header"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("1. ColumnTreeColumn")]
        [DefaultValue("")]
        [Description("")]
        public virtual string Cls
        {
            get
            {
                object obj = this.ViewState["Cls"];
                return (obj == null) ? "" : (string)obj;
            }
            set
            {
                this.ViewState["Cls"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("1. ColumnTreeColumn")]
        [DefaultValue(0)]
        [Description("")]
        public virtual int Width
        {
            get
            {
                object obj = this.ViewState["Width"];
                return (obj == null) ? 0 : (int)obj;
            }
            set
            {
                this.ViewState["Width"] = value;
            }
        }

        private Renderer renderer;

        /// <summary>
        /// (optional) A function used to generate HTML markup for a node
        /// </summary>
        [Meta]
        [ConfigOption(typeof(RendererJsonConverter))]
        [Category("2. ColumnBase")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ViewStateMember]
        [Description("(optional) A function used to generate HTML markup for a node.")]
        public virtual Renderer Renderer
        {
            get
            {
                if (this.renderer == null)
                {
                    this.renderer = new Renderer();
                    if (!this.DesignMode)
                    {
                        this.renderer.Args = new string[] {"value", "node", "attrs"};
                    }
                }

                return this.renderer;
            }
            set
            {
                this.renderer = value;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class ColumnTreeColumnCollection : StateManagedCollection<ColumnTreeColumn> { }
}