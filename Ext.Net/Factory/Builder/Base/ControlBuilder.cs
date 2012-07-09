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

using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
    /*  Abstract
        -----------------------------------------------------------------------------------------------*/

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TComponent"></typeparam>
    /// <typeparam name="TBuilder"></typeparam>
    public partial class ControlBuilder<TComponent, TBuilder> 
        : IControlBuilder<TComponent>
        where TComponent : Control
        where TBuilder : ControlBuilder<TComponent, TBuilder>
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ControlBuilder(TComponent control)
        {
            this.control = control;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected TComponent control;

        //  Hat Tip to James Newton King
        //  REFERENCE: http://james.newtonking.com/archive/2009/07/28/implicit-conversions-and-linq-to-json.aspx
        /// <summary>
        /// Implicit conversion of a TBuilder object directly into a TComponent. 
        /// </summary>
        public static implicit operator TComponent(ControlBuilder<TComponent, TBuilder> builder)
        {
            return builder.control as TComponent;
        }


        /*  Properties
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Identifier assigned to the server control.
        /// </summary>
        /// <param name="id">The id to assign to the server control.</param>
        /// <returns>ControlBuilder</returns>
        public virtual TBuilder ID(string id)
        {
            this.ToComponent().ID = id;
            return this as TBuilder;
        }


        /*  Methods
            -----------------------------------------------------------------------------------------------*/


        /// <summary>
        /// Get the instance of the underlying Control.
        /// </summary>
        /// <returns>Control</returns>
        public virtual TComponent ToComponent()
        {
            return this.control;
        }

        /// <summary>
        /// Render the Control.
        /// </summary>
        /// <param name="control">A Control in which to render this Builder into.</param>
        public virtual void Render(Control control)
        {
            control.Controls.Add(this.ToComponent());
        }
    }


    /*  Concrete
        -----------------------------------------------------------------------------------------------*/

    /// <summary>
    /// 
    /// </summary>
    public partial class ControlBuilder : ControlBuilder<Control, ControlBuilder>
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ControlBuilder(Control control) : base(control) { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static implicit operator ControlBuilder(Control control)
        {
            return control.ToBuilder();
        }
    }


    /*  Extensions
        -----------------------------------------------------------------------------------------------*/

    public static partial class Extensions
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static ControlBuilder ToBuilder(this Control instance)
        {
            return new ControlBuilder(instance);
        }
    }
}
