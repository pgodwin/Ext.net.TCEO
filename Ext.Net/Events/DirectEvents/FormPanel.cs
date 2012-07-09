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
    public partial class FormPanelDirectEvents : PanelDirectEvents
    {
        private ComponentDirectEvent clientValidation;

        /// <summary>
        /// If the monitorValid config option is true, this event fires repetitively to notify of valid state
        /// </summary>
        [ListenerArgument(0, "item", typeof(FormPanel))]
        [ListenerArgument(1, "valid")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("clientvalidation", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("If the monitorValid config option is true, this event fires repetitively to notify of valid state")]
        public virtual ComponentDirectEvent ClientValidation
        {
            get
            {
                if (this.clientValidation == null)
                {
                    this.clientValidation = new ComponentDirectEvent();
                }

                return this.clientValidation;
            }
        }

        private ComponentDirectEvent actionComplete;

        /// <summary>
        /// Fires when an action is completed.
        /// </summary>
        [ListenerArgument(0, "item", typeof(FormPanel))]
        [ListenerArgument(1, "action")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("actioncomplete", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when an action is completed.")]
        public virtual ComponentDirectEvent ActionComplete
        {
            get
            {
                if (this.actionComplete == null)
                {
                    this.actionComplete = new ComponentDirectEvent();
                }

                return this.actionComplete;
            }
        }

        private ComponentDirectEvent actionFailed;

        /// <summary>
        /// Fires when an action fails.
        /// </summary>
        [ListenerArgument(0, "item", typeof(FormPanel))]
        [ListenerArgument(1, "action")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("actionfailed", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when an action fails.")]
        public virtual ComponentDirectEvent ActionFailed
        {
            get
            {
                if (this.actionFailed == null)
                {
                    this.actionFailed = new ComponentDirectEvent();
                }

                return this.actionFailed;
            }
        }

        private ComponentDirectEvent beforeAction;

        /// <summary>
        /// Fires before any action is performed. Return false to cancel the action.
        /// </summary>
        [ListenerArgument(0, "item", typeof(FormPanel))]
        [ListenerArgument(1, "action")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeaction", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before any action is performed. Return false to cancel the action.")]
        public virtual ComponentDirectEvent BeforeAction
        {
            get
            {
                if (this.beforeAction == null)
                {
                    this.beforeAction = new ComponentDirectEvent();
                }

                return this.beforeAction;
            }
        }
    }
}