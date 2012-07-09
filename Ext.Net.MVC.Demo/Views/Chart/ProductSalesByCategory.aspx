<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    
    <script type="text/javascript">
        var reloadImage = function() {
            var year = cbxYear.getValue();
            if (Ext.isEmpty(year, false)) {
                year = 0;
            }
            Ext.fly("chart").dom.src = String.format("/Chart/GetProductsSalesByCategoryImage/?t={0}&width={1}&height={2}&year={3}", new Date().format("U"), ImgContainer.body.getWidth(true), ImgContainer.body.getHeight(true), year);
        };
    </script>
</head>
<body>
    <ext:ResourceManager runat="server"/>
    
    <ext:ViewPort runat="server" Layout="fit">
        <Items>
            <ext:Panel ID="ImgContainer" runat="server" Border="false">
                <TopBar>
                    <ext:Toolbar runat="server">
                        <Items>
                            <ext:ToolbarTextItem runat="server" Text="Year: " />
                            <ext:ComboBox 
                                ID="cbxYear" 
                                runat="server" 
                                DisplayField="Year" 
                                Mode="Local"
                                ValueField="Value" 
                                Editable="false">
                                <Store>
                                    <ext:Store ID="dsYears" runat="server">
                                        <Proxy>
                                            <ext:HttpProxy Url="/Data/GetOrdersYears/" />
                                        </Proxy>
                                        <Reader>
                                            <ext:JsonReader Root="data">
                                                <Fields>
                                                    <ext:RecordField Name="Year" />
                                                    <ext:RecordField Name="Value" Mapping="Year" />
                                                </Fields>
                                            </ext:JsonReader>
                                        </Reader>
                                    </ext:Store>
                                </Store>
                                <Items>
                                    <ext:ListItem Text="All" Value="0" />
                                </Items>
                                <SelectedItem Value="0" />
                                <Listeners>
                                    <Select Handler="reloadImage();" />
                                </Listeners>
                            </ext:ComboBox>
                        </Items>
                    </ext:Toolbar>                            
                </TopBar>
                <Content>
                    <img id="chart" />
                </Content>
                <Listeners>
                    <Render Delay="50" Handler="reloadImage();" />
                </Listeners>
            </ext:Panel>
        </Items>
    </ext:ViewPort>
</body>
</html>
