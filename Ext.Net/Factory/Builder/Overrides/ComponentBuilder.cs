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
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
    public abstract partial class Component
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TComponent"></typeparam>
        /// <typeparam name="TBuilder"></typeparam>
        new public abstract partial class Builder<TComponent, TBuilder> : Observable.Builder<TComponent, TBuilder>
            where TComponent : Component
            where TBuilder : Builder<TComponent, TBuilder>
        {
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/

            /// <summary>
            /// 
            /// </summary>
            /// <param name="control"></param>
            /// <returns></returns>
            public virtual TBuilder RenderTo(Control control)
            {
                return this.RenderTo(control.ClientID);
            }


            /*  Methods
                -----------------------------------------------------------------------------------------------*/

            //protected internal TBuilder SetParent<TParent, TParentBuilder>(TParent parent, TParentBuilder parentBuilder)
            //    where TParent : Component
            //    where TParentBuilder : Component.Builder<TParent, TParentBuilder>
            //{
            //    var temp = new ParentComponentBase<TParent, TParentBuilder>(parent, parentBuilder);
                
            //    return this as TBuilder;
            //}

            //public virtual TBuilder Parent()
            //{
            //    return this.OwnerBuilder as IControlBuilder<Component>;
            //}
        }        
    }
}