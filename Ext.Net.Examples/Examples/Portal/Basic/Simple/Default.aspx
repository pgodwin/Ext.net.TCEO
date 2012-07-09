<%@ Page Language="C#" %>

<%@ Import Namespace="Ext.Net.Utilities" %>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            string text = @"Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Sed metus nibh, sodales a, porta at, vulputate eget, dui. Pellentesque ut nisl. Maecenas tortor turpis, interdum non, sodales non, iaculis ac, lacus. Vestibulum auctor, tortor quis iaculis malesuada, libero lectus bibendum purus, sit amet tincidunt quam turpis vel lacus. In pellentesque nisl non sem. Suspendisse nunc sem, pretium eget, cursus a, fringilla vel, urna.";

            this.ResourceManager1.RegisterClientScriptBlock("text", string.Format("var text=\"{0}\";", text));

            foreach (Portlet portlet in ControlUtils.FindControls<Portlet>(this.Page))
            {
                portlet.Html = "={text}";
                portlet.Padding = 5;
                portlet.Tools.Add(new Tool(ToolType.Close, string.Concat(portlet.ClientID, ".hide();"), "Close Portlet"));
            }
        }

        foreach (Portlet portlet in ControlUtils.FindControls<Portlet>(this.Page))
        {
            portlet.DirectEvents.Hide.Event += Portlet_Hide;
            portlet.DirectEvents.Hide.EventMask.ShowMask = true;
            portlet.DirectEvents.Hide.EventMask.Msg = "Saving...";
            portlet.DirectEvents.Hide.EventMask.MinDelay = 500;
            
            portlet.DirectEvents.Hide.ExtraParams.Add(new Ext.Net.Parameter("ID", portlet.ClientID));
        }
    }

    protected void Portlet_Hide(object sender, DirectEventArgs e)
    {
       X.Msg.Alert("Status", e.ExtraParams["ID"] + " Hidden").Show();
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Portal in TabPanel - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" /> 
    
    <style type="text/css">
        .x-column-padding{
            padding: 10px 0px 10px 10px;
        }
        
        .x-column-padding1{
            padding: 10px;
        }
    </style>  
</head>
<body>
    <form runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        
        <ext:Viewport runat="server">
            <Items>
                <ext:BorderLayout runat="server">
                    <West 
                        Collapsible="true" 
                        Split="true" 
                        MinWidth="175" 
                        MaxWidth="400" 
                        MarginsSummary="5 0 5 5" 
                        CMarginsSummary="5 5 5 5">
                        <ext:Panel runat="server" Title="West" Width="200">
                            <Items>
                                <ext:AccordionLayout runat="server" Animate="true">
                                    <Items>
                                        <ext:Panel 
                                            runat="server" 
                                            Border="false" 
                                            Collapsed="true" 
                                            Icon="Note"
                                            AutoScroll="true"
                                            Title="Content"
                                            Html="={text}"
                                            Padding="5"
                                            />
                                        <ext:Panel
                                            runat="server" 
                                            Border="false" 
                                            Collapsed="true" 
                                            Icon="FolderWrench" 
                                            AutoScroll="true"
                                            Title="Settings"
                                            Html="={text}"
                                            Padding="5"
                                            />
                                    </Items>
                                </ext:AccordionLayout>
                            </Items>
                        </ext:Panel>
                    </West>
                    <Center MarginsSummary="5 5 5 0">
                        <ext:TabPanel runat="server" ActiveTabIndex="0" Title="TabPanel">
                            <Items>
                                <ext:Panel runat="server" Title="Tab 1" Layout="Fit">
                                    <Items>
                                        <ext:Portal runat="server" Border="false" Layout="Column">
                                            <Items>
                                                <ext:PortalColumn 
                                                    runat="server" 
                                                    Cls="x-column-padding"
                                                    ColumnWidth=".33"
                                                    Layout="Anchor">
                                                    <Items>
                                                        <ext:Portlet ID="Portlet1" runat="server" Title="Another Panel 1" Icon="Accept" />
                                                    </Items>
                                                </ext:PortalColumn>
                                                <ext:PortalColumn 
                                                    runat="server" 
                                                    Cls="x-column-padding"
                                                    ColumnWidth=".33"
                                                    Layout="Anchor">
                                                    <Items>
                                                        <ext:Portlet ID="Portlet2" runat="server" Title="Panel 2" />
                                                        <ext:Portlet ID="Portlet3" runat="server" Title="Another Panel 2" />
                                                    </Items>
                                                </ext:PortalColumn>
                                                <ext:PortalColumn 
                                                    runat="server" 
                                                    Cls="x-column-padding1"
                                                    ColumnWidth=".33"
                                                    Layout="Anchor">
                                                    <Items>
                                                        <ext:Portlet ID="Portlet4" runat="server" Title="Panel 3" />
                                                        <ext:Portlet ID="Portlet5" runat="server" Title="Another Panel 3" />
                                                    </Items>
                                                </ext:PortalColumn>
                                            </Items>
                                        </ext:Portal>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel runat="server" Title="Tab 2" Layout="Fit">
                                    <Items>
                                        <ext:Portal runat="server" Border="false" Layout="Column">
                                            <Items>
                                                <ext:PortalColumn 
                                                    runat="server" 
                                                    Cls="x-column-padding"
                                                    ColumnWidth=".33"
                                                    Layout="Anchor">
                                                    <Items>
                                                        <ext:Portlet ID="Portlet7" Title="Another Panel 3" runat="server" />
                                                    </Items>
                                                </ext:PortalColumn>
                                                <ext:PortalColumn 
                                                    runat="server" 
                                                    Cls="x-column-padding"
                                                    ColumnWidth=".33"
                                                    Layout="Anchor">
                                                    <Items>
                                                        <ext:Portlet ID="Portlet8" Title="Panel 2" runat="server" />
                                                        <ext:Portlet ID="Portlet9" Title="Another Panel 2" runat="server" />
                                                    </Items>
                                                </ext:PortalColumn>
                                                <ext:PortalColumn 
                                                    runat="server" 
                                                    Cls="x-column-padding1"
                                                    ColumnWidth=".33"
                                                    Layout="Anchor">
                                                    <Items>
                                                        <ext:Portlet ID="Portlet10" Title="Another Panel 1" runat="server" />
                                                    </Items>
                                                </ext:PortalColumn>
                                            </Items>
                                        </ext:Portal>  
                                    </Items>                                  
                                </ext:Panel>
                            </Items>
                        </ext:TabPanel> 
                    </Center>
                </ext:BorderLayout>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>