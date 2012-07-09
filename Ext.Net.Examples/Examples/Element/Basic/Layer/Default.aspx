<%@ Page Language="C#" %>

<%@ Import Namespace="Panel=Ext.Net.Panel" %>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<script runat="server">
    protected void ShowRight(object sender, DirectEventArgs e)
    {
        Layer layer = new Layer(new LayerConfig
        {
            ID = "Layer1",
            DH = {
                Cls = "layer",
                Children = {
                    new DomObject {
                        Children = {
                            new DomObject { 
                                Tag = HtmlTextWriterTag.H3,
                                Html = "Hello" 
                            },
                            new DomObject { 
                                Tag = HtmlTextWriterTag.Hr 
                            },
                            new DomObject {
                                Tag = HtmlTextWriterTag.A,
                                Html = "Close",
                                CustomConfig = {
                                    new ConfigItem("href", "#", ParameterMode.Value),
                                    new ConfigItem("onClick", "CompanyX.Close('Layer1'); return false;", ParameterMode.Value)
                                }
                            }
                        }
                    }
                }
            }
        });

        layer.AlignTo(Panel1.Element, "tl-tr", new int[] {5, 0}).SlideIn("l");
        ((Ext.Net.Button)sender).Disabled = true;
    }
    
    [DirectMethod]
    public void Close(string id)
    {
        X.Get(id).SlideOut("l", new FxConfig { 
            Callback = new JFunction(X.Get(id).ChainOn().Remove().ToScript()) 
        });
        
        this.Button1.Disabled = false;
    }
    
    protected void ShowBottom(object sender, DirectEventArgs e)
    {
        Panel p = new Panel {
            ID = "Panel2",
            Title = "Panel in Layer",
            Cls = "x-hidden",
            Html = "Ext.Net Panel",
            Padding = 5,
            Width = 300, 
            Height = 100,
            Tools = { 
                new Tool { 
                    Type = ToolType.Close, 
                    Handler = "CompanyX.Close2();" 
                } 
            }
        };
        
        p.Render(X.Body().Descriptor, RenderMode.RenderTo);
        
        Layer layer = new Layer(new LayerConfig {
            ID = "Layer2",
            ExistingElement = p.Element
        });

        layer.AlignTo(Panel1.Element, "tl-bl", new int[] { 0, 5 }).SlideIn("t");
        ((Ext.Net.Button)sender).Disabled = true;
    }

    [DirectMethod]
    public void Close2()
    {
        Element l2 = X.Get("Layer2").ChainOn();
        l2.SlideOut("t", new FxConfig { Callback = new JFunction(l2.Remove().ToScript()) }).Render();
        Button2.Disabled = false;
    }
   
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Layer Overview - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />  
    
    <style type="text/css">
        .layer {             
             width : 100px;
             height : 250px;
             padding : 5px;
             border : solid 1px silver;
        }
        
        .layer div {
            height : 238px;
            background-color : silver;
            padding : 5px;
        }
    </style>
</head>
<body>
    <ext:ResourceManager runat="server" DirectMethodNamespace="CompanyX" DirectEventUrl="Default.aspx" />  
    
    <ext:Panel 
        ID="Panel1" 
        runat="server" 
        Title="Panel" 
        Width="300"
        Height="300">
        <Buttons>
            <ext:Button ID="Button1" runat="server" Text="Show Right">
                <DirectEvents>
                    <Click OnEvent="ShowRight">
                        <EventMask MinDelay="250" ShowMask="true" CustomTarget="={#{Panel1}.getBody()}" />
                    </Click>
                </DirectEvents>
            </ext:Button>
            
            <ext:Button ID="Button2" runat="server" Text="Show Bottom">
                <DirectEvents>
                    <Click OnEvent="ShowBottom">
                        <EventMask MinDelay="250" ShowMask="true" CustomTarget="={#{Panel1}.getBody()}" />
                    </Click>
                </DirectEvents>
            </ext:Button>
        </Buttons>
    </ext:Panel>
</body>
</html>