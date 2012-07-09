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
using System.Web.UI.WebControls;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public abstract partial class SliderBase : BoxComponentBase
    {
        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "slider";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.Slider";
            }
        }

        /// <summary>
        /// The Number (int) to initialize this field with.
        /// </summary>
        [Meta]
        [Category("Appearance")]
        [DefaultValue(int.MinValue)]
        [Bindable(true, BindingDirection.TwoWay)]
        [DirectEventUpdate(MethodName = "SetValueProxy")]
        [Description("The Number (int) to initialize this field with.")]
        public virtual int Value
        {
            get
            {
                object obj = this.ViewState["Value"];
                return (obj == null) ? int.MinValue : (int)obj;
            }
            set
            {
                this.ViewState["Value"] = value;
            }
        }

        /// <summary>
        /// Thumbs values array
        /// </summary>
        [ConfigOption("values", typeof(IntArrayJsonConverter))]
        [TypeConverter(typeof(IntArrayConverter))]
        [DefaultValue(null)]
        [Description("Thumbs values list")]
        public virtual int[] Values
        {
            get
            {
                object obj = this.ViewState["Values"];
                return (obj == null) ? null : (int[])obj;
            }
            set
            {
                this.ViewState["Values"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("value", JsonMode.Raw)]
        [DefaultValue(int.MinValue)]
        [Description("")]
        protected virtual int ValueProxy
        {
            get
            {
                if (this.Value == int.MinValue || (this.Values != null && this.Values.Length > 1))
                {
                    return int.MinValue;
                }

                return this.Value;
            }
        }
        
        /// <summary>
        /// Turn on or off animation. Defaults to true
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Slider")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Turn on or off animation. Defaults to true")]
        public virtual bool Animate
        {
            get
            {
                object obj = this.ViewState["Animate"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["Animate"] = value;
            }
        }

        /// <summary>
        /// Determines whether or not clicking on the Slider axis will change the slider. Defaults to true
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Slider")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Determines whether or not clicking on the Slider axis will change the slider. Defaults to true")]
        public virtual bool ClickToChange
        {
            get
            {
                object obj = this.ViewState["ClickToChange"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["ClickToChange"] = value;
            }
        }

        /// <summary>
        /// True to disallow thumbs from overlapping one another. Defaults to true
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Slider")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to disallow thumbs from overlapping one another. Defaults to true")]
        public virtual bool ConstrainThumbs
        {
            get
            {
                object obj = this.ViewState["ConstrainThumbs"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["ConstrainThumbs"] = value;
            }
        }

        /// <summary>
        /// The number of decimal places to which to round the Slider's value. Defaults to 0.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Slider")]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [Description("The number of decimal places to which to round the Slider's value. Defaults to 0.")]
        public virtual int DecimalPrecision
        {
            get
            {
                object obj = this.ViewState["DecimalPrecision"];
                return (obj == null) ? 0 : (int)obj;
            }
            set
            {
                this.ViewState["DecimalPrecision"] = value;
            }
        }

        /// <summary>
        /// How many units to change the slider when adjusting by drag and drop. Use this option to enable 'snapping'.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Slider")]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [Description("How many units to change the slider when adjusting by drag and drop. Use this option to enable 'snapping'.")]
        public virtual int Increment
        {
            get
            {
                object obj = this.ViewState["Increment"];
                return (obj == null) ? 0 : (int)obj;
            }
            set
            {
                this.ViewState["Increment"] = value;
            }
        }

        /// <summary>
        /// How many units to change the Slider when adjusting with keyboard navigation. Defaults to 1. If the increment config is larger, it will be used instead.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Slider")]
        [DefaultValue(1)]
        [NotifyParentProperty(true)]
        [Description("How many units to change the Slider when adjusting with keyboard navigation. Defaults to 1. If the increment config is larger, it will be used instead.")]
        public virtual int KeyIncrement
        {
            get
            {
                object obj = this.ViewState["KeyIncrement"];
                return (obj == null) ? 1 : (int)obj;
            }
            set
            {
                this.ViewState["KeyIncrement"] = value;
            }
        }

        /// <summary>
        /// The maximum value for the Slider. Defaults to 100.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Slider")]
        [DefaultValue(100)]
        [NotifyParentProperty(true)]
        [Description("The maximum value for the Slider. Defaults to 100.")]
        public virtual int MaxValue
        {
            get
            {
                object obj = this.ViewState["MaxValue"];
                return (obj == null) ? 100 : (int)obj;
            }
            set
            {
                this.ViewState["MaxValue"] = value;
            }
        }

        /// <summary>
        /// The minimum value for the Slider. Defaults to 0.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Slider")]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [Description("The minimum value for the Slider. Defaults to 0.")]
        public virtual int MinValue
        {
            get
            {
                object obj = this.ViewState["MinValue"];
                return (obj == null) ? 0 : (int)obj;
            }
            set
            {
                this.ViewState["MinValue"] = value;
            }
        }

        /// <summary>
        /// Orient the Slider vertically rather than horizontally, defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Slider")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Orient the Slider vertically rather than horizontally, defaults to false.")]
        public virtual bool Vertical
        {
            get
            {
                object obj = this.ViewState["Vertical"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Vertical"] = value;
            }
        }

        /// <summary>
        /// The number used to set the z index of the top thumb
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Slider")]
        [DefaultValue(10000)]
        [NotifyParentProperty(true)]
        [Description("The number used to set the z index of the top thumb")]
        public virtual int TopThumbZIndex
        {
            get
            {
                object obj = this.ViewState["TopThumbZIndex"];
                return (obj == null) ? 10000 : (int)obj;
            }
            set
            {
                this.ViewState["TopThumbZIndex"] = value;
            }
        }

        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void SetValueProxy(int value)
        {
            this.Call("setValue", 0, value);
        }

        /// <summary>
        /// Programmatically sets the value of the Slider. Ensures that the value is constrained within the minValue and maxValue.
        /// </summary>
        /// <param name="value">The value to set the slider to. (This will be constrained within minValue and maxValue)</param>
        [Meta]
        [Description("Programmatically sets the value of the Slider. Ensures that the value is constrained within the minValue and maxValue.")]
        public virtual void SetValue(int value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Programmatically sets the value of the Slider. Ensures that the value is constrained within the minValue and maxValue.
        /// </summary>
        /// <param name="index">Index of the thumb to move</param>
        /// <param name="value">The value to set the slider to. (This will be constrained within minValue and maxValue)</param>
        [Meta]
        [Description("Programmatically sets the value of the Slider. Ensures that the value is constrained within the minValue and maxValue.")]
        public virtual void SetValue(int index, int value)
        {
            this.SetValue(index, value, true);
        }

        /// <summary>
        /// Programmatically sets the value of the Slider. Ensures that the value is constrained within the minValue and maxValue.
        /// </summary>
        /// <param name="value">The value to set the slider to. (This will be constrained within minValue and maxValue)</param>
        /// <param name="animate">Turn on or off animation, defaults to true</param>
        [Meta]
        [Description("Programmatically sets the value of the Slider. Ensures that the value is constrained within the minValue and maxValue.")]
        public virtual void SetValue(int value, bool animate)
        {
            this.SuspendScripting();
            this.Value = value;
            this.ResumeScripting();

            this.Call("setValue", 0, value, animate);
        }

        /// <summary>
        /// Programmatically sets the value of the Slider. Ensures that the value is constrained within the minValue and maxValue.
        /// </summary>
        /// <param name="index">Index of the thumb to move</param>
        /// <param name="value">The value to set the slider to. (This will be constrained within minValue and maxValue)</param>
        /// <param name="animate">Turn on or off animation, defaults to true</param>
        [Meta]
        [Description("Programmatically sets the value of the Slider. Ensures that the value is constrained within the minValue and maxValue.")]
        public virtual void SetValue(int index, int value, bool animate)
        {
            this.SuspendScripting();
            this.Value = value;
            this.ResumeScripting();

            this.Call("setValue", index, value, animate);
        }

        /// <summary>
        /// Synchronizes the thumb position to the proper proportion of the total component width based on the current slider value. This will be called automatically when the Slider is resized by a layout, but if it is rendered auto width, this method can be called from another resize handler to sync the Slider if necessary.
        /// </summary>
        [Meta]
        [Description("Synchronizes the thumb position to the proper proportion of the total component width based on the current slider value. This will be called automatically when the Slider is resized by a layout, but if it is rendered auto width, this method can be called from another resize handler to sync the Slider if necessary.")]
        public virtual void SyncThumb()
        {
            this.Call("syncThumb");
        }

        /// <summary>
        /// Creates a new thumb and adds it to the slider
        /// </summary>
        [Meta]
        [Description("Creates a new thumb and adds it to the slider")]
        public virtual void AddThumb(int value)
        {
            this.Call("addThumb", value);
        }
    }
}