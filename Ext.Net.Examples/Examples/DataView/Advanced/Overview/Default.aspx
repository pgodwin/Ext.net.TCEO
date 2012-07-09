<%@ Page Language="C#" %>

<%@ Import Namespace="System.Threading" %>
<%@ Import Namespace="System.Collections.Generic" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register src="ChooserDialog.ascx" tagname="ChooserDialog" tagprefix="uc1" %>
    
<script runat="server">
    private List<object> GetImages(string path)
    {
        string serverPath = Server.MapPath(path);
        string[] files = System.IO.Directory.GetFiles(serverPath);

        List<object> data = new List<object>(files.Length);

        foreach (string fileName in files)
        {
            System.IO.FileInfo fi = new System.IO.FileInfo(fileName);
            long size = fi.Length;
            string strSize = size < 1024 ? size + " bytes" : (Math.Round(((size * 10.0) / 1024)) / 10) + " KB";
            data.Add(new
            {
                name = fi.Name,
                url = path + fi.Name,
                sizeString = strSize,
                lastmod = fi.LastAccessTime
            });
        }

        return data;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            this.Button1.Listeners.Click.Handler = string.Format("openDialog({0}_class,{1},{2});", this.ChooserDialog1.ClientID, this.Store1.ClientID, this.ChooserDialog1.WindowID);
            this.Button2.Listeners.Click.Handler = string.Format("openDialog({0}_class,{1},{2});", this.ChooserDialog2.ClientID, this.Store1.ClientID, this.ChooserDialog2.WindowID);
        }
    }

    protected void Store1_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        this.Store1.DataSource = this.GetImages(e.Parameters["folder"]);
        this.Store1.DataBind();
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Advanced DataView - Ext.NET Example</title>
    
    <ext:ResourcePlaceHolder Mode="Script" runat="server" />
    
    <link href="chooser.css" rel="stylesheet" type="text/css" />
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />    
    
    <script src="ChooserDialog.js" type="text/javascript"></script>
    
    <script type="text/javascript">
        var insertImage = function (data) {
            Ext.DomHelper.append("images", {
                tag   : "img", 
                src   : data.url, 
                style : "margin:10px;visibility:hidden;"
            }, true).show(true).frame();            
        };

        var openDialog = function (dialog, store, window) {
            store.directEventConfig.eventMask.customTarget = window.body;
            dialog.show();
        };
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>Advanced DataView</h1>
        
        <p>This example shows loading a DataView in a Window.  Each item has a linked details view, and the DataView supports custom sorting and filtering.</p>
        
         <ext:Store runat="server" ID="Store1" AutoLoad="false" OnRefreshData="Store1_RefreshData">
            <Reader>
                <ext:JsonReader>
                    <Fields>
                        <ext:RecordField Name="name" />
                        <ext:RecordField Name="url" />      
                        <ext:RecordField Name="sizeString" />
                        <ext:RecordField Name="lastmod" Type="Date" DateFormat="yyyy-MM-ddTHH:mm:ss" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
            <DirectEventConfig>
                <EventMask ShowMask="true" Target="CustomTarget" />
            </DirectEventConfig>
        </ext:Store>      
        
        <uc1:ChooserDialog ID="ChooserDialog1" runat="server" StoreID="Store1" Callback="insertImage" Folder="../../Shared/images/thumbs/" />
        <uc1:ChooserDialog ID="ChooserDialog2" runat="server" StoreID="Store1" Callback="insertImage" Folder="../../Shared/images/thumbs2/" />
        
        <ext:Button 
            ID="Button1" 
            runat="server" 
            Text="Insert an Image from the Folder 1" 
            StyleSpec="display:inline" 
            />
            
        <ext:Button 
            ID="Button2" 
            runat="server" 
            Text="Insert an Image from the Folder 2" 
            StyleSpec="display:inline" 
            />
                
        <div id="images" style="margin:20px;width:600px;"></div>
    </form>
</body>
</html>
