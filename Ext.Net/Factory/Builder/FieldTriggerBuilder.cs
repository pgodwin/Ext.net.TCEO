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
    public partial class FieldTrigger
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : StateManagedItem.Builder<FieldTrigger, FieldTrigger.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new FieldTrigger()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(FieldTrigger component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(FieldTrigger.Config config) : base(new FieldTrigger(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(FieldTrigger component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// A trigger tag
			/// </summary>
            public virtual FieldTrigger.Builder Tag(string tag)
            {
                this.ToComponent().Tag = tag;
                return this as FieldTrigger.Builder;
            }
             
 			/// <summary>
			/// True to hide the trigger element and display only the base text field (defaults to false).
			/// </summary>
            public virtual FieldTrigger.Builder HideTrigger(bool hideTrigger)
            {
                this.ToComponent().HideTrigger = hideTrigger;
                return this as FieldTrigger.Builder;
            }
             
 			/// <summary>
			/// A CSS class to apply to the trigger.
			/// </summary>
            public virtual FieldTrigger.Builder TriggerCls(string triggerCls)
            {
                this.ToComponent().TriggerCls = triggerCls;
                return this as FieldTrigger.Builder;
            }
             
 			/// <summary>
			/// The icon to use in the trigger. See also, IconCls to set an icon with a custom Css class.
			/// </summary>
            public virtual FieldTrigger.Builder Icon(TriggerIcon icon)
            {
                this.ToComponent().Icon = icon;
                return this as FieldTrigger.Builder;
            }
             
 			/// <summary>
			/// A css class which sets a background image to be used as the icon for this button.
			/// </summary>
            public virtual FieldTrigger.Builder IconCls(string iconCls)
            {
                this.ToComponent().IconCls = iconCls;
                return this as FieldTrigger.Builder;
            }
             
 			/// <summary>
			/// Quick tip.
			/// </summary>
            public virtual FieldTrigger.Builder Qtip(string qtip)
            {
                this.ToComponent().Qtip = qtip;
                return this as FieldTrigger.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public FieldTrigger.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.FieldTrigger(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public FieldTrigger.Builder FieldTrigger()
        {
            return this.FieldTrigger(new FieldTrigger());
        }

        /// <summary>
        /// 
        /// </summary>
        public FieldTrigger.Builder FieldTrigger(FieldTrigger component)
        {
            return new FieldTrigger.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public FieldTrigger.Builder FieldTrigger(FieldTrigger.Config config)
        {
            return new FieldTrigger.Builder(new FieldTrigger(config));
        }
    }
}