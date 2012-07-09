<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DragDrop from TreePanel to Div - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript">
        var notifyDrop = function (dd, e, data) {
            var msg = [];
            
            msg.push("<p><b>Node</b></p><ul>");
            msg.push("<li>id : " + data.node.id + "</li>");
            msg.push("<li>text : " + data.node.text + "</li>");
            msg.push("<li>leaf : " + data.node.leaf + "</li>");
            msg.push("<li>data : " + data.node.attributes.data + "</li>");
            msg.push("</ul>");
            
            Ext.get("drop-target").update(msg.join(""))
            return true;
        }
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>DragDrop from TreePanel to Div</h1>
        
        <ext:Panel runat="server" Width="600" Height="400" Layout="Border">
            <Items>
                <ext:TreePanel 
                    runat="server" 
                    EnableDrag="true"                            
                    DDGroup="tree2div"
                    Region="West"
                    Split="true"
                    Margins="5 0 5 5"
                    Width="200"
                    Title="Tree"
                    AutoScroll="true"
                    Collapsible="true">
                    <Root>
                        <ext:TreeNode Text="Root" Expanded="true" SingleClickExpand="true">
                            <Nodes>
                                <ext:TreeNode Text="Folder 1" SingleClickExpand="true">
                                    <CustomAttributes>
                                        <ext:ConfigItem Name="data" Value="Folder 1 data" Mode="Value" />
                                    </CustomAttributes>
                                    <Nodes>
                                        <ext:TreeNode Text="Child 1" Leaf="true">
                                            <CustomAttributes>
                                                <ext:ConfigItem Name="data" Value="Folder 1 Child 1 data" Mode="Value" />
                                            </CustomAttributes>
                                        </ext:TreeNode>
                                    </Nodes>
                                </ext:TreeNode>
                                
                                <ext:TreeNode Text="Folder 2" SingleClickExpand="true">
                                    <CustomAttributes>
                                        <ext:ConfigItem Name="data" Value="Folder 2 data" Mode="Value" />
                                    </CustomAttributes>
                                    <Nodes>
                                        <ext:TreeNode Text="Child 2" Leaf="true">
                                            <CustomAttributes>
                                                <ext:ConfigItem Name="data" Value="Folder 2 Child 2 data" Mode="Value" />
                                            </CustomAttributes>
                                        </ext:TreeNode>
                                    </Nodes>
                                </ext:TreeNode>
                                
                                <ext:TreeNode Text="Leaf 1" Leaf="true">
                                    <CustomAttributes>
                                        <ext:ConfigItem Name="data" Value="Leaf 1 data" Mode="Value" />
                                    </CustomAttributes>
                                </ext:TreeNode>
                            </Nodes>
                        </ext:TreeNode>
                    </Root>
                    
                    <Listeners>
                        <StartDrag Handler="Ext.fly('drop-target').applyStyles({'background-color':'#f0f0f0'});" />
                        <EndDrag Handler="Ext.fly('drop-target').applyStyles({'background-color':'white'});" />
                    </Listeners>
                </ext:TreePanel>
            
                <ext:Panel 
                    runat="server" 
                    Title="Target"
                    Region="Center"
                    Margins="5 5 5 0">
                    <Content>
                        <div id="drop-target" style="border:1px silver solid;margin:20px;padding:8px;height:140px">
                            Drop Node Here
                        </div>
                    </Content>
                </ext:Panel>
            </Items>
        </ext:Panel> 
        
        <ext:DropTarget runat="server" Target="drop-target" Group="tree2div">
            <NotifyDrop Fn="notifyDrop" />
        </ext:DropTarget>
    </form>
</body>
</html>
