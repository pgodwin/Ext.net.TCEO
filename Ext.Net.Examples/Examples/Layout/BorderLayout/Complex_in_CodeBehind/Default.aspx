<%@ Page Language="C#" Debug="true" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        /////////////////
        // WEST REGION //
        /////////////////
        
        // Make Panel for West Region
        Ext.Net.Panel west = new Ext.Net.Panel();
        west.ID = "WestPanel";
        west.Width = Unit.Pixel(175);
        
        // Make Navigation Panel for Accordion
        Ext.Net.Panel pnlNavigation = new Ext.Net.Panel();
        pnlNavigation.ID = "Navigation";
        pnlNavigation.Title = "Navigation";
        pnlNavigation.Border = false;
        pnlNavigation.BodyStyle = "padding:6px;";
        pnlNavigation.Icon = Icon.FolderGo;
        pnlNavigation.Html = "West";

        // Make Settings Panel for Accordion
        Ext.Net.Panel pnlSettings = new Ext.Net.Panel();
        pnlSettings.ID = "Settings";
        pnlSettings.Title = "Settings";
        pnlSettings.Border = false;
        pnlSettings.BodyStyle = "padding:6px;";
        pnlSettings.Icon = Icon.FolderWrench;
        pnlSettings.Html = "Some settings in here";        
     
        // Make Accordion container
        AccordionLayout acc = new AccordionLayout();
        acc.Animate = true;
        
        // Add Navigation and Settings Panels to Accordion
        acc.Items.Add(pnlNavigation);
        acc.Items.Add(pnlSettings);
        
        // Add Accordion to West Panel
        west.Items.Add(acc);
        

        ///////////////////
        // CENTER REGION //
        ///////////////////   

        // Make TabPanel for Center Region
        TabPanel center = new TabPanel();
        center.ID = "CenterPanel";
        center.ActiveTabIndex = 0;
        
        // Make Tab
        Ext.Net.Panel tab1 = new Ext.Net.Panel();
        tab1.ID = "Tab1";
        tab1.Title = "Close Me";
        tab1.Closable = true;
        tab1.Border = false;
        tab1.BodyStyle = "padding:6px;";
        tab1.Html = "Hello...";
        
        Ext.Net.Panel tab2 = new Ext.Net.Panel();
        tab2.ID = "Tab2";
        tab2.Title = "Center";
        tab2.Border = false;
        tab2.BodyStyle = "padding:6px;";
        tab2.Html = "...World";
     
        // Add Tab's to TabPanel
        center.Items.Add(tab1);
        center.Items.Add(tab2);

        
        /////////////////
        // EAST REGION //
        /////////////////
        
        // Make Panel for East Region
        Ext.Net.Panel east = new Ext.Net.Panel();
        east.ID = "EastPanel";
        east.Title = "East";
        east.Width = Unit.Pixel(225);
        
        // Make TabPanel for East Panel
        TabPanel tpEast = new TabPanel();
        tpEast.ActiveTabIndex = 1;
        tpEast.TabPosition = TabPosition.Bottom;
        tpEast.Border = false;
        
        // Make Tab 1
        Ext.Net.Panel tabEast1 = new Ext.Net.Panel();
        tabEast1.Title = "Tab 1";
        tabEast1.Border = false;
        tabEast1.BodyStyle = "padding:6px;";
        tabEast1.Html = "East Tab 1";
        
        // Make Tab 2
        Ext.Net.Panel tabEast2 = new Ext.Net.Panel();
        tabEast2.Title = "Tab 2";
        tabEast2.Border = false;
        tabEast2.BodyStyle = "padding:6px;";
        tabEast2.Html = "East Tab 2";
        
        // Add Tab's to East TabPanel
        tpEast.Items.Add(tabEast1);
        tpEast.Items.Add(tabEast2);
        
        // Make new FitLayout container
        FitLayout fit = new FitLayout();
        
        // Add TabPanel East to FitLayout
        fit.Items.Add(tpEast);
        
        // Add FitLayout container to East Panel
        east.Items.Add(fit);
        
        
        //////////////////
        // SOUTH REGION //
        //////////////////
        
        // Make Panel for South Region
        Ext.Net.Panel south = new Ext.Net.Panel();
        south.ID = "SouthPanel";
        south.Title = "South";
        south.Height = Unit.Pixel(150);
        south.BodyStyle = "padding:6px;";
        south.Html = "South";


        ///////////////////////
        // MAIN BORDERLAYOUT //
        ///////////////////////
        
        // Make BorderLayout container for Window
        BorderLayout layout = new BorderLayout();
        
        // Set West Region properties
        layout.West.MinWidth = Unit.Pixel(175);
        layout.West.MaxWidth = Unit.Pixel(400);
        layout.West.Split = true;
        layout.West.Collapsible = true;
        
        // Set East Region properties
        layout.East.MinWidth = Unit.Pixel(225);
        layout.East.Split = true;
        layout.East.Collapsible = true;
        
        // Set South Region properties
        layout.South.Split = true;
        layout.South.Collapsible = true;
        
        // Add Panels to BorderLayout Regions
        layout.West.Items.Add(west);
        layout.Center.Items.Add(center);
        layout.East.Items.Add(east);
        layout.South.Items.Add(south);

        
        /////////////////
        // MAIN WINDOW //
        /////////////////        

        // Make Window to hold everything
        Window win = new Window();
        win.ID = "Window1";
        win.Title = "Complex Layout";
        win.Icon = Icon.Application;
        win.Width = Unit.Pixel(640);
        win.Height = Unit.Pixel(480);
        win.Plain = true;
        win.Border = false;
        win.BodyBorder = false;
        win.Collapsible = true;
        win.AnimateTarget = "Button1";
                
        // Add BorderLayout to Window
        win.Items.Add(layout);

        // Add Window to Form
        this.PlaceHolder1.Controls.Add(win);
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Complex BorderLayout - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <ext:ResourceManager runat="server" />
    
    <h1>Complex BorderLayout in CodeBehind</h1>
    
    <ext:Button 
        ID="Button1" 
        runat="server" 
        Text="Show Window" 
        Icon="Application">
        <Listeners>
            <Click Handler="#{Window1}.show();" />
        </Listeners>    
    </ext:Button>
    
    <asp:PlaceHolder ID="PlaceHolder1" runat="server" />
</body>
</html>