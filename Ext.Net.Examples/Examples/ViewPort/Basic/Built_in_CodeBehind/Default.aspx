<%@ Page Language="C#" %>
<%@ Import Namespace="Panel=Ext.Net.Panel" %>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        //////////////////
        // NORTH REGION //
        //////////////////

        // Make Panel for South Region
        Panel north = new Panel();
        north.ID = "NorthPanel";
        north.Title = "North";
        north.Height = Unit.Pixel(150);
        north.BodyStyle = "padding:6px;";
        north.Html = "North";
        
        
        /////////////////
        // WEST REGION //
        /////////////////
        
        // Make Panel for West Region
        Panel west = new Panel();
        west.ID = "WestPanel";
        west.Title = "West";
        west.Width = Unit.Pixel(225);
        
        // Make Navigation Panel for Accordion
        Panel pnlNavigation = new Panel();
        pnlNavigation.ID = "Navigation";
        pnlNavigation.Title = "Navigation";
        pnlNavigation.Border = false;
        pnlNavigation.BodyStyle = "padding:6px;";
        pnlNavigation.Icon = Icon.FolderGo;
        pnlNavigation.Html = "West";

        // Make Settings Panel for Accordion
        Panel pnlSettings = new Panel();
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
        Panel tab1 = new Panel();
        tab1.ID = "Tab2";
        tab1.Title = "Center";
        tab1.Border = false;
        tab1.BodyStyle = "padding:6px;";
        tab1.Html = "<h1>Viewport with BorderLayout</h1>";

        Panel tab2 = new Panel();
        tab2.ID = "Tab1";
        tab2.Title = "Close Me";
        tab2.Closable = true;
        tab2.Border = false;
        tab2.BodyStyle = "padding:6px;";
        tab2.Html = "Closable Tab";
        
        // Add Tab's to TabPanel
        center.Items.Add(tab1);
        center.Items.Add(tab2);

        
        /////////////////
        // EAST REGION //
        /////////////////
        
        // Make Panel for East Region
        Panel east = new Panel();
        east.ID = "EastPanel";
        east.Title = "East";
        east.Width = Unit.Pixel(225);
        
        // Make TabPanel for East Panel
        TabPanel tpEast = new TabPanel();
        tpEast.ActiveTabIndex = 1;
        tpEast.TabPosition = TabPosition.Bottom;
        tpEast.Border = false;
        
        // Make Tab 1
        Panel tabEast1 = new Panel();
        tabEast1.Title = "Tab 1";
        tabEast1.Border = false;
        tabEast1.BodyStyle = "padding:6px;";
        tabEast1.Html = "East Tab 1";
        
        // Make Tab 2
        Panel tabEast2 = new Panel();
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
        Panel south = new Panel();
        south.ID = "SouthPanel";
        south.Title = "South";
        south.Height = Unit.Pixel(150);
        south.BodyStyle = "padding:6px;";
        south.Html = "South";
        
        
        //////////////
        // VIEWPORT //
        //////////////        
        
        // Make BorderLayout container for Viewport
        BorderLayout layout = new BorderLayout();

        // Set North Region properties
        layout.North.Split = true;
        layout.North.Collapsible = true;
        
        // Set West Region properties
        layout.West.MinWidth = Unit.Pixel(225);
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
        layout.North.Items.Add(north);
        layout.West.Items.Add(west);
        layout.Center.Items.Add(center);
        layout.East.Items.Add(east);
        layout.South.Items.Add(south);

        // Make Viewport to fold everything
        Viewport vp = new Viewport();
        vp.ID = "ViewPort1";

        // Add BorderLayout to Viewport
        vp.Items.Add(layout);
        
        // Add Viewport to Form
        this.Controls.Add(vp);
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Viewport with BorderLayout - Ext.NET Examples</title>
</head>
<body>
    <ext:ResourceManager runat="server" />
</body>
</html>