<%@ Page Language="C#" %>

<%@ Import Namespace="System.Collections.ObjectModel" %>
<%@ Import Namespace="System.Collections.Generic" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            var store = this.GridPanel1.GetStore();
            
            store.DataSource = new List<object>
            {
                new { 
                    Name = "Bill Foot", 
                    Email = "bill.foot@ext.net", 
                    Start = new DateTime(2007, 2, 5), 
                    Salary = 37000, 
                    Active = true
                },
                new { 
                    Name = "Bill Little", 
                    Email = "bill.little@ext.net", 
                    Start = new DateTime(2009, 6, 13), 
                    Salary = 53000, 
                    Active = true
                },
                new { 
                    Name = "Bob Jones", 
                    Email = "bob.jones@ext.net", 
                    Start = new DateTime(2008, 10, 6), 
                    Salary = 70000, 
                    Active = true
                },
                new { 
                    Name = "Bob Train", 
                    Email = "bob.train@ext.net", 
                    Start = new DateTime(2009, 5, 5), 
                    Salary = 68000, 
                    Active = true
                },
                new { 
                    Name = "Chris Johnson", 
                    Email = "chris.johnson@ext.net", 
                    Start = new DateTime(2009, 1, 25), 
                    Salary = 47000, 
                    Active = true
                }
            };
            
            store.DataBind();
        }
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GridPanel with RowEditor Plugin - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <ext:XScript runat="server">
        <script type="text/javascript">
            var addEmployee = function () {
                var grid = #{GridPanel1};
                grid.getRowEditor().stopEditing();
                
                grid.insertRecord(0, {
                    name   : "New Guy",
                    email  : "guy@ext.net",
                    start  : (new Date()).clearTime(),
                    salary : 50000,
                    active : true
                });
                
                grid.getView().refresh();
                grid.getSelectionModel().selectRow(0);
                grid.getRowEditor().startEditing(0);
            }
            
            var removeEmployee = function () {
                var grid = #{GridPanel1};
                grid.getRowEditor().stopEditing();
                
                var s = grid.getSelectionModel().getSelections();
                
                for (var i = 0, r; r = s[i]; i++) {
                    #{Store1}.remove(r);
                }
            }
        </script>
    </ext:XScript>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>GridPanel with RowEditor Plugin</h1>
        
        <ext:GridPanel 
            ID="GridPanel1" 
            runat="server"
            Width="600"
            Height="400"
            AutoExpandColumn="name"
            Title="Employees">
            <Store>
                <ext:Store ID="Store1" runat="server">
                    <Reader>
                        <ext:JsonReader>
                            <Fields>
                                <ext:RecordField Name="name" Mapping="Name" Type="String" />
                                <ext:RecordField Name="email" Mapping="Email" Type="String" />
                                <ext:RecordField Name="start" Mapping="Start" Type="Date" />
                                <ext:RecordField Name="salary" Mapping="Salary" Type="Float" />
                                <ext:RecordField Name="active" Mapping="Active" Type="Boolean" />
                            </Fields>
                        </ext:JsonReader>
                    </Reader>
                </ext:Store>
            </Store>
            <Plugins>
                <ext:RowEditor runat="server" SaveText="Update" />
            </Plugins>
            <View>
                <ext:GridView runat="server" MarkDirty="false" />
            </View>
            <TopBar>
                <ext:Toolbar runat="server">
                    <Items>
                        <ext:Button runat="server" Text="Add Employee" Icon="UserAdd">
                            <Listeners>
                                <Click Fn="addEmployee" />
                            </Listeners>
                        </ext:Button>
                        <ext:Button runat="server" Text="Remove Employee" Icon="UserDelete">
                            <Listeners>
                                <Click Fn="removeEmployee" />
                            </Listeners>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <SelectionModel>
                <ext:RowSelectionModel runat="server" />
            </SelectionModel>
            <ColumnModel>
                <Columns>
                    <ext:RowNumbererColumn />
                    <ext:Column 
                        ColumnID="name" 
                        Header="First Name" 
                        DataIndex="name" 
                        Width="220" 
                        Sortable="true">
                        <Editor>
                            <ext:TextField runat="server" AllowBlank="false" />
                        </Editor>
                    </ext:Column>
                    <ext:Column Header="Email" DataIndex="email" Width="150">
                        <Editor>
                            <ext:TextField runat="server" AllowBlank="false" Vtype="email" />
                        </Editor>
                    </ext:Column>
                    <ext:DateColumn 
                        Header="Start Date" 
                        DataIndex="start" 
                        Format="MM/dd/yyyy" 
                        Width="100" 
                        Sortable="true">
                        <Editor>
                            <ext:DateField 
                                runat="server" 
                                AllowBlank="false" 
                                MinDate="01.01.2006" 
                                MinText="Can not have a start date before the Company existed." 
                                />
                        </Editor>
                    </ext:DateColumn>
                    <ext:NumberColumn 
                        Header="Salary" 
                        DataIndex="salary" 
                        Format="$0,0.00" 
                        Width="100" 
                        Sortable="true">
                        <Editor>
                            <ext:NumberField 
                                runat="server" 
                                AllowBlank="false" 
                                MinValue="1" 
                                MaxValue="150000" 
                                />
                        </Editor>
                    </ext:NumberColumn>
                    <ext:BooleanColumn 
                        Header="Active" 
                        DataIndex="active" 
                        Align="Center" 
                        Width="50" 
                        TrueText="Yes" 
                        FalseText="No">
                        <Editor>
                            <ext:Checkbox runat="server" />
                        </Editor>
                    </ext:BooleanColumn>
                </Columns>
            </ColumnModel>
        </ext:GridPanel>
    </form>  
</body>
</html>