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
    <title>LinkButton Control Variations - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <ext:ResourceManager runat="server" />
   
    <h1>LinkButton Control Variations</h1>
    
    <h2>Simple LinkButton</h2>
    
    <ext:LinkButton runat="server" Text="Click">
        <Listeners>
            <Click Handler="Ext.Msg.alert('Clicked', 'LinkButton');" />
        </Listeners>
    </ext:LinkButton>
    
    <h2>LinkButton with Icon and Click DirectEvent</h2>
    
    <ext:LinkButton runat="server" Icon="Accept" Text="Click">
        <DirectEvents>
            <Click OnEvent="Button_Click" />
        </DirectEvents>
    </ext:LinkButton>
    
    <h2>LinkButton with Right Aligned Icon</h2>
    
    <ext:LinkButton runat="server" Icon="Accept" IconAlign="Right" Text="Click" />
    
    <h2>LinkButton with Menu</h2>
    
    <ext:LinkButton runat="server" Icon="Accept" Text="Click">
        <Menu>
            <ext:Menu runat="server">
                <Items>
                    <ext:MenuItem runat="server" Text="Add" Icon="Add" />
                    <ext:MenuItem runat="server" Text="Remove" Icon="Delete" />
                </Items>
            </ext:Menu>
        </Menu>
    </ext:LinkButton>
    
    <h2>LinkButton in a ToggleGroup</h2>
      
    <ext:LinkButton runat="server" Icon="GroupAdd" Text="Add group" ToggleGroup="Group1" />&nbsp;&nbsp;
    <ext:LinkButton runat="server" Icon="GroupDelete" Text="Delete group" ToggleGroup="Group1" />&nbsp;&nbsp;
    <ext:LinkButton runat="server" Icon="GroupEdit" Text="Edit group" ToggleGroup="Group1" />
</body>
</html>
