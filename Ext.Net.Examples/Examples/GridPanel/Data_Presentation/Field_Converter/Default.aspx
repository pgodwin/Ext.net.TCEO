<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            this.Store1.DataSource = new object[]
            {
                new object[] { "3m Co", 71.72, 0.02, 0.03, "Y" },
                new object[] { "Alcoa Inc", 29.01, 0.42, 1.47, "Y" },
                new object[] { "Altria Group Inc", 83.81, 0.28, 0.34, "N" },
                new object[] { "Wal-Mart Stores, Inc.", 45.45, 0.73, 1.63, "N" }
            };

            this.Store1.DataBind();
        }
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Field Convert - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <ext:Store ID="Store1" runat="server">
            <Reader>
                <ext:ArrayReader>
                    <Fields>
                        <ext:RecordField Name="company" />
                        <ext:RecordField Name="price" Type="Float" />
                        <ext:RecordField Name="change" Type="Float" />
                        <ext:RecordField Name="pctChange" Type="Float" />
                        <ext:RecordField Name="active" Type="Boolean">
                            <Convert Handler="return value === 'Y';" />
                        </ext:RecordField>
                    </Fields>
                </ext:ArrayReader>
            </Reader>
        </ext:Store>
        
        <ext:GridPanel 
            ID="GridPanel1" 
            runat="server" 
            StoreID="Store1" 
            StripeRows="true"
            Title="Grid" 
            TrackMouseOver="true"
            Width="600" 
            Height="350"
            AutoExpandColumn="Company">
            <ColumnModel runat="server">
                <Columns>
                    <ext:Column ColumnID="Company" Header="Company" Width="160" DataIndex="company" />
                    <ext:Column Header="Price" Width="75" DataIndex="price" />
                    <ext:Column Header="Change" Width="75" DataIndex="change" />
                    <ext:Column Header="Change" Width="75" DataIndex="pctChange" />
                    <ext:CheckColumn Header="Active" Width="50" Sortable="true" DataIndex="active" />
                </Columns>
            </ColumnModel>         
        </ext:GridPanel>  
    </form>
</body>
</html>