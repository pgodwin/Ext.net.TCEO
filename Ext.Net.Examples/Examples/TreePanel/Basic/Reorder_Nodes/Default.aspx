<%@ Page Language="C#" %>

<%@ Import Namespace="System.Collections.Generic" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        SiteMapNode siteNode = SiteMap.RootNode;
        Ext.Net.TreeNode root = this.CreateNode(siteNode);
        root.Draggable = false;
        root.Expanded = true;
        TreePanel1.Root.Add(root);
    }

    //static node creation with children
    private Ext.Net.TreeNode CreateNode(SiteMapNode siteMapNode)
    {
        Ext.Net.TreeNode treeNode = new Ext.Net.TreeNode();
        
        treeNode.NodeID = siteMapNode.Key;
        treeNode.Text = siteMapNode.Title;
        treeNode.Qtip = siteMapNode.Description;

        SiteMapNodeCollection children = siteMapNode.ChildNodes;

        if (children != null && children.Count > 0)
        {
            foreach (SiteMapNode mapNode in siteMapNode.ChildNodes)
            {
                treeNode.Nodes.Add(this.CreateNode(mapNode));
            }
        }
        
        return treeNode;
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Drag and Drop ordering of TreePanel Nodes - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        var moveNode = function (tree, node, oldParent, newParent, index) {
            var buf=[];
            buf.push("Node = "+node.text);
            buf.push("<br/>");
            buf.push("Old parent = "+oldParent.text);
            buf.push("<br/>");
            buf.push("New parent = "+newParent.text);
            buf.push("<br/>");
            buf.push("Index = "+index);
            
            Ext.Msg.alert("Node droped", buf.join(""));
        }
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>Drag and Drop ordering of TreePanel Nodes</h1>
        
        <p>This example shows basic drag and drop node moving in a tree. In this implementation there are no restrictions and 
        anything can be dropped anywhere except appending to nodes marked "leaf".</p>
        
        <p>Drag along the edge of the tree to trigger auto scrolling while performing a drag and drop.</p>
        
        <p>In order to demonstrate drag and drop insertion points, sorting was <b>not</b> enabled.</p>
        
        <ext:TreePanel 
            ID="TreePanel1"
            runat="server" 
            Height="300" 
            Width="250"
            UseArrows="true"
            AutoScroll="true"
            Animate="true"
            EnableDD="true"
            ContainerScroll="true">            
            <Listeners>
                <MoveNode Fn="moveNode" />
            </Listeners>
        </ext:TreePanel>
    </form>
</body>
</html>