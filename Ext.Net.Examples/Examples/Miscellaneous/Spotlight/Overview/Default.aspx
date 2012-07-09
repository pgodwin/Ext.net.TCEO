<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Spotlight - Ext.NET Examples</title>    
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript">
        var updateSpot = function (cmp) {
            Spot.show(cmp);
            updateButtons(cmp);
        };

        var hideSpot = function () {
            if (Spot.active) {
                Spot.hide();
            }
            
            updateButtons();
        }

        var updateButtons = function (cmp) {
            cmp = cmp || {};
            Panel1.buttons[0].setDisabled(cmp.id != Panel1.id);
            Panel2.buttons[0].setDisabled(cmp.id != Panel2.id);
            Panel3.buttons[0].setDisabled(cmp.id != Panel3.id);
        }
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server">
            <Listeners>
                <DocumentReady Handler="updateButtons();" />
            </Listeners>
        </ext:ResourceManager>
        
        <h1>Spotlight</h1>
        <p>This control allows you to restrict input to a particular element by masking all other page content.</p>

        
        <ext:Spotlight ID="Spot" runat="server" Easing="EaseOut" Duration="0.3" />
        
        <ext:Button runat="server" Text="Start">
            <Listeners>
                <Click Handler="updateSpot(#{Panel1});" />
            </Listeners>
        </ext:Button>
        
        <ext:Panel runat="server" Border="false">
            <Items>
                <ext:TableLayout runat="server" Columns="3">
                    <Cells>
                        <ext:Cell>
                            <ext:Panel ID="Panel1" runat="server" 
                                Frame="true"
                                Title="Demo Panel"
                                Width="200"
                                Height="150"
                                Html="Some panel content goes here!" 
                                PaddingSummary="10px 15px">
                                <Buttons>
                                    <ext:Button ID="Button1" runat="server" Text="Next Panel">
                                        <Listeners>
                                            <Click Handler="updateSpot(#{Panel2});" />
                                        </Listeners>
                                    </ext:Button>
                                </Buttons>
                            </ext:Panel>
                        </ext:Cell>
                        
                        <ext:Cell>
                            <ext:Panel ID="Panel2" runat="server" 
                                Frame="true"
                                Title="Demo Panel"
                                Width="200"
                                Height="150"
                                Html="Some panel content goes here!" 
                                PaddingSummary="10px 15px">
                                <Buttons>
                                    <ext:Button ID="Button2" runat="server" Text="Next Panel">
                                        <Listeners>
                                            <Click Handler="updateSpot(#{Panel3});" />
                                        </Listeners>
                                    </ext:Button>
                                </Buttons>
                            </ext:Panel>
                        </ext:Cell>
                        
                        <ext:Cell>
                            <ext:Panel ID="Panel3" runat="server" 
                                Frame="true"
                                Title="Demo Panel"
                                Width="200"
                                Height="150"
                                Html="Some panel content goes here!" 
                                PaddingSummary="10px 15px">
                                <Buttons>
                                    <ext:Button ID="Button3" runat="server" Text="Done">
                                        <Listeners>
                                            <Click Handler="hideSpot();" />
                                        </Listeners>
                                    </ext:Button>
                                </Buttons>
                            </ext:Panel>
                        </ext:Cell>
                    </Cells>
                </ext:TableLayout>
            </Items>
        </ext:Panel>        
    </form>
</body>
</html>
