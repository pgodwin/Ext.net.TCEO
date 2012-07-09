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

using System.Web.UI;
using System.ComponentModel;

namespace Ext.Net
{
    /*  Abstract
        -----------------------------------------------------------------------------------------------*/
    public abstract partial class XControl
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public partial class Builder<TComponent, TBuilder> 
            : ControlBuilder<TComponent, TBuilder>, IXControlBuilder<TComponent>
            where TComponent : XControl
            where TBuilder : XControl.Builder<TComponent, TBuilder>
        {
            /// <summary>
            /// 
            /// </summary>
            [Description("")]
            public Builder(TComponent control) : base(control) { }


            /*  Properties
                -----------------------------------------------------------------------------------------------*/

            /// <summary>
            /// An itemId can be used as an alternative way to get a reference to a component when no object reference is available.
            /// </summary>
            /// <param name="itemId">The ItemID to assign to the Component.</param>
            /// <returns>ControlBuilder</returns>
            public virtual TBuilder ItemID(string itemId)
            {
                this.ToComponent().ItemID = itemId;
                return this as TBuilder;
            }


            /*  Methods
                -----------------------------------------------------------------------------------------------*/

            /// <summary>
            /// 
            /// </summary>
            [Description("")]
            public virtual string ToScript()
            {
                return this.ToComponent().ToScript();
            }

            /// <summary>
            /// 
            /// </summary>
            [Description("")]
            public virtual void Render()
            {
                this.ToComponent().Render();
            }

            /// <summary>
            /// 
            /// </summary>
            [Description("")]
            public override void Render(Control control)
            {
                this.ToComponent().Render(control);
            }

            /// <summary>
            /// 
            /// </summary>
            [Description("")]
            public virtual void Render(string element, RenderMode mode)
            {
                this.ToComponent().Render(element, mode);
            }

            /// <summary>
            /// 
            /// </summary>
            [Description("")]
            public virtual void Render(Control control, RenderMode mode)
            {
                this.ToComponent().Render(control, mode);
            }

            /// <summary>
            /// 
            /// </summary>
            [Description("")]
            public virtual void Render(string element, RenderMode mode, bool selfRendering)
            {
                this.ToComponent().Render(element, mode, selfRendering);
            }

            /// <summary>
            /// 
            /// </summary>
            [Description("")]
            public virtual void Render(Control control, RenderMode mode, bool selfRendering)
            {
                this.ToComponent().Render(control, mode, selfRendering);
            }

            /// <summary>
            /// 
            /// </summary>
            [Description("")]
            public virtual void AddTo(string element)
            {
                this.ToComponent().Render(element, RenderMode.AddTo);
            }

            /// <summary>
            /// 
            /// </summary>
            [Description("")]
            public virtual void AddTo(Control control)
            {
                this.ToComponent().Render(control, RenderMode.AddTo);
            }

            /// <summary>
            /// 
            /// </summary>
            [Description("")]
            public virtual void AddTo(string element, bool selfRendering)
            {
                this.ToComponent().Render(element, RenderMode.AddTo, selfRendering);
            }

            /// <summary>
            /// 
            /// </summary>
            [Description("")]
            public virtual void AddTo(Control control, bool selfRendering)
            {
                this.ToComponent().Render(control, RenderMode.AddTo, selfRendering);
            }

            /// <summary>
            /// Adds the script to be be called on the client.
            /// </summary>
            /// <param name="script">The script</param>
            [Description("Adds the script to be be called on the client.")]
            public virtual TBuilder AddScript(string script)
            {
                this.ToComponent().AddScript(script);
                return this as TBuilder;
            }

            /// <summary>
            /// Adds the script to be be called on the client. The script is formatted using the template and args.
            /// </summary>
            /// <param name="template">The script string template</param>
            /// <param name="args">The arguments to use with the template</param>
            [Description("Adds the script to be be called on the client. The script is formatted using the template and args.")]
            public virtual TBuilder AddScript(string template, params object[] args)
            {
                this.ToComponent().AddScript(template, args);
                return this as TBuilder;
            }

            public virtual TBuilder Set(string name, object value)
            {
                this.ToComponent().Set(ScriptPosition.Auto, name, value);
                return this as TBuilder;
            }

            public virtual TBuilder Set(ScriptPosition position, string name, object value)
            {
                this.ToComponent().CallTemplate(position, XControl.SETEMPLATE, name, value);
                return this as TBuilder;
            }

            public virtual TBuilder Call(string name)
            {
                this.ToComponent().Call(name, null);
                return this as TBuilder;
            }

            public virtual TBuilder Call(string name, params object[] args)
            {
                this.ToComponent().Call(ScriptPosition.Auto, name, args);
                return this as TBuilder;
            }

            public virtual TBuilder Call(ScriptPosition mode, string name, params object[] args)
            {
                this.ToComponent().CallTemplate(mode, XControl.CALLTEMPLATE, name, args);
                return this as TBuilder;
            }
        }
    }
}