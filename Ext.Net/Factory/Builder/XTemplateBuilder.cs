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
    public partial class XTemplate
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : LazyObservable.Builder<XTemplate, XTemplate.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new XTemplate()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(XTemplate component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(XTemplate.Config config) : base(new XTemplate(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(XTemplate component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Template text
			/// </summary>
            public virtual XTemplate.Builder Html(string html)
            {
                this.ToComponent().Html = html;
                return this as XTemplate.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// Applies the supplied values to the template and appends the new node(s) to el.
			/// </summary>
            public virtual XTemplate.Builder Append(string target, object data)
            {
                this.ToComponent().Append(target, data);
                return this;
            }
            
 			/// <summary>
			/// Applies the supplied values to the template and appends the new node(s) to el.
			/// </summary>
            public virtual XTemplate.Builder Append(Component target, object data)
            {
                this.ToComponent().Append(target, data);
                return this;
            }
            
 			/// <summary>
			/// Applies the supplied values to the template and appends the new node(s) to el.
			/// </summary>
            public virtual XTemplate.Builder Append(Element target, object data)
            {
                this.ToComponent().Append(target, data);
                return this;
            }
            
 			/// <summary>
			/// Applies the supplied values to the template and inserts the new node(s) after el.
			/// </summary>
            public virtual XTemplate.Builder InsertAfter(string target, object data)
            {
                this.ToComponent().InsertAfter(target, data);
                return this;
            }
            
 			/// <summary>
			/// Applies the supplied values to the template and inserts the new node(s) after el.
			/// </summary>
            public virtual XTemplate.Builder InsertAfter(Component target, object data)
            {
                this.ToComponent().InsertAfter(target, data);
                return this;
            }
            
 			/// <summary>
			/// Applies the supplied values to the template and inserts the new node(s) after el.
			/// </summary>
            public virtual XTemplate.Builder InsertAfter(Element target, object data)
            {
                this.ToComponent().InsertAfter(target, data);
                return this;
            }
            
 			/// <summary>
			/// Applies the supplied values to the template and inserts the new node(s) before el.
			/// </summary>
            public virtual XTemplate.Builder InsertBefore(string target, object data)
            {
                this.ToComponent().InsertBefore(target, data);
                return this;
            }
            
 			/// <summary>
			/// Applies the supplied values to the template and inserts the new node(s) before el.
			/// </summary>
            public virtual XTemplate.Builder InsertBefore(Component target, object data)
            {
                this.ToComponent().InsertBefore(target, data);
                return this;
            }
            
 			/// <summary>
			/// Applies the supplied values to the template and inserts the new node(s) before el.
			/// </summary>
            public virtual XTemplate.Builder InsertBefore(Element target, object data)
            {
                this.ToComponent().InsertBefore(target, data);
                return this;
            }
            
 			/// <summary>
			/// Applies the supplied values to the template and inserts the new node(s) as the first child of el.
			/// </summary>
            public virtual XTemplate.Builder InsertFirst(string target, object data)
            {
                this.ToComponent().InsertFirst(target, data);
                return this;
            }
            
 			/// <summary>
			/// Applies the supplied values to the template and inserts the new node(s) as the first child of el.
			/// </summary>
            public virtual XTemplate.Builder InsertFirst(Component target, object data)
            {
                this.ToComponent().InsertFirst(target, data);
                return this;
            }
            
 			/// <summary>
			/// Applies the supplied values to the template and inserts the new node(s) as the first child of el.
			/// </summary>
            public virtual XTemplate.Builder InsertFirst(Element target, object data)
            {
                this.ToComponent().InsertFirst(target, data);
                return this;
            }
            
 			/// <summary>
			/// Applies the supplied values to the template and overwrites the content of el with the new node(s).
			/// </summary>
            public virtual XTemplate.Builder Overwrite(string target, object data)
            {
                this.ToComponent().Overwrite(target, data);
                return this;
            }
            
 			/// <summary>
			/// Applies the supplied values to the template and overwrites the content of el with the new node(s).
			/// </summary>
            public virtual XTemplate.Builder Overwrite(Element target, object data)
            {
                this.ToComponent().Overwrite(target, data);
                return this;
            }
            
 			/// <summary>
			/// Applies the supplied values to the template and overwrites the content of el with the new node(s).
			/// </summary>
            public virtual XTemplate.Builder Overwrite(Component target, object data)
            {
                this.ToComponent().Overwrite(target, data);
                return this;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        public XTemplate.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.XTemplate(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public XTemplate.Builder XTemplate()
        {
            return this.XTemplate(new XTemplate());
        }

        /// <summary>
        /// 
        /// </summary>
        public XTemplate.Builder XTemplate(XTemplate component)
        {
            return new XTemplate.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public XTemplate.Builder XTemplate(XTemplate.Config config)
        {
            return new XTemplate.Builder(new XTemplate(config));
        }
    }
}