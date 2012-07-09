<%@ Page Language="C#" %>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>IFrame Communication - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>IFrame Communication</h1>
        
        <ext:Window runat="server" Title="Parent" Width="400" Height="200" Layout="column">
            <Items>
                <ext:Panel ID="Panel1" runat="server" Title="A" Padding="10" ColumnWidth="0.5">
                    <AutoLoad Url="A.aspx" Mode="IFrame" ShowMask="true" />                                
                </ext:Panel>
                <ext:Panel ID="Panel2" runat="server" Title="B" Padding="10" ColumnWidth="0.5">
                    <AutoLoad Url="B.aspx" Mode="IFrame" ShowMask="true" />                                
                </ext:Panel>
            </Items>
        </ext:Window>    
    </form>
</body>
</html>
