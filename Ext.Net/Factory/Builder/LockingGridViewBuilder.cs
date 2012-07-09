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
    public partial class LockingGridView
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : GridView.Builder<LockingGridView, LockingGridView.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new LockingGridView()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(LockingGridView component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(LockingGridView.Config config) : base(new LockingGridView(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(LockingGridView component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The text displayed in the \"Lock\" menu item
			/// </summary>
            public virtual LockingGridView.Builder LockText(string lockText)
            {
                this.ToComponent().LockText = lockText;
                return this as LockingGridView.Builder;
            }
             
 			/// <summary>
			/// The text displayed in the \"Unlock\" menu item
			/// </summary>
            public virtual LockingGridView.Builder UnlockText(string unlockText)
            {
                this.ToComponent().UnlockText = unlockText;
                return this as LockingGridView.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual LockingGridView.Builder RowBorderWidth(int rowBorderWidth)
            {
                this.ToComponent().RowBorderWidth = rowBorderWidth;
                return this as LockingGridView.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual LockingGridView.Builder LockedBorderWidth(int lockedBorderWidth)
            {
                this.ToComponent().LockedBorderWidth = lockedBorderWidth;
                return this as LockingGridView.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual LockingGridView.Builder SyncHeights(bool syncHeights)
            {
                this.ToComponent().SyncHeights = syncHeights;
                return this as LockingGridView.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public LockingGridView.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.LockingGridView(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public LockingGridView.Builder LockingGridView()
        {
            return this.LockingGridView(new LockingGridView());
        }

        /// <summary>
        /// 
        /// </summary>
        public LockingGridView.Builder LockingGridView(LockingGridView component)
        {
            return new LockingGridView.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public LockingGridView.Builder LockingGridView(LockingGridView.Config config)
        {
            return new LockingGridView.Builder(new LockingGridView(config));
        }
    }
}