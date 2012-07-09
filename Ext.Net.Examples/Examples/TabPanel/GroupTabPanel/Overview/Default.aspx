<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            this.Store1.DataSource = new object[]
            {
                new object[] { "3m Co", 71.72, 0.02, 0.03, "9/1 12:00am" },
                new object[] { "Alcoa Inc", 29.01, 0.42, 1.47, "9/1 12:00am" },
                new object[] { "Altria Group Inc", 83.81, 0.28, 0.34, "9/1 12:00am" },
                new object[] { "American Express Company", 52.55, 0.01, 0.02, "9/1 12:00am" },
                new object[] { "American International Group, Inc.", 64.13, 0.31, 0.49, "9/1 12:00am" },
                new object[] { "AT&T Inc.", 31.61, -0.48, -1.54, "9/1 12:00am" },
                new object[] { "Boeing Co.", 75.43, 0.53, 0.71, "9/1 12:00am" },
                new object[] { "Caterpillar Inc.", 67.27, 0.92, 1.39, "9/1 12:00am" },
                new object[] { "Citigroup, Inc.", 49.37, 0.02, 0.04, "9/1 12:00am" },
                new object[] { "E.I. du Pont de Nemours and Company", 40.48, 0.51, 1.28, "9/1 12:00am" },
                new object[] { "Exxon Mobil Corp", 68.1, -0.43, -0.64, "9/1 12:00am" },
                new object[] { "General Electric Company", 34.14, -0.08, -0.23, "9/1 12:00am" },
                new object[] { "General Motors Corporation", 30.27, 1.09, 3.74, "9/1 12:00am" },
                new object[] { "Hewlett-Packard Co.", 36.53, -0.03, -0.08, "9/1 12:00am" },
                new object[] { "Honeywell Intl Inc", 38.77, 0.05, 0.13, "9/1 12:00am" },
                new object[] { "Intel Corporation", 19.88, 0.31, 1.58, "9/1 12:00am" },
                new object[] { "International Business Machines", 81.41, 0.44, 0.54, "9/1 12:00am" },
                new object[] { "Johnson & Johnson", 64.72, 0.06, 0.09, "9/1 12:00am" },
                new object[] { "JP Morgan & Chase & Co", 45.73, 0.07, 0.15, "9/1 12:00am" },
                new object[] { "McDonald\"s Corporation", 36.76, 0.86, 2.40, "9/1 12:00am" },
                new object[] { "Merck & Co., Inc.", 40.96, 0.41, 1.01, "9/1 12:00am" },
                new object[] { "Microsoft Corporation", 25.84, 0.14, 0.54, "9/1 12:00am" },
                new object[] { "Pfizer Inc", 27.96, 0.4, 1.45, "9/1 12:00am" },
                new object[] { "The Coca-Cola Company", 45.07, 0.26, 0.58, "9/1 12:00am" },
                new object[] { "The Home Depot, Inc.", 34.64, 0.35, 1.02, "9/1 12:00am" },
                new object[] { "The Procter & Gamble Company", 61.91, 0.01, 0.02, "9/1 12:00am" },
                new object[] { "United Technologies Corporation", 63.26, 0.55, 0.88, "9/1 12:00am" },
                new object[] { "Verizon Communications", 35.57, 0.39, 1.11, "9/1 12:00am" },
                new object[] { "Wal-Mart Stores, Inc.", 45.45, 0.73, 1.63, "9/1 12:00am" }
            };

            this.Store1.DataBind();
        }
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GroupTabPanel - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        var template = '<span style="color:{0};">{1}</span>';

        var change = function(value) {
            return String.format(template, (value > 0) ? "green" : "red", value);
        };

        var pctChange = function(value) {
            return String.format(template, (value > 0) ? "green" : "red", value + "%");
        };

        var shortTestMarkup = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Sed metus nibh, sodales a, porta at, vulputate eget, dui. Pellentesque ut nisl. Maecenas tortor turpis, interdum non, sodales non, iaculis ac, lacus. Vestibulum auctor, tortor quis iaculis malesuada, libero lectus bibendum purus, sit amet tincidunt quam turpis vel lacus. In pellentesque nisl non sem. Suspendisse nunc sem, pretium eget, cursus a, fringilla vel, urna.";
    </script>

    <style type="text/css">
        .custom {
            background-color : gray;
            border : solid 5px gray;
        }
        .custom .x-grouptabs-corner {
            background-image : none;
        }
        
        .custom ul.x-grouptabs-strip li.x-grouptabs-strip-active {
            background : #DBDBDB;
            border : none !important;
        }
        
        .custom ul.x-grouptabs-strip li.x-grouptabs-main {
            border : solid 1px white;
        }
        
        .custom li.x-grouptabs-strip-active ul.x-grouptabs-sub li.x-grouptabs-strip-active {
            background-color : white;
        }
    </style>
