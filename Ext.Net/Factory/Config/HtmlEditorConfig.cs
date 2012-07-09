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
    public partial class HtmlEditor
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public HtmlEditor(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit HtmlEditor.Config Conversion to HtmlEditor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator HtmlEditor(HtmlEditor.Config config)
        {
            return new HtmlEditor(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : Field.Config 
        { 
			/*  Implicit HtmlEditor.Config Conversion to HtmlEditor.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator HtmlEditor.Builder(HtmlEditor.Config config)
			{
				return new HtmlEditor.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string text = "";

			/// <summary>
			/// The Text value to initialize this field with.
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
        
			private EditorListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public EditorListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new EditorListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private EditorDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public EditorDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new EditorDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
			private string createLinkText = "";

			/// <summary>
			/// The default text for the create link prompt.
			/// </summary>
			[DefaultValue("")]
			public virtual string CreateLinkText 
			{ 
				get
				{
					return this.createLinkText;
				}
				set
				{
					this.createLinkText = value;
				}
			}

			private string defaultLinkValue = "http://";

			/// <summary>
			/// The default value for the create link prompt (defaults to http://).
			/// </summary>
			[DefaultValue("http://")]
			public virtual string DefaultLinkValue 
			{ 
				get
				{
					return this.defaultLinkValue;
				}
				set
				{
					this.defaultLinkValue = value;
				}
			}

			private bool enableAlignments = true;

			/// <summary>
			/// Enable the left, center, right alignment buttons (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableAlignments 
			{ 
				get
				{
					return this.enableAlignments;
				}
				set
				{
					this.enableAlignments = value;
				}
			}

			private bool enableColors = true;

			/// <summary>
			/// Enable the fore/highlight color buttons (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableColors 
			{ 
				get
				{
					return this.enableColors;
				}
				set
				{
					this.enableColors = value;
				}
			}

			private bool enableFont = true;

			/// <summary>
			/// Enable font selection. Not available in Safari. (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableFont 
			{ 
				get
				{
					return this.enableFont;
				}
				set
				{
					this.enableFont = value;
				}
			}

			private bool enableFontSize = true;

			/// <summary>
			/// Enable the increase/decrease font size buttons (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableFontSize 
			{ 
				get
				{
					return this.enableFontSize;
				}
				set
				{
					this.enableFontSize = value;
				}
			}

			private bool enableFormat = true;

			/// <summary>
			/// Enable the bold, italic and underline buttons (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableFormat 
			{ 
				get
				{
					return this.enableFormat;
				}
				set
				{
					this.enableFormat = value;
				}
			}

			private bool enableLinks = true;

			/// <summary>
			/// Enable the create link button. Not available in Safari. (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableLinks 
			{ 
				get
				{
					return this.enableLinks;
				}
				set
				{
					this.enableLinks = value;
				}
			}

			private bool enableLists = true;

			/// <summary>
			/// Enable the bullet and numbered list buttons. Not available in Safari. (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableLists 
			{ 
				get
				{
					return this.enableLists;
				}
				set
				{
					this.enableLists = value;
				}
			}

			private bool enableSourceEdit = true;

			/// <summary>
			/// Enable the switch to source edit button. Not available in Safari. (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableSourceEdit 
			{ 
				get
				{
					return this.enableSourceEdit;
				}
				set
				{
					this.enableSourceEdit = value;
				}
			}

			private bool escapeValue = true;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EscapeValue 
			{ 
				get
				{
					return this.escapeValue;
				}
				set
				{
					this.escapeValue = value;
				}
			}

			private string[] fontFamilies = null;

			/// <summary>
			/// An array of available font families.
			/// </summary>
			[DefaultValue(null)]
			public virtual string[] FontFamilies 
			{ 
				get
				{
					return this.fontFamilies;
				}
				set
				{
					this.fontFamilies = value;
				}
			}

        }
    }
}