/********
 * @version   : 1.0.0 - Professional Edition (Ext.NET Professional License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2009-11-15
 * @copyright : Copyright (c) 2010, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.ComponentModel;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace Ext.Net.Examples.FeedViewer
{
    public partial class FeedTree : TreePanel
    {
        public const string SCOPE = "FeedViewer.FeedTree";
        
        private Menu menu;
        private int minSize = 175;
        private int maxSize = 400;
        private string margins = "0 0 5 5";
        private string cmargins = "0 5 5 5";
        
        public FeedTree()
        {
            this.Title = "Feeds";
            this.Width = 225;
            this.Collapsible = true;
            this.RootVisible = false;
            this.Lines = false;
            this.AutoScroll = true;
            this.CollapseFirst = false;
            this.Region = Ext.Net.Region.West;
            this.Split = true;
            
            this.Root.Add(new TreeNode
              {
                  Text = "My Feeds",
                  Nodes =
                  {
                      new TreeNode
                      {
                          NodeID = "MyFeeds",
                          Text = "My Feeds",
                          Cls = "feeds-node",
                          Expanded = true
                      }
                  }
              });

            this.TopBar.Add(new Toolbar
            {
                Items =
                {
                    new Button
                    {
                        Icon = Icon.FeedAdd,
                        Text = "Add Feed"
                    },
                    new Button
                    {
                        ID = "Delete",
                        Icon = Icon.FeedDelete,
                        Text = "Remove"
                    }
                }
            });

            ((Button)this.TopBar[0].Items[1]).DirectEvents.Click.Event += this.DeleteFeedClick;
            ((Button)this.TopBar[0].Items[0]).DirectEvents.Click.Event += this.AddFeedClick;

            this.SelectionModel.Add(new DefaultSelectionModel
            {
                Listeners =
                {
                    BeforeSelect = { Handler = "return newNode.isLeaf();" },
                    SelectionChange = { 
                         Fn = FeedTree.SCOPE + ".selectionChange",
                         Scope = FeedTree.SCOPE
                    }
                }
            });

            this.Listeners.AfterRender.Handler = "this.tree = item;";
            this.Listeners.AfterRender.Scope = FeedTree.SCOPE;

            this.BuildContextMenu();
        }

        protected override void OnLoad(EventArgs e)
        {
            if (!Net.X.IsAjaxRequest)
            {
                this.ResourceManager.AddDirectMethodControl(this);
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (!Ext.Net.X.IsAjaxRequest)
            {
                this.AddEvents("feedselect");

                this.On("feedselect", new JFunction(MainPanel.SCOPE + ".loadFeed(feed);", new string[]{"feed"}));

                this.AddFeed("http://feeds.feedburner.com/extblog", "ExtJS.com Blog", false, true);
                this.AddFeed("http://extjs.com/forum/external.php?type=RSS2", "ExtJS.com Forums", true, false);
                this.AddFeed("http://feeds.feedburner.com/ajaxian", "Ajaxian", true, false);
                this.Focus();
            }

            base.OnPreRender(e);    
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

        [DefaultValue(175)]
        public int MinSize
        {
            get
            {
                return this.minSize;
            }
            set
            {
                this.minSize = value;
            }
        }

        [DefaultValue(400)]
        public int MaxSize
        {
            get
            {
                return this.maxSize;
            }
            set
            {
                this.maxSize = value;
            }
        }

        [DefaultValue("0 0 5 5")]
        public string Margins
        {
            get
            {
                return this.margins;
            }
            set
            {
                this.margins = value;
            }
        }

        [DefaultValue("0 5 5 5")]
        public string Cmargins
        {
            get
            {
                return this.cmargins;
            }
            set
            {
                this.cmargins = value;
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
                list.Add("minSize", new ConfigOption("minSize", null, 50, this.MinSize));
                list.Add("maxSize", new ConfigOption("maxSize", null, int.MaxValue, this.MaxSize));
                list.Add("margins", new ConfigOption("margins", null, "", this.Margins));
                list.Add("cmargins", new ConfigOption("cmargins", null, "", this.Cmargins));

                return list;
            }
        }

        private void BuildContextMenu()
        {
            this.menu = new Menu
                {
                ID = "FeedsCtx",
                Items =
                {
                    new MenuItem
                    {
                        ID = "Load",
                        Icon = Icon.FeedGo,
                        Text = "Load Feed",
                        Scope = FeedTree.SCOPE,
                        Handler = new JFunction("this.tree.ctxNode.select();").ToScript()
                    },
                    new MenuItem
                    {
                        Icon = Icon.FeedDelete,
                        Text = "Remove",
                        DirectEvents =
                        {
                            Click =
                            {
                                ExtraParams =
                                {
                                    new Parameter("nodeId", FeedTree.SCOPE + ".tree.ctxNode.id", ParameterMode.Raw)
                                }
                            }
                       }
                    },
                    new MenuSeparator(),
                    new MenuItem
                    {
                        Icon = Icon.FeedAdd,
                        Text = "Add Feed",
                        Scope = FeedTree.SCOPE,
                        Handler = FeedTree.SCOPE + ".showWindow"
                    }
                }
            };

            ((MenuItem)this.menu.Items[1]).DirectEvents.Click.Event += OnRemoveFeedClick;
            ((MenuItem)this.menu.Items[3]).DirectEvents.Click.Event += AddFeedClick;

            this.menu.Listeners.Hide.Fn = FeedTree.SCOPE + ".onContextHide";
            this.menu.Listeners.Hide.Scope = FeedTree.SCOPE;

            this.Listeners.ContextMenu.Fn = FeedTree.SCOPE + ".onContextMenu";
            this.Listeners.ContextMenu.Scope = FeedTree.SCOPE;

            this.Controls.Add(this.menu);
            this.LazyItems.Add(this.menu);
        }
    }
}
