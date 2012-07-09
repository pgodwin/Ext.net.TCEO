<%@ Page Language="C#" %>

<%@ Import Namespace="System.Collections.Generic" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
    
<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            string path = Server.MapPath("../../../DataView/Shared/images/thumbs");
            string[] files = System.IO.Directory.GetFiles(path);

            List<object> data = new List<object>(files.Length);
            
            foreach (string fileName in files)
            {
                System.IO.FileInfo file = new System.IO.FileInfo(fileName);
                
                data.Add(new { name = file.Name,
                               url = "../../../DataView/Shared/images/thumbs/" + file.Name,
                               size = file.Length,
                               lastmod = file.LastAccessTime });
            }

            var store = this.ListView1.GetStore();
            
            store.DataSource = data;
            store.DataBind();
        }
    }

    protected void Button1_Click(object sender, DirectEventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        
        foreach (SelectedRow row in ListView1.SelectedRows)
        {
            sb.AppendFormat("RecordID: {0}&nbsp;&nbsp;&nbsp;&nbsp;Row index: {1}<br/>", row.RecordID, row.RowIndex);
        }
        
        this.Label1.Html = sb.ToString();
    }

    protected void Clear_Click(object sender, DirectEventArgs e)
    {
        this.ListView1.SelectedRows.Clear();
        this.ListView1.UpdateSelection();
    }

    protected void Add_Click(object sender, DirectEventArgs e)
    {
        this.ListView1.SelectedRows.Add(new SelectedRow("zack.jpg"));
        this.ListView1.UpdateSelection();
    }

    protected void SubmitSelection(object sender, DirectEventArgs e)
    {
        string json = e.ExtraParams["Values"];

        Dictionary<string, string>[] images = JSON.Deserialize<Dictionary<string, string>[]>(json);

        StringBuilder sb = new StringBuilder();
        sb.Append("<table cellspacing=\"15\">");
        bool addHeader = true;

        foreach (Dictionary<string, string> row in images)
        {
            if (addHeader)
            {
                sb.Append("<tr>");
            
                foreach (KeyValuePair<string, string> keyValuePair in row)
                {
                    sb.AppendFormat("<td style=\"white-space:nowrap;font-weight:bold;\">{0}</td>", keyValuePair.Key);
                }
                
                sb.Append("</tr>");

                addHeader = false;
            }

            sb.Append("<tr>");
            
            foreach (KeyValuePair<string, string> keyValuePair in row)
            {
                sb.AppendFormat("<td style=\"white-space:nowrap;\">{0}</td>", keyValuePair.Value);
            }
            
            sb.Append("</tr>");
        }
        
        sb.Append("</table>");
        this.Label1.Html = sb.ToString();
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ListView - Ext.NET Examples</title>    
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript">
        var selectionChaged = function (dv, nodes) {
			var count = nodes.length, s = l != 1 ? "s" : "";
			Panel1.setTitle("Simple ListView (" + count + " item" + s + " selected)");
		};
    </script>   
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>ListView Example</h1>
        
        <p>ListView is a high performance, light-weight version of a grid like display. 
            It provides you with selection, column resizing, sorting and other DataView features. 
            The columns have percentage based widths and uses templates to render the data in any required format. 
            If you need to show your data in a grid like display without some of the more advanced features of the &lt;ext:GridPanel></ext:GridPanel>, then ListView is the perfect solution.</p>
        
        <ext:Panel 
            ID="Panel1" 
            runat="server" 
            Width="650" 
            Height="300"
            Title="Simple List <i>View (0 items selected)</i>"
            Layout="Fit">
            <Items>
                <ext:ListView 
                    ID="ListView1" 
                    runat="server"
                    MultiSelect="true"
                    ReserveScrollOffset="true"
                    EmptyText="No Images to Display">
                    <Store>
                        <ext:Store runat="server">
                            <Reader>
                                <ext:JsonReader IDProperty="name">
                                    <Fields>
                                        <ext:RecordField Name="name" />
                                        <ext:RecordField Name="url" />      
                                        <ext:RecordField Name="size" Type="Int" />
                                        <ext:RecordField Name="lastmod" Type="Date" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <Columns>
                        <ext:ListViewColumn 
                            Header="File" 
                            Width="0.15" 
                            DataIndex="url" 
                            Template='<img style="width:60px;height:45px;" src="{url}" />' 
                            />
                        <ext:ListViewColumn 
                            Header="File" 
                            Width="0.35" 
                            DataIndex="name" 
                            />
                        <ext:ListViewColumn 
                            Header="Last Modified" 
                            Width="0.3" 
                            DataIndex="lastmod" 
                            Template='{lastmod:date("m-d h:i a")}' 
                            />
                        <ext:ListViewColumn 
                            Header="Size" 
                            Width="0.2" 
                            DataIndex="size" 
                            Align="Right" 
                            Template="{size:fileSize}" 
                            />
                    </Columns>
                    <Listeners>
                        <SelectionChange Fn="selectionChaged" /> 
                    </Listeners> 
                </ext:ListView>
            </Items>        
            <Buttons>
                <ext:Button runat="server" Text="Submit Selected" OnDirectClick="Button1_Click" />
                <ext:Button runat="server" Text="Submit Selected with Values">
                    <DirectEvents>
                        <Click OnEvent="SubmitSelection">
                            <ExtraParams>
                                <ext:Parameter Name="Values" Value="Ext.encode(#{ListView1}.getRowsValues())" Mode="Raw" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" Text="Clear Selections" OnDirectClick="Clear_Click" />
                <ext:Button runat="server" Text="Add 'Zack' to Selection " OnDirectClick="Add_Click" />
            </Buttons>
        </ext:Panel>
        
        <div style="width:640px; border:1px solid gray; padding:5px;">
            <ext:Label ID="Label1" runat="server" />
        </div>
    </form>
</body>
</html>
