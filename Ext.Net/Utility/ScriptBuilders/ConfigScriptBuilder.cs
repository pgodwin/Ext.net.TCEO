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
using System.Linq;
using System.Text;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public class ConfigScriptBuilder : BaseScriptBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        [Description("")]
        public ConfigScriptBuilder(XControl control) : base(control) { }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public override string Build()
        {
            return this.Build(LazyMode.Config);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selfRendering"></param>
        /// <returns></returns>
        [Description("")]
        public override string Build(bool selfRendering)
        {
            return this.Build();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        [Description("")]
        public virtual string Build(LazyMode mode)
        {
            if (this.script == null)
            {
                Component cmp = this.Control as Component;

                if (cmp != null)
                {
                    cmp.AutoRender = false;
                }
                
                this.Control.IsDynamicLazy = true;
                this.Control.TopDynamicControl = true;

                StringBuilder sb = new StringBuilder();

                List<XControl> childControls = this.FindControls(this.Control, false, null, null);
                childControls.Insert(0, this.Control);

                foreach (XControl c in childControls)
                {
                    if (c.Visible || Object.ReferenceEquals(c, this.Control))
                    {
                        if (c.AutoDataBind)
                        {
                            c.DataBind();
                        }

                        c.OnClientInit(false);
                        c.RegisterBeforeAfterScript();
                    }
                }

                foreach (XControl c in childControls)
                {
                    if (c.Visible || Object.ReferenceEquals(c, this.Control))
                    {
                        if (Object.ReferenceEquals(c, this.Control))
                        {
                            string initScript;

                            if (this.Control is ICustomConfigSerialization)
                            {
                                initScript = ((ICustomConfigSerialization)c).ToScript(c);
                            }
                            else
                            {
                                initScript = mode == LazyMode.Instance ? "new {0}({1})".FormatWith(c.InstanceOf, c.InitialConfig) : c.InitialConfig;
                            }
                            
                            this.ScriptClientInitBag.Add(c.ClientInitID, initScript);
                        }
                        else
                        {
                            this.ScriptClientInitBag.Add(c.ClientInitID, c.BuildInitScript());
                        }
                        
                        c.AlreadyRendered = true;
                    }
                }

                if (this.ScriptClientInitBag.Count > 0)
                {
                    foreach (KeyValuePair<string, string> item in this.ScriptClientInitBag)
                    {
                        sb.Append(this.Combine(item.Key));
                    }
                }

                this.script = sb.ToString();
            }

            return this.script;
        }

        protected override void CheckResources(XControl control)
        {
        }

        protected override void CheckIcon(XControl control, List<Icon> icons)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        [Description("")]
        public static ConfigScriptBuilder Create(XControl control)
        {
            return new ConfigScriptBuilder(control);
        }
    }
}
