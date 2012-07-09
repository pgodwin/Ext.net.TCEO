<%@ Page Language="C#" %>
<%@ Import Namespace="System.Collections.Generic"%>
<%@ Import Namespace="ListView=Ext.Net.ListView"%>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (X.IsAjaxRequest)
        {
            //We do not need to DataBind on an DirectEvent
            return;
        }
        
        List<object> data = new List<object>();
        
        for (int i = 1; i <= 10; i++)
        {
            data.Add(new { ID = "S" + i, Name = "Supplier " + i});
        }
        
        this.Store1.DataSource = data;
        this.Store1.DataBind();
    }
    
    private void RemoveFromCache(string id)
    {
        X.Js.Call("removeFromCache", id);
    }

    private void AddToCache(string id)
    {
        X.Js.Call("addToCache", id);
    }

    protected void BeforeExpand(object sender, DirectEventArgs e)
    {
        string id = e.ExtraParams["id"];
        
        Store store = new Store { ID = "StoreRow_"+id };

        JsonReader reader = new JsonReader();
        reader.IDProperty = "ID";
        reader.Fields.Add("ID", "Name");
        store.Reader.Add(reader);

        List<object> data = new List<object>();
        
        for (int i = 1; i <= 10; i++)
        {
            data.Add(new { ID = "P"+i, Name = "Product " + i });
        }

        store.DataSource = data;

        this.RemoveFromCache(store.ID);
        store.Render();
        this.AddToCache(store.ID);
        
        GridPanel grid = new GridPanel{
             ID = "GridPanelRow_"+id,
             StoreID = "{raw}StoreRow_" + id,
             Height = 200
        };
        
        grid.ColumnModel.Columns.Add(new Column
                                         {
                                             Header = "Products's Name",
                                             DataIndex = "Name"
                                         });
        grid.ColumnModel.ID = "GridPanelRowCM_" + id;

        grid.View.Add(new Ext.Net.GridView { ID = "GridPanelRowView_" + id, ForceFit = true });

        //important
        X.Get("row-" + id).SwallowEvent(new string[] { "click", "mousedown", "mouseup", "dblclick"}, true);

        this.RemoveFromCache(grid.ID);
        grid.Render("row-" + id, RenderMode.RenderTo);
        this.AddToCache(grid.ID);
    }
    
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RowExpander with GridPanel - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <ext:ResourcePlaceHolder runat="server" Mode="Script" />
    
    <script type="text/javascript">
        window.lookup = [];
        
        var clean = function () {
            if (window.lookup.length > 0) {
                RowExpander1.collapseAll();
                
                Ext.each(window.lookup, function (control) {
                    if (control) {
                        control.destroy();
                    }
                });
                
                window.lookup = [];
            }            
        };

        var removeFromCache = function(c) {
            var c = window[c];
            window.lookup.remove(c);
            
            if (c) {
                c.destroy();
            }
        };

        var addToCache = function(c) {
            window.lookup.push(window[c]);
        };
        
        var rerenderNestedGrid = function(view, rowIndex, record){    
            var grid = window["GridPanelRow_"+record.id];
            if(grid && !grid.moved){
                var ce = Ext.get(grid.getPositionEl()), 
                    el = Ext.net.ResourceMgr.getAspForm() || Ext.getBody();                    
                    
                ce.addClass("x-hidden");
                
                el.dom.appendChild(ce.dom);
                grid.moved = true;
        
                view.on("rowupdated", function(){
                    if(!grid.moved){
                        return;
                    }
                    var row = view.getRow(rowIndex),              
                        body = Ext.DomQuery.selectNode(RowExpander1.rowBodySelector, row);                
                
                    Ext.fly("row-"+record.id).appendChild(ce.dom);
                    ce.removeClass("x-hidden");  
                    grid.moved = false;       
                    body.rendered = true;   
                    body.expanderRendered = true;        
                }, view, {single:true});
            }
        };
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>Row Expander Plugin with GridPanel</h1>
        
        <p>The caching is presented, GridPanel renders once only (until view refresh)</p>
        
        <ext:Store ID="Store1" runat="server">
            <Reader>
                <ext:JsonReader IDProperty="ID">
                    <Fields>
                        <ext:RecordField Name="ID" />
                        <ext:RecordField Name="Name" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        
        <ext:GridPanel 
            ID="GridPanel1" 
            runat="server" 
            StoreID="Store1" 
            TrackMouseOver="false"
            Title="Expander Rows with ListView" 
            Collapsible="true"
            AnimCollapse="true" 
            Icon="Table" 
            Width="600" 
            Height="600">
            <ColumnModel runat="server">
                <Columns>
                    <ext:Column Header="Supplier" DataIndex="Name" />
                </Columns>
            </ColumnModel>
            <View>
                <ext:GridView runat="server" ForceFit="true">
                    <Listeners>
                        <BeforeRefresh Fn="clean" />
                    </Listeners>
                </ext:GridView>
            </View>
            <SelectionModel>
                <ext:RowSelectionModel runat="server" />
            </SelectionModel>
            <Plugins>
                <ext:RowExpander ID="RowExpander1" runat="server" EnableCaching="true">
                    <Template runat="server">
                        <Html>
							<div id="row-{ID}" style="background-color:White;"></div>
						</Html>
                    </Template>
                    <DirectEvents>
                        <BeforeExpand 
                            OnEvent="BeforeExpand" 
                            Before="return !body.rendered;" 
                            Success="body.rendered=true;">
                            <EventMask ShowMask="true" Target="CustomTarget" CustomTarget="={GridPanel1.body}" />
                            <ExtraParams>
                                <ext:Parameter Name="id" Value="record.id" Mode="Raw" />
                            </ExtraParams>
                        </BeforeExpand>
                    </DirectEvents>
                </ext:RowExpander>
            </Plugins>
            <Listeners>
                <ViewReady Handler="this.view.on('beforerowupdate', rerenderNestedGrid);" />
            </Listeners>
        </ext:GridPanel>
    </form>
</body>
</html>