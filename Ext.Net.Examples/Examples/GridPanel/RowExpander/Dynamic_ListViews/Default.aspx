<%@ Page Language="C#" %>
<%@ Import Namespace="System.Collections.Generic"%>
<%@ Import Namespace="ListView=Ext.Net.ListView"%>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

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
        ResourceManager1.AddScript("removeFromCache({0});", JSON.Serialize(id));
    }

    private void AddToCache(string id)
    {
        ResourceManager1.AddScript("addToCache({0});", JSON.Serialize(id));
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

        ListView list = new ListView {
            ID = "ListViewRow_" + id,
            MultiSelect = true,
            StoreID = "{raw}StoreRow_" + id,
            Height = 200
        };

        list.Columns.AddRange(new ListViewColumn[] { 
            new ListViewColumn {
                Header = "Products's Name",
                DataIndex = "Name"
            }
        });

        this.RemoveFromCache(list.ID);
        list.Render("row-" + id, RenderMode.RenderTo);
        this.AddToCache(list.ID);
    }
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RowExpander with ListView - Ext.NET Examples</title>
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
        
        var removeFromCache = function(c){             
            var c = window[c];
            window.lookup.remove(c);   
            if (c){
                c.destroy();                
            }       
        }
        
        var addToCache = function(c){
            window.lookup.push(window[c]);      
        }
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        
        <h1>Row Expander Plugin with ListView</h1>
        <p>The caching is absent, ListView control renders on each expand</p>
        
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
            TrackMouseOver="true"
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
                <ext:GridView ID="GridView1" runat="server" ForceFit="true">
                    <Listeners>
                        <BeforeRefresh Fn="clean" />
                    </Listeners>
                </ext:GridView>
            </View>
            <SelectionModel>
                <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" />
            </SelectionModel>
            <Plugins>
                <ext:RowExpander ID="RowExpander1" runat="server">
                     <Template runat="server">
                        <Html>
							<div id="row-{ID}" style="background-color:White;"></div>
						</Html>
                    </Template>
                    
                    <DirectEvents>
                        <BeforeExpand OnEvent="BeforeExpand">
                            <EventMask ShowMask="true" Target="CustomTarget" CustomTarget="={GridPanel1.body}" />
                            <ExtraParams>
                                <ext:Parameter Name="id" Value="record.id" Mode="Raw" />
                            </ExtraParams>
                        </BeforeExpand>
                    </DirectEvents>
                </ext:RowExpander>
            </Plugins>
        </ext:GridPanel>
    </form>
</body>
</html>