</head>
<body>
    <ext:ResourceManager runat="server" />
    
    <ext:Viewport runat="server" Layout="border">
        <Items>
            <ext:GroupTabPanel ID="GroupTabPanel1" runat="server" Region="Center" TabWidth="130" ActiveGroupIndex="0">
                <Groups>
                    <ext:GroupTab runat="server" MainItem="1" >
                        <Items>
                            <ext:Panel 
                                runat="server" 
                                Title="Tickets" 
                                Layout="fit" 
                                Icon="TagBlue" 
                                TabTip="Tickets tabtip"
                                Padding="10">
                                <Items>
                                    <ext:GridPanel 
                                        runat="server" 
                                        StripeRows="true"
                                        Title="Array Grid" 
                                        TrackMouseOver="true" 
                                        AutoExpandColumn="Company">
                                        <Store>
                                            <ext:Store ID="Store1" runat="server">
                                                <Reader>
                                                    <ext:ArrayReader>
                                                        <Fields>
                                                            <ext:RecordField Name="company" />
                                                            <ext:RecordField Name="price" Type="Float" />
                                                            <ext:RecordField Name="change" Type="Float" />
                                                            <ext:RecordField Name="pctChange" Type="Float" />
                                                            <ext:RecordField Name="lastChange" Type="Date" DateFormat="M/d hh:mmtt" />
                                                        </Fields>
                                                    </ext:ArrayReader>
                                                </Reader>
                                            </ext:Store>
                                        </Store>
                                        <ColumnModel runat="server">
                                            <Columns>
                                                <ext:Column ColumnID="Company" Header="Company" Sortable="true" DataIndex="company" />
                                                <ext:Column Header="Price" Sortable="true" DataIndex="price">
                                                    <Renderer Format="UsMoney" />
                                                </ext:Column>
                                                <ext:Column Header="Change" Sortable="true" DataIndex="change">
                                                    <Renderer Fn="change" />
                                                </ext:Column>
                                                <ext:Column Header="Change" Sortable="true" DataIndex="pctChange">
                                                    <Renderer Fn="pctChange" />
                                                </ext:Column>
                                                <ext:DateColumn Header="Last Updated" Sortable="true" DataIndex="lastChange" />
                                            </Columns>
                                        </ColumnModel>
                                        <SelectionModel>
                                            <ext:RowSelectionModel runat="server" SingleSelect="true" />
                                        </SelectionModel>
                                    </ext:GridPanel>
                                </Items>
                            </ext:Panel>
                            <ext:Portal 
                                runat="server" 
                                Title="Dashboard" 
                                TabTip="Dashboard TabTip" 
                                Layout="Column">
                                <Items>
                                    <ext:PortalColumn 
                                        runat="server"
                                        StyleSpec="padding:10px 0 10px 10px" 
                                        ColumnWidth=".33"
                                        Layout="Anchor">
                                        <Items>
                                            <ext:Portlet 
                                                runat="server" 
                                                Title="Another Panel 1" 
                                                Html="={shortTestMarkup}" 
                                                />
                                        </Items>
                                    </ext:PortalColumn>
                                    <ext:PortalColumn 
                                        runat="server" 
                                        StyleSpec="padding:10px 0 10px 10px" 
                                        ColumnWidth=".33"
                                        Layout="Anchor">
                                        <Items>
                                            <ext:Portlet 
                                                runat="server" 
                                                Title="Panel 2" 
                                                Html="={shortTestMarkup}" 
                                                />
                                            <ext:Portlet 
                                                runat="server" 
                                                Title="Another Panel 2" 
                                                Html="={shortTestMarkup}" 
                                                />
                                        </Items>
                                    </ext:PortalColumn>
                                    <ext:PortalColumn 
                                        runat="server" 
                                        StyleSpec="padding: 10px;" 
                                        ColumnWidth=".33" 
                                        Layout="Anchor">
                                        <Items>
                                            <ext:Portlet ID="Portlet4" runat="server" Title="Panel 3" Html="={shortTestMarkup}" />
                                            <ext:Portlet ID="Portlet5" runat="server" Title="Another Panel 3" Html="={shortTestMarkup}" />
                                        </Items>
                                    </ext:PortalColumn>
                                </Items>
                            </ext:Portal>
                            <ext:Panel 
                                runat="server" 
                                Title="Subscriptions" 
                                Icon="Newspaper" 
                                TabTip="Subscriptions TabTip"
                                StyleSpec="padding: 10px;" 
                                Layout="Fit">
                                <Items>
                                    <ext:TabPanel runat="server" ActiveTabIndex="0">
                                        <Items>
                                            <ext:Panel 
                                                runat="server" 
                                                Title="Subscriptions" 
                                                Padding="5"
                                                Html="={shortTestMarkup}" 
                                                />
                                        </Items>
                                    </ext:TabPanel>
                                </Items>
                            </ext:Panel>
                            <ext:Panel
                                runat="server" 
                                Title="Users" 
                                Icon="Group" 
                                TabTip="Users tabtip" 
                                StyleSpec="padding: 10px;"
                                Html="={shortTestMarkup}" 
                                />
                        </Items>
                    </ext:GroupTab>
                    <ext:GroupTab runat="server">
                        <Items>
                            <ext:Panel 
                                runat="server" 
                                Title="Configuration" 
                                TabTip="Configuration tabtip" 
                                StyleSpec="padding: 10px;"
                                Html="={shortTestMarkup}" 
                                />
                            <ext:Panel 
                                runat="server" 
                                Title="Email Templates" 
                                TabTip="Templates tabtip" 
                                Icon="Email"
                                StyleSpec="padding: 10px;" 
                                Html="={shortTestMarkup}" 
                                />
                        </Items>
                    </ext:GroupTab>
                </Groups>
            </ext:GroupTabPanel>
            <ext:Panel runat="server" Region="South" Margins="5 10 10 10" ButtonAlign="Left" BodyBorder="false">
                <TopBar>
                    <ext:Toolbar runat="server" Flat="true">
                        <Items>
                            <ext:SplitButton
                                runat="server" 
                                Icon="Tab" 
                                ToggleGroup="group"
                                Pressed="true" 
                                Text="Dashboard">
                                <Menu>
                                    <ext:Menu runat="server">
                                        <Items>
                                            <ext:MenuItem runat="server" Text="Tickets" Icon="TagBlue">
                                                <Listeners>
                                                    <Click Handler="GroupTabPanel1.activeGroup.setActiveTab(0);" />
                                                </Listeners>
                                            </ext:MenuItem>
                                            <ext:MenuItem runat="server" Text="Subscriptions" Icon="Newspaper">
                                                <Listeners>
                                                    <Click Handler="GroupTabPanel1.activeGroup.setActiveTab(2);" />
                                                </Listeners>
                                            </ext:MenuItem>
                                            <ext:MenuItem runat="server" Text="Users" Icon="Group">
                                                <Listeners>
                                                    <Click Handler="GroupTabPanel1.activeGroup.setActiveTab(3);" />
                                                </Listeners>
                                            </ext:MenuItem>
                                        </Items>
                                    </ext:Menu>
                                </Menu>
                                <Listeners>
                                    <Click Handler="GroupTabPanel1.setActiveGroup(0);" />
                                </Listeners>
                            </ext:SplitButton>
                            <ext:ToolbarSpacer runat="server" />
                            <ext:SplitButton 
                                ID="Group2Btn" 
                                runat="server" 
                                Icon="Tab" 
                                ToggleGroup="group" 
                                Text="Configuration">
                                <Menu>
                                    <ext:Menu runat="server">
                                        <Items>
                                            <ext:MenuItem runat="server" Text="Email Templates" Icon="Email">
                                                <Listeners>
                                                    <Click Handler="GroupTabPanel1.activeGroup.setActiveTab(1);" />
                                                </Listeners>
                                            </ext:MenuItem>
                                        </Items>
                                    </ext:Menu>
                                </Menu>
                                <Listeners>
                                    <Click Handler="GroupTabPanel1.setActiveGroup(1);" />
                                </Listeners>
                            </ext:SplitButton>
                            <ext:ToolbarFill runat="server" />
                            <ext:Button ID="Button1" runat="server" Text="Set Custom Css Class" Icon="BulletBlue">
                                <Listeners>
                                    <Click Handler="GroupTabPanel1.addClass('custom'); this.disable(); Button2.enable();" />
                                </Listeners>
                            </ext:Button>
                            
                            <ext:Button ID="Button2" runat="server" Text="Remove Customer Css Class" Disabled="true" Icon="BulletBlack">
                                <Listeners>
                                    <Click Handler="GroupTabPanel1.removeClass('custom'); this.disable(); Button1.enable();" />
                                </Listeners>
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
            </ext:Panel>
        </Items>
    </ext:Viewport>
</body>
</html>