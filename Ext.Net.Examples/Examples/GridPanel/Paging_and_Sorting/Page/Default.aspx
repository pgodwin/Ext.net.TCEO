<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Store1_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        string tpl = "Start: {0}<br />Limit: {1}<br />Sort: {2}<br />Dir: {3}";

        this.Label1.Html = string.Format(tpl, e.Start, e.Limit, e.Sort, e.Dir);
        
        //this.Label1.Text = e.Sort + ":" + e.Dir;
        
        this.ObjectDataSource1.SelectParameters["start"].DefaultValue = e.Start.ToString();
        this.ObjectDataSource1.SelectParameters["limit"].DefaultValue = e.Limit.ToString();
        this.ObjectDataSource1.SelectParameters["sort"].DefaultValue = e.Sort;
        this.ObjectDataSource1.SelectParameters["dir"].DefaultValue = e.Dir.ToString();

        this.Store1.DataBind();
    }

    protected void ObjectDataSource1_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        (this.Store1.Proxy[0] as PageProxy).Total = (int)e.OutputParameters["count"];
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GridPanel with ObjectDataSource - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .x-grid3-td-fullName .x-grid3-cell-inner {
            font-family : tahoma, verdana;
            display     : block;
            font-weight : normal;
            font-style  : normal;
            color       : #385F95;
            white-space : normal;
        }
        
        .x-grid3-row-body p {
            margin : 5px 5px 10px 5px !important;
            width  : 99%;
            color  : Gray;
        }
    </style>

    <script type="text/javascript">
        var fullName = function (value, metadata, record, rowIndex, colIndex, store) {
            return "<b>" + record.data.LastName + " " + record.data.FirstName + "</b>";
        };
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <asp:ObjectDataSource 
            ID="ObjectDataSource1" 
            runat="server" 
            OnSelected="ObjectDataSource1_Selected"
            SelectMethod="GetEmployeesFilter" 
            TypeName="Ext.Net.Examples.Northwind.Employee">
            <SelectParameters>
                <asp:Parameter Name="start" Type="Int32" />
                <asp:Parameter Name="limit" Type="Int32" />
                <asp:Parameter Name="sort" />
                <asp:Parameter Name="dir" />
                <asp:Parameter Name="count" Direction="Output" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        
        <ext:GridPanel 
            runat="server" 
            ID="GridPanel1" 
            Title="Employees" 
            Frame="true"
            Height="300">
            <Store>
                <ext:Store 
                    ID="Store1" 
                    runat="server" 
                    RemoteSort="true" 
                    DataSourceID="ObjectDataSource1"
                    OnRefreshData="Store1_RefreshData">
                    <AutoLoadParams>
                        <ext:Parameter Name="start" Value="0" Mode="Raw" />
                        <ext:Parameter Name="limit" Value="3" Mode="Raw" />
                    </AutoLoadParams>
                    <Proxy>
                        <ext:PageProxy />
                    </Proxy>
                    <Reader>
                        <ext:JsonReader IDProperty="EmployeeID">
                            <Fields>
                                <ext:RecordField Name="FirstName" />
                                <ext:RecordField Name="LastName" />
                                <ext:RecordField Name="Title" />
                                <ext:RecordField Name="TitleOfCourtesy" />
                                <ext:RecordField Name="BirthDate" Type="Date" />
                                <ext:RecordField Name="HireDate" Type="Date" />
                                <ext:RecordField Name="Address" />
                                <ext:RecordField Name="City" />
                                <ext:RecordField Name="Region" />
                                <ext:RecordField Name="PostalCode" />
                                <ext:RecordField Name="Country" />
                                <ext:RecordField Name="HomePhone" />
                                <ext:RecordField Name="Extension" />
                                <ext:RecordField Name="Notes" />
                            </Fields>
                        </ext:JsonReader>
                    </Reader>
                </ext:Store>
            </Store>
            <ColumnModel runat="server">
                <Columns>
                    <ext:Column ColumnID="fullName" Header="Full Name" Width="150" DataIndex="LastName">
                        <Renderer Fn="fullName" />
                    </ext:Column>
                    <ext:Column DataIndex="Title" Header="Title" Width="150" />
                    <ext:Column DataIndex="TitleOfCourtesy" Header="Title Of Courtesy" Width="150" />
                    <ext:DateColumn DataIndex="BirthDate" Header="BirthDate" Width="110" Format="yyyy-MM-dd" />
                    <ext:DateColumn DataIndex="HireDate" Header="HireDate" Width="110" Format="yyyy-MM-dd" />
                    <ext:Column DataIndex="Address" Header="Address" Width="150" />
                    <ext:Column DataIndex="City" Header="City" Width="100" />
                    <ext:Column DataIndex="Region" Header="Region" Width="100" />
                    <ext:Column DataIndex="PostalCode" Header="PostalCode" Width="100" />
                    <ext:Column DataIndex="Country" Header="Country" Width="100" />
                    <ext:Column DataIndex="HomePhone" Header="HomePhone" Width="150" />
                    <ext:Column DataIndex="Extension" Header="Extension" Width="100" />
                </Columns>
            </ColumnModel>
            <View>
                <ext:GridView runat="server" EnableRowBody="true">
                    <GetRowClass Handler="rowParams.body = '<p>' + record.data.Notes + '</p>'; return 'x-grid3-row-expanded';" />
                </ext:GridView>
            </View>
            <SelectionModel>
                <ext:RowSelectionModel runat="server" />
            </SelectionModel>            
            <BottomBar>
                <ext:PagingToolbar 
                    runat="server" 
                    PageSize="3" 
                    DisplayInfo="true" 
                    DisplayMsg="Displaying employees {0} - {1} of {2}" 
                    EmptyMsg="No employees to display" 
                    />
            </BottomBar>
            <LoadMask ShowMask="true" />
        </ext:GridPanel>
        
        <ext:Label ID="Label1" runat="server" />
    </form>
</body>
</html>
