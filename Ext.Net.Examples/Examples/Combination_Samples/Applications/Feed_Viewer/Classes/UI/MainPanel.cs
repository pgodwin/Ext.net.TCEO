/********
 * @version   : 1.0.0 - Professional Edition (Ext.NET Professional License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2009-11-15
 * @copyright : Copyright (c) 2010, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.ComponentModel;
using System.Web.UI;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace Ext.Net.Examples.FeedViewer
{
    public partial class MainPanel : TabPanel
    {
        public const string SCOPE = "FeedViewer.MainPanel";

        private Panel preview;
        private FeedGrid grid;
        private string margins = "0 5 5 0";

        public MainPanel()
        {
            this.ID = "MainTabs";
            this.ActiveTabIndex = 0;
            this.Region = Ext.Net.Region.Center;
            this.ResizeTabs = true;
            this.TabWidth = 150;
            this.MinTabWidth = 120;
            this.EnableTabScroll = true;
            this.Plugins.Add(new TabCloseMenu());

            this.BuildPreviewPanel();
            this.BuildGrid();
            this.BuildTemplate();

            this.Listeners.AfterLayout.Fn = MainPanel.SCOPE + ".afterLayout";
            this.Listeners.AfterLayout.Scope = MainPanel.SCOPE;
            this.Listeners.AfterLayout.Single = true;

            this.Items.Add(new Panel
               {
                   ID = "MainView",
                   Layout = "Border",
                   Title = "Loading...",
                   HideMode = HideMode.Offsets,
                   Items =
                   {
                       this.Grid,
                       new Panel
                       {
                           ID = "BottomPreview",
                           Layout = "Fit",
                           Items = { this.Preview },
                           Height = 250,
                           Split = true,
                           Border = false,
                           Region = Ext.Net.Region.South
                       },
                       new Panel
                       {
                           ID = "RightPreview",
                           Layout = "Fit",
                           Border = false,
                           Region = Ext.Net.Region.East,
                           Width = 350,
                           Split = true,
                           Hidden = true
                       }
                   }
               });

        }

        protected override void OnLoad(EventArgs e)
        {
            if (!Net.X.IsAjaxRequest)
            {
                this.ResourceManager.AddDirectMethodControl(this);
            }
        }

        [DefaultValue("0 5 5 0")]
        public override string Margins
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public FeedGrid Grid
        {
            get
            {
                return this.grid;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Panel Preview
        {
            get
            {
                return this.preview;
            }
        }

        private XTemplate template;

        [DefaultValue(null)]
        public virtual XTemplate Template
        {
            get
            {
                return this.template;
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
                list.Add("template", new ConfigOption("template", new SerializationOptions("tpl", typeof(LazyControlJsonConverter)), null, this.Template));

                return list;
            }
        }

        private void BuildPreviewPanel()
        {
            this.preview = new Panel
            {
                ID = "Preview",
                Region = Ext.Net.Region.South,
                Cls = "preview",
                AutoScroll = true,
                Border = false,
                Listeners =
                {
                    Render = { Fn = "FeedViewer.LinkInterceptor" }
                },
                TopBar =
                {
                   new Toolbar
                   {
                       Items =
                       {
                           new Button
                           {
                               ID = "btnNewTab",
                               Text = "View in New Tab",
                               IconCls = "new-tab",
                               Disabled = true,
                               Scope = MainPanel.SCOPE,
                               Handler = MainPanel.SCOPE + ".openTab"
                           },
                           new ToolbarSeparator(),
                           new Button
                           {
                               ID = "btnNewWin",
                               Text = "Go To Post",
                               IconCls = "new-win",
                               Disabled = true,
                               Scope = MainPanel.SCOPE,
                               Handler = new JFunction("window.open(this.grid.getSelectionModel().getSelected().data.link);").ToScript()
                           }
                       }
                   }
                }
            };
        }

        private void BuildTemplate()
        {
            this.template = new XTemplate();

            this.template.Html = @"
            <div id=""preview-tpl"">
                <div class=""post-data"">
                    <span class=""post-date"">{pubDate:date(""M j, Y, g:i a"")}</span>
                    <h3 class=""post-title"">{title}</h3>
                    <h4 class=""post-author"">by {author:defaultValue(""Unknown"")}</h4>
                </div>
                <div class=""post-body"">{content:this.getBody}</div>
            </div>";

            this.template.Functions.Add(new JFunction
              {
                  Name = "getBody",
                  Handler = "return Ext.util.Format.stripScripts(v || all.description);",
                  Args = new string[]{"v", "all"}
              });

            this.Controls.Add(this.template);
            this.LazyItems.Add(this.template);
        }

        private void BuildGrid()
        {
            this.grid = new FeedGrid
            {
                Region = Ext.Net.Region.Center,
                Border = false,
                TopBar =
                {
                    new Toolbar
                    {
                        Items =
                        {
                            new Button
                            {
                                Text = "Open All",
                                QTipCfg =
                                {
                                    Title = "Open All", 
                                    Text = "Opens all item in tabs"
                                },
                                IconCls = "tabs",
                                Scope = MainPanel.SCOPE,
                                Handler = MainPanel.SCOPE + ".openAll"
                            },
                            new ToolbarSeparator(),
                            new SplitButton
                            {
                                ID = "PreviewPlaceButton",
                                Text = "Reading Pane",
                                QTipCfg =
                                    {
                                        Title = "Reading Pane",
                                        Text = "Show, move or hide the Reading Pane"
                                    },
                                IconCls = "preview-bottom",
                                Scope = MainPanel.SCOPE,
                                Handler = MainPanel.SCOPE + ".cyclePreview",
                                Menu =
                                {
                                    new Menu
                                    {
                                        ID = "ReadingMenu",
                                        Cls = "reading-menu",
                                        Width = 100,
                                        Items =
                                        {
                                            new CheckMenuItem
                                            {
                                                Text = "Bottom",
                                                Checked = true,
                                                Group = "rp-group",
                                                IconCls = "preview-bottom",
                                                Scope = MainPanel.SCOPE,
                                                CheckHandler = MainPanel.SCOPE + ".movePreview"
                                            },
                                            new CheckMenuItem
                                            {
                                                Text = "Right",
                                                Checked = false,
                                                Group = "rp-group",
                                                IconCls = "preview-right",
                                                Scope = MainPanel.SCOPE,
                                                CheckHandler = MainPanel.SCOPE + ".movePreview"
                                            },
                                            new CheckMenuItem
                                            {
                                                Text = "Hide",
                                                Checked = false,
                                                Group = "rp-group",
                                                IconCls = "preview-hide",
                                                Scope = MainPanel.SCOPE,
                                                CheckHandler = MainPanel.SCOPE + ".movePreview"
                                            }
                                        }
                                    }
                                }
                            },
                            new ToolbarSeparator(),
                            new Button
                            {
                                Pressed = true,
                                EnableToggle = true,
                                Text = "Summary",
                                QTipCfg =
                                {
                                    Title = "Post Summary",
                                    Text = "View a short summary of each item in the list"
                                },
                                IconCls = "summary"
                            }
                        }
                    }
                }
            };

            ComponentDirectEvent toggle = ((Button)this.grid.TopBar[0].Items[4]).DirectEvents.Toggle;
            toggle.Event += ShowPreview_Toggle;
            toggle.ExtraParams.Add(new Parameter("pressed", "pressed", ParameterMode.Raw));

            var sm = this.grid.SelectionModel[0] as RowSelectionModel;
            sm.Listeners.RowSelect.Scope = MainPanel.SCOPE;
            sm.Listeners.RowSelect.Fn = MainPanel.SCOPE + ".onRowSelect";
            sm.Listeners.RowSelect.Buffer = 250;

            this.grid.Store.Primary.Listeners.BeforeLoad.Fn = MainPanel.SCOPE + ".clear";
            this.grid.Store.Primary.Listeners.BeforeLoad.Scope = MainPanel.SCOPE;

            this.grid.Store.Primary.Listeners.Load.Fn = MainPanel.SCOPE + ".onStoreLoad";
            this.grid.Store.Primary.Listeners.Load.Scope = MainPanel.SCOPE;

            this.grid.Listeners.RowDblClick.Fn = MainPanel.SCOPE + ".openTab";
            this.grid.Listeners.RowDblClick.Scope = MainPanel.SCOPE;
        }
    }
}
