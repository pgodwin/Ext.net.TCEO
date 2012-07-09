<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Resizable - Ext.NET Examples</title>    
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />    
    
    <style type="text/css">
        #basic, #animated {
            border:1px solid #c3daf9;
            color:#1e4e8f;
            font:bold 14px tahoma,verdana,helvetica;
            text-align:center;
            padding-top:20px;
        }
        
        #snap {
            border:1px solid #c3daf9;
            overflow:hidden;
        }
        
        #custom {
            cursor:move;
        }
        
        #custom-rzwrap{
            z-index: 100;
        }
        
        #custom-rzwrap .x-resizable-handle{
            width:11px;
            height:11px;
            background:transparent url(resources/images/square.gif) no-repeat;
            margin:0px;
        }
        
        #custom-rzwrap .x-resizable-handle-east, #custom-rzwrap .x-resizable-handle-west{
            top:45%;
        }
        
        #custom-rzwrap .x-resizable-handle-north, #custom-rzwrap .x-resizable-handle-south{
            left:45%;
        }
    </style>
    
    <script type="text/javascript">
        var hideImage = function () {
            var customEl = CustomResizer.getEl();
            customEl.hide();
            document.body.insertBefore(customEl.dom, document.body.firstChild);

            customEl.on('dblclick', function () {
                customEl.hide(true);
            });            
        };
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server">
            <Listeners>
                <DocumentReady Handler="hideImage();" />
            </Listeners>
        </ext:ResourceManager>
        
        <h1>Resizable Examples</h1>
        <p>These examples show how to apply a floating (default) and pinned Resizable component to a standard element.</p>
        
        
        <p>
            <b>Basic Example</b><br />
            This is a basic as you get. To resize the box, position your mouse anywhere near the bottom,
            right or border right edge of the box. This example uses the default "floating" handles.
        </p>
        
        <div id="basic">Resize Me!</div>
        
        <ext:Resizable 
            runat="server" 
            Element="basic" 
            Width="200"
            Height="100"
            MinWidth="100"
            MinHeight="50"
            />
        
        <hr/>
        
        <p>
            <b>Animated Transitions</b><br />
            Resize operations can also be animated. Animations support configurable easing and duration.
            Here's a very basic clone of the first element, but with animation turned on. I used a "backIn"
            easing and made it a little slower than default.
        </p>
        <div id="animated">Animate Me!</div>
        
        <ext:Resizable 
            ID="Resizable1" 
            runat="server" 
            Element="animated" 
            Pinned="true"
            Width="200"
            Height="100"            
            MinWidth="100"
            MinHeight="50"
            Animate="true"
            Easing="BackIn"
            Duration="0.6"
            />
        
        Warning: for obvious reasons animate and dynamic resizing can not be used together.
        
        <hr/>
        
        <p>
            <b>Wrapped Elements</b><br />
            Some elements such as images and textareas don't allow child elements. In the past, you had
            to wrap these elements and set up a Resizable with resize child. Resizable will
            wrap the element, calculate adjustments for borders/padding and offset the handles for you. All you have to
            do is set "Wrap=true". The manual way of specifying a "ResizeChild" is still supported as well.
        </p><p>
            <b>Pinned Handles</b><br />
            Notice this example has the resize handles "Pinned". This is done by setting "Pinned=true".
        </p><p>
            <b>Dynamic Sizing</b><br />
            If you don't like the proxy resizing, you can also turn on dynamic sizing. Just set "Dynamic=true".
        </p>
        <p>
            Here's a textarea that is wrapped, has pinned handles and has dynamic sizing turned on.
        </p>
        <textarea id="dwrapped">
        Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Sed metus nibh, sodales a, porta at, vulputate eget, dui. Pellentesque ut nisl. Maecenas tortor turpis, interdum non, sodales non, iaculis ac, lacus. Vestibulum auctor, tortor quis iaculis malesuada, libero lectus bibendum purus, sit amet tincidunt quam turpis vel lacus. In pellentesque nisl non sem. Suspendisse nunc sem, pretium eget, cursus a, fringilla vel, urna. Aliquam commodo ullamcorper erat. Nullam vel justo in neque porttitor laoreet. Aenean lacus dui, consequat eu, adipiscing eget, nonummy non, nisi. Morbi nunc est, dignissim non, ornare sed, luctus eu, massa.
        Vivamus eget quam. Vivamus tincidunt diam nec urna. Curabitur velit. Quisque dolor magna, ornare sed, elementum porta, luctus in, leo.
        </textarea><br /><br />
        
        <ext:Resizable 
            runat="server" 
            Element="dwrapped" 
            Wrap="true"
            Pinned="true"
            Width="450"
            Height="150"
            MinWidth="200"
            MinHeight="50"
            Dynamic="true"
            />
        <hr/>
        
        <p>
            <b>Preserve Ratio</b><br />
            For some things like images, you will probably want to preserve the ratio of width to height. Just set PreserveRatio=true.
        </p>
        
        <img id="wrapped" src="resources/images/sara.jpg" width="200" height="250" />
        
        <ext:Resizable 
            runat="server" 
            Element="wrapped" 
            Wrap="true"
            Pinned="true"
            MinWidth="50"
            MinHeight="50"
            PreserveRatio="true"
            />
        <hr/>
        
        <p>
            <b>Transparent Handles</b><br />
            If you just want the element to be resizable without any fancy handles, set transparent to true.
        </p>
        <img id="transparent" src="resources/images/zack.jpg" width="100" height="176" />
        
        <ext:Resizable 
            runat="server" 
            Element="transparent" 
            Wrap="true"
            MinWidth="50"
            MinHeight="50"
            PreserveRatio="true"
            Transparent="true"
            />
        <hr />
        
        <p>
            <b>Customizable Handles</b><br />
            Resizable elements are resizable 8 ways. 8 way resizing for a static positioned element will cause the element to be positioned relative and taken out of the document flow. For resizing which adjusts the
            x and y of the element, the element should be positioned absolute. You can also control which handles are displayed by setting the "handles" attribute.
            The handles are styled using CSS so they can be customized to look however you would like them to. 
        </p>
        <p>
            This image has 8 way resizing, custom handles, is draggable and 8 way preserved ratio (that wasn't easy!).<br />
            <b>Double click anywhere on the image to hide it when you are done.</b>
        </p>
        <img id="custom" src="resources/images/sara_and_zack.jpg" width="200" height="152" style="position:absolute;left:0;top:0;" />
        
        <ext:Resizable 
            ID="CustomResizer" 
            runat="server" 
            Element="custom" 
            Wrap="true"
            Pinned="true"
            MinWidth="50"
            MinHeight="50"
            PreserveRatio="true"
            Handles="All"
            Draggable="true"
            Dynamic="true"
            />
        
        <div style="padding:8px;border:1px solid #c3daf9;background:#d9e8fb;width:150px;text-align:center;">
            <ext:Button runat="server" Text="Show Me">
                <Listeners>
                    <Click Handler="CustomResizer.getEl().center();CustomResizer.getEl().show(true);" />
                </Listeners>
            </ext:Button>
        </div>
        <hr />
        
        <p>
            <b>Snapping</b><br />
            Resizable also supports basic snapping in increments. 
        </p>
        <div id="snap"></div>
        
        <ext:Resizable 
            runat="server" 
            Element="snap" 
            Pinned="true"
            Width="250"
            Height="100"
            Handles="East"
            WidthIncrement="50"
            MinWidth="50"
            Dynamic="true"
            />
        
        Warning: Snapping and preserveRatio conflict and can not be used together.
        <hr/>        
        
        <ext:Panel ID="ExtNetSite" Title="Resizable panel" runat="server" Width="400" Height="200">
            <AutoLoad Url="http://www.ext.net" Mode="IFrame" />
        </ext:Panel>
        
        <ext:Resizable 
            runat="server" 
            Element="={#{ExtNetSite}.el}" 
            Width="400"
            Height="200"
            MinWidth="200"
            MinHeight="200"
            Transparent="true">            
            <Listeners>
                <Resize Handler="#{ExtNetSite}.el.setStyle({width:'', height:''}); #{ExtNetSite}.setSize(width, height);" />
            </Listeners>
        </ext:Resizable>
        
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </form>
</body>
</html>
