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
    public class Layer : Element
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Layer(LayerConfig config) : base(config.Serialize(true)) { }

        /// <summary>
        /// Sets the z-index of this layer and adjusts any shadow and shim z-indexes. The layer z-index is automatically incremented by two more than the value passed in so that it always shows above any shadow or shim (the shadow element, if any, will be assigned z-index + 1, and the shim element, if any, will be assigned the unmodified z-index).
        /// </summary>
        /// <param name="zindex">The new z-index to set</param>
        /// <returns>This layer</returns>
        public virtual Layer SetZIndex(int zindex)
        {
            this.Call("setZIndex", zindex);
            return this;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual Layer Sync(bool show)
        {
            this.Call("sync", show);
            return this;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual Layer Sync()
        {
            this.Call("sync");
            return this;
        }
    }

    public partial class LayerConfig : StateManagedItem
    {
        /// <summary>
        /// CSS class to add to the element
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        public virtual string Cls
        {
            get
            {
                return (string)this.ViewState["Cls"] ?? "";
            }
            set
            {
                this.ViewState["Cls"] = value;
            }
        }

        /// <summary>
        /// The Layer ID
        /// </summary>
        [Meta]
        [ConfigOption("id")]
        [DefaultValue("")]
        public virtual string ID
        {
            get
            {
                return (string)this.ViewState["ID"] ?? "";
            }
            set
            {
                this.ViewState["ID"] = value;
            }
        }

        /// <summary>
        /// False to disable constrain to viewport (defaults to true)
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        public virtual bool Constrain
        {
            get
            {
                object obj = this.ViewState["Constrain"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["Constrain"] = value;
            }
        }

        private DomObject dh;

        /// <summary>
        /// DomHelper object config to create element with (defaults to {tag: 'div', cls: 'x-layer'}).
        /// </summary>
        [Meta]
        [ConfigOption("dh", JsonMode.Object)]
        public virtual DomObject DH
        {
            get
            {
                if (this.dh == null)
                {
                    this.dh = new DomObject();
                }

                return this.dh;
            }
        }

        /// <summary>
        /// True to automatically create an Ext.Shadow, or a string indicating the shadow's display Ext.Shadow.mode. False to disable the shadow. (defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption(typeof(ShadowJsonConverter))]
        [DefaultValue(ShadowMode.None)]
        public virtual ShadowMode Shadow
        {
            get
            {
                object obj = this.ViewState["Shadow"];
                return (obj == null) ? ShadowMode.None : (ShadowMode)obj;
            }
            set
            {
                this.ViewState["Shadow"] = value;
            }
        }

        /// <summary>
        /// Number of pixels to offset the shadow (defaults to 4)
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(4)]
        public virtual int ShadowOffset
        {
            get
            {
                object obj = this.ViewState["ShadowOffset"];
                return (obj == null) ? 4 : (int)obj;
            }
            set
            {
                this.ViewState["ShadowOffset"] = value;
            }
        }

        /// <summary>
        /// False to disable the iframe shim in browsers which need one (defaults to true)
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        public virtual bool Shim
        {
            get
            {
                object obj = this.ViewState["Shim"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["Shim"] = value;
            }
        }

        /// <summary>
        /// Defaults to use css offsets to hide the Layer. Specify true to use css style 'display:none;' to hide the Layer.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        public virtual bool UseDisplay
        {
            get
            {
                object obj = this.ViewState["UseDisplay"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["UseDisplay"] = value;
            }
        }

        /// <summary>
        /// Starting z-index (defaults to 11000)
        /// </summary>
        [Meta]
        [ConfigOption("zindex")]
        [DefaultValue(11000)]
        public virtual int ZIndex
        {
            get
            {
                object obj = this.ViewState["ZIndex"];
                return (obj == null) ? 11000 : (int)obj;
            }
            set
            {
                this.ViewState["ZIndex"] = value;
            }
        }

        private Element parentElement;

        /// <summary>
        /// Parent element for current Layer
        /// </summary>
        [Meta]
        [DefaultValue(null)]
        public virtual Element ParentElement
        {
            get
            {
                return this.parentElement;
            }
            set
            {
                this.parentElement = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [DefaultValue("")]
        [ConfigOption("parentEl", JsonMode.Raw)]
		[Description("")]
        protected virtual string ParentElementProxy
        {
            get
            {
                if (this.ParentElement != null)
                {
                    return this.ParentElement.Descriptor;
                }

                return "";
            }
        }

        private Element existingElement;

        /// <summary>
        /// Uses an existing DOM element. If the element is not found it creates it.
        /// </summary>
        [Meta]
        [DefaultValue(null)]
        public virtual Element ExistingElement
        {
            get
            {
                return this.existingElement;
            }
            set
            {
                this.existingElement = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Serialize()
        {
            return this.Serialize(false);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Serialize(bool withInstance)
        {
            string config = new ClientConfig().Serialize(this, true);

            if (withInstance)
            {
                config = "new Ext.Layer(".ConcatWith(config, this.ExistingElement != null ? ", "+this.ExistingElement.Descriptor : "" , ")");
            }
            
            return config;
        }
    }
}
