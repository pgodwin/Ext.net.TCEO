<%@ Page Language="C#" %>

<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Xml.Xsl" %>
<%@ Import Namespace="System.Xml" %>
<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="System.Data.SqlClient" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            this.Store1.DataSource = this.GetDataReader();
            this.Store1.DataBind();
        }
    }

    protected void Store1_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        this.Store1.DataSource = this.GetDataReader();
        this.Store1.DataBind();
    }
    
    private SqlDataReader GetDataReader()
    {
        SqlConnection myConnection;
        SqlCommand myCommand;
        SqlDataReader myDataReader;

        string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;
            
        myConnection = new SqlConnection(strConn);
        myConnection.Open();

        myCommand = new SqlCommand("SELECT * FROM Suppliers", myConnection);
        myDataReader = myCommand.ExecuteReader();

        return myDataReader;
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GridPanel using DataReader with Local Paging and Remote Reloading - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        var template = '<span style="color:{0};">{1}</span>';

        var change = function (value) {
            return String.format(template, (value > 0) ? "green" : "red", value);
        }

        var pctChange = function (value) {
            return String.format(template, (value > 0) ? "green" : "red", value + "%");
        }
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>GridPanel using DataReader with Local Paging and Remote Reloading</h1>
        
        <ext:Store 
            ID="Store1" 
            runat="server" 
            OnRefreshData="Store1_RefreshData">
            <Reader>
                <ext:JsonReader>
                    <Fields>
                        <ext:RecordField Name="SupplierID" />
                        <ext:RecordField Name="CompanyName" />
                        <ext:RecordField Name="ContactName" />
                        <ext:RecordField Name="ContactTitle" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        
        <ext:GridPanel 
            id="GridPanel1"
            runat="server" 
            StoreID="Store1" 
            Title="DataReader Grid" 
            Width="600" 
            Height="320"
            AutoExpandColumn="CompanyName">
            <ColumnModel runat="server">
                <Columns>
                    <ext:Column Header="Supplier ID" DataIndex="SupplierID" />
                    <ext:Column ColumnID="CompanyName" Header="Company Name" DataIndex="CompanyName" />
                    <ext:Column Header="Contact Name" DataIndex="ContactName" />
                    <ext:Column Header="Contact Title" DataIndex="ContactTitle" />
                </Columns>
            </ColumnModel>
            <SelectionModel>
                <ext:RowSelectionModel runat="server" />
            </SelectionModel>
            <LoadMask ShowMask="true" />
            <BottomBar>
                <ext:PagingToolbar runat="server" PageSize="10" StoreID="Store1" />
            </BottomBar>
        </ext:GridPanel>
    </form>
</body>
</html>
