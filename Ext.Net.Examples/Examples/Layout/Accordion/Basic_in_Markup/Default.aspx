<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AccordionLayout in Markup - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <ext:ResourceManager runat="server" />
    
    <h1>Accordion Layout in Markup</h1>
    
    <ext:Window 
        runat="server" 
        Title="Accordion"
        Width="250"
        Height="400"
        Maximizable="true"
        BodyBorder="false"
        Icon="ApplicationTileVertical"
        Layout="Accordion">
        <TopBar>
            <ext:Toolbar runat="server">
                <Items>
                    <ext:Button runat="server" Icon="Connect">
                        <ToolTips>
                            <ext:ToolTip runat="server" Title="Rich ToolTips" Html="Let your users know what they can do!" />
                        </ToolTips>
                    </ext:Button>
                    <ext:Button ID="Button2" runat="server" Icon="UserAdd" />
                    <ext:Button ID="Button3" runat="server" Icon="UserDelete" />
                </Items>
            </ext:Toolbar>
        </TopBar>
        <Items>
            <ext:TreePanel runat="server" Title="Online Users" RootVisible="false">
                <Tools>
                    <ext:Tool Type="Refresh" Handler="Ext.Msg.alert('Message','Refresh Tool Clicked!');" />
                </Tools>
                <Root>
                    <ext:TreeNode Text="Root">
                        <Nodes>
                            <ext:TreeNode Text="Friends" Expanded="true">
                                <Nodes>
                                    <ext:TreeNode Text="Jack" Icon="User" />
                                    <ext:TreeNode Text="Brian" Icon="User" />
                                    <ext:TreeNode Text="Jon" Icon="User" />
                                    <ext:TreeNode Text="Tim" Icon="User" />
                                    <ext:TreeNode Text="Nige" Icon="User" />
                                    <ext:TreeNode Text="Fred" Icon="User" />
                                    <ext:TreeNode Text="Bob" Icon="User" />
                                </Nodes>
                            </ext:TreeNode>
                            <ext:TreeNode Text="Family" Expanded="true">
                                <Nodes>
                                    <ext:TreeNode Text="Kelly" Icon="UserFemale" />
                                    <ext:TreeNode Text="Sara" Icon="UserFemale" />
                                    <ext:TreeNode Text="Zack" Icon="UserGreen" />
                                    <ext:TreeNode Text="John" Icon="UserGreen" />
                                </Nodes>
                            </ext:TreeNode>
                        </Nodes>
                    </ext:TreeNode>
                </Root>
            </ext:TreePanel>
            <ext:Panel runat="server" Title="Settings" />
            <ext:Panel runat="server" Title="Even More Stuff" />
            <ext:Panel runat="server" Title="My Stuff" />
        </Items>
    
    </ext:Window>
</body>
</html>
