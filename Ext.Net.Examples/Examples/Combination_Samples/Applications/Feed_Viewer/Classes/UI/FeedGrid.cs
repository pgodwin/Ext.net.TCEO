/********
 * @version   : 1.0.0 - Professional Edition (Ext.NET Professional License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2009-11-15
 * @copyright : Copyright (c) 2010, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace Ext.Net.Examples.FeedViewer
{
    public partial class FeedGrid : GridPanel
    {
        public const string SCOPE = "FeedViewer.FeedGrid";
        
        private Store store;
        private Menu menu;

        public FeedGrid()
        {
            this.Region = Ext.Net.Region.Center;
            this.ID = "TopicGrid";
            this.LoadMask.ShowMask = true;
            this.LoadMask.Msg = "Loading Feed...";
            this.Listeners.Render.Handler = "this.grid = item;";
            this.Listeners.Render.Scope = FeedGrid.SCOPE;

            this.SelectionModel.Add(new RowSelectionModel { SingleSelect = true });

            this.View.Add(new GridView
            {
                ForceFit = true,
                EnableRowBody = true,
                GetRowClass = { Fn = FeedGrid.SCOPE + ".applyRowClass" },
                CustomConfig =
                {
                    new ConfigItem("showPreview", "true", ParameterMode.Raw)
                }
            });

            this.BuildStore();

            this.ColumnModel.Columns.Add(new Column
            {
                 ColumnID = "title", 
                 Header = "Title",
                 DataIndex = "title",
                 Sortable = true,
                 Width = 420,
                 Renderer = { Fn = "FeedViewer.FeedGrid.formatTitle" }
            });

            this.ColumnModel.Columns.Add(new Column
            {
                Header = "Author",
                DataIndex = "author",
                Sortable = true,
                Width = 100,
                Hidden = true
            });

            this.ColumnModel.Columns.Add(new DateColumn
            {
                ColumnID = "last",
                Header = "Date",
                DataIndex = "pubDate",
                Sortable = true,
                Width = 150,
                Format = "dd MMM yyyy - HH:mm"
            });

            this.BuildContextMenu();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(null)]
        public Menu ContextMenu
        {
            get
            {
                return this.menu;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [XmlIgnore]
        [JsonIgnore]
        public override ConfigOptionsCollection ConfigOptions
        {
            get
            {
                ConfigOptionsCollection list = base.ConfigOptions;
                list.Add("contextMenu", new ConfigOption("contextMenu", new SerializationOptions("menu", typeof(LazyControlJsonConverter)), null, this.ContextMenu));

                return list;
            }
        }

        private void BuildStore()
        {
            var store = new Store
            {
                ID = "TopicStore",
                AutoLoad = false,
                Proxy = 
                {
                    new HttpProxy
                    {
                        Url = "FeedProxy.ashx"
                    }
                },

                Reader =
                {
                    new XmlReader
                    {
                        Record = "item",
                        Fields =
                        {
                            new RecordField("title"),
                            new RecordField("author"),
                            new RecordField("pubDate", RecordFieldType.Date, "ddd, dd MMM yyyy HH:mm:ss O"),
                            new RecordField("link"),
                            new RecordField("description"),
                            new RecordField("content")
                        }
                    }
                },

                SortInfo =
                {
                    Field = "pubDate",
                    Direction = SortDirection.DESC
                }
            };

            this.Store.Add(store);
        }

        private void BuildContextMenu()
        {
            this.menu = new Menu
            {
                ID = "GridCtx",
                Items =
                {
                    new MenuItem
                    {
                        IconCls = "new-tab",
                        Text = "View in new tab",
                        Scope = FeedGrid.SCOPE,
                        Handler = new JFunction( MainPanel.SCOPE + ".openTab(this.grid.ctxRecord);").ToScript()
                    },
                    new MenuItem
                    {
                        IconCls = "new-win",
                        Text = "Go to Post",
                        Scope = FeedGrid.SCOPE,
                        Handler = new JFunction("window.open(this.grid.ctxRecord.data.link);").ToScript()
                    },
                    new MenuSeparator(),
                    new MenuItem
                    {
                        Icon = Icon.TableRefresh,
                        Text = "Refresh",
                        Scope = FeedGrid.SCOPE,
                        Handler = new JFunction("this.grid.ctxRow = null;this.grid.store.reload();").ToScript()
                    }
                }
            };

            this.menu.Listeners.Hide.Fn = FeedGrid.SCOPE + ".onContextHide";
            this.menu.Listeners.Hide.Scope = FeedGrid.SCOPE;

            this.Listeners.RowContextMenu.Fn = FeedGrid.SCOPE + ".onContextClick";
            this.Listeners.RowContextMenu.Scope = FeedGrid.SCOPE;

            this.Controls.Add(this.menu);
            this.LazyItems.Add(this.menu);
        }
    }
}
