<%@ Page Language="C#" %>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FormLayouts built in markup - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>FormLayouts built in markup</h1>
        
        <h2>Form1 - Very Simple</h2>

        <ext:Panel 
            ID="Panel1" 
            runat="server" 
            Title="Simple Form"
            PaddingSummary="5px 5px 0"
            Width="350"
            Frame="true"
            ButtonAlign="Center"
            Layout="Form">
            <Items>
                <ext:TextField runat="server" FieldLabel="First Name" AllowBlank="false" AnchorHorizontal="100%" />
                <ext:TextField runat="server" FieldLabel="Last Name" AnchorHorizontal="100%" />
                <ext:TextField runat="server" FieldLabel="Company" AnchorHorizontal="100%" />
                <ext:TextField runat="server" FieldLabel="Email" Vtype="email" AnchorHorizontal="100%" />
            </Items>
            <Buttons>
                <ext:Button runat="server" Text="Save" />
                <ext:Button runat="server" Text="Cancel" />
            </Buttons>
        </ext:Panel>

        <h2>Form 2 - Adding fieldsets</h2>
        
        <ext:Panel 
            ID="Panel2" 
            runat="server"
            Title="Simple Form with FieldSets"
            PaddingSummary="5px 5px 0"
            Width="350"
            Frame="true"
            ButtonAlign="Center">
            <Items>
                <ext:FieldSet 
                    runat="server"
                    CheckboxToggle="true"
                    Title="User Information"
                    AutoHeight="true"
                    Collapsed="true"
                    LabelWidth="75"
                    Layout="Form">
                    <Items>
                        <ext:TextField runat="server" FieldLabel="First Name" AllowBlank="false" AnchorHorizontal="100%" />
                        <ext:TextField runat="server" FieldLabel="Last Name" AnchorHorizontal="100%" />
                        <ext:TextField runat="server" FieldLabel="Company" AnchorHorizontal="100%" />
                        <ext:TextField runat="server" FieldLabel="Email" AnchorHorizontal="100%" />
                    </Items>
                </ext:FieldSet>
                <ext:FieldSet
                    runat="server"
                    CheckboxToggle="true"
                    Title="Phone Number"
                    AutoHeight="true"
                    LabelWidth="75"
                    Layout="Form">
                    <Items>
                        <ext:TextField runat="server" FieldLabel="Home" Text="(888) 555-1212" AnchorHorizontal="100%" />
                        <ext:TextField runat="server" FieldLabel="Business" AnchorHorizontal="100%" />
                        <ext:TextField runat="server" FieldLabel="Mobile" AnchorHorizontal="100%" />
                        <ext:TextField runat="server" FieldLabel="Fax" AnchorHorizontal="100%" />
                    </Items>
                </ext:FieldSet>
            </Items>
            <Buttons>
                <ext:Button runat="server" Text="Save" />
                <ext:Button runat="server" Text="Cancel" />
            </Buttons>
        </ext:Panel>
        
        <h2>Form 3 - A little more complex</h2>
        
        <ext:Panel 
            ID="Panel3"
            runat="server" 
            Title="Multi Column, Nested Layouts and Anchoring" 
            Frame="true"
            PaddingSummary="5px 5px 0"
            Width="600"
            ButtonAlign="Center">
            <Items>
                <ext:Container runat="server" Layout="Column" Height="100">
                    <Items>
                        <ext:Container runat="server" LabelAlign="Top" Layout="Form" ColumnWidth=".5">
                            <Items>
                                <ext:TextField runat="server" FieldLabel="First Name" AnchorHorizontal="95%" />
                                <ext:TextField runat="server" FieldLabel="Company" AnchorHorizontal="95%" />
                            </Items>
                        </ext:Container>
                        <ext:Container runat="server" LabelAlign="Top" Layout="Form" ColumnWidth=".5">
                            <Items>
                                <ext:TextField runat="server" FieldLabel="Last Name" AnchorHorizontal="95%" />
                                <ext:TextField runat="server" FieldLabel="Email" AnchorHorizontal="95%" />
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
                <ext:Container runat="server" LabelAlign="Top" Layout="Form">
                    <Items>
                        <ext:HtmlEditor runat="server" Height="200" FieldLabel="Biography" AnchorHorizontal="98%" />
                    </Items>
                </ext:Container>
            </Items>
            <Buttons>
                <ext:Button runat="server" Text="Save" />
                <ext:Button runat="server" Text="Cancel" />
            </Buttons>
        </ext:Panel>
        
        <h2>Form 4 - Forms can be a TabPanel...</h2>
        
        <ext:Panel
            ID="Panel4"
            runat="server"
            Border="false"
            Width="350"
            ButtonAlign="Center"
            Layout="Fit">
            <Items>
                <ext:TabPanel runat="server" ActiveTabIndex="0">
                    <Items>
                        <ext:Panel 
                            runat="server" 
                            Title="Personal Details" 
                            AutoHeight="true" 
                            Padding="10"
                            LabelWidth="75"
                            Layout="Form">
                            <Items>
                                <ext:TextField runat="server" FieldLabel="First Name" AllowBlank="false" AnchorHorizontal="100%" />
                                <ext:TextField runat="server" FieldLabel="Last Name" AnchorHorizontal="100%" />
                                <ext:TextField runat="server" FieldLabel="Company" AnchorHorizontal="100%" />
                                <ext:TextField runat="server" FieldLabel="Email" AnchorHorizontal="100%" />
                            </Items>
                        </ext:Panel>
                        <ext:Panel 
                            runat="server"
                            Title="Phone Numbers"
                            AutoHeight="true"
                            Padding="10"
                            LabelWidth="75"
                            Layout="Form">
                            <Items>
                                <ext:TextField ID="TextField1" runat="server" FieldLabel="Home" Text="(888) 555-1212" AnchorHorizontal="100%" />
                                <ext:TextField ID="TextField2" runat="server" FieldLabel="Business" AnchorHorizontal="100%" />
                                <ext:TextField ID="TextField3" runat="server" FieldLabel="Mobile" AnchorHorizontal="100%" />
                                <ext:TextField ID="TextField4" runat="server" FieldLabel="Fax" AnchorHorizontal="100%" />
                            </Items>
                        </ext:Panel>
                    </Items>
                </ext:TabPanel>
            </Items>
            <Buttons>
                <ext:Button runat="server" Text="Save" />
                <ext:Button runat="server" Text="Cancel" />
            </Buttons>
        </ext:Panel>
        
        <h2>Form 5 - Form with TabPanel</h2>
        
        <ext:Panel
            ID="Panel5"
            runat="server"
            Title="Inner Tabs"
            Width="600"
            Padding="5"
            ButtonAlign="Center">
            <Items>
                <ext:Container runat="server">
                    <Items>
                        <ext:Container runat="server" LabelAlign="Top" Layout="Form" ColumnWidth=".5">
                            <Items>
                                <ext:TextField runat="server" FieldLabel="First Name" AnchorHorizontal="95%" />
                                <ext:TextField runat="server" FieldLabel="Company" AnchorHorizontal="95%" />
                            </Items>
                        </ext:Container>
                        <ext:Container runat="server" LabelAlign="Top" Layout="Form" ColumnWidth=".5">
                            <Items>
                                <ext:TextField runat="server" FieldLabel="Last Name" AnchorHorizontal="95%" />
                                <ext:TextField runat="server" FieldLabel="Email" AnchorHorizontal="95%" />
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
                <ext:TabPanel 
                    runat="server" 
                    ActiveTabIndex="0" 
                    Plain="true"
                    Height="235">
                    <Items>
                        <ext:Panel
                            runat="server" 
                            Title="Personal Details" 
                            AutoHeight="true" 
                            Padding="10"
                            LabelWidth="75" 
                            LabelAlign="Top"
                            Layout="Form">
                            <Items>
                                <ext:TextField runat="server" FieldLabel="First Name" AllowBlank="false" Width="230" />
                                <ext:TextField runat="server" FieldLabel="Last Name" Width="230" />
                                <ext:TextField runat="server" FieldLabel="Company" Width="230" />
                                <ext:TextField runat="server" FieldLabel="Email" Width="230" />
                            </Items>
                        </ext:Panel>
                        <ext:Panel
                            runat="server"
                            Title="Phone Numbers"
                            AutoHeight="true" 
                            Padding="10"
                            LabelWidth="75" 
                            LabelAlign="Top"
                            Layout="Form">
                            <Items>
                                <ext:TextField runat="server" FieldLabel="Home" Text="(888) 555-1212" Width="230" />
                                <ext:TextField runat="server" FieldLabel="Business" Width="230" />
                                <ext:TextField runat="server" FieldLabel="Mobile" Width="230" />
                                <ext:TextField runat="server" FieldLabel="Fax" Width="230" />
                            </Items>
                        </ext:Panel>
                        <ext:Panel
                            runat="server"
                            Title="Biography"
                            Padding="10"
                            Layout="Fit">
                            <Items>
                                <ext:HtmlEditor runat="server" />
                            </Items>
                        </ext:Panel>
                        <ext:Panel 
                            ID="Tab4"
                            runat="server"
                            Title="Tab 4"
                            Layout="Form"
                            LabelWidth="75"
                            Padding="10" 
                            LabelAlign="Top">
                            <Items>
                                <ext:TextField runat="server" FieldLabel="Name" Width="230" />
                                <ext:TextField runat="server" FieldLabel="Age" Width="230" />
                            </Items>
                        </ext:Panel>
                    </Items>
                </ext:TabPanel>
            </Items>
            <Buttons>
                <ext:Button runat="server" Text="Save" />
                <ext:Button runat="server" Text="Cancel" />
            </Buttons>
        </ext:Panel>
    </form>
</body>
</html>