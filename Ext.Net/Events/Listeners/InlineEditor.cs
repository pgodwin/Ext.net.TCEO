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
    public partial class InlineEditorListeners : ComponentBaseListeners
    {
        private ComponentListener beforestartedit;

        /// <summary>
        /// 
        /// </summary>
        [ListenerArgument(0, "editor")]
        [ListenerArgument(1, "boundEl")]
        [ListenerArgument(2, "value")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforestartedit", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener BeforeStartEdit
        {
            get
            {
                if (this.beforestartedit == null)
                {
                    this.beforestartedit = new ComponentListener();
                }

                return this.beforestartedit;
            }
        }

        private ComponentListener beforecomplete;

        /// <summary>
        /// 
        /// </summary>
        [ListenerArgument(0, "editor")]
        [ListenerArgument(1, "value")]
        [ListenerArgument(2, "startValue")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforecomplete", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener BeforeComplete
        {
            get
            {
                if (this.beforecomplete == null)
                {
                    this.beforecomplete = new ComponentListener();
                }

                return this.beforecomplete;
            }
        }

        private ComponentListener canceledit;

        /// <summary>
        /// 
        /// </summary>
        [ListenerArgument(0, "editor")]
        [ListenerArgument(1, "value")]
        [ListenerArgument(2, "startValue")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("canceledit", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener CancelEdit
        {
            get
            {
                if (this.canceledit == null)
                {
                    this.canceledit = new ComponentListener();
                }

                return this.canceledit;
            }
        }

        private ComponentListener complete;

        /// <summary>
        /// 
        /// </summary>
        [ListenerArgument(0, "editor")]
        [ListenerArgument(1, "value")]
        [ListenerArgument(2, "startValue")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("complete", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener Complete
        {
            get
            {
                if (this.complete == null)
                {
                    this.complete = new ComponentListener();
                }

                return this.complete;
            }
        }

        private ComponentListener specialkey;

		/// <summary>
		/// 
		/// </summary>
        [ListenerArgument(0, "field")]
        [ListenerArgument(1, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("specialkey", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
		[Description("")]
        public virtual ComponentListener SpecialKey
        {
            get
            {
                if (this.specialkey == null)
                {
                    this.specialkey = new ComponentListener();
                }

                return this.specialkey;
            }
        }

        private ComponentListener startedit;

		/// <summary>
		/// 
		/// </summary>
        [ListenerArgument(0, "boundEl")]
        [ListenerArgument(1, "value")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("startedit", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
		[Description("")]
        public virtual ComponentListener StartEdit
        {
            get
            {
                if (this.startedit == null)
                {
                    this.startedit = new ComponentListener();
                }

                return this.startedit;
            }
        }
    }
}