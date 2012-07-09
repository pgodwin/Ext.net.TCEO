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
        // Generic function to add records.
		var addRow = function (store, record, ddSource) {
			// Search for duplicates
			var foundItem = store.findExact('Name', record.data.Name);
			
			// if not found
			if (foundItem  == -1) {
				//Remove Record from the source
				ddSource.grid.store.remove(record);
				
				store.add(record);

				// Call a sort dynamically
				store.sort('Name', 'ASC');				
			}
		};
        
        var notifyDrop1 = function (ddSource, e, data) {
			// Loop through the selections
			Ext.each(ddSource.dragData.selections, function (record) {
			    addRow(Store1, record, ddSource);
			});
			
			return true;
		};
		
		var notifyDrop2 = function (ddSource, e, data) {
			// Loop through the selections
			Ext.each(ddSource.dragData.selections, function (record) {
			    addRow(Store2, record, ddSource);
			});
			
			return true;
		};
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>Drag and Drop from GridPanel to GridPanel</h1>
        
        <p>This example shows how to setup two way drag and drop from one GridPanel to another.</p>    
        
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
        
        <ext:Store ID="Store2" runat="server">
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
                            DDGroup="secondGridDDGroup"
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
                                <ext:RowSelectionModel runat="server" />
                            </SelectionModel>
                        </ext:GridPanel>
                    </West>
                    
                    <Center MarginsSummary="5 5 5 0">
                        <ext:GridPanel 
                            ID="GridPanel2" 
                            runat="server" 
                            DDGroup="firstGridDDGroup"
                            StoreID="Store2"
                            EnableDragDrop="true"
                            StripeRows="true"
                            AutoExpandColumn="Name"
                            Width="325"
                            Title="Right">
                            <ColumnModel>
                                <Columns>
                                    <ext:Column ColumnID="Name" Header="Record Name" Width="160" DataIndex="Name" />
                                    <ext:Column Header="Column 1" Width="60" DataIndex="Column1" />
                                    <ext:Column Header="Column 2" Width="60" DataIndex="Column2" />
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:RowSelectionModel runat="server" />
                            </SelectionModel>
                        </ext:GridPanel>
                    </Center>
                </ext:BorderLayout>
            </Items>
            
            <BottomBar>
                <ext:Toolbar runat="server">
                    <Items>
                        <ext:ToolbarFill runat="server" />
                        <ext:Button runat="server" Text="Reset">
                            <Listeners>
                                <Click Handler="Store1.loadData(Store1.proxy.data); Store2.removeAll();" />
                            </Listeners>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </BottomBar>
        </ext:Panel> 
        
        <ext:DropTarget runat="server" Target="={GridPanel1.view.scroller.dom}" Group="firstGridDDGroup">
            <NotifyDrop Fn="notifyDrop1" />
        </ext:DropTarget>       
        
        <ext:DropTarget runat="server" Target="={GridPanel2.view.scroller.dom}" Group="secondGridDDGroup">
            <NotifyDrop Fn="notifyDrop2" />
        </ext:DropTarget> 
        
    </form>    
</body>
</html>
