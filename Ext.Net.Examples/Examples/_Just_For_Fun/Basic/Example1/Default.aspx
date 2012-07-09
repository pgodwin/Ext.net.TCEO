<%@ Page Language="C#" %>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
        .cards-conatiner {
            padding:0px;
            margin:0px;
            width:390px;
            font-size:12px;
        }
        
        .cards-header {
            padding: 0px 0px 0px 10px;	
	        height: 33px;
		    border-top:3px solid #ECE8D7;
	        background-color: #F8F5E8;
        }
        
        .cards-header ul, .cards-header li {
            list-style-type:none;
            list-style-image:none;
        }
        
        .cards-header li {
	        margin: 0px;
	        padding: 7px 5px 2px 0px;
            width:23%;
	        background-color: #F8F5E8;
	        text-transform:uppercase;
	        color:#333;
	        font-family:Georgia;
	        font-size: 12px;
	        line-height: normal;
            font-weight:700;
	        float: left;
	        list-style: none;
	        cursor: pointer;
	        text-align:center;
	        border-bottom: none;
       }
       
       .cards-header li a, .cards-header li a:visited {
	        margin: 0px;
	        padding: 4px 6px 4px 6px;        	
	        background-color: #E6E3D3;
	        color: #333;
	        text-decoration: none;        	
	        display: block;
       }

       .cards-header li a.current {
	        background-color: #333;
	        color: #ffffff;
	        text-decoration: none;
       }
       
       .card-content {
	        margin: 0px;
	        padding: 0px;
	        float:left;
	        border: 5px solid #F8F5E8;
        }
        
        
        .current-card {
	        margin: 0px;
	        padding: 10px;
            width:359px;
	        border-left: 1px solid #dddddd;
	        border-top: 1px solid #dddddd;
	        border-right: 1px solid #cccccc;
	        border-bottom: 1px solid #cccccc;	        
        }
    </style>
    
    <script type="text/javascript">
        var setCard = function (t) {
            t.addClass("current");
            var index = parseInt(t.getAttribute("rel"));
            CardsContainer.getLayout().setActiveItem(index);
        }
        var initCards = function () {
            var cards = this.el.select(".cards-header a");
            
            cards.hover(function (e, t) {
                cards.removeClass("current");
                setCard(Ext.fly(t));
            }, Ext.emptyFn, this);

            setCard(cards.first());
        }
    </script>
</head>
<body>
    <ext:ResourceManager runat="server" />
   
    <ext:Container runat="server" Cls="cards-conatiner">
        <Items>
            <ext:Container runat="server">
                <AutoEl Cls="cards-header">
                    <Children>
                        <ext:DomObject Tag="Ul">
                            <Children>
                                <ext:DomObject Tag="Li">
                                    <Children>
                                        <ext:DomObject Tag="A" Html="RECENT">
                                            <CustomConfig>
                                                <ext:ConfigItem Name="rel" Value="0" />
                                            </CustomConfig>
                                        </ext:DomObject>
                                    </Children>
                                </ext:DomObject>
                                
                                <ext:DomObject Tag="Li">
                                    <Children>
                                        <ext:DomObject Tag="A" Html="COMMENTS">
                                            <CustomConfig>
                                                <ext:ConfigItem Name="rel" Value="1" />
                                            </CustomConfig>
                                        </ext:DomObject>
                                    </Children>
                                </ext:DomObject>
                                
                                <ext:DomObject Tag="Li">
                                    <Children>
                                        <ext:DomObject Tag="A" Html="POPULAR">
                                            <CustomConfig>
                                                <ext:ConfigItem Name="rel" Value="2" />
                                            </CustomConfig>
                                        </ext:DomObject>
                                    </Children>
                                </ext:DomObject>
                                
                                <ext:DomObject Tag="Li">
                                    <Children>
                                        <ext:DomObject Tag="A" Html="TAGS">
                                            <CustomConfig>
                                                <ext:ConfigItem Name="rel" Value="3" />
                                            </CustomConfig>
                                        </ext:DomObject>
                                    </Children>
                                </ext:DomObject>
                            </Children>
                        </ext:DomObject>
                    </Children>
                </AutoEl>
            </ext:Container>
            
            <ext:Container runat="server" Cls="card-content">
                <Items>
                    <ext:Container ID="CardsContainer" runat="server" Cls="current-card" AutoHeight="true">
                        <Defaults>
                            <ext:Parameter Name="Border" Value="false" Mode="Raw" />
                        </Defaults>
                        <Items>
                            <ext:CardLayout runat="server">
                                <Items>
                                    <ext:Panel runat="server">
                                        <Content>
                                           RECENT
                                        </Content>
                                    </ext:Panel>
                                    
                                    <ext:Panel runat="server">
                                        <Content>
                                            COMMENTS<br />
                                            COMMENTS
                                        </Content>
                                    </ext:Panel>
                                    
                                    <ext:Panel runat="server">
                                        <Content>
                                            POPULAR<br />
                                            POPULAR<br />
                                            POPULAR
                                        </Content>
                                    </ext:Panel>
                                    
                                    <ext:Panel runat="server">
                                        <Content>
                                            TAGS<br />
                                            TAGS<br />
                                            TAGS<br />
                                            TAGS
                                        </Content>
                                    </ext:Panel>
                                </Items>
                            </ext:CardLayout>
                        </Items>
                    </ext:Container>
                </Items>
            </ext:Container>
        </Items>      
        <Listeners>
            <AfterLayout Fn="initCards" Single="true" />
        </Listeners>  
    </ext:Container>
</body>
</html>