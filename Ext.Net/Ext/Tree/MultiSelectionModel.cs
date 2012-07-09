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
    /// Multi selection for a TreePanel.
    /// </summary>
    [ToolboxItem(false)]
    [Description("Multi selection for a TreePanel.")]
    public partial class MultiSelectionModel : AbstractTreeSelectionModel
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
                return "Ext.tree.MultiSelectionModel";
            }
        }

        /// <summary>
        /// Selection mode
        /// </summary>
        [ConfigOption(JsonMode.ToLower)]
        [Category("3. MultiSelectionModel")]
        [DefaultValue(KeepSelectionMode.WithCtrlKey)]
        [Description("Selection mode")]
        public virtual KeepSelectionMode KeepSelectionOnClick
        {
            get
            {
                object obj = this.ViewState["KeepSelectionOnClick"];
                return (obj == null) ? KeepSelectionMode.WithCtrlKey : (KeepSelectionMode)obj;
            }
            set
            {
                this.ViewState["KeepSelectionOnClick"] = value;
            }
        }

        private MultiSelectionModelListeners listeners;

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
        public MultiSelectionModelListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new MultiSelectionModelListeners();
                }

                return this.listeners;
            }
        }


        private MultiSelectionModelDirectEvents directEvents;

        /// <summary>
        /// Server-side DirectEvent Handlers
        /// </summary>
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]
        [ViewStateMember]
        [Description("Server-side DirectEventHandlers")]
        public MultiSelectionModelDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new MultiSelectionModelDirectEvents();
                }

                return this.directEvents;
            }
        }

        private List<SubmittedNode> selectedNodes;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual List<SubmittedNode> SelectedNodes
        {
            get
            {
                return this.selectedNodes;
            }
            protected internal set
            {
                this.selectedNodes = value;
            }
        }

        /// <summary>
        /// Clears all selections.
        /// </summary>
        [Description("Clears all selections.")]
        public virtual void ClearSelections()
        {
            this.Call("clearSelections");
        }

        /// <summary>
        /// Select a node.
        /// </summary>
        /// <param name="nodeId">The node to select</param>
        [Description("Select a node.")]
        public virtual void Select(string nodeId)
        {
            this.Call("select", new JRawValue(this.ClientID.ConcatWith(".getNodeById(", JSON.Serialize(nodeId), ")")));
        }

        /// <summary>
        /// Select a node.
        /// </summary>
        /// <param name="nodeId">The node to select</param>
        /// <param name="keepExisting">True to retain existing selections</param>
        [Description("Select a node.")]
        public virtual void Select(string nodeId, bool keepExisting)
        {
            this.Call("select", new JRawValue(this.ClientID.ConcatWith(".getNodeById(", JSON.Serialize(nodeId), ")")), null, keepExisting);
        }
        
        /// <summary>
        /// Deselect a node.
        /// </summary>
        /// <param name="nodeId">The node to unselect</param>
        [Description("Deselect a node.")]
        public virtual void Unselect(string nodeId)
        {
            this.Call("unselect", new JRawValue(this.ClientID.ConcatWith(".getNodeById(", JSON.Serialize(nodeId), ")")));
        }
    }
}