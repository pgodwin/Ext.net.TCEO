<%@ Page Language="C#" %>

<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Xml" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    protected void Store1_Refresh(object sender, StoreRefreshDataEventArgs e)
    {
        int start = int.Parse(e.Parameters["startRemote"]);
        int limit = int.Parse(e.Parameters["limitRemote"]);
        
        List<object> data = new List<object>(limit);
        
        for (int i = start; i < start + limit; i++)
        {
            data.Add(new {field = "Value" + (i + 1)});
        }

        e.Total = 8000;

        var store = this.GridPanel1.GetStore();
        store.DataSource = data;
        store.DataBind(); 
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Local Paging for Remote Data - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />  
    
     <script type="text/javascript">
        var remoteLoad = function (grid) {
            grid.body.mask("Loading...", "x-mask-loading");
                        
            grid.store.load({ 
                callback : function () { 
                    grid.body.unmask(); 
                } 
            });
        };
    </script>  
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>Local Paging for Remote Data</h1>
        
        <ext:GridPanel
            ID="GridPanel1" 
            runat="server" 
            StripeRows="true"
            Title="Grid" 
            Width="600" 
            Height="330"
            AutoExpandColumn="Field">
            <Store>
                <ext:Store 
                    runat="server"    
                    AutoLoad="true"
                    RemotePaging="false"
                    OnRefreshData="Store1_Refresh">
                    <Proxy>
                        <ext:PageProxy />
                    </Proxy>
                    <Reader>
                        <ext:JsonReader>
                            <Fields>
                                <ext:RecordField Name="field" />
                            </Fields>
                        </ext:JsonReader>
                    </Reader>
                    <BaseParams>
                        <ext:Parameter Name="startRemote" Value="#{Slider1}.getValue()" Mode="Raw" />
                        <ext:Parameter Name="limitRemote" Value="1000" Mode="Raw" />
                        <ext:Parameter Name="start" Value="0" Mode="Raw" />
                        <ext:Parameter Name="limit" Value="10" Mode="Raw" />
                    </BaseParams>
                </ext:Store>
            </Store>
            <LoadMask ShowMask="true" Msg="Loading Data..." />
            <ColumnModel runat="server">
                <Columns>
                    <ext:Column 
                        ColumnID="Field"
                        Header="Field" 
                        Width="160" 
                        Sortable="true" 
                        DataIndex="field">
                        <Editor>
                            <ext:TextField runat="server" />
                        </Editor>
                    </ext:Column>                   
                </Columns>
            </ColumnModel>
            <BottomBar>
                <ext:PagingToolbar runat="server" PageSize="10" />
            </BottomBar>
            <TopBar>
                <ext:Toolbar runat="server">
                    <Items>                        
                        <ext:ToolbarTextItem runat="server" Text="Remote Pager:" />
                        <ext:ToolbarSpacer runat="server" Width="20" />
                        <ext:Slider 
                            ID="Slider1" 
                            runat="server" 
                            MinValue="0" 
                            MaxValue="7000" 
                            Increment="1000" 
                            Width="250">
                            <Plugins>
                                <ext:SliderTip runat="server" />
                            </Plugins>
                            <Listeners>
                                <Change Handler="#{RangeText}.setText((newValue+1) + '-' + (newValue + 1000));" />
                                <ChangeComplete Handler="remoteLoad(#{GridPanel1});" />
                            </Listeners>
                        </ext:Slider>
                        <ext:ToolbarSpacer runat="server" Width="20" />
                        <ext:ToolbarTextItem ID="RangeText" runat="server" Text="(1-1000)" />
                    </Items>
                </ext:Toolbar>
            </TopBar>
        </ext:GridPanel>  
    </form>
</body>
</html>
