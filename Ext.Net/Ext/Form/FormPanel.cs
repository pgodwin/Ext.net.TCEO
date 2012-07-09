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
using System.Drawing;
using System.Text;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Standard form container.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:FormPanel runat=\"server\" Title=\"Title\" Padding=\"5\" ButtonAlign=\"Right\" Height=\"185\" Width=\"300\"><Items><{0}:TextField runat=\"server\" FieldLabel=\"Label\" AnchorHorizontal=\"100%\" /></Items><Buttons><{0}:Button runat=\"server\" Icon=\"Disk\" Text=\"Submit\" /></Buttons></ext:FormPanel>")]
    [ToolboxBitmap(typeof(FormPanel), "Build.ToolboxIcons.FormPanel.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("Standard form container.")]
    public partial class FormPanel : FormPanelBase
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public FormPanel() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "form";
            }
        }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.form.FormPanel";
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void OnBeforeClientInit(Observable sender)
        {
            base.OnBeforeClientInit(sender);

            if (this.BaseParams.Count > 0)
            {
                if (this.Listeners.BeforeAction.IsDefault)
                {
                    this.Listeners.BeforeAction.Fn = this.BuildParams(this.BaseParams, null, true);
                }
                else
                {
                    if (this.Listeners.BeforeAction.Fn.IsNotEmpty())
                    {
                        this.Listeners.BeforeAction.Fn = this.BuildParams(this.BaseParams, this.Listeners.BeforeAction.Fn, true);
                    }
                    else
                    {
                        this.Listeners.BeforeAction.Fn = this.BuildParams(this.BaseParams, this.Listeners.BeforeAction.Handler, false);
                    }
                }
            }
        }

        private string BuildParams(ParameterCollection parameters, string userHandler, bool isFn)
        {
            StringBuilder sb = new StringBuilder("function(form,action){if (!form.baseParams){form.baseParams={};};");

            sb.AppendFormat("Ext.apply(form.baseParams,{0});", parameters.ToJson(0));

            if (userHandler.IsNotEmpty())
            {
                sb.Append(userHandler);

                if (isFn)
                {
                    sb.Append("(form,action);");
                }
            }
            sb.Append("}");

            return sb.ToString();
        }

        private FormPanelListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ViewStateMember]
        [Description("Client-side JavaScript Event Handlers")]
        public FormPanelListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new FormPanelListeners();
                }

                return this.listeners;
            }
        }

        private FormPanelDirectEvents directEvents;

        /// <summary>
        /// Server-side Ajax Event Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]
        [ViewStateMember]
        [Description("Server-side Ajax Event Handlers")]
        public FormPanelDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new FormPanelDirectEvents();
                }

                return this.directEvents;
            }
        }
    }
}