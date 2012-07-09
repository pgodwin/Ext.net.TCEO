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
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>    
    public partial class ObservableDirectEvent : BaseDirectEvent
    {
        /// <summary>
        /// After handler with params: el, extraParams. Called immediately after DirectEvent has been requested.
        /// </summary>
        [ConfigOption(typeof(DirectEventHandlerJsonConverter))]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("After handler with params: el, extraParams. Called immediately after DirectEvent has been requested.")]
        public virtual string After
        {
            get
            {
                return (string)this.ViewState["After"] ?? "";
            }
            set
            {
                this.ViewState["After"] = value;
            }
        }

        /// <summary>
        /// Before handler with params: el, type, action, extraParams
        /// </summary>
        [ConfigOption(typeof(DirectEventHandlerJsonConverter))]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Before handler with params: el, type, action, extraParams")]
        public virtual string Before
        {
            get
            {
                return (string)this.ViewState["Before"] ?? "";
            }
            set
            {
                this.ViewState["Before"] = value;
            }
        }

        /// <summary>
        /// Success handler with params: response, result, control, type, action, extraParams
        /// </summary>
        [DefaultValue("")]
        [ConfigOption("userSuccess", typeof(DirectEventHandlerJsonConverter))]
        [NotifyParentProperty(true)]
        [Description("Success handler with params: response, result, el, type, action, extraParams")]
        public virtual string Success
        {
            get
            {
                return (string)this.ViewState["Success"] ?? "";
            }
            set
            {
                this.ViewState["Success"] = value;
            }
        }

        /// <summary>
        /// Failure handler with params: response, result, control, type, action, extraParams
        /// </summary>
        [DefaultValue("")]
        [ConfigOption("userFailure", typeof(DirectEventHandlerJsonConverter))]
        [NotifyParentProperty(true)]
        [Description("Failure handler with params: response, result, control, type, action, extraParams")]
        public virtual string Failure
        {
            get
            {
                return (string)this.ViewState["Failure"] ?? "";
            }
            set
            {
                this.ViewState["Failure"] = value;
            }
        }

        /// <summary>
        /// Failure handler with params: success, response, result, control, type, action, extraParams
        /// </summary>
        [DefaultValue("")]
        [ConfigOption("userComplete", typeof(DirectEventHandlerJsonConverter))]
        [NotifyParentProperty(true)]
        [Description("Failure handler with params: success, response, result, control, type, action, extraParams")]
        public virtual string Complete
        {
            get
            {
                return (string)this.ViewState["Complete"] ?? "";
            }
            set
            {
                this.ViewState["Complete"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void Clear()
        {
            this.Before = this.Success = this.Failure = "";
            this.ShowWarningOnFailure = true;
        }
    }
}