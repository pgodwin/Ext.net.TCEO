<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<%@ Register src="WindowEditor.ascx" tagname="WindowEditor" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Custom Window with Record Details - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript">
        var CompanyX = {               
            _index : 0,
            
            getIndex : function () {
                return this._index;
            },
            
            setIndex : function (index) {
                if (index > -1 && index < GridPanel1.getStore().getCount()) {
                    this._index = index;
                }
            },
            
            getRecord : function () {
                var rec = GridPanel1.getStore().getAt(this.getIndex());  // Get the Record
                
                if (rec != null) {
                    return rec;
                }
            },
            
            edit : function (index) {
                this.setIndex(index);
                this.open();
            },
            
            next : function () {
                this.edit(this.getIndex() + 1);
            },
            
            previous : function () {
                this.edit(this.getIndex() - 1);
            }
        };
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>Custom Window with Record Details</h1>
        
        <p>For view/edit additional properties please click on the image in last column.</p>
        
        <ext:GridPanel 
            runat="server" 
            ID="GridPanel1" 
            Title="Employees" 
            Height="200"
            AutoExpandColumn="Employee">
            <Store>
                <ext:Store runat="server">
                    <Proxy>
                        <ext:HttpProxy runat="server" Method="POST" Url="../../Shared/EmployeesControler.ashx" />
                    </Proxy>
                    <Reader>
                        <ext:JsonReader TotalProperty="total" Root="data" IDProperty="EmployeeID">
                            <Fields>
                                <ext:RecordField Name="EmployeeID" />
                                <ext:RecordField Name="FirstName" />
                                <ext:RecordField Name="LastName" />
                                <ext:RecordField Name="Title" />
                                <ext:RecordField Name="TitleOfCourtesy" />
                                <ext:RecordField Name="BirthDate" Type="Date" />
                                <ext:RecordField Name="HireDate" Type="Date" />
                                <ext:RecordField Name="City" />
                                <ext:RecordField Name="Address" />
                                <ext:RecordField Name="Region" />
                                <ext:RecordField Name="PostalCode" />
                                <ext:RecordField Name="Country" />
                                <ext:RecordField Name="Homephone" />
                                <ext:RecordField Name="Extension" />
                                <ext:RecordField Name="Notes" />
                                <ext:RecordField Name="Photopath" />
                                <ext:RecordField Name="ReportsTo" />
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
            </Store>
            <ColumnModel runat="server">
			    <Columns>
                    <ext:Column ColumnID="Employee" Header="Full Name" DataIndex="LastName">  
                        <Renderer Handler="return '<b>' + record.data['LastName'] + '</b>,' + record.data['FirstName']" />                 
                    </ext:Column>
                    <ext:Column Header="Title" DataIndex="Title" Width="150">
                        <Editor>
                            <ext:TextField runat="server" />
                        </Editor>
                    </ext:Column>
                    <ext:DateColumn Header="Birth Date" DataIndex="BirthDate" Format="yyyy-MM-dd">
                        <Editor>
                            <ext:DateField runat="server" Format="yyyy-MM-dd" />
                        </Editor>
                    </ext:DateColumn>
                    <ext:Column Header="City" DataIndex="City" Width="100">
                        <Editor>
                            <ext:TextField runat="server" />
                        </Editor>
                    </ext:Column>
                    <ext:Column Header="Address" DataIndex="Address" Width="250">
                        <Editor>
                            <ext:TextField runat="server" />
                        </Editor>
                    </ext:Column>
                    <ext:CommandColumn Width="35">
                        <Commands>
                            <ext:GridCommand Icon="NoteEdit" CommandName="Edit">
                                <ToolTip Text="Edit" />
                            </ext:GridCommand>
                        </Commands>
                    </ext:CommandColumn>
			    </Columns>
            </ColumnModel>
            <LoadMask ShowMask="true" />
            <SaveMask ShowMask="true" />
            <BottomBar>
                <ext:PagingToolbar 
                    runat="server" 
                    PageSize="5" 
                    DisplayInfo="true"
                    DisplayMsg="Displaying employees {0} - {1} of {2}"
                    EmptyMsg="No employees to display"
                    />
            </BottomBar>
            <Listeners>
                <Command Handler="CompanyX.edit(rowIndex);" />
            </Listeners>           
        </ext:GridPanel>
        
        <uc1:WindowEditor ID="WindowEditor1" runat="server" />
    </form>
</body>
</html>
