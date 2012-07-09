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
    public partial class MessageBox
    {
        /// <summary>
        /// Displays a confirmation message box with Yes and No buttons (comparable to JavaScript's confirm). If a callback function is passed it will be called after the user clicks either button, and the id of the button that was clicked will be passed as the only parameter to the callback (could also be the top-right close button).
        /// </summary>
        /// <param name="title">The title bar text</param>
        /// <param name="msg">The message box body text</param>
        [Description("Displays a standard read-only message box with an OK button (comparable to the basic JavaScript confirm prompt). If a callback function is passed it will be called after the user clicks the button, and the id of the button that was clicked will be passed as the only parameter to the callback (could also be the top-right close button).")]
        public MessageBox Confirm(string title, object msg)
        {
            return this.Confirm(title, msg.ToString());
        }

        /// <summary>
        /// Displays a confirmation message box with Yes and No buttons (comparable to JavaScript's confirm). If a callback function is passed it will be called after the user clicks either button, and the id of the button that was clicked will be passed as the only parameter to the callback (could also be the top-right close button).
        /// </summary>
        /// <param name="title">The title bar text</param>
        /// <param name="msg">The message box body text</param>
        [Description("Displays a standard read-only message box with an OK button (comparable to the basic JavaScript confirm prompt). If a callback function is passed it will be called after the user clicks the button, and the id of the button that was clicked will be passed as the only parameter to the callback (could also be the top-right close button).")]
        public MessageBox Confirm(string title, string msg)
        {
            return this.Confirm(title, msg, "", "");
        }

        /// <summary>
        /// Displays a confirmation message box with Yes and No buttons (comparable to JavaScript's confirm). If a callback function is passed it will be called after the user clicks either button, and the id of the button that was clicked will be passed as the only parameter to the callback (could also be the top-right close button).
        /// </summary>
        /// <param name="title">The title bar text</param>
        /// <param name="msg">The message box body text</param>
        /// <param name="fn">(optional) The callback function invoked after the message box is closed</param>
        [Description("Displays a standard read-only message box with an OK button (comparable to the basic JavaScript confirm prompt). If a callback function is passed it will be called after the user clicks the button, and the id of the button that was clicked will be passed as the only parameter to the callback (could also be the top-right close button).")]
        public MessageBox Confirm(string title, string msg, JFunction fn)
        {
            return this.Confirm(title, msg, fn, "");
        }

        /// <summary>
        /// Displays a confirmation message box with Yes and No buttons (comparable to JavaScript's confirm). If a callback function is passed it will be called after the user clicks either button, and the id of the button that was clicked will be passed as the only parameter to the callback (could also be the top-right close button).
        /// </summary>
        /// <param name="title">The title bar text</param>
        /// <param name="msg">The message box body text</param>
        /// <param name="handler">(optional) The callback function invoked after the message box is closed</param>
        [Description("Displays a standard read-only message box with an OK button (comparable to the basic JavaScript confirm prompt). If a callback function is passed it will be called after the user clicks the button, and the id of the button that was clicked will be passed as the only parameter to the callback (could also be the top-right close button).")]
        public MessageBox Confirm(string title, string msg, string handler)
        {
            return this.Confirm(title, msg, handler, "");
        }

        /// <summary>
        /// Displays a confirmation message box with Yes and No buttons (comparable to JavaScript's confirm). If a callback function is passed it will be called after the user clicks either button, and the id of the button that was clicked will be passed as the only parameter to the callback (could also be the top-right close button).
        /// </summary>
        /// <param name="title">The title bar text</param>
        /// <param name="msg">The message box body text</param>
        /// <param name="handler">(optional) The callback function invoked after the message box is closed</param>
        /// <param name="scope">(optional) The scope of the callback function</param>
        [Description("Displays a standard read-only message box with an OK button (comparable to the basic JavaScript confirm prompt). If a callback function is passed it will be called after the user clicks the button, and the id of the button that was clicked will be passed as the only parameter to the callback (could also be the top-right close button).")]
        public MessageBox Confirm(string title, string msg, string handler, string scope)
        {
            return this.Confirm(title, msg, handler.IsNotEmpty() ? new JFunction(handler, "buttonId", "text") : null as JFunction, scope);
        }

        /// <summary>
        /// Displays a confirmation message box with Yes and No buttons (comparable to JavaScript's confirm). If a callback function is passed it will be called after the user clicks either button, and the id of the button that was clicked will be passed as the only parameter to the callback (could also be the top-right close button).
        /// </summary>
        /// <param name="title">The title bar text</param>
        /// <param name="msg">The message box body text</param>
        /// <param name="fn">(optional) The callback function invoked after the message box is closed</param>
        /// <param name="scope">(optional) The scope of the callback function</param>
        [Description("Displays a standard read-only message box with an OK button (comparable to the basic JavaScript confirm prompt). If a callback function is passed it will be called after the user clicks the button, and the id of the button that was clicked will be passed as the only parameter to the callback (could also be the top-right close button).")]
        public MessageBox Confirm(string title, string msg, JFunction fn, string scope)
        {
            MessageBoxConfig config = new MessageBoxConfig();
            config.Title = title;
            config.Message = msg;
            config.Buttons = Button.YESNO;
            config.Fn = fn;
            config.Scope = scope;
            config.Icon = Icon.QUESTION;

            return this.Configure(config);
        }

        /// <summary>
        /// Displays a confirmation message box with Yes and No buttons (comparable to JavaScript's confirm). If a callback function is passed it will be called after the user clicks either button, and the id of the button that was clicked will be passed as the only parameter to the callback (could also be the top-right close button).
        /// </summary>
        /// <param name="title">The title bar text</param>
        /// <param name="msg">The message box body text</param>
        /// <param name="buttonsConfig">A MessageBoxButtonsConfig object for configuring the Text value and JavaScript Handler for each MessageBox Button.</param>
        public MessageBox Confirm(string title, string msg, MessageBoxButtonsConfig buttonsConfig)
        {
            MessageBoxConfig config = new MessageBoxConfig();
            config.Title = title;
            config.Message = msg;
            config.Buttons = Button.YESNO;
            config.MessageBoxButtonsConfig = buttonsConfig;
            config.Icon = Icon.QUESTION;

            return this.Configure(config);
        }

        /// <summary>
        /// Displays a confirmation message box with Yes and No buttons (comparable to JavaScript's confirm). If a callback function is passed it will be called after the user clicks either button, and the id of the button that was clicked will be passed as the only parameter to the callback (could also be the top-right close button).
        /// </summary>
        /// <param name="title">The title bar text</param>
        /// <param name="msg">The message box body text</param>
        /// <param name="buttonsConfig">A MessageBoxButtonsConfig object for configuring the Text value and JavaScript Handler for each MessageBox Button.</param>
        /// <param name="scope">(optional) The scope of the callback function</param>
        public MessageBox Confirm(string title, string msg, MessageBoxButtonsConfig buttonsConfig, string scope)
        {
            MessageBoxConfig config = new MessageBoxConfig();
            config.Title = title;
            config.Message = msg;
            config.Buttons = Button.YESNO;
            config.MessageBoxButtonsConfig = buttonsConfig;
            config.Scope = scope;
            config.Icon = Icon.QUESTION;

            return this.Configure(config);
        }
    }
}