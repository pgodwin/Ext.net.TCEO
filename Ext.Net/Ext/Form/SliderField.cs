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
using System.Text;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// Wraps a Slider so it can be used as a form field.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:SliderField runat=\"server\" />")]
    [SupportsEventValidation]
    [Designer(typeof(EmptyDesigner))]
    [ToolboxBitmap(typeof(SliderField), "Build.ToolboxIcons.Slider.bmp")]
    [Description("Basic Label field.")]
    public partial class SliderField : Field
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public SliderField() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.form.SliderField";
            }
        }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "sliderfield";
            }
        }

        private Slider slider;

        /// <summary>
        /// Slider object config
        /// </summary>
        [Meta]
        [ConfigOption("slider", typeof(LazyControlJsonConverter))]
        [Category("5. SliderField")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Slider object config")]
        public Slider Slider
        {
            get
            {
                if(this.slider == null)
                {
                    this.slider = new Slider();
                }

                return this.slider;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void CreateChildControls()
        {
            this.Controls.Add(this.Slider);
            this.LazyItems.Add(this.Slider);
        }
    }
}