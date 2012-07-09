<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FlashComponent - Ext.NET Examples</title>    
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />    
</head>
<body>    
    <form runat="server">    
        <ext:ResourceManager runat="server" />
        
        <script type="text/javascript">
            var player = {
                play : function () {
                    Button1.disable();
                    Button2.enable();
                    Button3.enable();
                    //Window1.items.items[0].el.dom.api_play();
                    VideoPlayer.el.dom.api_play();
                },
                
                pause : function () {
                    Button3.disable();
                    Button2.disable();
                    Slider1.disable();
                    Button1.enable();
                    //Window1.items.items[0].el.dom.api_pause();
                    VideoPlayer.el.dom.api_pause();
                },
            
                volume : function (el, level) {
                    //Window1.items.items[0].el.dom.api_setVolume(level)
                    VideoPlayer.el.dom.api_setVolume(level);
                }
            };
        </script>
        
        <ext:Window 
            ID="Window1"
            runat="server" 
            Title="Flash Movie" 
            Layout="fit" 
            Height="320" 
            Width="402"
            Maximizable="true">
            <TopBar>
                <ext:Toolbar runat="server">
                    <Items>
                        <ext:Button 
                            ID="Button1" 
                            runat="server" 
                            Text="Play" 
                            Icon="ControlPlayBlue" 
                            Handler="player.play" 
                            />
                        <ext:Button 
                            ID="Button2" 
                            runat="server" 
                            Text="Pause" 
                            Icon="ControlPauseBlue" 
                            Handler="player.pause" 
                            Disabled="true" 
                            />
                        <ext:ToolbarFill runat="server" />
                        <ext:SplitButton ID="Button3" runat="server" Icon="Sound" Disabled="true">
                            <Menu>
                                <ext:Menu runat="server">
                                    <Items>
                                        <ext:Slider ID="Slider1" runat="server" Width="100" Number="100">
                                            <Plugins>
                                                <ext:SliderTip ID="SliderTip1" runat="server" />
                                            </Plugins>
                                            <Listeners>
                                                <Change Fn="player.volume" />
                                            </Listeners>
                                        </ext:Slider>            
                                    </Items>
                                </ext:Menu>
                            </Menu>
                        </ext:SplitButton>
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <Items>
                <ext:FlashComponent 
                    ID="VideoPlayer"
                    runat="server" 
                    Url="http://vimeo.com/moogaloop.swf?clip_id=3911557&amp;server=vimeo.com&amp;show_title=1&amp;show_byline=1&amp;show_portrait=0&amp;color=&amp;fullscreen=1&js_api=1">
                    <FlashParams>
                        <ext:Parameter Name="allowfullscreen" Value="true" Mode="Raw" />                
                    </FlashParams>
                </ext:FlashComponent>
            </Items>
        </ext:Window>
    </form>
</body>
</html>
