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
    /// <summary>
    /// Abstract base class for grid SelectionModels. It provides the interface that should
    /// be implemented by descendant classes. This class should not be directly instantiated.
    /// </summary>
    [Meta]
    [Description("Abstract base class for grid SelectionModels. It provides the interface that should be implemented by descendant classes. This class should not be directly instantiated.")]
    public abstract partial class AbstractSelectionModel : LazyObservable
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public abstract void UpdateSelection();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="args"></param>
        [Description("")]
        protected virtual void CallGrid(string name, params object[] args)
        {
            this.CallTemplate("if({0}.grid){{{0}.grid.{1}({2});}}", name, args);
        }

        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Locks the selections.
        /// </summary>
        [Meta]
        [Description("Locks the selections.")]
        public virtual void Lock()
        {
            this.Call("lock");
        }

        /// <summary>
        /// Unlocks the selections.
        /// </summary>
        [Meta]
        [Description("Unlocks the selections.")]
        public virtual void Unlock()
        {
            this.Call("unlock");
        }
    }
}