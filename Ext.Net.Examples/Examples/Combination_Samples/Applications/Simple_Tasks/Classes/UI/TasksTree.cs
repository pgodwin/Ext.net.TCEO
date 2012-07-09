using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace Ext.Net.Examples.SimpleTasks
{
    public partial class TasksTree : TreePanel
    {
        private Toolbar bBar;
        private Menu ctxCategory;
        private Menu ctxFolder;

        public TasksTree()
        {
            this.Title = "My Lists";
            this.Collapsible = true;
            this.Width = 200;
            this.AutoScroll = true;
            this.UseArrows = true;
            this.Mode = TreePanelMode.Remote;
            this.Cls = "tasks-tree";
            this.EnableDD = true;
            this.AllowLeafDrop = true;
            this.DDAppendOnly = true;
            this.DirectEventConfig.Type = DirectEventType.Load;
            this.DDGroup = "tasktree";

            this.Editors.Add(new TreeEditor
             {
                 CancelOnBlur = true,
                 Shadow = ShadowMode.None,
                 Field =
                 {
                     new TextField
                     {
                         AllowBlank = false,
                         BlankText = "A name is required",
                         SelectOnFocus = true
                     }
                 }
             });

            this.Loader.Add(new PageTreeLoader
            {
                PreloadChildren = true,
                RequestMethod = HttpMethod.GET,
                Type=DirectEventType.Load
            });

            this.Root.Add(new AsyncTreeNode
              {
                  Text = "All Lists",
                  NodeID = "1",
                  Leaf = false,
                  IconCls = "icon-folder",
                  Expanded = true,
                  Editable = false,
                  CustomAttributes =
                  {
                      new ConfigItem("isFolder", "true", ParameterMode.Raw)
                  }
              });

            this.Sorter.FolderSort = true;

            this.SelectionModel.Add(new DefaultSelectionModel());

            this.BuildBottomBar();
            this.BuildCategoryMenu();
            this.BuildFolderMenu();

            this.InitLogic();
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
                ConfigOptionsCollection category = base.ConfigOptions;
                category.Add("categoryContextMenu", new ConfigOption("categoryContextMenu", new SerializationOptions("ctxCategory", typeof(LazyControlJsonConverter)), null, this.CategoryContextMenu));
                category.Add("folderContextMenu", new ConfigOption("folderContextMenu", new SerializationOptions("ctxFolder", typeof(LazyControlJsonConverter)), null, this.FolderContextMenu));

                return category;
            }
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(null)]
        public Menu CategoryContextMenu
        {
            get
            {
                return this.ctxCategory;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(null)]
        public Menu FolderContextMenu
        {
            get
            {
                return this.ctxFolder;
            }
        }

        private void BuildBottomBar()
        {
            this.bBar = new Toolbar
            {
                Items =
                {
                    new Button
                    {
                        ToolTip = "New Category",
                        IconCls = "icon-category-new",
                        Disabled = true
                    },
                    new Button
                    {
                        ToolTip = "Delete Category",
                        IconCls = "icon-category-delete",
                        Disabled = true
                    },
                    new ToolbarSeparator(),
                    new Button
                    {
                        ToolTip = "New Folder",
                        IconCls = "icon-folder-new",
                        Disabled = true
                    },
                    new Button
                    {
                        ToolTip = "Delete Folder",
                        IconCls = "icon-folder-delete",
                        Disabled = true
                    }
                }
            };

            this.BottomBar.Add(this.bBar);
        }

        private void BuildCategoryMenu()
        {
            this.ctxCategory = new Menu
            {
                Items =
                   {
                       new MenuItem
                       {
                           Text = "New Task",
                           IconCls = "icon-edit"
                       },
                       new MenuSeparator(),
                       new MenuItem
                       {
                           Text = "Delete",
                           IconCls = "icon-category-delete"
                       }
                   }
            };

            this.Controls.Add(this.ctxCategory);
            this.LazyItems.Add(this.ctxCategory);
            this.ctxCategory.LazyMode = LazyMode.Instance;
        }

        private void BuildFolderMenu()
        {
            this.ctxFolder = new Menu
            {
                Items =
                   {
                       new MenuItem
                       {
                           Text = "New Category",
                           IconCls = "icon-category-new"
                       },
                       new MenuItem
                       {
                           Text = "New Folder",
                           IconCls = "icon-folder-new"
                       },
                       new MenuSeparator(),
                       new MenuItem
                       {
                           Text = "Delete",
                           IconCls = "icon-category-delete"
                       }
                   }
            };

            this.Controls.Add(this.ctxFolder);
            this.LazyItems.Add(this.ctxFolder);
            this.ctxFolder.LazyMode = LazyMode.Instance;
        }
    }
}
