<%@ Page Language="C#" %>

<%@ Import Namespace="Button=Ext.Net.Button" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            this.BindData();
        }
    }
    
    protected void AddColumn(object sender, DirectEventArgs e)
    {
        ((Button)sender).Disabled = true;

        RecordField field = new RecordField("pctChange", RecordFieldType.Float);
        
        //we need specify index because we use ArrayReader which parse data source by index
        this.Store1.AddField(field, 3);

        this.BindData();

        Column col = new Column();
        col.Header = "Change %";
        col.Width = 75;
        col.Sortable = true;
        col.DataIndex = "pctChange";
        col.Renderer.Fn = "pctChange";

        ComboBox cb = new ComboBox();
        cb.Items.Add(new Ext.Net.ListItem("1", "1"));
        cb.Items.Add(new Ext.Net.ListItem("2", "2"));
        cb.Items.Add(new Ext.Net.ListItem("3", "3"));
        this.Controls.Add(cb);

        col.Editor.Add(cb);

        this.GridPanel1.AddColumn(col);
    }

    protected void InsertColumn(object sender, DirectEventArgs e)
    {
        ((Button)sender).Disabled = true;

        DateColumn col = new DateColumn 
        {
            Header = "Last Updated",
            Width = 85,
            Sortable = true,
            DataIndex = "lastChange",
            Format = "M/d/yyyy"
        };

        this.GridPanel1.InsertColumn(1, col);
    }

    protected void Reconfigure(object sender, DirectEventArgs e)
    {
        ((Button)sender).Disabled = true;
        
        this.GridPanel1.ColumnModel.Columns.RemoveAt(1);
        this.GridPanel1.ColumnModel.Columns.RemoveAt(1);
        this.GridPanel1.Reconfigure();
    }

    private void BindData()
    {
        this.Store1.DataSource = this.data;
        this.Store1.DataBind();
    }
    
    private object[] data
    {
        get
        {
            return new object[]
            {
               new object[] { "3m Co", 71.72, 0.02, 0.03, "9/1 12:00am" },
               new object[] { "Alcoa Inc", 29.01, 0.42, 1.47, "9/1 12:00am" },
               new object[] { "Altria Group Inc", 83.81, 0.28, 0.34, "9/1 12:00am" },
               new object[] { "American Express Company", 52.55, 0.01, 0.02, "9/1 12:00am" },
               new object[] { "American International Group, Inc.", 64.13, 0.31, 0.49, "9/1 12:00am" },
               new object[] { "AT&T Inc.", 31.61, -0.48, -1.54, "9/1 12:00am" },
               new object[] { "Boeing Co.", 75.43, 0.53, 0.71, "9/1 12:00am" },
               new object[] { "Caterpillar Inc.", 67.27, 0.92, 1.39, "9/1 12:00am" },
               new object[] { "Citigroup, Inc.", 49.37, 0.02, 0.04, "9/1 12:00am" },
               new object[] { "E.I. du Pont de Nemours and Company", 40.48, 0.51, 1.28, "9/1 12:00am" },
               new object[] { "Exxon Mobil Corp", 68.1, -0.43, -0.64, "9/1 12:00am" },
               new object[] { "General Electric Company", 34.14, -0.08, -0.23, "9/1 12:00am" },
               new object[] { "General Motors Corporation", 30.27, 1.09, 3.74, "9/1 12:00am" },
               new object[] { "Hewlett-Packard Co.", 36.53, -0.03, -0.08, "9/1 12:00am" },
               new object[] { "Honeywell Intl Inc", 38.77, 0.05, 0.13, "9/1 12:00am" },
               new object[] { "Intel Corporation", 19.88, 0.31, 1.58, "9/1 12:00am" },
               new object[] { "International Business Machines", 81.41, 0.44, 0.54, "9/1 12:00am" },
               new object[] { "Johnson & Johnson", 64.72, 0.06, 0.09, "9/1 12:00am" },
               new object[] { "JP Morgan & Chase & Co", 45.73, 0.07, 0.15, "9/1 12:00am" },
               new object[] { "McDonald\"s Corporation", 36.76, 0.86, 2.40, "9/1 12:00am" },
               new object[] { "Merck & Co., Inc.", 40.96, 0.41, 1.01, "9/1 12:00am" },
               new object[] { "Microsoft Corporation", 25.84, 0.14, 0.54, "9/1 12:00am" },
               new object[] { "Pfizer Inc", 27.96, 0.4, 1.45, "9/1 12:00am" },
               new object[] { "The Coca-Cola Company", 45.07, 0.26, 0.58, "9/1 12:00am" },
               new object[] { "The Home Depot, Inc.", 34.64, 0.35, 1.02, "9/1 12:00am" },
               new object[] { "The Procter & Gamble Company", 61.91, 0.01, 0.02, "9/1 12:00am" },
               new object[] { "United Technologies Corporation", 63.26, 0.55, 0.88, "9/1 12:00am" },
               new object[] { "Verizon Communications", 35.57, 0.39, 1.11, "9/1 12:00am" },
               new object[] { "Wal-Mart Stores, Inc.", 45.45, 0.73, 1.63, "9/1 12:00am" }
            };
        }
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Simple Array Grid - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />    

    <script type="text/javascript">
        var template = '<span style="color:{0};">{1}</span>';

        var change = function (value) {
            return String.format(template, (value > 0) ? "green" : "red", value);
        };

        var pctChange = function (value) {
            return String.format(template, (value > 0) ? "green" : "red", value + "%");
        };
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>Modify ColumnModel during DirectEvent</h1>
        
        <ext:GridPanel 
            ID="GridPanel1" 
            runat="server" 
            StripeRows="true"
            Title="Array Grid" 
            TrackMouseOver="true"
            Width="600" 
            Height="350"
            AutoExpandColumn="Company">
            <Store>
                <ext:Store ID="Store1" runat="server">
                    <Reader>
                        <ext:ArrayReader>
                            <Fields>
                                <ext:RecordField Name="company" />
                                <ext:RecordField Name="price" Type="Float" />
                                <ext:RecordField Name="change" Type="Float" />                        
                                <ext:RecordField Name="lastChange" Type="Date" DateFormat="M/d hh:mmtt" />
                            </Fields>
                        </ext:ArrayReader>
                    </Reader>
                </ext:Store>
            </Store>
            <ColumnModel runat="server">
                <Columns>
                    <ext:Column ColumnID="Company" Header="Company" Width="160" DataIndex="company" />
                    <ext:Column Header="Price" Width="75" DataIndex="price">
                        <Renderer Format="UsMoney" />
                    </ext:Column>
                    <ext:Column Header="Change" Width="75" DataIndex="change">
                    </ext:Column>
                </Columns>
            </ColumnModel>
            <SelectionModel>
                <ext:RowSelectionModel runat="server" SingleSelect="true" />
            </SelectionModel>
            <BottomBar>
                <ext:Toolbar runat="server">
                    <Items>
                        <ext:ToolbarFill runat="server" />
                        <ext:Button runat="server" Text="Add Column">
                             <DirectEvents>
                                <Click OnEvent="AddColumn" Single="true" />
                             </DirectEvents>
                        </ext:Button>
                        <ext:Button runat="server" Text="Insert Column">
                             <DirectEvents>
                                <Click OnEvent="InsertColumn" Single="true" />
                             </DirectEvents>
                        </ext:Button>
                         <ext:Button runat="server" Text="Reconfigure">
                             <DirectEvents>
                                <Click OnEvent="Reconfigure" Single="true" />
                             </DirectEvents>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </BottomBar>
        </ext:GridPanel>  
    </form>
</body>
</html>