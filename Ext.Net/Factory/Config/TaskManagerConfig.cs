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
    public partial class TaskManager
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public TaskManager(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit TaskManager.Config Conversion to TaskManager
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator TaskManager(TaskManager.Config config)
        {
            return new TaskManager(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : Observable.Config 
        { 
			/*  Implicit TaskManager.Config Conversion to TaskManager.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator TaskManager.Builder(TaskManager.Config config)
			{
				return new TaskManager.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private int interval = 10;

			/// <summary>
			/// The minimum precision in milliseconds supported by this TaskRunner instance (defaults to 10)
			/// </summary>
			[DefaultValue(10)]
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

			private int autoRunDelay = 50;

			/// <summary>
			/// The start delay in milliseconds for autorun tasks
			/// </summary>
			[DefaultValue(50)]
			public virtual int AutoRunDelay 
			{ 
				get
				{
					return this.autoRunDelay;
				}
				set
				{
					this.autoRunDelay = value;
				}
			}
        
			private TaskCollection tasks = null;

			/// <summary>
			/// 
			/// </summary>
			public TaskCollection Tasks
			{
				get
				{
					if (this.tasks == null)
					{
						this.tasks = new TaskCollection();
					}
			
					return this.tasks;
				}
			}
			
        }
    }
}