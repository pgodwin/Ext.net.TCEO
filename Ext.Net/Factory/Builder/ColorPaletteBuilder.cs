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
    public partial class ColorPalette
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : Component.Builder<ColorPalette, ColorPalette.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ColorPalette()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ColorPalette component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ColorPalette.Config config) : base(new ColorPalette(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ColorPalette component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// If set to true then reselecting a color that is already selected fires the select event
			/// </summary>
            public virtual ColorPalette.Builder AllowReselect(bool allowReselect)
            {
                this.ToComponent().AllowReselect = allowReselect;
                return this as ColorPalette.Builder;
            }
             
 			/// <summary>
			/// An array of 6-digit color hex code strings (without the # symbol).
			/// </summary>
            public virtual ColorPalette.Builder Colors(string[] colors)
            {
                this.ToComponent().Colors = colors;
                return this as ColorPalette.Builder;
            }
             
 			/// <summary>
			/// The CSS class to apply to the containing element (defaults to \"x-color-palette\")
			/// </summary>
            public virtual ColorPalette.Builder ItemCls(string itemCls)
            {
                this.ToComponent().ItemCls = itemCls;
                return this as ColorPalette.Builder;
            }
             
 			// /// <summary>
			// /// An existing XTemplate instance to be used in place of the default template for rendering the component.
			// /// </summary>
            // public virtual TBuilder Template(XTemplate template)
            // {
            //    this.ToComponent().Template = template;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// The initial color to highlight (should be a valid 6-digit color hex code without the # symbol). Note that the hex codes are case-sensitive.
			/// </summary>
            public virtual ColorPalette.Builder Value(string value)
            {
                this.ToComponent().Value = value;
                return this as ColorPalette.Builder;
            }
             
 			/// <summary>
			/// AutoPostBack
			/// </summary>
            public virtual ColorPalette.Builder AutoPostBack(bool autoPostBack)
            {
                this.ToComponent().AutoPostBack = autoPostBack;
                return this as ColorPalette.Builder;
            }
             
 			/// <summary>
			/// Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs.
			/// </summary>
            public virtual ColorPalette.Builder CausesValidation(bool causesValidation)
            {
                this.ToComponent().CausesValidation = causesValidation;
                return this as ColorPalette.Builder;
            }
             
 			/// <summary>
			/// Gets or Sets the Controls ValidationGroup
			/// </summary>
            public virtual ColorPalette.Builder ValidationGroup(string validationGroup)
            {
                this.ToComponent().ValidationGroup = validationGroup;
                return this as ColorPalette.Builder;
            }
             
 			// /// <summary>
			// /// Client-side JavaScript Event Handlers
			// /// </summary>
            // public virtual TBuilder Listeners(ColorPaletteListeners listeners)
            // {
            //    this.ToComponent().Listeners = listeners;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// Server-side DirectEventHandlers
			// /// </summary>
            // public virtual TBuilder DirectEvents(ColorPaletteDirectEvents directEvents)
            // {
            //    this.ToComponent().DirectEvents = directEvents;
            //    return this as TBuilder;
            // }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// Selects the specified color in the palette (fires the select event)
			/// </summary>
            public virtual ColorPalette.Builder Select(string value)
            {
                this.ToComponent().Select(value);
                return this;
            }
            
 			/// <summary>
			/// Selects the specified color in the palette (fires the select event)
			/// </summary>
            public virtual ColorPalette.Builder Select(string value, bool suppressEvent)
            {
                this.ToComponent().Select(value, suppressEvent);
                return this;
            }
            
 			/// <summary>
			/// Selects the specified color in the palette (doesn't fire the select event)
			/// </summary>
            public virtual ColorPalette.Builder SilentSelect(string value)
            {
                this.ToComponent().SilentSelect(value);
                return this;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        public ColorPalette.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ColorPalette(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public ColorPalette.Builder ColorPalette()
        {
            return this.ColorPalette(new ColorPalette());
        }

        /// <summary>
        /// 
        /// </summary>
        public ColorPalette.Builder ColorPalette(ColorPalette component)
        {
            return new ColorPalette.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ColorPalette.Builder ColorPalette(ColorPalette.Config config)
        {
            return new ColorPalette.Builder(new ColorPalette(config));
        }
    }
}