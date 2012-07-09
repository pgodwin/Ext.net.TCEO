<%@ Page Language="C#" %>

<%@ Import Namespace="Ext.Net.Examples"%>
<%@ Import Namespace="Ext.Net.Examples.Northwind" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void RowSelect(object sender, DirectEventArgs e)
    {
        string employeeID = e.ExtraParams["EmployeeID"];

        Employee empl = Employee.GetEmployee(int.Parse(employeeID));

        this.FormPanel1.SetValues(new {
            empl.EmployeeID,
            empl.FirstName,                          
            empl.LastName,
            empl.Title,
            ReportsTo = empl.ReportsTo.HasValue ? (Employee.GetEmployee(empl.ReportsTo.Value).LastName) : "",
            empl.HireDate,
            empl.Extension,
            empl.Address,
            empl.City,
            empl.PostalCode,
            empl.HomePhone,
            empl.TitleOfCourtesy,
            empl.BirthDate,
            empl.Region,
            empl.Country,
            empl.Notes
        });
    }

    protected void Store1_Refresh(object sender, StoreRefreshDataEventArgs e)
    {
        this.Store1.DataBind();
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GridPanel with Form Details - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <asp:LinqDataSource 
            ID="LinqDataSource1" 
            runat="server" 
            ContextTypeName="Ext.Net.Examples.Northwind.NorthwindDataContext"
            Select="new (EmployeeID, LastName, FirstName)" 
            TableName="Employees" 
            />
            
        <ext:Viewport runat="server" Layout="border">
            <Items>
                <ext:Panel 
                    runat="server" 
                    Region="North"
                    Margins="5 5 5 5"
                    Title="Description" 
                    Height="100" 
                    Padding="5"
                    Frame="true" 
                    Icon="Information">
                    <Content>
                        <b>GridPanel with Form Details</b>
                        <p>Click on any record with the GridPanel and the record details will be loaded into the Details Form.</p>
                    </Content>
                </ext:Panel>
                <ext:GridPanel 
                    runat="server" 
                    Title="Employees"
                    Margins="0 0 5 5"
                    Icon="UserSuit"
                    Region="Center"
                    AutoExpandColumn="LastName" 
                    Frame="true">
                    <Store>
                        <ext:Store 
                            ID="Store1" 
                            runat="server" 
                            DataSourceID="LinqDataSource1" 
                            OnRefreshData="Store1_Refresh">
                            <Reader>
                                <ext:JsonReader IDProperty="EmployeeID">
                                    <Fields>
                                        <ext:RecordField Name="LastName" />
                                        <ext:RecordField Name="FirstName" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <ColumnModel runat="server">
                        <Columns>
                            <ext:Column ColumnID="LastName" DataIndex="LastName" Header="Last Name" />
                            <ext:Column DataIndex="FirstName" Header="First Name" Width="150" />
                        </Columns>
                    </ColumnModel>
                    <SelectionModel>
                        <ext:RowSelectionModel runat="server" SingleSelect="true">
                            <DirectEvents>
                                <RowSelect OnEvent="RowSelect" Buffer="100">
                                    <EventMask ShowMask="true" Target="CustomTarget" CustomTarget="#{FormPanel1}" />
                                    <ExtraParams>
                                        <%-- or can use params[2].id as value --%>
                                        <ext:Parameter Name="EmployeeID" Value="this.getSelected().id" Mode="Raw" />
                                    </ExtraParams>
                                </RowSelect>
                            </DirectEvents>
                        </ext:RowSelectionModel>
                    </SelectionModel>
                    <BottomBar>
                        <ext:PagingToolbar runat="server" />
                    </BottomBar>
                    <LoadMask ShowMask="true" />
                </ext:GridPanel>
                <ext:FormPanel 
                    ID="FormPanel1" 
                    runat="server" 
                    Region="East"
                    Split="true"
                    Margins="0 5 5 5"
                    Frame="true" 
                    Title="Employee Details" 
                    Width="280"
                    Icon="User"
                    DefaultAnchor="100%">
                    <Items>
                        <ext:DisplayField runat="server" FieldLabel="Employee ID" DataIndex="EmployeeID" />
                        <ext:TextField runat="server" FieldLabel="First Name" DataIndex="FirstName" />
                        <ext:TextField runat="server" FieldLabel="Last Name" DataIndex="LastName" />
                        <ext:TextField runat="server" FieldLabel="Title" DataIndex="Title" />
                        <ext:TextField runat="server" FieldLabel="Reports to" DataIndex="ReportsTo" />
                        <ext:DateField runat="server" FieldLabel="Hire date" Format="yyyy-MM-dd" DataIndex="HireDate" />
                        <ext:TextField runat="server" FieldLabel="Extension" DataIndex="Extension" />
                        <ext:TextField runat="server" FieldLabel="Address" DataIndex="Address" />
                        <ext:TextField runat="server" FieldLabel="City" DataIndex="City" />
                        <ext:TextField runat="server" FieldLabel="Post Code" DataIndex="PostalCode" />
                        <ext:TextField runat="server" FieldLabel="Home Phone" DataIndex="HomePhone" />
                        <ext:TextField runat="server" FieldLabel="Title Of Courtesy" DataIndex="TitleOfCourtesy" />
                        <ext:DateField runat="server" FieldLabel="Birth date" Format="yyyy-MM-dd" DataIndex="BirthDate" />
                        <ext:TextField runat="server" FieldLabel="Region" DataIndex="Region" />
                        <ext:TextField runat="server" FieldLabel="Country" DataIndex="Country" />
                        <ext:TextArea runat="server" FieldLabel="Note" Height="50" DataIndex="Notes" />
                    </Items>
                </ext:FormPanel>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
