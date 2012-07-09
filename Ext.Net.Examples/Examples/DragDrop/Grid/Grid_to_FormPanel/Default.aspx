<%@ Page Language="C#" %>

<%@ Import Namespace="System.Collections.Generic"%>
<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

 <script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        List<object> data = new List<object>();
        
        for (int i = 0; i < 10; i++)
        {
            data.Add(new
            {
                Name = "Rec " + i,
                Column1 = i.ToString(),
                Column2 = i.ToString()
            });
        }

        this.Store1.DataSource = data;
        this.Store1.DataBind();
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Drag and Drop from GridPanel to GridPanel - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript">
        var notifyEnter = function (ddSource, e, data) {
			FormPanel1.body.stopFx();
			FormPanel1.body.highlight();
		};
		
		var notifyDrop = function (ddSource, e, data){
			var selectedRecord = ddSource.dragData.selections[0];
			FormPanel1.getForm().loadRecord(selectedRecord);
			
			// Delete record from the grid.  not really required.
    		ddSource.grid.store.remove(selectedRecord);
			return(true);
		};
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>Drag and Drop from a Data Grid to a Form Panel</h1>
        
        <p>This example shows how to setup a one way drag and drop from a grid to an instance of a FormPanel.</p>    
        
        <ext:Store ID="Store1" runat="server">
            <Reader>
                <ext:JsonReader>
                    <Fields>
                        <ext:RecordField Name="Name" />
                        <ext:RecordField Name="Column1" />
                        <ext:RecordField Name="Column2" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        
        <ext:Panel runat="server" Width="650" Height="300">
            <Items>
                <ext:BorderLayout runat="server">
                    <West MarginsSummary="5 5 5 5">
                        <ext:GridPanel 
                            ID="GridPanel1" 
                            runat="server" 
                            DDGroup="gridDDGroup"
                            StoreID="Store1"
                            EnableDragDrop="true"
                            StripeRows="true"
                            AutoExpandColumn="Name"
                            Width="325"
                            Title="Left">
                            <ColumnModel>
                                <Columns>
                                    <ext:Column ColumnID="Name" Header="Record Name" Width="160" DataIndex="Name" />
                                    <ext:Column Header="Column 1" Width="60" DataIndex="Column1" />
                                    <ext:Column Header="Column 2" Width="60" DataIndex="Column2" />
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:RowSelectionModel runat="server" SingleSelect="true" />
                            </SelectionModel>
                        </ext:GridPanel>
                    </West>
                    
                    <Center MarginsSummary="5 5 5 0">
                        <ext:FormPanel 
                            ID="FormPanel1" 
                            runat="server"
                            Title="Generic Form Panel"
                            BodyStyle="background-color: #DFE8F6"
                            Padding="10"
                            LabelWidth="100">
                            <Items>
                                <ext:TextField runat="server" FieldLabel="Record Name" DataIndex="Name" />
                                <ext:TextField runat="server" FieldLabel="Column 1" DataIndex="Column1" />
                                <ext:TextField runat="server" FieldLabel="Column 2" DataIndex="Column2" />
                            </Items>
                        </ext:FormPanel>
                    </Center>
                </ext:BorderLayout>
            </Items>
            
            <BottomBar>
                <ext:Toolbar runat="server">
                    <Items>
                        <ext:ToolbarFill runat="server" />
                        <ext:Button runat="server" Text="Reset">
                            <Listeners>
                                <Click Handler="Store1.loadData(Store1.proxy.data); FormPanel1.getForm().reset();" />
                            </Listeners>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </BottomBar>
        </ext:Panel> 
        
        <ext:DropTarget runat="server" Target="={FormPanel1.body.dom}" Group="gridDDGroup">
            <NotifyEnter Fn="notifyEnter" /> 
            <NotifyDrop Fn="notifyDrop" />
        </ext:DropTarget>       
    </form>
</body>
</html>
