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
    public abstract partial class TreeLoaderBase : StateManagedItem
    {
        private ParameterCollection baseAttrs;

        /// <summary>
        /// (optional) An object containing attributes to be added to all nodes created by this loader. If the attributes sent by the server have an attribute in this object, they take priority.
        /// </summary>
        [ConfigOption("baseAttrs", JsonMode.ArrayToObject)]
        [Category("2. TreeLoader")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ViewStateMember]
        [Description("(optional) An object containing attributes to be added to all nodes created by this loader. If the attributes sent by the server have an attribute in this object, they take priority.")]
        public virtual ParameterCollection BaseAttributes
        {
            get
            {
                if (this.baseAttrs == null)
                {
                    this.baseAttrs = new ParameterCollection();
                    this.baseAttrs.Owner = this.Owner;
                }

                return this.baseAttrs;
            }
        }

        private ParameterCollection baseParams;

        /// <summary>
        /// (optional) An object containing properties which specify HTTP parameters to be passed to each request for child nodes.
        /// </summary>
        [Category("2. TreeLoader")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ViewStateMember]
        [Description("(optional) An object containing properties which specify HTTP parameters to be passed to each request for child nodes.")]
        public virtual ParameterCollection BaseParams
        {
            get
            {
                if (this.baseParams == null)
                {
                    this.baseParams = new ParameterCollection();
                    this.baseParams.Owner = this.Owner;
                }

                return this.baseParams;
            }
        }

        /// <summary>
        /// Send params as JSON object
        /// </summary>
        [ConfigOption]
        [Category("2. TreeLoader")]
        [DefaultValue(false)]
        [Description("Send params as JSON object")]
        public virtual bool Json
        {
            get
            {
                object obj = this.ViewState["Json"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Json"] = value;
            }
        }


        /// <summary>
        /// (optional) Default to true. Remove previously existing child nodes before loading.
        /// </summary>
        [ConfigOption]
        [Category("2. TreeLoader")]
        [DefaultValue(true)]
        [Description("(optional) Default to true. Remove previously existing child nodes before loading.")]
        public virtual bool ClearOnLoad
        {
            get
            {
                object obj = this.ViewState["ClearOnLoad"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["ClearOnLoad"] = value;
            }
        }

        /// <summary>
        /// The URL from which to request a Json string which specifies an array of node definition objects representing the child nodes to be loaded.
        /// </summary>
        [Category("2. TreeLoader")]
        [DefaultValue("")]
        [Description("The URL from which to request a Json string which specifies an array of node definition objects representing the child nodes to be loaded.")]
        public virtual string DataUrl
        {
            get
            {
                return (string)this.ViewState["DataUrl"] ?? "";
            }
            set
            {
                this.ViewState["DataUrl"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("url")]
        [DefaultValue("")]
        [Description("")]
        protected string UrlProxy
        {
            get
            {
                if (this.DataUrl.IsEmpty())
                {
                    return "";
                }

                Control c = this.Owner;

                if (c == null)
                {
                    c = this.ResourceManager;
                }

                return c != null ? c.ResolveUrl(this.DataUrl) : this.DataUrl;
            }
        }

        /// <summary>
        /// If set to true, the loader recursively loads 'children' attributes when doing the first load on nodes.
        /// </summary>
        [ConfigOption]
        [Category("2. TreeLoader")]
        [DefaultValue(false)]
        [Description("If set to true, the loader recursively loads 'children' attributes when doing the first load on nodes.")]
        public virtual bool PreloadChildren
        {
            get
            {
                object obj = this.ViewState["PreloadChildren"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["PreloadChildren"] = value;
            }
        }

        /// <summary>
        /// The HTTP request method for loading data.
        /// </summary>
        [ConfigOption]
        [Category("2. TreeLoader")]
        [DefaultValue(HttpMethod.Default)]
        [NotifyParentProperty(true)]
        [Description("The HTTP request method for loading data.")]
        public virtual HttpMethod RequestMethod
        {
            get
            {
                object obj = this.ViewState["RequestMethod"];
                return obj == null ? HttpMethod.Default : (HttpMethod)obj;
            }
            set
            {
                this.ViewState["RequestMethod"] = value;
            }
        }

        /// <summary>
        /// The timeout in milliseconds to be used for requests. (defaults to 30000)
        /// </summary>
        [ConfigOption]
        [NotifyParentProperty(true)]
        [DefaultValue(30000)]
        [Description("The timeout in milliseconds to be used for requests. (defaults to 30000)")]
        public virtual int Timeout
        {
            get
            {
                object obj = this.ViewState["Timeout"];
                return obj == null ? 30000 : (int)this.ViewState["Timeout"];
            }
            set
            {
                this.ViewState["Timeout"] = value;
            }
        }

        private TreeNodeUIProviders uiProviders;
        
        /// <summary>
        /// An object containing properties which specify custom Ext.tree.TreeNodeUI implementations. If the optional uiProvider attribute of a returned child node is a string rather than a reference to a TreeNodeUI implementation, then that string value is used as a property name in the uiProviders object.
        /// </summary>
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DefaultValue(null)]
        [Description("An object containing properties which specify custom Ext.tree.TreeNodeUI implementations. If the optional uiProvider attribute of a returned child node is a string rather than a reference to a TreeNodeUI implementation, then that string value is used as a property name in the uiProviders object.")]
        public virtual TreeNodeUIProviders UIProviders
        {
            get
            {
                if (this.uiProviders == null)
                {
                    this.uiProviders = new TreeNodeUIProviders();
                }

                return this.uiProviders;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("uiProviders", JsonMode.Raw)]
        [DefaultValue("{}")]
        [Description("")]
        protected virtual string UIProvidersProxy
        {
           get
           {
               return this.UIProviders.ToScript();
           }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class TreeLoaderCollection : StateManagedCollection<TreeLoaderBase>
    {
        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.ObjectAllowEmpty)]
        [Description("")]
        public TreeLoaderBase Primary
        {
            get
            {
                if (this.Count > 0)
                {
                    return this[0];
                }

                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public TreeLoaderCollection() : this(true) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="single"></param>
        [Description("")]
        public TreeLoaderCollection(bool single)
        {
           this.SingleItemMode = single;
        }
    }
}