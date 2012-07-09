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

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;

using Ext.Net.Utilities;
using System;

namespace Ext.Net
{
    /// <summary>
    /// A grouping container for Ext.form.Radio controls.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:RadioGroup runat=\"server\" />")]
    [Designer(typeof(EmptyDesigner))]
    [ToolboxBitmap(typeof(RadioGroup), "Build.ToolboxIcons.RadioGroup.bmp")]
    [Description("A grouping container for Ext.form.Radio controls.")]
    public partial class RadioGroup : CheckboxGroupBase, IItems
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public RadioGroup() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "radiogroup";
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
                return "Ext.form.RadioGroup";
            }
        }

        /// <summary>
        /// The default type of content Container represented by this object as registered in Ext.ComponentMgr (defaults to 'radio').
        /// </summary>
        [Meta]
        [Category("5. Container")]
        [DefaultValue("Radio")]
        [TypeConverter(typeof(DefaultTypeConverter))]
        [NotifyParentProperty(true)]
        [Description("The default type of content Container represented by this object as registered in Ext.ComponentMgr (defaults to 'radio').")]
        public virtual string DefaultType
        {
            get
            {
                return (string)this.ViewState["DefaultType"] ?? "Radio";
            }
            set
            {
                this.ViewState["DefaultType"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("defaultType")]
        [DefaultValue("radio")]
        [Description("")]
        protected virtual string DefaultTypeProxy
        {
            get
            {
                return DefaultTypeConverter.GetXType(this.DefaultType);
            }
        }

        private RadioGroupListeners listeners;

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
        public RadioGroupListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new RadioGroupListeners();
                }

                return this.listeners;
            }
        }

        private RadioGroupDirectEvents directEvents;

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
        public RadioGroupDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new RadioGroupDirectEvents();
                }

                return this.directEvents;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        [Description("")]
        protected override void OnBeforeClientInit(Observable sender)
        {
            base.OnBeforeClientInit(sender);

            if (!this.DesignMode && this.AutomaticGrouping)
            {
                this.SetGroup();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (!this.DesignMode && this.AutomaticGrouping)
            {
                this.SetGroup();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void SetGroup()
        {
            string groupName = this.GroupName.IsEmpty()
                                   ? this.ClientID + "_Group"
                                   : this.GroupName;

            foreach (Radio item in this.Items)
            {
                RadioColumn rCol = item as RadioColumn;

                if (rCol != null)
                {
                    foreach (Component comp in rCol.Items)
                    {
                        Radio radio = comp as Radio;

                        if (radio != null && (radio.Name.IsEmpty() || this.AutomaticGrouping))
                        {
                            radio.SuspendScripting();
                            radio.Name = groupName;
                            radio.ResumeScripting();
                        }
                    }
                }
                else
                {
                    if (item.Name.IsEmpty() || this.AutomaticGrouping)
                    {
                        item.SuspendScripting();
                        item.Name = groupName;
                        item.ResumeScripting();
                    }
                }
            }
        }

        ItemsCollection<Radio> items;

        /// <summary>
        /// Items collection
        /// </summary>
        [Meta]
        [ConfigOption("items", typeof(ItemCollectionJsonConverter))]
        [Category("7. RadioGroup")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Items collection")]
        public virtual ItemsCollection<Radio> Items
        {
            get
            {
                if (this.items == null)
                {
                    this.items = new ItemsCollection<Radio>();
                    this.items.AfterItemAdd += AfterItemAdd;
                    this.items.AfterItemRemove += AfterItemRemove;
                }

                return this.items;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        [Description("")]
        protected override void AfterItemAdd(Observable item)
        {
            base.AfterItemAdd(item);

            Radio radio = (Radio)item;

            if (!this.DesignMode && this.AutomaticGrouping)
            {
                string groupName = this.GroupName.IsEmpty()
                                   ? this.ClientID + "_Group"
                                   : this.GroupName;

                RadioColumn rCol = radio as RadioColumn;

                if (rCol != null)
                {
                    foreach (Component comp in rCol.Items)
                    {
                        Radio radioItem = comp as Radio;

                        if (radioItem != null && (radioItem.Name.IsEmpty() || this.AutomaticGrouping))
                        {
                            radioItem.SuspendScripting();
                            radioItem.Name = groupName;
                            radioItem.ResumeScripting();
                        }
                    }
                }
                else
                {
                    if (radio.Name.IsEmpty() || this.AutomaticGrouping)
                    {
                        radio.SuspendScripting();
                        radio.Name = groupName;
                        radio.ResumeScripting();
                    }
                }
            }
        }

        IList IItems.ItemsList
        {
            get
            {
                return this.Items;
            }
        }

        /// <summary>
        /// Automatic grouping (defaults to true).
        /// </summary>
        [Meta]
        [Category("7. RadioGroup")]
        [Bindable(true, BindingDirection.TwoWay)]
        [DefaultValue(true)]
        [Description("Automatic grouping (defaults to true).")]
        public virtual bool AutomaticGrouping
        {
            get
            {
                object obj = this.ViewState["AutomaticGrouping"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["AutomaticGrouping"] = value;
            }
        }

        /// <summary>
        /// The field's HTML name attribute.
        /// </summary>
        [Meta]
        [Category("7. RadioGroup")]
        [DefaultValue("")]
        [Description("The field's HTML name attribute.")]
        public virtual string GroupName
        {
            get
            {
                return (string)this.ViewState["GroupName"] ?? "";
            }
            set
            {
                this.ViewState["GroupName"] = value;
            }
        }

        /// <summary>
        /// A List of Radio Controls in this RadioGroup that are Checked.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("A List of Radio Controls in this RadioGroup that are Checked.")]
        public virtual List<Radio> CheckedItems
        {
            get
            {
                return Utilities.ControlUtils.FindControls<Radio>(this).FindAll(cb => cb.Checked);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public virtual List<string> CheckedTags
        {
            get
            {
                return Utilities.ControlUtils.FindControls<Radio>(this).FindAll(cb => cb.Checked).ConvertAll(checkbox => checkbox.Tag);
            }
        }
        

        /*  DirectEvent Handler
            -----------------------------------------------------------------------------------------------*/

        static RadioGroup()
        {
            DirectEventChange = new object();
        }

        private static readonly object DirectEventChange;

        /// <summary>
        /// Server-side DirectEvent handler. Method signature is (object sender, DirectEventArgs e).
        /// </summary>
        [Description("Server-side DirectEvent handler. Method signature is (object sender, DirectEventArgs e).")]
        public event ComponentDirectEvent.DirectEventHandler DirectChange
        {
            add
            {
                this.DirectEvents.Change.Event += value;
            }
            remove
            {
                this.DirectEvents.Change.Event -= value;
            }
        }
    }
}