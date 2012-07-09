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
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// A standard tooltip implementation for providing additional information when hovering over a target element.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:ToolTip runat=\"server\" Title=\"Message\"></{0}:ToolTip>")]
    [ToolboxBitmap(typeof(ToolTip), "Build.ToolboxIcons.ToolTip.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("A standard tooltip implementation for providing additional information when hovering over a target element.")]
    public partial class ToolTip : Tip
    {
        /// <summary>
        /// 
        /// </summary>
        public ToolTip() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.ToolTip";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override bool RemoveContainer
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// A numeric pixel value used to offset the default position of the anchor arrow (defaults to 0). When the anchor position is on the top or bottom of the tooltip, anchorOffset will be used as a horizontal offset. Likewise, when the anchor position is on the left or right side, anchorOffset will be used as a vertical offset.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ToolTip")]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [Description("A numeric pixel value used to offset the default position of the anchor arrow (defaults to 0). When the anchor position is on the top or bottom of the tooltip, anchorOffset will be used as a horizontal offset. Likewise, when the anchor position is on the left or right side, anchorOffset will be used as a vertical offset.")]
        public virtual int AnchorOffset
        {
            get
            {
                object obj = this.ViewState["AnchorOffset"];
                return (obj == null) ? 0 : (int)obj;
            }
            set
            {
                this.ViewState["AnchorOffset"] = value;
            }
        }

        /// <summary>
        /// True to anchor the tooltip to the target element, false to anchor it relative to the mouse coordinates (defaults to true). When anchorToTarget is true, use defaultAlign to control tooltip alignment to the target element. When anchorToTarget is false, use anchorPosition instead to control alignment.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ToolTip")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to automatically hide the tooltip after the mouse exits the target element or after the dismissDelay has expired if set (defaults to true). If closable = true a close tool button will be rendered into the tooltip header.")]
        public virtual bool AnchorToTarget
        {
            get
            {
                object obj = this.ViewState["AnchorToTarget"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["AnchorToTarget"] = value;
            }
        }

        /// <summary>
        /// True to automatically hide the tooltip after the mouse exits the target element or after the dismissDelay has expired if set (defaults to true). If closable = true a close tool button will be rendered into the tooltip header.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ToolTip")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to automatically hide the tooltip after the mouse exits the target element or after the dismissDelay has expired if set (defaults to true). If closable = true a close tool button will be rendered into the tooltip header.")]
        public virtual bool AutoHide
        {
            get
            {
                object obj = this.ViewState["AutoHide"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["AutoHide"] = value;
            }
        }

        /// <summary>
        /// Optional. A DomQuery selector which allows selection of individual elements within the target element to trigger showing and hiding the ToolTip as the mouse moves within the target.
        /// When specified, the child element of the target which caused a show event is placed into the triggerElement property before the ToolTip is shown.
        /// This may be useful when a Component has regular, repeating elements in it, each of which need a Tooltip which contains information specific to that element.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ToolTip")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A DomQuery selector which allows selection of individual elements within the target element to trigger showing and hiding the ToolTip as the mouse moves within the target.")]
        public virtual string Delegate
        {
            get
            {
                object obj = this.ViewState["Delegate"];
                return (obj == null) ? "" : (string)obj;
            }
            set
            {
                this.ViewState["Delegate"] = value;
            }
        }

        /// <summary>
        /// Delay in milliseconds before the tooltip automatically hides (defaults to 5000). To disable automatic hiding, set dismissDelay = 0.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ToolTip")]
        [DefaultValue(5000)]
        [NotifyParentProperty(true)]
        [Description("Delay in milliseconds before the tooltip automatically hides (defaults to 5000). To disable automatic hiding, set dismissDelay = 0.")]
        public virtual int DismissDelay
        {
            get
            {
                object obj = this.ViewState["DismissDelay"];
                return (obj == null) ? 5000 : (int)obj;
            }
            set
            {
                this.ViewState["DismissDelay"] = value;
            }
        }

        /// <summary>
        /// Delay in milliseconds after the mouse exits the target element but before the tooltip actually hides (defaults to 200). Set to 0 for the tooltip to hide immediately.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ToolTip")]
        [DefaultValue(200)]
        [NotifyParentProperty(true)]
        [Description("Delay in milliseconds after the mouse exits the target element but before the tooltip actually hides (defaults to 200). Set to 0 for the tooltip to hide immediately.")]
        public virtual int HideDelay
        {
            get
            {
                object obj = this.ViewState["HideDelay"];
                return (obj == null) ? 200 : (int)obj;
            }
            set
            {
                this.ViewState["HideDelay"] = value;
            }
        }

        /// <summary>
        /// An XY offset from the mouse position where the tooltip should be shown (defaults to [15,18]).
        /// </summary>
        [Meta]
        [ConfigOption(typeof(IntArrayJsonConverter))]
        [TypeConverter(typeof(IntArrayConverter))]
        [Category("8. ToolTip")]
        [DefaultValue(null)]
        [Description("An XY offset from the mouse position where the tooltip should be shown (defaults to [15,18]).")]
        public virtual int[] MouseOffset
        {
            get
            {
                object obj = this.ViewState["MouseOffset"];
                return (obj == null) ? null : (int[])obj;
            }
            set
            {
                this.ViewState["MouseOffset"] = value;
            }
        }

        /// <summary>
        /// Delay in milliseconds before the tooltip displays after the mouse enters the target element (defaults to 500).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ToolTip")]
        [DefaultValue(500)]
        [NotifyParentProperty(true)]
        [Description("Delay in milliseconds before the tooltip displays after the mouse enters the target element (defaults to 500).")]
        public virtual int ShowDelay
        {
            get
            {
                object obj = this.ViewState["ShowDelay"];
                return (obj == null) ? 500 : (int)obj;
            }
            set
            {
                this.ViewState["ShowDelay"] = value;
            }
        }

        private Control targetControl;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Description("")]
        public Control TargetControl
        {
            get
            {
                return this.targetControl;
            }
            set
            {
                this.targetControl = value;
            }
        }

        /// <summary>
        /// The target id to associate with this tooltip.
        /// </summary>
        [Meta]
        [Category("8. ToolTip")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The target id to associate with this tooltip.")]
        public virtual string Target
        {
            get
            {
                return (string)this.ViewState["Target"] ?? "";
            }
            set
            {
                this.ViewState["Target"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("target", JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected string TargetProxy
        {
            get
            {
                string target = this.Target;

                if (target.IsNotEmpty())
                {
                    string t = this.ParseTarget(target);

                    if (t.StartsWith("\""))
                    {
                        return t;
                    }

                    return TokenUtils.ParseAndNormalize(t);
                }

                if (this.TargetControl != null)
                {
                    return JSON.Serialize(this.TargetControl.ClientID);
                }

                return "";
            }
        }

        /// <summary>
        /// True to have the tooltip follow the mouse as it moves over the target element (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ToolTip")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to have the tooltip follow the mouse as it moves over the target element (defaults to false).")]
        public virtual bool TrackMouse
        {
            get
            {
                object obj = this.ViewState["TrackMouse"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["TrackMouse"] = value;
            }
        }

        private PanelListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Client-side JavaScript Event Handlers")]
        public PanelListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new PanelListeners();
                }

                return this.listeners;
            }
        }

        private PanelDirectEvents directEvents;

        /// <summary>
        /// Server-side Ajax Event Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]
        [Description("Server-side Ajax Event Handlers")]
        public PanelDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new PanelDirectEvents();
                }

                return this.directEvents;
            }
        }


        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Update the html of the Body, optionally searching for and processing scripts.
        /// </summary>
        [Meta]
        [Description("Update the html of the Body, optionally searching for and processing scripts.")]
        public override void Update(string html)
        {
            string template = "{0}.html={1};if({0}.body){{{0}.body.update({1});}}";
            this.AddScript(template, this.ClientID, JSON.Serialize(html));
        }
    }
}