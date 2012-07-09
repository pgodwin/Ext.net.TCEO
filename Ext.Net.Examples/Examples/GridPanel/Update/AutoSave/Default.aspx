<%@ Page Language="C#" %>

<%@ Import Namespace="System.Collections.Generic"%>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        bool useConfirmation;
    
        if (bool.TryParse(UseConfirmation.Text, out useConfirmation))
        {
            this.Store1.SuspendScripting();
            this.Store1.UseIdConfirmation = useConfirmation;
            this.Store1.ResumeScripting();
        }
    
        this.BindData();
    }
    
    public class TestPerson
    {
        public int Id
        {
            get; set;
        }

        public string Email
        {
            get; set;
        }

        public string First
        {
            get;
            set;
        }

        public string Last
        {
            get;
            set;
        }
    }
    
    //----------------Page------------------------
    private List<TestPerson> TestPersons
    {
        get
        {
            return new List<TestPerson>
               {
                   new TestPerson{Id=1, Email="fred@flintstone.com", First="Fred", Last="Flintstone"},
                   new TestPerson{Id=2, Email="wilma@flintstone.com", First="Wilma", Last="Flintstone"},
                   new TestPerson{Id=3, Email="pebbles@flintstone.com", First="Pebbles", Last="Flintstone"},
                   new TestPerson{Id=4, Email="barney@rubble.com", First="Barney", Last="Rubble"},
                   new TestPerson{Id=5, Email="betty@rubble.com", First="Betty", Last="Rubble"},
                   new TestPerson{Id=6, Email="bambam@rubble.com", First="BamBam", Last="Rubble"}
               };
        }
    }

    private static int curId = 7;
    private static object lockObj = new object();
    
    private int NewId
    {
        get
        {
            return System.Threading.Interlocked.Increment(ref curId);
        }
    }
    
    private List<TestPerson> CurrentData
    {
        get
        {
            var persons = this.Session["TestPersons"];
            
            if (persons == null)
            {
                persons = this.TestPersons;
                this.Session["TestPersons"] = persons;
            }

            return (List<TestPerson>)persons;
        }
    }
    
    private int AddPerson(TestPerson person)
    {
        lock (lockObj)
        {
            var persons = this.CurrentData;
            person.Id = this.NewId;
            persons.Add(person);
            this.Session["TestPersons"] = persons;

            return person.Id;
        }
    }

    private void DeletePerson(int id)
    {
        lock (lockObj)
        {
            var persons = this.CurrentData;
            TestPerson person = null;
            
            foreach (TestPerson p in persons)
            {
                if (p.Id == id)
                {
                    person = p;
                    break;
                }
            }
            
            if (person == null)
            {
                throw new Exception("TestPerson not found");
            }

            persons.Remove(person);
            
            this.Session["TestPersons"] = persons;
        }
    }
    
    private void UpdatePerson(TestPerson person)
    {
        lock (lockObj)
        {
            if (person.Id % 2 != 0)
            {
                throw new Exception("SIMULATED ERROR: ODD-numbered id");
            }
            
            var persons = this.CurrentData;
            TestPerson updatingPerson = null;
            
            foreach (TestPerson p in persons)
            {
                if (p.Id == person.Id)
                {
                    updatingPerson = p;
                    break;
                }
            }

            if (updatingPerson == null)
            {
                throw new Exception("TestPerson not found");
            }

            updatingPerson.Email = person.Email;
            updatingPerson.Last = person.Last;
            updatingPerson.First = person.First;

            this.Session["TestPersons"] = persons;
        }
    }
    
    private void BindData()
    {
        if (X.IsAjaxRequest)
        {
            return;
        }

        this.Store1.DataSource = this.CurrentData;
        this.Store1.DataBind();
    }
    
    protected void HandleChanges(object sender, BeforeStoreChangedEventArgs e)
    {
        ChangeRecords<TestPerson> persons = e.DataHandler.ObjectData<TestPerson>();

        foreach (TestPerson created in persons.Created)
        {
            int tempId = created.Id;
            int newId = this.AddPerson(created);
            
            if (Store1.UseIdConfirmation)
            {
                e.ConfirmationList.ConfirmRecord(tempId.ToString(), newId.ToString());
            }
            else
            {
                Store1.UpdateRecordId(tempId, newId);   
            }
            
        }

        foreach (TestPerson deleted in persons.Deleted)
        {
            this.DeletePerson(deleted.Id);
            
            if (Store1.UseIdConfirmation)
            {
                e.ConfirmationList.ConfirmRecord(deleted.Id.ToString());
            }
        }

        foreach (TestPerson updated in persons.Updated)
        {
            this.UpdatePerson(updated);
            
            if (Store1.UseIdConfirmation)
            {
                e.ConfirmationList.ConfirmRecord(updated.Id.ToString());
            }
        }
        e.Cancel = true;
    }
