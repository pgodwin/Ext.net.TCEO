<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        TreePanel tree = new TreePanel();

        tree.Title = "Online Users";
        tree.RootVisible = false;

        tree.Tools.Add(new Tool(ToolType.Refresh,X.Msg.Alert("Message", "Refresh Tool Clicked!").ToScript(), ""));

        Ext.Net.TreeNode root = new Ext.Net.TreeNode();
        root.NodeID = "root";

        tree.Root.Add(root);
        
        Ext.Net.TreeNode node1 = new Ext.Net.TreeNode();
        
        node1.Text = "Friends";
        node1.Expanded = true;
        
        node1.Nodes.Add(new Ext.Net.TreeNode("Jack", Icon.User));
        node1.Nodes.Add(new Ext.Net.TreeNode("Brian", Icon.User));
        node1.Nodes.Add(new Ext.Net.TreeNode("Jon", Icon.User));
        node1.Nodes.Add(new Ext.Net.TreeNode("Tim", Icon.User));
        node1.Nodes.Add(new Ext.Net.TreeNode("Nige", Icon.User));
        node1.Nodes.Add(new Ext.Net.TreeNode("Fred", Icon.User));
        node1.Nodes.Add(new Ext.Net.TreeNode("Bob", Icon.User));

        root.Nodes.Add(node1);

        Ext.Net.TreeNode node2 = new Ext.Net.TreeNode();
        node2.Text = "Family";
        node2.Expanded = true;
        
        node2.Nodes.Add(new Ext.Net.TreeNode("Kelly", Icon.UserFemale));
        node2.Nodes.Add(new Ext.Net.TreeNode("Sara", Icon.UserFemale));
        node2.Nodes.Add(new Ext.Net.TreeNode("Zack", Icon.UserGreen));
        node2.Nodes.Add(new Ext.Net.TreeNode("John", Icon.UserGreen));

        root.Nodes.Add(node2);
        
        Ext.Net.Panel panel1 = new Ext.Net.Panel("Settings");
        Ext.Net.Panel panel2 = new Ext.Net.Panel("Even More Stuff");
        Ext.Net.Panel panel3 = new Ext.Net.Panel("My Stuff");

        Toolbar toolbar = new Toolbar();

        Ext.Net.Button button1 = new Ext.Net.Button();
        button1.Icon = Icon.Connect;

        ToolTip tooltip = new ToolTip();
        tooltip.Title = "Rich ToolTips";
        tooltip.Html = "Let your users know what they can do!";

        button1.ToolTips.Add(tooltip);
        
        Ext.Net.Button button2 = new Ext.Net.Button();
        button2.Icon = Icon.UserAdd;
        
        Ext.Net.Button button3 = new Ext.Net.Button();
        button3.Icon = Icon.UserDelete;

        toolbar.Items.Add(button1);
        toolbar.Items.Add(button2);
        toolbar.Items.Add(button3);
        
        Window window = new Window();

        window.Title = "Accordion Window";
        window.Width = Unit.Pixel(250);
        window.Height = Unit.Pixel(400);
        window.Maximizable = true;
        window.Icon = Icon.ApplicationTileVertical;
        window.BodyBorder = false;
        window.Layout = "Accordion";

        window.TopBar.Add(toolbar);

        window.Items.Add(tree);
        window.Items.Add(panel1);
        window.Items.Add(panel2);
        window.Items.Add(panel3);

        this.PlaceHolder1.Controls.Add(window);
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AccordionLayout in Code-Behind - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
    
    <h1>Accordion Layout in Code-Behind</h1>
    
    <asp:PlaceHolder ID="PlaceHolder1" runat="server" />
</body>
</html>
