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

namespace Ext.Net
{
    /// <summary>
    /// An individual column's config object defines the header string, the Record field
    /// the column draws its data from, an optional rendering function to provide customized
    /// data formatting, and the ability to apply a CSS class to all cells in a column
    /// through its id config option.
    /// </summary>
    [Meta]
    [Description("An individual column's config object defines the header string, the Record field the column draws its data from, an optional rendering function to provide customized data formatting, and the ability to apply a CSS class to all cells in a column through its id config option.")]
    public partial class Column : ColumnBase, IIcon
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Column() { }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("xtype")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string XType
        {
            get
            {
                object obj = this.ViewState["XType"];
                return (obj == null) ? "" : (string)obj;
            }
            set
            {
                this.ViewState["XType"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual bool RightCommandAlign
        {
            get
            {
                object obj = this.ViewState["RightCommandAlign"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                this.ViewState["RightCommandAlign"] = value;
            }
        }        
        
        private ImageCommandCollection commands;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("commands", JsonMode.AlwaysArray)]
        [Category("2. Column")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ViewStateMember]
        [Description("")]
        public virtual ImageCommandCollection Commands
        {
            get
            {
                if (this.commands == null)
                {
                    this.commands = new ImageCommandCollection();
                }

                return this.commands;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [DefaultValue(false)]
        [ConfigOption]
		[Description("")]
        protected virtual bool IsCellCommand
        {
            get
            {
                return this.Commands.Count > 0;
            }
        }

        private JFunction prepareCommand;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("2. Column")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public virtual JFunction PrepareCommand
        {
            get
            {
                if (this.prepareCommand == null)
                {
                    this.prepareCommand = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.prepareCommand.Args = new string[] {"grid", "command", "record", "row", "col", "value"};
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
        [Category("2. Column")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public virtual JFunction PrepareCommands
        {
            get
            {
                if (this.prepareCommands == null)
                {
                    this.prepareCommands = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.prepareCommands.Args = new string[] {"grid", "commands", "record", "row", "col", "value"};
                    }
                }
                return this.prepareCommands;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual System.Collections.Generic.List<Icon> Icons
        {
            get
            {
                List<Icon> icons = new List<Icon>();

                foreach (ImageCommand command in this.Commands)
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