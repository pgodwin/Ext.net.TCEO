<%@ Page Language="C#" %>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<script runat="server">
    protected void SubmitColor(object sender, DirectEventArgs e)
    {
        X.Js.Alert("Color: " + System.Drawing.Color.FromArgb(RedSlider.Slider.Value, GreenSlider.Slider.Value, BlueSlider.Slider.Value).ToString());
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SliderField - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript">
        var toHex = function (value) {
            var str = value.toString(16);
            
            if (str.length == 1) {
                str = "0" + str;
            }
            
            return str;
        };
        
        var updateColor = function () {
            var color = "#" +
                toHex(RedSlider.getValue().toString(16)) +
                toHex(GreenSlider.getValue().toString(16)) +
                toHex(BlueSlider.getValue().toString(16));
            
            color = color.toUpperCase();
            
            ColorPreview.setTitle("Color: " + color);
            ColorPreview.body.setStyle("background-color", color);
        };
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>SliderField</h1>
        
        <ext:FormPanel 
            ID="FormPanel1" 
            runat="server" 
            Title="Color Chooser"
            Width="400"
            Height="250"
            ButtonAlign="Left"
            Padding="10">
            <Items>
                <ext:SliderField 
                    ID="RedSlider" 
                    runat="server" 
                    FieldLabel="Red" 
                    LabelStyle="color:red">
                    <Slider runat="server" MaxValue="255" Value="255">
                        <Listeners>
                            <Change Fn="updateColor" />
                        </Listeners>
                        <Plugins>
                            <ext:SliderTip runat="server">
                                <GetText Handler="return toHex(thumb.value).toUpperCase();" />
                            </ext:SliderTip>
                        </Plugins>
                    </Slider>  
                </ext:SliderField>
                
                <ext:SliderField 
                    ID="GreenSlider" 
                    runat="server" 
                    FieldLabel="Green" 
                    LabelStyle="color:green">
                    <Slider runat="server" MaxValue="255" Value="255">
                        <Listeners>
                            <Change Fn="updateColor" />
                        </Listeners>
                        <Plugins>
                            <ext:SliderTip runat="server">
                                <GetText Handler="return toHex(thumb.value).toUpperCase();" />
                            </ext:SliderTip>
                        </Plugins>
                    </Slider>  
                </ext:SliderField>
                
                <ext:SliderField 
                    ID="BlueSlider" 
                    runat="server" 
                    FieldLabel="Blue" 
                    LabelStyle="color:blue">
                    <Slider runat="server" MaxValue="255" Value="255">
                        <Listeners>
                            <Change Fn="updateColor" />
                        </Listeners>
                        <Plugins>
                            <ext:SliderTip runat="server">
                                <GetText Handler="return toHex(thumb.value).toUpperCase();" />
                            </ext:SliderTip>
                        </Plugins>
                    </Slider>  
                </ext:SliderField>
                
                <ext:Panel 
                    ID="ColorPreview" 
                    runat="server" 
                    Title="Color: #FFFFFF" 
                    Border="false"
                    StyleSpec="margin:10px;" 
                    Height="75" 
                    />
                
            </Items>
            <FooterBar>
                <ext:Toolbar runat="server">
                    <Items>
                        <ext:Button runat="server" Text="Max All">
                            <Listeners>
                                <Click Handler="FormPanel1.getForm().items.each(function (c) { c.setValue(255); });" />
                            </Listeners>
                        </ext:Button>
                        <ext:Button runat="server" Text="Min All">
                            <Listeners>
                                <Click Handler="FormPanel1.getForm().items.each(function (c) { c.setValue(0); });" />
                            </Listeners>
                        </ext:Button>
                        <ext:ToolbarFill runat="server" />
                        <ext:Button runat="server" Text="Save">
                            <DirectEvents>
                                <Click OnEvent="SubmitColor" />
                            </DirectEvents>
                        </ext:Button>
                        <ext:Button runat="server" Text="Reset">
                            <Listeners>
                                <Click Handler="FormPanel1.getForm().reset();" />
                            </Listeners>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </FooterBar>
        </ext:FormPanel>
    </form>
</body>
</html>
