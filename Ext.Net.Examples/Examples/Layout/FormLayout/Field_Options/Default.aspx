<%@ Page Language="C#" %>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FormLayout Overview - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
        .blueborder {
        	border: dotted 1px blue;
        	padding:1px 0px;
        }
    </style>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
            
        <ext:Panel 
            runat="server" 
            Frame="true" 
            Title="Label Style and Separator" 
            Width="400"
            LabelSeparator="-" 
            LabelWidth="55"
            Layout="Form">
            <Defaults>
                <ext:Parameter Name="LabelStyle" Value="color:red;" Mode="Value" />
            </Defaults>
            <Items>
                <ext:TextField runat="server" FieldLabel="Label" AnchorHorizontal="95%" />
                <ext:TextField 
                    runat="server" 
                    FieldLabel="Label" 
                    LabelStyle="color:blue;" 
                    LabelSeparator="+" 
                    AnchorHorizontal="95%" 
                    />
            </Items>
        </ext:Panel>
        
        <br />
        
        <ext:Panel 
            ID="Panel1" 
            runat="server" 
            Frame="true" 
            Title="Without labels" 
            Width="400" 
            HideLabels="true"
            Layout="Form">
            <Items>
                <ext:TextField runat="server" FieldLabel="Label" AnchorHorizontal="95%" />
                <ext:TextField runat="server" FieldLabel="Label" AnchorHorizontal="95%" />
            </Items>
        </ext:Panel>
    
        <br />
        
        <ext:Panel 
            ID="Panel2" 
            runat="server" 
            Frame="true" 
            Title="Item style" 
            Width="400"
            ItemCls="blueborder"
            Layout="Form">
            <Items>
                <ext:TextField runat="server" FieldLabel="Label" AnchorHorizontal="95%" />
                <ext:TextField runat="server" FieldLabel="Label" AnchorHorizontal="95%" />
            </Items>
        </ext:Panel>
        
        <br />
        
        <ext:Panel 
            ID="Panel3" 
            runat="server" 
            Frame="true" 
            Title="Label Top Align" 
            Width="400"
            LabelAlign="Top"
            Layout="Form">
            <Items>
                <ext:TextField runat="server" FieldLabel="Label" AnchorHorizontal="95%" />
                <ext:TextField runat="server" FieldLabel="Label" AnchorHorizontal="95%" />
            </Items>
        </ext:Panel>
    </form>
</body>
</html>


