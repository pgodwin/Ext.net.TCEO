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

using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
    public partial class XControl
    {
        /*  ViewState
            -----------------------------------------------------------------------------------------------*/

        private ViewStateProxy viewState;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected new ViewStateProxy ViewState
        {
            get
            {
                if (this.viewState == null)
                {
                    this.viewState = new ViewStateProxy(this, base.ViewState);
                }

                return this.viewState;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void LoadViewState(object state)
        {
            object[] states = state as object[];

            if (states != null)
            {
                foreach (Pair pair in states)
                {
                    switch ((string)pair.First)
                    {
                        case "base":
                            base.LoadViewState(pair.Second);
                            break;
                        case "vsMembers":
                            ViewStateProcessor.LoadViewState(this, pair.Second);
                            break;
                    }
                }
            }
            else
            {
                base.LoadViewState(state);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override object SaveViewState()
        {
            List<Pair> state = new List<Pair>();
            object baseState = base.SaveViewState();

            if (baseState != null)
            {
                state.Add(new Pair("base", baseState));
            }

            object vsMembers = ViewStateProcessor.SaveViewState(this);

            if (vsMembers != null)
            {
                state.Add(new Pair("vsMembers", vsMembers));
            }

            return state.Count == 0 ? null : state.ToArray();
        }
    }
}