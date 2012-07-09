<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TabPanel with MenuTab - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript">
        var beforeMenu = function (pnl, tab, menu) {
            menu.items.get(0).component.setText(tab.title);
            
            var doLayout = false;
            while (menu.items.getCount() > 4) {
                var item = menu.getComponent(4);
                item.destroy();
                menu.remove(item);
            }
            
            if (tab.id == "customMenuTab") {
                menu.addSeparator();
                menu.addMenuItem({
                    text    : "Show Menu for last Tab",
                    handler : function () {
                        pnl.items.get(pnl.items.getCount() - 1).showTabMenu();
                    }
                });
                
                menu.addMenuItem({
                    text    : "Hide Menu for last Tab",
                    handler : function () {
                        pnl.items.get(pnl.items.getCount() - 1).hideTabMenu();
                    }
                });
            }
        };
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>TabPanel with TabMenu</h1>
        
        <h2>Simple TabMenu</h2>
        
        <ext:TabPanel ID="TabPanel1" runat="server" Height="100">
            <Items>
                <ext:Panel 
                    runat="server" 
                    Title="No Menu"
                    />
                <ext:Panel 
                    runat="server" 
                    Title="Menu 1">      
                    <TabMenu>
                        <ext:Menu runat="server">
                            <Items>
                                <ext:MenuItem runat="server" Text="Item 1" />
                                <ext:MenuItem runat="server" Text="Item 2" />
                                <ext:MenuSeparator runat="server" />
                                <ext:ComponentMenuItem runat="server">
                                    <Component>
                                        <ext:Label runat="server" Text="Rename Tab:" />    
                                    </Component>
                                </ext:ComponentMenuItem>                                
                                <ext:ComponentMenuItem runat="server" ComponentElement="Wrap">
                                    <Component>
                                        <ext:TriggerField ID="RenameField" runat="server" Text="New title">
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Empty" Qtip="Click to rename" />
                                            </Triggers>
                                            <Listeners>
                                                <TriggerClick Handler="this.parentMenu.tab.setTitle(this.getValue());this.parentMenu.hide();" />
                                            </Listeners>
                                        </ext:TriggerField>
                                    </Component>
                                </ext:ComponentMenuItem>
                            </Items>
                        </ext:Menu>
                    </TabMenu>          
                </ext:Panel>
                
                <ext:Panel
                    ID="Tab3"
                    runat="server" 
                    Title="Menu 2" 
                    Closable="true" 
                    Padding="6">    
                    <TabMenu>
                        <ext:ColorMenu runat="server">
                            <Listeners>
                                <Select Handler="#{TabPanel1}.setActiveTab(this.tab); this.tab.body.applyStyles(String.format('background-color:{0}', '#' + color));" />
                            </Listeners>
                        </ext:ColorMenu>
                    </TabMenu>                 
                </ext:Panel>
            </Items>
        </ext:TabPanel>
        
        <h2>Default TabMenu</h2>
        
        <ext:TabPanel ID="TabPanel2" runat="server" Height="100">
            <DefaultTabMenu>
                <ext:Menu runat="server" EnableScrolling="false">
                     <Items>
                         <ext:ComponentMenuItem runat="server">
                            <Component>
                                <ext:Label runat="server" StyleSpec="font-weight:bold;" />    
                            </Component>
                         </ext:ComponentMenuItem>
                         <ext:MenuSeparator runat="server" />
                         <ext:MenuItem runat="server" Text="Item 1" />
                         <ext:MenuItem runat="server" Text="Item 2" />
                     </Items>                     
                </ext:Menu>
            </DefaultTabMenu>
            <Listeners>
                <BeforeTabMenuShow Fn="beforeMenu" />
            </Listeners>
            <Items>
                <ext:Panel 
                    runat="server" 
                    TabMenuHidden="true"
                    Title="No Menu"
                    />
                <ext:Panel 
                    runat="server" 
                    Title="Default Menu"
                    />
                <ext:Panel 
                    ID="customMenuTab"
                    runat="server" 
                    Title="Default Menu +"
                    />
                <ext:Panel 
                    runat="server" 
                    TabMenuHidden="true"
                    Title="Default Menu"
                    />
            </Items>
        </ext:TabPanel>        
    </form>
</body>
</html>
