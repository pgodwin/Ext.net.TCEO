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
	/// 
	/// </summary>
	[Description("")]
    public partial class FileUploadFieldDirectEvents : TextFieldDirectEvents
    {
        private ComponentDirectEvent fileSelected;

        /// <summary>
        /// Fires when the underlying file input field's value has changed from the user selecting a new file from the system file selection dialog.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "This file upload field")]
        [ListenerArgument(1, "value", typeof(int), "The file value returned by the underlying file input field")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("fileselected", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the underlying file input field's value has changed from the user selecting a new file from the system file selection dialog.")]
        public virtual ComponentDirectEvent FileSelected
        {
            get
            {
                if (this.fileSelected == null)
                {
                    this.fileSelected = new ComponentDirectEvent();
                }

                return this.fileSelected;
            }
        }
    }
}