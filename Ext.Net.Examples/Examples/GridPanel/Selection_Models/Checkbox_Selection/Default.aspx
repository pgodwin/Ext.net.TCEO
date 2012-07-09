<%@ Page Language="C#" %>

<%@ Import Namespace="System.Collections.Generic" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            this.Store1.DataSource = new List<Company> 
            { 
                new Company(0, "3m Co", 71.72, 0.02, 0.03),
                new Company(1, "Alcoa Inc", 29.01, 0.42, 1.47),
                new Company(2, "Altria Group Inc", 83.81, 0.28, 0.34),
                new Company(3, "American Express Company", 52.55, 0.01, 0.02),
                new Company(4, "American International Group, Inc.", 64.13, 0.31, 0.49),
                new Company(5, "AT&T Inc.", 31.61, -0.48, -1.54),
                new Company(6, "Boeing Co.", 75.43, 0.53, 0.71),
                new Company(7, "Caterpillar Inc.", 67.27, 0.92, 1.39),
                new Company(8, "Citigroup, Inc.", 49.37, 0.02, 0.04),
                new Company(9, "E.I. du Pont de Nemours and Company", 40.48, 0.51, 1.28),
                new Company(10, "Exxon Mobil Corp", 68.1, -0.43, -0.64),
                new Company(11, "General Electric Company", 34.14, -0.08, -0.23),
                new Company(12, "General Motors Corporation", 30.27, 1.09, 3.74),
                new Company(13, "Hewlett-Packard Co.", 36.53, -0.03, -0.08),
                new Company(14, "Honeywell Intl Inc", 38.77, 0.05, 0.13),
                new Company(15, "Intel Corporation", 19.88, 0.31, 1.58),
                new Company(16, "International Business Machines", 81.41, 0.44, 0.54),
                new Company(17, "Johnson & Johnson", 64.72, 0.06, 0.09),
                new Company(18, "JP Morgan & Chase & Co", 45.73, 0.07, 0.15),
                new Company(19, "McDonald\"s Corporation", 36.76, 0.86, 2.40),
                new Company(20, "Merck & Co., Inc.", 40.96, 0.41, 1.01),
                new Company(21, "Microsoft Corporation", 25.84, 0.14, 0.54),
                new Company(22, "Pfizer Inc", 27.96, 0.4, 1.45),
                new Company(23, "The Coca-Cola Company", 45.07, 0.26, 0.58),
                new Company(24, "The Home Depot, Inc.", 34.64, 0.35, 1.02),
                new Company(25, "The Procter & Gamble Company", 61.91, 0.01, 0.02),
                new Company(26, "United Technologies Corporation", 63.26, 0.55, 0.88),
                new Company(27, "Verizon Communications", 35.57, 0.39, 1.11),
                new Company(28, "Wal-Mart Stores, Inc.", 45.45, 0.73, 1.63)
            };

            this.Store1.DataBind();

            if (!this.IsPostBack)
            {
                RowSelectionModel sm = this.GridPanel1.SelectionModel.Primary as RowSelectionModel;

                sm.SelectedRow = new SelectedRow(2);
               
                sm.SelectedRows.Add(new SelectedRow(2));
                sm.SelectedRows.Add(new SelectedRow("11"));
            }
        }
   }

    protected void Button2_Click(object sender, DirectEventArgs e)
    {
        StringBuilder result = new StringBuilder();
        
        result.Append("<b>Selected Rows</b></br /><ul>");
        RowSelectionModel sm = this.GridPanel1.SelectionModel.Primary as RowSelectionModel;

        foreach (SelectedRow row in sm.SelectedRows)
        {
            result.Append("<li>" + row.RecordID + "</li>");
        }

        result.Append("</ul>");
        this.Label1.Html = result.ToString();
    }

    public class Company
    {
        public Company(int id, string name, double price, double change, double pctChange)
        {
            this.ID = id;
            this.Name = name;
            this.Price = price;
            this.Change = change;
            this.PctChange = pctChange;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get;set; }
        public double Change { get;set; }
        public double PctChange { get;set; }
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GridPanel with Checkbox Selection Model - Ext.NET Examples</title>
    
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
        
        <h1>GridPanel with Checkbox Selection Model</h1>
        
        <ext:Store ID="Store1" runat="server">
            <Reader>
                <ext:JsonReader IDProperty="ID">
                    <Fields>
                        <ext:RecordField Name="ID" />
                        <ext:RecordField Name="Name" />
                        <ext:RecordField Name="Price" />
                        <ext:RecordField Name="Change" />
                        <ext:RecordField Name="PctChange" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        
        <ext:GridPanel 
            ID="GridPanel1" 
            runat="server" 
            StoreID="Store1"
            StripeRows="true"
            Title="Company List"
            AutoExpandColumn="Company" 
            Collapsible="true"
            Width="600"
            Height="350">
            <ColumnModel runat="server">
		        <Columns>
                    <ext:Column ColumnId="Company" Header="Company" Width="160" DataIndex="Name" Resizable="false" MenuDisabled="true" Fixed="true" />
                    <ext:Column Header="Price" Width="75" DataIndex="Price">
                        <Renderer Format="UsMoney" />
                    </ext:Column>
                    <ext:Column Header="Change" Width="75" DataIndex="Change">
                        <Renderer Fn="change" />
                    </ext:Column>
                    <ext:Column Header="Change" Width="75" DataIndex="PctChange">
                        <Renderer Fn="pctChange" />
                    </ext:Column>
		        </Columns>
            </ColumnModel>
            <BottomBar>
                <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="10" StoreID="Store1" DisplayInfo="false" />
            </BottomBar>
            <SelectionModel>
                <ext:CheckboxSelectionModel runat="server" />
            </SelectionModel>
            <Buttons>
                <ext:Button ID="Button2" runat="server" Text="Submit Selected Records">
                    <DirectEvents>
                        <Click OnEvent="Button2_Click">
                            <EventMask ShowMask="true" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
            </Buttons>
        </ext:GridPanel>
        
        <div style="width:590px; border:1px solid gray; padding:5px;">
            <ext:Label ID="Label1" runat="server" />
        </div>
    </form>
  </body>
</html>
    