</script>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Grid with AutoSave - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />    
    <script type="text/javascript">
       var updateRecord = function (form) {
            if (form.record == null) {
                return;
            }
            
            if (!form.getForm().isValid()) {
                Ext.net.Notification.show({
                    iconCls  : "icon-exclamation",
                    html     : "Form is invalid",
                    title    : "Error"
                });
                return false;
            }
            
            form.getForm().updateRecord(form.record);
       };
       
       var addRecord = function (form, grid) {
            if (!form.getForm().isValid()) {
                Ext.net.Notification.show({
                    iconCls  : "icon-exclamation",
                    html     : "Form is invalid",
                    title    : "Error"
                });
            
                return false;
            }
            
            grid.insertRecord(0, form.getForm().getFieldValues(false, "dataIndex"));
            form.getForm().reset();
       };
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>Grid with AutoSave</h1>
        
        <p>An Error has been simulated on the server-side: Attempting to update a record having ODD-numbered id will generate this errror. This error can be handled by listening to the "exception" event upon your Store.</p>
        
        <ext:Store 
            ID="Store1" 
            runat="server" 
            AutoSave="true" 
            ShowWarningOnFailure="false"
            OnBeforeStoreChanged="HandleChanges" 
            SkipIdForNewRecords="false"
            RefreshAfterSaving="None">
            <Reader>
                <ext:JsonReader IDProperty="Id">
                    <Fields>
                        <ext:RecordField Name="Id" />
                        <ext:RecordField Name="Email" AllowBlank="false" />
                        <ext:RecordField Name="First" AllowBlank="false" />
                        <ext:RecordField Name="Last" AllowBlank="false" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
            
            <Listeners>
                <Exception Handler="
                    Ext.net.Notification.show({
                        iconCls    : 'icon-exclamation', 
                        html       : e.message, 
                        title      : 'EXCEPTION', 
                        autoScroll : true, 
                        hideDelay  : 5000, 
                        width      : 300, 
                        height     : 200
                    });" />
                <BeforeSave Handler="var valid = true; this.each(function(r){if(r.dirty && !r.isValid()){valid=false;}}); return valid;" />
            </Listeners>
        </ext:Store>
        
        <ext:Hidden ID="UseConfirmation" runat="server" Text="false" />
        
        <ext:FormPanel 
            ID="UserForm" 
            runat="server"
            Icon="User"
            Frame="true"
            LabelAlign="Right"
            Title="User -- All fields are required"
            Width="500">
            <Items>
                <ext:TextField runat="server"
                    FieldLabel="Email"
                    DataIndex="Email"
                    AllowBlank="false"
                    Vtype="email"
                    AnchorHorizontal="100%"
                    />
                
                <ext:TextField runat="server"
                    FieldLabel="First"
                    DataIndex="First"
                    AllowBlank="false"
                    AnchorHorizontal="100%"
                    />
                
                <ext:TextField runat="server"
                    FieldLabel="Last"
                    DataIndex="Last"
                    AllowBlank="false"
                    AnchorHorizontal="100%"
                    />
            </Items>
            
            <Buttons>
                <ext:Button 
                    runat="server"
                    Text="Save"
                    Icon="Disk">
                    <Listeners>
                        <Click Handler="updateRecord(#{UserForm});" />
                    </Listeners>
                </ext:Button>
                
                <ext:Button 
                    runat="server"
                    Text="Create"
                    Icon="UserAdd">
                    <Listeners>
                        <Click Handler="addRecord(#{UserForm}, #{GridPanel1});" />
                    </Listeners>
                </ext:Button>
                
                <ext:Button 
                    runat="server"
                    Text="Reset">
                    <Listeners>
                        <Click Handler="#{UserForm}.getForm().reset();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:FormPanel>
        
        <ext:GridPanel 
            ID="GridPanel1" 
            runat="server"
            Icon="Table"
            Frame="true"
            Title="Users"
            Height="400"
            Width="500"
            StoreID="Store1"
            StyleSpec="margin-top: 10px">
            <ColumnModel>
                <Columns>
                    <ext:Column Header="ID" Width="40" DataIndex="Id" />
                    
                    <ext:Column Header="Email" Width="100" DataIndex="Email">
                        <Editor>
                            <ext:TextField runat="server" />    
                        </Editor>
                    </ext:Column>
                    
                    <ext:Column Header="First" Width="50" DataIndex="First">
                        <Editor>
                            <ext:TextField runat="server" />    
                        </Editor>
                    </ext:Column>
                    
                    <ext:Column Header="Last" Width="50" DataIndex="Last">
                        <Editor>
                            <ext:TextField runat="server" />    
                        </Editor>
                    </ext:Column>
                    
                    <ext:CommandColumn Width="40">
                        <Commands>
                            <ext:GridCommand Text="Reject" ToolTip-Text="Reject row changes" CommandName="reject" Icon="ArrowUndo" />
                        </Commands>
                        <PrepareToolbar Handler="toolbar.items.get(0).setVisible(record.dirty);" />
                    </ext:CommandColumn>
                </Columns>
            </ColumnModel>
            
            <Listeners>
                <Command Handler="record.reject();" />
            </Listeners>
            
            <View>
                <ext:GridView runat="server" ForceFit="true" />
            </View>
            
            <TopBar>
                <ext:Toolbar runat="server">
                    <Items>
                        <ext:Button runat="server" Text="Add" Icon="Add">
                            <Listeners>
                                <Click Handler="#{GridPanel1}.insertRecord();" />
                            </Listeners>
                        </ext:Button>
                        
                        <ext:Button runat="server" Text="Delete" Icon="Exclamation">
                            <Listeners>
                                <Click Handler="#{GridPanel1}.deleteSelected();#{UserForm}.getForm().reset();" />
                            </Listeners>
                        </ext:Button>
                        
                        <ext:ToolbarSeparator />
                        
                        <ext:Button 
                            runat="server" 
                            Text="Auto Save"
                            EnableToggle="true"
                            Pressed="true"
                            ToolTip="When enabled, Store will execute Ajax requests as soon as a Record becomes dirty.">
                            <Listeners>
                                <Toggle Handler="#{Store1}.autoSave = pressed;#{Store1}.useIdConfirmation = !pressed;#{UseConfirmation}.setValue(!pressed);" />
                            </Listeners>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
            
            <SelectionModel>
                <ext:RowSelectionModel runat="server" SingleSelect="true">
                    <Listeners>
                        <RowSelect Handler="#{UserForm}.getForm().loadRecord(record);#{UserForm}.record = record;" />
                    </Listeners>
                </ext:RowSelectionModel>
            </SelectionModel>
            
            <Buttons>
                <ext:Button runat="server" Text="Save" Icon="Disk">
                    <Listeners>
                        <Click Handler="#{GridPanel1}.save();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:GridPanel>
    </form>
</body>
</html>