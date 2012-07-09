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
    public partial class StatusBar
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public StatusBar(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit StatusBar.Config Conversion to StatusBar
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator StatusBar(StatusBar.Config config)
        {
            return new StatusBar(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : ToolbarBase.Config 
        { 
			/*  Implicit StatusBar.Config Conversion to StatusBar.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator StatusBar.Builder(StatusBar.Config config)
			{
				return new StatusBar.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private int autoClear = 5000;

			/// <summary>
			/// The number of milliseconds to wait after setting the status via setStatus before automatically clearing the status text and icon (defaults to 5000). Note that this only applies when passing the clear argument to setStatus since that is the only way to defer clearing the status. This can be overridden by specifying a different wait value in setStatus. Calls to clearStatus always clear the status bar immediately and ignore this value.
			/// </summary>
			[DefaultValue(5000)]
			public virtual int AutoClear 
			{ 
				get
				{
					return this.autoClear;
				}
				set
				{
					this.autoClear = value;
				}
			}

			private Icon busyIcon = Icon.None;

			/// <summary>
			/// The default Icon applied when calling showBusy (defaults to 'Icon.None'). It can be overridden at any time by passing the iconCls argument into showBusy. See the Icon or IconCls docs for additional details about customizing the icon.
			/// </summary>
			[DefaultValue(Icon.None)]
			public virtual Icon BusyIcon 
			{ 
				get
				{
					return this.busyIcon;
				}
				set
				{
					this.busyIcon = value;
				}
			}

			private string busyIconCls = "x-status-busy";

			/// <summary>
			/// The default iconCls applied when calling showBusy (defaults to 'x-status-busy'). It can be overridden at any time by passing the iconCls argument into showBusy. See the iconCls docs for additional details about customizing the icon.
			/// </summary>
			[DefaultValue("x-status-busy")]
			public virtual string BusyIconCls 
			{ 
				get
				{
					return this.busyIconCls;
				}
				set
				{
					this.busyIconCls = value;
				}
			}

			private string busyText = "Loading...";

			/// <summary>
			/// The default text applied when calling showBusy (defaults to 'Loading...'). It can be overridden at any time by passing the text argument into showBusy.
			/// </summary>
			[DefaultValue("Loading...")]
			public virtual string BusyText 
			{ 
				get
				{
					return this.busyText;
				}
				set
				{
					this.busyText = value;
				}
			}

			private string cls = "x-statusbar";

			/// <summary>
			/// The base class applied to the containing element for this component on render (defaults to 'x-statusbar')
			/// </summary>
			[DefaultValue("x-statusbar")]
			public override string Cls 
			{ 
				get
				{
					return this.cls;
				}
				set
				{
					this.cls = value;
				}
			}

			private Icon defaultIcon = Icon.None;

			/// <summary>
			/// The default Icon (see the Icon or IconCls docs for additional details about customizing the icon). This will be used anytime the status bar is cleared with the useDefaults:true option (defaults to 'Icon.None').
			/// </summary>
			[DefaultValue(Icon.None)]
			public virtual Icon DefaultIcon 
			{ 
				get
				{
					return this.defaultIcon;
				}
				set
				{
					this.defaultIcon = value;
				}
			}

			private string defaultIconCls = "";

			/// <summary>
			/// The default iconCls value (see the iconCls docs for additional details about customizing the icon). This will be used anytime the status bar is cleared with the useDefaults:true option (defaults to '').
			/// </summary>
			[DefaultValue("")]
			public virtual string DefaultIconCls 
			{ 
				get
				{
					return this.defaultIconCls;
				}
				set
				{
					this.defaultIconCls = value;
				}
			}

			private string defaultText = "&nbsp;";

			/// <summary>
			/// The default text value. This will be used anytime the status bar is cleared with the useDefaults:true option (defaults to '').
			/// </summary>
			[DefaultValue("&nbsp;")]
			public virtual string DefaultText 
			{ 
				get
				{
					return this.defaultText;
				}
				set
				{
					this.defaultText = value;
				}
			}

			private Icon icon = Icon.None;

			/// <summary>
			/// An Icon that will be applied to the status element and is expected to provide a background image that will serve as the status bar icon (defaults to 'Icon.None'). The Icons is applied directly to the div that also contains the status text, so the rule should provide the appropriate padding on the div to make room for the image.
			/// </summary>
			[DefaultValue(Icon.None)]
			public virtual Icon Icon 
			{ 
				get
				{
					return this.icon;
				}
				set
				{
					this.icon = value;
				}
			}

			private string iconCls = "";

			/// <summary>
			/// A CSS class that will be applied to the status element and is expected to provide a background image that will serve as the status bar icon (defaults to ''). The class is applied directly to the div that also contains the status text, so the rule should provide the appropriate padding on the div to make room for the image.
			/// </summary>
			[DefaultValue("")]
			public virtual string IconCls 
			{ 
				get
				{
					return this.iconCls;
				}
				set
				{
					this.iconCls = value;
				}
			}

			private StatusAlign statusAlign = StatusAlign.Left;

			/// <summary>
			/// The alignment of the status element within the overall StatusBar layout. When the StatusBar is rendered, it creates an internal div containing the status text and icon. Any additional Toolbar items added in the StatusBar's items config, or added via add or any of the supported add* methods, will be rendered, in added order, to the opposite side. The status element is greedy, so it will automatically expand to take up all sapce left over by any other items.
			/// </summary>
			[DefaultValue(StatusAlign.Left)]
			public virtual StatusAlign StatusAlign 
			{ 
				get
				{
					return this.statusAlign;
				}
				set
				{
					this.statusAlign = value;
				}
			}

			private string text = "";

			/// <summary>
			/// A string that will be rendered into the status element as the status message (defaults to '').
			/// </summary>
			[DefaultValue("")]
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
        
			private ToolbarListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public ToolbarListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new ToolbarListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private StatusBarDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public StatusBarDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new StatusBarDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}