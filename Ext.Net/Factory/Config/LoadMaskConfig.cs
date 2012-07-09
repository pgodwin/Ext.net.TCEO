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
    public partial class LoadMask
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public LoadMask(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit LoadMask.Config Conversion to LoadMask
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator LoadMask(LoadMask.Config config)
        {
            return new LoadMask(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : StateManagedItem.Config 
        { 
			/*  Implicit LoadMask.Config Conversion to LoadMask.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator LoadMask.Builder(LoadMask.Config config)
			{
				return new LoadMask.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool showMask = false;

			/// <summary>
			/// True to create a single-use mask that is automatically destroyed after loading (useful for page loads), False to persist the mask element reference for multiple uses (e.g., for paged data widgets). Defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool ShowMask 
			{ 
				get
				{
					return this.showMask;
				}
				set
				{
					this.showMask = value;
				}
			}

			private string msg = "Loading...";

			/// <summary>
			/// The text to display in a centered loading message box (defaults to 'Loading...').
			/// </summary>
			[DefaultValue("Loading...")]
			public virtual string Msg 
			{ 
				get
				{
					return this.msg;
				}
				set
				{
					this.msg = value;
				}
			}

			private string msgCls = "x-mask-loading";

			/// <summary>
			/// The CSS class to apply to the loading message element (defaults to 'x-mask-loading').
			/// </summary>
			[DefaultValue("x-mask-loading")]
			public virtual string MsgCls 
			{ 
				get
				{
					return this.msgCls;
				}
				set
				{
					this.msgCls = value;
				}
			}

			private bool removeMask = false;

			/// <summary>
			/// True to create a single-use mask that is automatically destroyed after loading (useful for page loads), False to persist the mask element reference for multiple uses (e.g., for paged data widgets). Defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool RemoveMask 
			{ 
				get
				{
					return this.removeMask;
				}
				set
				{
					this.removeMask = value;
				}
			}

        }
    }
}