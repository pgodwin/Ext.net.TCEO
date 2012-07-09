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
    /// A simple utility class for generically masking elements while loading data. If the element being masked has an underlying Ext.data.Store, the masking will be automatically synchronized with the store's loading process and the mask element will be cached for reuse. For all other elements, this mask will replace the element's UpdateOptions load indicator and will be destroyed after the initial load.
    /// </summary>
    [Meta]
    [Description("A simple utility class for generically masking elements while loading data. If the element being masked has an underlying Ext.data.Store, the masking will be automatically synchronized with the store's loading process and the mask element will be cached for reuse. For all other elements, this mask will replace the element's UpdateOptions load indicator and will be destroyed after the initial load.")]
    public partial class LoadMask : StateManagedItem
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public LoadMask() { }

        /// <summary>
        /// True to create a single-use mask that is automatically destroyed after loading (useful for page loads), False to persist the mask element reference for multiple uses (e.g., for paged data widgets). Defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue(false)]
        [Description("True to create a single-use mask that is automatically destroyed after loading (useful for page loads), False to persist the mask element reference for multiple uses (e.g., for paged data widgets). Defaults to false.")]
        public virtual bool ShowMask
        {
            get
            {
                object obj = this.ViewState["ShowMask"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["ShowMask"] = value;
            }
        }

        /// <summary>
        /// The text to display in a centered loading message box (defaults to 'Loading...').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue("Loading...")]
        [Description("The text to display in a centered loading message box (defaults to 'Loading...').")]
        public virtual string Msg
        {
            get
            {
                return (string)this.ViewState["Msg"] ?? "Loading...";
            }
            set
            {
                this.ViewState["Msg"] = value;
            }
        }

        /// <summary>
        /// The CSS class to apply to the loading message element (defaults to 'x-mask-loading').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue("x-mask-loading")]
        [Description("The CSS class to apply to the loading message element (defaults to 'x-mask-loading').")]
        public virtual string MsgCls
        {
            get
            {
                return (string)this.ViewState["MsgCls"] ?? "x-mask-loading";
            }
            set
            {
                this.ViewState["MsgCls"] = value;
            }
        }

        /// <summary>
        /// True to create a single-use mask that is automatically destroyed after loading (useful for page loads), False to persist the mask element reference for multiple uses (e.g., for paged data widgets). Defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue(false)]
        [Description("True to create a single-use mask that is automatically destroyed after loading (useful for page loads), False to persist the mask element reference for multiple uses (e.g., for paged data widgets). Defaults to false.")]
        public virtual bool RemoveMask
        {
            get
            {
                object obj = this.ViewState["RemoveMask"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["RemoveMask"] = value;
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
                if (this is EventMask)
                {
                    return base.IsDefault;
                }

                return (this.ShowMask == false);
            }
        }
    }
}