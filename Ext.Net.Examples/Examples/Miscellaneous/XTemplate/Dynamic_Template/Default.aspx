<%@ Page Language="C#" %>

<%@ Import Namespace="System.Collections.Generic" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void ApplyClick(object sender, DirectEventArgs e)
    {
        var tpl = new XTemplate { ID = "Template1" };
        
        tpl.Html = @"<p>Name: {Name}</p>
                   <p>Company: {Company}</p>
                   <p>Location: {City}, {State}</p>
                   <p>Kids:
                   <tpl for=""Kids"" if=""Name=='Jack Slocum'"">
                   <tpl if=""Age &gt; 1""><p>{#}. {parent.Name}'s kid - {Name}</p></tpl>
                   </tpl></p>";

        tpl.Overwrite(this.Panel1, new {
            Name = "Jack Slocum",
            Company = "Ext JS, LLC",
            Address = "4 Red Bulls Drive",
            City = "Cleveland",
            State = "Ohio",
            Zip = "44102",
            Kids = new object[] {
                new { Name = "Sara Grace", Age = 3 },
                new { Name = "Zachary", Age = 2 },
                new { Name = "John James", Age = 0 }              
            }
        });
        
        tpl.Render();
        
        this.Panel1.BodyElement.Highlight("#c3daf9", new HighlightConfig { Block = true });
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
   
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dynamic Template - Ext.NET Examples</title>    
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />    
    
    <style type="text/css">
        .x-panel {
            margin : 15px;
        }
        
        .x-panel-body p {
            margin    : 5px;
            font-size : 11px;
            padding   : 0px;
        }
    </style>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />

        <ext:Panel 
            ID="Panel1" 
            runat="server"
            Title="Panel"
            Width="300"
            Padding="10"
            Html="<p><i>Apply the template to see results here</i></p>">
            <TopBar>
                <ext:Toolbar runat="server">
                    <Items>
                        <ext:Button runat="server" Text="Apply Template">
                            <DirectEvents>
                                <Click OnEvent="ApplyClick">
                                    <EventMask ShowMask="true" CustomTarget="={#{Panel1}.body}" />
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
        </ext:Panel>
    </form>
</body>
</html>
