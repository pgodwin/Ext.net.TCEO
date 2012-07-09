<%@ Page Language="C#" %>

<%@ Import Namespace="System.Collections.Generic"%>
<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        List<object> data = new List<object>();
        
        for (int i = 0; i < 10; i++)
        {
            data.Add(new{Name="Rec "+i, Column1=i.ToString(), Column2=i.ToString()});
        }

        this.Store1.DataSource = data;
        this.Store1.DataBind();
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Drag and Drop from GridPanel to GridPanel with Custom Drag Text - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript">
        //---Commnon function for drop zones
        var onContainerOver = function (dz, grid, dd, e, data) {
            return dd.grid !== grid ? dz.dropAllowed : dz.dropNotAllowed;
        };
        
        var onContainerDrop = function (grid, dd, e, data) {
            if (dd.grid !== grid) {                
                Ext.each(data.selections, function (r) {
                    dd.grid.store.remove(r);
                });
                grid.store.add(data.selections);
                return true;
            } else {
                return false;
            }
        };
        
        //---grid drag and rop custom text ------------------
        var getDragDropText = function () {
            var buf = [];
            
            buf.push("<ul>");
            
            Ext.each(this.getSelectionModel().getSelections(), function (record) {
                buf.push("<li>"+record.data.Name+"</li>");
            });
            
            buf.push("</ul>");
            
            return buf.join("");
        };
        
        var getRepairXY = function (e, dd){
	        if ( this.dragData.selections.length  > 0 ){
	             var foundItem = dd.grid.store.find('Name', this.dragData.selections[0].data.Name);
	             var myRow = dd.grid.getView().getRow(foundItem);
	             this.invalidRow = myRow;
	             var xy = Ext.fly(myRow).getXY();
	             return xy;
	        }
	        return false;
        };
        
        var setDD = function (){
            this.getView().dragZone.getRepairXY = getRepairXY;
        };
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>Drag and Drop from GridPanel to GridPanel with Custom Drag Text</h1>
        
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
                            StoreID="Store1"
                            DDGroup="GridDDGroup"
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
                            <GetDragDropText Fn="getDragDropText" />
                            <Listeners>
                                <Render Fn="setDD" />
                            </Listeners>
                        </ext:GridPanel>
                    </West>
                    
                    <Center MarginsSummary="5 5 5 0">
                        <ext:GridPanel 
                            ID="GridPanel2" 
                            runat="server" 
                            StoreID="Store2"
                            DDGroup="GridDDGroup"
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
                            <GetDragDropText Fn="getDragDropText" />
                            <Listeners>
                                <Render Fn="setDD" />
                            </Listeners>
                        </ext:GridPanel>
                    </Center>
                </ext:BorderLayout>
            </Items>
            
            <BottomBar>
                <ext:Toolbar runat="server">
                    <Items>
                        <ext:ToolbarFill runat="server" />
                        <ext:Button runat="server" Text="Reset both grids">
                            <Listeners>
                                <Click Handler="Store1.loadData(Store1.proxy.data);Store2.removeAll();" />
                            </Listeners>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </BottomBar>
        </ext:Panel> 

        <ext:DropZone runat="server" Target="={GridPanel1.view.scroller.dom}" Group="GridDDGroup" ContainerScroll="true">
            <OnContainerDrop Handler="return onContainerDrop(GridPanel1, source, e, data);" />
            <OnContainerOver Handler="return onContainerOver(this, GridPanel1, source, e, data);" />
        </ext:DropZone>
        
        <ext:DropZone runat="server" Target="={GridPanel2.view.scroller.dom}" Group="GridDDGroup" ContainerScroll="true">
            <OnContainerDrop Handler="return onContainerDrop(GridPanel2, source, e, data);" />
            <OnContainerOver Handler="return onContainerOver(this, GridPanel2, source, e, data);" />
        </ext:DropZone>
    </form>    
</body>
</html>
