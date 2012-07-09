<%@ Page Language="C#" %>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<script runat="server">
    protected void Button_Click(object sender, DirectEventArgs e)
    {
        X.Msg.Alert("Server Time", DateTime.Now.ToLongTimeString()).Show();
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ImageButton Control Variations - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <ext:ResourceManager runat="server" DirectEventUrl="default.aspx" />
   
    <h1>ImageButton Control Variations</h1>
    
    <h2>Simple ImageButton</h2> 
       
    <ext:ImageButton 
        runat="server" 
        ImageUrl="button.gif" 
        OverImageUrl="overButton.gif" 
        DisabledImageUrl="disabled.gif" 
        PressedImageUrl="pressed.gif">
        <DirectEvents>
            <Click OnEvent="Button_Click" />
        </DirectEvents>
    </ext:ImageButton>
    
    <h2>Disabled ImageButton</h2>
    
    <ext:ImageButton 
        runat="server" 
        Disabled="true"
        ImageUrl="button.gif" 
        OverImageUrl="overButton.gif" 
        DisabledImageUrl="disabled.gif" 
        PressedImageUrl="pressed.gif"
        />
    
    <h2>Toggling ImageButton</h2>    
    
    <ext:ImageButton
        runat="server" 
        EnableToggle="true"
        ImageUrl="button.gif" 
        OverImageUrl="overButton.gif" 
        DisabledImageUrl="disabled.gif" 
        PressedImageUrl="pressed.gif"
        />
    
    <h2>ImageButton with Menu</h2>    
    
    <ext:ImageButton
        runat="server" 
        ImageUrl="button.gif" 
        OverImageUrl="overButton.gif" 
        DisabledImageUrl="disabled.gif" 
        PressedImageUrl="pressed.gif">
        <Menu>
            <ext:Menu runat="server">
                <Items>
                    <ext:MenuItem runat="server" Text="Add" Icon="Add" />
                    <ext:MenuItem runat="server" Text="Accept" Icon="Accept" />
                </Items>
            </ext:Menu>
        </Menu>
    </ext:ImageButton>
    
    <h2>ImageButton in ToggleGroup</h2>
    
    <ext:ImageButton 
        runat="server" 
        ToggleGroup="Group1"
        ImageUrl="button.gif" 
        OverImageUrl="overButton.gif" 
        DisabledImageUrl="disabled.gif" 
        PressedImageUrl="pressed.gif"
        />
    
    <ext:ImageButton 
        runat="server" 
        ToggleGroup="Group1"
        ImageUrl="button.gif" 
        OverImageUrl="overButton.gif" 
        DisabledImageUrl="disabled.gif" 
        PressedImageUrl="pressed.gif"
        />
    
    <ext:ImageButton 
        runat="server" 
        ToggleGroup="Group1"
        ImageUrl="button.gif" 
        OverImageUrl="overButton.gif" 
        DisabledImageUrl="disabled.gif" 
        PressedImageUrl="pressed.gif"
        />
</body>
</html>
