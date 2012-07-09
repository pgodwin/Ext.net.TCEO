<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fixed Height TabPanel with options - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <div>
            <h1>Fixed Height TabPanel with options</h1>
            <p>Tabs with no tab strip and a fixed height that scroll the content.</p>
        </div>
        
        <div>
            <ext:TabPanel 
                ID="TabPanel1" 
                runat="server" 
                ActiveTabIndex="0" 
                Width="600" 
                Height="250" 
                Plain="true">
                <Items>
                    <ext:Panel 
                        ID="Tab1" 
                        runat="server" 
                        Title="Normal Tab" 
                        Html="My content was added with the Html Property."
                        Padding="6" 
                        AutoScroll="true" 
                        />
                    <ext:Panel 
                        ID="Tab2" 
                        runat="server" 
                        Title="Closable Tab" 
                        Html="You can close this Tab."
                        Padding="6" 
                        Closable="true" 
                        />
                    <ext:Panel 
                        ID="Tab3" 
                        runat="server" 
                        Title="Ajax Tab"                         
                        Padding="6"
                        AutoScroll="true">
                        <AutoLoad Url="ajax.aspx" />
                    </ext:Panel>
                    <ext:Panel 
                        ID="Tab4" 
                        runat="server" 
                        Title="Event Tab" 
                        Html="I am tab 3's content. I also have an event listener attached."
                        Padding="6" 
                        AutoScroll="true">
                        <Listeners>
                            <Activate Handler="Ext.Msg.alert('Event', this.title + ' was activated.');" />
                        </Listeners>
                    </ext:Panel>
                    <ext:Panel 
                        ID="Tab5" 
                        runat="server" 
                        Title="Disabled Tab" 
                        Disabled="true" 
                        Html="Can't see me cause I'm disabled"
                        AutoScroll="true" 
                        />
                </Items>
            </ext:TabPanel>
        </div>
    </form>
</body>
</html>
