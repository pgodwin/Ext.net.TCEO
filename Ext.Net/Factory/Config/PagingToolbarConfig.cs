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
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public PagingToolbar(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit PagingToolbar.Config Conversion to PagingToolbar
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator PagingToolbar(PagingToolbar.Config config)
        {
            return new PagingToolbar(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : ToolbarBase.Config 
        { 
			/*  Implicit PagingToolbar.Config Conversion to PagingToolbar.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator PagingToolbar.Builder(PagingToolbar.Config config)
			{
				return new PagingToolbar.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private int pageIndex = 1;

			/// <summary>
			/// The index of current page.
			/// </summary>
			[DefaultValue(1)]
			public virtual int PageIndex 
			{ 
				get
				{
					return this.pageIndex;
				}
				set
				{
					this.pageIndex = value;
				}
			}

			private bool displayInfo = false;

			/// <summary>
			/// True to display the displayMsg (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool DisplayInfo 
			{ 
				get
				{
					return this.displayInfo;
				}
				set
				{
					this.displayInfo = value;
				}
			}

			private string displayMsg = "Displaying {0} - {1} of {2}";

			/// <summary>
			/// The paging status message to display (defaults to 'Displaying {0} - {1} of {2}'). Note that this string is formatted using the braced numbers 0-2 as tokens that are replaced by the values for start, end and total respectively. These tokens should be preserved when overriding this string if showing those values is desired.
			/// </summary>
			[DefaultValue("Displaying {0} - {1} of {2}")]
			public virtual string DisplayMsg 
			{ 
				get
				{
					return this.displayMsg;
				}
				set
				{
					this.displayMsg = value;
				}
			}

			private string emptyMsg = "No data to display";

			/// <summary>
			/// The message to display when no records are found (defaults to 'No data to display').
			/// </summary>
			[DefaultValue("No data to display")]
			public virtual string EmptyMsg 
			{ 
				get
				{
					return this.emptyMsg;
				}
				set
				{
					this.emptyMsg = value;
				}
			}

			private int pageSize = 20;

			/// <summary>
			/// The number of records to display per page (defaults to 20).
			/// </summary>
			[DefaultValue(20)]
			public virtual int PageSize 
			{ 
				get
				{
					return this.pageSize;
				}
				set
				{
					this.pageSize = value;
				}
			}

			private string storeID = "";

			/// <summary>
			/// The data store to use.
			/// </summary>
			[DefaultValue("")]
			public virtual string StoreID 
			{ 
				get
				{
					return this.storeID;
				}
				set
				{
					this.storeID = value;
				}
			}

			private string afterPageText = "of {0}";

			/// <summary>
			/// Customizable piece of the default paging text (defaults to 'of {0}'). Note that this string is formatted using {0} as a token that is replaced by the number of total pages. This token should be preserved when overriding this string if showing the total page count is desired.
			/// </summary>
			[DefaultValue("of {0}")]
			public virtual string AfterPageText 
			{ 
				get
				{
					return this.afterPageText;
				}
				set
				{
					this.afterPageText = value;
				}
			}

			private string beforePageText = "Page";

			/// <summary>
			/// Customizable piece of the default paging text (defaults to 'Page')
			/// </summary>
			[DefaultValue("Page")]
			public virtual string BeforePageText 
			{ 
				get
				{
					return this.beforePageText;
				}
				set
				{
					this.beforePageText = value;
				}
			}

			private string firstText = "First Page";

			/// <summary>
			/// Customizable piece of the default paging text (defaults to 'First Page')
			/// </summary>
			[DefaultValue("First Page")]
			public virtual string FirstText 
			{ 
				get
				{
					return this.firstText;
				}
				set
				{
					this.firstText = value;
				}
			}

			private string lastText = "Last Page";

			/// <summary>
			/// Customizable piece of the default paging text (defaults to 'Last Page')
			/// </summary>
			[DefaultValue("Last Page")]
			public virtual string LastText 
			{ 
				get
				{
					return this.lastText;
				}
				set
				{
					this.lastText = value;
				}
			}

			private string nextText = "Next Page";

			/// <summary>
			/// Customizable piece of the default paging text (defaults to 'Next Page')
			/// </summary>
			[DefaultValue("Next Page")]
			public virtual string NextText 
			{ 
				get
				{
					return this.nextText;
				}
				set
				{
					this.nextText = value;
				}
			}

			private string prevText = "Previous Page";

			/// <summary>
			/// Customizable piece of the default paging text (defaults to 'Previous Page')
			/// </summary>
			[DefaultValue("Previous Page")]
			public virtual string PrevText 
			{ 
				get
				{
					return this.prevText;
				}
				set
				{
					this.prevText = value;
				}
			}

			private string refreshText = "Refresh";

			/// <summary>
			/// Customizable piece of the default paging text (defaults to 'Refresh')
			/// </summary>
			[DefaultValue("Refresh")]
			public virtual string RefreshText 
			{ 
				get
				{
					return this.refreshText;
				}
				set
				{
					this.refreshText = value;
				}
			}

			private bool hideRefresh = false;

			/// <summary>
			/// Hide refresh button
			/// </summary>
			[DefaultValue(false)]
			public virtual bool HideRefresh 
			{ 
				get
				{
					return this.hideRefresh;
				}
				set
				{
					this.hideRefresh = value;
				}
			}
        
			private ParameterCollection paramNames = null;

			/// <summary>
			/// Object mapping of parameter names for load calls (defaults to {start: 'start', limit: 'limit'})
			/// </summary>
			public ParameterCollection ParamNames
			{
				get
				{
					if (this.paramNames == null)
					{
						this.paramNames = new ParameterCollection();
					}
			
					return this.paramNames;
				}
			}
			        
			private PagingToolbarListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public PagingToolbarListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new PagingToolbarListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private PagingToolbarDirectEvents directEvents = null;

			/// <summary>
			/// Server-side DirectEventHandlers
			/// </summary>
			public PagingToolbarDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new PagingToolbarDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}