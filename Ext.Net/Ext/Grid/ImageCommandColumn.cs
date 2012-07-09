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
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public partial class ImageCommandColumn : Column, ICustomConfigSerialization
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ImageCommandColumn() { }

        /// <summary>
        /// (optional) Specify as false to prevent the user from hiding this column. Defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. ImageCommandColumn")]
        [DefaultValue(true)]
        [Description("(optional) Specify as false to prevent the user from hiding this column. Defaults to true.")]
        public override bool Hideable
        {
            get
            {
                object obj = this.ViewState["Hideable"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Hideable"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Ignore)]
        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [Description("")]
        public override bool RightCommandAlign
        {
            get
            {
                return false;
            }
            set
            {
            }
        }
        
        private GroupImageCommandCollection groupCommands;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("groupCommands", JsonMode.AlwaysArray)]
        [Category("3. ImageCommandColumn")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ViewStateMember]
        [Description("")]
        public virtual GroupImageCommandCollection GroupCommands
        {
            get
            {
                if (this.groupCommands == null)
                {
                    this.groupCommands = new GroupImageCommandCollection();
                }

                return this.groupCommands;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [DefaultValue(false)]
        [ConfigOption(JsonMode.Ignore)]
		[Description("")]
        protected override bool IsCellCommand
        {
            get
            {
                return false;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual string ToScript(Control owner)
        {
            return "new Ext.net.ImageCommandColumn(".ConcatWith(new ClientConfig().Serialize(this, true), ")");
        }

        private JFunction prepareGroupCommand;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. ImageCommandColumn")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public virtual JFunction PrepareGroupCommand
        {
            get
            {
                if (this.prepareGroupCommand == null)
                {
                    this.prepareGroupCommand = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.prepareGroupCommand.Args = new string[] {"grid", "command", "groupId", "group"};
                    }
                }

                return this.prepareGroupCommand;
            }
        }

        private JFunction prepareGroupCommands;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. ImageCommandColumn")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public virtual JFunction PrepareGroupCommands
        {
            get
            {
                if (this.prepareGroupCommands == null)
                {
                    this.prepareGroupCommands = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.prepareGroupCommands.Args = new string[] {"grid", "commands", "groupId", "group"};
                    }
                }
                return this.prepareGroupCommands;
            }
        }

        private JFunction prepareCommand;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. ImageCommandColumn")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public override JFunction PrepareCommand
        {
            get
            {
                if (this.prepareCommand == null)
                {
                    this.prepareCommand = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.prepareCommand.Args = new string[] {"grid", "command", "record", "row"};
                    }
                }

                return this.prepareCommand;
            }
        }

        private JFunction prepareCommands;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. ImageCommandColumn")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public override JFunction PrepareCommands
        {
            get
            {
                if (this.prepareCommands == null)
                {
                    this.prepareCommands = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.prepareCommands.Args = new string[] {"grid", "commands", "record", "row"};
                    }
                }
                return this.prepareCommands;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public override System.Collections.Generic.List<Icon> Icons
        {
            get
            {
                List<Icon> icons = base.Icons;

                foreach (GroupImageCommand command in this.GroupCommands)
                {
                    if (command.Icon != Icon.None)
                    {
                        icons.Add(command.Icon);
                    }
                }

                return icons;
            }
        }
    }
}