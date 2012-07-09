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
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
    public partial class MessageBox
    {
        /// <summary>
        /// Displays a message box with OK and Cancel buttons prompting the user to enter some text (comparable to JavaScript's prompt). The prompt can be a single-line or multi-line textbox. If a callback function is passed it will be called after the user clicks either button, and the id of the button that was clicked (could also be the top-right close button) and the text that was entered will be passed as the two parameters to the callback.
        /// </summary>
        /// <param name="title">The title bar text</param>
        /// <param name="msg">The message box body text</param>
        public MessageBox Prompt(string title, object msg)
        {
            return this.Prompt(title, msg.ToString());
        }

        /// <summary>
        /// Displays a message box with OK and Cancel buttons prompting the user to enter some text (comparable to JavaScript's prompt). The prompt can be a single-line or multi-line textbox. If a callback function is passed it will be called after the user clicks either button, and the id of the button that was clicked (could also be the top-right close button) and the text that was entered will be passed as the two parameters to the callback.
        /// </summary>
        /// <param name="title">The title bar text</param>
        /// <param name="msg">The message box body text</param>
        public MessageBox Prompt(string title, string msg)
        {
            return this.Prompt(title, msg, "");
        }

        /// <summary>
        /// Displays a message box with OK and Cancel buttons prompting the user to enter some text (comparable to JavaScript's prompt). The prompt can be a single-line or multi-line textbox. If a callback function is passed it will be called after the user clicks either button, and the id of the button that was clicked (could also be the top-right close button) and the text that was entered will be passed as the two parameters to the callback.
        /// </summary>
        /// <param name="title">The title bar text</param>
        /// <param name="msg">The message box body text</param>
        /// <param name="fn">(optional) The callback function invoked after the message box is closed</param>
        public MessageBox Prompt(string title, string msg, JFunction fn)
        {
            return this.Prompt(title, msg, fn, "");
        }

        /// <summary>
        /// Displays a message box with OK and Cancel buttons prompting the user to enter some text (comparable to JavaScript's prompt). The prompt can be a single-line or multi-line textbox. If a callback function is passed it will be called after the user clicks either button, and the id of the button that was clicked (could also be the top-right close button) and the text that was entered will be passed as the two parameters to the callback.
        /// </summary>
        /// <param name="title">The title bar text</param>
        /// <param name="msg">The message box body text</param>
        /// <param name="handler">(optional) The callback function invoked after the message box is closed</param>
        public MessageBox Prompt(string title, string msg, string handler)
        {
            return this.Prompt(title, msg, handler, "");
        }

        /// <summary>
        /// Displays a message box with OK and Cancel buttons prompting the user to enter some text (comparable to JavaScript's prompt). The prompt can be a single-line or multi-line textbox. If a callback function is passed it will be called after the user clicks either button, and the id of the button that was clicked (could also be the top-right close button) and the text that was entered will be passed as the two parameters to the callback.
        /// </summary>
        /// <param name="title">The title bar text</param>
        /// <param name="msg">The message box body text</param>
        /// <param name="handler">(optional) The callback function invoked after the message box is closed</param>
        /// <param name="scope">(optional) The scope of the callback function</param>
        [Description("Displays a message box with OK and Cancel buttons prompting the user to enter some text (comparable to JavaScript's prompt). The prompt can be a single-line or multi-line textbox. If a callback function is passed it will be called after the user clicks either button, and the id of the button that was clicked (could also be the top-right close button) and the text that was entered will be passed as the two parameters to the callback.")]
        public MessageBox Prompt(string title, string msg, string handler, string scope)
        {
            return this.Prompt(title, msg, handler.IsNotEmpty() ? new JFunction(handler, "buttonId", "text") : null as JFunction, scope);
        }

        /// <summary>
        /// Displays a message box with OK and Cancel buttons prompting the user to enter some text (comparable to JavaScript's prompt). The prompt can be a single-line or multi-line textbox. If a callback function is passed it will be called after the user clicks either button, and the id of the button that was clicked (could also be the top-right close button) and the text that was entered will be passed as the two parameters to the callback.
        /// </summary>
        /// <param name="title">The title bar text</param>
        /// <param name="msg">The message box body text</param>
        /// <param name="fn">(optional) The callback function invoked after the message box is closed</param>
        /// <param name="scope">(optional) The scope of the callback function</param>
        public MessageBox Prompt(string title, string msg, JFunction fn, string scope)
        {
            return this.Prompt(title, msg, fn, scope, false, "");
        }

        /// <summary>
        /// Displays a message box with OK and Cancel buttons prompting the user to enter some text (comparable to JavaScript's prompt). The prompt can be a single-line or multi-line textbox. If a callback function is passed it will be called after the user clicks either button, and the id of the button that was clicked (could also be the top-right close button) and the text that was entered will be passed as the two parameters to the callback.
        /// </summary>
        /// <param name="title">The title bar text</param>
        /// <param name="msg">The message box body text</param>
        /// <param name="fn">(optional) The callback function invoked after the message box is closed</param>
        /// <param name="scope">(optional) The scope of the callback function</param>
        /// <param name="multiline">(optional) True to create a multiline textbox using the defaultTextHeight property, or the height in pixels to create the textbox (defaults to false / single-line)</param>
        /// <param name="value">(optional) Default value of the text input element (defaults to '')</param>
        public MessageBox Prompt(string title, string msg, JFunction fn, string scope, bool multiline, string value)
        {
            MessageBoxConfig config = new MessageBoxConfig();
            config.Title = title;
            config.Message = msg;
            config.Buttons = Button.OKCANCEL;
            config.Fn = fn;
            config.MinWidth = Unit.Pixel(250);
            config.Scope = scope;
            config.Prompt = true;
            config.Multiline = multiline;
            config.Value = value;

            return this.Configure(config);
        }

        /// <summary>
        /// Displays a message box with OK and Cancel buttons prompting the user to enter some text (comparable to JavaScript's prompt). The prompt can be a single-line or multi-line textbox. If a callback function is passed it will be called after the user clicks either button, and the id of the button that was clicked (could also be the top-right close button) and the text that was entered will be passed as the two parameters to the callback.
        /// </summary>
        /// <param name="title">The title bar text</param>
        /// <param name="msg">The message box body text</param>
        /// <param name="fn">(optional) The callback function invoked after the message box is closed</param>
        /// <param name="scope">(optional) The scope of the callback function</param>
        /// <param name="multiline">(optional) True to create a multiline textbox using the defaultTextHeight property, or the height in pixels to create the textbox (defaults to false / single-line)</param>
        /// <param name="value">(optional) Default value of the text input element (defaults to '')</param>
        public MessageBox Prompt(string title, string msg, JFunction fn, string scope, Unit multiline, string value)
        {
            MessageBoxConfig config = new MessageBoxConfig();
            config.Title = title;
            config.Message = msg;
            config.Buttons = Button.OKCANCEL;
            config.Fn = fn;
            config.MinWidth = Unit.Pixel(250);
            config.Scope = scope;
            config.Prompt = true;
            config.MultilineHeight = multiline;
            config.Value = value;

            return this.Configure(config);
        }

        /// <summary>
        /// Displays a message box with OK and Cancel buttons prompting the user to enter some text (comparable to JavaScript's prompt). The prompt can be a single-line or multi-line textbox. If a callback function is passed it will be called after the user clicks either button, and the id of the button that was clicked (could also be the top-right close button) and the text that was entered will be passed as the two parameters to the callback.
        /// </summary>
        /// <param name="title">The title bar text</param>
        /// <param name="msg">The message box body text</param>
        /// <param name="buttonsConfig">A MessageBoxButtonsConfig object for configuring the Text value and JavaScript Handler for each MessageBox Button.</param>
        public MessageBox Prompt(string title, string msg, MessageBoxButtonsConfig buttonsConfig)
        {
            MessageBoxConfig config = new MessageBoxConfig();
            config.Title = title;
            config.Message = msg;
            config.Buttons = Button.OKCANCEL;
            config.MessageBoxButtonsConfig = buttonsConfig;
            config.MinWidth = Unit.Pixel(250);
            config.Prompt = true;

            return this.Configure(config);
        }

        /// <summary>
        /// Displays a message box with OK and Cancel buttons prompting the user to enter some text (comparable to JavaScript's prompt). The prompt can be a single-line or multi-line textbox. If a callback function is passed it will be called after the user clicks either button, and the id of the button that was clicked (could also be the top-right close button) and the text that was entered will be passed as the two parameters to the callback.
        /// </summary>
        /// <param name="title">The title bar text</param>
        /// <param name="msg">The message box body text</param>
        /// <param name="buttonsConfig">A MessageBoxButtonsConfig object for configuring the Text value and JavaScript Handler for each MessageBox Button.</param>
        /// <param name="scope">(optional) The scope of the callback function</param>
        /// <param name="multiline">(optional) True to create a multiline textbox using the defaultTextHeight property, or the height in pixels to create the textbox (defaults to false / single-line)</param>
        /// <param name="value">(optional) Default value of the text input element (defaults to '')</param>
        public MessageBox Prompt(string title, string msg, MessageBoxButtonsConfig buttonsConfig, string scope, bool multiline, string value)
        {
            MessageBoxConfig config = new MessageBoxConfig();
            config.Title = title;
            config.Message = msg;
            config.Buttons = Button.OKCANCEL;
            config.MessageBoxButtonsConfig = buttonsConfig;
            config.MinWidth = Unit.Pixel(250);
            config.Scope = scope;
            config.Prompt = true;
            config.Multiline = multiline;
            config.Value = value;

            return this.Configure(config);
        }

        /// <summary>
        /// Displays a message box with OK and Cancel buttons prompting the user to enter some text (comparable to JavaScript's prompt). The prompt can be a single-line or multi-line textbox. If a callback function is passed it will be called after the user clicks either button, and the id of the button that was clicked (could also be the top-right close button) and the text that was entered will be passed as the two parameters to the callback.
        /// </summary>
        /// <param name="title">The title bar text</param>
        /// <param name="msg">The message box body text</param>
        /// <param name="buttonsConfig">A MessageBoxButtonsConfig object for configuring the Text value and JavaScript Handler for each MessageBox Button.</param>
        /// <param name="scope">(optional) The scope of the callback function</param>
        /// <param name="multiline">(optional) True to create a multiline textbox using the defaultTextHeight property, or the height in pixels to create the textbox (defaults to false / single-line)</param>
        /// <param name="value">(optional) Default value of the text input element (defaults to '')</param>
        public MessageBox Prompt(string title, string msg, MessageBoxButtonsConfig buttonsConfig, string scope, Unit multiline, string value)
        {
            MessageBoxConfig config = new MessageBoxConfig();
            config.Title = title;
            config.Message = msg;
            config.Buttons = Button.OKCANCEL;
            config.MessageBoxButtonsConfig = buttonsConfig;
            config.MinWidth = Unit.Pixel(250);
            config.Scope = scope;
            config.Prompt = true;
            config.MultilineHeight = multiline;
            config.Value = value;

            return this.Configure(config);
        }
    }
}