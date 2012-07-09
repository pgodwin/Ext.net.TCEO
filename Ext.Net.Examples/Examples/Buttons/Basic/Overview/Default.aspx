<%@ Page Language="C#" %>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<script runat="server">
    protected void Button_Click(object sender, DirectEventArgs e)
    {
       X.Msg.Alert("DirectEvent", string.Format("Item - {0}", e.ExtraParams["Item"])).Show();
    }
</script>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Button Control Variations - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .custom-icon1 {
        	background-image: url(arrow-down.gif) !important;
        }
    </style>
</head>
<body>
    <ext:ResourceManager runat="server" DirectEventUrl="default.aspx" />
   
    <h1>Button Control Variations</h1>
    
    <h2>1. Button with Listener</h2>
    
    <ext:Button runat="server" Text="Click Me">
        <Listeners>
            <Click Handler="alert('Clicked');" />
        </Listeners>
    </ext:Button>
    
    <h2>2. Button with DirectEvent</h2>
    
    <ext:Button runat="server" Text="Click Me">
        <DirectEvents>
            <Click OnEvent="Button_Click">
                <EventMask ShowMask="true" />
                <ExtraParams>
                    <ext:Parameter Name="Item" Value="One" />
                </ExtraParams>
            </Click>
        </DirectEvents>
    </ext:Button>
    
    <h2>3. Button with Icon</h2>
    
    <ext:Button runat="server" Text="Text" Icon="Add" />
    
    <h2>4. Button with Custom Icon</h2> 
    
    <ext:Button runat="server" Text="Text" IconCls="custom-icon1" />
    
    <h2>5. Button with QuickTip</h2>
    
    <ext:Button runat="server" Text="Text">
        <ToolTips>
            <ext:ToolTip runat="server" Title="Title" Html="Description" />
        </ToolTips>
    </ext:Button>
    
    <h2>6. Toggle Buttons</h2>
    
    <ext:Button runat="server" Text="Button1" EnableToggle="true" ToggleGroup="Group1" Pressed="true" />
    <ext:Button runat="server" Text="Button2" EnableToggle="true" ToggleGroup="Group1" />
    <ext:Button runat="server" Text="Button3" EnableToggle="true" ToggleGroup="Group1" />
    
    <h2>7. Button with menu</h2>
    
    <ext:Button runat="server" Text="Text">
        <Menu>
            <ext:Menu runat="server">
                <Items>                    
                    <ext:MenuItem runat="server" Text="Item 1" Icon="GroupAdd" />
                    <ext:MenuItem runat="server" Text="Item 2" Icon="GroupDelete" />
                    <ext:MenuItem runat="server" Text="Item 3" Icon="GroupEdit" />
                </Items>
            </ext:Menu>
        </Menu>
    </ext:Button>
    
    <h2>8. SplitButton with menu</h2>
    
    <ext:SplitButton runat="server" Text="Text">
        <Menu>
            <ext:Menu runat="server">
                <Items>                    
                    <ext:MenuItem runat="server" Text="Item 1" Icon="GroupAdd" />
                    <ext:MenuItem runat="server" Text="Item 2" Icon="GroupDelete" />
                    <ext:MenuItem runat="server" Text="Item 3" Icon="GroupEdit" />
                </Items>
            </ext:Menu>
        </Menu>
    </ext:SplitButton>
    
    <h2>9. CycleButton</h2>
    
    <ext:CycleButton runat="server" ShowText="true" PrependText="View As ">
        <Menu>
            <ext:Menu runat="server">
                <Items>
                    <ext:CheckMenuItem runat="server" Text="Text Only" Icon="Note" />
                    <ext:CheckMenuItem runat="server" Text="Html" Icon="Html" Checked="true" />
                </Items>
            </ext:Menu>
        </Menu>
    </ext:CycleButton>
    
    <h2>10. Flat Button</h2>
    
    <ext:Button runat="server" Text="FlatButton" Icon="Accept" Flat="true" />
    
    <h2>11. Custom Size Button</h2>
    
    <ext:Button ID="Button1" runat="server" Text="128 x 128" Height="128" Width="128" />
</body>
</html>
