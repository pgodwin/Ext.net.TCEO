<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Horizontal Menu - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
        .x-menu.x-menu-horizontal .x-menu-list
        {
            overflow: hidden;
        }
        .x-menu.x-menu-horizontal .x-menu-list .x-menu-list-item
        {
            float: left;
        }
        .x-menu.x-menu-horizontal .x-menu-list .x-menu-list-item .x-menu-item-arrow
        {
            background: none;
        }
    </style>
</head>
<body>
    <ext:ResourceManager runat="server" />

    <ext:Viewport ID="Viewport1" runat="server" Layout="Border">
        <Items>
            <ext:MenuPanel ID="MenuPanel1" runat="server" Border="false" Region="North" Height="28"
                SaveSelection="true" SelectedIndex="0">
                <Menu ID="Menu1" runat="server" Hidden="false" ShowSeparator="false" EnableScrolling="false"
                    SubMenuAlign="tl-bl?" Cls="x-menu-horizontal" Floating="false">                    
                    <Items>
                        <ext:MenuItem runat="server" Text="Item 1" Icon="BulletBlue" />
                        <ext:MenuItem runat="server" Text="Item 2" Icon="BulletBlue" />
                        <ext:MenuItem runat="server" Text="Item 3" Icon="BulletBlue" />
                        <ext:MenuItem runat="server" Text="Item 4" Icon="BulletBlue" />
                        <ext:MenuItem runat="server" Text="Item 5" Icon="BulletBlue" />
                        <ext:MenuItem runat="server" Text="Item 6" Icon="BulletBlue" />
                        <ext:MenuItem runat="server" Text="Item 7" Icon="BulletBlue" />
                        <ext:MenuItem runat="server" Text="Item 8" Icon="BulletBlue" />
                        <ext:MenuItem runat="server" Text="Item 9" Icon="BulletBlue" />
                        <ext:MenuItem runat="server" Text="Item 10" Icon="BulletBlue" />                        
                    </Items>
                </Menu>
            </ext:MenuPanel>
            <ext:Panel ID="Panel1" runat="server" Region="Center" />
        </Items>
    </ext:Viewport>
</body>
</html>