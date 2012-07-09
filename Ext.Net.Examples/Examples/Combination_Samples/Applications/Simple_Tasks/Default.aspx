<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Assembly="Ext.Net.Examples" Namespace="Ext.Net.Examples.SimpleTasks" TagPrefix="task" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Simple Tasks - Ext.NET Examples</title>    
    <ext:ResourcePlaceHolder runat="server" Mode="ScriptFiles" />
    <link href="resources/main.css" rel="stylesheet" type="text/css" />
    <script src="resources/main.js" type="text/javascript"></script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager 
            runat="server" 
            InitScriptMode="Linked"
            DirectEventUrl="Default.aspx" 
            RemoveViewState="true" 
            IDMode="Explicit"
            />
        
        <ext:Viewport runat="server" Layout="border">
            <Items>
                <task:TasksTopBar 
                    runat="server" 
                    Region="North" 
                    />
                <task:TasksTree 
                    ID="TasksTree1"
                    runat="server" 
                    Region="West" 
                    Margins="3 0 3 3" 
                    CMargins="3 3 3 3" 
                    MinWidth="120" 
                    Split="true"
                    />
                <task:TasksGrid 
                    ID="TasksGrid1"
                    runat="server" 
                    Region="Center" 
                    Margins="3 3 3 0"
                    />                         
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
