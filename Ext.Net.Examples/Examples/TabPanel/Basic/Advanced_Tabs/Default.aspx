<%@ Page Language="C#" %>

<%@ Import Namespace="Panel=Ext.Net.Panel" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        Window win = new Window();

        win.Height = 200;
        win.Width = 400;
        win.Closable = false;
        win.Title = "Scrollable Tabs";
        win.Layout = "Fit";
        
        TabPanel tabs = new TabPanel();

        tabs.ID = "TabPanel1";
        tabs.IDMode = IDMode.Explicit;
        tabs.ResizeTabs = true;
        tabs.Border = false;
        tabs.MinTabWidth = Unit.Pixel(75);
        tabs.TabWidth = Unit.Pixel(135);
        tabs.EnableTabScroll = true;
        tabs.Width = Unit.Pixel(600);
        tabs.Height = Unit.Pixel(250);
        tabs.ActiveTabIndex = 6;
        tabs.Plugins.Add(new TabScrollerMenu { 
	        PageSize = 5
        });

        tabs.Add(new Panel {
            Title = "Our First Tab"
        });
        
        int index = 1;
        
        while (index <= 11)
        {
            Panel tab = new Panel();
            tab.Title = "Tab # " + index.ToString();
            tab.TabTip = "Tab # " + index.ToString();
            tab.Html = "Tab " + index.ToString();
            tab.Closable = true;
            tab.Padding = 6;
            
            tabs.Items.Add(tab);
            index++;
        }

        win.Items.Add(tabs);
        this.Form.Controls.Add(win);
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Scrollable Tabs with TabScrollerMenu Plugin - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>Scrollable Tabs with TabScrollerMenu Plugin</h1>
    </form>
</body>
</html>
