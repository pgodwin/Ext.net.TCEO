<%@ Page Language="C#" %>

<%@ Import Namespace="System.Collections.Generic" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            SiteMapNode siteNode = SiteMap.RootNode;
            TreeNodeBase node = this.CreateNodeWithOutChildren(siteNode);
            node.Draggable = false;
            node.Expanded = true;
            TreePanel1.Root.Add(node);
        }
    }

    //page tree node loader handler
    protected void LoadPages(object sender, NodeLoadEventArgs e)
    {
        if (!string.IsNullOrEmpty(e.NodeID))
        {
            SiteMapNode siteMapNode = SiteMap.Provider.FindSiteMapNodeFromKey(e.NodeID);
            
            if (siteMapNode == null)
            {
                return;
            }

            SiteMapNodeCollection children = siteMapNode.ChildNodes;

            if (children != null && children.Count > 0)
            {
                foreach (SiteMapNode mapNode in siteMapNode.ChildNodes)
                {
                    e.Nodes.Add(this.CreateNodeWithOutChildren(mapNode));
                }
            }
        }
    }

    //dynamic node creation
    private TreeNodeBase CreateNodeWithOutChildren(SiteMapNode siteMapNode)
    {
        TreeNodeBase treeNode;

        if (siteMapNode.ChildNodes != null && siteMapNode.ChildNodes.Count > 0)
        {
            treeNode = new AsyncTreeNode();
        }
        else
        {
            treeNode = new Ext.Net.TreeNode();
            treeNode.Leaf = true;
        }

        treeNode.NodeID = siteMapNode.Key;
        treeNode.Text = siteMapNode.Title;
        treeNode.Qtip = siteMapNode.Description;

        return treeNode;
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Drag and Drop betweens two TreePanels - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .tree {
    	    float  : left;
    	    margin : 20px;
    	    border : 1px solid #c3daf9;
        }
    </style>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>Drag and Drop betweens two TreePanels</h1>
        
        <p>The TreePanels have a TreeSorter applied in "folderSort" mode.</p>
        
        <p>Both TreePanels are in "appendOnly" drop mode since they are sorted.</p>
        
        <p>Drag along the edge of the tree to trigger auto scrolling while performing a drag and drop.</p>
        
        <div class="tree">
            <ext:TreePanel 
                ID="TreePanel1"
                runat="server" 
                Border="false"
                Height="300"
                Width="250"
                UseArrows="true"
                AutoScroll="true"
                Animate="true"
                EnableDD="true"
                ContainerScroll="true">     
                    <DropConfig runat="server" AppendOnly="true" />
                    
                    <Sorter FolderSort="true" />
                    
                    <Loader>
                        <ext:PageTreeLoader OnNodeLoad="LoadPages" />
                    </Loader>   
            </ext:TreePanel>
        </div>
        
        <div class="tree">
            <ext:TreePanel 
                ID="TreePanel2"
                runat="server" 
                Height="300"
                Width="250"
                Border="false"
                UseArrows="true"
                AutoScroll="true"
                Animate="true"
                EnableDD="true"
                ContainerScroll="true">     
                    <DropConfig runat="server" AppendOnly="true" />
                    
                    <Sorter FolderSort="true" />
                    
                    <Loader>
                        <ext:PageTreeLoader OnNodeLoad="LoadPages" />
                    </Loader>   
                    
                    <Root>
                        <ext:TreeNode Text="My Files" Icon="Folder" Expanded="true" />
                    </Root>
            </ext:TreePanel>
        </div>
    </form>
</body>
</html>