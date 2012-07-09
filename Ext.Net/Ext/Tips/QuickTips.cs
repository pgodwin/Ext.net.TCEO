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

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class QuickTips : ScriptClass
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public QuickTips() { }

        /*  IScriptable
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.QuickTips";
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


        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Disable quick tips globally.
        /// </summary>
        [Description("Disable quick tips globally.")]
        public virtual void Disable()
        {
            this.Call("disable");
        }

        /// <summary>
        /// Enable quick tips globally.
        /// </summary>
        [Description("Enable quick tips globally.")]
        public virtual void Enable()
        {
            this.Call("enable");
        }

        /// <summary>
        /// Initialize the global QuickTips instance and prepare any quick tips.
        /// </summary>
        /// <returns>QuickTips</returns>
        [Description("Initialize the global QuickTips instance and prepare any quick tips.")]
        public virtual void Init()
        {
            this.Call("init");
        }

        /// <summary>
        /// Initialize the global QuickTips instance and prepare any quick tips.
        /// </summary>
        /// <param name="autoRender">True to render the QuickTips container immediately to preload images. (Defaults to true)</param>
        /// <returns>QuickTips</returns>
        [Description("Initialize the global QuickTips instance and prepare any quick tips.")]
        public virtual void Init(bool autoRender)
        {
            this.Call("init", autoRender);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cfg"></param>
        [Description("")]
        public virtual void Register(QTipCfg cfg)
        {
            this.Call("register", new JRawValue(new ClientConfig().Serialize(cfg, true)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        [Description("")]
        public virtual void Unregister(string target)
        {
            target = "Ext.net.getEl({0})".FormatWith(TokenUtils.ParseAndNormalize(target));
            this.Call("unregister", new JRawValue(target));
        }
    }
}