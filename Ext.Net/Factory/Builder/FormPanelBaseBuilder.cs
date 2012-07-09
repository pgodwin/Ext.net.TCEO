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
        new public abstract partial class Builder<TFormPanelBase, TBuilder> : PanelBase.Builder<TFormPanelBase, TBuilder>
            where TFormPanelBase : FormPanelBase
            where TBuilder : Builder<TFormPanelBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TFormPanelBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// (optional) The id of the FORM tag (defaults to an auto-generated id).
			/// </summary>
            public virtual TBuilder FormID(string formID)
            {
                this.ToComponent().FormID = formID;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A css class to apply to the x-form-item of fields. This property cascades to child containers.
			/// </summary>
            public virtual TBuilder ItemCls(string itemCls)
            {
                this.ToComponent().ItemCls = itemCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The milliseconds to poll valid state, ignored if monitorValid is not true (defaults to 200)
			/// </summary>
            public virtual TBuilder MonitorPoll(int monitorPoll)
            {
                this.ToComponent().MonitorPoll = monitorPoll;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// If true the form monitors its valid state client-side and fires a looping event with that state. This is required to bind buttons to the valid state using the config value formBind:true on the button.
			/// </summary>
            public virtual TBuilder MonitorValid(bool monitorValid)
            {
                this.ToComponent().MonitorValid = monitorValid;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RenderFormElement(bool renderFormElement)
            {
                this.ToComponent().RenderFormElement = renderFormElement;
                return this as TBuilder;
            }
             
 			// /// <summary>
			// /// Parameters to pass with all requests. e.g. baseParams: {id: '123', foo: 'bar'}.
			// /// </summary>
            // public virtual TBuilder BaseParams(ParameterCollection baseParams)
            // {
            //    this.ToComponent().BaseParams = baseParams;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// An Ext.data.DataReader (e.g. Ext.data.XmlReader) to be used to read data when reading validation errors on \"submit\" actions. This is completely optional as there is built-in support for processing JSON.
			// /// </summary>
            // public virtual TBuilder ErrorReader(ReaderCollection errorReader)
            // {
            //    this.ToComponent().ErrorReader = errorReader;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// Set to true if this form is a file upload.
			/// </summary>
            public virtual TBuilder FileUpload(bool fileUpload)
            {
                this.ToComponent().FileUpload = fileUpload;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The HTTP method to use. Defaults to POST if params are present, or GET if not.
			/// </summary>
            public virtual TBuilder Method(HttpMethod method)
            {
                this.ToComponent().Method = method;
                return this as TBuilder;
            }
             
 			// /// <summary>
			// /// An Ext.data.DataReader (e.g. Ext.data.XmlReader) to be used to read data when executing \"load\" actions. This is optional as there is built-in support for processing JSON.
			// /// </summary>
            // public virtual TBuilder Reader(ReaderCollection reader)
            // {
            //    this.ToComponent().Reader = reader;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// If set to true, standard HTML form submits are used instead of XHR (Ajax) style form submissions. (defaults to false).
			/// </summary>
            public virtual TBuilder StandardSubmit(bool standardSubmit)
            {
                this.ToComponent().StandardSubmit = standardSubmit;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Timeout for form actions in seconds (default is 30 seconds).
			/// </summary>
            public virtual TBuilder Timeout(int timeout)
            {
                this.ToComponent().Timeout = timeout;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// If set to true, form.reset() resets to the last loaded or setValues() data instead of when the form was first created.
			/// </summary>
            public virtual TBuilder TrackResetOnLoad(bool trackResetOnLoad)
            {
                this.ToComponent().TrackResetOnLoad = trackResetOnLoad;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The URL to use for form actions if one isn't supplied in the action options.
			/// </summary>
            public virtual TBuilder Url(string url)
            {
                this.ToComponent().Url = url;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A CSS style specification string to add to each field element in this layout (defaults to '').
			/// </summary>
            public virtual TBuilder ElementStyle(string elementStyle)
            {
                this.ToComponent().ElementStyle = elementStyle;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The layout type to be used in this container.
			/// </summary>
            public virtual TBuilder Layout(string layout)
            {
                this.ToComponent().Layout = layout;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// Clears all invalid messages in this form.
			/// </summary>
            public virtual TBuilder ClearInvalid()
            {
                this.ToComponent().ClearInvalid();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Mark fields in this form invalid in bulk.
			/// </summary>
            public virtual TBuilder MarkInvalid(object errors)
            {
                this.ToComponent().MarkInvalid(errors);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Resets this form.
			/// </summary>
            public virtual TBuilder Reset()
            {
                this.ToComponent().Reset();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Set values for fields in this form in bulk.
			/// </summary>
            public virtual TBuilder SetValues(object values)
            {
                this.ToComponent().SetValues(values);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Calls Ext.apply for all fields in this form with the passed object.
			/// </summary>
            public virtual TBuilder ApplyToFields(object values)
            {
                this.ToComponent().ApplyToFields(values);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Calls Ext.applyIf for all fields in this form with the passed object.
			/// </summary>
            public virtual TBuilder ApplyIfToFields(object values)
            {
                this.ToComponent().ApplyIfToFields(values);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Calls required method for all fields in this form with the passed args.
			/// </summary>
            public virtual TBuilder CallFieldMethod(string fnName, object[] args)
            {
                this.ToComponent().CallFieldMethod(fnName, args);
                return this as TBuilder;
            }
            
        }        
    }
}