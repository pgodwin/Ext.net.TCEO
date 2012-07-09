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
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// A config object containing any or all of the following properties. If this object is not specified the status will be cleared using the defaults.
    /// </summary>
    [ToolboxItem(false)]
    [Description("A config object containing any or all of the following properties. If this object is not specified the status will be cleared using the defaults.")]
    public partial class WaitConfig : ExtObject
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public WaitConfig() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual string ToJsonString()
        {
            return new ClientConfig().Serialize(this);
        }

        int duration = -1;

        /// <summary>
        /// The length of time in milliseconds that the progress bar should run before resetting itself (defaults to undefined, in which case it will run indefinitely until reset is called)
        /// </summary>
        [ConfigOption]
        [DefaultValue(-1)]
        [NotifyParentProperty(true)]
        [Description("The length of time in milliseconds that the progress bar should run before resetting itself (defaults to undefined, in which case it will run indefinitely until reset is called)")]
        public virtual int Duration
        {
            get
            {
                return this.duration;
            }
            set
            {
                this.duration = value;
            }
        }

        int interval = 1000;

        /// <summary>
        /// The length of time in milliseconds between each progress update (defaults to 1000 ms)
        /// </summary>
        [ConfigOption]
        [DefaultValue(1000)]
        [NotifyParentProperty(true)]
        [Description("The length of time in milliseconds between each progress update (defaults to 1000 ms)")]
        public virtual int Interval
        {
            get
            {
                return this.interval;
            }
            set
            {
                this.interval = value;
            }
        }

        int increment = 10;

        /// <summary>
        /// The number of progress update segments to display within the progress bar (defaults to 10).  If the bar reaches the end and is still updating, it will automatically wrap back to the beginning.
        /// </summary>
        [ConfigOption]
        [DefaultValue(10)]
        [NotifyParentProperty(true)]
        [Description("The number of progress update segments to display within the progress bar (defaults to 10).  If the bar reaches the end and is still updating, it will automatically wrap back to the beginning.")]
        public virtual int Increment
        {
            get
            {
                return this.increment;
            }
            set
            {
                this.increment = value;
            }
        }

        string text = "";

        /// <summary>
        /// Optional text to display in the progress bar element (defaults to '').
        /// </summary>
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Optional text to display in the progress bar element (defaults to '').")]
        public virtual string Text
        {
            get
            {
                return this.text;
            }
            set
            {
                this.text = value;
            }
        }

        string fn = "";

        /// <summary>
        /// A callback function to execute after the progress bar finishes auto-updating. The function will be called with no arguments. This function will be ignored if duration is not specified since in that case the progress bar can only be stopped programmatically, so any required function should be called by the same code after it resets the progress bar.
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A callback function to execute after the progress bar finishes auto-updating. The function will be called with no arguments. This function will be ignored if duration is not specified since in that case the progress bar can only be stopped programmatically, so any required function should be called by the same code after it resets the progress bar.")]
        public virtual string Fn
        {
            get
            {
                return this.fn;
            }
            set
            {
                this.fn = value;
            }
        }

        string scope = "";

        /// <summary>
        /// The scope that is passed to the callback function (only applies when duration and fn are both passed).
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The scope that is passed to the callback function (only applies when duration and fn are both passed).")]
        public virtual string Scope
        {
            get
            {
                return this.scope;
            }
            set
            {
                this.scope = value;
            }
        }
    }        
}