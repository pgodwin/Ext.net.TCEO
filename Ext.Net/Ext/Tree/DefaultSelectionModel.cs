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
using System.Web.UI;
using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// The default single selection for a TreePanel.
    /// </summary>
    [ToolboxItem(false)]
    [Description("The default single selection for a TreePanel.")]
    public partial class DefaultSelectionModel : AbstractTreeSelectionModel
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
                return "Ext.tree.DefaultSelectionModel";
            }
        }

        private DefaultSelectionModelListeners listeners;

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
        public DefaultSelectionModelListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new DefaultSelectionModelListeners();
                }

                return this.listeners;
            }
        }


        private DefaultSelectionModelDirectEvents directEvents;

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
        public DefaultSelectionModelDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new DefaultSelectionModelDirectEvents();
                }

                return this.directEvents;
            }
        }

        private SubmittedNode selectedNode;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual SubmittedNode SelectedNode
        {
            get
            {
                return this.selectedNode;
            }
            protected internal set
            {
                this.selectedNode = value;
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
        /// Selects the node above the selected node in the tree, intelligently walking the nodes
        /// </summary>
        [Description("Selects the node above the selected node in the tree, intelligently walking the nodes")]
        public virtual void SelectNext()
        {
            this.Call("selectNext");
        }

        /// <summary>
        /// Selects the node above the selected node in the tree, intelligently walking the nodes
        /// </summary>
        [Description("Selects the node above the selected node in the tree, intelligently walking the nodes")]
        public virtual void SelectPrevious()
        {
            this.Call("selectPrevious");
        }

        /// <summary>
        /// Deselect a node.
        /// </summary>
        [Description("Deselect a node.")]
        public virtual void Unselect()
        {
            this.Call("unselect");
        }
    }
}