<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Import Namespace="System.Linq" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            this.BindData(0);
        }
    }

    protected void AddRecords(object sender, StoreRefreshDataEventArgs e)
    {
        this.BindData(int.Parse(e.Parameters["count"] ?? "0"));
    }

    private void BindData(int count)
    {
        var store = this.GridPanel1.GetStore();
        var data = this.Data;

        store.DataSource = data.Skip(count).Take(5);
        store.DataBind();

        InfoLabel.Text = String.Format("Displaying {0} of {1}", Math.Min(count + 5, data.Count), data.Count);
        MoreButton.Disabled = (count + 5) >= data.Count;
    }

    private new System.Collections.Generic.List<object> Data
    {
        get
        {
            return new System.Collections.Generic.List<object>
            {
                new { company = "3m Co" },
                new { company = "Alcoa Inc"},
                new { company = "Altria Group Inc"},
                new { company = "American Express Company"},
                new { company = "American International Group, Inc."},
                new { company = "AT&T Inc."},
                new { company = "Boeing Co."},
                new { company = "Caterpillar Inc."},
                new { company = "Citigroup, Inc."},
                new { company = "E.I. du Pont de Nemours and Company"},
                new { company = "Exxon Mobil Corp"},
                new { company = "General Electric Company"},
                new { company = "General Motors Corporation"},
                new { company = "Hewlett-Packard Co."},
                new { company = "Honeywell Intl Inc"},
                new { company = "Intel Corporation"},
                new { company = "International Business Machines"},
                new { company = "Johnson & Johnson"},
                new { company = "JP Morgan & Chase & Co"},
                new { company = "McDonald\"s Corporation"},
                new { company = "Merck & Co., Inc."},
                new { company = "Microsoft Corporation"},
                new { company = "Pfizer Inc"},
                new { company = "The Coca-Cola Company"},
                new { company = "The Home Depot, Inc."},
                new { company = "The Procter & Gamble Company"},
                new { company = "United Technologies Corporation"},
                new { company = "Verizon Communications"},
                new { company = "Wal-Mart Stores, Inc."}
            };
        }
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add mode of Store - Ext.NET Examples</title>
    <ext:ResourcePlaceHolder runat="server" Mode="Script" />
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        
        <h1>Add mode of Store</h1>
        
        <ext:GridPanel ID="GridPanel1" runat="server" Title="Grid" Width="600" AutoExpandColumn="Company"
            AutoHeight="true">
            <Store>
                <ext:Store ID="Store1" runat="server" OnRefreshData="AddRecords" WarningOnDirty="false">
                    <Reader>
                        <ext:JsonReader>
                            <Fields>
                                <ext:RecordField Name="company" />
                            </Fields>
                        </ext:JsonReader>
                    </Reader>
                </ext:Store>
            </Store>
            <ColumnModel runat="server">
                <Columns>
                    <ext:RowNumbererColumn />
                    <ext:Column ColumnID="Company" Header="Company" Width="160" DataIndex="company" />
                </Columns>
            </ColumnModel>
            <LoadMask ShowMask="true" />
            <View>
                <ext:GridView runat="server" ScrollOffset="0" />
            </View>
            <BottomBar>
                <ext:Toolbar runat="server">
                    <Items>
                        <ext:Button ID="MoreButton" runat="server" Text="More" Icon="Add">
                            <Listeners>
                                <Click Handler="#{Store1}.reload({add:true, params : {count: #{Store1}.getCount()} });" />
                            </Listeners>
                        </ext:Button>
                        <ext:ToolbarFill runat="server" />
                        <ext:Label ID="InfoLabel" runat="server" />
                    </Items>
                </ext:Toolbar>
            </BottomBar>
        </ext:GridPanel>
    </form>
</body>
</html>
