<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TriggerField with Icons - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <ext:ResourceManager runat="server" />
    
    <h1>TriggerField with Icons</h1>
    
    <h2>TriggerField</h2>
    
    <ext:TriggerField runat="server">
        <Triggers>
            <ext:FieldTrigger Icon="SimpleEllipsis" />
            <ext:FieldTrigger Icon="SimpleMagnify" />
            <ext:FieldTrigger Icon="SimplePlus" />
        </Triggers>
    </ext:TriggerField>
    
   <h2>ComboBox</h2>
   
    <ext:ComboBox runat="server" TriggerIcon="SimpleArrowDown">
        <Items>
            <ext:ListItem Text="Item 1" />
            <ext:ListItem Text="Item 2" />
            <ext:ListItem Text="Item 3" />
            <ext:ListItem Text="Item 4" />
            <ext:ListItem Text="Item 5" />
        </Items>
        <Triggers>
            <ext:FieldTrigger Icon="SimpleEllipsis" />
            <ext:FieldTrigger Icon="SimpleMagnify" />
            <ext:FieldTrigger Icon="SimplePlus" />
        </Triggers>
    </ext:ComboBox>
    
    <h2>DateField</h2>
   
    <ext:DateField runat="server" TriggerIcon="SimpleDate" />
    
    <h2>TimeField</h2>
   
    <ext:TimeField runat="server" TriggerIcon="SimpleTime" />
</html>
