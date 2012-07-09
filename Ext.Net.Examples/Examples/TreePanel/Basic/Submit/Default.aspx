<%@ Page Language="C#" %>

<%@ Import Namespace="TreeNode=Ext.Net.TreeNode" %>
<%@ Import Namespace="TreeNodeCollection=Ext.Net.TreeNodeCollection" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

 <script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            this.BuildTree(this.TreePanel1.Root);
        }
    }

    private TreeNodeCollection BuildTree(TreeNodeCollection nodes)
    {
        if (nodes == null)
        {
            nodes = new TreeNodeCollection();
        }
        
        TreeNode root = new TreeNode();
        root.Text = "Root";
        nodes.Add(root);
        
        bool submit = true;
        
        for (int i = 0; i < 10; i++)
        {
            TreeNode node = new TreeNode();
            node.NodeID = (i + 1).ToString();
            node.Text = "Node" + (i + 1);
            node.CustomAttributes.Add(new ConfigItem("submit", JSON.Serialize(submit), ParameterMode.Raw));
            root.Nodes.Add(node);
            submit = !submit;
        }

        return nodes;
    }

    protected void SubmitNodes(object sender, SubmitEventArgs e)
    {
        X.Msg.Alert("Submit", "You have submitted " + e.RootNode.Children.Count + " nodes").Show();
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
    <title>TreePanel Submit - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>TreePanel Submit</h1>
        
        <ext:TreePanel 
            ID="TreePanel1" 
            runat="server" 
            Icon="Anchor" 
            Title="Tree"
            AutoScroll="true" 
            Width="550" 
            RootVisible="False"
            OnSubmit="SubmitNodes">
            <Buttons>
                <ext:Button runat="server" Text="Simple Submit">
                    <Listeners>
                        <Click Handler="#{TreePanel1}.submitNodes();" />
                    </Listeners>
                </ext:Button>
                
                <ext:Button runat="server" Text="Submit with Callback">
                    <Listeners>
                        <Click Handler="#{TreePanel1}.submitNodes({text : 'Submit finish', callback : function(o, success, r) { alert(o.text + ', Status : ' + success); }});" />
                    </Listeners>
                </ext:Button>
                
                <ext:Button runat="server" Text="Submit with Node Filter">
                    <Listeners>
                        <Click Handler="#{TreePanel1}.submitNodes({ nodeFilter : function (node) { return node.attributes.submit || node.isRoot;}});" />
                    </Listeners>
                </ext:Button>

            </Buttons>            
         </ext:TreePanel>
    </form>
</body>
</html>