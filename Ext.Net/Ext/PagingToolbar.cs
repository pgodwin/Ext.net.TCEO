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

using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// A specialized toolbar that is bound to a Ext.data.Store and provides automatic paging controls.
    /// </summary>
    [Meta]
    [ToolboxBitmap(typeof(PagingToolbar), "Build.ToolboxIcons.PagingToolbar.bmp")]
    [ToolboxData("<{0}:PagingToolbar runat=\"server\"></{0}:PagingToolbar>")]
    [Description("A specialized toolbar that is bound to a Ext.data.Store and provides automatic paging controls.")]
    public partial class PagingToolbar : ToolbarBase, IXPostBackDataHandler
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public PagingToolbar() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                Store store = null;
                if (this.StoreID.IsNotEmpty())
                {
                    store = ControlUtils.FindControl(this, this.StoreID) as Store;
                }
                else
                {
                    IStore istore = this.OwnerCt as IStore;
                    if (istore != null)
                    {
                        store = istore.GetStore();
                    }
                }

                if (store != null && store.Proxy.Count == 0)
                {
                    return "ux.paging";
                }

                return "paging";
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
                if (this.StoreID.IsNotEmpty())
                {
                    Store store = ControlUtils.FindControl(this, this.StoreID) as Store;
                    if (store != null && store.Proxy.Count == 0)
                    {
                        return "Ext.ux.PagingToolbar";
                    }
                }
                else
                {
                    IStore istore = this.OwnerCt as IStore;
                    if (istore != null)
                    {
                        Store store = istore.GetStore();
                        if (store != null && store.Proxy.Count == 0)
                        {
                            return "Ext.ux.PagingToolbar";
                        }
                    }
                }

                return "Ext.PagingToolbar";
            }
        }

        /// <summary>
        /// The index of current page.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. PagingToolbar")]
        [DefaultValue(1)]
        [NotifyParentProperty(true)]
        [DirectEventUpdate(MethodName = "SetPageIndex")]
        [Description("The index of current page.")]
        public virtual int PageIndex
        {
            get
            {
                object obj = this.ViewState["PageIndex"];
                return (obj == null) ? 1 : (int)obj;
            }
            set
            {
                this.ViewState["PageIndex"] = value;
            }
        }

        /// <summary>
        /// True to display the displayMsg (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. PagingToolbar")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to display the displayMsg (defaults to false).")]
        public virtual bool DisplayInfo
        {
            get
            {
                object obj = this.ViewState["DisplayInfo"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["DisplayInfo"] = value;
            }
        }

        /// <summary>
        /// The paging status message to display (defaults to 'Displaying {0} - {1} of {2}'). Note that this string is formatted using the braced numbers 0-2 as tokens that are replaced by the values for start, end and total respectively. These tokens should be preserved when overriding this string if showing those values is desired.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. PagingToolbar")]
        [DefaultValue("Displaying {0} - {1} of {2}")]
        [NotifyParentProperty(true)]
        [Localizable(true)]
        [Description("The paging status message to display (defaults to 'Displaying {0} - {1} of {2}'). Note that this string is formatted using the braced numbers 0-2 as tokens that are replaced by the values for start, end and total respectively. These tokens should be preserved when overriding this string if showing those values is desired.")]
        public virtual string DisplayMsg
        {
            get
            {
                return (string)this.ViewState["DisplayMsg"] ?? "Displaying {0} - {1} of {2}";
            }
            set
            {
                this.ViewState["DisplayMsg"] = value;
            }
        }

        /// <summary>
        /// The message to display when no records are found (defaults to 'No data to display').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. PagingToolbar")]
        [DefaultValue("No data to display")]
        [NotifyParentProperty(true)]
        [Localizable(true)]
        [Description("The message to display when no records are found (defaults to 'No data to display').")]
        public virtual string EmptyMsg
        {
            get
            {
                return (string)this.ViewState["EmptyMsg"] ?? "No data to display";
            }
            set
            {
                this.ViewState["EmptyMsg"] = value;
            }
        }

        /// <summary>
        /// The number of records to display per page (defaults to 20).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. PagingToolbar")]
        [DefaultValue(20)]
        [NotifyParentProperty(true)]
        [DirectEventUpdate(MethodName = "SetPageSize")]
        [Description("The number of records to display per page (defaults to 20).")]
        public virtual int PageSize
        {
            get
            {
                object obj = this.ViewState["PageSize"];
                return (obj == null) ? 20 : (int)obj;
            }
            set
            {
                this.ViewState["PageSize"] = value;
            }
        }

        /// <summary>
        /// The data store to use.
        /// </summary>
        [Meta]
        [ConfigOption("store", JsonMode.ToClientID)]
        [Category("7. PagingToolbar")]
        [DefaultValue("")]
        [IDReferenceProperty(typeof(Store))]
        [NotifyParentProperty(true)]
        [Description("The data store to use.")]
        public virtual string StoreID
        {
            get
            {
                return (string)ViewState["StoreID"] ?? "";
            }
            set
            {
                this.ViewState["StoreID"] = value;
            }
        }

        /// <summary>
        /// Customizable piece of the default paging text (defaults to 'of {0}'). Note that this string is formatted using {0} as a token that is replaced by the number of total pages. This token should be preserved when overriding this string if showing the total page count is desired.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. PagingToolbar")]
        [DefaultValue("of {0}")]
        [NotifyParentProperty(true)]
        [Localizable(true)]
        [Description("Customizable piece of the default paging text (defaults to 'of {0}'). Note that this string is formatted using {0} as a token that is replaced by the number of total pages. This token should be preserved when overriding this string if showing the total page count is desired.")]
        public virtual string AfterPageText
        {
            get
            {
                return (string)ViewState["AfterPageText"] ?? "of {0}";
            }
            set
            {
                this.ViewState["AfterPageText"] = value;
            }
        }

        /// <summary>
        /// Customizable piece of the default paging text (defaults to 'Page')
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. PagingToolbar")]
        [DefaultValue("Page")]
        [NotifyParentProperty(true)]
        [Localizable(true)]
        [Description("Customizable piece of the default paging text (defaults to 'Page')")]
        public virtual string BeforePageText
        {
            get
            {
                return (string)this.ViewState["BeforePageText"] ?? "Page";
            }
            set
            {
                this.ViewState["BeforePageText"] = value;
            }
        }

        /// <summary>
        /// Customizable piece of the default paging text (defaults to 'First Page')
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. PagingToolbar")]
        [DefaultValue("First Page")]
        [NotifyParentProperty(true)]
        [Localizable(true)]
        [Description("Customizable piece of the default paging text (defaults to 'First Page')")]
        public virtual string FirstText
        {
            get
            {
                return (string)this.ViewState["FirstText"] ?? "First Page";
            }
            set
            {
                this.ViewState["FirstText"] = value;
            }
        }

        /// <summary>
        /// Customizable piece of the default paging text (defaults to 'Last Page')
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. PagingToolbar")]
        [DefaultValue("Last Page")]
        [NotifyParentProperty(true)]
        [Localizable(true)]
        [Description("Customizable piece of the default paging text (defaults to 'Last Page')")]
        public virtual string LastText
        {
            get
            {
                return (string)this.ViewState["LastText"] ?? "Last Page";
            }
            set
            {
                this.ViewState["LastText"] = value;
            }
        }

        /// <summary>
        /// Customizable piece of the default paging text (defaults to 'Next Page')
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. PagingToolbar")]
        [DefaultValue("Next Page")]
        [NotifyParentProperty(true)]
        [Localizable(true)]
        [Description("Customizable piece of the default paging text (defaults to 'Next Page')")]
        public virtual string NextText
        {
            get
            {
                return (string)this.ViewState["NextText"] ?? "Next Page";
            }
            set
            {
                this.ViewState["NextText"] = value;
            }
        }

        /// <summary>
        /// Customizable piece of the default paging text (defaults to 'Previous Page')
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. PagingToolbar")]
        [DefaultValue("Previous Page")]
        [NotifyParentProperty(true)]
        [Localizable(true)]
        [Description("Customizable piece of the default paging text (defaults to 'Previous Page')")]
        public virtual string PrevText
        {
            get
            {
                return (string)this.ViewState["PrevText"] ?? "Previous Page";
            }
            set
            {
                this.ViewState["PrevText"] = value;
            }
        }

        /// <summary>
        /// Customizable piece of the default paging text (defaults to 'Refresh')
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. PagingToolbar")]
        [DefaultValue("Refresh")]
        [NotifyParentProperty(true)]
        [Localizable(true)]
        [Description("Customizable piece of the default paging text (defaults to 'Refresh')")]
        public virtual string RefreshText
        {
            get
            {
                return (string)this.ViewState["RefreshText"] ?? "Refresh";
            }
            set
            {
                this.ViewState["RefreshText"] = value;
            }
        }

        /// <summary>
        /// Hide refresh button
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. PagingToolbar")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [DirectEventUpdate(MethodName = "SetHideRefresh")]
        [Description("Hide refresh button")]
        public virtual bool HideRefresh
        {
            get
            {
                object obj = this.ViewState["HideRefresh"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                this.ViewState["HideRefresh"] = value;
            }
        }

        private ParameterCollection paramNames;

        /// <summary>
        /// Object mapping of parameter names for load calls (defaults to {start: 'start', limit: 'limit'})
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ArrayToObject)]
        [Category("7. PagingToolbar")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Object mapping of parameter names for load calls (defaults to {start: 'start', limit: 'limit'})")]
        public virtual ParameterCollection ParamNames
        {
            get
            {
                if (this.paramNames == null)
                {
                    this.paramNames = new ParameterCollection();
                }

                return this.paramNames;
            }
        }

        private PagingToolbarListeners listeners;

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
        public PagingToolbarListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new PagingToolbarListeners();
                }

                return this.listeners;
            }
        }


        private PagingToolbarDirectEvents directEvents;

        /// <summary>
        /// Server-side DirectEvent Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]
        [ViewStateMember]
        [Description("Server-side DirectEventHandlers")]
        public PagingToolbarDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new PagingToolbarDirectEvents();
                }

                return this.directEvents;
            }
        }

        private bool hasLoadPostData = false;

        /// <summary>
        /// 
        /// </summary>
        protected virtual bool HasLoadPostData
        {
            get
            {
                return this.hasLoadPostData;
            }
            set
            {
                this.hasLoadPostData = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        bool IXPostBackDataHandler.HasLoadPostData
        {
            get
            {
                return this.HasLoadPostData;
            }
            set
            {
                this.HasLoadPostData = value;
            }
        }

        bool IPostBackDataHandler.LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            this.HasLoadPostData = true;

            string val = postCollection[this.ConfigID.ConcatWith("_ActivePage")];

            if (val.IsNotEmpty())
            {
                int activePageNum;

                if (int.TryParse(val, out activePageNum))
                {
                    if (activePageNum > -1 && this.PageIndex != activePageNum)
                    {
                        try
                        {
                            this.SuspendScripting();
                            this.PageIndex = activePageNum;
                        }
                        finally
                        {
                            this.ResumeScripting();
                        }

                        return true;
                    }
                }
            }

            return false;
        }

        void IPostBackDataHandler.RaisePostDataChangedEvent() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        [Meta]
        [Description("")]
        public virtual void SetPageIndex(int index)
        {
            this.Call("changePage", index);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        [Meta]
        [Description("")]
        public virtual void SetPageSize(int size)
        {
            this.Set("pageSize", size);
            this.Call("doLoad");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hide"></param>
        [Description("")]
        protected virtual void SetHideRefresh(bool hide)
        {
            if (hide)
            {
                this.Call("refresh.hide");
            }
            else
            {
                this.Call("refresh.show");
            }
        }
    }
}
