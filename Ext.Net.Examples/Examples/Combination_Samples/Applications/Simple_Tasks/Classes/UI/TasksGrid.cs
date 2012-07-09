using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace Ext.Net.Examples.SimpleTasks
{
    public partial class TasksGrid : GridPanel
    {
        private Store store;
        private Menu ctxMenu;
        private TreePanel ctxTreeCategory;

        public TasksGrid()
        {
            this.Title = "All Lists";
            this.IconCls = "icon-folder";
            this.EnableColumnHide = false;
            this.EnableColumnMove = false;
            this.EnableDragDrop = true;
            this.DDGroup = "tasktree";

            this.SelectionModel.Add(new RowSelectionModel
            {
                MoveEditorOnEnter = false
            });

            this.View.Add(new GroupingView
            {
                ForceFit = true,
                MarkDirty = false,
                IgnoreAdd = true,
                EmptyText = "There are no tasks to show in this category.",
                GetRowClass = { Fn = TasksGrid.SCOPE + ".getRowClass" }
            });

            //this.LoadMask.ShowMask = true;
            //this.LoadMask.Msg = "Loading Tasks...";

            this.BuildStore();
            this.BuildColumnModel();
            this.BuildHeaderRow();
            this.BuildContextMenu();
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
                category.Add("contextMenu", new ConfigOption("contextMenu", new SerializationOptions("ctxMenu", typeof(LazyControlJsonConverter)), null, this.ContextMenu));

                return category;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(null)]
        public Menu ContextMenu
        {
            get
            {
                return this.ctxMenu;
            }
        }


        private void BuildContextMenu()
        {
            ctxTreeCategory = new TreePanel
              {
                  ID = "ctxTreeCategory",
                  Height = 300,
                  Width = 200,
                  Shadow = ShadowMode.None,
                  UseArrows = true,
                  AutoScroll = true,
                  Animate = true,
                  RootVisible = false,
                  Cls = "tasks-tree",
                  Root =
                  {
                      new TreeNode("root")
                  },
                  SelectionModel =
                  {
                      new DefaultSelectionModel()
                  }
              };

            this.ctxMenu = new Menu
            {
                Items =
                   {
                       new MenuItem
                       {
                           ID = "mnuTaskGrid_OpenTask",
                           Text = "Open"
                       },
                       new MenuItem
                       {
                           Text = "Move To...",
                           Icon = Net.Icon.ArrowRight,
                           Menu =
                           {
                               new Menu
                               {
                                   Items =
                                   {
                                       new ComponentMenuItem
                                       {
                                           Shift = false,
                                           Component =
                                           {
                                               new Panel
                                               {
                                                   Width = 200,
                                                   BodyStyle = "color: #3764a0;",
                                                   Padding = 5,
                                                   Html = "You can drag and drop tasks from<br/>the grid to the west tree also"
                                               }
                                           }
                                       },
                                       new MenuSeparator(),
                                       new ComponentMenuItem
                                       {
                                           Shift = false,
                                           Component =
                                           {
                                               this.ctxTreeCategory
                                           }
                                       }
                                   }
                               }
                           }
                       },
                       new MenuSeparator(),
                       new MenuItem
                       {
                           ID = "mnuTaskGrid_MarkTask",
                           Text = "Mark Complete",
                           IconCls = "icon-mark-complete"
                       },
                       new MenuItem
                       {
                           ID = "mnuTaskGrid_DeleteTask",
                           Text = "Delete",
                           IconCls = "icon-category-delete"
                       }
                   }
            };

            this.Controls.Add(this.ctxMenu);
            this.LazyItems.Add(this.ctxMenu);
            this.ctxMenu.LazyMode = LazyMode.Instance;
        }

        private void BuildHeaderRow()
        {
            GridView view = this.View[0];
            view.HeaderRows.Add(new HeaderRow
            {
                Columns =
                {
                    new HeaderColumn
                        {
                            Cls = "x-small-editor",
                            Component =
                            {
                                new Container
                                {
                                    AutoEl =
                                    {
                                        ID = "icnIndicator",
                                        Cls = "new-task-icon"
                                    }
                                }
                            }
                        },
                    new HeaderColumn
                    {
                        Cls = "x-small-editor",
                        Component =
                        {
                            new TextField
                            {
                                ID = "ntTitle",
                                IDMode = IDMode.Static,
                                EmptyText = "Add a task...",
                                Listeners =
                                {
                                    Focus =
                                    {
                                        Fn = TasksGrid.SCOPE+".onFocusNewTask",
                                        Scope = TasksGrid.SCOPE
                                    }
                                }
                            }
                        }
                    },
                    new HeaderColumn
                    {
                        Cls = "x-small-editor",
                        Component =
                        {
                            new DropDownField
                            {
                                ID = "ntCategory",
                                IDMode = IDMode.Static,
                                Disabled = true,
                                LazyInit = false,
                                Editable = false,
                                Mode = DropDownMode.ValueText,
                                Component =
                                {
                                    new TreePanel
                                    {
                                        ID = "ntTreeCategory",
                                        Height = 300,
                                        Shadow = ShadowMode.None,
                                        UseArrows = true,
                                        AutoScroll = true,
                                        Animate = true,
                                        RootVisible = false,
                                        Cls = "tasks-tree",
                                        Root =
                                        {
                                            new TreeNode("root")
                                        },
                                        SelectionModel =
                                        {
                                            new DefaultSelectionModel()
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new HeaderColumn
                    {
                        Cls = "x-small-editor",
                        Component =
                        {
                            new DateField
                            {
                                ID = "ntDue",
                                IDMode = IDMode.Static,
                                Editable = false,
                                Disabled = true
                            }
                        }
                    },
                    new HeaderColumn
                    {
                        Component =
                            {
                                new Button
                                    {
                                        Icon = Icon.Add,
                                        ToolTip = "Add new task",
                                        Handler = TasksGrid.SCOPE+".onAddTask",
                                        Scope = TasksGrid.SCOPE
                                    }
                            }
                    }
                }
            });
        }

        private void BuildColumnModel()
        {
            ColumnModel cm = this.ColumnModel;
            cm.Columns.Add(new CommandColumn
               {
                   Commands =
                   {
                       new GridCommand
                       {
                           IconCls = "icon-active",
                           CommandName = "togglestatus"
                       }
                   },
                   Header = "<div class='task-col-hd'></div>",
                   Width = 25,
                   Fixed = true,
                   MenuDisabled = true
               });

            cm.Columns.Add(new Column
               {
                   Header = "Task",
                   Width = 400,
                   Sortable = true,
                   DataIndex = "Title"
               });

            cm.Columns.Add(new Column
               {
                   Header = "Category",
                   Width = 150,
                   Sortable = true,
                   DataIndex = "ID",
                   Renderer = new Renderer("return record.get('Name');")
               });

            cm.Columns.Add(new DateColumn
               {
                   Header = "Due Date",
                   Width = 150,
                   Sortable = true,
                   DataIndex = "DueDate",
                   GroupName = "Due"
               });

            cm.Columns.Add(new Column
               {
                   Fixed = true,
                   MenuDisabled = true,
                   Width = 25,
                   DataIndex = ""
               });
        }

        private void BuildStore()
        {
            this.store = new Store
             {
                 AutoLoad = false,
                 WarningOnDirty = false,
                 Reader =
                 {
                     new JsonReader
                     {
                         IDProperty = "ID",
                         Fields =
                         {
                             new RecordField("ID", RecordFieldType.Int),
                             new RecordField
                             {
                                 Name = "Name",
                                 ServerMapping = "Category.Name"
                             },
                             new RecordField("Title"),
                             new RecordField("Description"),
                             new RecordField("DueDate", RecordFieldType.Date),
                             new RecordField
                             {
                                 Name = "Completed",
                                 Type = RecordFieldType.Boolean,
                                 DefaultValue = "={false}"
                             },
                             new RecordField("CompletedDate", RecordFieldType.Date),
                             new RecordField("Reminder", RecordFieldType.Date)
                         }
                     }
                 },
                 SortInfo =
                 {
                     Field = "DueDate",
                     Direction = SortDirection.ASC
                 },
                 GroupField = "DueDate",
                 Proxy =
                 {
                     new PageProxy()
                 }
             };

            this.Store.Add(this.store);
        }
    }
}