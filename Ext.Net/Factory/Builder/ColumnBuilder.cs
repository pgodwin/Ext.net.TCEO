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
    public partial class Column
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : ColumnBase.Builder<Column, Column.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new Column()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Column component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Column.Config config) : base(new Column(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(Column component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual Column.Builder XType(string xType)
            {
                this.ToComponent().XType = xType;
                return this as Column.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual Column.Builder RightCommandAlign(bool rightCommandAlign)
            {
                this.ToComponent().RightCommandAlign = rightCommandAlign;
                return this as Column.Builder;
            }
             
 			// /// <summary>
			// /// 
			// /// </summary>
            // public virtual TBuilder Commands(ImageCommandCollection commands)
            // {
            //    this.ToComponent().Commands = commands;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// 
			// /// </summary>
            // public virtual TBuilder PrepareCommand(JFunction prepareCommand)
            // {
            //    this.ToComponent().PrepareCommand = prepareCommand;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// 
			// /// </summary>
            // public virtual TBuilder PrepareCommands(JFunction prepareCommands)
            // {
            //    this.ToComponent().PrepareCommands = prepareCommands;
            //    return this as TBuilder;
            // }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public Column.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.Column(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public Column.Builder Column()
        {
            return this.Column(new Column());
        }

        /// <summary>
        /// 
        /// </summary>
        public Column.Builder Column(Column component)
        {
            return new Column.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public Column.Builder Column(Column.Config config)
        {
            return new Column.Builder(new Column(config));
        }
    }
}