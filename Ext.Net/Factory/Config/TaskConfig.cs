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
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    public partial class Task
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public Task(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit Task.Config Conversion to Task
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator Task(Task.Config config)
        {
            return new Task(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : StateManagedItem.Config 
        { 
			/*  Implicit Task.Config Conversion to Task.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator Task.Builder(Task.Config config)
			{
				return new Task.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string taskID = "";

			/// <summary>
			/// (optional) The TaskID.
			/// </summary>
			[DefaultValue("")]
			public virtual string TaskID 
			{ 
				get
				{
					return this.taskID;
				}
				set
				{
					this.taskID = value;
				}
			}

			private bool autoRun = true;

			/// <summary>
			/// True to auto run task (defaults to false).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AutoRun 
			{ 
				get
				{
					return this.autoRun;
				}
				set
				{
					this.autoRun = value;
				}
			}

			private int interval = 1000;

			/// <summary>
			/// The frequency in milliseconds with which the task should be executed (defaults to 1000)
			/// </summary>
			[DefaultValue(1000)]
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

			private string[] args = null;

			/// <summary>
			/// (optional) An array of arguments to be passed to the function specified by run
			/// </summary>
			[DefaultValue(null)]
			public virtual string[] Args 
			{ 
				get
				{
					return this.args;
				}
				set
				{
					this.args = value;
				}
			}

			private string scope = "this";

			/// <summary>
			/// (optional) The scope in which to execute the run function.
			/// </summary>
			[DefaultValue("this")]
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

			private int duration = 0;

			/// <summary>
			/// (optional) The length of time in milliseconds to execute the task before stopping automatically (defaults to indefinite).
			/// </summary>
			[DefaultValue(0)]
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

			private int repeat = 0;

			/// <summary>
			/// (optional) The number of times to execute the task before stopping automatically (defaults to indefinite).
			/// </summary>
			[DefaultValue(0)]
			public virtual int Repeat 
			{ 
				get
				{
					return this.repeat;
				}
				set
				{
					this.repeat = value;
				}
			}

			private string onStart = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string OnStart 
			{ 
				get
				{
					return this.onStart;
				}
				set
				{
					this.onStart = value;
				}
			}

			private string onStop = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string OnStop 
			{ 
				get
				{
					return this.onStop;
				}
				set
				{
					this.onStop = value;
				}
			}
        
			private TaskListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public TaskListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new TaskListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private TaskDirectEvents directEvents = null;

			/// <summary>
			/// Server-side DirectEventHandlers
			/// </summary>
			public TaskDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new TaskDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}