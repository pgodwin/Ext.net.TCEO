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
                if (!portlet.ID.Equals("Portlet1"))
                {
                    portlet.Html = "={text}";
                    portlet.Padding = 5;
                }
            }
        }
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Deluxe Portal in TabPanel - Ext.NET Examples</title>
</head>
<body>
<style type="text/css">
    body {
        font-size: 12px;
        background-color: #284051;
        font-family: "Trebuchet MS",sans-serif;
    }
    
    #settingsWrapper {
        border-bottom: 1px solid #111;
        background-color: #323232;
        padding-left: 4px;
    }
    
    #settings {
        padding: 2px;
        border-bottom: 1px solid #3B3B3B;
    }
    
    #settings ul li {
        display: inline;
        color: #fff;
        margin-right: 8px;
        line-height: 24px;
        padding: 2px;
        padding-left: 19px;
    }
    
    #settings ul li a, #settings ul li a:link {
        color: #fff;
        text-decoration: none;
    }
    
    #settings ul li a:hover {
        text-decoration: underline;
    }
    
    #pageTitle {
        font-family: "Trebuchet MS",sans-serif;
        font-size: 17px;
        text-align: center;
        color: #fff;
        margin-top: 20px;
    }
    
    #itemAddContent {
        background: url(<%= this.ResourceManager1.GetIconUrl(Icon.Add) %>) no-repeat 0 2px;
    }
    
    #itemComments {
        background: url(<%= this.ResourceManager1.GetIconUrl(Icon.Comment) %>) no-repeat 0 2px;
    }
    
    #itemActivities {
        background: url(<%= this.ResourceManager1.GetIconUrl(Icon.Star) %>) no-repeat 0 2px;
    }
    
    #itemContacts {
        background: url(<%= this.ResourceManager1.GetIconUrl(Icon.Vcard) %>) no-repeat 0 2px;
    }
    
    #TabPanel1 ul.x-tab-strip-top {
        background-image: none !important;
        background-color: #284051;
    }
  
    .x-panel-dd-spacer {
        border: 2px dashed #284051;
    }
