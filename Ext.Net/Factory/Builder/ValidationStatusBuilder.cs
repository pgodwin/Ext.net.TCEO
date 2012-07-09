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
    public partial class ValidationStatus
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : Plugin.Builder<ValidationStatus, ValidationStatus.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ValidationStatus()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ValidationStatus component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ValidationStatus.Config config) : base(new ValidationStatus(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ValidationStatus component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The FormPanel to use.
			/// </summary>
            public virtual ValidationStatus.Builder FormPanelID(string formPanelID)
            {
                this.ToComponent().FormPanelID = formPanelID;
                return this as ValidationStatus.Builder;
            }
             
 			/// <summary>
			/// The error icon
			/// </summary>
            public virtual ValidationStatus.Builder ErrorIcon(Icon errorIcon)
            {
                this.ToComponent().ErrorIcon = errorIcon;
                return this as ValidationStatus.Builder;
            }
             
 			/// <summary>
			/// The error icon css class
			/// </summary>
            public virtual ValidationStatus.Builder ErrorIconCls(string errorIconCls)
            {
                this.ToComponent().ErrorIconCls = errorIconCls;
                return this as ValidationStatus.Builder;
            }
             
 			/// <summary>
			/// The error list css class
			/// </summary>
            public virtual ValidationStatus.Builder ErrorListCls(string errorListCls)
            {
                this.ToComponent().ErrorListCls = errorListCls;
                return this as ValidationStatus.Builder;
            }
             
 			/// <summary>
			/// The valid icon
			/// </summary>
            public virtual ValidationStatus.Builder ValidIcon(Icon validIcon)
            {
                this.ToComponent().ValidIcon = validIcon;
                return this as ValidationStatus.Builder;
            }
             
 			/// <summary>
			/// The valid icon css class
			/// </summary>
            public virtual ValidationStatus.Builder ValidIconCls(string validIconCls)
            {
                this.ToComponent().ValidIconCls = validIconCls;
                return this as ValidationStatus.Builder;
            }
             
 			/// <summary>
			/// The text which shown when errors exist
			/// </summary>
            public virtual ValidationStatus.Builder ShowText(string showText)
            {
                this.ToComponent().ShowText = showText;
                return this as ValidationStatus.Builder;
            }
             
 			/// <summary>
			/// The text which hide error list when click on it
			/// </summary>
            public virtual ValidationStatus.Builder HideText(string hideText)
            {
                this.ToComponent().HideText = hideText;
                return this as ValidationStatus.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public ValidationStatus.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ValidationStatus(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public ValidationStatus.Builder ValidationStatus()
        {
            return this.ValidationStatus(new ValidationStatus());
        }

        /// <summary>
        /// 
        /// </summary>
        public ValidationStatus.Builder ValidationStatus(ValidationStatus component)
        {
            return new ValidationStatus.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ValidationStatus.Builder ValidationStatus(ValidationStatus.Config config)
        {
            return new ValidationStatus.Builder(new ValidationStatus(config));
        }
    }
}