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
using System.Drawing;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// Simple plugin for using an Ext.Tip with a slider to show the slider value.
    /// </summary>
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(SliderTip), "Build.ToolboxIcons.Plugin.bmp")]
    [ToolboxData("<{0}:SliderTip runat=\"server\" />")]
    [Description("Simple plugin for using an Ext.Tip with a slider to show the slider value")]
    public partial class SliderTip : Plugin
    {
        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.slider.Tip";
            }
        }

        private JFunction getText;

        /// <summary>
        /// Used to create the text that appears in the Tip's body. By default this just returns the value of the Slider Thumb that the Tip is attached to. Override to customize.
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("3. SliderTip")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Override this function to apply custom tip text")]
        public virtual JFunction GetText
        {
            get
            {
                if(this.getText == null)
                {
                    this.getText = new JFunction();
                    if(!this.DesignMode)
                    {
                        this.getText.Args = new string[]{"thumb"};
                    }
                }
                
                return this.getText;
            }
        }
    }
}
