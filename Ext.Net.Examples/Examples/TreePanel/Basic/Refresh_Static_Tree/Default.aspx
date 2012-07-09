<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack && !X.IsAjaxRequest)
        {
            this.BuildTree(TreePanel1.Root);
        }
    }

    private Ext.Net.TreeNodeCollection BuildTree(Ext.Net.TreeNodeCollection nodes)
    {
        if (nodes == null)
        {
            nodes = new Ext.Net.TreeNodeCollection();
        }
        
        Ext.Net.TreeNode root = new Ext.Net.TreeNode();
        root.Text = "Root";
        nodes.Add(root);

        string prefix = DateTime.Now.Second + "_";
        for (int i = 0; i < 10; i++)
        {
            Ext.Net.TreeNode node = new Ext.Net.TreeNode();
            node.Text = prefix + i;
            root.Nodes.Add(node);
        }

        return nodes;
    }

    [DirectMethod]
    public string RefreshMenu()
    {
        Ext.Net.TreeNodeCollection nodes = this.BuildTree(null);

        return nodes.ToJson();
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
    <title>SiteMap - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        var refreshTree = function (tree) {            
            Ext.net.DirectMethods.RefreshMenu({
                success : function (result) {
                    var nodes = eval(result);
                    if(nodes.length > 0){
                        tree.initChildren(nodes);
                    }
                    else{
                        tree.getRootNode().removeChildren();
                    }
                }
            });
        }
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <ext:TreePanel 
            ID="TreePanel1" 
            runat="server" 
            Icon="Anchor" 
            Title="Tree"
            AutoScroll="true" 
            Width="250" 
            Collapsed="False" 
            CollapseFirst="True" 
            HideParent="False"
            RootVisible="False" 
            BodyStyle="padding-left:10px">
            <Tools>            
                <ext:Tool Type="Refresh" Qtip="Refresh" Handler="refreshTree(#{TreePanel1});" />
            </Tools>
         </ext:TreePanel>
    </form>
</body>
</html>