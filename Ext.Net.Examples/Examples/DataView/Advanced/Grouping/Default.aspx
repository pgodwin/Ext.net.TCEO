<%@ Page Language="C#" %>

<%@ Import Namespace="System.Linq"%>
<%@ Import Namespace="System.Xml.Linq"%>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            XElement document = XElement.Load(Server.MapPath("resources/DashboardSchema.xml"));
            var defaultIcon = document.Attribute("defaultIcon") != null ? document.Attribute("defaultIcon").Value : "";
            
            var query = from g in document.Elements("group")
                   select new
                   {
                       Title = g.Attribute("title") != null ? g.Attribute("title").Value : "",
                       Items = (from i in g.Elements("item")
                               select new
                               {
                                   Title = i.Element("title") != null ? i.Element("title").Value : "",
                                   Icon = i.Element("item-icon") != null ? i.Element("item-icon").Value : defaultIcon,
                                   Id = i.Element("id") != null ? i.Element("id").Value : ""
                               }
                           )
                   };

            this.Store1.DataSource = query;
            this.Store1.DataBind();
        }
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Grouping DataView - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
        div.item-wrap {
            float : left;
            border : 1px solid transparent;
            margin : 5px 25px 5px 25px;
            width : 100px;
            cursor : pointer;
            height : 120px;
            text-align : center;
        }

        div.item-wrap img {
            margin : 5px 0px 0px 5px;
            width : 61px;
            height : 77px;
        }

        div.item-wrap h6 {
            font-size : 14px;
            color : #3A4B5B;
            font-family : tahoma,arial,san-serif;
        }

        .items-view .x-view-over { border : solid 1px silver; }

        #items-ct { padding : 0px 30px 24px 30px; }

        #items-ct h2 {
            border-bottom : 2px solid #3A4B5B;           
            cursor : pointer;                  
        }

        #items-ct h2 div {
            background : transparent url(resources/images/group-expand-sprite.gif) no-repeat 3px -47px;
            padding : 4px 4px 4px 17px;
            font-family : tahoma,arial,san-serif;
            font-size : 12px;
            color : #3A4B5B;
        }

        #items-ct .collapsed h2 div { background-position : 3px 3px; }
        #items-ct dl { margin-left : 2px; }
        #items-ct .collapsed dl { display : none; }
    </style>
    
    <script type="text/javascript">
        var selectionChanged = function (dv, nodes) {
            if (nodes.length > 0) {
                var id = nodes[0].id;
                Ext.Msg.alert("Click", "The node with id='" + id + "' has been clicked");
            }
        }
        
        var viewClick = function (dv, e) {
            var group = e.getTarget("h2", 3, true);
            
            if (group) {
                group.up("div").toggleClass("collapsed");
            }
        }
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>Grouping DataView Example</h1>
        
        <ext:Store ID="Store1" runat="server">        
            <Reader>
                <ext:JsonReader>
                    <Fields>
                        <ext:RecordField Name="Title" />
                        <ext:RecordField Name="Items" IsComplex="true" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        
        <ext:Panel 
            ID="DashBoardPanel" 
            runat="server" 
            Cls="items-view" 
            Layout="fit"
            AutoHeight="true"
            Width="800" 
            Border="false">
            <TopBar>
                <ext:Toolbar runat="server" Flat="true">
                    <Items>
                        <ext:ToolbarFill />
                        
                        <ext:Button runat="server" Icon="BulletPlus" Text="Expand All">
                            <Listeners>
                                <Click Handler="#{Dashboard}.el.select('.group-header').removeClass('collapsed');" />
                            </Listeners>
                        </ext:Button>
                        
                        <ext:Button runat="server" Icon="BulletMinus" Text="Collapse All">
                             <Listeners>
                                <Click Handler="#{Dashboard}.el.select('.group-header').addClass('collapsed');" />
                            </Listeners>
                        </ext:Button>
                        
                        <ext:ToolbarSpacer runat="server" Width="30" />
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <Items>
                <ext:DataView 
                    ID="Dashboard"
                    runat="server" 
                    StoreID="Store1" 
                    SingleSelect="true"
                    OverClass="x-view-over" 
                    ItemSelector="div.item-wrap" 
                    AutoHeight="true" 
                    EmptyText="No items to display">
                    <Template runat="server">
                        <Html>
							<div id="items-ct">
								<tpl for=".">
									<div class="group-header">
										<h2><div>{Title}</div></h2>
										<dl>
											<tpl for="Items">
												<div id="{Id}" class="item-wrap">
													<img src="{Icon}"/>
													<div>
														<H6>{Title}</H6>                                                    
													</div>
												</div>
											</tpl>
											<div style="clear:left"></div>
										 </dl>
									</div>
								</tpl>
							</div>
						</Html>
                    </Template>
                    <Listeners>
                        <SelectionChange Fn="selectionChanged" />
                        <ContainerClick Fn="viewClick" />
                    </Listeners>
                </ext:DataView>
            </Items>
        </ext:Panel>
        
    </form>
</body>
</html>
