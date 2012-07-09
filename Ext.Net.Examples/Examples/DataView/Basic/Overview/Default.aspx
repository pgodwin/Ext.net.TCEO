<%@ Page Language="C#" %>

<%@ Import Namespace="System.Collections.Generic" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<script runat="server">
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                string path = Server.MapPath("../../Shared/images/thumbs");
                string[] files = System.IO.Directory.GetFiles(path);

                List<object> data = new List<object>(files.Length);
                foreach (string fileName in files)
                {
                    System.IO.FileInfo fi = new System.IO.FileInfo(fileName);
                    data.Add(new { name = fi.Name, 
                                   url = "../../Shared/images/thumbs/" + fi.Name,
                                   size = fi.Length,
                                   lastmod = fi.LastAccessTime });
                }

                this.Store1.DataSource = data;
                this.Store1.DataBind();
            }
        }

        protected void Button1_Click(object sender, DirectEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (SelectedRow row in ImageView.SelectedRows)
            {
                sb.AppendFormat("RecordID: {0}&nbsp;&nbsp;&nbsp;&nbsp;Row index: {1}<br/>", row.RecordID, row.RowIndex);
            }
            this.Label1.Html = sb.ToString();
        }

        protected void Clear_Click(object sender, DirectEventArgs e)
        {
            ImageView.SelectedRows.Clear();
            ImageView.UpdateSelection();
        }

        protected void Add_Click(object sender, DirectEventArgs e)
        {
            ImageView.SelectedRows.Add(new SelectedRow("zack.jpg"));
            ImageView.UpdateSelection();
        }

        protected void SubmitSelection(object sender, DirectEventArgs e)
        {
            string json = e.ExtraParams["Values"];

            Dictionary<string, string>[] images = JSON.Deserialize<Dictionary<string, string>[]>(json);

            StringBuilder sb = new StringBuilder();
            sb.Append("<table  cellspacing='15'>");
            bool addHeader = true;

            foreach (Dictionary<string, string> row in images)
            {
                if (addHeader)
                {
                    sb.Append("<tr>");
                    foreach (KeyValuePair<string, string> keyValuePair in row)
                    {
                        sb.Append("<td style='white-space:nowrap;font-weight:bold;'>");

                        sb.Append(keyValuePair.Key);

                        sb.Append("</td>");
                    }
                    sb.Append("</tr>");

                    addHeader = false;
                }

                sb.Append("<tr>");
                foreach (KeyValuePair<string, string> keyValuePair in row)
                {
                    sb.Append("<td style='white-space:nowrap;'>");

                    sb.Append(keyValuePair.Value);

                    sb.Append("</td>");
                }
                sb.Append("</tr>");
            }
            sb.Append("</table>");
            this.Label1.Html = sb.ToString();
        }

</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <ext:ResourcePlaceHolder runat="server" Mode="Script" />
    
    <script src="data-view-plugins.js" type="text/javascript"></script>
    
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript">
        var prepareData = function (data) {
            data.shortName = Ext.util.Format.ellipsis(data.name, 15);
            data.sizeString = Ext.util.Format.fileSize(data.size);
            data.dateString = data.lastmod.format("m/d/Y g:i a");

            return data;
        };
            
        var selectionChaged = function (dv,nodes) {
			var l = nodes.length, s = l != 1 ? 's' : '';
			ImagePanel.setTitle('Simple DataView (' + l + ' item' + s + ' selected)');
		};
    </script> 
    
    <style type="text/css">
        .images-view .x-panel-body{
	        background: white;
	        font: 11px Arial, Helvetica, sans-serif;
        }
        .images-view .thumb{
	        background: #dddddd;
	        padding: 3px;
        }
        .images-view .thumb img{
	        height: 60px;
	        width: 80px;
        }
        .images-view .thumb-wrap{
	        float: left;
	        margin: 4px;
	        margin-right: 0;
	        padding: 5px;
	        text-align:center;
        }
        .images-view .thumb-wrap span{
	        display: block;
	        overflow: hidden;
	        text-align: center;
        }

        .images-view .x-view-over{
            border:1px solid #dddddd;
            background: #efefef url(../../Shared/images/row-over.gif) repeat-x left top;
	        padding: 4px;
        }

        .images-view .x-view-selected{
	        background: #eff5fb url(../../Shared/images/selected.gif) no-repeat right bottom;
	        border:1px solid #99bbe8;
	        padding: 4px;
        }
        .images-view .x-view-selected .thumb{
	        background:transparent;
        }

        .images-view .loading-indicator {
	        font-size:11px;
	        background-image:url(../../Shared/images/loading.gif);
	        background-repeat: no-repeat;
	        background-position: left;
	        padding-left:20px;
	        margin:10px;
        }
    </style>   
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>DataView Example</h1>
        
        <p>This example shows how to use a DataView.  It demonstrates basic multi-select (using ctrl or shift) and drag selection.</p>

        <ext:Store runat="server" ID="Store1">
            <Reader>
                <ext:JsonReader IDProperty="name">
                    <Fields>
                        <ext:RecordField Name="name" />
                        <ext:RecordField Name="url" />      
                        <ext:RecordField Name="size" Type="Int" />
                        <ext:RecordField Name="lastmod" Type="Date" DateFormat="yyyy-MM-ddTHH:mm:ss" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>   
                       
        <ext:Panel 
            ID="ImagePanel" 
            runat="server" 
            Cls="images-view" 
            Frame="true" 
            AutoHeight="true" 
            Width="535" 
            Collapsible="true" 
            Layout="Fit"
            Title="Simple DataView (0 items selected)">
            <Items>
                <ext:DataView ID="ImageView" runat="server"
                    StoreID="Store1"
                    AutoHeight="true"
                    MultiSelect="true"
                    OverClass="x-view-over"
                    ItemSelector="div.thumb-wrap"
                    EmptyText="No images to display">
                    <Template runat="server">
                        <Html>
							<tpl for=".">
								<div class="thumb-wrap" id="{name}">
									<div class="thumb"><img src="{url}" title="{name}"></div>
									<span class="x-editable">{shortName}</span>
								</div>
							</tpl>
							<div class="x-clear"></div>    
						</Html>
                    </Template>                         
                    <PrepareData Fn="prepareData" />                
                    <Listeners>
                        <SelectionChange Fn="selectionChaged" /> 
                    </Listeners>   
                    
                    <Plugins>
                        <ext:GenericPlugin runat="server" InstanceName="Ext.DataView.DragSelector" />
                    </Plugins>
                </ext:DataView>
            </Items>        
            
            <Buttons>
                <ext:Button runat="server" Text="Submit selected">
                    <DirectEvents>
                        <Click OnEvent="Button1_Click" />
                    </DirectEvents>
                </ext:Button>
                
                <ext:Button runat="server" Text="Submit selected with values">
                    <DirectEvents>
                        <Click OnEvent="SubmitSelection">
                            <ExtraParams>
                                <ext:Parameter Name="Values" Value="Ext.encode(#{ImageView}.getRowsValues())" Mode="Raw" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                
                <ext:Button runat="server" Text="Clear Selection">
                    <DirectEvents>
                        <Click OnEvent="Clear_Click" />
                    </DirectEvents>
                </ext:Button>
                
                <ext:Button runat="server" Text="Add 'Zack' to selection ">
                    <DirectEvents>
                        <Click OnEvent="Add_Click" />
                    </DirectEvents>
                </ext:Button>
            </Buttons>
        </ext:Panel>
        
        <div style="width:523px; border:1px solid gray; padding:5px;">
            <ext:Label ID="Label1" runat="server" />
        </div>
    </form>
</body>
</html>
