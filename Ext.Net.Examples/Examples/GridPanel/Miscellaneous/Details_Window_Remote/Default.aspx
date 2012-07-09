<%@ Page Language="C#" %>

<%@ Import Namespace="Ext.Net.Examples.Northwind"%>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register src="WindowEditor.ascx" tagname="WindowEditor" tagprefix="uc1" %>

<script runat="server">
    protected void Page_Init(object sender, EventArgs e)
    {
        this.WindowEditor1.GridStore = this.Store1;
    }
    
    protected void ShowDetails(object sender, DirectEventArgs e)
    {
        string id = e.ExtraParams["id"];
        this.WindowEditor1.SetEmployee(Employee.GetEmployee(int.Parse(id)));
        this.WindowEditor1.Show();            
    }

    protected void Store1_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        int count;
        this.Store1.DataSource = Employee.GetEmployeesFilter(e.Start, e.Limit, e.Sort, e.Dir.ToString(), out count);
        e.Total = count;

        this.Store1.DataBind();
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
	"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
   
    <script type="text/javascript">                
        var employeeDetailsRender = function () {
            return '<img class="imgEdit" ext:qtip="Click to view/edit additional details" style="cursor:pointer;" src="vcard_edit.png" />';
        };

        var cellClick = function (grid, rowIndex, columnIndex, e) {
            var t = e.getTarget(),
                record = grid.getStore().getAt(rowIndex),  // Get the Record
                columnId = grid.getColumnModel().getColumnId(columnIndex); // Get column id

            if (t.className == "imgEdit" && columnId == "Details") {
                //the ajax call is allowed
                return true;
            }
            
            //forbidden
            return false;
        };
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>Custom Window with Record Details (AJAX Version)</h1>
        
        <p>For view/edit additional properties please click on the image in last column</p>
        
        <ext:Store ID="Store1" runat="server" RemoteSort="true" OnRefreshData="Store1_RefreshData">
            <Proxy>
                <ext:PageProxy />
            </Proxy>
            <Reader>
                <ext:JsonReader IDProperty="EmployeeID">
                    <Fields>
                        <ext:RecordField Name="EmployeeID" />
                        <ext:RecordField Name="FirstName" />
                        <ext:RecordField Name="LastName" />
                        <ext:RecordField Name="Title" />                        
                        <ext:RecordField Name="BirthDate" Type="Date" DateFormat="yyyy-MM-ddTHH:mm:ss" />                       
                        <ext:RecordField Name="City" />
                        <ext:RecordField Name="Address" />                  
                    </Fields>
                </ext:JsonReader>
            </Reader>
            <AutoLoadParams>
                <ext:Parameter Name="start" Value="0" Mode="Raw" />
                <ext:Parameter Name="limit" Value="5" Mode="Raw" />
            </AutoLoadParams>
            <SortInfo Field="LastName" Direction="ASC" />
            <Listeners> 
                <LoadException Handler="Ext.MessageBox.alert('Load failed', response.statusText);" />                            
            </Listeners>
        </ext:Store>
        
        <ext:GridPanel 
            ID="GridPanel1" 
            runat="server" 
            StoreID="Store1" 
            Title="Employees" 
            Header="false" 
            Height="175" 
            AutoExpandColumn="Employee">
            <ColumnModel runat="server">
			    <Columns>
                    <ext:Column ColumnID="Employee" Header="Full Name" DataIndex="LastName">  
                        <Renderer Handler="return '<b>' + record.data['LastName'] + '</b>,' + record.data['FirstName']" />                 
                    </ext:Column>
                    <ext:Column Header="Title" DataIndex="Title" Width="150" />
                    <ext:DateColumn Header="Birth Date" DataIndex="BirthDate" Format="yyyy-MM-dd" />
                    <ext:Column Header="City" DataIndex="City" Width="100" />
                    <ext:Column Header="Address" DataIndex="Address" Width="250" />
                    <ext:Column 
                        ColumnID="Details" 
                        Header="Details" 
                        Width="50" 
                        Align="Center" 
                        Fixed="true" 
                        MenuDisabled="true" 
                        Resizable="false">
                        <Renderer Fn="employeeDetailsRender" 
                        />                    
                    </ext:Column>
			    </Columns>
            </ColumnModel>
            <LoadMask ShowMask="true" />
            <SaveMask ShowMask="true" />
            <BottomBar>
                <ext:PagingToolbar ID="PagingToolBar1" runat="server" 
                    PageSize="5" 
                    DisplayInfo="true"
                    DisplayMsg="Displaying employees {0} - {1} of {2}"
                    EmptyMsg="No employees to display"                
                    />
            </BottomBar>
            <Listeners>
                <CellClick Fn="cellClick" />
            </Listeners>       
            <DirectEvents>
                <CellClick 
                    OnEvent="ShowDetails" 
                    Failure="Ext.MessageBox.alert('Load failed', 'Error during ajax event!');">
                    <EventMask ShowMask="true" Target="CustomTarget" CustomTarget="={#{GridPanel1}.body}" />
                    <ExtraParams>
                        <ext:Parameter Name="id" Value="params[0].getStore().getAt(params[1]).id" Mode="Raw" />
                    </ExtraParams>
                </CellClick>
            </DirectEvents>    
        </ext:GridPanel>
        
        <uc1:WindowEditor ID="WindowEditor1" runat="server" />
    </form>
</body>
</html>
