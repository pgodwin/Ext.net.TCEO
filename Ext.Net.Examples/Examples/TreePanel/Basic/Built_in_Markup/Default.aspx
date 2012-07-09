<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Multi Node TreePanel built using markup - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>Multi Node TreePanel built using markup</h1>       
        
        <ext:TreePanel 
            ID="TreePanel1" 
            runat="server" 
            Width="300" 
            Height="450" 
            Icon="BookOpen" 
            Title="Catalog" 
            AutoScroll="true">
            <TopBar>
                <ext:Toolbar runat="server">
                    <Items>
                        <ext:Button ID="Button1" runat="server" Text="Expand All">
                            <Listeners>
                                <Click Handler="#{TreePanel1}.expandAll();" />
                            </Listeners>
                        </ext:Button>
                        <ext:Button ID="Button2" runat="server" Text="Collapse All">
                            <Listeners>
                                <Click Handler="#{TreePanel1}.collapseAll();" />
                            </Listeners>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <Root>
                <ext:TreeNode Text="Composers" Expanded="true">
                    <Nodes>
                        <ext:TreeNode Text="Beethoven" Icon="UserGray">
                            <Nodes>
                                <ext:TreeNode Text="Concertos">
                                    <Nodes>
                                        <ext:TreeNode Text="No. 1 - C" Icon="Music" />
                                        <ext:TreeNode Text="No. 2 - B-Flat Major" Icon="Music" />
                                        <ext:TreeNode Text="No. 3 - C Minor" Icon="Music" />
                                        <ext:TreeNode Text="No. 4 - G Major" Icon="Music" />
                                        <ext:TreeNode Text="No. 5 - E-Flat Major" Icon="Music" />
                                    </Nodes>
                                </ext:TreeNode>
                                <ext:TreeNode Text="Quartets">
                                    <Nodes>
                                        <ext:TreeNode Text="Six String Quartets" Icon="Music" />
                                        <ext:TreeNode Text="Three String Quartets" Icon="Music" />
                                        <ext:TreeNode Text="Grosse Fugue for String Quartets" Icon="Music" />
                                    </Nodes>
                                </ext:TreeNode>
                                <ext:TreeNode Text="Sonatas">
                                    <Nodes>
                                        <ext:TreeNode Text="Sonata in A Minor" Icon="Music" />
                                        <ext:TreeNode Text="sonata in F Major" Icon="Music" />
                                    </Nodes>
                                </ext:TreeNode>
                                <ext:TreeNode Text="Symphonies">
                                    <Nodes>
                                        <ext:TreeNode Text="No. 1 - C Major" Icon="Music" />
                                        <ext:TreeNode Text="No. 2 - D Major" Icon="Music" />
                                        <ext:TreeNode Text="No. 3 - E-Flat Major" Icon="Music" />
                                        <ext:TreeNode Text="No. 4 - B-Flat Major" Icon="Music" />
                                        <ext:TreeNode Text="No. 5 - C Minor" Icon="Music" />
                                        <ext:TreeNode Text="No. 6 - F Major" Icon="Music" />
                                        <ext:TreeNode Text="No. 7 - A Major" Icon="Music" />
                                        <ext:TreeNode Text="No. 8 - F Major" Icon="Music" />
                                        <ext:TreeNode Text="No. 9 - D Minor" Icon="Music" />
                                    </Nodes>
                                </ext:TreeNode>
                            </Nodes>
                        </ext:TreeNode>
                        <ext:TreeNode Text="Brahms" Icon="UserGray">
                            <Nodes>
                                <ext:TreeNode Text="Concertos">
                                    <Nodes>
                                        <ext:TreeNode Text="Violin Concerto" Icon="Music" />
                                        <ext:TreeNode Text="Double Concerto - A Minor" Icon="Music" />
                                        <ext:TreeNode Text="Piano Concerto No. 1 - D Minor" Icon="Music" />
                                        <ext:TreeNode Text="Piano Concerto No. 2 - B-Flat Major" Icon="Music" />
                                    </Nodes>
                                </ext:TreeNode>
                                <ext:TreeNode Text="Quartets">
                                    <Nodes>
                                        <ext:TreeNode Text="Piano Quartet No. 1 - G Minor" Icon="Music" />
                                        <ext:TreeNode Text="Piano Quartet No. 2 - A Major" Icon="Music" />
                                        <ext:TreeNode Text="Piano Quartet No. 3 - C Minor" Icon="Music" />
                                        <ext:TreeNode Text="Piano Quartet No. 3 - B-Flat Minor" Icon="Music" />
                                    </Nodes>
                                </ext:TreeNode>
                                <ext:TreeNode Text="Sonatas">
                                    <Nodes>
                                        <ext:TreeNode Text="Two Sonatas for Clarinet - F Minor" Icon="Music" />
                                        <ext:TreeNode Text="Two Sonatas for Clarinet - E-Flat Major" Icon="Music" />
                                    </Nodes>
                                </ext:TreeNode>
                                <ext:TreeNode Text="Symphonies">
                                    <Nodes>
                                        <ext:TreeNode Text="No. 1 - C Minor" Icon="Music" />
                                        <ext:TreeNode Text="No. 2 - D Minor" Icon="Music" />
                                        <ext:TreeNode Text="No. 3 - F Major" Icon="Music" />
                                        <ext:TreeNode Text="No. 4 - E Minor" Icon="Music" />
                                    </Nodes>
                                </ext:TreeNode>
                            </Nodes>
                        </ext:TreeNode>
                        <ext:TreeNode Text="Mozart" Icon="UserGray">
                            <Nodes>
                                <ext:TreeNode Text="Concertos">
                                    <Nodes>
                                        <ext:TreeNode Text="Piano Concerto No. 12" Icon="Music"  />
                                        <ext:TreeNode Text="Piano Concerto No. 17" Icon="Music"  />
                                        <ext:TreeNode Text="Clarinet Concerto" Icon="Music"  />
                                        <ext:TreeNode Text="Violin Concerto No. 5" Icon="Music"  />
                                        <ext:TreeNode Text="Violin Concerto No. 4" Icon="Music"  />
                                    </Nodes>
                                </ext:TreeNode>
                            </Nodes>
                        </ext:TreeNode>
                    </Nodes>
                </ext:TreeNode>
            </Root>
            <BottomBar>
                <ext:StatusBar ID="StatusBar1" runat="server" AutoClear="1500" />
            </BottomBar>
            <Listeners>
                <Click 
                    Handler="#{StatusBar1}.setStatus({text: 'Node Selected: <b>' + node.text + '<br />', clear: true});" 
                    />
                <ExpandNode 
                    Handler="#{StatusBar1}.setStatus({text: 'Node Expanded: <b>' + node.text + '<br />', clear: true});" 
                    Delay="30" 
                    />
                <CollapseNode 
                    Handler="#{StatusBar1}.setStatus({text: 'Node Collapsed: <b>' + node.text + '<br />', clear: true});" 
                    />
            </Listeners>
        </ext:TreePanel>
    </form>
</body>
</html>