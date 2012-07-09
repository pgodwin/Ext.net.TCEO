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
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    public abstract partial class FormPanelBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : PanelBase.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string formID = "";

			/// <summary>
			/// (optional) The id of the FORM tag (defaults to an auto-generated id).
			/// </summary>
			[DefaultValue("")]
			public virtual string FormID 
			{ 
				get
				{
					return this.formID;
				}
				set
				{
					this.formID = value;
				}
			}

			private string itemCls = "";

			/// <summary>
			/// A css class to apply to the x-form-item of fields. This property cascades to child containers.
			/// </summary>
			[DefaultValue("")]
			public override string ItemCls 
			{ 
				get
				{
					return this.itemCls;
				}
				set
				{
					this.itemCls = value;
				}
			}

			private int monitorPoll = 200;

			/// <summary>
			/// The milliseconds to poll valid state, ignored if monitorValid is not true (defaults to 200)
			/// </summary>
			[DefaultValue(200)]
			public virtual int MonitorPoll 
			{ 
				get
				{
					return this.monitorPoll;
				}
				set
				{
					this.monitorPoll = value;
				}
			}

			private bool monitorValid = false;

			/// <summary>
			/// If true the form monitors its valid state client-side and fires a looping event with that state. This is required to bind buttons to the valid state using the config value formBind:true on the button.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool MonitorValid 
			{ 
				get
				{
					return this.monitorValid;
				}
				set
				{
					this.monitorValid = value;
				}
			}

			private bool renderFormElement = true;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(true)]
			public virtual bool RenderFormElement 
			{ 
				get
				{
					return this.renderFormElement;
				}
				set
				{
					this.renderFormElement = value;
				}
			}
        
			private ParameterCollection baseParams = null;

			/// <summary>
			/// Parameters to pass with all requests. e.g. baseParams: {id: '123', foo: 'bar'}.
			/// </summary>
			public ParameterCollection BaseParams
			{
				get
				{
					if (this.baseParams == null)
					{
						this.baseParams = new ParameterCollection();
					}
			
					return this.baseParams;
				}
			}
			        
			private ReaderCollection errorReader = null;

			/// <summary>
			/// An Ext.data.DataReader (e.g. Ext.data.XmlReader) to be used to read data when reading validation errors on \"submit\" actions. This is completely optional as there is built-in support for processing JSON.
			/// </summary>
			public ReaderCollection ErrorReader
			{
				get
				{
					if (this.errorReader == null)
					{
						this.errorReader = new ReaderCollection();
					}
			
					return this.errorReader;
				}
			}
			
			private bool fileUpload = false;

			/// <summary>
			/// Set to true if this form is a file upload.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool FileUpload 
			{ 
				get
				{
					return this.fileUpload;
				}
				set
				{
					this.fileUpload = value;
				}
			}

			private HttpMethod method = HttpMethod.Default;

			/// <summary>
			/// The HTTP method to use. Defaults to POST if params are present, or GET if not.
			/// </summary>
			[DefaultValue(HttpMethod.Default)]
			public virtual HttpMethod Method 
			{ 
				get
				{
					return this.method;
				}
				set
				{
					this.method = value;
				}
			}
        
			private ReaderCollection reader = null;

			/// <summary>
			/// An Ext.data.DataReader (e.g. Ext.data.XmlReader) to be used to read data when executing \"load\" actions. This is optional as there is built-in support for processing JSON.
			/// </summary>
			public ReaderCollection Reader
			{
				get
				{
					if (this.reader == null)
					{
						this.reader = new ReaderCollection();
					}
			
					return this.reader;
				}
			}
			
			private bool standardSubmit = false;

			/// <summary>
			/// If set to true, standard HTML form submits are used instead of XHR (Ajax) style form submissions. (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool StandardSubmit 
			{ 
				get
				{
					return this.standardSubmit;
				}
				set
				{
					this.standardSubmit = value;
				}
			}

			private int timeout = 30;

			/// <summary>
			/// Timeout for form actions in seconds (default is 30 seconds).
			/// </summary>
			[DefaultValue(30)]
			public virtual int Timeout 
			{ 
				get
				{
					return this.timeout;
				}
				set
				{
					this.timeout = value;
				}
			}

			private bool trackResetOnLoad = false;

			/// <summary>
			/// If set to true, form.reset() resets to the last loaded or setValues() data instead of when the form was first created.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool TrackResetOnLoad 
			{ 
				get
				{
					return this.trackResetOnLoad;
				}
				set
				{
					this.trackResetOnLoad = value;
				}
			}

			private string url = "";

			/// <summary>
			/// The URL to use for form actions if one isn't supplied in the action options.
			/// </summary>
			[DefaultValue("")]
			public virtual string Url 
			{ 
				get
				{
					return this.url;
				}
				set
				{
					this.url = value;
				}
			}

			private string elementStyle = "";

			/// <summary>
			/// A CSS style specification string to add to each field element in this layout (defaults to '').
			/// </summary>
			[DefaultValue("")]
			public virtual string ElementStyle 
			{ 
				get
				{
					return this.elementStyle;
				}
				set
				{
					this.elementStyle = value;
				}
			}

			private string layout = "form";

			/// <summary>
			/// The layout type to be used in this container.
			/// </summary>
			[DefaultValue("form")]
			public override string Layout 
			{ 
				get
				{
					return this.layout;
				}
				set
				{
					this.layout = value;
				}
			}

        }
    }
}