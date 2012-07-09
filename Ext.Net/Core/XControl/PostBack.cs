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
using System.Web.UI;

using Ext.Net.Utilities;
using System.Text.RegularExpressions;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
    public partial class XControl
    {
        /*  PostBack
            -----------------------------------------------------------------------------------------------*/

        private string postBackArgument = "";

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual string PostBackArgument
        {
            get
            {
                return this.postBackArgument;
            }
            set
            {
                this.postBackArgument = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual string PostBackFunction
        {
            get
            {
                if (this is IAutoPostBack)
                {
                    IAutoPostBack control = (IAutoPostBack)this;

                    if (control.AutoPostBack)
                    {
                        if (control.CausesValidation)
                        {
                            PostBackOptions options = new PostBackOptions(this, this.PostBackArgument);
                            options.ValidationGroup = control.ValidationGroup;

                            options.AutoPostBack = control.AutoPostBack;
                            options.PerformValidation = control.CausesValidation;

                            if (control is Button)
                            {
                                Button button = (Button)control;

                                if (button.PostBackUrl.IsNotEmpty())
                                {
                                    options.ActionUrl = HttpUtility.UrlPathEncode(base.ResolveClientUrl(button.PostBackUrl));
                                }
                            }

                            if (RequestManager.IsIE)
                            {
                                string ps = this.Page.ClientScript.GetPostBackEventReference(options, false);
                                Regex re = new Regex("setTimeout\\('(.+)',(\\s*)\\d+\\)");
                                Match m = re.Match(ps);
                                if (m != null && m.Success)
                                {
                                    ps = m.Groups[1].Value;
                                }
                                ps = ps.Replace("'", "\"");
                                return string.Format("window.location = 'javascript:{0}';", ps);
                            }
                            else
                            {
                                return this.Page.ClientScript.GetPostBackEventReference(options, false) + ";";
                            }
                        }
                        else
                        {
                            return RequestManager.IsIE ? string.Format("window.location = 'javascript:{0}';", this.Page.ClientScript.GetPostBackEventReference(this, this.PostBackArgument).Replace("'", "\""))
                                            : string.Concat(this.Page.ClientScript.GetPostBackEventReference(this, this.PostBackArgument), ";");
                        }
                    }
                }

                return "";
            }
        }
    }
}