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

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class TreeSubmitConfig : StateManagedItem
    {
        /// <summary>
        /// Serialize node with children
        /// </summary>
        [ConfigOption]
        [Category("2. TreeSubmitConfig")]
        [DefaultValue(false)]
        [Description("Serialize node with children")]
        public virtual bool WithChildren
        {
            get
            {
                object obj = this.ViewState["WithChildren"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["WithChildren"] = value;
            }
        }

        /// <summary>
        /// Disable automatic submit
        /// </summary>
        [ConfigOption]
        [Category("2. TreeSubmitConfig")]
        [DefaultValue(false)]
        [Description("Disable automatic submit")]
        public virtual bool DisableAutomaticSubmit
        {
            get
            {
                object obj = this.ViewState["DisableAutomaticSubmit"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["DisableAutomaticSubmit"] = value;
            }
        }

        /// <summary>
        /// True to encode node's text
        /// </summary>
        [ConfigOption]
        [Category("2. TreeSubmitConfig")]
        [DefaultValue(false)]
        [Description("True to encode node's text")]
        public virtual bool Encode
        {
            get
            {
                object obj = this.ViewState["Encode"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Encode"] = value;
            }
        }

        /// <summary>
        /// The attr to use for the path (defaults to the node's id)
        /// </summary>
        [ConfigOption]
        [Category("3. TreeSubmitConfig")]
        [DefaultValue("id")]
        [NotifyParentProperty(true)]
        [Description("The attr to use for the path (defaults to the node's id)")]
        public virtual string PathAttribute
        {
            get
            {
                return (string)this.ViewState["PathAttribute"] ?? "id";
            }
            set
            {
                this.ViewState["PathAttribute"] = value;
            }
        }

        private JFunction nodeFilter;

        /// <summary>
        /// Node filter functon, return false to exclude the node
        /// Parameters:
        ///    node - filter node
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("3. TreeSubmitConfig")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Node filter functon, return false to exclude the node")]
        public virtual JFunction NodeFilter
        {
            get
            {
                if (this.nodeFilter == null)
                {
                    this.nodeFilter = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.nodeFilter.Args = new string[] {"node"};
                    }
                }

                return this.nodeFilter;
            }
        }

        private JFunction attributeFilter;

        /// <summary>
        /// Attribute filter functon, return false to exclude the attribute
        /// Parameters:
        ///    attrName - attribute's name
        ///    attrValue - attribute's value
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("3. TreeSubmitConfig")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Attribute filter functon, return false to exclude the attribute")]
        public virtual JFunction AttributeFilter
        {
            get
            {
                if (this.attributeFilter == null)
                {
                    this.attributeFilter = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.attributeFilter.Args = new string[] {"attrName", "attrValue"};
                    }
                }

                return this.attributeFilter;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public override bool IsDefault
        {
            get
            {
                return (this.PathAttribute.IsEmpty() || this.PathAttribute == "id") && 
                        !this.WithChildren &&
                        !this.DisableAutomaticSubmit &&
                        this.NodeFilter.IsDefault &&
                        AttributeFilter.IsDefault;
            }
        }
    }
}