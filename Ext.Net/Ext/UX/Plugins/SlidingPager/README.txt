// ASP.NET Markup

<ext:Panel 
	ID="Panel1" 
	runat="server" 
	Title="Accordion" 
    Layout="accordion"
	Width="185" 
	Height="350">
    <Items>
        <ext:Panel runat="server" Title="Item1" />
        <ext:Panel runat="server" Title="Item2" />
        <ext:Panel runat="server" Title="Item3" />
        <ext:Panel runat="server" Title="Item4" />
    </Items>
    <Plugins>
        <ext:KeepActive runat="server" />
    </Plugins>
</ext:Panel>


// JavaScript

var pnl = new Ext.Panel({
	id     : "Panel1",
    title  : "Accordion",
    layout : "accordion",
    width  : 185,
    height : 350,
    items  : [
        { title : "Item1" },
        { title : "Item2" },
        { title : "Item3" },
        { title : "Item4" }
    ],
    plugins  : [ new Ext.ux.plugins.KeepActive() ],
    renderTo : Ext.getBody()
});
