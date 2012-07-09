<%@ Control Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<ext:Window 
    ID="winAbout" 
    runat="server" 
    Title="About" 
    Icon="Information" 
    Modal="true"
    Height="225" 
    Width="350"
    Layout="fit"
    Hidden="true">
    <Items>
        <ext:TabPanel runat="server" Border="false">
            <Items>
                <ext:Panel runat="server" Title="Info" Padding="5" BodyStyle="background-color:#fff;">
                    <Content>
                        Northind Traders Web Administration (1.0 RC) using:<br /><br />
                        <a href="http://www.ext.net/" target="_blank">Ext.NET 1.0 RC</a><br /><br />
                        <a href="http://www.extjs.com/" target="_blank">ExtJS 3.3+</a><br /><br /> 
                        <a href="http://www.asp.net/mvc/" target="_blank">ASP.NET MVC 2.0</a>
                    </Content>
                </ext:Panel>
                <ext:Panel runat="server" Title="Credits" Padding="5" BodyStyle="background-color:#fff;">
                    <Content>
                        Many icons provided by <a href="http://www.famfamfam.com/lab/icons/silk/" target="_blank">FamFamFam</a> under <a href="http://creativecommons.org/licenses/by/2.5/" target="_blank">Creative Commons Attribution 2.5 License</a>.
                    </Content>
                </ext:Panel>
                <ext:Panel 
                    runat="server" 
                    Title="License" 
                    Padding="5"
                    BodyStyle="background-color:#fff;">
                    <Content>
                        Source code for the Ext.Net.MVC.Demo project is release by Ext.NET, Inc. under an MIT open source license, see <a href="/License/License.txt" target="_blank">license</a>.
                        <br />
                        <br />
                        Download project source code from GoogleCode, see <a href="http://extnet-mvc.googlecode.com/" target="_blank">http://extnet-mvc.googlecode.com/</a>
                        <br />
                        <br />
                        Licensing information and download of Ext.NET is available at <a href="http://www.ext.net/download/" target="_blank">http://www.ext.net/download/</a>.
                    </Content>
                </ext:Panel>
            </Items>
        </ext:TabPanel>
    </Items>
    <BottomBar>
        <ext:Toolbar runat="server">
            <Items>
                <ext:ToolbarFill runat="server" />
                <ext:ToolbarTextItem runat="server" Text="Copyright 2006-2010 Ext.NET, Inc<br />" />
                <ext:ToolbarSpacer runat="server" />
            </Items>
        </ext:Toolbar>
    </BottomBar>
</ext:Window>