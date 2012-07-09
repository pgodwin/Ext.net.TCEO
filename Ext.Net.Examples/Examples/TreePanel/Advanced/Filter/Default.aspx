<%@ Page Language="C#" %>
<%@ Import Namespace="TreeNode=Ext.Net.TreeNode" %>

<%@ Import Namespace="System.Collections.Generic" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        SiteMapNode siteNode = SiteMap.RootNode;
        TreeNode root = this.CreateNode(siteNode);
        root.Draggable = false;
        root.Expanded = true;
        TreePanel1.Root.Add(root);
    }

    //static node creation with children
    private Ext.Net.TreeNode CreateNode(SiteMapNode siteMapNode)
    {
        TreeNode treeNode = new TreeNode();
        
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
    <title>Tree Filter - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript">
        var filterTree = function (el, e) {
            var tree = TreePanel1,
                text = this.getRawValue();
            
            tree.clearFilter();
            
            if (Ext.isEmpty(text, false)){
                return;
            }
            
            if (e.getKey() === Ext.EventObject.ESC) {
                clearFilter();
            } else {
                var re = new RegExp(".*" + text + ".*", "i");
                
                tree.filterBy(function (node) {
                    return re.test(node.text);
                });
            }
        };
        
        var clearFilter = function () {
            var field = TriggerField1,
                tree = TreePanel1;
            
            field.setValue(""); 
            tree.clearFilter(); 
            tree.getRootNode().collapseChildNodes(true);
            tree.getRootNode().ensureVisible();
        };
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>Tree Filter</h1>
        
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
            <TopBar>
                <ext:Toolbar runat="server">
                    <Items>
                        <ext:ToolbarTextItem runat="server" Text="Filter:" />
                        <ext:ToolbarSpacer />
                        <ext:TriggerField ID="TriggerField1" runat="server" EnableKeyEvents="true">
                            <Triggers>
                                <ext:FieldTrigger Icon="Clear" />
                            </Triggers>
                            
                            <Listeners>
                                <KeyUp Fn="filterTree" Buffer="250" />
                                <TriggerClick Handler="clearFilter();" />
                            </Listeners>
                        </ext:TriggerField>
                    </Items>
                </ext:Toolbar>
            </TopBar>
        </ext:TreePanel>
    </form>
</body>
</html>