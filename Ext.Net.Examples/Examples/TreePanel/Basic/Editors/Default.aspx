<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

 <script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            this.BuildTree(TreePanel1.Root);
            this.BuildTree(TreePanel2.Root);
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

        for (int i = 0; i < 3; i++)
        {
            Ext.Net.TreeNode node = new Ext.Net.TreeNode();
            node.Text = "TextField node";
            node.CustomAttributes.Add(new ConfigItem("editor", "1", ParameterMode.Value));
            root.Nodes.Add(node);

            node = new Ext.Net.TreeNode();
            node.Text = "1";
            node.CustomAttributes.Add(new ConfigItem("editor", "2", ParameterMode.Value));
            root.Nodes.Add(node);

            node = new Ext.Net.TreeNode();
            node.Text = "ComboBox node";
            node.CustomAttributes.Add(new ConfigItem("editor", "3", ParameterMode.Value));
            root.Nodes.Add(node);
        }

        return nodes;
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
    <title>TreePanel with Editor - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .note-cls {
            background-color : silver !important;
            border : dotted 1px black;
            color : black !important;
        }
    </style>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>TreePanel with Editor</h1>
        
        <h3>Tree Editor Filter</h3>
        
        <ext:TreePanel 
            ID="TreePanel1" 
            runat="server" 
            Icon="Anchor" 
            Title="Tree Editors Filter"
            AutoScroll="true" 
            Width="250" 
            Collapsed="False" 
            CollapseFirst="True" 
            HideParent="False"
            RootVisible="False">    
            <Editors>
                <ext:TreeEditor runat="server">
                    <Field>
                        <ext:TextField runat="server" />
                    </Field>
                    <Filter Attribute="editor" Value="1" />
                </ext:TreeEditor>
                
                <ext:TreeEditor runat="server">
                    <Field>
                        <ext:NumberField runat="server" />
                    </Field>
                    <Filter Attribute="editor" Value="2" />
                </ext:TreeEditor>
                
                <ext:TreeEditor runat="server">
                    <Field>
                        <ext:ComboBox runat="server" ForceSelection="true">
                            <Items>
                                <ext:ListItem Text="Item 1" />
                                <ext:ListItem Text="Item 2" />
                            </Items>
                        </ext:ComboBox>
                    </Field>
                    <Filter Attribute="editor" Value="3" />
                </ext:TreeEditor>
            </Editors>      
         </ext:TreePanel>
         
        <h3>TreePanel with Active Editor</h3>
        
        <ext:TreePanel 
            ID="TreePanel2" 
            runat="server" 
            Icon="Anchor" 
            Title="Tree Active Editor"
            AutoScroll="true" 
            Width="250" 
            Collapsed="False" 
            CollapseFirst="True" 
            HideParent="False"
            ActiveEditor="Editor1"
            RootVisible="False">    
            <TopBar>
                <ext:Toolbar runat="server">
                    <Items>
                        <ext:Button runat="server" Text="Editor1" ToggleGroup="editor" Pressed="true">
                            <Listeners>
                                <Click Handler="#{TreePanel2}.activeEditor = '#{Editor1}';" />
                            </Listeners>
                        </ext:Button>
                        
                        <ext:Button runat="server" Text="Editor2" ToggleGroup="editor">
                            <Listeners>
                                <Click Handler="#{TreePanel2}.activeEditor = '#{Editor2}';" />
                            </Listeners>
                        </ext:Button>
                        
                        <ext:Button runat="server" Text="Editor3" ToggleGroup="editor">
                            <Listeners>
                                <Click Handler="#{TreePanel2}.activeEditor = '#{Editor3}';" />
                            </Listeners>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <Editors>
                <ext:TreeEditor ID="Editor1" runat="server" Shadow="None">
                    <Field>
                        <ext:TextField runat="server" Note="Custom Aligned Editor" NoteCls="note-cls" />
                    </Field>
                    <Alignment TargetAnchor="BottomLeft" ElementAnchor="TopLeft" />                    
                </ext:TreeEditor>
                
                <ext:TreeEditor ID="Editor2" runat="server">
                    <Field>
                        <ext:NumberField runat="server" />
                    </Field>                    
                </ext:TreeEditor>
                
                <ext:TreeEditor ID="Editor3" runat="server">
                    <Field>
                        <ext:ComboBox runat="server" ForceSelection="true">
                            <Items>
                                <ext:ListItem Text="Item 1" />
                                <ext:ListItem Text="Item 2" />
                            </Items>
                        </ext:ComboBox>
                    </Field>
                </ext:TreeEditor>
            </Editors>      
         </ext:TreePanel>
    </form>
</body>
</html>