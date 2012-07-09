<%@ Page Language="C#" %>

<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="System.Collections.Generic" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        List<string> icons = Enum.GetNames(typeof(Icon)).ToList<string>();

        icons.Remove("None");

        List<object> data = new List<object>(icons.Count);

        icons.ForEach(icon => data.Add(
            new
            {
                name = icon,
                url = this.ResourceManager1.GetIconUrl((Icon)Enum.Parse(typeof(Icon), icon))
            }
        ));

        var store = this.DataView1.GetStore();
        store.DataSource = data;
        store.DataBind();
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Icons - Ext.NET Examples</title>
    <style type="text/css">
        body {
            padding : 20px;
            font    : normal 11px arial,helvetica,sans-serif;
        }
        
        .thumb-wrap {
            float  : left;
            width  : 150px;
            height : 22px;
            color  : #333;
        }
        
        .thumb-wrap img {
            width : 16px;
            vertical-align : middle;
        }
    </style>
</head>
<body>
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
    
    <ext:DataView 
        ID="DataView1" 
        runat="server"
        AutoHeight="true"
        ItemSelector="div.thumb-wrap">
        <Store>
            <ext:Store runat="server">
                <Reader>
                    <ext:JsonReader>
                        <Fields>
                            <ext:RecordField Name="name" />
                            <ext:RecordField Name="url" />      
                        </Fields>
                    </ext:JsonReader>
                </Reader>
            </ext:Store>    
        </Store>
        <Template runat="server">
            <Html>
				<tpl for=".">
					<div class="thumb-wrap" id="{name}">
						<div class="thumb"><img src="{url}" title="{name}">&nbsp;{name}</div>
					</div>
				</tpl>
				<div class="x-clear"></div>            
			</Html>
        </Template>                         
    </ext:DataView>
</body>
</html>