namespace Ext.Net.Examples.SimpleTasks
{
    public partial class TaskWindow : Window
    {
        private Toolbar toolbar;
        private FormPanel formPanel;
        private Checkbox cbxReminder;
        private DateField dfReminder;
        private TextField taskSubject;
        private DateField dueDate;
        private DropDownField taskCategory;
        private HtmlEditor description;

        public TaskWindow()
        {
            this.Width = 480;
            this.Height = 365;
            this.InitCenter = true;
            this.Resizable = false;
            this.Layout = "Border";
            this.CloseAction = CloseAction.Close;

            this.BuildToolbar();
            this.BuildFormPanel();
        }

        private void BuildToolbar()
        {
            this.toolbar = new Toolbar
               {
                   Ref = "buttonsBar",
                   Region = Ext.Net.Region.North,
                   Height = 26,
                   Items =
                   {
                       new Button
                       {
                           Ref = "../markComplete",
                           IconCls = "icon-mark-complete",
                           Text = "Mark Complete"
                       },
                       new Button
                       {
                           Ref = "../markActive",
                           Hidden = true,
                           IconCls = "icon-mark-active",
                           Text = "Mark Active"
                       },
                       new ToolbarSeparator(),
                       new Button
                       {
                           IconCls = "icon-delete-task",
                           Text = "Delete"
                       }
                   }
               };

            this.Items.Add(this.toolbar);
        }

        private void BuildFormPanel()
        {
            this.cbxReminder = new Checkbox  {
                Ref = "../../../hasReminder",
                BoxLabel = "Reminder:",
                DataIndex = "HasReminder",
                Checked = false
            };

            this.dfReminder = new DateField
            {
                Ref = "../../../reminder",
                Disabled = true,
                DataIndex = "Reminder",
                Width = 135
            };

            this.taskSubject = new TextField
            {
                AllowBlank = false,
                FieldLabel = "Task&nbsp;Subject",
                DataIndex = "Title",
                Anchor = "100%"
            };

            this.dueDate = new DateField
            {
                AllowBlank = false,
                FieldLabel = "Due Date",
                DataIndex = "DueDate",
                Width = 135
            };

            this.taskCategory = new DropDownField
              {
                  AllowBlank = false,
                  LazyInit = false,
                  FieldLabel = "Task List",
                  DataIndex = "Name",
                  Editable = false,
                  Mode = DropDownMode.ValueText,
                  Ref = "../../../taskCategory",
                  Component =
                  {
                      new TreePanel
                      {
                          Height = 150,
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
              };

            this.description = new HtmlEditor
            {
                HideLabel = true,
                DataIndex = "Description",
                Anchor = "100% -150",
                EnableSourceEdit = false,
                EnableFont = false
            };

            this.formPanel = new FormPanel
             {
                 Region = Ext.Net.Region.Center,
                 LabelWidth = 75,
                 ButtonAlign = Alignment.Right,
                 MinButtonWidth = 80,
                 BaseCls = "x-plain",
                 Ref = "taskForm",
                 Cls = "task-window", RenderFormElement = false,

                 CustomConfig =
                 {
                     new ConfigItem("margins", "10 10 5 10", ParameterMode.Value)
                 },

                 Items =
                 {
                     new BoxComponent
                     {
                         Hidden = true,
                         Ref = "../taskMessage",
                         AutoEl =
                         {
                             Cls = "taskMessage"
                         }
                     },
                     taskSubject,
                     new Container
                     {
                         Cls = "x-plain",
                         Layout = "Hbox",
                         Anchor = "100%",
                         Height = 30,
                         Items =
                         {
                             new Container
                             {
                                 Width = 250,
                                 Layout = "Form",
                                 Cls = "x-pain",
                                 Items =
                                 {
                                     dueDate
                                 }
                             },
                             new Container
                             {
                                 Flex = 1,
                                 Layout = "Form",
                                 Cls = "x-plain",
                                 LabelWidth = 55,
                                 Items =
                                 {
                                     taskCategory
                                 }
                             }
                         }
                     },
                     new BoxComponent
                     {
                         AutoEl =
                         {
                             Cls = "divider"
                         }
                     },
                     new Container
                     {
                         Layout = "HBox",
                         Anchor = "100%",
                         Cls = "x-plain",
                         Height = 30,
                         Items =
                         {
                             new Container
                             {
                                 Width = 80,
                                 Layout = "Form",
                                 Cls = "x-plain",
                                 HideLabels = true,
                                 Items =
                                 {
                                     cbxReminder
                                 }
                             },
                             new Container
                             {
                                 Flex = 1,
                                 Layout = "Form",
                                 Cls = "x-plain",
                                 HideLabels = true,
                                 Items =
                                 {
                                     dfReminder
                                 }
                             }
                         }
                     },
                     description
                 }
             };

            this.Buttons.Add(new Button ("OK"));
            this.Buttons.Add(new Button ("Cancel"));

            this.Items.Add(this.formPanel);
        }
    }
}