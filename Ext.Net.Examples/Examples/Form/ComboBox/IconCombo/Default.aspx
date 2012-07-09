<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Store1.DataSource = new object[]
        {
            new object[] { ResourceManager.GetIconClassName(Icon.FlagFr), "France"},
            new object[] { ResourceManager.GetIconClassName(Icon.FlagCa), "Canada"},
            new object[] { ResourceManager.GetIconClassName(Icon.FlagDe), "Germany"},
            new object[] { ResourceManager.GetIconClassName(Icon.FlagUs), "United States"},
            new object[] { ResourceManager.GetIconClassName(Icon.FlagIt), "Italy"}
        };
        
        this.Store1.DataBind();

        ResourceManager1.RegisterIcon(Icon.FlagFr);
        ResourceManager1.RegisterIcon(Icon.FlagCa);
        ResourceManager1.RegisterIcon(Icon.FlagDe);
        ResourceManager1.RegisterIcon(Icon.FlagUs);
        ResourceManager1.RegisterIcon(Icon.FlagIt);
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>IconCombo</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
         .icon-combo-item {
            background-repeat: no-repeat ! important;
            background-position: 3px 50% ! important;
            padding-left: 24px ! important;
        }
    </style>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        
        <ext:Store ID="Store1" runat="server">
            <Reader>
                <ext:ArrayReader>
                    <Fields>
                        <ext:RecordField Name="iconCls" />
                        <ext:RecordField Name="name" />
                    </Fields>
                </ext:ArrayReader>
            </Reader>            
        </ext:Store>

        <ext:ComboBox 
            ID="ComboBox1" 
            runat="server"
            StoreID="Store1" 
            Width="250"
            Editable="false"
            DisplayField="name"
            ValueField="name"
            Mode="Local"
            TriggerAction="All"
            EmptyText="Select a country...">
            <Template runat="server">
                <Html>
					<tpl for=".">
                        <div class="x-combo-list-item icon-combo-item {iconCls}">
                            {name}
                        </div>
                    </tpl>
				</Html>
            </Template>  
            <Listeners>
                <Select Handler="this.setIconCls(record.get('iconCls'));" />
            </Listeners>  
        </ext:ComboBox>    
    </form>
</body>
</html>
