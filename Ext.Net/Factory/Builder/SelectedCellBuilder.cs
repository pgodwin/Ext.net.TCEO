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
    public partial class SelectedCell
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : StateManagedItem.Builder<SelectedCell, SelectedCell.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new SelectedCell()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(SelectedCell component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(SelectedCell.Config config) : base(new SelectedCell(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(SelectedCell component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual SelectedCell.Builder RowIndex(int rowIndex)
            {
                this.ToComponent().RowIndex = rowIndex;
                return this as SelectedCell.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual SelectedCell.Builder ColIndex(int colIndex)
            {
                this.ToComponent().ColIndex = colIndex;
                return this as SelectedCell.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual SelectedCell.Builder RecordID(string recordID)
            {
                this.ToComponent().RecordID = recordID;
                return this as SelectedCell.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual SelectedCell.Builder Name(string name)
            {
                this.ToComponent().Name = name;
                return this as SelectedCell.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public SelectedCell.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.SelectedCell(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public SelectedCell.Builder SelectedCell()
        {
            return this.SelectedCell(new SelectedCell());
        }

        /// <summary>
        /// 
        /// </summary>
        public SelectedCell.Builder SelectedCell(SelectedCell component)
        {
            return new SelectedCell.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public SelectedCell.Builder SelectedCell(SelectedCell.Config config)
        {
            return new SelectedCell.Builder(new SelectedCell(config));
        }
    }
}