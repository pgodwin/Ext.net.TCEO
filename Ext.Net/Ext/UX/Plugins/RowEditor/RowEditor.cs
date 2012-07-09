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

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    /// <summary>
    /// Plugin that adds the ability to rapidly edit full rows in a grid.
    /// </summary>
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(RowEditor), "Build.ToolboxIcons.RowEditor.bmp")]
    [ToolboxData("<{0}:RowEditor runat=\"server\" />")]
    [Description("Plugin that adds the ability to rapidly edit full rows in a grid.")]
    public partial class RowEditor : Plugin
    {
        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.ux.grid.RowEditor";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("proxyId")]
        [Description("")]
        protected override string ConfigIDProxy
        {
            get { return base.ConfigIDProxy; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override List<ResourceItem> Resources
        {
            get
            {
                List<ResourceItem> baseList =  base.Resources;
                baseList.Capacity += 2; 

                baseList.Add(new ClientStyleItem(
                                    typeof(RowEditor), 
                                    "Ext.Net.Build.Ext.Net.ux.plugins.roweditor.css.roweditor-embedded.css", 
                                    "/ux/plugins/roweditor/css/roweditor.css"));

                baseList.Add(new ClientScriptItem(
                                    typeof(RowEditor),
                                    "Ext.Net.Build.Ext.Net.ux.plugins.roweditor.roweditor.js",
                                    "/ux/plugins/roweditor/roweditor.js"));

                return baseList;
            }
        }

        /// <summary>
        /// The number of clicks on a cell required to display the cell's editor (defaults to 0 (auto)).
        /// </summary>
        [ConfigOption]
        [Category("3. RowEditor")]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [Description("The number of clicks on a cell required to display the cell's editor (defaults to 0(auto)).")]
        public virtual int ClicksToEdit
        {
            get
            {
                object obj = this.ViewState["ClicksToEdit"];
                return (obj == null) ? 0 : (int)obj;
            }
            set
            {
                this.ViewState["ClicksToEdit"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        [Category("3. RowEditor")]
        [DefaultValue(5)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual int FrameWidth
        {
            get
            {
                object obj = this.ViewState["FrameWidth"];
                return (obj == null) ? 5 : (int)obj;
            }
            set
            {
                this.ViewState["FrameWidth"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        [Category("3. RowEditor")]
        [DefaultValue(250)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual int FocusDelay
        {
            get
            {
                object obj = this.ViewState["FocusDelay"];
                return (obj == null) ? 250 : (int)obj;
            }
            set
            {
                this.ViewState["FocusDelay"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        [Category("3. RowEditor")]
        [DefaultValue(3)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual int ButtonPad
        {
            get
            {
                object obj = this.ViewState["ButtonPad"];
                return (obj == null) ? 3 : (int)obj;
            }
            set
            {
                this.ViewState["ButtonPad"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        [Category("3. RowEditor")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual bool ErrorSummary
        {
            get
            {
                object obj = this.ViewState["ErrorSummary"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["ErrorSummary"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        [Category("3. RowEditor")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual bool MonitorValid
        {
            get
            {
                object obj = this.ViewState["MonitorValid"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["MonitorValid"] = value;
            }
        }

        /// <summary>
        /// Minimum width in pixels of all buttons in this panel (defaults to 75).
        /// </summary>
        [ConfigOption]
        [Category("3. RowEditor")]
        [DefaultValue(typeof(Unit), "75")]
        [NotifyParentProperty(true)]
        [Description("Minimum width in pixels of all buttons in this panel (defaults to 75).")]
        public virtual Unit MinButtonWidth
        {
            get
            {
                return this.UnitPixelTypeCheck(ViewState["MinButtonWidth"], Unit.Pixel(75), "MinButtonWidth");
            }
            set
            {
                this.ViewState["MinButtonWidth"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        [Category("3. RowEditor")]
        [DefaultValue("Save")]
        [Localizable(true)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string SaveText
        {
            get
            {
                return (string)this.ViewState["SaveText"] ?? "Save";
            }
            set
            {
                this.ViewState["SaveText"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        [Category("3. RowEditor")]
        [DefaultValue("Cancel")]
        [Localizable(true)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string CancelText
        {
            get
            {
                return (string)this.ViewState["CancelText"] ?? "Cancel";
            }
            set
            {
                this.ViewState["CancelText"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        [Category("3. RowEditor")]
        [DefaultValue("You need to commit or cancel your changes")]
        [Localizable(true)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string CommitChangesText
        {
            get
            {
                return (string)this.ViewState["CommitChangesText"] ?? "You need to commit or cancel your changes";
            }
            set
            {
                this.ViewState["CommitChangesText"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        [Category("3. RowEditor")]
        [DefaultValue("Errors")]
        [Localizable(true)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string ErrorText
        {
            get
            {
                return (string)this.ViewState["ErrorText"] ?? "Errors";
            }
            set
            {
                this.ViewState["ErrorText"] = value;
            }
        }

        /// <summary>
        /// Starts editing the specified for the specified row
        /// </summary>
        /// <param name="rowIndex">row index</param>
        [Description("Starts editing the specified for the specified row")]
        public virtual void StartEditing(int rowIndex)
        {
            RequestManager.EnsureDirectEvent();
            this.Call("startEditing", rowIndex);
        }

        /// <summary>
        /// Stops any active editing
        /// </summary>
        /// <param name="saveChanges">False to cancel any changes</param>
        [Description("Stops any active editing")]
        public virtual void StopEditing(bool saveChanges)
        {
            RequestManager.EnsureDirectEvent();
            this.Call("stopEditing", saveChanges);
        }

        /// <summary>
        /// Stops any active editing
        /// </summary>
        [Description("Stops any active editing")]
        public virtual void StopEditing()
        {
            RequestManager.EnsureDirectEvent();
            this.Call("stopEditing");
        }

        /// <summary>
        /// Hide editor
        /// </summary>
        [Description("Hide editor")]
        public virtual void Hide()
        {
            RequestManager.EnsureDirectEvent();
            this.Call("slideHide");
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void ShowTooltip(string msg)
        {
            RequestManager.EnsureDirectEvent();
            this.Call("showTooltip", msg);
        }

        private RowEditorListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ViewStateMember]
        [Description("Client-side JavaScript Event Handlers")]
        public RowEditorListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new RowEditorListeners();
                }

                return this.listeners;
            }
        }

        private RowEditorDirectEvents directEvents;

        /// <summary>
        /// Server-side Ajax Event Handlers
        /// </summary>
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]
        [ViewStateMember]
        [Description("Server-side Ajax Event Handlers")]
        public RowEditorDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new RowEditorDirectEvents();
                }

                return this.directEvents;
            }
        }
    }
}