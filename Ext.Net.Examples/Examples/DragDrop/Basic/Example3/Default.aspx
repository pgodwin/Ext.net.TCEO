<%@ Page Language="C#" %>
<%@ Import Namespace="Ext.Net.Utilities"%>
<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Drag&amp;Drop - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
        body {
            font-size: 11px;
        }
        .dd-ct {
            position:absolute;
            border: 1px solid silver;
            width: 180px;
            height: 180px;
            top: 40px;
            background-color: #ffffc0;
        }
        #dd1-ct {
            left: 64px;
        }
        #dd2-ct {
            left: 256px;
        }
        .dd-item {
            height: 18px;
            border: 1px solid #a0a0a0;
            background-color: #c4d0ff;
            vertical-align: middle;
            cursor: move;
            padding: 2px;
            z-index: 1000;
        }
        .dd-ct .dd-item {
            margin: 2px;
        }
        .dd-proxy {
            opacity: 0.4;
            -moz-opacity: 0.4;
            filter: alpha(opacity=40);
        }
        .dd-over {
            background-color: #ffff60;
        }
    </style>
    
    <ext:ResourcePlaceHolder runat="server" Mode="ScriptFiles" />
    
    <script type="text/javascript">
        function startDrag(x, y) {
            var dragEl = Ext.get(this.getDragEl());
            var el = Ext.get(this.getEl());
     
            dragEl.applyStyles({border:'','z-index':2000});
            dragEl.update(el.dom.innerHTML);
            dragEl.addClass(el.dom.className + ' dd-proxy');
        }
        
        function onDragOver(e, targetId) {
            if ('dd1-ct' === targetId || 'dd2-ct' === targetId) {
                var target = Ext.get(targetId);
                this.lastTarget = target;
                target.addClass('dd-over');
            }
        }
        
        function onDragOut(e, targetId) {
            if ('dd1-ct' === targetId || 'dd2-ct' === targetId) {
                var target = Ext.get(targetId);
                this.lastTarget = null;
                target.removeClass('dd-over');
            }
        }
        
        function endDrag() {
            var dragEl = Ext.get(this.getDragEl());
            var el = Ext.get(this.getEl());
            if (this.lastTarget) {
                Ext.get(this.lastTarget).appendChild(el);
                el.applyStyles({position:'', width:''});
            }
            else {
                el.applyStyles({position:'absolute'});
                el.setXY(dragEl.getXY());
                el.setWidth(dragEl.getWidth());
            }
            Ext.get('dd1-ct').removeClass('dd-over');
            Ext.get('dd2-ct').removeClass('dd-over');
            
            if (typeof this.dragData.fn === 'function') {
                this.dragData.fn.apply(window, [this, this.dragData]);
            }
        }
    </script>
    
    <script runat="server">
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 2; i++)
            {
                DropZone dz = new DropZone{ Target = "dd{0}-ct".FormatWith(i), Group = "group"};
                this.Form.Controls.Add(dz);
            }

            for (int i = 1; i <= 2; i++)
            {
                for (int p = 1; p <= 3; p++)
                {
                    DDProxy ddProxy = new DDProxy
                                          {
                                              Target = "dd{0}-item{1}".FormatWith(i,p),
                                              Group = "group",
                                              StartDrag = { Fn = "startDrag" },
                                              OnDragOver = { Fn = "onDragOver" },
                                              OnDragOut = { Fn = "onDragOut" },
                                              EndDrag = { Fn = "endDrag" }
                                          };
                    JsonObject data = new JsonObject();
                    data.Add("name", "Item{0}.{1}".FormatWith(i, p));
                    data.Add("index", p);
                    data.Add("fn", new JFunction("alert(data.name);", new string[]{"dd", "data"}));
                    ddProxy.CustomConfig.Add(new ConfigItem("dragData", JSON.Serialize(data), ParameterMode.Raw));
                    this.Form.Controls.Add(ddProxy);
                }
            }
        }
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />  
        
        <a href="http://www.extjs.com/learn/Tutorial:Custom_Drag_and_Drop_Part_3">Tutorial:Custom Drag and Drop Part 3</a>
        
        <div class="dd-ct" id="dd1-ct">
            <div class="dd-item" id="dd1-item1">Item 1.1</div>
            <div class="dd-item" id="dd1-item2">Item 1.2</div>
            <div class="dd-item" id="dd1-item3">Item 1.3</div>
        </div>
        
        <div class="dd-ct" id="dd2-ct">
            <div class="dd-item" id="dd2-item1">Item 2.1</div>
            <div class="dd-item" id="dd2-item2">Item 2.2</div>
            <div class="dd-item" id="dd2-item3">Item 2.3</div>
        </div>
    </form>    
</body>
</html>
