<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TreePanel with Async TreeLoader using Page - Ext.NET Examples</title>
    
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <script runat="server">
        protected void NodeLoad(object sender, NodeLoadEventArgs e)
        {
            string prefix = e.ExtraParams["prefix"] ?? "";

            if (!string.IsNullOrEmpty(e.NodeID))
            {
                for (int i = 1; i < 6; i++)
                {
                    AsyncTreeNode asyncNode = new AsyncTreeNode();
                    asyncNode.Text = prefix + e.NodeID + i;
                    asyncNode.NodeID = e.NodeID + i;
                    e.Nodes.Add(asyncNode);
                }

                for (int i = 6; i < 11; i++)
                {
                    Ext.Net.TreeNode treeNode = new Ext.Net.TreeNode();
                    treeNode.Text = prefix + e.NodeID + i;
                    treeNode.NodeID = e.NodeID + i;
                    treeNode.Leaf = true;
                    e.Nodes.Add(treeNode);
                }
            }
        }
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        
        <h1>TreePanel using PageTreeLoader</h1> 
        
        <p>Set custom node prefix: </p>
        <ext:TextField ID="TextField1" runat="server" Text="Node" />
        
        <ext:TreePanel 
            ID="TreePanel1" 
            runat="server" 
            Title="Tree" 
            AutoHeight="true" 
            Border="false">
            <Loader>
                <ext:PageTreeLoader OnNodeLoad="NodeLoad">
                    <BaseParams>
                        <ext:Parameter Name="prefix" Value="#{TextField1}.getValue()" Mode="Raw" />
                    </BaseParams>
                </ext:PageTreeLoader>
            </Loader>
            <Root>
                <ext:AsyncTreeNode NodeID="0" Text="Root" />
            </Root>
        </ext:TreePanel>       
    </form>
</body>
</html>