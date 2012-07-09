<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC"-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Top Menu - Ext.NET Example</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .x-menu.x-menu-horizontal .x-menu-list {
            overflow: hidden;
        }
        .x-menu.x-menu-horizontal .x-menu-list .x-menu-list-item {
            float: left;
        }
        .x-menu.x-menu-horizontal .x-menu-list .x-menu-list-item .x-menu-item-arrow {
            background: none;
        }
    </style>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <ext:Menu 
            runat="server" 
            Hidden="false" 
            ShowSeparator="false" 
            EnableScrolling="false"
            Cls="x-menu-horizontal" 
            Floating="false" 
            SubMenuAlign="tl-bl?">
            <Items>
                <ext:MenuItem runat="server" Text="Our first Menu" Icon="BulletBlue">
                    <Menu>
                        <ext:Menu runat="server" BoxMinWidth="110">
                            <Items>
                                <ext:MenuItem runat="server" Text="Item1" />
                                <ext:MenuItem runat="server" Text="Item2" />
                                <ext:MenuItem runat="server" Text="Item3" />
                                <ext:MenuItem runat="server" Text="Item4" />
                                <ext:MenuItem runat="server" Text="Item5" />
                            </Items>
                        </ext:Menu>
                    </Menu>
                </ext:MenuItem>
                <ext:MenuItem runat="server" Text="Our second Menu" Icon="BulletGreen">
                    <Menu>
                        <ext:Menu runat="server" BoxMinWidth="110">
                            <Items>
                                <ext:MenuItem runat="server" Text="Item1" />
                                <ext:MenuItem runat="server" Text="Item2" />
                                <ext:MenuItem runat="server" Text="Item3" />
                                <ext:MenuItem runat="server" Text="Item4" />
                                <ext:MenuItem runat="server" Text="Item5" />
                            </Items>
                        </ext:Menu>
                    </Menu>
                </ext:MenuItem>
            </Items>
        </ext:Menu>
    </form>
</body>
</html>
