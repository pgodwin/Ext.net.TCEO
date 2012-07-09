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
using System.Reflection;
using System.Threading;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class ViewStateProxy : StateManagedItem
    {
        private readonly XControl control;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ViewStateProxy(XControl control, StateBag viewState)
        {
            this.control = control;
            this.ViewState = viewState;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual bool Suspend()
        {
            bool oldValue = control.AllowCallbackScriptMonitoring;
            this.control.AllowCallbackScriptMonitoring = false;
            Monitor.Enter(this.control);

            return oldValue;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void Resume(bool oldValue)
        {
            this.control.AllowCallbackScriptMonitoring = oldValue;
            Monitor.Exit(this.control);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void Resume()
        {
            this.Resume(true);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public object this[string key]
        {
            get
            {
                return this.ViewState[key];
            }
            set
            {
                this.ViewState[key] = value;

                if ((control.GenerateMethodsCalling) || (RequestManager.IsAjaxRequest && (control.AllowCallbackScriptMonitoring && (!control.IsDynamic || control.IsProxy))))
                {
                    PropertyInfo pi = control.GetType().GetProperty(key);

                    if (pi == null)
                    {
                        return;
                    }

                    object[] attrs = pi.GetCustomAttributes(typeof(DirectEventUpdateAttribute), true);

                    if (attrs.Length > 0)
                    {
                        this.control.CallbackValues[key] = value;

                        if (value is Icon)
                        {
                            if (this.ResourceManager != null)
                            {
                                this.ResourceManager.RegisterIcon((Icon)value);
                            }
                            else
                            {
                                this.control.AddScript("Ext.net.ResourceMgr.registerIcon({0});", JSON.Serialize(value));
                            }
                        }

                        ((DirectEventUpdateAttribute)attrs[0]).RegisterScript(this.control, pi); 
                    }
                    else
                    {
                        ConfigOptionAttribute attr = ClientConfig.GetClientConfigAttribute(pi);
                        if (attr != null)
                        {
                            this.control.CallbackValues[key] = value;
                            this.control.AddScript(string.Format(DirectEventUpdateAttribute.AutoGenerateFormat, this.control.ClientID, JSON.Serialize(value), pi.Name.ToLowerCamelCase()));
                        }
                    }
                }
            }
        }
    }
}