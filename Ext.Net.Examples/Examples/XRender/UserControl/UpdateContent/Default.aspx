<%@ Page Language="C#" %>
<%@ Import Namespace="System.Collections.Generic"%>
<%@ Import Namespace="Ext.Net.Examples"%>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Button1_Click(object sender, DirectEventArgs e)
    {
        X.Js.Call("destroyFromCache", new JRawValue(Panel1.ClientID));
        BaseUserControl uc1 = (BaseUserControl)this.LoadControl("UserControl1.ascx");
        uc1.ID = "UC1";
        this.Panel1.ContentControls.Add(uc1);

        X.Js.Call("putToCache", new JRawValue(Panel1.ClientID), uc1.ControlsToDestroy);
        this.Panel1.UpdateContent();
        
        this.Button1.Disabled = true;
        this.Button2.Disabled = false;
    }

    protected void Button2_Click(object sender, DirectEventArgs e)
    {
        X.Js.Call("destroyFromCache", new JRawValue(Panel1.ClientID));
        BaseUserControl uc2 = (BaseUserControl)this.LoadControl("UserControl2.ascx");
        uc2.ID = "UC2";
        this.Panel1.ContentControls.Add(uc2);
        
        X.Js.Call("putToCache", new JRawValue(Panel1.ClientID), uc2.ControlsToDestroy);
        this.Panel1.UpdateContent();

        this.Button1.Disabled = false;
        this.Button2.Disabled = true;
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Controls and Content during a DirectEvent - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript">
        var destroyFromCache = function(container) {
            container.controlsCache = container.controlsCache || [];
            Ext.each(container.controlsCache, function(controlId) {
                var control = Ext.getCmp(controlId);
                if (control && control.destroy) {
                    control.destroy();
                }
            });
        };
        
        var putToCache = function(container, controls) {
            container.controlsCache = controls;
        };
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>Update Controls and Content during a DirectEvent</h1>
        
        <h3>Load UserControls</h3>
        
        <ext:Panel 
            ID="Panel1" 
            runat="server" 
            Title="User Controls" 
            Width="500" 
            Height="200"
            Padding="5">
            <TopBar>
                <ext:Toolbar runat="server">
                    <Items>
                        <ext:Button 
                            ID="Button1" 
                            runat="server" 
                            Text="Load 1"
                            OnDirectClick="Button1_Click" 
                            />
                        <ext:Button 
                            ID="Button2" 
                            runat="server" 
                            Text="Load 2" 
                            OnDirectClick="Button2_Click" 
                            Disabled="true"
                            />
                    </Items>
                </ext:Toolbar>
            </TopBar>
        </ext:Panel>
    </form>
</body>
</html>