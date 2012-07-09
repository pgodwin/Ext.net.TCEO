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
    /// 
    /// </summary>
    [Description("")]
    public abstract partial class TreeNodeBase : Node, IIcon
    {
        private TreeNodeBase parentNode;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public TreeNodeBase ParentNode
        {
            get 
            { 
                return this.parentNode; 
            }
            protected internal set 
            {
                this.parentNode = value; 
            }
        }

        /// <summary>
        /// False to not allow this node to have child nodes (defaults to true)
        /// </summary>
        [ConfigOption]
        [Category("3. TreeNode")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("False to not allow this node to have child nodes (defaults to true)")]
        public virtual bool AllowChildren
        {
            get
            {
                object obj = this.ViewState["AllowChildren"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["AllowChildren"] = value;
            }
        }

        /// <summary>
        /// False to make this node undraggable if draggable = true (defaults to true)
        /// </summary>
        [ConfigOption]
        [Category("3. TreeNode")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("False to make this node undraggable if draggable = true (defaults to true)")]
        public virtual bool AllowDrag
        {
            get
            {
                object obj = this.ViewState["AllowDrag"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["AllowDrag"] = value;
            }
        }

        /// <summary>
        /// False if this node cannot have child nodes dropped on it (defaults to true)
        /// </summary>
        [ConfigOption]
        [Category("3. TreeNode")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("False if this node cannot have child nodes dropped on it (defaults to true)")]
        public virtual bool AllowDrop
        {
            get
            {
                object obj = this.ViewState["AllowDrop"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["AllowDrop"] = value;
            }
        }

        /// <summary>
        /// True to render a checked checkbox for this node, false to render an unchecked checkbox (defaults to undefined with no checkbox rendered)
        /// </summary>
        [ConfigOption(typeof(ThreeStateBoolJsonConverter))]
        [Category("3. TreeNode")]
        [DefaultValue(ThreeStateBool.Undefined)]
        [NotifyParentProperty(true)]
        [Description("True to render a checked checkbox for this node, false to render an unchecked checkbox (defaults to undefined with no checkbox rendered)")]
        public virtual ThreeStateBool Checked
        {
            get
            {
                object obj = this.ViewState["Checked"];
                return (obj == null) ? ThreeStateBool.Undefined : (ThreeStateBool)obj;
            }
            set
            {
                this.ViewState["Checked"] = value;
            }
        }

        /// <summary>
        /// A css class to be added to the node.
        /// </summary>
        [ConfigOption]
        [Category("3. TreeNode")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A css class to be added to the node.")]
        public virtual string Cls
        {
            get
            {
                return (string)this.ViewState["Cls"] ?? "";
            }
            set
            {
                this.ViewState["Cls"] = value;
            }
        }

        /// <summary>
        /// True to start the node disabled
        /// </summary>
        [ConfigOption]
        [Category("3. TreeNode")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to start the node disabled")]
        public virtual bool Disabled
        {
            get
            {
                object obj = this.ViewState["Disabled"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Disabled"] = value;
            }
        }

        /// <summary>
        /// True to make this node draggable (defaults to false)
        /// </summary>
        [ConfigOption]
        [Category("3. TreeNode")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to make this node draggable (defaults to false)")]
        public virtual bool Draggable
        {
            get
            {
                object obj = this.ViewState["Draggable"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Draggable"] = value;
            }
        }

        /// <summary>
        /// False to not allow this node to be edited by an TreeEditor (defaults to true)
        /// </summary>
        [ConfigOption]
        [Category("3. TreeNode")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("False to not allow this node to be edited by an TreeEditor (defaults to true)")]
        public virtual bool Editable
        {
            get
            {
                object obj = this.ViewState["Editable"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["Editable"] = value;
            }
        }

        /// <summary>
        /// If set to true, the node will always show a plus/minus icon, even when empty
        /// </summary>
        [ConfigOption(typeof(ThreeStateBoolJsonConverter))]
        [Category("3. TreeNode")]
        [DefaultValue(ThreeStateBool.Undefined)]
        [NotifyParentProperty(true)]
        [Description("If set to true, the node will always show a plus/minus icon, even when empty")]
        public virtual ThreeStateBool Expandable
        {
            get
            {
                object obj = this.ViewState["Expandable"];
                return (obj == null) ? ThreeStateBool.Undefined : (ThreeStateBool)obj;
            }
            set
            {
                this.ViewState["Expandable"] = value;
            }
        }

        /// <summary>
        /// True to start the node expanded
        /// </summary>
        [ConfigOption]
        [Category("3. TreeNode")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to start the node expanded")]
        public virtual bool Expanded
        {
            get
            {
                object obj = this.ViewState["Expanded"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Expanded"] = value;
            }
        }

        /// <summary>
        /// True to render hidden. (Defaults to false).
        /// </summary>
        [ConfigOption]
        [Category("3. TreeNode")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to render hidden. (Defaults to false).")]
        public virtual bool Hidden
        {
            get
            {
                object obj = this.ViewState["Hidden"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Hidden"] = value;
            }
        }

        /// <summary>
        /// URL of the link used for the node (defaults to #)
        /// </summary>
        [ConfigOption]
        [Category("3. TreeNode")]
        [DefaultValue("#")]
        [NotifyParentProperty(true)]
        [Description("URL of the link used for the node (defaults to #)")]
        public virtual string Href
        {
            get
            {
                return (string)this.ViewState["Href"] ?? "#";
            }
            set
            {
                this.ViewState["Href"] = value;
            }
        }

        /// <summary>
        /// Target frame for the link
        /// </summary>
        [ConfigOption]
        [Category("3. TreeNode")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Target frame for the link")]
        public virtual string HrefTarget
        {
            get
            {
                return (string)this.ViewState["HrefTarget"] ?? "";
            }
            set
            {
                this.ViewState["HrefTarget"] = value;
            }
        }

        /// <summary>
        /// The path to an icon for the node. The preferred way to do this is to use the cls or iconCls attributes and add the icon via a CSS background image.
        /// </summary>
        [ConfigOption("icon")]
        [Category("3. TreeNode")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The path to an icon for the node. The preferred way to do this is to use the cls or iconCls attributes and add the icon via a CSS background image.")]
        public virtual string IconFile
        {
            get
            {
                return (string)this.ViewState["IconFile"] ?? "";
            }
            set
            {
                this.ViewState["IconFile"] = value;
            }
        }

        /// <summary>
        /// The icon to use for the Node. See also, IconCls to set an icon with a custom Css class.
        /// </summary>
        [Category("3. TreeNode")]
        [DefaultValue(Icon.None)]
        [NotifyParentProperty(true)]
        [Description("The icon to use for the Node. See also, IconCls to set an icon with a custom Css class.")]
        public virtual Icon Icon
        {
            get
            {
                object obj = this.ViewState["Icon"];
                return (obj == null) ? Icon.None : (Icon)obj;
            }
            set
            {
                this.ViewState["Icon"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("iconCls")]
        [DefaultValue("")]
        protected virtual string IconClsProxy
        {
            get
            {
                if (this.Icon != Icon.None)
                {
                    return ResourceManager.GetIconClassName(this.Icon);
                }

                return this.IconCls;
            }
        }

        /// <summary>
        /// A css class to be added to the nodes icon element for applying css background images
        /// </summary>
        [Category("3. TreeNode")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A css class to be added to the nodes icon element for applying css background images")]
        public virtual string IconCls
        {
            get
            {
                return (string)this.ViewState["IconCls"] ?? "";
            }
            set
            {
                this.ViewState["IconCls"] = value;
            }
        }

        /// <summary>
        /// False to not allow this node to act as a drop target (defaults to true)
        /// </summary>
        [ConfigOption]
        [Category("3. TreeNode")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("False to not allow this node to act as a drop target (defaults to true)")]
        public virtual bool IsTarget
        {
            get
            {
                object obj = this.ViewState["IsTarget"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["IsTarget"] = value;
            }
        }

        /// <summary>
        /// An Ext QuickTip for the node
        /// </summary>
        [ConfigOption]
        [Category("3. TreeNode")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("An Ext QuickTip for the node")]
        public virtual string Qtip
        {
            get
            {
                return (string)this.ViewState["Qtip"] ?? "";
            }
            set
            {
                this.ViewState["Qtip"] = value;
            }
        }

        private QTipCfg qtipConfig;

        /// <summary>
        /// An Ext QuickTip config for the node (used instead of qtip)
        /// </summary>
        [ConfigOption("qtipCfg", JsonMode.Object)]
        [Category("3. TreeNode")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("An Ext QuickTip config for the node (used instead of qtip)")]
        public virtual QTipCfg QtipConfig
        {
            get
            {
                if (this.qtipConfig == null)
                {
                    this.qtipConfig = new QTipCfg();
                }

                return this.qtipConfig;
            }
        }

        /// <summary>
        /// True for single click expand on this node
        /// </summary>
        [ConfigOption]
        [Category("3. TreeNode")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True for single click expand on this node")]
        public virtual bool SingleClickExpand
        {
            get
            {
                object obj = this.ViewState["SingleClickExpand"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["SingleClickExpand"] = value;
            }
        }

        /// <summary>
        /// The text for this node
        /// </summary>
        [ConfigOption]
        [Category("3. TreeNode")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The text for this node")]
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

        private ConfigItemCollection customAttributes;

        /// <summary>
        /// Collection of custom node attributes
        /// </summary>
        [ConfigOption("-", typeof(CustomConfigJsonConverter))]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Collection of custom node attributes")]
        public virtual ConfigItemCollection CustomAttributes
        {
            get
            {
                if (this.customAttributes == null)
                {
                    this.customAttributes = new ConfigItemCollection();
                    this.customAttributes.CamelName = false;
                }

                return this.customAttributes;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual bool EnforceNodeType
        {
            get
            {
                object obj = this.ViewState["EnforceNodeType"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["EnforceNodeType"] = value;
            }
        }

        /// <summary>
        /// A UI class to use for this node
        /// </summary>
        [ConfigOption("uiProvider", JsonMode.Value)]
        [Category("3. TreeNode")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A UI class to use for this node")]
        public virtual string UIProvider
        {
            get
            {
                return (string)this.ViewState["UIProvider"] ?? "";
            }
            set
            {
                this.ViewState["UIProvider"] = value;
            }
        }

        /// <summary>
        /// A UI class to use for this node
        /// </summary>
        [ConfigOption("uiProvider", JsonMode.Raw)]
        [Category("3. TreeNode")]
        [DefaultValue("Ext.tree.TreeNodeUI")]
        [NotifyParentProperty(true)]
        [Description("A UI class to use for this node")]
        public virtual string UIProviderClass
        {
            get
            {
                return (string)this.ViewState["UIProviderClass"] ?? "Ext.tree.TreeNodeUI";
            }
            set
            {
                this.ViewState["UIProviderClass"] = value;
            }
        }

        List<Icon> IIcon.Icons
        {
            get 
            {
                List<Icon> icons = new List<Icon>(1);
                icons.Add(this.Icon);
                return icons;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public string ToScript()
        {
            return this.ToScript(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configOnly"></param>
        /// <returns></returns>
        [Description("")]
        public string ToScript(bool configOnly)
        {
            if (configOnly)
            {
                return new ClientConfig().Serialize(this);
            }
            else
            {
                bool oldEnforceNodeType = this.EnforceNodeType;
                string script = string.Concat("new ", this.InstanceOf, "(", this.ToScript(true) , ")");
                this.EnforceNodeType = oldEnforceNodeType;

                return script;
            }
        }

        /*  Protected Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Sets the class on this node.
        /// </summary>
        /// <param name="cls">The css class</param>
        [Description("Sets the class on this node.")]
        protected virtual void  SetCls(string cls)
        {
        }

        /// <summary>
        /// Sets the icon class for this node.
        /// </summary>
        /// <param name="cls">The css class</param>
        [Description("Sets the icon class for this node.")]
        protected virtual void SetIconCls(string cls)
        {
        }

        /// <summary>
        /// Sets the tooltip for this node.
        /// </summary>
        /// <param name="tip">The text for the tip</param>
        [Description("Sets the tooltip for this node.")]
        protected virtual void SetToolTip(string tip)
        {

        }

        /// <summary>
        /// Sets the tooltip for this node.
        /// </summary>
        /// <param name="tip">The text for the tip</param>
        /// <param name="title">The title for the tip</param>
        [Description("Sets the tooltip for this node.")]
        protected virtual void SetToolTip(string tip, string title)
        {

        }

        /// <summary>
        /// Sets the icon for this node.
        /// </summary>
        /// <param name="icon">The Icon</param>
        [Description("Sets the icon for this node.")]
        protected virtual void SetIcon(Icon icon)
        {
        }

        /// <summary>
        /// Sets the href for the node.
        /// </summary>
        /// <param name="href">The href to set</param>
        [Description("Sets the href for the node.")]
        protected virtual void SetHref(string href)
        {

        }

        /// <summary>
        /// Sets the href for the node.
        /// </summary>
        /// <param name="href">The href to set</param>
        /// <param name="target">The target of the href</param>
        [Description("Sets the href for the node.")]
        protected virtual void SetHref(string href, string target)
        {

        }
    }
}