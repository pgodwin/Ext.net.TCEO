<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Center Layout - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <ext:ResourceManager runat="server" />
    
    <ext:Viewport runat="server" Layout="Center">
        <Items>
            <ext:Panel 
                runat="server" 
                Title="Centered Panel: 75% of container width and fit height"
                AutoScroll="true"
                PaddingSummary="20px 0"
                Layout="Center">                        
                <CustomConfig>
                    <ext:ConfigItem Name="width" Value="75%" Mode="Value" />
                </CustomConfig>
                <Items>
                    <ext:Panel 
                        runat="server" 
                        Title="Inner Centered Panel" 
                        Width="300" 
                        Frame="true" 
                        AutoHeight="true"
                        PaddingSummary="10px 20px">
                        <Content>
                            Fixed 300px wide and auto height. The container panel will also autoscroll if narrower than 300px.
                        </Content>
                    </ext:Panel>
                </Items>                        
            </ext:Panel>
        </Items>
    </ext:Viewport>
</body>
</html>
