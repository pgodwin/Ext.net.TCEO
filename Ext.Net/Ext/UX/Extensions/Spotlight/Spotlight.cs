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
    /// This control allows you to restrict input to a particular element by masking all other page content.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:Spotlight runat=\"server\"></{0}:Spotlight>")]
    [ToolboxBitmap(typeof(Spotlight), "Build.ToolboxIcons.Spotlight.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("This control allows you to restrict input to a particular element by masking all other page content.")]
    public partial class Spotlight : Observable, IVirtual
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Spotlight() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override List<ResourceItem> Resources
        {
            get
            {
                List<ResourceItem> baseList = base.Resources;
                baseList.Capacity += 1;

                baseList.Add(new ClientScriptItem(typeof(Spotlight), "Ext.Net.Build.Ext.Net.ux.extensions.spotlight.spotlight.js", "/ux/extensions/spotlight/spotlight.js"));

                return baseList;
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
                return "Ext.Spotlight";
            }
        }

        /// <summary>
        /// True to animate the spot (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Spotlight")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to animate the spot (defaults to true).")]
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
        /// Animation duration if animate = true (defaults to .25)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Spotlight")]
        [DefaultValue(0.25)]
        [Description("Animation duration if animate = true (defaults to .25)")]
        public virtual double Duration
        {
            get
            {
                object obj = this.ViewState["Duration"];
                return (obj == null) ? 0.25 : (double)obj;
            }
            set
            {
                this.ViewState["Duration"] = value;
            }
        }

        /// <summary>
        /// Animation easing if animate = true (defaults to 'easeNone')
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToCamelLower)]
        [Category("3. Spotlight")]
        [DefaultValue(Easing.EaseNone)]
        [Description("Animation easing if animate = true (defaults to 'easeNone')")]
        public virtual Easing Easing
        {
            get
            {
                object obj = this.ViewState["Easing"];
                return (obj == null) ? Easing.EaseNone : (Easing)obj;
            }
            set
            {
                this.ViewState["Easing"] = value;
            }
        }


        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        [Meta]
        [Description("")]
        public virtual void Show(string id)
        {
            this.Call("show");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        [Meta]
        [Description("")]
        public virtual void Show(XControl control)
        {
            this.Call("show", new JRawValue(control.ClientID));
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Description("")]
        public virtual void Hide()
        {
            this.Call("hide");
        }
    }
}