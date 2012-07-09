<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TreePanel with Async TreeLoader using WebService - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        
        <h1>TreePanel using WebServiceTreeLoader</h1> 
        
        <ext:TreePanel 
            ID="TreePanel1" 
            runat="server" 
            Title="Tree" 
            AutoHeight="true" 
            Border="false">
            <Loader>
                <ext:WebServiceTreeLoader DataUrl="TreeLoaderService.asmx/GetNodes" />
            </Loader>
            <Root>
                <ext:AsyncTreeNode NodeID="0" Text="Root" />
            </Root>
        </ext:TreePanel>       
    </form>
</body>
</html>