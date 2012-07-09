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
    public partial class PagingToolbar
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : ToolbarBase.Builder<PagingToolbar, PagingToolbar.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new PagingToolbar()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(PagingToolbar component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(PagingToolbar.Config config) : base(new PagingToolbar(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(PagingToolbar component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The index of current page.
			/// </summary>
            public virtual PagingToolbar.Builder PageIndex(int pageIndex)
            {
                this.ToComponent().PageIndex = pageIndex;
                return this as PagingToolbar.Builder;
            }
             
 			/// <summary>
			/// True to display the displayMsg (defaults to false).
			/// </summary>
            public virtual PagingToolbar.Builder DisplayInfo(bool displayInfo)
            {
                this.ToComponent().DisplayInfo = displayInfo;
                return this as PagingToolbar.Builder;
            }
             
 			/// <summary>
			/// The paging status message to display (defaults to 'Displaying {0} - {1} of {2}'). Note that this string is formatted using the braced numbers 0-2 as tokens that are replaced by the values for start, end and total respectively. These tokens should be preserved when overriding this string if showing those values is desired.
			/// </summary>
            public virtual PagingToolbar.Builder DisplayMsg(string displayMsg)
            {
                this.ToComponent().DisplayMsg = displayMsg;
                return this as PagingToolbar.Builder;
            }
             
 			/// <summary>
			/// The message to display when no records are found (defaults to 'No data to display').
			/// </summary>
            public virtual PagingToolbar.Builder EmptyMsg(string emptyMsg)
            {
                this.ToComponent().EmptyMsg = emptyMsg;
                return this as PagingToolbar.Builder;
            }
             
 			/// <summary>
			/// The number of records to display per page (defaults to 20).
			/// </summary>
            public virtual PagingToolbar.Builder PageSize(int pageSize)
            {
                this.ToComponent().PageSize = pageSize;
                return this as PagingToolbar.Builder;
            }
             
 			/// <summary>
			/// The data store to use.
			/// </summary>
            public virtual PagingToolbar.Builder StoreID(string storeID)
            {
                this.ToComponent().StoreID = storeID;
                return this as PagingToolbar.Builder;
            }
             
 			/// <summary>
			/// Customizable piece of the default paging text (defaults to 'of {0}'). Note that this string is formatted using {0} as a token that is replaced by the number of total pages. This token should be preserved when overriding this string if showing the total page count is desired.
			/// </summary>
            public virtual PagingToolbar.Builder AfterPageText(string afterPageText)
            {
                this.ToComponent().AfterPageText = afterPageText;
                return this as PagingToolbar.Builder;
            }
             
 			/// <summary>
			/// Customizable piece of the default paging text (defaults to 'Page')
			/// </summary>
            public virtual PagingToolbar.Builder BeforePageText(string beforePageText)
            {
                this.ToComponent().BeforePageText = beforePageText;
                return this as PagingToolbar.Builder;
            }
             
 			/// <summary>
			/// Customizable piece of the default paging text (defaults to 'First Page')
			/// </summary>
            public virtual PagingToolbar.Builder FirstText(string firstText)
            {
                this.ToComponent().FirstText = firstText;
                return this as PagingToolbar.Builder;
            }
             
 			/// <summary>
			/// Customizable piece of the default paging text (defaults to 'Last Page')
			/// </summary>
            public virtual PagingToolbar.Builder LastText(string lastText)
            {
                this.ToComponent().LastText = lastText;
                return this as PagingToolbar.Builder;
            }
             
 			/// <summary>
			/// Customizable piece of the default paging text (defaults to 'Next Page')
			/// </summary>
            public virtual PagingToolbar.Builder NextText(string nextText)
            {
                this.ToComponent().NextText = nextText;
                return this as PagingToolbar.Builder;
            }
             
 			/// <summary>
			/// Customizable piece of the default paging text (defaults to 'Previous Page')
			/// </summary>
            public virtual PagingToolbar.Builder PrevText(string prevText)
            {
                this.ToComponent().PrevText = prevText;
                return this as PagingToolbar.Builder;
            }
             
 			/// <summary>
			/// Customizable piece of the default paging text (defaults to 'Refresh')
			/// </summary>
            public virtual PagingToolbar.Builder RefreshText(string refreshText)
            {
                this.ToComponent().RefreshText = refreshText;
                return this as PagingToolbar.Builder;
            }
             
 			/// <summary>
			/// Hide refresh button
			/// </summary>
            public virtual PagingToolbar.Builder HideRefresh(bool hideRefresh)
            {
                this.ToComponent().HideRefresh = hideRefresh;
                return this as PagingToolbar.Builder;
            }
             
 			// /// <summary>
			// /// Object mapping of parameter names for load calls (defaults to {start: 'start', limit: 'limit'})
			// /// </summary>
            // public virtual TBuilder ParamNames(ParameterCollection paramNames)
            // {
            //    this.ToComponent().ParamNames = paramNames;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// Client-side JavaScript Event Handlers
			// /// </summary>
            // public virtual TBuilder Listeners(PagingToolbarListeners listeners)
            // {
            //    this.ToComponent().Listeners = listeners;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// Server-side DirectEventHandlers
			// /// </summary>
            // public virtual TBuilder DirectEvents(PagingToolbarDirectEvents directEvents)
            // {
            //    this.ToComponent().DirectEvents = directEvents;
            //    return this as TBuilder;
            // }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// 
			/// </summary>
            public virtual PagingToolbar.Builder SetPageIndex(int index)
            {
                this.ToComponent().SetPageIndex(index);
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual PagingToolbar.Builder SetPageSize(int size)
            {
                this.ToComponent().SetPageSize(size);
                return this;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        public PagingToolbar.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.PagingToolbar(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public PagingToolbar.Builder PagingToolbar()
        {
            return this.PagingToolbar(new PagingToolbar());
        }

        /// <summary>
        /// 
        /// </summary>
        public PagingToolbar.Builder PagingToolbar(PagingToolbar component)
        {
            return new PagingToolbar.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public PagingToolbar.Builder PagingToolbar(PagingToolbar.Config config)
        {
            return new PagingToolbar.Builder(new PagingToolbar(config));
        }
    }
}