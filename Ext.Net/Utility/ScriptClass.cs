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
using System.Text;
using System.Web;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public abstract partial class ScriptClass : IScriptable, IResourceManager
    {
        /*  IScriptable
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual string InstanceOf
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public abstract string ToScript();

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void Render()
        {
            this.AddScript(this.ToScript());
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void Call(string name)
        {
            this.Call(name, null);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void Call(string name, params object[] args)
        {
            string tpl = this.InstanceOf.IsEmpty() ? "{1}({2});" : "{0}.{1}({2});";
            this.CallTemplate(tpl, name, args);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void Set(string name, object value)
        {
            string tpl = this.InstanceOf.IsEmpty() ? "{1}={2};" : "{0}.{1}={2};";
            this.CallTemplate(tpl, name, value);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("Adds the script to be be called on the client. The script is formatted using the template and args.")]
        public virtual void AddScript(string template, params object[] args)
        {
            this.AddScript(string.Format(template, args));
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void AddScript(string script)
        {
            if (this.Page != null && this.ResourceManager != null)
            {
                this.ResourceManager.AddScript(script);

                return;
            }

            ResourceManager.AddInstanceScript(script);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void CallTemplate(string template, string name, params object[] args)
        {
            string s = this.FormatArgs(args);

            this.AddScript(template, this.InstanceOf, name, s);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual string FormatCall(string name, params object[] args)
        {
            return "{0}.{1}({2});".FormatWith(this.InstanceOf, name, this.FormatArgs(args));
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual string FormatCallTemplate(string template, string name, params object[] args)
        {
            return template.FormatWith(this.InstanceOf, name, this.FormatArgs(args));
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual string FormatArgs(object[] args)
        {
            StringBuilder sb = new StringBuilder();

            if (args != null && args.Length > 0)
            {
                foreach (object arg in args)
                {
                    if (arg is string)
                    {
                        sb.AppendFormat("{0},", TokenUtils.ParseAndNormalize(arg.ToString(), this.ResourceManager));
                    }
                    else
                    {
                        sb.AppendFormat("{0},", JSON.Serialize(arg));
                    }
                }
            }

            return sb.ToString().LeftOfRightmostOf(',');
        }


        /*  IResourceManager
            -----------------------------------------------------------------------------------------------*/

        private Page page;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual Page Page
        {
            get
            {
                if (this.page == null && this.ResourceManager != null)
                {
                    this.page = this.ResourceManager.Page;
                }

                return this.page;
            }
        }

        private ResourceManager resourceManager;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual ResourceManager ResourceManager
        {
            get
            {
                if (this.resourceManager == null)
                {
                    this.resourceManager = ResourceManager.GetInstance(HttpContext.Current);
                }

                return this.resourceManager;
            }
        }
    }
}