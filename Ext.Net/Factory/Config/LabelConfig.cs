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
    public partial class Label
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public Label(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit Label.Config Conversion to Label
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator Label(Label.Config config)
        {
            return new Label(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : BoxComponentBase.Config 
        { 
			/*  Implicit Label.Config Conversion to Label.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator Label.Builder(Label.Config config)
			{
				return new Label.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string format = "";

			/// <summary>
			/// The format of the string to render using the .Text property. Example 'Hello {0}'.
			/// </summary>
			[DefaultValue("")]
			public virtual string Format 
			{ 
				get
				{
					return this.format;
				}
				set
				{
					this.format = value;
				}
			}

			private string emptyText = "";

			/// <summary>
			/// The default text to display if the Text property is empty (defaults to '').
			/// </summary>
			[DefaultValue("")]
			public virtual string EmptyText 
			{ 
				get
				{
					return this.emptyText;
				}
				set
				{
					this.emptyText = value;
				}
			}

			private string forID = "";

			/// <summary>
			/// The id of the input element to which this label will be bound via the standard 'htmlFor' attribute. If not specified, the attribute will not be added to the label.
			/// </summary>
			[DefaultValue("")]
			public virtual string ForID 
			{ 
				get
				{
					return this.forID;
				}
				set
				{
					this.forID = value;
				}
			}

			private string html = "";

			/// <summary>
			/// An HTML fragment that will be used as the label's innerHTML (defaults to ''). Note that if text is specified it will take precedence and this value will be ignored.
			/// </summary>
			[DefaultValue("")]
			public virtual string Html 
			{ 
				get
				{
					return this.html;
				}
				set
				{
					this.html = value;
				}
			}

			private string text = "";

			/// <summary>
			/// The plain text to display within the label (defaults to ''). If you need to include HTML tags within the label's innerHTML, use the html config instead.
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

			private Icon icon = Icon.None;

			/// <summary>
			/// The icon to use in the label. See also, IconCls to set an icon with a custom Css class.
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
			/// A css class which sets a background image to be used as the icon for this label.
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

			private Alignment iconAlign = Alignment.Left;

			/// <summary>
			/// (optional) Set the CSS text-align property of the icon. The center is not supported. Defaults to \"Left\"
			/// </summary>
			[DefaultValue(Alignment.Left)]
			public virtual Alignment IconAlign 
			{ 
				get
				{
					return this.iconAlign;
				}
				set
				{
					this.iconAlign = value;
				}
			}
        
			private ItemsCollection<Editor> editor = null;

			/// <summary>
			/// Inline editor
			/// </summary>
			public ItemsCollection<Editor> Editor
			{
				get
				{
					if (this.editor == null)
					{
						this.editor = new ItemsCollection<Editor>();
					}
			
					return this.editor;
				}
			}
			        
			private BoxComponentListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public BoxComponentListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new BoxComponentListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private BoxComponentDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public BoxComponentDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new BoxComponentDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}