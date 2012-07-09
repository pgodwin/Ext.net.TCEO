<%@ Page Language="C#" %>

<%@ Import Namespace="Ext.Net.Utilities"%>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        for (int i = 0; i < 100; i++)
        {
            this.TableLayout1.Cells.Add(new Cell{Items = {new Checkbox(false)}});
        }
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Click and Drag to Select Items - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript">        
        var startTrack = function () {
	        this.checkboxes = [];
	        var cb;
	        
	        Ext.select(".x-form-check-wrap input", false).each(function (checkEl) {
	            cb = Ext.getCmp(checkEl.dom.id);
	            cb.setValue(false);
	            this.checkboxes.push(cb);
	        }, this);
        };
        
        dragTrack = function () {
	        var cb, sel;
	        
	        for (var i = 0, l = this.checkboxes.length; i < l; i++) {
	            cb = this.checkboxes[i];	     
	            sel = this.dragRegion.isIntersect(cb.el.getRegion());
	            
	            if (cb.checked && !sel) {
	                cb.setValue(false);
	            } else if (!cb.checked && sel) {
	                cb.setValue(true);
	            }
	        }
		};
        
        var endTrack = function () {				
	        delete this.checkboxes;
		};
    </script>
    
    <style type="text/css">
        .cb-cell td{
            padding-right  : 10px;
            padding-bottom : 5px;
        }
        
        .black-view-selector {
            position     : absolute;
            left         : 0;
            top          : 0;
            width        : 0;
            background   : black;
            border       : 1px dotted gray;
	        opacity      : .3;
            -moz-opacity :  .3;
            filter       : alpha(opacity=30);
            zoom         : 1;
        }
    </style>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />         
        
        <ext:Viewport runat="server" Layout="Border">
            <Items>
                <ext:Panel runat="server" Region="North" Height="40">
                    <Content>
                        <h3>Click and Drag to Select Items</h3>
                    </Content>
                </ext:Panel>
                
                <ext:Panel 
                    ID="Panel1" 
                    runat="server" 
                    Cls="cb-cell"
                    Region="Center"
                    Padding="10">
                    <Items>
                        <ext:TableLayout 
                            ID="TableLayout1" 
                            runat="server"
                            Columns="10"
                            />
                    </Items>
                </ext:Panel>
            </Items>
        </ext:Viewport>      
        
        <ext:DragTracker 
            runat="server" 
            Target="={Panel1.body}" 
            ProxyCls="black-view-selector">
            <Listeners>
                <DragStart Fn="startTrack" />
                <Drag      Fn="dragTrack" />
                <DragEnd   Fn="endTrack" />
            </Listeners>
        </ext:DragTracker>
    </form>    
</body>
</html>
