<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TreePanel using Ajax Method - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <script runat="server">

        [DirectMethod]
        public static string NodeLoad(string nodeID)
        {
            Ext.Net.TreeNodeCollection nodes = new Ext.Net.TreeNodeCollection();

            if (!string.IsNullOrEmpty(nodeID))
            {
                for (int i = 1; i < 6; i++)
                {
                    AsyncTreeNode asyncNode = new AsyncTreeNode();
                    asyncNode.Text = nodeID + i;
                    asyncNode.NodeID = nodeID + i;
                    nodes.Add(asyncNode);
                }

                for (int i = 6; i < 11; i++)
                {
                    Ext.Net.TreeNode treeNode = new Ext.Net.TreeNode();
                    treeNode.Text = nodeID + i;
                    treeNode.NodeID = nodeID + i;
                    treeNode.Leaf = true;
                    nodes.Add(treeNode);
                }
            }

            return nodes.ToJson();
        }
    </script>
    
    <script type="text/javascript">
        function nodeLoad(node) {
            Ext.net.DirectMethods.NodeLoad(node.id, {
                success: function (result) {
                    var data = eval("(" + result + ")");
                    node.loadNodes(data);
                },

                failure: function (errorMsg) {
                    Ext.Msg.alert('Failure', errorMsg);
                }
            });            
        }
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        
        <h1>TreePanel using Ajax Method</h1>         
        
        <ext:TreePanel 
            ID="TreePanel1" 
            runat="server" 
            Title="Tree" 
            AutoHeight="true" 
            Border="false">
            <Root>
                <ext:AsyncTreeNode NodeID="0" Text="Root" />
            </Root>
            <Listeners>
                <BeforeLoad Fn="nodeLoad" />
            </Listeners>
        </ext:TreePanel>       
    </form>
</body>
</html>