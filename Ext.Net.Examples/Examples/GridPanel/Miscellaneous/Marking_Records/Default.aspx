<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        this.GridPanel1.Store.Primary.DataSource = new object[]
        {
            new object[] { "Sample 1" },
            new object[] { "Sample 2" },
            new object[] { "Sample 3" },
            new object[] { "Sample 4" },
            new object[] { "Sample 5" },
            new object[] { "Sample 6" },
            new object[] { "Sample 7" },
            new object[] { "Sample 8" },
            new object[] { "Sample 9" },
            new object[] { "Sample 10" },
            new object[] { "Sample 11" },
            new object[] { "Sample 12" },
            new object[] { "Sample 13" },
            new object[] { "Sample 14" },
            new object[] { "Sample 15" }
        };

        this.GridPanel1.Store.Primary.DataBind();
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Marking Changed GridPanel - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />  
    
    <style type="text/css">
        .dirty-row {
	        background: #FFFDD8;
        }
        
        .new-row {
	        background: #c8ffc8;
        } 
    </style>
</head>
<body>    
    <form runat="server">
        <script type="text/javascript">
            var getRowClass = function (record) {
                if (record.newRecord) {
                    return "new-row";
                }
                
                if (record.dirty) {
                    return "dirty-row";
                }
            }

            var insertRecord = function () {
                var grid = <%= GridPanel1.ClientID %>;
                
                grid.insertRecord(0, {});
                grid.getView().focusRow(0);
                grid.startEditing(0, 0);
            }
        </script>  
        
        <ext:ResourceManager runat="server" />
        
        <h1>Marking Records</h1>
        
        <p>Demonstrates how to mark rows with custom colors. Edit any cell or insert new record.</p>
       
        <ext:GridPanel 
            ID="GridPanel1" 
            runat="server" 
            StripeRows="true" 
            ClicksToEdit="1"
            Title="Test Grid" 
            Width="600"  
            Height="350"
            AutoExpandColumn="TestCell">
            <Store>
                <ext:Store runat="server">
                    <Reader>
                        <ext:ArrayReader>
                            <Fields>
                                <ext:RecordField Name="TestCell" />                       
                            </Fields>
                        </ext:ArrayReader>
                    </Reader>
                </ext:Store>
            </Store>
            <ColumnModel runat="server">
                <Columns>
                    <ext:Column ColumnID="TestCell" Header="TestCell" DataIndex="TestCell">
                        <Editor>
                            <ext:TextField runat="server" />
                        </Editor>
                    </ext:Column>                    
                </Columns>
            </ColumnModel>
            <View>
                <ext:GridView runat="server">
                    <GetRowClass Fn="getRowClass" />                       
                </ext:GridView>
            </View>
            <Buttons>
                <ext:Button runat="server" Text="Insert record" Icon="Add">
                    <Listeners>
                        <Click Fn="insertRecord" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:GridPanel>  
    </form>
</body>
</html>