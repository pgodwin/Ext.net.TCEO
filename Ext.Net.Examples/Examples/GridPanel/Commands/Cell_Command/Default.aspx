<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            this.Store1.DataSource = new object[]
            {
                new object[] { "3m Co", 71.72, 0.02, 0.03},
                new object[] { "Alcoa Inc", 29.01, 0.42, 1.47},
                new object[] { "Altria Group Inc", 83.81, 0.28, 0.34},
                new object[] { "American Express Company", 52.55, 0.01, 0.02},
                new object[] { "American International Group, Inc.", 64.13, 0.31, 0.49},
                new object[] { "AT&T Inc.", 31.61, -0.48, -1.54},
                new object[] { "Boeing Co.", 75.43, 0.53, 0.71},
                new object[] { "Caterpillar Inc.", 67.27, 0.92, 1.39},
                new object[] { "Citigroup, Inc.", 49.37, 0.02, 0.04},
                new object[] { "E.I. du Pont de Nemours and Company", 40.48, 0.51, 1.28}
            };

            this.Store1.DataBind();
        }
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Basic Row Command - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />    

    <script type="text/javascript">
        var template = '<span style="color:{0};">{1}</span>';

        var change = function (value) {
            return String.format(template, (value > 0) ? "green" : "red", value);
        };

        var pctChange = function (value) {
            return String.format(template, (value > 0) ? "green" : "red", value + "%");
        };

        var prepare = function (grid, command, record, row, col, value) {
            //debugger;

            if (value < 0 && command.command == "Dollar") {
                command.hidden = true;
                command.hideMode = "visibility";
            }
        };
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        
        <ext:Store ID="Store1" runat="server">
            <Reader>
                <ext:ArrayReader>
                    <Fields>
                        <ext:RecordField Name="company" />
                        <ext:RecordField Name="price" Type="Float" />
                        <ext:RecordField Name="change" Type="Float" />
                        <ext:RecordField Name="pctChange" Type="Float" />
                    </Fields>
                </ext:ArrayReader>
            </Reader>
        </ext:Store>
       
        <ext:GridPanel 
            ID="GridPanel1" 
            runat="server" 
            StoreID="Store1" 
            Title="Cell commands" 
            Width="700" 
            Height="300"
            AutoExpandColumn="Company">
            <ColumnModel runat="server">
                <Columns>
                    <ext:Column ColumnID="Company" Header="Company" Width="160" DataIndex="company">
                        <Commands>
                            <ext:ImageCommand CommandName="Edit" Icon="NoteEdit" Text="Edit">
                                <ToolTip Text="Edit" />
                            </ext:ImageCommand>
                        </Commands>                       
                    </ext:Column>
                    <ext:Column Header="Price" Width="100" DataIndex="price" Align="Right" RightCommandAlign="false">
                        <Renderer Format="UsMoney" />
                        <Commands>
                            <ext:ImageCommand CommandName="Dollar" Icon="MoneyDollar" />
                            <ext:ImageCommand CommandName="Euro" Icon="MoneyEuro" />
                        </Commands>
                    </ext:Column>
                    <ext:Column Header="Change" Width="100" DataIndex="change" Align="Right" RightCommandAlign="false">
                        <Renderer Fn="change" />
                        <Commands>
                            <ext:ImageCommand CommandName="Dollar" Icon="MoneyDollar" />
                            <ext:ImageCommand CommandName="Euro" Icon="MoneyEuro" />
                        </Commands>
                        <PrepareCommand Fn="prepare" />
                    </ext:Column>
                    <ext:Column Header="Change" Width="75" DataIndex="pctChange" Align="Right">
                        <Renderer Fn="pctChange" />
                        <Commands>
                            <ext:ImageCommand CommandName="Chart" Icon="ChartBar" Style="margin-left:5px !important;" />
                        </Commands>
                    </ext:Column>                            
                </Columns>
            </ColumnModel>
            <SelectionModel>
               <ext:RowSelectionModel runat="server">                    
               </ext:RowSelectionModel> 
            </SelectionModel>          
            <Listeners>
                <Command Handler="Ext.Msg.alert('Command', 'Command = '+ command + '<br/>'+ 'Column = ' + this.getColumnModel().getDataIndex(colIndex));" />
            </Listeners>
        </ext:GridPanel>  
    </form>
</body>
</html>