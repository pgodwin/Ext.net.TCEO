<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            var store = this.GridPanel1.GetStore();
            
            store.DataSource = this.Data;
            store.DataBind();
        }
    }

    private object[] Data
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
    <title>Mouse Sensor Distance - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />    

    <ext:ResourcePlaceHolder runat="server" />

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
    <ext:ResourceManager runat="server" />
    
    <h1>Mouse Sensor Distance</h1>
    
    <ext:Viewport runat="server" Layout="fit">
         <Items>
            <ext:GridPanel 
                ID="GridPanel1"
                runat="server" 
                StripeRows="true"
                Title="Move cursor to the bottom right window" 
                TrackMouseOver="true"        
                AutoExpandColumn="company">
                <Store>
                    <ext:Store runat="server">
                        <Reader>
                            <ext:ArrayReader>
                                <Fields>
                                    <ext:RecordField Name="company" />
                                    <ext:RecordField Name="price" Type="Float" />
                                    <ext:RecordField Name="change" Type="Float" />
                                    <ext:RecordField Name="pctChange" Type="Float" />
                                    <ext:RecordField Name="lastChange" Type="Date" DateFormat="M/d hh:mmtt" />
                                </Fields>
                            </ext:ArrayReader>
                        </Reader>
                    </ext:Store>
                </Store>
                <ColumnModel runat="server">
                    <Columns>
                        <ext:Column ColumnID="Company" Header="Company" DataIndex="company" />
                        <ext:Column Header="Price" DataIndex="price">                  
                            <Renderer Format="UsMoney" />
                        </ext:Column>
                        <ext:Column ColumnID="Change" Header="Change" DataIndex="change">
                            <Renderer Fn="change" />
                        </ext:Column>
                        <ext:Column Header="Change" DataIndex="pctChange">
                            <Renderer Fn="pctChange" />
                        </ext:Column>
                        <ext:DateColumn Header="Last Updated" DataIndex="lastChange" />
                    </Columns>
                </ColumnModel>
                <SelectionModel>
                    <ext:RowSelectionModel runat="server" SingleSelect="true">
                        <Listeners>
                            <RowSelect Handler="#{FormPanel1}.getForm().loadRecord(record);" />
                        </Listeners>
                    </ext:RowSelectionModel>
                </SelectionModel>
            </ext:GridPanel>          
        </Items>
    </ext:Viewport>
    
    <ext:Window 
        runat="server" 
        Title="Record" 
        Width="300" 
        Height="170"
        Layout="Fit"
        Hidden="false"        
        Closable="false"
        Shadow="None">
        <Items>
            <ext:FormPanel 
                ID="FormPanel1"
                runat="server" 
                Border="false" 
                DefaultAnchor="100%" 
                Padding="10" 
                ReadOnly="true">
                <Items>
                    <ext:TextField runat="server" DataIndex="company" FieldLabel="Company" />
                    <ext:NumberField runat="server" DataIndex="price" FieldLabel="Price" />
                    <ext:NumberField runat="server" DataIndex="change" FieldLabel="Change" />
                    <ext:NumberField runat="server" DataIndex="pctChange" FieldLabel="Change" />
                    <ext:DateField runat="server" DataIndex="lastChange" FieldLabel="Last Updated" />
                </Items>
            </ext:FormPanel>
        </Items>
        <Listeners>
            <Show Handler="this.el.alignTo(document, 'br-br', [-20,-20]);" />
        </Listeners>
        <Plugins>
            <ext:MouseDistanceSensor runat="server" MinOpacity="0.3" />
        </Plugins>
    </ext:Window>
</body>
</html>
