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
    public partial class KeyNav
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public KeyNav(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit KeyNav.Config Conversion to KeyNav
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator KeyNav(KeyNav.Config config)
        {
            return new KeyNav(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : Observable.Config 
        { 
			/*  Implicit KeyNav.Config Conversion to KeyNav.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator KeyNav.Builder(KeyNav.Config config)
			{
				return new KeyNav.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string target = "";

			/// <summary>
			/// The element to bind to
			/// </summary>
			[DefaultValue("")]
			public virtual string Target 
			{ 
				get
				{
					return this.target;
				}
				set
				{
					this.target = value;
				}
			}
        
			private JFunction left = null;

			/// <summary>
			/// 
			/// </summary>
			public JFunction Left
			{
				get
				{
					if (this.left == null)
					{
						this.left = new JFunction();
					}
			
					return this.left;
				}
			}
			        
			private JFunction right = null;

			/// <summary>
			/// 
			/// </summary>
			public JFunction Right
			{
				get
				{
					if (this.right == null)
					{
						this.right = new JFunction();
					}
			
					return this.right;
				}
			}
			        
			private JFunction up = null;

			/// <summary>
			/// 
			/// </summary>
			public JFunction Up
			{
				get
				{
					if (this.up == null)
					{
						this.up = new JFunction();
					}
			
					return this.up;
				}
			}
			        
			private JFunction down = null;

			/// <summary>
			/// 
			/// </summary>
			public JFunction Down
			{
				get
				{
					if (this.down == null)
					{
						this.down = new JFunction();
					}
			
					return this.down;
				}
			}
			        
			private JFunction pageUp = null;

			/// <summary>
			/// 
			/// </summary>
			public JFunction PageUp
			{
				get
				{
					if (this.pageUp == null)
					{
						this.pageUp = new JFunction();
					}
			
					return this.pageUp;
				}
			}
			        
			private JFunction pageDown = null;

			/// <summary>
			/// 
			/// </summary>
			public JFunction PageDown
			{
				get
				{
					if (this.pageDown == null)
					{
						this.pageDown = new JFunction();
					}
			
					return this.pageDown;
				}
			}
			        
			private JFunction del = null;

			/// <summary>
			/// 
			/// </summary>
			public JFunction Del
			{
				get
				{
					if (this.del == null)
					{
						this.del = new JFunction();
					}
			
					return this.del;
				}
			}
			        
			private JFunction home = null;

			/// <summary>
			/// 
			/// </summary>
			public JFunction Home
			{
				get
				{
					if (this.home == null)
					{
						this.home = new JFunction();
					}
			
					return this.home;
				}
			}
			        
			private JFunction end = null;

			/// <summary>
			/// 
			/// </summary>
			public JFunction End
			{
				get
				{
					if (this.end == null)
					{
						this.end = new JFunction();
					}
			
					return this.end;
				}
			}
			        
			private JFunction enter = null;

			/// <summary>
			/// 
			/// </summary>
			public JFunction Enter
			{
				get
				{
					if (this.enter == null)
					{
						this.enter = new JFunction();
					}
			
					return this.enter;
				}
			}
			        
			private JFunction esc = null;

			/// <summary>
			/// 
			/// </summary>
			public JFunction Esc
			{
				get
				{
					if (this.esc == null)
					{
						this.esc = new JFunction();
					}
			
					return this.esc;
				}
			}
			        
			private JFunction tab = null;

			/// <summary>
			/// 
			/// </summary>
			public JFunction Tab
			{
				get
				{
					if (this.tab == null)
					{
						this.tab = new JFunction();
					}
			
					return this.tab;
				}
			}
			
			private KeyEventAction defaultEventAction = KeyEventAction.StopEvent;

			/// <summary>
			/// The method to call on the Ext.EventObject after this KeyNav intercepts a key. Valid values are Ext.EventObject.stopEvent, Ext.EventObject.preventDefault and Ext.EventObject.stopPropagation (defaults to 'stopEvent')
			/// </summary>
			[DefaultValue(KeyEventAction.StopEvent)]
			public virtual KeyEventAction DefaultEventAction 
			{ 
				get
				{
					return this.defaultEventAction;
				}
				set
				{
					this.defaultEventAction = value;
				}
			}

			private bool disabled = false;

			/// <summary>
			/// True to disable this KeyNav instance (defaults to false)
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Disabled 
			{ 
				get
				{
					return this.disabled;
				}
				set
				{
					this.disabled = value;
				}
			}

			private bool forceKeyDown = false;

			/// <summary>
			/// Handle the keydown event instead of keypress (defaults to false). KeyNav automatically does this for IE since IE does not propagate special keys on keypress, but setting this to true will force other browsers to also handle keydown instead of keypress.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool ForceKeyDown 
			{ 
				get
				{
					return this.forceKeyDown;
				}
				set
				{
					this.forceKeyDown = value;
				}
			}

			private string scope = "";

			/// <summary>
			/// The scope of the callback function
			/// </summary>
			[DefaultValue("")]
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
}