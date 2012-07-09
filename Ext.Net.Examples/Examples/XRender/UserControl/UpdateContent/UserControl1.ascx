<%@ Control Language="C#" Inherits="Ext.Net.Examples.BaseUserControl" %>
<%@ Import Namespace="System.Collections.Generic"%>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    public override List<string> ControlsToDestroy
    {
        get
        {
            // we should return none lazy controls only because lazy controls will be autodestroyed by parent container
            return new List<string>
                       {
                            Label1.ClientID,
                            Button1.ClientID
                       };
        }
    }
    
    [DirectMethod]
    public void DirectMethod()
    {
        
    }
</script>

<h1>№1</h1>
<ext:Label ID="Label1" runat="server" Text="I am User control №1" />
<br />
<ext:Button ID="Button1" runat="server" Text="User control №1: Ext.Net button" />
<br />
<asp:Button runat="server" Text="User control №1: ASP.NET button" OnClientClick="return false;" />