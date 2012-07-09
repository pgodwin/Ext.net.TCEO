<%@ Page Language="C#" %>
<%@ Import Namespace="System.Collections.Generic"%>
<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Drag with state - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <script runat="server">
        protected void Page_Load(object sender, EventArgs e)
        {
            divsData.Items.Add("divs",new List<object>
            {
                new { X=20,  Y=20 },
                new { X=80,  Y=20 },
                new { X=140, Y=20 },
                new { X=200, Y=20 },
                new { X=20,  Y=80 },
                new { X=80,  Y=80 },
                new { X=140, Y=80 },
                new { X=200, Y=80 },
                new { X=20,  Y=140 },
                new { X=80,  Y=140 },
                new { X=140, Y=140 },
                new { X=200, Y=140 }
            });
        }
    </script>
    
    <style type="text/css">
        div.draggable-item {
            border:1px solid silver;
            background-color:#f0f080;
            width:40px;
            height:40px;
            text-align:center;
            line-height:40px;
            font-size:11px;
            font-family:sans-serif;
            position:absolute;
            cursor: default;
        }
        
        .drag-area{
            background-color:#f0f0f0 ! important;
            position:relative;
        }
        
        .dd-proxy {
            opacity:0.4;
            -moz-opacity:0.4;
            filter:alpha(opacity=40);
            cursor:default ! important;
        }
    </style>
    
    <script type="text/javascript">
        var getState = function () {
            var state = {};
            state.divs = divsData.divs;
            return state;
        };
        
        var startDrag = function (x, y) {
            var dragEl = Ext.get(this.getDragEl());
            var el = Ext.get(this.getEl());
            el.hide();

            dragEl.applyStyles({border:"solid gray 1px"});
            dragEl.update(el.dom.innerHTML);
            dragEl.addClass(el.dom.className + " dd-proxy");
        };
        
        var afterDrag = function () {
            var el = Ext.get(this.getEl());
            var div = divsData.divs[parseInt(el.getAttribute("index"))-1];
            div.X = el.getLeft(true);
            div.Y = el.getTop(true);
            el.show();
            DragArea.fireEvent("itemdrag", this);
        };
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" StateProvider="Cookie" />
        
        <ext:ObjectHolder ID="divsData" runat="server" />
        
        <ext:XTemplate ID="Tpl1" runat="server">
            <Html>
				<tpl for=".">
					 <div id="item-{#}" index="{#}" class="draggable-item" style="top:{Y}px;left:{X}px;">Item {#}</div>
				</tpl>
			</Html>
        </ext:XTemplate>
        
        <ext:Viewport runat="server" Layout="fit">
            <Items>
                <ext:Panel 
                    ID="DragArea" 
                    runat="server" 
                    BodyCssClass="drag-area" 
                    StateEvents="resize,itemdrag">
                    <GetState Fn="getState" />
                    <Listeners>
                        <BeforeStateRestore Handler="#{divsData}.divs = state.divs;" />
                        <AfterRender Handler="#{Tpl1}.overwrite(this.body, #{divsData}.divs);" />
                    </Listeners>
                </ext:Panel>
            </Items>
        </ext:Viewport>
        
        <ext:DDProxy runat="server" Target="${div.draggable-item}" Group="group">
            <StartDrag Fn="startDrag" />
            <AfterDrag Fn="afterDrag" />
        </ext:DDProxy>
    </form>    
</body>
</html>