</style>
<form runat="server">    
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
    
    <ext:Viewport runat="server" StyleSpec="background-color: transparent;">
        <Items>
            <ext:BorderLayout runat="server">
                <North>
                    <ext:Panel 
                        ID="pnlNorth" 
                        runat="server" 
                        Height="80" 
                        Border="false" 
                        Header="false" 
                        BodyStyle="background-color: transparent;">
                        <Content>
                            <div id="settingsWrapper">
                                <div id="settings">
                                    <ul>
                                        <li id="itemAddContent"><a href="#">Add content</a></li>
                                        <li id="itemComments"><a href="#">Comments</a></li>
                                        <li id="itemActivities"><a href="#">Activities</a></li>
                                        <li id="itemContacts"><a href="#">Contacts</a></li>
                                    </ul>
                                </div>
                            </div>
                            <div id="pageTitle">Page Title</div>
                        </Content>
                    </ext:Panel>
                </North>
                <West 
                    Collapsible="true"
                    Split="true" 
                    MinWidth="175" 
                    MaxWidth="400" 
                    MarginsSummary="31 0 5 5" 
                    CMarginsSummary="31 5 5 5">
                    <ext:Panel 
                        runat="server" 
                        Title="Settings" 
                        Width="200" 
                        ID="pnlSettings"
                        BodyStyle="background-color: #284051;">
                        <Items>
                            <ext:AccordionLayout runat="server" Animate="true">
                                <Items>
                                    <ext:Panel 
                                        runat="server" 
                                        Border="false" 
                                        Collapsed="True" 
                                        Icon="PageWhiteCopy"
                                        AutoScroll="true"
                                        Title="Content"
                                        Html="={text}"
                                        Padding="6"
                                        />
                                    <ext:Panel 
                                        runat="server" 
                                        Border="false" 
                                        Collapsed="true" 
                                        Icon="Star" 
                                        AutoScroll="true"
                                        Title="Activities" 
                                        Html="={text}"
                                        Padding="6"
                                        />
                                    <ext:Panel ID="Panel1" 
                                        runat="server" 
                                        Border="false" 
                                        Collapsed="true" 
                                        Icon="Group" 
                                        AutoScroll="true"
                                        Title="Contacts" 
                                        Html="={text}"
                                        Padding="6"
                                        />    
                                </Items>                                    
                            </ext:AccordionLayout>
                        </Items>
                    </ext:Panel>
                </West>
                <Center MarginsSummary="5 5 5 0">
                    <ext:TabPanel 
                        ID="TabPanel1" 
                        runat="server" 
                        Title="TabPanel" 
                        ActiveTabIndex="0" 
                        Border="false" 
                        BodyStyle="background-color: #4D778B; border: 1px solid #AABBCC; border-top: none;">
                        <Items>
                            <ext:Panel 
                                ID="Tab1" 
                                runat="server" 
                                Title="Internet" 
                                Icon="Vcard" 
                                BodyStyle="background-color: transparent;"
                                Layout="Fit">
                                <Items>
                                    <ext:Portal 
                                        ID="Portal1" 
                                        runat="server" 
                                        Border="false" 
                                        BodyStyle="background-color: transparent;"
                                        Layout="Column">
                                        <Items>
                                            <ext:PortalColumn 
                                                runat="server" 
                                                StyleSpec="padding:10px 0 10px 10px"
                                                ColumnWidth=".33"
                                                Layout="Anchor">
                                                <Items>
                                                    <ext:Portlet 
                                                        ID="Portlet1" 
                                                        Title="Google Search" 
                                                        runat="server" 
                                                        Height="450"
                                                        Padding="0">
                                                        <AutoLoad Url="http://www.google.com/" Mode="IFrame" />
                                                    </ext:Portlet>
                                                </Items>
                                            </ext:PortalColumn>
                                            <ext:PortalColumn 
                                                runat="server" 
                                                StyleSpec="padding:10px 0 10px 10px"
                                                ColumnWidth=".33"
                                                Layout="Anchor">
                                                <Items>
                                                    <ext:Portlet ID="Portlet2" Title="Panel 2" runat="server" />
                                                    <ext:Portlet ID="Portlet3" Title="Another Panel 2" runat="server" />
                                                </Items>
                                            </ext:PortalColumn>
                                            <ext:PortalColumn 
                                                runat="server" 
                                                StyleSpec="padding:10px"
                                                ColumnWidth=".33"
                                                Layout="Anchor">
                                                <Items>
                                                    <ext:Portlet ID="Portlet4" Title="Panel 3" runat="server" />
                                                    <ext:Portlet ID="Portlet5" Title="Another Panel 3" runat="server" />
                                                </Items>
                                            </ext:PortalColumn>
                                        </Items>
                                    </ext:Portal>
                                </Items>
                            </ext:Panel>
                            <ext:Panel 
                                ID="Tab2" 
                                runat="server" 
                                Title="General" 
                                Icon="House" 
                                BodyStyle="background-color: transparent;"
                                Layout="Fit">
                                <Items>
                                    <ext:Portal 
                                        ID="Portal2" 
                                        runat="server" 
                                        Border="false" 
                                        BodyStyle="background-color: transparent;"
                                        Layout="Column">
                                        <Items>
                                            <ext:PortalColumn 
                                                ID="PortalColumn6" 
                                                runat="server" 
                                                StyleSpec="padding:10px"
                                                ColumnWidth=".33"
                                                />
                                            <ext:PortalColumn 
                                                ID="PortalColumn5" 
                                                runat="server" 
                                                StyleSpec="padding:10px 0 10px 10px"
                                                ColumnWidth=".33"
                                                Layout="Anchor">
                                                <Items>
                                                    <ext:Portlet ID="Portlet9" Title="Panel 3" runat="server" />
                                                    <ext:Portlet ID="Portlet10" Title="Another Panel 3" runat="server" />
                                                </Items>
                                            </ext:PortalColumn>
                                            <ext:PortalColumn 
                                                ID="PortalColumn4" 
                                                runat="server" 
                                                StyleSpec="padding:10px 0 10px 10px"
                                                ColumnWidth=".33"
                                                Layout="Anchor">
                                                <Items>
                                                    <ext:Portlet ID="Portlet6" Title="Another Panel 1" runat="server" />
                                                </Items>
                                            </ext:PortalColumn>
                                        </Items>
                                    </ext:Portal> 
                                </Items>                                   
                            </ext:Panel>
                            <ext:Panel 
                                runat="server" 
                                Title="Fun" 
                                Icon="ColorSwatch" 
                                BodyStyle="background-color: transparent;"
                                Layout="Fit">
                                <Items>
                                    <ext:Portal 
                                        ID="Portal3" 
                                        runat="server" 
                                        Border="false" 
                                        BodyStyle="background-color: transparent;"
                                        Layout="Column">
                                        <Items>
                                            <ext:PortalColumn 
                                                runat="server" 
                                                StyleSpec="padding:10px"
                                                ColumnWidth=".33"
                                                Layout="Anchor">
                                                <Items>
                                                    <ext:Portlet runat="server" Title="My &quot;Fun&quot; Portlet" />
                                                </Items>
                                            </ext:PortalColumn>
                                            <ext:PortalColumn 
                                                runat="server" 
                                                StyleSpec="padding:10px 0 10px 10px" 
                                                ColumnWidth=".33"
                                                />
                                            <ext:PortalColumn 
                                                runat="server" 
                                                StyleSpec="padding:10px 0 10px 10px" 
                                                ColumnWidth=".33"
                                                />
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
