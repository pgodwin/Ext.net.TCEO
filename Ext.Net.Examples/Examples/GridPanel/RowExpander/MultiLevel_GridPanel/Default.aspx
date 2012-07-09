<%@ Page Language="C#" %>
<%@ Import Namespace="Ext.Net.Utilities"%>
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
        
        //Build first level
        this.BuildLevel(1, "r0", "g0");
    }

    [DirectMethod]
    public void BuildLevel(int level, string recId, string gridId)
    {
        var storeId = "L".ConcatWith(level, "_", recId, "_Store");
        var newGridId = "L".ConcatWith(level, "_", recId, "_Grid");
        
        // build store
        var store = new Store{ID = storeId};
        var reader = new JsonReader {IDProperty = "ID"};
        reader.Fields.Add("ID", "Name");
        reader.Fields.Add(new RecordField
                              {
                                  Name = "Level",
                                  Convert = {Handler = "return ".ConcatWith(level, ";")}
                              });
        store.Reader.Add(reader);
        store.CustomConfig.Add(new ConfigItem("level", level.ToString(), ParameterMode.Raw));

        // bind store
        var data = new List<object>();

        for (int i = 1; i <= 10; i++)
        {
            data.Add(new { ID = recId.ConcatWith("_R", i), Name = "Level".ConcatWith(level, ": Row " + i) });
        }
        
        //build grid
        var grid = new GridPanel
                             {
                                 ID = newGridId,
                                 Store = { 
                                    store
                                 },
                                 AutoHeight = true,
                                 HideHeaders = level != 1
                             };
        
        //build columns
        grid.ColumnModel.Columns.Add(new Column {DataIndex = "Name", Header = "Name"});
        grid.ColumnModel.ID = newGridId + "_CM";
        
        // build view
        var view = new Ext.Net.GridView
                                    {
                                        ID = newGridId + "_View",
                                        ForceFit = true
                                    };
        grid.View.Add(view);
        
        // build selection model
        var sm = new RowSelectionModel { ID = newGridId + "_SM" };
        grid.SelectionModel.Add(sm);
        
        // add expander for all levels except last (last level is 5)
        if (level < 5)
        {
            view.Listeners.BeforeRefresh.Fn = "clean";
            var re = new RowExpander
                                 {
                                     ID = newGridId + "_RE",
                                     EnableCaching = true,
                                     Template = { ID = newGridId + "_TPL", Html = "<div id=\"row_{ID}\" style=\"background-color:white;\"></div>" }
                                 };

            re.Listeners.BeforeExpand.Fn = "loadLevel";
            
            grid.Plugins.Add(re);
        }

        store.DataSource = data;
        store.DataBind();  
        
        if (level == 1)
        {
            grid.Title = "MultiLevel grid";
            grid.Width = 600;
            grid.Height = 600;
            grid.AutoHeight = false;            
            this.Form.Controls.Add(grid);
            
            grid.Plugins.Add(new PanelResizer());            
        }
        else
        {
            var renderEl = "row_" + recId;
            X.Get(renderEl).SwallowEvent(new string[] { "click", "mousedown", "mouseup", "dblclick" }, true);

            this.RemoveFromCache(newGridId, gridId);
            grid.Render(renderEl, RenderMode.RenderTo);
            this.AddToCache(newGridId, gridId);
        }  
    }
    
    private void RemoveFromCache(string id, string parentId)
    {
        ResourceManager1.AddScript("removeFromCache({0}, {1});", JSON.Serialize(id), JSON.Serialize(parentId));
    }

    private void AddToCache(string id, string parentId)
    {
        ResourceManager1.AddScript("addToCache({0}, {1});", JSON.Serialize(id), JSON.Serialize(parentId));
    }
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MultiLevel GridPanel - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <ext:ResourcePlaceHolder runat="server" Mode="Script" />
    
    <script type="text/javascript">
        window.lookup = {};
        
        var clean = function (view, isDestroy) {
            var controls = window.lookup[view.grid.id] || {},
                ids = [];            
            
            for(var c in controls){
                ids.push(controls[c].id || controls[c].storeId);
            }
            
            if (ids.length > 0){
                if (isDestroy !== true){
                    view.grid.getRowExpander().collapseAll();
                }
                
                for(var i=0; i<ids.length;i++){
                    removeFromCache(ids[i], view.grid.id);
                }
            }
        };
        
        var addToCache = function(c, parent){
            window.lookup[parent] = window.lookup[parent] || {};
            window.lookup[parent][c] = window[c];      
        }
        
        var removeFromCache = function(c, parent){             
            window.lookup[parent] = window.lookup[parent] || {};
            
            var ctrl = window.lookup[parent][c];
            delete window.lookup[parent][c];
            if (ctrl){
                if (ctrl.view){
                    clean(ctrl.view, true);
                }
                ctrl.destroy();                
            }       
        }
        
        var loadLevel = function(expander, record, body, row){
            if (body.rendered){
                return;
            }
            
            var recId = record.id,
                gridId = expander.grid.id,
                level = record.data.Level;
            
            mLevels.BuildLevel(level+1, recId, gridId, {
                eventMask: {
                    showMask: true,
                    tartget: "customtarget",
                    customTarget: expander.grid.body
                },
                
                success: function(){
                    body.rendered = true;
                }
            });
        };
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" DirectMethodNamespace="mLevels" />
        
        <h1>MultiLevel GridPanel</h1>
        
    </form>
</body>
</html>