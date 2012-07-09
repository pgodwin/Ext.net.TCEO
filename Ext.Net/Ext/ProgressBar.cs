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

namespace Ext.Net
{
    /// <summary>
    /// An updateable progress bar component. The progress bar supports two different modes: manual and automatic.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:ProgressBar runat=\"server\" Width=\"300\"></{0}:ProgressBar>")]
    [ToolboxBitmap(typeof(ProgressBar), "Build.ToolboxIcons.ProgressBar.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("An updateable progress bar component. The progress bar supports two different modes: manual and automatic.")]
    public partial class ProgressBar : BoxComponentBase
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public ProgressBar() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "progress";
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
                return "Ext.ProgressBar";
            }
        }
        
        /// <summary>
        /// The base CSS class to apply to the progress bar's wrapper element (defaults to 'x-progress')
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. ProgressBar")]
        [DefaultValue("x-progress")]
        [NotifyParentProperty(true)]
        [Description("The base CSS class to apply to the progress bar's wrapper element (defaults to 'x-progress')")]
        public virtual string BaseCls
        {
            get
            {
                return (string)this.ViewState["BaseCls"] ?? "x-progress";
            }
            set
            {
                this.ViewState["BaseCls"] = value;
            }
        }
        
        /// <summary>
        /// The progress bar text (defaults to '')
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. ProgressBar")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The progress bar text (defaults to '')")]
        public virtual string Text
        {
            get
            {
                return (string)this.ViewState["Text"] ?? "";
            }
            set
            {
                this.ViewState["Text"] = value;
            }
        }

        /// <summary>
        /// The element to render the progress text to (defaults to the progress bar's internal text element)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. ProgressBar")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The element to render the progress text to (defaults to the progress bar's internal text element)")]
        public virtual string TextEl
        {
            get
            {
                return (string)this.ViewState["TextEl"] ?? "";
            }
            set
            {
                this.ViewState["TextEl"] = value;
            }
        }

        /// <summary>
        /// A floating point value between 0 and 1 (e.g., .5, defaults to 0)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. ProgressBar")]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [Description("A floating point value between 0 and 1 (e.g., .5, defaults to 0)")]
        public virtual float Value
        {
            get
            {
                var obj = this.ViewState["Value"];
                return (obj == null) ? 0 : (float)this.ViewState["Value"];
            }
            set
            {
                this.ViewState["Value"] = value;
            }
        }


        /*  Listeners and DirectEvents
            -----------------------------------------------------------------------------------------------*/

        private ProgressBarListeners listeners;

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
        public ProgressBarListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new ProgressBarListeners();
                }

                return this.listeners;
            }
        }

        private ProgressBarDirectEvents directEvents;

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
        public ProgressBarDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new ProgressBarDirectEvents();
                }

                return this.directEvents;
            }
        }


        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Resets the progress bar value to 0 and text to empty string. If hide = true, the progress bar will also be hidden (using the hideMode property internally).
        /// </summary>
        [Meta]
        [Description("Resets the progress bar value to 0 and text to empty string. If hide = true, the progress bar will also be hidden (using the hideMode property internally).")]
        public virtual void Reset()
        {
            this.Call("reset");
        }

        /// <summary>
        /// Resets the progress bar value to 0 and text to empty string. If hide = true, the progress bar will also be hidden (using the hideMode property internally).
        /// </summary>
        /// <param name="hide">True to hide the progress bar</param>
        [Meta]
        [Description("Resets the progress bar value to 0 and text to empty string. If hide = true, the progress bar will also be hidden (using the hideMode property internally).")]
        public virtual void Reset(bool hide)
        {
            this.Call("reset", hide);
        }

        /// <summary>
        /// Synchronizes the inner bar width to the proper proportion of the total componet width based on the current progress value. This will be called automatically when the ProgressBar is resized by a layout, but if it is rendered auto width, this method can be called from another resize handler to sync the ProgressBar if necessary.
        /// </summary>
        [Meta]
        [Description("Synchronizes the inner bar width to the proper proportion of the total componet width based on the current progress value. This will be called automatically when the ProgressBar is resized by a layout, but if it is rendered auto width, this method can be called from another resize handler to sync the ProgressBar if necessary.")]
        public virtual void SyncProgressBar()
        {
            this.Call("syncProgressBar");
        }

        /// <summary>
        /// Updates the progress bar value, and optionally its text. If the text argument is not specified, any existing text value will be unchanged. To blank out existing text, pass ''. Note that even if the progress bar value exceeds 1, it will never automatically reset -- you are responsible for determining when the progress is complete and calling reset to clear and/or hide the control.
        /// </summary>
        [Description("Updates the progress bar value, and optionally its text. If the text argument is not specified, any existing text value will be unchanged. To blank out existing text, pass ''. Note that even if the progress bar value exceeds 1, it will never automatically reset -- you are responsible for determining when the progress is complete and calling reset to clear and/or hide the control.")]
        public virtual void UpdateProgress(float value)
        {
            this.Call("updateProgress", value);
        }

        /// <summary>
        /// Updates the progress bar value, and optionally its text. If the text argument is not specified, any existing text value will be unchanged. To blank out existing text, pass ''. Note that even if the progress bar value exceeds 1, it will never automatically reset -- you are responsible for determining when the progress is complete and calling reset to clear and/or hide the control.
        /// </summary>
        [Meta]
        [Description("Updates the progress bar value, and optionally its text. If the text argument is not specified, any existing text value will be unchanged. To blank out existing text, pass ''. Note that even if the progress bar value exceeds 1, it will never automatically reset -- you are responsible for determining when the progress is complete and calling reset to clear and/or hide the control.")]
        public virtual void UpdateProgress(float value, string text)
        {
            this.Call("updateProgress", value, text);
        }

        /// <summary>
        /// Updates the progress bar text. If specified, textEl will be updated, otherwise the progress bar itself will display the updated text.
        /// </summary>
        [Meta]
        [Description("Updates the progress bar text. If specified, textEl will be updated, otherwise the progress bar itself will display the updated text.")]
        public virtual void UpdateText()
        {
            this.Call("updateText");
        }

        /// <summary>
        /// Updates the progress bar text. If specified, textEl will be updated, otherwise the progress bar itself will display the updated text.
        /// </summary>
        /// <param name="text">The string to display in the progress text element</param>
        [Meta]
        [Description("Updates the progress bar text. If specified, textEl will be updated, otherwise the progress bar itself will display the updated text.")]
        public virtual void UpdateText(string text)
        {
            this.Call("updateText", text);
        }

        /// <summary>
        /// Initiates an auto-updating progress bar. A duration can be specified, in which case the progress bar will automatically reset after a fixed amount of time and optionally call a callback function if specified. If no duration is passed in, then the progress bar will run indefinitely and must be manually cleared by calling reset.
        /// </summary>
        [Meta]
        [Description("Initiates an auto-updating progress bar. A duration can be specified, in which case the progress bar will automatically reset after a fixed amount of time and optionally call a callback function if specified. If no duration is passed in, then the progress bar will run indefinitely and must be manually cleared by calling reset.")]
        public virtual void Wait()
        {
            this.Call("wait");
        }

        /// <summary>
        /// Initiates an auto-updating progress bar. A duration can be specified, in which case the progress bar will automatically reset after a fixed amount of time and optionally call a callback function if specified. If no duration is passed in, then the progress bar will run indefinitely and must be manually cleared by calling reset.
        /// </summary>
        /// <param name="config">Configuration options</param>
        [Meta]
        [Description("Updates the progress bar text. If specified, textEl will be updated, otherwise the progress bar itself will display the updated text.")]
        public virtual void Wait(WaitConfig config)
        {
            this.Call("wait", new JRawValue(config.ToJsonString()));
        }
    }
}