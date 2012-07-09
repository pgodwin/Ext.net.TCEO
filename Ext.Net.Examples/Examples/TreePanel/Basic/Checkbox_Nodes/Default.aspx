<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
    <title>TreePanel with Checkbox Enabled Nodes - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
        .complete .x-tree-node-anchor span {
            text-decoration : line-through;
            color : #777;
        }
    </style>
    
    <script type="text/javascript">
        var getTasks = function () {
            var msg = "", 
                selNodes = TreePanel1.getChecked();
                
            Ext.each(selNodes, function(node) {
                if (msg.length > 0) {
                    msg += ", ";
                }
                
                msg += node.text;
            });
            
            Ext.Msg.show({
                title    : "Completed Tasks", 
                msg      : msg.length > 0 ? msg : "None",
                icon     : Ext.Msg.INFO,
                minWidth : 200,
                buttons  : Ext.Msg.OK
            });
        };
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>TreePanel with Checkbox Enabled Nodes</h1>
        
        <p>This example demonstrates a simple checkbox selection in a TrePanel. The Checkbox is enabled on leaf nodes by simply setting Checked="true/false" at the node level.</p>
        
        <ext:TreePanel 
            ID="TreePanel1" 
            runat="server" 
            Title="My Task List"
            Icon="Accept"
            Height="400"
            Width="250"
            UseArrows="true"
            AutoScroll="true"
            Animate="true"
            EnableDD="true"
            ContainerScroll="true"
            RootVisible="false">
            <Root>
                <ext:TreeNode>
                    <Nodes>
                        <ext:TreeNode Text="To Do" Icon="Folder">
                            <Nodes>
                                <ext:TreeNode Text="Go jogging" Leaf="true" Checked="False" />
                                <ext:TreeNode Text="Take a nap" Leaf="true" Checked="False" />
                                <ext:TreeNode Text="Clean house" Leaf="true" Checked="False" />
                            </Nodes>
                        </ext:TreeNode>
                        
                        <ext:TreeNode Text="Grocery List" Icon="Folder">
                            <Nodes>
                                <ext:TreeNode Text="Bananas" Leaf="true" Checked="False" />
                                <ext:TreeNode Text="Milk" Leaf="true" Checked="False" />
                                <ext:TreeNode Text="Cereal" Leaf="true" Checked="False" />
                                
                                <ext:TreeNode Text="Energy foods" Icon="Folder">
                                    <Nodes>
                                        <ext:TreeNode Text="Coffee" Leaf="true" Checked="False" />
                                        <ext:TreeNode Text="Red Bull" Leaf="true" Checked="False" />
                                    </Nodes>
                                </ext:TreeNode>
                            </Nodes>
                        </ext:TreeNode>
                        
                        <ext:TreeNode Text="Kitchen Remodel" Icon="Folder">
                            <Nodes>
                                <ext:TreeNode Text="Finish the budget" Leaf="true" Checked="False" />
                                <ext:TreeNode Text="Call contractors" Leaf="true" Checked="False" />
                                <ext:TreeNode Text="Choose design" Leaf="true" Checked="False" />
                            </Nodes>
                        </ext:TreeNode>
                    </Nodes>
                </ext:TreeNode>
            </Root>
            
            <Listeners>
                <CheckChange Handler="node.getUI()[checked ? 'addClass' : 'removeClass']('complete')" />
                <Render Handler="this.getRootNode().expand(true);" Delay="50" />
            </Listeners>
            
            <Buttons>
                <ext:Button runat="server" Text="Get Completed Tasks">
                    <Listeners>
                        <Click Fn="getTasks" />
                    </Listeners>
                </ext:Button>
            </Buttons>
                  
         </ext:TreePanel>
    </form>
</body>
</html>