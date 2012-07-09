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
    [Meta]
    public abstract partial class CheckboxBase : Field
    {
        /*  Public Properties
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// The text that appears beside the checkbox (defaults to '').
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetBoxLabel")]
        [Category("6. Checkbox")]
        [DefaultValue("")]
        [Description("The text that appears beside the checkbox (defaults to '').")]
        public virtual string BoxLabel
        {
            get
            {
                return (string)this.ViewState["BoxLabel"] ?? "";
            }
            set
            {
                this.ViewState["BoxLabel"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetBoxLabelStyle")]
        [Category("6. Checkbox")]
        [DefaultValue("")]
        [Description("")]
        public virtual string BoxLabelStyle
        {
            get
            {
                return (string)this.ViewState["BoxLabelStyle"] ?? "";
            }
            set
            {
                this.ViewState["BoxLabelStyle"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetBoxLabelCls")]
        [Category("6. Checkbox")]
        [DefaultValue("")]
        [Description("")]
        public virtual string BoxLabelCls
        {
            get
            {
                return (string)this.ViewState["BoxLabelCls"] ?? "";
            }
            set
            {
                this.ViewState["BoxLabelCls"] = value;
            }
        }

        /// <summary>
        /// True if the checkbox should render already checked (defaults to false).
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "SetValue")]
        [DefaultValue(false)]
        [Category("6. Checkbox")]
        [Bindable(true, BindingDirection.TwoWay)]
        [Description("True if the checkbox should render already checked (defaults to false).")]
        public virtual bool Checked
        {
            get
            {
                object obj = this.Value;
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.Value = value;
            }
        }

        /// <summary>
        /// The CSS class to use when the control is checked (defaults to 'x-form-check-checked'). Note that this class applies to both checkboxes and radio buttons and is added to the control's wrapper element.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Checkbox")]
        [DefaultValue("x-form-check-checked")]
        [Description("The CSS class to use when the control is checked (defaults to 'x-form-check-checked'). Note that this class applies to both checkboxes and radio buttons and is added to the control's wrapper element.")]
        public virtual string CheckedCls
        {
            get
            {
                return (string)this.ViewState["CheckedCls"] ?? "x-form-check-checked";
            }
            set
            {
                this.ViewState["CheckedCls"] = value;
            }
        }

        /// <summary>
        /// The CSS class to use when the control receives input focus (defaults to 'x-form-check-focus'). Note that this class applies to both checkboxes and radio buttons and is added to the control's wrapper element.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Checkbox")]
        [DefaultValue("x-form-check-focus")]
        [Description("The CSS class to use when the control receives input focus (defaults to 'x-form-check-focus'). Note that this class applies to both checkboxes and radio buttons and is added to the control's wrapper element.")]
        public virtual string FocusCls
        {
            get
            {
                return (string)this.ViewState["FocusCls"] ?? "x-form-check-focus";
            }
            set
            {
                this.ViewState["FocusCls"] = value;
            }
        }

        /// <summary>
        /// The value that should go into the generated input element's value attribute (defaults to undefined, with no value attribute)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Checkbox")]
        [DefaultValue("")]
        [Description("The value that should go into the generated input element's value attribute (defaults to undefined, with no value attribute)")]
        public virtual string InputValue
        {
            get
            {
                if (this.DesignMode && this.ViewState["InputValue"] == null)
                {
                    return "";
                }

                return (string)this.ViewState["InputValue"] ?? this.ClientID;
            }
            set
            {
                this.ViewState["InputValue"] = value;
            }
        }

        /// <summary>
        /// The CSS class to use when the control is being actively clicked (defaults to 'x-form-check-down'). Note that this class applies to both checkboxes and radio buttons and is added to the control's wrapper element.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Checkbox")]
        [DefaultValue("x-form-check-down")]
        [Description("The CSS class to use when the control is being actively clicked (defaults to 'x-form-check-down'). Note that this class applies to both checkboxes and radio buttons and is added to the control's wrapper element.")]
        public virtual string MouseDownCls
        {
            get
            {
                return (string)this.ViewState["MouseDownCls"] ?? "x-form-check-down";
            }
            set
            {
                this.ViewState["MouseDownCls"] = value;
            }
        }

        /// <summary>
        /// An optional extra CSS class that will be added to this component's Element when the mouse moves over the Element, and removed when the mouse moves out. (defaults to ''). This can be useful for adding customized 'active' or 'hover' styles to the component or any of its children using standard CSS rules.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Checkbox")]
        [DefaultValue("x-form-check-over")]
        [Description("The CSS class to use when the control is hovered over (defaults to 'x-form-check-over'). Note that this class applies to both checkboxes and radio buttons and is added to the control's wrapper element.")]
        public override string OverCls
        {
            get
            {
                return (string)this.ViewState["OverCls"] ?? "x-form-check-over";
            }
            set
            {
                this.ViewState["OverCls"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Checkbox")]
        [DefaultValue("")]
        public virtual string Tag
        {
            get
            {
                return (string)this.ViewState["Tag"] ?? "";
            }
            set
            {
                this.ViewState["Tag"] = value;
            }
        }


        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        [DefaultValue("")]
        protected virtual void SetBoxLabel(string value)
        {
            this.Call("setBoxLabel", value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        [DefaultValue("")]
        protected virtual void SetBoxLabelStyle(string value)
        {
            this.Call("setBoxLabelStyle", value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        [DefaultValue("")]
        protected virtual void SetBoxLabelCls(string value)
        {
            this.Call("setBoxLabelCls", value);
        }
    }
}