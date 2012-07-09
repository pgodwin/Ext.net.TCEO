<%@ Page Language="C#" %>

<%@ Import Namespace="System.Collections.ObjectModel" %>
<%@ Import Namespace="System.Collections.Generic" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            this.Store1.DataSource = FiltersTestData.Data;
            this.Store1.DataBind();
        }
    }
    
    protected void SetFilter(object sender, DirectEventArgs e)
    {
        StringFilter sf = (StringFilter)GridFilters1.Filters[1];
        sf.SetValue("3m Co");
        sf.SetActive(true);
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GridPanel with Local Filtering, Sorting and Paging - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <ext:ResourceManager ID="ResourceManager1" runat="server" DirectEventUrl="default.aspx" />
    
    <h1>GridPanel with Local Filtering, Sorting and Paging</h1>
    
    <p>Please see column header menu for apllying filters</p>
    
    <ext:Store runat="server" ID="Store1">
        <Reader>
            <ext:JsonReader IDProperty="Id">
                <Fields>
                    <ext:RecordField Name="Id" Type="Int" />
                    <ext:RecordField Name="Company" Type="String" />
                    <ext:RecordField Name="Price" Type="Float" />
                    <ext:RecordField Name="Date" Type="Date" DateFormat="yyyy-MM-ddTHH:mm:ss" />
                    <ext:RecordField Name="Size" Type="String" />
                    <ext:RecordField Name="Visible" Type="Boolean" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <SortInfo Field="Company" Direction="ASC" />
    </ext:Store>
    
    <ext:Window 
        ID="Window1" 
        runat="server"         
        Width="700" 
        Height="400" 
        Closable="false"
        Collapsible="true"
        Title="Example" 
        Maximizable="true"
        Layout="Fit">
        <Items>
            <ext:GridPanel runat="server" ID="GridPanel1" Border="false" StoreID="Store1">
                <ColumnModel runat="server">
                    <Columns>
                        <ext:Column Header="Id" DataIndex="Id" />
                        <ext:Column Header="Company" DataIndex="Company" />
                        <ext:Column Header="Price" DataIndex="Price">
                            <Renderer Format="UsMoney" />
                        </ext:Column>
                        <ext:DateColumn Header="Date" DataIndex="Date" Align="Center" Format="yyyy-MM-dd" />
                        <ext:Column Header="Size" DataIndex="Size" />
                        <ext:Column Header="Visible" DataIndex="Visible" Align="Center">
                            <Renderer Handler="return (value) ? 'Yes':'No';" />
                        </ext:Column>
                    </Columns>
                </ColumnModel>
                <LoadMask ShowMask="true" />
                <Plugins>
                    <ext:GridFilters runat="server" ID="GridFilters1" Local="true">
                        <Filters>
                            <ext:NumericFilter DataIndex="Id" />
                            <ext:StringFilter DataIndex="Company" />
                            <ext:NumericFilter DataIndex="Price" />
                            <ext:DateFilter DataIndex="Date">
                                <DatePickerOptions runat="server" TodayText="Now" />
                            </ext:DateFilter>
                            <ext:ListFilter DataIndex="Size" Options="extra small,small,medium,large,extra large" />
                            <ext:BooleanFilter DataIndex="Visible" />
                        </Filters>
                    </ext:GridFilters>
                </Plugins>
                <BottomBar>
                    <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="10">
                        <Items>
                            <ext:ToolbarSeparator runat="server" />
                            <ext:Button runat="server" Text="Find '3m Co'">
                                <DirectEvents>
                                    <Click OnEvent="SetFilter" />
                                </DirectEvents>
                            </ext:Button>
                        </Items>
                    </ext:PagingToolbar>
                </BottomBar>                   
            </ext:GridPanel>
        </Items>
    </ext:Window>
</body>
</html>
