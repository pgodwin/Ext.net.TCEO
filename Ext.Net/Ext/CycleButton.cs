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
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// A specialized SplitButton that contains a menu of Ext.menu.CheckItem elements. The button automatically cycles through each menu items on click, raising the button's change event (or calling the button's changeHandler function, if supplied) for the active menu items. Clicking on the arrow section of the button displays the dropdown menu just like a normal SplitButton.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:CycleButton runat=\"server\" Text=\"Cycle Button\" />")]
    [DefaultEvent("Click")]
    [DefaultProperty("Text")]
    [ToolboxBitmap(typeof(CycleButton), "Build.ToolboxIcons.CycleButton.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("A specialized SplitButton that contains a menu of Ext.menu.CheckItem elements. The button automatically cycles through each menu items on click, raising the button's change event (or calling the button's changeHandler function, if supplied) for the active menu items. Clicking on the arrow section of the button displays the dropdown menu just like a normal SplitButton.")]
    public partial class CycleButton : SplitButtonBase
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public CycleButton() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "cycle";
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
                return "Ext.CycleButton";
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (this.DesignMode)
            {
                return;
            }

            if (!RequestManager.IsAjaxRequest)
            {
                if (this.Menu.Primary != null)
                {
                    foreach (CheckMenuItem item in this.Menu.Primary.Items)
                    {
                        if (item.Group.IsEmpty())
                        {
                            item.Group = this.ClientID;
                        }
                    }
                }

                if (this.Menu.Primary != null)
                {
                    this.Menu.Primary.Items.AfterItemAdd += MenuItems_AfterItemAdd;
                    this.Menu.Primary.LazyMode = LazyMode.Config;
                }
            
                this.Menu.AfterItemAdd += Menu_AfterItemAdd;                
            }    
        }

        void Menu_AfterItemAdd(MenuBase item)
        {
            item.Items.AfterItemAdd += MenuItems_AfterItemAdd;
        }

        void MenuItems_AfterItemAdd(Component item)
        {
            CheckMenuItem ci = (CheckMenuItem)item;

            if (ci.Group.IsEmpty())
            {
                ci.Group = this.ClientID;
            }
        }

        /// <summary>
        /// A callback function that will be invoked each time the active menu items in the button's menu has changed. If this callback is not supplied, the SplitButton will instead fire the change event on active items change. The changeHandler function will be called with the following argument list: (SplitButton this, Ext.menu.CheckItem items).
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("7. CycleButton")]
        [DefaultValue("")]
        [Description("A callback function that will be invoked each time the active menu items in the button's menu has changed. If this callback is not supplied, the SplitButton will instead fire the change event on active items change. The changeHandler function will be called with the following argument list: (SplitButton this, Ext.menu.CheckItem items).")]
        public virtual string ChangeHandler
        {
            get
            {
                return (string)this.ViewState["ChangeHandler"] ?? "";
            }
            set
            {
                this.ViewState["ChangeHandler"] = value;
            }
        }

        /// <summary>
        /// A css class which sets an image to be used as the static icon for this button. This icon will always be displayed regardless of which item is selected in the dropdown list. This overrides the default behavior of changing the button's icon to match the selected item's icon on change.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. CycleButton")]
        [DefaultValue("")]
        [Description("A css class which sets an image to be used as the static icon for this button. This icon will always be displayed regardless of which item is selected in the dropdown list. This overrides the default behavior of changing the button's icon to match the selected item's icon on change.")]
        public virtual string ForceIcon
        {
            get
            {
                return (string)this.ViewState["ForceIcon"] ?? "";
            }
            set
            {
                this.ViewState["ForceIcon"] = value;
            }
        }

        /// <summary>
        /// A static string to prepend before the active items's text when displayed as the button's text (only applies when showText = true, defaults to '')
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. CycleButton")]
        [DefaultValue("")]
        [Description("A static string to prepend before the active items's text when displayed as the button's text (only applies when showText = true, defaults to '')")]
        public virtual string PrependText
        {
            get
            {
                return (string)this.ViewState["PrependText"] ?? "";
            }
            set
            {
                this.ViewState["PrependText"] = value;
            }
        }

        /// <summary>
        /// True to display the active items's text as the button text (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. CycleButton")]
        [DefaultValue(false)]
        [Description("True to display the active items's text as the button text (defaults to false).")]
        public virtual bool ShowText
        {
            get
            {
                object obj = this.ViewState["ShowText"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["ShowText"] = value;
            }
        }

        /// <summary>
        /// False to prevent change active item after button click (defaults to true).
        /// </summary>
        [Meta]
        [Category("7. CycleButton")]
        [DefaultValue(true)]
        [Description("False to prevent change active item after button click (defaults to true).")]
        public virtual bool ToggleOnClick
        {
            get
            {
                object obj = this.ViewState["ToggleOnClick"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["ToggleOnClick"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("toggleSelected", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected string ToggleOnClickProxy
        {
            get
            {
                if (!this.ToggleOnClick)
                {
                    return "Ext.emptyFn";
                }

                return "";
            }
        }

        private CycleButtonListeners listeners;

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
        public CycleButtonListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new CycleButtonListeners();
                }

                return this.listeners;
            }
        }

        private CycleButtonDirectEvents directEvents;

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
        public CycleButtonDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new CycleButtonDirectEvents();
                }

                return this.directEvents;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(-1)]
        [Browsable(false)]
        [Description("")]
        public int ActiveItemIndex
        {
            get
            {
                if (this.Menu.Primary == null)
                {
                    return -1;
                }

                for (int i = 0; i < this.Menu.Primary.Items.Count; i++)
                {
                    CheckMenuItem item = (CheckMenuItem)this.Menu.Primary.Items[i];

                    if (item.Checked)
                    {
                        return i;
                    }
                }

                return -1;
            }
            set
            {
                if (this.Menu.Primary == null)
                {
                    throw new Exception("The menu can not be null");
                }

                try
                {
                    this.SuspendScripting();
                    ((CheckMenuItem)this.Menu.Primary.Items[value]).Checked = true;
                    
                    if (RequestManager.IsAjaxRequest)
                    {
                        this.Call("setActiveItem", value);    
                    }
                }
                finally
                {
                    this.ResumeScripting();    
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public CheckMenuItem ActiveItem
        {
            get
            {
                if (this.Menu.Primary == null)
                {
                    return null;
                }

                for (int i = 0; i < this.Menu.Primary.Items.Count; i++)
                {
                    CheckMenuItem item = (CheckMenuItem)this.Menu.Primary.Items[i];

                    if (item.Checked)
                    {
                        return item;
                    }
                }

                return null;
            }
            set
            {
                if (this.Menu.Primary == null)
                {
                    throw new Exception("The CycleButton menu is null");
                }

                if (value == null)
                {
                    throw new Exception("The value can not be null");
                }


                for (int i = 0; i < this.Menu.Primary.Items.Count; i++)
                {
                    CheckMenuItem item = (CheckMenuItem)this.Menu.Primary.Items[i];
                    item.Checked = false;
                }

                try
                {
                    this.SuspendScripting();
                    value.Checked = true;

                    if (RequestManager.IsAjaxRequest)
                    {
                        this.Call("setActiveItem", value.ClientID);
                    }
                }
                finally
                {
                    this.ResumeScripting();
                }
            }
        }


        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// This is normally called internally on button click, but can be called externally to advance the button's active item programmatically to the next one in the menu. If the current item is the last one in the menu the active item will be set to the first item in the menu.
        /// </summary>
        [Meta]
        [Description("This is normally called internally on button click, but can be called externally to advance the button's active item programmatically to the next one in the menu. If the current item is the last one in the menu the active item will be set to the first item in the menu.")]
        public virtual void ToggleSelected()
        {
            this.Call("toggleSelected");
        }
    }
}