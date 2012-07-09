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
    public partial class FieldListeners : BoxComponentListeners
    {
        private ComponentListener blur;

        /// <summary>
        /// Fires when this field loses input focus.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("blur", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when this field loses input focus.")]
        public virtual ComponentListener Blur
        {
            get
            {
                if (this.blur == null)
                {
                    this.blur = new ComponentListener();
                }

                return this.blur;
            }
        }

        private ComponentListener change;

        /// <summary>
        /// Fires just before the field blurs if the field value has changed.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "this")]
        [ListenerArgument(1, "newValue", typeof(object), "The new value")]
        [ListenerArgument(2, "oldValue", typeof(object), "The original value")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("change", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires just before the field blurs if the field value has changed.")]
        public virtual ComponentListener Change
        {
            get
            {
                if (this.change == null)
                {
                    this.change = new ComponentListener();
                }

                return this.change;
            }
        }

        private ComponentListener focus;

        /// <summary>
        /// Fires when this field receives input focus.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("focus", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when this field receives input focus.")]
        public virtual ComponentListener Focus
        {
            get
            {
                if (this.focus == null)
                {
                    this.focus = new ComponentListener();
                }

                return this.focus;
            }
        }

        private ComponentListener invalid;

        /// <summary>
        /// Fires after the field has been marked as invalid.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "this")]
        [ListenerArgument(1, "msg", typeof(string), "the validation message")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("invalid", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the field has been marked as invalid.")]
        public virtual ComponentListener Invalid
        {
            get
            {
                if (this.invalid == null)
                {
                    this.invalid = new ComponentListener();
                }

                return this.invalid;
            }
        }

        private ComponentListener specialKey;

        /// <summary>
        /// Fires when any key related to navigation (arrows, tab, enter, esc, etc.) is pressed.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "this")]
        [ListenerArgument(1, "e", typeof(object), "The event object")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("specialkey", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when any key related to navigation (arrows, tab, enter, esc, etc.) is pressed.")]
        public virtual ComponentListener SpecialKey
        {
            get
            {
                if (this.specialKey == null)
                {
                    this.specialKey = new ComponentListener();
                }

                return this.specialKey;
            }
        }

        private ComponentListener valid;

        /// <summary>
        /// Fires after the field has been validated with no errors.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("valid", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the field has been validated with no errors.")]
        public virtual ComponentListener Valid
        {
            get
            {
                if (this.valid == null)
                {
                    this.valid = new ComponentListener();
                }

                return this.valid;
            }
        }

        private ComponentListener remoteValidationFailure;

        /// <summary>
        ///
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "this")]
        [ListenerArgument(1, "response", typeof(object), "")]
        [ListenerArgument(2, "e", typeof(Field), "")]
        [ListenerArgument(3, "o", typeof(Field), "")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("remotevalidationfailure", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener RemoteValidationFailure
        {
            get
            {
                if (this.remoteValidationFailure == null)
                {
                    this.remoteValidationFailure = new ComponentListener();
                }

                return this.remoteValidationFailure;
            }
        }

        private ComponentListener remoteValidationValid;

        /// <summary>
        ///
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "this")]        
        [ListenerArgument(1, "response", typeof(object), "")]
        [ListenerArgument(2, "responseObject", typeof(object), "")]
        [ListenerArgument(3, "result", typeof(object), "")]
        [ListenerArgument(4, "o", typeof(Field), "")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("remotevalidationvalid", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener RemoteValidationValid
        {
            get
            {
                if (this.remoteValidationValid == null)
                {
                    this.remoteValidationValid = new ComponentListener();
                }

                return this.remoteValidationValid;
            }
        }

        private ComponentListener remoteValidationInvalid;

        /// <summary>
        ///
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "this")]
        [ListenerArgument(1, "response", typeof(object), "")]
        [ListenerArgument(2, "responseObject", typeof(object), "")]
        [ListenerArgument(3, "result", typeof(object), "")]
        [ListenerArgument(4, "o", typeof(Field), "")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("remotevalidationinvalid", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener RemoteValidationInvalid
        {
            get
            {
                if (this.remoteValidationInvalid == null)
                {
                    this.remoteValidationInvalid = new ComponentListener();
                }

                return this.remoteValidationInvalid;
            }
        }

        private ComponentListener beforeRemoteValidation;

        /// <summary>
        ///
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "this")]
        [ListenerArgument(1, "options", typeof(object), "")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeremotevalidation", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener BeforeRemoteValidation
        {
            get
            {
                if (this.beforeRemoteValidation == null)
                {
                    this.beforeRemoteValidation = new ComponentListener();
                }

                return this.beforeRemoteValidation;
            }
        }
    }
}