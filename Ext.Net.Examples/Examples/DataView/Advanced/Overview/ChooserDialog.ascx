<%@ Control Language="C#" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    public string StoreID { get; set; }
    public string Callback { get; set; }
    public string Folder { get; set; }
    public string AnimateElement { get; set; }
    public string WindowID
    {
        get
        {
            return this.ImageChooserDialog.ClientID;
        }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            this.resourceManagerProxy1.Listeners.DocumentReady.Handler = string.Format(
                "this.{0}_class = new ChooserDialog(this.{1}, this.{2}, this.{3}, this.{4}, {5}, null, '{6}');", 
                this.ClientID, 
                this.ImageChooserDialog.ClientID, 
                this.ImageView.ClientID, 
                this.ImageDetailPanel.ClientID, 
                this.DetailsTemplate.ClientID, 
                this.Callback, 
                this.Folder);

            this.ImageView.PrepareData.Handler = string.Concat("return ", this.ClientID, "_class.formatData(data);");
        
            this.ImageView.Listeners.SelectionChange.Handler = string.Concat(this.ClientID, "_class.showDetails();");
            this.ImageView.Listeners.SelectionChange.Buffer = 100;

            this.ImageView.Listeners.DblClick.Handler = string.Concat(this.ClientID, "_class.doCallback();");
            this.OkBtn.Listeners.Click.Handler = string.Concat(this.ClientID, "_class.doCallback();");
            this.CancelBtn.Listeners.Click.Handler = string.Concat(this.ClientID, "_class.windowDialog.hide();");
            this.ImageView.StoreID = this.StoreID;
        }
    }
</script>

<ext:ResourceManagerProxy ID="resourceManagerProxy1" runat="server" />

<ext:XTemplate ID="DetailsTemplate" runat="server">
    <Html>
		<div class="details">
			<tpl for=".">
				<img src="{url}" /><div class="details-info">
				<b>Image Name:</b>
				<span>{name}</span>
				<b>Size:</b>
				<span>{sizeString}</span>
				<b>Last Modified:</b>
				<span>{dateString}</span></div>
			</tpl>
		</div>
	</Html>
</ext:XTemplate>

<ext:Window 
    ID="ImageChooserDialog" 
    runat="server"
    Icon="Images"
    Title="Choose an Image"
    MinHeight="300"
    MinWidth="500"
    Width="515"
    Height="350"
    Modal="true"         
    Border="false"
    Cls="img-chooser-dlg"
    Hidden="true">
    <Items>        
        <ext:BorderLayout ID="BorderLayout1" runat="server">
            <Center>
                <ext:Panel runat="server" AutoScroll="true" Cls="img-chooser-view">
                    <Items>
                        <ext:DataView 
                            ID="ImageView"
                            runat="server" 
                            SingleSelect="true" 
                            OverClass="x-view-over" 
                            ItemSelector="div.thumb-wrap" 
                            EmptyText="<div style='padding:10px;'>No images match the specified filter</div>">
                            <Template runat="server">
                                <Html>
									<tpl for=".">
										<div class="thumb-wrap" id="{name}">
										<div class="thumb"><img src="{url}" title="{name}" /></div>
										<span>{shortName}</span></div>
									</tpl>
								</Html>
                            </Template>
                            <Listeners>                                    
                                <BeforeSelect Handler="return this.store.getRange().length > 0;" />                                    
                            </Listeners>                                
                        </ext:DataView>  
                    </Items>
                </ext:Panel>
            </Center>
            <East Collapsible="True" Split="True" MinWidth="150" MaxWidth="250">
                <ext:Panel runat="server" ID="ImageDetailPanel" Title="Selected Image" Width="150px" />
            </East>            
        </ext:BorderLayout>                
    </Items>
    <Buttons>
        <ext:Button runat="server" ID="OkBtn" Text="OK" />
        <ext:Button runat="server" ID="CancelBtn" Text="Cancel" />
    </Buttons>
</ext:Window>