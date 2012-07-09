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
using System.Web;
using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class Debug : ScriptClass
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.net.Debug";
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string ToScript()
        {
            return "";
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void CallDebug(string name, params object[] args)
        {
            this.Call(name, args);
        }

        /// <summary>
        /// Show message in console
        /// </summary>
        /// <param name="text">Log message</param>
        public static void Log(string text)
        {
            new Debug().Call("log", text);
        }

        /// <summary>
        /// Show the debug console (should be activated before it, using Debug property of ResourceManager or Debug.Activate function)
        /// </summary>
        public static void Show()
        {
            new Debug().Call("show");
        }

        /// <summary>
        /// Hide the debug console
        /// </summary>
        public static void Hide()
        {
            new Debug().Call("hide");
        }

        /// <summary>
        /// Add required resources and activate console
        /// </summary>
        /// <param name="module">Console type</param>
        /// <param name="callback">callback which fires after console activating</param>
        public static void Activate(DebugConsole module, JFunction callback)
        {
            
            Debug debug = new Debug();
            string scriptUrl = debug.ResourceManager.GetWebResourceUrl(ResourceManager.ASSEMBLYSLUG + ".ux.extensions.debug.Debug.js");
            string activate = "function(){{Ext.net.Debug.activate({0}{1});}}".FormatWith(new DebugDescriptor(module).Serialize(), callback == null ? "" : ","+callback.ToScript());
            debug.AddScript("Ext.net.ResourceMgr.load({{ url: {0}, callback: {1} }});", JSON.Serialize(scriptUrl), activate);
        }

        /// <summary>
        /// Add required resources and activate console
        /// </summary>
        /// <param name="module">Console type</param>
        public static void Activate(DebugConsole module)
        {
            Debug.Activate(module, null);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public class DebugDescriptor
    {
        private DebugConsole type;
        private string css;
        private string script;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public DebugDescriptor() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public DebugDescriptor(DebugConsole type)
        {
            this.type = type;
            string name="";

            switch(type)
            {
                case DebugConsole.Ext:
                    name = "debug";
                    break;
                case DebugConsole.Firebug:
                    name = "firebug-lite";
                    break;
            }

            ResourceManager rm = ResourceManager.GetInstance(HttpContext.Current);
            this.css = rm.GetWebResourceUrl(ResourceManager.ASSEMBLYSLUG + string.Concat(".ux.extensions.debug.",type.ToString().ToLowerInvariant(),".css.",name,"-embedded.css"));
            this.script = rm.GetWebResourceUrl(ResourceManager.ASSEMBLYSLUG + string.Concat(".ux.extensions.debug.", type.ToString().ToLowerInvariant(), ".", name, ".js"));
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public DebugDescriptor(DebugConsole type, string css, string script)
        {
            this.type = type;
            this.css = css;
            this.script = script;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public DebugConsole Type
        {
            get { return type; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Css
        {
            get { return css; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Script
        {
            get { return script; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Serialize()
        {
            return JSON.Serialize(this, new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver());
        }
    }
}