<%@ Page Language="C#" %>

<%@ Import Namespace="System.Collections.Generic" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    public class Company
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Change { get; set; }
        public double PctChange { get; set; }
        public DateTime LastChange { get; set; }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            this.BindData();
        }
    }

    private void BindData()
    {
        this.GridPanel1.Store.Primary.DataSource = this.GetData();
        this.GridPanel1.Store.Primary.DataBind();
    }

    private List<Company> GetData()
    {
        return new List<Company> 
        {
            new Company { ID = 1, Name = "3m Co", Price = 71.72, Change = 0.02, PctChange = 0.03, LastChange = DateTime.Now },
            new Company { ID = 2, Name = "Alcoa Inc", Price = 29.01, Change = 0.42, PctChange = 1.47, LastChange = DateTime.Now },
            new Company { ID = 3, Name = "Altria Group Inc", Price = 83.81, Change = 0.28, PctChange = 0.34, LastChange = DateTime.Now },
            new Company { ID = 4, Name = "American Express Company", Price = 52.55, Change = 0.01, PctChange = 0.02, LastChange = DateTime.Now },
            new Company { ID = 5, Name = "American International Group, Inc.", Price = 64.13, Change = 0.31, PctChange = 0.49, LastChange = DateTime.Now },
            new Company { ID = 6, Name = "AT&T Inc.", Price = 31.61, Change = -0.48, PctChange = -1.54, LastChange = DateTime.Now },
            new Company { ID = 7, Name = "Boeing Co.", Price = 75.43, Change = 0.53, PctChange = 0.71, LastChange = DateTime.Now },
            new Company { ID = 8, Name = "Caterpillar Inc.", Price = 67.27, Change = 0.92, PctChange = 1.39, LastChange = DateTime.Now },
            new Company { ID = 9, Name = "Citigroup, Inc.", Price = 49.37, Change = 0.02, PctChange = 0.04, LastChange = DateTime.Now },
            new Company { ID = 10, Name = "E.I. du Pont de Nemours and Company", Price = 40.48, Change = 0.51, PctChange = 1.28, LastChange = DateTime.Now },
            new Company { ID = 11, Name = "Exxon Mobil Corp", Price = 68.1, Change = -0.43, PctChange = -0.64, LastChange = DateTime.Now },
            new Company { ID = 12, Name = "General Electric Company", Price = 34.14, Change = -0.08, PctChange = -0.23, LastChange = DateTime.Now },
            new Company { ID = 13, Name = "General Motors Corporation", Price = 30.27, Change = 1.09, PctChange = 3.74, LastChange = DateTime.Now },
            new Company { ID = 14, Name = "Hewlett-Packard Co.", Price = 36.53, Change = -0.03, PctChange = -0.08, LastChange = DateTime.Now },
            new Company { ID = 15, Name = "Honeywell Intl Inc", Price = 38.77, Change = 0.05, PctChange = 0.13, LastChange = DateTime.Now },
            new Company { ID = 16, Name = "Intel Corporation", Price = 19.88, Change = 0.31, PctChange = 1.58, LastChange = DateTime.Now },
            new Company { ID = 17, Name = "International Business Machines", Price = 81.41, Change = 0.44, PctChange = 0.54, LastChange = DateTime.Now },
            new Company { ID = 18, Name = "Johnson & Johnson", Price = 64.72, Change = 0.06, PctChange = 0.09, LastChange = DateTime.Now },
            new Company { ID = 19, Name = "JP Morgan & Chase & Co", Price = 45.73, Change = 0.07, PctChange = 0.15, LastChange = DateTime.Now },
            new Company { ID = 20, Name = "McDonald\"s Corporation", Price = 36.76, Change = 0.86, PctChange = 2.40, LastChange = DateTime.Now },
            new Company { ID = 21, Name = "Merck & Co., Inc.", Price = 40.96, Change = 0.41, PctChange = 1.01, LastChange = DateTime.Now },
            new Company { ID = 22, Name = "Microsoft Corporation", Price = 25.84, Change = 0.14, PctChange = 0.54, LastChange = DateTime.Now },
            new Company { ID = 23, Name = "Pfizer Inc", Price = 27.96, Change = 0.4, PctChange = 1.45, LastChange = DateTime.Now },
            new Company { ID = 24, Name = "The Coca-Cola Company", Price = 45.07, Change = 0.26, PctChange = 0.58, LastChange = DateTime.Now },
            new Company { ID = 25, Name = "The Home Depot, Inc.", Price = 34.64, Change = 0.35, PctChange = 1.02, LastChange = DateTime.Now },
            new Company { ID = 26, Name = "The Procter & Gamble Company", Price = 61.91, Change = 0.01, PctChange = 0.02, LastChange = DateTime.Now },
            new Company { ID = 27, Name = "United Technologies Corporation", Price = 63.26, Change = 0.55, PctChange = 0.88, LastChange = DateTime.Now },
            new Company { ID = 28, Name = "Verizon Communications", Price = 35.57, Change = 0.39, PctChange = 1.11, LastChange = DateTime.Now },
            new Company { ID = 29, Name = "Wal-Mart Stores, Inc.", Price = 45.45, Change = 0.73, PctChange = 1.63, LastChange = DateTime.Now }
        };
    }

    [DirectMethod(Namespace = "CompanyX")]
    public void AfterEdit(int id, string field, string oldValue, string newValue, object customer)
    {
        string message = "<b>Property:</b> {0}<br /><b>Field:</b> {1}<br /><b>Old Value:</b> {2}<br /><b>New Value:</b> {3}";

        // Send Message...
        X.Msg.Notify("Edit Record #" + id.ToString(), string.Format(message, id, field, oldValue, newValue)).Show();

        this.GridPanel1.Store.Primary.CommitChanges();
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
        
        var startEditing = function (e) {
            if (e.getKey() === e.ENTER) {
                var grid = GridPanel1,
                    record = grid.getSelectionModel().getSelected(),
                    index = grid.store.indexOf(record);
                    
                grid.startEditing(index, 1);
            }
        };
        
        var afterEdit = function (e) {
            /*
            Properties of 'e' include:
                e.grid - This grid
                e.record - The record being edited
                e.field - The field name being edited
                e.value - The value being set
                e.originalValue - The original value for the field, before the edit.
                e.row - The grid row index
                e.column - The grid column index
            */
            
            // Call DirectMethod
            CompanyX.AfterEdit(e.record.data.ID, e.field, e.originalValue, e.value, e.record.data);
        };
    </script>
</head>
<body>
    <ext:ResourceManager runat="server" RemoveViewState="true" IDMode="Explicit" />
    
    <h1>Editable GridPanel With Save To [DirectMethod]</h1>
    
    <ext:GridPanel 
        ID="GridPanel1"
        runat="server" 
        Title="Editable GridPanel" 
        StripeRows="true"
        TrackMouseOver="true"
        Width="600" 
        Height="350"
        AutoExpandColumn="Name">
        <Store>
            <ext:Store runat="server">
                <Reader>
                    <ext:JsonReader IDProperty="ID">
                        <Fields>
                            <ext:RecordField Name="ID" Type="Int" />
                            <ext:RecordField Name="Name" />
                            <ext:RecordField Name="Price" Type="Float" />
                            <ext:RecordField Name="Change" Type="Float" />
                            <ext:RecordField Name="PctChange" Type="Float" />
                            <ext:RecordField Name="LastChange" Type="Date" />
                        </Fields>
                    </ext:JsonReader>
                </Reader>
            </ext:Store>
        </Store>
        <Listeners>
            <KeyDown Fn="startEditing" />
            <AfterEdit Fn="afterEdit" />
        </Listeners>
        <ColumnModel runat="server">
            <Columns>
                <ext:Column Header="ID" DataIndex="ID" Width="35" />
                <ext:Column ColumnID="Name" Header="Name" DataIndex="Name">
                    <Editor>
                        <ext:TextField runat="server" />
                    </Editor>
                </ext:Column>
                <ext:Column Header="Price" DataIndex="Price">
                    <Renderer Format="UsMoney" />
                    <Editor>
                        <ext:TextField runat="server" />
                    </Editor>
                </ext:Column>
                <ext:Column Header="Change" DataIndex="Change">
                    <Renderer Fn="change" />
                    <Editor>
                        <ext:TextField runat="server" />
                    </Editor>
                </ext:Column>
                <ext:Column Header="Change" DataIndex="PctChange">
                    <Renderer Fn="pctChange" />
                    <Editor>
                        <ext:TextField runat="server" />
                    </Editor>
                </ext:Column>
                <ext:DateColumn Header="Last Updated" DataIndex="LastChange" Format="yyyy-MM-dd">
                    <Editor>
                        <ext:DateField runat="server" />
                    </Editor>
                </ext:DateColumn>
            </Columns>
        </ColumnModel>
        <SelectionModel>
            <ext:RowSelectionModel runat="server" SingleSelect="true" />
        </SelectionModel>
    </ext:GridPanel>          
</body>
</html>
