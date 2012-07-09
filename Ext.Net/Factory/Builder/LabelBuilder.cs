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
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : BoxComponentBase.Builder<Label, Label.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new Label()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Label component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Label.Config config) : base(new Label(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(Label component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The format of the string to render using the .Text property. Example 'Hello {0}'.
			/// </summary>
            public virtual Label.Builder Format(string format)
            {
                this.ToComponent().Format = format;
                return this as Label.Builder;
            }
             
 			/// <summary>
			/// The default text to display if the Text property is empty (defaults to '').
			/// </summary>
            public virtual Label.Builder EmptyText(string emptyText)
            {
                this.ToComponent().EmptyText = emptyText;
                return this as Label.Builder;
            }
             
 			/// <summary>
			/// The id of the input element to which this label will be bound via the standard 'htmlFor' attribute. If not specified, the attribute will not be added to the label.
			/// </summary>
            public virtual Label.Builder ForID(string forID)
            {
                this.ToComponent().ForID = forID;
                return this as Label.Builder;
            }
             
 			/// <summary>
			/// An HTML fragment that will be used as the label's innerHTML (defaults to ''). Note that if text is specified it will take precedence and this value will be ignored.
			/// </summary>
            public virtual Label.Builder Html(string html)
            {
                this.ToComponent().Html = html;
                return this as Label.Builder;
            }
             
 			/// <summary>
			/// The plain text to display within the label (defaults to ''). If you need to include HTML tags within the label's innerHTML, use the html config instead.
			/// </summary>
            public virtual Label.Builder Text(string text)
            {
                this.ToComponent().Text = text;
                return this as Label.Builder;
            }
             
 			/// <summary>
			/// The icon to use in the label. See also, IconCls to set an icon with a custom Css class.
			/// </summary>
            public virtual Label.Builder Icon(Icon icon)
            {
                this.ToComponent().Icon = icon;
                return this as Label.Builder;
            }
             
 			/// <summary>
			/// A css class which sets a background image to be used as the icon for this label.
			/// </summary>
            public virtual Label.Builder IconCls(string iconCls)
            {
                this.ToComponent().IconCls = iconCls;
                return this as Label.Builder;
            }
             
 			/// <summary>
			/// (optional) Set the CSS text-align property of the icon. The center is not supported. Defaults to \"Left\"
			/// </summary>
            public virtual Label.Builder IconAlign(Alignment iconAlign)
            {
                this.ToComponent().IconAlign = iconAlign;
                return this as Label.Builder;
            }
             
 			// /// <summary>
			// /// Inline editor
			// /// </summary>
            // public virtual TBuilder Editor(ItemsCollection<Editor> editor)
            // {
            //    this.ToComponent().Editor = editor;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// Client-side JavaScript Event Handlers
			// /// </summary>
            // public virtual TBuilder Listeners(BoxComponentListeners listeners)
            // {
            //    this.ToComponent().Listeners = listeners;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// Server-side Ajax Event Handlers
			// /// </summary>
            // public virtual TBuilder DirectEvents(BoxComponentDirectEvents directEvents)
            // {
            //    this.ToComponent().DirectEvents = directEvents;
            //    return this as TBuilder;
            // }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public Label.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.Label(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public Label.Builder Label()
        {
            return this.Label(new Label());
        }

        /// <summary>
        /// 
        /// </summary>
        public Label.Builder Label(Label component)
        {
            return new Label.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public Label.Builder Label(Label.Config config)
        {
            return new Label.Builder(new Label(config));
        }
    }
}