<%@ Control Language="C#" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<ext:XScript runat="server">
    <script type="text/javascript">
        var submitComment = function () {
            #{CommentForm}.getForm().submit({
                clientValidation: true,
                url     : '/ExampleLoader.ashx',
                waitMsg : "Adding comment...",
                params  : {
                    action : "comments.add",
                    url    : winComments.url
                },
                success : function () {
                    updateComments(true, winComments.url);
                },
                failure: function(form, action) {
                    switch (action.failureType) {
                        case Ext.form.Action.CLIENT_INVALID:
                            Ext.Msg.alert('Failure', 'Form fields may not be submitted with invalid values');
                            break;
                        case Ext.form.Action.CONNECT_FAILURE:
                            Ext.Msg.alert('Failure', 'Ajax communication failed');
                            break;
                        case Ext.form.Action.SERVER_INVALID:
                           Ext.Msg.alert('Failure', action.result.msg);
                   }
                }
            });
        };
    </script>
</ext:XScript>

<ext:Window 
    ID="winComments" 
    runat="server"
    Width="925"
    Height="650"
    Icon="Comments"
    Title="Comments"
    Layout="Border"
    Hidden="true"
    Modal="true">
    <Listeners>
        <%--<BeforeShow Handler="var height = Ext.getBody().getViewSize().height;if (this.getSize().height > height) {this.setHeight(height - 20)}" />--%>
        <Hide Handler="#{CommentsBody}.body.update('No comments. Be the first...');TagsView.store.removeAll();" />
    </Listeners>
    <Buttons>
        <ext:Button runat="server" Text="Close">
            <Listeners>
                <Click Handler="#{winComments}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
    <Items>
        <ext:Panel 
            runat="server" 
            Region="Center"
            Layout="Border"
            Border="false">
            <Items>
                <ext:FormPanel 
                    ID="CommentForm" 
                    runat="server" 
                    Region="North"
                    Padding="5"
                    Title="Comments"
                    Icon="Comments"
                    Collapsible="true"
                    AnimCollapse="false"
                    Height="250"
                    Margins="5 5 0 5">
                    <Buttons>
                        <ext:Button runat="server" Text="Add" Icon="Add">
                            <Listeners>
                                <Click Fn="submitComment" />
                            </Listeners>
                        </ext:Button>
                    </Buttons>
                    <Items>
                        <ext:TextField 
                            ID="UserName" 
                            runat="server" 
                            AnchorHorizontal="100%"
                            FieldLabel="Username"
                            MaxLength="128"
                            />
                            
                        <ext:TextField 
                            ID="CommentName" 
                            runat="server" 
                            AnchorHorizontal="100%"
                            FieldLabel="Subject"
                            MaxLength="128"
                            />
                        
                        <ext:TextArea 
                            ID="CommentMessage" 
                            runat="server"
                            AllowBlank="false"
                            FieldLabel="Message"
                            AnchorHorizontal="100%"
                            MaxLength="1024"
                            Height="120"
                            />                      
                    </Items>
                    <Listeners>
                        <Hide Handler="#{CommentForm}.reset();" />
                    </Listeners>
                </ext:FormPanel>
                <ext:Panel 
                    ID="CommentsBody" 
                    runat="server"
                    Region="Center"
                    AutoScroll="true"
                    Padding="5"
                    Margins="0 5 5 5"
                    Html="No Comments :("
                    />
            </Items>
        </ext:Panel>
        
        <ext:Panel 
            runat="server"
            Region="East"
            Title="Tags"
            Icon="Tag"
            Margins="5 5 5 0"
            CMargins="5 5 5 0"
            Collapsible="true"
            AnimCollapse="false"
            Width="200"
            Layout="Fit">
            <TopBar>
                <ext:Toolbar runat="server">
                    <Items>
                        <ext:TextField ID="TagField" runat="server" StyleSpec="margin-top:2px;" />
                        <ext:ToolbarSpacer runat="server" />
                        <ext:Button runat="server" Icon="Add" Text="Add" ToolTip="Add Tag">
                            <DirectEvents>
                                <Click 
                                    Url="/ExampleLoader.ashx" 
                                    CleanRequest="true"
                                    Before="return TagsView.store.findBy(function (r){ return r.data.Tag == TagField.getValue();}) <= 0;"
                                    Success="TagsView.store.addRecord({Tag:TagField.getValue()}, true);">
                                    <ExtraParams>
                                        <ext:Parameter Name="action" Value="tags.add" Mode="Value" />
                                        <ext:Parameter Name="tag" Value="TagField.getValue()" Mode="Raw" />
                                        <ext:Parameter Name="url" Value="winComments.url" Mode="Raw" />
                                    </ExtraParams>
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <Items>
                <ext:ListView ID="TagsView" runat="server">
                    <Store>
                        <ext:Store runat="server" AutoLoad="false" WarningOnDirty="false">
                            <Proxy>
                                <ext:HttpProxy Url="/ExampleLoader.ashx" />
                            </Proxy>
                            <BaseParams>
                                <ext:Parameter Name="action" Value="tags.read" Mode="Value" />
                                <ext:Parameter Name="url" Value="winComments.url" Mode="Raw" />
                            </BaseParams>
                            <Reader>
                                <ext:JsonReader>
                                    <Fields>
                                        <ext:RecordField Name="Tag" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    
                    <Columns>
                        <ext:ListViewColumn Header="Tags" DataIndex="Tag" Width="1" />
                    </Columns>
                </ext:ListView>
            </Items>
        </ext:Panel>
    </Items>
</ext:Window>

<ext:XTemplate ID="tplComments" runat="server" IDMode="Static">
    <Html>
        <tpl for=".">
            <div class="ecomment">
                 <table class="tborder" border="0" cellSpacing="1" cellPadding="6" width="100%" align="center">
                     <tr>
                        <td class="thead">
                            {Title}
                        </td>
                     </tr>
                     <tr>
                        <td class="alt2">
                            <table border="0" cellSpacing="6" cellPadding="0" width="100%">
                                <tr>
                                    <td>
                                        <img src="resources/images/commentlogo.png" width="32" height="32" />
                                    </td>
                                    <td style="white-space:nowrap">
                                        <span class="username">{Name}</span>
                                    </td>
                                    <td width="100%"></td>
                                    <td style="white-space:nowrap">
                                        {[ Date.parseDate(values.Time, "Y-m-dTh:i:s").format("d M Y, H:i")]}
                                    </td>
                                </tr>
                            </table>
                        </td>
                     </tr>
                     <tr>
                        <td style="padding:8px;font-size:13px;">
                            {Message}
                        </td>
                     </tr>
                 </table>
            </div>
        </tpl>
    </Html>
</ext:XTemplate>