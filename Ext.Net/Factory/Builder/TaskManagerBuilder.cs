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
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : Observable.Builder<TaskManager, TaskManager.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new TaskManager()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TaskManager component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TaskManager.Config config) : base(new TaskManager(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(TaskManager component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The minimum precision in milliseconds supported by this TaskRunner instance (defaults to 10)
			/// </summary>
            public virtual TaskManager.Builder Interval(int interval)
            {
                this.ToComponent().Interval = interval;
                return this as TaskManager.Builder;
            }
             
 			/// <summary>
			/// The start delay in milliseconds for autorun tasks
			/// </summary>
            public virtual TaskManager.Builder AutoRunDelay(int autoRunDelay)
            {
                this.ToComponent().AutoRunDelay = autoRunDelay;
                return this as TaskManager.Builder;
            }
             
 			// /// <summary>
			// /// 
			// /// </summary>
            // public virtual TBuilder Tasks(TaskCollection tasks)
            // {
            //    this.ToComponent().Tasks = tasks;
            //    return this as TBuilder;
            // }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// 
			/// </summary>
            public virtual TaskManager.Builder AddTask(Task task)
            {
                this.ToComponent().AddTask(task);
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TaskManager.Builder RemoveTask(int index)
            {
                this.ToComponent().RemoveTask(index);
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TaskManager.Builder RemoveTask(string name)
            {
                this.ToComponent().RemoveTask(name);
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TaskManager.Builder StartAll()
            {
                this.ToComponent().StartAll();
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TaskManager.Builder StopAll()
            {
                this.ToComponent().StopAll();
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TaskManager.Builder StartTask(int index)
            {
                this.ToComponent().StartTask(index);
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TaskManager.Builder StopTask(int index)
            {
                this.ToComponent().StopTask(index);
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TaskManager.Builder StartTask(string name)
            {
                this.ToComponent().StartTask(name);
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TaskManager.Builder StopTask(string name)
            {
                this.ToComponent().StopTask(name);
                return this;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        public TaskManager.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.TaskManager(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public TaskManager.Builder TaskManager()
        {
            return this.TaskManager(new TaskManager());
        }

        /// <summary>
        /// 
        /// </summary>
        public TaskManager.Builder TaskManager(TaskManager component)
        {
            return new TaskManager.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public TaskManager.Builder TaskManager(TaskManager.Config config)
        {
            return new TaskManager.Builder(new TaskManager(config));
        }
    }
}