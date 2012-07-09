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
    public partial class FileUploadField
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : TextFieldBase.Builder<FileUploadField, FileUploadField.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new FileUploadField()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(FileUploadField component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(FileUploadField.Config config) : base(new FileUploadField(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(FileUploadField component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The Text value to initialize this field with.
			/// </summary>
            public virtual FileUploadField.Builder Text(string text)
            {
                this.ToComponent().Text = text;
                return this as FileUploadField.Builder;
            }
             
 			/// <summary>
			/// The button text to display on the upload button (defaults to 'Browse...'). Note that if you supply a value for ButtonCfg, the ButtonCfg.Text value will be used instead if available.
			/// </summary>
            public virtual FileUploadField.Builder ButtonText(string buttonText)
            {
                this.ToComponent().ButtonText = buttonText;
                return this as FileUploadField.Builder;
            }
             
 			/// <summary>
			/// True to display the file upload field as a button with no visible text field (defaults to false).
			/// </summary>
            public virtual FileUploadField.Builder ButtonOnly(bool buttonOnly)
            {
                this.ToComponent().ButtonOnly = buttonOnly;
                return this as FileUploadField.Builder;
            }
             
 			/// <summary>
			/// The number of pixels of space reserved between the button and the text field (defaults to 3).  Note that this only applies if ButtonOnly=false.
			/// </summary>
            public virtual FileUploadField.Builder ButtonOffset(int buttonOffset)
            {
                this.ToComponent().ButtonOffset = buttonOffset;
                return this as FileUploadField.Builder;
            }
             
 			/// <summary>
			/// True to mark the field as readOnly in HTML (defaults to false) -- Note: this only sets the element's readOnly DOM attribute.
			/// </summary>
            public virtual FileUploadField.Builder ReadOnly(bool readOnly)
            {
                this.ToComponent().ReadOnly = readOnly;
                return this as FileUploadField.Builder;
            }
             
 			/// <summary>
			/// The icon to use in the Button. See also, IconCls to set an icon with a custom Css class.
			/// </summary>
            public virtual FileUploadField.Builder Icon(Icon icon)
            {
                this.ToComponent().Icon = icon;
                return this as FileUploadField.Builder;
            }
             
 			/// <summary>
			/// A css class which sets a background image to be used as the icon for this button.
			/// </summary>
            public virtual FileUploadField.Builder IconCls(string iconCls)
            {
                this.ToComponent().IconCls = iconCls;
                return this as FileUploadField.Builder;
            }
             
 			// /// <summary>
			// /// Client-side JavaScript Event Handlers
			// /// </summary>
            // public virtual TBuilder Listeners(FileUploadFieldListeners listeners)
            // {
            //    this.ToComponent().Listeners = listeners;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// Server-side Ajax Event Handlers
			// /// </summary>
            // public virtual TBuilder DirectEvents(FileUploadFieldDirectEvents directEvents)
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
        public FileUploadField.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.FileUploadField(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public FileUploadField.Builder FileUploadField()
        {
            return this.FileUploadField(new FileUploadField());
        }

        /// <summary>
        /// 
        /// </summary>
        public FileUploadField.Builder FileUploadField(FileUploadField component)
        {
            return new FileUploadField.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public FileUploadField.Builder FileUploadField(FileUploadField.Config config)
        {
            return new FileUploadField.Builder(new FileUploadField(config));
        }
    }
}