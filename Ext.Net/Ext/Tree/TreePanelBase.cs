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
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public abstract partial class TreePanelBase : PanelBase, INoneContentable
    {
        /// <summary>
        /// true to allow append to the leaf node
        /// </summary>
        [ConfigOption]
        [Category("7. TreePanel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("true to allow append to the leaf node")]
        public virtual bool AllowLeafDrop
        {
            get
            {
                object obj = this.ViewState["AllowLeafDrop"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["AllowLeafDrop"] = value;
            }
        }

        /// <summary>
        /// true to enable animated expand/collapse (defaults to the value of Ext.enableFx)
        /// </summary>
        [ConfigOption]
        [Category("7. TreePanel")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("true to enable animated expand/collapse (defaults to the value of Ext.enableFx)")]
        public virtual bool Animate
        {
            get
            {
                object obj = this.ViewState["Animate"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["Animate"] = value;
            }
        }

        /// <summary>
        /// True to register this container with ScrollManager
        /// </summary>
        [ConfigOption]
        [Category("7. TreePanel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to register this container with ScrollManager")]
        public virtual bool ContainerScroll
        {
            get
            {
                object obj = this.ViewState["ContainerScroll"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["ContainerScroll"] = value;
            }
        }

        /// <summary>
        /// True if the tree should only allow append drops (use for trees which are sorted)
        /// </summary>
        [ConfigOption("ddAppendOnly")]
        [Category("7. TreePanel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True if the tree should only allow append drops (use for trees which are sorted)")]
        public virtual bool DDAppendOnly
        {
            get
            {
                object obj = this.ViewState["DDAppendOnly"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["DDAppendOnly"] = value;
            }
        }

        /// <summary>
        /// The DD group this TreePanel belongs to
        /// </summary>
        [ConfigOption("ddGroup")]
        [Category("7. TreePanel")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The DD group this TreePanel belongs to")]
        public virtual string DDGroup
        {
            get
            {
                return (string)this.ViewState["DDGroup"] ?? "";
            }
            set
            {
                this.ViewState["DDGroup"] = value;
            }
        }

        /// <summary>
        /// True to enable body scrolling
        /// </summary>
        [ConfigOption("ddScroll")]
        [Category("7. TreePanel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to enable body scrolling")]
        public virtual bool DDScroll
        {
            get
            {
                object obj = this.ViewState["DDScroll"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["DDScroll"] = value;
            }
        }

        private TreeDragZone dragConfig;

        /// <summary>
        /// Custom config to pass to the Ext.tree.TreeDragZone instance
        /// </summary>
        [Category("7. TreePanel")]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Custom config to pass to the Ext.tree.TreeDragZone instance")]
        public virtual TreeDragZone DragConfig
        {
            get
            {
                if (this.dragConfig == null)
                {
                    this.dragConfig = new TreeDragZone();
                }

                return this.dragConfig;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("dragConfig", JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected virtual string DragConfigProxy
        {
            get
            {
                string cfg = new ClientConfig().Serialize(this.DragConfig, true);
                return cfg == "{}" ? "" : cfg;
            }
        }

        private TreeDropZone dropConfig;

        /// <summary>
        /// Custom config to pass to the Ext.tree.TreeDropZone instance
        /// </summary>
        [Category("7. TreePanel")]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Custom config to pass to the Ext.tree.TreeDropZone instance")]
        public virtual TreeDropZone DropConfig
        {
            get
            {
                if (this.dropConfig == null)
                {
                    this.dropConfig = new TreeDropZone();
                }

                return this.dropConfig;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("dropConfig", JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected virtual string DropConfigProxy
        {
            get
            {
                string cfg = new ClientConfig().Serialize(this.DropConfig, true);
                return cfg == "{}" ? "" : cfg;
            }
        }

        /// <summary>
        /// True to enable drag and drop
        /// </summary>
        [ConfigOption]
        [Category("7. TreePanel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to enable drag and drop")]
        public virtual bool EnableDD
        {
            get
            {
                object obj = this.ViewState["EnableDD"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["EnableDD"] = value;
            }
        }

        /// <summary>
        /// True to enable just drag
        /// </summary>
        [ConfigOption]
        [Category("7. TreePanel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to enable just drag")]
        public virtual bool EnableDrag
        {
            get
            {
                object obj = this.ViewState["EnableDrag"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["EnableDrag"] = value;
            }
        }

        /// <summary>
        /// True to enable just drop
        /// </summary>
        [ConfigOption]
        [Category("7. TreePanel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to enable just drop")]
        public virtual bool EnableDrop
        {
            get
            {
                object obj = this.ViewState["EnableDrop"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["EnableDrop"] = value;
            }
        }

        /// <summary>
        /// The color of the node highlight (defaults to C3DAF9)
        /// </summary>
        [ConfigOption("hlColor")]
        [Category("7. TreePanel")]
        [DefaultValue("C3DAF9")]
        [NotifyParentProperty(true)]
        [Description("The color of the node highlight (defaults to C3DAF9)")]
        public virtual string HighlightColor
        {
            get
            {
                return (string)this.ViewState["HighlightColor"] ?? "C3DAF9";
            }
            set
            {
                this.ViewState["HighlightColor"] = value;
            }
        }

        /// <summary>
        /// False to disable node highlight on drop (defaults to the value of Ext.enableFx)
        /// </summary>
        [ConfigOption("hlDrop")]
        [Category("7. TreePanel")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("False to disable node highlight on drop (defaults to the value of Ext.enableFx)")]
        public virtual bool HighlightDrop
        {
            get
            {
                object obj = this.ViewState["HighlightDrop"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["HighlightDrop"] = value;
            }
        }

        /// <summary>
        /// False to disable tree lines (defaults to true)
        /// </summary>
        [ConfigOption]
        [Category("7. TreePanel")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("False to disable tree lines (defaults to true)")]
        public virtual bool Lines
        {
            get
            {
                object obj = this.ViewState["Lines"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["Lines"] = value;
            }
        }

        /// <summary>
        /// The token used to separate sub-paths in path strings (defaults to '/')
        /// </summary>
        [ConfigOption]
        [Category("7. TreePanel")]
        [DefaultValue("/")]
        [NotifyParentProperty(true)]
        [Description("The token used to separate sub-paths in path strings (defaults to '/')")]
        public virtual string PathSeparator
        {
            get
            {
                return (string)this.ViewState["PathSeparator"] ?? "/";
            }
            set
            {
                this.ViewState["PathSeparator"] = value;
            }
        }

        /// <summary>
        /// Active editor id
        /// </summary>
        [ConfigOption]
        [Category("7. TreePanel")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Active editor id")]
        public virtual string ActiveEditor
        {
            get
            {
                return (string)this.ViewState["ActiveEditor"] ?? "";
            }
            set
            {
                this.ViewState["ActiveEditor"] = value;
            }
        }

        private TreeNodeCollection root;

        /// <summary>
        /// The root node for the tree.
        /// </summary>
        [Category("7. TreePanel")]
        [NotifyParentProperty(true)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The root node for the tree.")]
        public virtual TreeNodeCollection Root
        {
            get
            {
                if (this.root == null)
                {
                    this.root = new TreeNodeCollection(true);
                    this.root.Owner = this;
                }

                return this.root;
            }
        }

        private TreeLoaderCollection treeLoader;

        /// <summary>
        /// The root node for the tree.
        /// </summary>
        [ConfigOption("loader>Primary")]
        [Category("7. TreePanel")]
        [NotifyParentProperty(true)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The root node for the tree.")]
        public virtual TreeLoaderCollection Loader
        {
            get
            {
                if (this.treeLoader == null)
                {
                    this.treeLoader = new TreeLoaderCollection();
                }

                return this.treeLoader;
            }
        }

        /// <summary>
        /// false to hide the root node (defaults to true)
        /// </summary>
        [ConfigOption]
        [Category("7. TreePanel")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("false to hide the root node (defaults to true)")]
        public virtual bool RootVisible
        {
            get
            {
                object obj = this.ViewState["RootVisible"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["RootVisible"] = value;
            }
        }

        private TreeSelectionModelCollection selectionModel;

        /// <summary>
        /// A tree selection model to use with this TreePanel (defaults to an Ext.tree.DefaultSelectionModel)
        /// </summary>
        [ConfigOption("selModel>Primary")]
        [Category("7. TreePanel")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("A tree selection model to use with this TreePanel (defaults to an Ext.tree.DefaultSelectionModel)")]
        public virtual TreeSelectionModelCollection SelectionModel
        {
            get
            {
                if (this.selectionModel == null)
                {
                    this.selectionModel = new TreeSelectionModelCollection();
                    this.selectionModel.AfterItemAdd += this.AfterTreeItemAdd;
                    this.selectionModel.AfterItemRemove += this.AfterTreeItemRemove;
                }

                return this.selectionModel;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        [Description("")]
        protected virtual void AfterTreeItemAdd(Observable item)
        {
            this.Controls.AddAt(0, item);
            this.LazyItems.Insert(0, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        [Description("")]
        protected virtual void AfterTreeItemRemove(Observable item)
        {
            this.Controls.Remove(item);
            this.LazyItems.Remove(item);
        }

        /// <summary>
        /// true if only 1 node per branch may be expanded
        /// </summary>
        [ConfigOption]
        [Category("7. TreePanel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("true if only 1 node per branch may be expanded")]
        public virtual bool SingleExpand
        {
            get
            {
                object obj = this.ViewState["SingleExpand"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["SingleExpand"] = value;
            }
        }

        /// <summary>
        /// False to disable mouse over highlighting
        /// </summary>
        [ConfigOption]
        [Category("7. TreePanel")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("False to disable mouse over highlighting")]
        public virtual bool TrackMouseOver
        {
            get
            {
                object obj = this.ViewState["TrackMouseOver"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["TrackMouseOver"] = value;
            }
        }

        /// <summary>
        /// True to use Vista-style arrows in the tree (defaults to false)
        /// </summary>
        [ConfigOption]
        [Category("7. TreePanel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to use Vista-style arrows in the tree (defaults to false)")]
        public virtual bool UseArrows
        {
            get
            {
                object obj = this.ViewState["UseArrows"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["UseArrows"] = value;
            }
        }

        /// <summary>
        /// if true then leaf node has no icon
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. TreeGrid")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("if true then leaf node has no icon")]
        public virtual bool NoLeafIcon
        {
            get
            {
                object obj = this.ViewState["NoLeafIcon"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["NoLeafIcon"] = value;
            }
        }

        private ItemsCollection<TreeEditor> editors;

        /// <summary>
        /// A collection of editors configs
        /// </summary>
        [Meta]
        [ConfigOption("editors", typeof(ItemCollectionJsonConverter))]
        [Category("7. TreePanel")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("A collection of editors configs")]
        public virtual ItemsCollection<TreeEditor> Editors
        {
            get
            {
                if (this.editors == null)
                {
                    this.editors = new ItemsCollection<TreeEditor>();
                    this.editors.AfterItemAdd += this.AfterTreeItemAdd;
                    this.editors.AfterItemRemove += this.AfterTreeItemRemove;
                }

                return this.editors;
            }
        }

        private TreeSubmitConfig selectionSubmitConfig;

        /// <summary>
        /// Selection submit config
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Object)]
        [Category("7. TreePanel")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Selection submit config")]
        public virtual TreeSubmitConfig SelectionSubmitConfig
        {
            get
            {
                if (this.selectionSubmitConfig == null)
                {
                    this.selectionSubmitConfig = new TreeSubmitConfig();
                }

                return this.selectionSubmitConfig;
            }
        }

        private TreeSorter treeSorter;

        /// <summary>
        /// Provides sorting of nodes in a Ext.tree.TreePanel.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Object)]
        [Category("7. TreePanel")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Provides sorting of nodes in a Ext.tree.TreePanel.")]
        public virtual TreeSorter Sorter
        {
            get
            {
                if (this.treeSorter == null)
                {
                    this.treeSorter = new TreeSorter();
                }

                return this.treeSorter;
            }
        }

        private BaseDirectEvent directEventConfig;

        /// <summary>
        /// 
        /// </summary>
        [Category("7. TreePanel")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [ConfigOption(JsonMode.Object)]
        [Description("")]
        public BaseDirectEvent DirectEventConfig
        {
            get
            {
                if (this.directEventConfig == null)
                {
                    this.directEventConfig = new BaseDirectEvent();
                }

                return this.directEventConfig;
            }
        }

        /// <summary>
        /// Set to Remote need perform remote confirmation for basic operations.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("7. TreePanel")]
        [DefaultValue(TreePanelMode.Local)]
        [Description("Set to Remote need perform remote confirmation for basic operations.")]
        public virtual TreePanelMode Mode
        {
            get
            {
                object obj = this.ViewState["Mode"];
                return (obj == null) ? TreePanelMode.Local : (TreePanelMode)obj;
            }
            set
            {
                this.ViewState["Mode"] = value;
            }
        }

        /// <summary>
        /// True to use json mode 
        /// </summary>
        [ConfigOption]
        [Category("7. TreePanel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to use json mode")]
        public virtual bool RemoteJson
        {
            get
            {
                object obj = this.ViewState["RemoteJson"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["RemoteJson"] = value;
            }
        }
        
        /// <summary>
        /// The list of actions which must be local (even if Mode='Remote')
        /// </summary>
        [Category("7. TreePanel")]
        [ConfigOption(typeof(StringArrayJsonConverter))]
        [TypeConverter(typeof(StringArrayConverter))]
        [DefaultValue(null)]
        [Description("The list of actions which must be local (even if Mode='Remote')")]
        public virtual string[] LocalActions
        {
            get
            {
                object obj = this.ViewState["LocalActions"];
                return (obj == null) ? null : (string[])obj;
            }
            set
            {
                this.ViewState["LocalActions"] = value;
            }
        }

        private ParameterCollection remoteExtraParams;

        /// <summary>
        /// An object containing properties which are to be sent as parameters on any remote action request.
        /// </summary>
        [Meta]
        [Category("7. TreePanel")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ViewStateMember]
        [Description("An object containing properties which are to be sent as parameters on any remote action request.")]
        public virtual ParameterCollection RemoteExtraParams
        {
            get
            {
                if (this.remoteExtraParams == null)
                {
                    this.remoteExtraParams = new ParameterCollection();
                    this.remoteExtraParams.Owner = this;
                }

                return this.remoteExtraParams;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [DefaultValue("")]
        protected internal virtual string Nodes
        {
            get
            {
                if (this.Root.Count > 0)
                {                    
                    if (this.Root.Primary is TreeNode)
                    {
                        TreeNode rootNode = (TreeNode) this.Root.Primary;
                        rootNode.Owner = this;

                        StringBuilder sb = new StringBuilder(256);
                        sb.Append("[");
                        this.AddChildes(rootNode, sb);
                        sb.Append("]");

                        return sb.ToString();
                    }
                    else
                    {
                        return "[".ConcatWith(new ClientConfig().Serialize(this.Root.Primary), "]");
                    }
                }

                return "";
            }
        }

        private void AddChildes(TreeNode parent, StringBuilder sb)
        {
            string cfg = new ClientConfig().Serialize(parent);

            if (parent.Nodes.Count > 0)
            {
                bool addComma = cfg.Length > 2;
                int index = cfg.LastIndexOf("}");
                sb.Append(cfg.Substring(0, index));

                sb.Append(addComma ? ",":"").Append("children:[");

                foreach (TreeNodeBase node in parent.Nodes)
                {
                    node.Owner = this;
                    
                    if (node is TreeNode)
                    {
                        TreeNode treeNode = (TreeNode) node;
                        this.AddChildes(treeNode, sb);
                    }
                    else
                    {
                        sb.Append(new ClientConfig().Serialize(node));
                    }

                    sb.Append(",");
                }

                if (sb[sb.Length - 1] == ',')
                {
                    sb.Remove(sb.Length - 1, 1);
                }
                sb.Append("");
                sb.Append("]}");
            }
            else
            {
                sb.Append(cfg);
            }
        }

        private List<SubmittedNode> checkedNodes;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual List<SubmittedNode> CheckedNodes
        {
            get
            {
                return this.checkedNodes;
            }
            protected internal set
            {
                this.checkedNodes = value;
            }
        }

        #region TreeNode's methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        [Description("")]
        public Element GetNodeUIWrap(string nodeId)
        {
            return new Element("{0}.getNodeById({1}).ui.getEl()".FormatWith(this.ClientID, JSON.Serialize(nodeId)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        [Description("")]
        public Element GetNodeUIElement(string nodeId)
        {
            return new Element("Ext.get({0}.getNodeById({1}).ui.elNode)".FormatWith(this.ClientID, JSON.Serialize(nodeId)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        [Description("")]
        public Element GetNodeUIContainer(string nodeId)
        {
            return new Element("Ext.get({0}.getNodeById({1}).ui.ctNode)".FormatWith(this.ClientID, JSON.Serialize(nodeId)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        [Description("")]
        public Element GetNodeUIIndent(string nodeId)
        {
            return new Element("Ext.get({0}.getNodeById({1}).ui.indentNode)".FormatWith(this.ClientID, JSON.Serialize(nodeId)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        [Description("")]
        public Element GetNodeUIIcon(string nodeId)
        {
            return new Element("Ext.get({0}.getNodeById({1}).ui.iconNode)".FormatWith(this.ClientID, JSON.Serialize(nodeId)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        [Description("")]
        public Element GetNodeUIAnchor(string nodeId)
        {
            return new Element("Ext.get({0}.getNodeById({1}).ui.anchor)".FormatWith(this.ClientID, JSON.Serialize(nodeId)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        [Description("")]
        public Element GetNodeUIText(string nodeId)
        {
            return new Element("Ext.get({0}.getNodeById({1}).ui.textNode)".FormatWith(this.ClientID, JSON.Serialize(nodeId)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        [Description("")]
        public string GetNodeDescriptor(string nodeId)
        {
            return "{0}.getNodeById({1})".FormatWith(this.ClientID, JSON.Serialize(nodeId));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="method"></param>
        /// <param name="nodeId"></param>
        /// <param name="args"></param>
        [Description("")]
        public void CallNode(string method, string nodeId, params object[] args)
        {
            this.CallTemplate("{0}.getNodeById(".ConcatWith(JSON.Serialize(nodeId),").{1}({2});"), method, args);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="method"></param>
        /// <param name="nodeId"></param>
        /// <param name="args"></param>
        [Description("")]
        public void CallNodeUI(string method, string nodeId, params object[] args)
        {
            this.CallTemplate("{0}.getNodeById(".ConcatWith(JSON.Serialize(nodeId), ").ui.{1}({2});"), method, args);
        }

        /// <summary>
        /// Insert node as the last child node of this node.
        /// </summary>
        /// <param name="nodeId">Node id</param>
        /// <param name="node">The node to append</param>
        [Description("Insert node as the last child node of this node.")]
        public void AppendChild(string nodeId, TreeNodeBase node)
        {
            this.CallNode("appendChild", nodeId, new JRawValue(node.ToScript(false)));
        }

        /// <summary>
        /// Insert nodes as the last child node of this node.
        /// </summary>
        /// <param name="nodeId">Node id</param>
        /// <param name="nodes">Array of nodes to append</param>
        [Description("Insert nodes as the last child node of this node.")]
        public void AppendChild(string nodeId, IEnumerable<TreeNodeBase> nodes)
        {
            List<JRawValue> listNodes = new List<JRawValue>();

            foreach (TreeNodeBase node in nodes)
            {
                listNodes.Add(new JRawValue(node.ToScript(false)));
            }

            this.CallNode("appendChild", nodeId, listNodes);
        }

        /// <summary>
        /// Bubbles up the tree from this node, calling the specified function with each node. The scope (this) of function call will be the scope provided or the current node. The arguments to the function will be the args provided or the current node. If the function returns false at any point, the bubble is stopped.
        /// </summary>
        /// <param name="nodeId">Node id</param>
        /// <param name="fn">The function to call</param>
        /// <param name="scope">The scope of the function (defaults to current node)</param>
        /// <param name="args">The args to call the function with (default to passing the current node)</param>
        [Description("Bubbles up the tree from this node, calling the specified function with each node. The scope (this) of function call will be the scope provided or the current node. The arguments to the function will be the args provided or the current node. If the function returns false at any point, the bubble is stopped.")]
        public void Bubble(string nodeId, JFunction fn, string scope, string[] args)
        {
            this.CallNode("bubble", nodeId, fn, new JRawValue(scope), args);
        }

        /// <summary>
        /// Bubbles up the tree from this node, calling the specified function with each node. The scope (this) of function call will be the scope provided or the current node. The arguments to the function will be the args provided or the current node. If the function returns false at any point, the bubble is stopped.
        /// </summary>
        /// <param name="nodeId">Node id</param>
        /// <param name="fn">The function to call</param>
        [Description("Bubbles up the tree from this node, calling the specified function with each node. The scope (this) of function call will be the scope provided or the current node. The arguments to the function will be the args provided or the current node. If the function returns false at any point, the bubble is stopped.")]
        public void Bubble(string nodeId, JFunction fn)
        {
            this.CallNode("bubble", nodeId, fn);
        }

        /// <summary>
        /// Cascades down the tree from this node, calling the specified function with each node. The scope (this) of function call will be the scope provided or the current node. The arguments to the function will be the args provided or the current node. If the function returns false at any point, the cascade is stopped on that branch.
        /// </summary>
        /// <param name="nodeId">Node id</param>
        /// <param name="fn">The function to call</param>
        /// <param name="scope">The scope of the function (defaults to current node)</param>
        /// <param name="args">The args to call the function with (default to passing the current node)</param>
        [Description("Cascades down the tree from this node, calling the specified function with each node. The scope (this) of function call will be the scope provided or the current node. The arguments to the function will be the args provided or the current node. If the function returns false at any point, the cascade is stopped on that branch.")]
        public void Cascade(string nodeId, JFunction fn, string scope, string[] args)
        {
            this.CallNode("cascade", nodeId, fn, new JRawValue(scope), args);
        }

        /// <summary>
        /// Cascades down the tree from this node, calling the specified function with each node. The scope (this) of function call will be the scope provided or the current node. The arguments to the function will be the args provided or the current node. If the function returns false at any point, the cascade is stopped on that branch.
        /// </summary>
        /// <param name="nodeId">Node id</param>
        /// <param name="fn">The function to call</param>
        [Description("Cascades down the tree from this node, calling the specified function with each node. The scope (this) of function call will be the scope provided or the current node. The arguments to the function will be the args provided or the current node. If the function returns false at any point, the cascade is stopped on that branch.")]
        public void Cascade(string nodeId, JFunction fn)
        {
            this.CallNode("cascade", nodeId, fn);
        }

        /// <summary>
        /// Collapse this node.
        /// </summary>
        /// <param name="nodeId">Node id</param>
        /// <param name="deep">True to collapse all children as well</param>
        /// <param name="anim">false to cancel the default animation</param>
        /// <param name="callback">A callback to be called when collapsing this node completes (does not wait for deep expand to complete). Called with 1 parameter, this node.</param>
        /// <param name="scope">The scope in which to execute the callback.</param>
        [Description("Collapse this node.")]
        public void CollapseNode(string nodeId, bool deep, bool anim, JFunction callback, string scope)
        {
            this.CallNode("collapse", nodeId, deep, anim, callback, new JRawValue(scope));
        }

        /// <summary>
        /// Collapse this node.
        /// </summary>
        /// <param name="nodeId">Node id</param>
        /// <param name="deep">True to collapse all children as well</param>
        /// <param name="anim">false to cancel the default animation</param>
        /// <param name="callback">A callback to be called when collapsing this node completes (does not wait for deep expand to complete). Called with 1 parameter, this node.</param>
        [Description("Collapse this node.")]
        public void CollapseNode(string nodeId, bool deep, bool anim, JFunction callback)
        {
            this.CallNode("collapse", nodeId, deep, anim, callback);
        }

        /// <summary>
        /// Collapse this node.
        /// </summary>
        /// <param name="nodeId">Node id</param>
        /// <param name="deep">True to collapse all children as well</param>
        /// <param name="anim">false to cancel the default animation</param>
        [Description("Collapse this node.")]
        public void CollapseNode(string nodeId, bool deep, bool anim)
        {
            this.CallNode("collapse", nodeId, deep, anim);
        }

        /// <summary>
        /// Collapse this node.
        /// </summary>
        /// <param name="nodeId">Node id</param>
        /// <param name="deep">True to collapse all children as well</param>
        [Description("Collapse this node.")]
        public void CollapseNode(string nodeId, bool deep)
        {
            this.CallNode("collapse", nodeId, deep);
        }

        /// <summary>
        /// Collapse this node.
        /// </summary>
        /// <param name="nodeId">Node id</param>
        [Description("Collapse this node.")]
        public void CollapseNode(string nodeId)
        {
            this.CallNode("collapse", nodeId);
        }

        /// <summary>
        /// Collapse all child nodes
        /// </summary>
        /// <param name="nodeId">Node id</param>
        /// <param name="deep">true if the child nodes should also collapse their child nodes</param>
        [Description("Collapse all child nodes")]
        public void CollapseChildNodes(string nodeId, bool deep)
        {
            this.CallNode("collapseChildNodes", nodeId, deep);
        }

        /// <summary>
        /// Collapse all child nodes
        /// </summary>
        /// <param name="nodeId">Node id</param>
        [Description("Collapse all child nodes")]
        public void CollapseChildNodes(string nodeId)
        {
            this.CallNode("collapseChildNodes", nodeId);
        }

        /// <summary>
        ///  Destroys the node.
        /// </summary>
        /// <param name="nodeId">Node id</param>
        [Description("Destroys the node.")]
        public void Destroy(string nodeId)
        {
            this.CallNode("destroy", nodeId);
        }


        /// <summary>
        /// Disables this node
        /// </summary>
        /// <param name="nodeId">Node id</param>
        [Description("Disables this node")]
        public void DisableNode(string nodeId)
        {
            this.CallNode("disable", nodeId);
        }

        /// <summary>
        /// Interates the child nodes of this node, calling the specified function with each node. The scope (this) of function call will be the scope provided or the current node. The arguments to the function will be the args provided or the current node. If the function returns false at any point, the iteration stops.
        /// </summary>
        /// <param name="nodeId">Node id</param>
        /// <param name="fn">The function to call</param>
        /// <param name="scope">The scope of the function (defaults to current node)</param>
        /// <param name="args">The args to call the function with (default to passing the current node)</param>
        [Description("Interates the child nodes of this node, calling the specified function with each node. The scope (this) of function call will be the scope provided or the current node. The arguments to the function will be the args provided or the current node. If the function returns false at any point, the iteration stops.")]
        public void EachChild(string nodeId, JFunction fn, string scope, string[] args)
        {
            this.CallNode("eachChild", nodeId, fn, new JRawValue(scope), args);
        }

        /// <summary>
        /// Interates the child nodes of this node, calling the specified function with each node. The scope (this) of function call will be the scope provided or the current node. The arguments to the function will be the args provided or the current node. If the function returns false at any point, the iteration stops.
        /// </summary>
        /// <param name="nodeId">Node id</param>
        /// <param name="fn">The function to call</param>
        [Description("Interates the child nodes of this node, calling the specified function with each node. The scope (this) of function call will be the scope provided or the current node. The arguments to the function will be the args provided or the current node. If the function returns false at any point, the iteration stops.")]
        public void EachChild(string nodeId, JFunction fn)
        {
            this.CallNode("eachChild", nodeId, fn);
        }

        /// <summary>
        /// Enables this node
        /// </summary>
        /// <param name="nodeId">Node id</param>
        [Description("Enables this node")]
        public void EnableNode(string nodeId)
        {
            this.CallNode("enable", nodeId);
        }

        /// <summary>
        /// Ensures all parent nodes are expanded, and if necessary, scrolls the node into view.
        /// </summary>
        /// <param name="nodeId">Node id</param>
        /// <param name="callback">A function to call when the node has been made visible.</param>
        /// <param name="scope">The scope in which to execute the callback.</param>
        [Description("Ensures all parent nodes are expanded, and if necessary, scrolls the node into view.")]
        public void EnsureNodeVisible(string nodeId, JFunction callback, string scope)
        {
            this.CallNode("ensureVisible", nodeId, callback, new JRawValue(scope));
        }

        /// <summary>
        /// Ensures all parent nodes are expanded, and if necessary, scrolls the node into view.
        /// </summary>
        /// <param name="nodeId">Node id</param>
        /// <param name="callback">A function to call when the node has been made visible.</param>
        [Description("Ensures all parent nodes are expanded, and if necessary, scrolls the node into view.")]
        public void EnsureNodeVisible(string nodeId, JFunction callback)
        {
            this.CallNode("ensureVisible", nodeId, callback);
        }

        /// <summary>
        /// Ensures all parent nodes are expanded, and if necessary, scrolls the node into view.
        /// </summary>
        /// <param name="nodeId">Node id</param>
        [Description("Ensures all parent nodes are expanded, and if necessary, scrolls the node into view.")]
        public void EnsureNodeVisible(string nodeId)
        {
            this.CallNode("ensureVisible", nodeId);
        }


        /// <summary>
        /// Expand this node.
        /// </summary>
        /// <param name="nodeId">Node id</param>
        /// <param name="deep">True to expand all children as well</param>
        /// <param name="anim">false to cancel the default animation</param>
        /// <param name="callback">A callback to be called when expanding this node completes (does not wait for deep expand to complete). Called with 1 parameter, this node.</param>
        /// <param name="scope">The scope in which to execute the callback.</param>
        [Description("Expand this node.")]
        public void ExpandNode(string nodeId, bool deep, bool anim, JFunction callback, string scope)
        {
            this.CallNode("expand", nodeId, deep, anim, callback, new JRawValue(scope));
        }

        /// <summary>
        /// Expand this node.
        /// </summary>
        /// <param name="nodeId">Node id</param>
        /// <param name="deep">True to expand all children as well</param>
        /// <param name="anim">false to cancel the default animation</param>
        /// <param name="callback">A callback to be called when expanding this node completes (does not wait for deep expand to complete). Called with 1 parameter, this node.</param>
        [Description("Expand this node.")]
        public void ExpandNode(string nodeId, bool deep, bool anim, JFunction callback)
        {
            this.CallNode("expand", nodeId, deep, anim, callback);
        }

        /// <summary>
        /// Expand this node.
        /// </summary>
        /// <param name="nodeId">Node id</param>
        /// <param name="deep">True to expand all children as well</param>
        /// <param name="anim">false to cancel the default animation</param>
        [Description("Expand this node.")]
        public void ExpandNode(string nodeId, bool deep, bool anim)
        {
            this.CallNode("expand", nodeId, deep, anim);
        }

        /// <summary>
        /// Expand this node.
        /// </summary>
        /// <param name="nodeId">Node id</param>
        /// <param name="deep">True to expand all children as well</param>
        [Description("Expand this node.")]
        public void ExpandNode(string nodeId, bool deep)
        {
            this.CallNode("expand", nodeId, deep);
        }

        /// <summary>
        /// Expand this node.
        /// </summary>
        /// <param name="nodeId">Node id</param>
        [Description("Expand this node.")]
        public void ExpandNode(string nodeId)
        {
            this.CallNode("expand", nodeId);
        }

        /// <summary>
        /// Expand all child nodes
        /// </summary>
        /// <param name="nodeId">Node id</param>
        /// <param name="deep">true if the child nodes should also expand their child nodes</param>
        [Description("Expand all child nodes")]
        public void ExpandChildNodes(string nodeId, bool deep)
        {
            this.CallNode("expandChildNodes", nodeId, deep);
        }

        /// <summary>
        /// Expand all child nodes
        /// </summary>
        /// <param name="nodeId">Node id</param>
        [Description("Expand all child nodes")]
        public void ExpandChildNodes(string nodeId)
        {
            this.CallNode("expandChildNodes", nodeId);
        }

        /// <summary>
        /// Inserts the first node before the second node in this nodes childNodes collection.
        /// </summary>
        /// <param name="nodeId">Node id</param>
        /// <param name="newNode">The node to insert</param>
        /// <param name="refNodeId">The node to insert before (if null the node is appended)</param>
        [Description("Inserts the first node before the second node in this nodes childNodes collection.")]
        public void InsertBeforeChild(string nodeId, TreeNodeBase newNode, string refNodeId)
        {
            this.CallNode("insertBefore", 
                          nodeId,
                          new JRawValue(newNode.ToScript(false)),
                          new JRawValue(this.ClientID.ConcatWith(".getNodeById(", JSON.Serialize(refNodeId), ")")));
        }

        /// <summary>
        /// Appends an event handler to the node
        /// </summary>
        /// <param name="nodeId">Node id</param>
        /// <param name="eventName">The type of event to listen for</param>
        /// <param name="fn">The method the event invokes</param>
        [Description("Appends an event handler to the node")]
        public virtual void NodeOn(string nodeId, string eventName, JFunction fn)
        {
            this.CallNode("on", nodeId, eventName.ToLower(), new JRawValue(TokenUtils.ParseAndNormalize(fn.ToScript(), this)));
        }

        /// <summary>
        /// Appends an event handler to the node
        /// </summary>
        /// <param name="nodeId">Node id</param>
        /// <param name="eventName">The type of event to listen for</param>
        /// <param name="fn">The method the event invokes</param>
        /// <param name="scope">The scope (this reference) in which the handler function is executed. If omitted, defaults to the object which fired the event.</param>
        /// <param name="options">An object containing handler configuration.</param>
        [Description("Appends an event handler to the node")]
        public virtual void NodeOn(string nodeId, string eventName, JFunction fn, string scope, HandlerConfig options)
        {
            this.CallNode("on", nodeId, eventName, new JRawValue(TokenUtils.ParseAndNormalize(fn.ToScript(), this)), new JRawValue(scope), new JRawValue(options.ToJsonString()));
        }

        /// <summary>
        /// Removes this node from its parent
        /// </summary>
        /// <param name="nodeId">Node id</param>
        [Description("Removes this node from its parent")]
        public void RemoveNode(string nodeId)
        {
            this.CallNode("remove", nodeId);
        }

        /// <summary>
        /// Removes all children nodes
        /// </summary>
        /// <param name="nodeId">Node id</param>
        [Description("Removes all children nodes")]
        public void RemoveChildren(string nodeId)
        {
            this.CallNode("removeChildren", nodeId);
        }

        /// <summary>
        /// Removes a child node from this node.
        /// </summary>
        /// <param name="nodeId">Node id</param>
        /// <param name="childNodeId">The node to remove</param>
        [Description("Removes a child node from this node.")]
        public void RemoveChildNode(string nodeId, string childNodeId)
        {
            this.CallNode("removeChild", nodeId, new JRawValue(this.ClientID.ConcatWith(".getNodeById(", JSON.Serialize(childNodeId), ")")));
        }

        /// <summary>
        /// Replaces one child node in this node with another.
        /// </summary>
        /// <param name="nodeId">Node id</param>
        /// <param name="oldChildNodeId">The node to replace</param>
        /// <param name="newNode">The replacement node</param>
        [Description("Replaces one child node in this node with another.")]
        public void ReplaceChildNode(string nodeId, string oldChildNodeId, TreeNodeBase newNode)
        {
            this.CallNode("replaceChild", nodeId, new JRawValue(this.ClientID.ConcatWith(".getNodeById(", JSON.Serialize(oldChildNodeId), ")")), new JRawValue(newNode.ToScript(false)));
        }

        /// <summary>
        /// Triggers selection of this node
        /// </summary>
        /// <param name="nodeId">Node id</param>
        [Description("Triggers selection of this node")]
        public void SelectNode(string nodeId)
        {
            this.CallNode("select", nodeId);
        }

        /// <summary>
        /// Changes the id of this node.
        /// </summary>
        /// <param name="nodeId">Node id</param>
        /// <param name="newId">The new id for the node.</param>
        [Description("Changes the id of this node.")]
        public void SetNodeId(string nodeId, string newId)
        {
            this.CallNode("setId", nodeId, newId);
        }

        /// <summary>
        /// Sets the text for this node
        /// </summary>
        /// <param name="nodeId">Node id</param>
        /// <param name="text">The new text for the node.</param>
        [Description("Sets the text for this node")]
        public void SetNodeText(string nodeId, string text)
        {
            this.CallNode("setText", nodeId, text);
        }

        /// <summary>
        /// Sets the icon class for this node.
        /// </summary>
        /// <param name="nodeId">Node id</param>
        /// <param name="iconCls">The new icon class for the node.</param>
        [Description("Sets the icon class for this node.")]
        public void SetNodeIconCls(string nodeId, string iconCls)
        {
            this.CallNode("setIconCls", nodeId, iconCls);
        }

        /// <summary>
        /// Sets the tooltip for this node.
        /// </summary>
        /// <param name="nodeId">Node id</param>
        /// <param name="tip">The text for the tip.</param>
        /// <param name="title">The title for the tip.</param>
        [Description("Sets the tooltip for this node.")]
        public void SetNodeTooltip(string nodeId, string tip, string title)
        {
            this.CallNode("setTooltip", nodeId, tip, title);
        }

        /// <summary>
        /// Sets the icon for this node.
        /// </summary>
        /// <param name="nodeId">Node id</param>
        /// <param name="icon">The new icon for the node.</param>
        [Description("Sets the icon for this node.")]
        public void SetNodeIcon(string nodeId, string icon)
        {
            this.CallNode("setIcon", nodeId, icon);
        }

        /// <summary>
        /// Sets the href for the node.
        /// </summary>
        /// <param name="nodeId">Node id</param>
        /// <param name="href">The href to set</param>
        /// <param name="target">The target of the href</param>
        [Description("Sets the href for the node.")]
        public void SetNodeHref(string nodeId, string href, string target)
        {
            this.CallNode("setHref", nodeId, href, target);
        }

        /// <summary>
        /// Sets the class on this node.
        /// </summary>
        /// <param name="nodeId">Node id</param>
        /// <param name="cls">The new class for the node.</param>
        [Description("Sets the class on this node.")]
        public void SetNodeCls(string nodeId, string cls)
        {
            this.CallNode("setCls", nodeId, cls);
        }

        /// <summary>
        /// Sorts this nodes children using the supplied sort function
        /// </summary>
        /// <param name="nodeId">Node id</param>
        /// <param name="fn">Sort function</param>
        /// <param name="scope">The scope of the sort function</param>
        [Description("Sorts this nodes children using the supplied sort function")]
        public void SortChildrenNodes(string nodeId, JFunction fn, string scope)
        {
            this.CallNode("sort", nodeId, fn, new JRawValue(scope));
        }

        /// <summary>
        /// Sorts this nodes children using the supplied sort function
        /// </summary>
        /// <param name="nodeId">Node id</param>
        /// <param name="fn">Sort function</param>
        [Description("Sorts this nodes children using the supplied sort function")]
        public void SortChildrenNodes(string nodeId, JFunction fn)
        {
            this.CallNode("sort", nodeId, fn);
        }

        /// <summary>
        /// Toggles expanded/collapsed state of the node
        /// </summary>
        /// <param name="nodeId">Node id</param>
        [Description("Toggles expanded/collapsed state of the node")]
        public void ToggleNode(string nodeId)
        {
            this.CallNode("toggle", nodeId);
        }

        /// <summary>
        /// Triggers deselection of this node
        /// </summary>
        /// <param name="nodeId">Node id</param>
        [Description("Triggers deselection of this node")]
        public void UnselectNode(string nodeId)
        {
            this.CallNode("unselect", nodeId);
        }

        /// <summary>
        /// Trigger a reload for this node
        /// </summary>
        /// <param name="nodeId">Node id</param>
        /// <param name="callback ">Callback  function</param>
        /// <param name="scope">The scope of the sort function</param>
        [Description("Trigger a reload for this node")]
        public void ReloadAsyncNode(string nodeId, JFunction callback, string scope)
        {
            this.CallNode("reload", nodeId, callback, new JRawValue(scope));
        }

        /// <summary>
        /// Trigger a reload for this node
        /// </summary>
        /// <param name="nodeId">Node id</param>
        /// <param name="callback">Callback function</param>
        [Description("Trigger a reload for this node")]
        public void ReloadAsyncNode(string nodeId, JFunction callback)
        {
            this.CallNode("reload", nodeId, callback);
        }

        /// <summary>
        /// Adds one or more CSS classes to the node's UI element. Duplicate classes are automatically filtered out.
        /// </summary>
        /// <param name="nodeId">Node id</param>
        /// <param name="className">The CSS class to add</param>
        [Description("Adds one or more CSS classes to the node's UI element. Duplicate classes are automatically filtered out.")]
        public void AddNodeClass(string nodeId, string className)
        {
            this.CallNodeUI("addClass", nodeId, className);
        }

        /// <summary>
        /// Hides this node.
        /// </summary>
        /// <param name="nodeId">Node id</param>
        [Description("Hides this node.")]
        public void HideNode(string nodeId)
        {
            this.CallNodeUI("hide", nodeId);
        }

        /// <summary>
        /// Removes one or more CSS classes from the node's UI element.
        /// </summary>
        /// <param name="nodeId">Node id</param>
        /// <param name="className">The CSS class to remove</param>
        [Description("Removes one or more CSS classes from the node's UI element.")]
        public void RemoveNodeClass(string nodeId, string className)
        {
            this.CallNodeUI("removeClass", nodeId, className);
        }

        /// <summary>
        /// Shows this node.
        /// </summary>
        /// <param name="nodeId">Node id</param>
        [Description("Shows this node.")]
        public void ShowNode(string nodeId)
        {
            this.CallNodeUI("show", nodeId);
        }

        /// <summary>
        /// Sets the checked status of the tree node to the passed value, or, if no value was passed, toggles the checked status. If the node was rendered with no checkbox, this has no effect.
        /// </summary>
        /// <param name="nodeId">Node id</param>
        /// <param name="value">The new checked status.</param>
        [Description("Sets the checked status of the tree node to the passed value, or, if no value was passed, toggles the checked status. If the node was rendered with no checkbox, this has no effect.")]
        public void ToggleCheck(string nodeId, bool value)
        {
            this.CallNodeUI("toggleCheck", nodeId, value);
        }

        /// <summary>
        /// Sets the checked status of the tree node to the passed value, or, if no value was passed, toggles the checked status. If the node was rendered with no checkbox, this has no effect.
        /// </summary>
        /// <param name="nodeId">Node id</param>
        [Description("Sets the checked status of the tree node to the passed value, or, if no value was passed, toggles the checked status. If the node was rendered with no checkbox, this has no effect.")]
        public void ToggleCheck(string nodeId)
        {
            this.CallNodeUI("toggleCheck", nodeId);
        }

        #endregion

        /// <summary>
        /// Collapse all nodes
        /// </summary>
        [Description("Collapse all nodes")]
        public void CollapseAll()
        {
            this.Call("collapseAll");
        }

        /// <summary>
        /// Expand all nodes
        /// </summary>
        [Description("Expand all nodes")]
        public void ExpandAll()
        {
            this.Call("expandAll");
        }

        /// <summary>
        /// Expands a specified path in this TreePanel. A path can be retrieved from a node with Ext.data.Node.getPath
        /// </summary>
        /// <param name="path">Path</param>
        /// <param name="attr">The attribute used in the path</param>
        /// <param name="callback">The callback to call when the expand is complete. The callback will be called with (bSuccess, oLastNode) where bSuccess is if the expand was successful and oLastNode is the last node that was expanded.</param>
        [Description("Expands a specified path in this TreePanel. A path can be retrieved from a node with Ext.data.Node.getPath")]
        public void ExpandPath(string path, string attr, JFunction callback)
        {
            this.Call("expandPath", path, attr, callback);
        }

        /// <summary>
        /// Expands a specified path in this TreePanel. A path can be retrieved from a node with Ext.data.Node.getPath
        /// </summary>
        /// <param name="path">Path</param>
        /// <param name="attr">The attribute used in the path</param>
        [Description("Expands a specified path in this TreePanel. A path can be retrieved from a node with Ext.data.Node.getPath")]
        public void ExpandPath(string path, string attr)
        {
            this.Call("expandPath", path, attr);
        }

        /// <summary>
        /// Expands a specified path in this TreePanel. A path can be retrieved from a node with Ext.data.Node.getPath
        /// </summary>
        /// <param name="path">Path</param>
        [Description("Expands a specified path in this TreePanel. A path can be retrieved from a node with Ext.data.Node.getPath")]
        public void ExpandPath(string path)
        {
            this.Call("expandPath", path);
        }

        /// <summary>
        /// Selects the node in this tree at the specified path. A path can be retrieved from a node with Ext.data.Node.getPath
        /// </summary>
        /// <param name="path">Path</param>
        /// <param name="attr">The attribute used in the path</param>
        /// <param name="callback">The callback to call when the selection is complete. The callback will be called with (bSuccess, oSelNode) where bSuccess is if the selection was successful and oSelNode is the selected node.</param>
        [Description("Selects the node in this tree at the specified path. A path can be retrieved from a node with Ext.data.Node.getPath")]
        public void SelectPath(string path, string attr, JFunction callback)
        {
            this.Call("selectPath", path, attr, callback);
        }

        /// <summary>
        /// Selects the node in this tree at the specified path. A path can be retrieved from a node with Ext.data.Node.getPath
        /// </summary>
        /// <param name="path">Path</param>
        /// <param name="attr">The attribute used in the path</param>
        [Description("Selects the node in this tree at the specified path. A path can be retrieved from a node with Ext.data.Node.getPath")]
        public void SelectPath(string path, string attr)
        {
            this.Call("selectPath", path, attr);
        }

        /// <summary>
        /// Selects the node in this tree at the specified path. A path can be retrieved from a node with Ext.data.Node.getPath
        /// </summary>
        /// <param name="path">Path</param>
        [Description("Selects the node in this tree at the specified path. A path can be retrieved from a node with Ext.data.Node.getPath")]
        public void SelectPath(string path)
        {
            this.Call("selectPath", path);
        }

        /// <summary>
        /// Sets the root node for this tree. If the TreePanel has already rendered a root node, the previous root node (and all of its descendants) are destroyed before the new root node is rendered.
        /// </summary>
        /// <param name="node">New root node</param>
        [Description("Sets the root node for this tree. If the TreePanel has already rendered a root node, the previous root node (and all of its descendants) are destroyed before the new root node is rendered.")]
        public void SetRootNode(TreeNodeBase node)
        {
            this.Call("setRootNode", new JRawValue(node.ToScript(false)));
        }

        /// <summary>
        /// Start editing of the node
        /// </summary>
        /// <param name="nodeId">Node Id</param>
        /// <param name="defer">Delay before start in ms</param>
        [Description("Start editing of the node")]
        public void StartEdit(string nodeId, int defer)
        {
            this.Call("startEdit", nodeId, defer);
        }

        /// <summary>
        /// Start editing of the node
        /// </summary>
        /// <param name="nodeId">Node Id</param>
        [Description("Start editing of the node")]
        public void StartEdit(string nodeId)
        {
            this.Call("startEdit", nodeId);
        }

        /// <summary>
        /// Complete editing of the node
        /// </summary>
        [Description("Complete editing of the node")]
        public void CompleteEdit()
        {
            this.Call("completeEdit");
        }

        /// <summary>
        /// Cancel editing of the node
        /// </summary>
        [Description("Cancel editing of the node")]
        public void CancelEdit()
        {
            this.Call("cancelEdit");
        }

        #region IIcon Members

        private void FillIcons(List<Icon> icons, TreeNodeBase node)
        {
            Icon icon = node.Icon;

            if (icon != Icon.None && !icons.Contains(icon))
            {
                icons.Add(icon);
            }

            if (node is TreeNode)
            {
                TreeNode treeNode = (TreeNode)node;
                foreach (TreeNodeBase nodeBase in treeNode.Nodes)
                {
                    this.FillIcons(icons, nodeBase);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override List<Icon> Icons
        {
            get
            {
                List<Icon> icons = base.Icons;

                if (this.Root.Count > 0)
                {
                    this.FillIcons(icons, this.Root.Primary);
                }

                return icons;
            }
        }

        #endregion
    }
}