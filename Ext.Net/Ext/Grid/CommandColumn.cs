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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public partial class CommandColumn : ColumnBase, ICustomConfigSerialization, IIcon
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public CommandColumn() { }

        /// <summary>
        /// (optional) Specify as false to prevent the user from hiding this column. Defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. CommandColumn")]
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
        
        private GridCommandCollection commands;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("commands", JsonMode.AlwaysArray)]
        [Category("3. CommandColumn")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ViewStateMember]
        [Description("")]
        public virtual GridCommandCollection Commands
        {
            get
            {
                if (this.commands == null)
                {
                    this.commands = new GridCommandCollection();
                }

                return this.commands;
            }
        }

        private GridCommandCollection groupCommands;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("groupCommands", JsonMode.AlwaysArray)]
        [Category("3. CommandColumn")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ViewStateMember]
        [Description("")]
        public virtual GridCommandCollection GroupCommands
        {
            get
            {
                if (this.groupCommands == null)
                {
                    this.groupCommands = new GridCommandCollection();
                }

                return this.groupCommands;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string ToScript(Control owner)
        {
            return "new Ext.net.CommandColumn(".ConcatWith(new ClientConfig().Serialize(this, true), ")");
        }

        private void RegisterIcons(GridCommandCollection commands, List<Icon> icons)
        {
            foreach (GridCommandBase command in commands)
            {
                GridCommand cmd = command as GridCommand;

                if (cmd != null)
                {
                    if (cmd.Icon != Icon.None)
                    {
                        icons.Add(cmd.Icon);
                    }

                    if (cmd.Menu.Items.Count > 0)
                    {
                        this.RegisterMenuIcons(cmd.Menu, icons);
                    }
                }
            }
        }

        private void RegisterMenuIcons(CommandMenu menu, List<Icon> icons)
        {
            foreach (MenuCommand menuCommand in menu.Items)
            {
                if (menuCommand.Icon != Icon.None)
                {
                    icons.Add(menuCommand.Icon);
                }

                if (menuCommand.Menu.Items.Count > 0)
                {
                    this.RegisterMenuIcons(menuCommand.Menu, icons);
                }
            }
        }

        private JFunction prepareToolbar;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. CommandColumn")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public virtual JFunction PrepareToolbar
        {
            get
            {
                if (this.prepareToolbar == null)
                {
                    this.prepareToolbar = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.prepareToolbar.Args = new string[] { "grid", "toolbar", "rowIndex", "record" };
                    }
                    
                }

                return this.prepareToolbar;
            }
        }

        private JFunction prepareGroupToolbar;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. CommandColumn")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public virtual JFunction PrepareGroupToolbar
        {
            get
            {
                if (this.prepareGroupToolbar == null)
                {
                    this.prepareGroupToolbar = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.prepareGroupToolbar.Args = new string[] {"grid", "toolbar", "groupId", "records"};
                    }
                }

                return this.prepareGroupToolbar;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public System.Collections.Generic.List<Icon> Icons
        {
            get 
            {
                List<Icon> icons = new List<Icon>();
                
                RegisterIcons(this.Commands, icons);
                RegisterIcons(this.GroupCommands, icons);

                return icons;
            }
        }

        /// <summary>
        /// Valid values are "left", "center" and "right" (defaults to "left").
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("3. CommandColumn")]
        [DefaultValue(Alignment.Left)]
        [NotifyParentProperty(true)]
        [Description("Valid values are \"left\", \"center\" and \"right\" (defaults to \"left\").")]
        public virtual Alignment ButtonAlign
        {
            get
            {
                object obj = this.ViewState["ButtonAlign"];
                return (obj == null) ? Alignment.Left : (Alignment)obj;
            }
            set
            {
                this.ViewState["ButtonAlign"] = value;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public abstract partial class GridCommandBase : StateManagedItem { }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class GridCommandCollection : StateManagedCollection<GridCommandBase> { }
}