<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <ext:ResourceManager runat="server" />
    
    <ext:Viewport runat="server" Layout="fit">
        <Items>
            <ext:TabPanel runat="server" EnableTabScroll="true">
                <Items>
                    <ext:Panel runat="server" Title="Load View Into Container">
                        <TopBar>
                            <ext:Toolbar runat="server">
                                <Items>
                                    <ext:Button runat="server" Text="Load">
                                        <DirectEvents>
                                            <Click Url="/Partial/View1">
                                                <ExtraParams>
                                                    <ext:Parameter Name="containerId" Value="Tab1_Div" Mode="Value" />
                                                </ExtraParams>
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>
                                </Items>                                
                            </ext:Toolbar>
                        </TopBar>
                        
                        <Content>
                            <div id="Tab1_Div">
                            </div>
                        </Content>
                    </ext:Panel>
                    
                    <ext:Panel runat="server" Title="Load View With Layout" Layout="Border">
                        <Items>
                            <ext:Panel ID="Tab2_West" runat="server" Title="West" Width="250" Layout="fit" Region="West" />
                            <ext:Panel runat="server" Title="Center" Margins="0 0 0 5" Region="Center">
                                <Items>
                                    <ext:Button runat="server" Text="Click to load west region">
                                        <DirectEvents>
                                            <Click Url="/Partial/View2">
                                                <ExtraParams>
                                                    <ext:Parameter Name="containerId" Value="#{Tab2_West}" Mode="Value" />
                                                </ExtraParams>
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>
                                </Items>
                            </ext:Panel>
                        </Items>
                    </ext:Panel>
                    
                    <ext:Panel ID="Tab3" runat="server" Title="Load View Via AutoLoad">
                        <AutoLoad Url="/Partial/View1" NoCache="true">      
                            <Params>
                                <ext:Parameter Name="containerId" Value="function () { return #{Tab3}.body.id; }" Mode="Raw" />
                            </Params>                      
                        </AutoLoad>
                    </ext:Panel>
                    
                    <ext:Panel runat="server" Title="Load view as tab item" Padding="10">
                        <Content>
                            <ext:Button runat="server" Text="Add tab">
                                <DirectEvents>
                                    <Click Url="/Partial/View3">
                                        <ExtraParams>
                                            <ext:Parameter Name="containerId" Value="#{Tab4_SubTabs}" Mode="Value" />
                                        </ExtraParams>
                                    </Click>
                                </DirectEvents>
                            </ext:Button>
                            <br />
                            <ext:TabPanel ID="Tab4_SubTabs" runat="server" Width="300" AutoHeight="true">
                                <Listeners>
                                    <Add Handler="this.setActiveTab(component);" />
                                </Listeners>
                            </ext:TabPanel>
                        </Content>
                    </ext:Panel>
                    
                    <ext:Panel runat="server" Title="Load Window" Padding="10">
                        <Content>
                            <ext:Button runat="server" Text="Show Window">
                                <DirectEvents>
                                    <Click Url="/Partial/View4" />
                                </DirectEvents>
                            </ext:Button>                            
                        </Content>
                    </ext:Panel>
                </Items>
            </ext:TabPanel>
        </Items>
    </ext:Viewport>
</body>
</html>
