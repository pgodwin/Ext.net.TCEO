<%@ Page Language="C#" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Import Namespace="System.Collections.Generic" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
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
            node.NodeID = i.ToString();
            node.Text = prefix + i;
            root.Nodes.Add(node);
        }

        return nodes;
    }

    protected void RemoteRename(object sender, RemoteRenameEventArgs e)
    {
        e.Accept = true;

        // 1. You can set own text
        //    e.NewText = e.NewText + "_echo";
        
        // 2. You can refuse action
        //    e.Accept = false;
        //    e.RefusalMessage = "Error";
    }

    protected void RemoteRemove(object sender, RemoteActionEventArgs e)
    {
        e.Accept = true;
    }

    protected void RemoteAppend(object sender, RemoteAppendEventArgs e)
    {
        e.Accept = true;
        e.Text = e.Text + "_new";
    }

    protected void RemoteMove(object sender, RemoteMoveEventArgs e)
    {
        e.Accept = true;
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Remote mode - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
        .bold-text{
            font-weight:bold;
            padding-left: 25px;
            font-size:110%;
        }
    </style>
    
    <script type="text/javascript">
        function showMenu(node, e){            
            var menu = TreeContextMenu;
            if (node.browserEvent) {			    		    
			    this.menuNode = this.getRootNode(); 
                menu.nodeName = "";
                this.getSelectionModel().clearSelections();                
                e = node;
		    }
		    else {			    
			    this.menuNode = node; 
                menu.nodeName = node.text;                
			    node.select();	
		    }
		    
		    menu.showAt([e.getXY()[0], e.getXY()[1]+18]);
		    e.stopEvent();
        }
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>Remote mode</h1>
        
        <p>This example demomstrates remote mode of the TreePanel : remote confirmation of basic operations (rename, remove, append/insert, drag/drop)</p>
        
        <p>The remote mode is activating if set Mode="Remote"</p>
        
        <p>You can define particular action as local even if Mode="Remote" (LocalActions property)</p>
        <p>List of available values for LocalActions: rename, remove, append, insert, move</p>
        
        <ext:Menu ID="TreeContextMenu" runat="server" EnableScrolling="false">
            <Items>
                <ext:MenuTextItem ID="NodeName" runat="server" Cls="bold-text" />
                <ext:MenuSeparator />
                <ext:MenuItem runat="server" Text="Rename" Icon="Pencil">
                    <Listeners>
                        <Click Handler="#{TreePanel1}.startEdit(#{TreePanel1}.menuNode, 10);" />
                    </Listeners>
                </ext:MenuItem>
                
                <ext:MenuItem runat="server" Text="Remove" Icon="Delete">
                    <Listeners>
                        <Click Handler="#{TreePanel1}.removeNode(#{TreePanel1}.menuNode);" />
                    </Listeners>
                </ext:MenuItem>
                
                <ext:MenuItem runat="server" Text="Append child" Icon="Add">
                    <Listeners>
                        <Click Handler="#{TreePanel1}.appendChild(#{TreePanel1}.menuNode, 'New');" />
                    </Listeners>
                </ext:MenuItem>
                
                <ext:MenuItem runat="server" Text="Insert child" Icon="ArrowRight">
                    <Listeners>
                        <Click Handler="#{TreePanel1}.appendChild(#{TreePanel1}.menuNode, 'New', true);" />
                    </Listeners>
                </ext:MenuItem>
            </Items>
            <Listeners>
                <Show Handler="#{NodeName}.el.update(this.nodeName);" />
            </Listeners>
        </ext:Menu>
        
        <ext:TreePanel 
            ID="TreePanel1"
            runat="server" 
            Height="300" 
            Width="250"
            UseArrows="true"
            AutoScroll="true"
            Animate="true"
            EnableDD="true"
            Mode="Remote"
            RootVisible="false"
            AllowLeafDrop="true"
            ContainerScroll="true"
            OnRemoteRename="RemoteRename"
            OnRemoteRemove="RemoteRemove"
            OnRemoteAppend="RemoteAppend"
            OnRemoteMove="RemoteMove"
            >                        
            <Editors>
                <ext:TreeEditor runat="server" CancelOnBlur="true">
                    <Field>
                        <ext:TextField runat="server"/>
                    </Field>
                </ext:TreeEditor>
            </Editors>
            <SelectionSubmitConfig Encode="true" />
            
            <Listeners>
                <ContextMenu Fn="showMenu" StopEvent="true" />
            </Listeners>
        </ext:TreePanel>
    </form>
</body>
</html>