<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ProgressBar - Ext.NET Examples</title>    
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />  
    
    <style type="text/css">
        .status {
            color:#555;
        }
        .x-progress-wrap.left-align .x-progress-text {
            text-align:left;
        }
        .x-progress-wrap.custom {
            height:17px;
            border:1px solid #686868;
            overflow:hidden;
            padding:0 2px;
        }
        .ext-ie .x-progress-wrap.custom {
            height:19px;
        }
        .custom .x-progress-inner {
            height:17px;
            background: #fff;
        }
        .custom .x-progress-bar {
            height:15px;
            background:transparent url(custom-bar.gif) repeat-x 0 0;
            border-top:1px solid #BEBEBE;
            border-bottom:1px solid #EFEFEF;
            border-right:0;
        }
    </style>  
    
    <script type="text/javascript">
       var updateBar = function (value, pbar, btn, count, callback) {
            if (value > count) {
                btn.setDisabled(false);
                callback();
            }else{
                pbar.updateProgress(value / count, 'Loading item ' + value + ' of ' + count + '...');
            }
       }
        
       var run = function (pbar, btn, count, callback) {
           btn.setDisabled(true);
           var ms = 5000 / count;
           for (var i = 1; i < (count + 2); i++) {
               setTimeout(updateBar.createCallback(i, pbar, btn, count, callback), i * ms);
           }
       }

       var runProgress1 = function (status, progress, btn) {
           status.setText('Working');
           progress.show();
           run(progress, btn, 10, function () {
                progress.reset(true);
                status.setText('Done.'); 
           });
       }

       var runProgress2 = function (progress, btn) {
           progress.show();
           run(progress, btn, 12, function () {
               progress.reset();
               progress.updateText('Done.');
           });
       }

       var runProgress3 = function (status, progress, btn) {
           status.setText('Working');
           btn.setDisabled(true);           
           progress.wait({
               interval: 200,
               duration: 5000,
               increment: 15,
               fn: function () {
                   btn.setDisabled(false);
                   status.setText('Done');
               }
           });
       }

       var runProgress4 = function (progress, btn) {
           run(progress, btn, 19, function () {               
               progress.updateText('All finished!');
           });
       }
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <h1>Progress Bar</h1>
        <p>The example shows how to use the ProgressBar class.</p>
        
        <p>            
            <b>1. Basic Progress Bar</b><br />
            Dynamic show/hide and built-in progress text:
            <ext:Button ID="ShowProgress1" runat="server" Text="Show">
                <Listeners>
                    <Click Handler="runProgress1(#{StatusLabel}, #{Progress1}, this);" />
                </Listeners>
            </ext:Button>
            <br />
            <ext:Label ID="StatusLabel" runat="server" Cls="status" Text="Nothing to see here." />
            <ext:ProgressBar ID="Progress1" runat="server" Width="300" Text="Initializing..." Hidden="true" />
        </p>
        
        <p>
            <b>Additional Options</b><br />
            Rendered on page load, left-aligned text and % width:
            <ext:Button ID="Button1" runat="server" Text="Show">
                <Listeners>
                    <Click Handler="runProgress2(#{Progress2}, this);" />
                </Listeners>
            </ext:Button>
            <br />
            <ext:ProgressBar ID="Progress2" runat="server" StyleSpec="width:50%" Text="Ready" Cls="left-align" />
        </p>
        
        <p>
            <b>Waiting Bar</b><br />
            Wait for a long operation to complete (example will stop after 5 secs):
            <ext:Button ID="Button2" runat="server" Text="Show">
                <Listeners>
                    <Click Handler="runProgress3(#{StatusLabel3}, #{Progress3}, this);" />
                </Listeners>
            </ext:Button>
            <ext:ProgressBar ID="Progress3" runat="server" Width="300">
                <Listeners>
                    <Update Handler="#{StatusLabel3}.setText(#{StatusLabel3}.getText()+'.');" />
                </Listeners>
            </ext:ProgressBar>
            <ext:Label ID="StatusLabel3" runat="server" Cls="status" Text="Ready" />
        </p>
        
        <p>
            <b>Custom Styles</b><br />
            Rendered like Windows XP with custom progress text element:
            <ext:Button ID="Button3" runat="server" Text="Show">
                <Listeners>
                    <Click Handler="runProgress4(#{Progress4}, this);" />
                </Listeners>
            </ext:Button>
            
            <ext:ProgressBar ID="Progress4" runat="server" Width="300" Text="Waiting on you..." TextEl="p4text" Cls="custom" />
            <div class="status"><b>Status:</b> <span id="p4text"></span></div>
        </p>
      
    </form>
</body>
</html>
