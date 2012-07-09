<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Original Header - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <ext:ResourceManager runat="server" />
    
    <ext:Viewport runat="server" Layout="Border">
        <Items> 
            <ext:Panel runat="server" Width="300" Border="false" Region="West" Layout="VBox">
                <LayoutConfig>
                    <ext:VBoxLayoutConfig Padding="5" Align="Stretch" />
                </LayoutConfig>
                <Items>
                    <ext:Panel runat="server" Flex="1" Layout="Accordion" Margins="0 0 15 0">
                        <LayoutConfig>
                            <ext:AccordionLayoutConfig OriginalHeader="true" />
                        </LayoutConfig>
                        <Items>
                            <ext:Panel runat="server" Title="Item 1" Border="false" />
                            <ext:Panel runat="server" Title="Item 2" Border="false" />
                            <ext:Panel runat="server" Title="Item 3" Border="false" />
                            <ext:Panel runat="server" Title="Item 4" Border="false" />
                            <ext:Panel runat="server" Title="Item 5" Border="false" />
                        </Items>
                    </ext:Panel>
                    
                    <ext:Panel runat="server" Flex="1" Layout="Accordion">
                        <LayoutConfig>
                            <ext:AccordionLayoutConfig OriginalHeader="true" />
                        </LayoutConfig>
                        <Items>
                            <ext:Panel runat="server" Title="Item 1" FormGroup="true" />
                            <ext:Panel runat="server" Title="Item 2" FormGroup="true" />
                            <ext:Panel runat="server" Title="Item 3" FormGroup="true" />
                            <ext:Panel runat="server" Title="Item 4" FormGroup="true" />
                            <ext:Panel runat="server" Title="Item 5" FormGroup="true" />
                        </Items>
                    </ext:Panel>
                </Items>
            </ext:Panel>
            
            <ext:Panel runat="server" Margins="5" Region="Center" Padding="10">
                <Content>
                    <h1>Original header of the Accordion's item</h1>
                </Content>
            </ext:Panel>
        </Items>
    </ext:Viewport>
</body>
</html>
