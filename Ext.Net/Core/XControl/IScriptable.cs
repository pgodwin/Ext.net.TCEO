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
using System.ComponentModel;
using System.Text;

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
    public partial class XControl : IScriptable
    {
        /*  IScriptable
            -----------------------------------------------------------------------------------------------*/

        const string SETEMPLATE= "{0}.{1}={2};";
        const string CALLTEMPLATE = "{0}.{1}({2});";

        private bool isProxy;

        internal virtual bool IsProxy
        {
            get { return this.isProxy; }
            set { this.isProxy = value; }
        }

        private bool generateMethodsCalling;
        internal virtual bool GenerateMethodsCalling
        {
            get { return this.generateMethodsCalling; }
            set { this.generateMethodsCalling = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual string InstanceOf
        {
            get { return ""; }
        }

        private string directScript;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public virtual string ToConfig()
        {
            return ConfigScriptBuilder.Create(this).Build();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        [Description("")]
        public virtual string ToConfig(LazyMode mode)
        {
            return ConfigScriptBuilder.Create(this).Build(mode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selfRendering"></param>
        /// <returns></returns>
        [Description("")]
        public virtual string ToScript(bool selfRendering)
        {
            if (this.AlreadyRendered && this.directScript != null)
            {
                return this.directScript;
            }

            this.directScript = DefaultScriptBuilder.Create(this).Build(selfRendering);

            return this.directScript;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public virtual string ToScript()
        {
            return this.ToScript(this.Page == null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        [Description("")]
        public string ToScript(RenderMode mode, string element)
        {
            return this.ToScript(mode, element, this.Page == null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="element"></param>
        /// <param name="selfRendering"></param>
        /// <returns></returns>
        [Description("")]
        public string ToScript(RenderMode mode, string element, bool selfRendering)
        {
            if (this.AlreadyRendered)
            {
                return this.directScript;
            }

            this.directScript = DefaultScriptBuilder.Create(this).Build(mode, element, selfRendering);

            return this.directScript;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="element"></param>
        /// <param name="index">Index</param>
        /// <returns></returns>
        [Description("")]
        public string ToScript(RenderMode mode, string element, int index)
        {
            return this.ToScript(mode, element, index, this.Page == null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="element"></param>
        /// <param name="index"></param>
        /// <param name="selfRendering"></param>
        /// <returns></returns>
        [Description("")]
        public string ToScript(RenderMode mode, string element, int index, bool selfRendering)
        {
            if (this.AlreadyRendered)
            {
                return this.directScript;
            }

            this.directScript = DefaultScriptBuilder.Create(this).Build(mode, element, index, selfRendering);

            return this.directScript;
        }

        /// <summary>
        /// Adds the script to be be called on the client.
        /// </summary>
        /// <param name="script">The script</param>
        [Description("Adds the script to be be called on the client.")]
        public virtual void AddScript(string script)
        {
            if (script.IsNotEmpty() && !this.IsParentDeferredRender && this.Visible)
            {
                if (this.AlreadyRendered && this.HasResourceManager)
                {
                    this.ResourceManager.RegisterOnReadyScript(ResourceManager.ScriptOrderNumber, TokenUtils.ReplaceRawToken(TokenUtils.ParseTokens(script, this)));
                }
                else
                {
                    this.ProxyScripts.Add(ResourceManager.ScriptOrderNumber, TokenUtils.ReplaceRawToken(TokenUtils.ParseTokens(script, this)));    
                }
            }
        }

        /// <summary>
        /// Adds the script to be be called on the client. The script is formatted using the template and args.
        /// </summary>
        /// <param name="template">The script string template</param>
        /// <param name="args">The arguments to use with the template</param>
        [Description("Adds the script to be be called on the client. The script is formatted using the template and args.")]
        public virtual void AddScript(string template, params object[] args)
        {
            this.AddScript(template.FormatWith(args));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        [Description("")]
        public virtual void Set(string name, object value)
        {
            this.Set(ScriptPosition.Auto, name, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        [Description("")]
        public virtual void Set(ScriptPosition position, string name, object value)
        {
            this.CallTemplate(position, XControl.SETEMPLATE, name, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        [Description("")]
        public virtual void Call(string name)
        {
            this.Call(name, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="args"></param>
        [Description("")]
        public virtual void Call(string name, params object[] args)
        {
            this.Call(ScriptPosition.Auto, name, args);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="name"></param>
        /// <param name="args"></param>
        [Description("")]
        public virtual void Call(ScriptPosition mode, string name, params object[] args)
        {
            this.CallTemplate(mode, XControl.CALLTEMPLATE, name, args);
        }


        /*  Protected
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="template"></param>
        [Description("")]
        protected virtual void CallTemplate(string template)
        {
            this.CallTemplate(template, "");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="template"></param>
        /// <param name="name"></param>
        /// <param name="args"></param>
        [Description("")]
        protected virtual void CallTemplate(string template, string name, params object[] args)
        {
            this.CallTemplate(ScriptPosition.Auto, template, name, args);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="template"></param>
        /// <param name="name"></param>
        /// <param name="args"></param>
        [Description("")]
        protected virtual void CallTemplate(ScriptPosition position, string template, string name, params object[] args)
        {
            StringBuilder sb = new StringBuilder();

            if (args != null && args.Length > 0)
            {
                foreach (object arg in args)
                {
                    if (arg is string)
                    {
                        sb.AppendFormat("{0},", TokenUtils.ParseAndNormalize(arg.ToString(), this.SafeResourceManager  ));
                    }
                    else
                    {
                        sb.AppendFormat("{0},", JSON.Serialize(arg, JSON.AltConvertersInternal));
                    }
                }
            }

            string script = template.FormatWith(this.CallID, name, sb.ToString().LeftOfRightmostOf(','));

            switch (position)
            {
                case ScriptPosition.BeforeInit:
                    this.ResourceManager.RegisterBeforeClientInitScript(script);
                    break;
                case ScriptPosition.AfterInit:
                    this.ResourceManager.RegisterAfterClientInitScript(script);
                    break;
                default:
                    this.AddScript(script);
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual string CallID
        {
            get
            {
                return this.ClientID;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public enum ScriptPosition
    {
        /// <summary>
        /// 
        /// </summary>
        BeforeInit,

        /// <summary>
        /// 
        /// </summary>
        AfterInit,

        /// <summary>
        /// 
        /// </summary>
        Auto
    }
}