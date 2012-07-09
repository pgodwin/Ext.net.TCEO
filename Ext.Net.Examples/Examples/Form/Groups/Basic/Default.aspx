<%@ Page Language="C#" %>

<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="Ext.Net.Utilities" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Button1_Click(object sender, DirectEventArgs e)
    {
        StringBuilder sb = new StringBuilder(255);

        sb.Append("<h1>Checked Items</h1>");
        sb.Append("<h2>CheckboxGroups</h2>");
        sb.Append("<blockquote>");
        
        List<CheckboxGroup> groups1 = Ext.Net.Utilities.ControlUtils.FindControls<CheckboxGroup>(this.Page.Form);

        groups1.ForEach(delegate(CheckboxGroup group) {
            int count = 0;

            group.CheckedItems.ForEach(delegate(Checkbox checkbox)
            {
                if (count == 0)
                {
                    sb.AppendFormat("<h3>{0}</h3>", group.FieldLabel);
                    sb.Append("<blockquote>");
                }
                sb.AppendFormat("{0}<br />", checkbox.BoxLabel);
                count++;
            });

            if (count > 0)
            {
                sb.Append("</blockquote>");
            }
        });
            
        sb.Append("</blockquote>");

        sb.Append("<h2>RadioGroups</h2>");
        sb.Append("<blockquote>");

        List<RadioGroup> groups2 = Ext.Net.Utilities.ControlUtils.FindControls<RadioGroup>(this.Page.Form);

        groups2.ForEach(delegate(RadioGroup group)
        {
            int count = 0;

            group.CheckedItems.ForEach(delegate(Radio radio)
            {
                if (count == 0)
                {
                    sb.AppendFormat("<h3>{0}</h3>", group.FieldLabel);
                    sb.Append("<blockquote>");
                }
                sb.AppendFormat("{0}<br />", radio.BoxLabel);
                count++;
            });

            if (count > 0)
            {
                sb.Append("</blockquote>");
            }
        });
        
        sb.Append("</blockquote>");
        
        this.Label1.Html = sb.ToString();
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CheckboxGroup and RadioGroup Configuration Options - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .x-check-group-alt {
            background: #D1DDEF;
            border-top: 1px dotted #B5B8C8;
            border-bottom: 1px dotted #B5B8C8;            
        }
    </style>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        
        <h1>CheckboxGroup and RadioGroup Configuration Options</h1>
        
        <ext:Panel 
            ID="Panel1"
            runat="server" 
            Title="Groups" 
            Width="600"
            Height="520"
            Frame="true"
            Layout="Fit">
            <Buttons>
                <ext:Button ID="Button1" runat="server" Text="Save" Icon="Disk">
                    <DirectEvents>
                        <Click OnEvent="Button1_Click" />
                    </DirectEvents>
                </ext:Button>
            </Buttons>
            <Items>
                <ext:TabPanel ID="TabPanel1" runat="server" ActiveTabIndex="0" Frame="true" DeferredRender="false">
                    <Items>
                        <ext:Panel ID="Tab1" runat="server" Title="Checkbox Groups" Padding="2">
                            <Items>
                                <ext:FormLayout runat="server" LabelWidth="110">
                                    <Anchors>
                                        <ext:Anchor Horizontal="100%">
                                            <ext:CheckboxGroup 
                                                ID="CheckboxGroup1" 
                                                runat="server" 
                                                FieldLabel="Auto Layout">
                                                <Items>
                                                    <ext:Checkbox ID="Checkbox4" runat="server" BoxLabel="Item 1" Checked="true" />
                                                    <ext:Checkbox ID="Checkbox5" runat="server" BoxLabel="Item 2" Checked="true" />
                                                    <ext:Checkbox ID="Checkbox6" runat="server" BoxLabel="Item 3" />
                                                    <ext:Checkbox ID="Checkbox7" runat="server" BoxLabel="Item 4" Checked="true" />
                                                    <ext:Checkbox ID="Checkbox8" runat="server" BoxLabel="Item 5" />
                                                </Items>
                                            </ext:CheckboxGroup> 
                                        </ext:Anchor>
                                        <ext:Anchor Horizontal="100%">
                                            <ext:CheckboxGroup 
                                                ID="CheckboxGroup2" 
                                                runat="server" 
                                                FieldLabel="Single Column" 
                                                ColumnsNumber="1" 
                                                ItemCls="x-check-group-alt">
                                                <Items>
                                                    <ext:Checkbox ID="Checkbox9" runat="server" BoxLabel="Item 1" />
                                                    <ext:Checkbox ID="Checkbox10" runat="server" BoxLabel="Item 2" Checked="true" />
                                                    <ext:Checkbox ID="Checkbox11" runat="server" BoxLabel="Item 3" />
                                                </Items>
                                            </ext:CheckboxGroup> 
                                        </ext:Anchor>
                                        <ext:Anchor Horizontal="100%">
                                            <ext:CheckboxGroup 
                                                ID="CheckboxGroup3" 
                                                runat="server" 
                                                FieldLabel="Multi-Column<br/>(Horizontal)" 
                                                ColumnsNumber="3">
                                                <Items>
                                                    <ext:Checkbox ID="Checkbox12" runat="server" BoxLabel="Item 1" Checked="true" />
                                                    <ext:Checkbox ID="Checkbox13" runat="server" BoxLabel="Item 2" Checked="true" />
                                                    <ext:Checkbox ID="Checkbox14" runat="server" BoxLabel="Item 3" />
                                                    <ext:Checkbox ID="Checkbox15" runat="server" BoxLabel="Item 4" Checked="true" />
                                                    <ext:Checkbox ID="Checkbox16" runat="server" BoxLabel="Item 5" />
                                                </Items>
                                            </ext:CheckboxGroup> 
                                        </ext:Anchor>
                                        <ext:Anchor Horizontal="100%">
                                            <ext:CheckboxGroup ID="CheckboxGroup4" 
                                                runat="server" 
                                                FieldLabel="Multi-Column<br/>(Vertical)" 
                                                ColumnsNumber="3" 
                                                Vertical="true" 
                                                ItemCls="x-check-group-alt">
                                                <Items>
                                                    <ext:Checkbox ID="Checkbox17" runat="server" BoxLabel="Item 1" Checked="true" />
                                                    <ext:Checkbox ID="Checkbox18" runat="server" BoxLabel="Item 2" Checked="true" />
                                                    <ext:Checkbox ID="Checkbox19" runat="server" BoxLabel="Item 3" /> 
                                                    <ext:Checkbox ID="Checkbox20" runat="server" BoxLabel="Item 4" Checked="true" />
                                                    <ext:Checkbox ID="Checkbox21" runat="server" BoxLabel="Item 5" />
                                                </Items>
                                            </ext:CheckboxGroup> 
                                        </ext:Anchor>
                                        <ext:Anchor Horizontal="100%">
                                            <ext:CheckboxGroup ID="CheckboxGroup5" 
                                                runat="server" 
                                                FieldLabel="Multi-Column<br />(Custom Widths)" 
                                                ColumnsWidths="100,100" 
                                                Vertical="true">
                                                <Items>
                                                    <ext:Checkbox ID="Checkbox22" runat="server" BoxLabel="Item 1" Checked="true" />
                                                    <ext:Checkbox ID="Checkbox23" runat="server" BoxLabel="Item 2" Checked="true" />
                                                    <ext:Checkbox ID="Checkbox24" runat="server" BoxLabel="Item 3" />
                                                    <ext:Checkbox ID="Checkbox25" runat="server" BoxLabel="Item 4" Checked="true" />
                                                    <ext:Checkbox ID="Checkbox26" runat="server" BoxLabel="Item 5" />
                                                </Items>
                                            </ext:CheckboxGroup> 
                                        </ext:Anchor>
                                        <ext:Anchor Horizontal="100%">
                                            <ext:CheckboxGroup 
                                                ID="CheckboxGroup6" 
                                                runat="server" 
                                                MsgTarget="Side" 
                                                ItemCls="x-check-group-alt" 
                                                FieldLabel="Custom Layout" 
                                                AllowBlank="false">
                                                <Items>
                                                    <ext:CheckboxColumn runat="server" ColumnWidth="0.25">
                                                        <Items>
                                                            <ext:Label 
                                                                runat="server" 
                                                                Text="Heading 1" 
                                                                Cls="x-form-check-group-label" 
                                                                ForID="-">
                                                                <CustomConfig>
                                                                    <ext:ConfigItem Name="anchor" Value="-15" Mode="Value" />
                                                                </CustomConfig>
                                                            </ext:Label>
                                                            <ext:Checkbox ID="Checkbox27" runat="server" BoxLabel="Item 1" Checked="true" />
                                                            <ext:Checkbox ID="Checkbox28" runat="server" BoxLabel="Item 2" Checked="true" />
                                                        </Items>
                                                    </ext:CheckboxColumn>
                                                    <ext:CheckboxColumn ID="CheckboxColumn2" runat="server" ColumnWidth="0.5">
                                                        <Items>
                                                            <ext:Label 
                                                                runat="server" 
                                                                Text="Heading 2" 
                                                                Cls="x-form-check-group-label" 
                                                                ForID="-">
                                                                <CustomConfig>
                                                                    <ext:ConfigItem Name="anchor" Value="-15"  Mode="Value" />
                                                                </CustomConfig>
                                                            </ext:Label>
                                                            <ext:Checkbox 
                                                                ID="Checkbox29" 
                                                                runat="server" 
                                                                BoxLabel="A long item just for fun" 
                                                                />
                                                        </Items>
                                                    </ext:CheckboxColumn>
                                                    <ext:CheckboxColumn runat="server" ColumnWidth="0.25">
                                                        <Items>
                                                            <ext:Label 
                                                                runat="server" 
                                                                Text="Heading 3" 
                                                                Cls="x-form-check-group-label" 
                                                                ForID="-">
                                                                <CustomConfig>
                                                                    <ext:ConfigItem Name="anchor" Value="-15" Mode="Value" />
                                                                </CustomConfig>
                                                            </ext:Label>
                                                            <ext:Checkbox ID="Checkbox1" runat="server" BoxLabel="Item 4" Checked="true" />
                                                            <ext:Checkbox ID="Checkbox2" runat="server" BoxLabel="Item 5" />
                                                        </Items>
                                                    </ext:CheckboxColumn>
                                                </Items>
                                            </ext:CheckboxGroup> 
                                        </ext:Anchor>
                                    </Anchors>
                                </ext:FormLayout>
                            </Items>
                        </ext:Panel>
                        <ext:Panel ID="Tab2" runat="server" Title="Radio Groups" Padding="2">
                            <Items>
                                <ext:FormLayout ID="FormLayout4" runat="server" LabelWidth="110">
                                    <Anchors>
                                        <ext:Anchor Horizontal="100%">
                                            <ext:RadioGroup ID="RadioGroup1" runat="server" ItemCls="x-check-group-base" FieldLabel="Auto Layout">
                                                <Items>
                                                    <ext:Radio ID="Radio4" runat="server" BoxLabel="Item 1" />
                                                    <ext:Radio ID="Radio5" runat="server" BoxLabel="Item 2" Checked="true" />
                                                    <ext:Radio ID="Radio6" runat="server" BoxLabel="Item 3" />
                                                    <ext:Radio ID="Radio7" runat="server" BoxLabel="Item 4" />
                                                    <ext:Radio ID="Radio8" runat="server" BoxLabel="Item 5" />
                                                </Items>
                                            </ext:RadioGroup> 
                                        </ext:Anchor>
                                        <ext:Anchor Horizontal="100%">
                                            <ext:RadioGroup ID="RadioGroup2" 
                                                runat="server" 
                                                FieldLabel="Single Column" 
                                                ColumnsNumber="1" 
                                                ItemCls="x-check-group-alt">
                                                <Items>
                                                    <ext:Radio ID="Radio9" runat="server" BoxLabel="Item 1" />
                                                    <ext:Radio ID="Radio10" runat="server" BoxLabel="Item 2" Checked="true" />
                                                    <ext:Radio ID="Radio11" runat="server" BoxLabel="Item " />
                                                </Items>
                                            </ext:RadioGroup> 
                                        </ext:Anchor>
                                        <ext:Anchor Horizontal="100%">
                                            <ext:RadioGroup ID="RadioGroup3" 
                                                runat="server" 
                                                FieldLabel="Multi-Column<br/>(Horizontal)" 
                                                ColumnsNumber="3">
                                                <Items>
                                                    <ext:Radio ID="Radio12" runat="server" BoxLabel="Item 1" />
                                                    <ext:Radio ID="Radio13" runat="server" BoxLabel="Item 2" Checked="true" />
                                                    <ext:Radio ID="Radio14" runat="server" BoxLabel="Item 3" /> 
                                                    <ext:Radio ID="Radio15" runat="server" BoxLabel="Item 4" />
                                                    <ext:Radio ID="Radio16" runat="server" BoxLabel="Item 5" />
                                                </Items>
                                            </ext:RadioGroup> 
                                        </ext:Anchor>
                                        <ext:Anchor Horizontal="100%">
                                            <ext:RadioGroup ID="RadioGroup4" 
                                                runat="server" 
                                                FieldLabel="Multi-Column<br/>(Vertical)" 
                                                ColumnsNumber="3" 
                                                Vertical="true" 
                                                ItemCls="x-check-group-alt">
                                                <Items>
                                                    <ext:Radio ID="Radio17" runat="server" BoxLabel="Item 1" />
                                                    <ext:Radio ID="Radio18" runat="server" BoxLabel="Item 2" Checked="true" />
                                                    <ext:Radio ID="Radio19" runat="server" BoxLabel="Item 3" />
                                                    <ext:Radio ID="Radio20" runat="server" BoxLabel="Item 4" />
                                                    <ext:Radio ID="Radio21" runat="server" BoxLabel="Item 5" />
                                                </Items>
                                            </ext:RadioGroup> 
                                        </ext:Anchor>
                                        <ext:Anchor Horizontal="100%">
                                            <ext:RadioGroup ID="RadioGroup5" 
                                                runat="server" 
                                                FieldLabel="Multi-Column<br />(Custom Widths)" 
                                                ColumnsWidths="100,100" 
                                                Vertical="true">
                                                <Items>
                                                    <ext:Radio ID="Radio22" runat="server" BoxLabel="Item 1" />
                                                    <ext:Radio ID="Radio23" runat="server" BoxLabel="Item 2" Checked="true" />
                                                    <ext:Radio ID="Radio24" runat="server" BoxLabel="Item 3" />
                                                    <ext:Radio ID="Radio25" runat="server" BoxLabel="Item 4" />
                                                    <ext:Radio ID="Radio26" runat="server" BoxLabel="Item 5" />
                                                </Items>
                                            </ext:RadioGroup> 
                                        </ext:Anchor>
                                        <ext:Anchor Horizontal="100%">
                                            <ext:RadioGroup 
                                                ID="RadioGroup6" 
                                                runat="server" 
                                                MsgTarget="Side" 
                                                ItemCls="x-check-group-alt" 
                                                FieldLabel="Custom Layout"                                                 
                                                AllowBlank="false">
                                                <Items>
                                                    <ext:RadioColumn ID="RadioColumn1" runat="server" ColumnWidth="0.25">
                                                        <Items>
                                                            <ext:Label 
                                                                runat="server" 
                                                                Text="Heading 1" 
                                                                Cls="x-form-check-group-label" 
                                                                ForID="-">
                                                                <CustomConfig>
                                                                    <ext:ConfigItem Name="anchor" Value="-15" Mode="Value" />
                                                                </CustomConfig>
                                                            </ext:Label>
                                                            <ext:Radio ID="Radio27" runat="server" BoxLabel="Item 1" />
                                                            <ext:Radio ID="Radio28" runat="server" BoxLabel="Item 2" Checked="true" />
                                                        </Items>
                                                    </ext:RadioColumn>
                                                    
                                                     <ext:RadioColumn ID="RadioColumn2" runat="server" ColumnWidth="0.5">
                                                        <Items>
                                                            <ext:Label 
                                                                runat="server" 
                                                                Text="Heading 2" 
                                                                Cls="x-form-check-group-label" 
                                                                ForID="-">
                                                                <CustomConfig>
                                                                    <ext:ConfigItem Name="anchor" Value="-15" Mode="Value" />
                                                                </CustomConfig>
                                                            </ext:Label>
                                                            <ext:Radio 
                                                                ID="Radio29" 
                                                                runat="server" 
                                                                BoxLabel="A long item just for fun" 
                                                                />
                                                        </Items>
                                                    </ext:RadioColumn>
                                                    
                                                     <ext:RadioColumn ID="RadioColumn3" runat="server" ColumnWidth="0.25">
                                                        <Items>
                                                            <ext:Label 
                                                                runat="server" 
                                                                Text="Heading 3" 
                                                                Cls="x-form-check-group-label" 
                                                                ForID="-">
                                                                <CustomConfig>
                                                                    <ext:ConfigItem Name="anchor" Value="-15"  Mode="Value" />
                                                                </CustomConfig>
                                                            </ext:Label>
                                                            <ext:Radio ID="Radio30" runat="server" BoxLabel="Item 4" />
                                                            <ext:Radio ID="Radio31" runat="server" BoxLabel="Item 5" />
                                                        </Items>
                                                    </ext:RadioColumn>
                                                </Items>
                                            </ext:RadioGroup> 
                                        </ext:Anchor>
                                    </Anchors>
                                </ext:FormLayout>
                            </Items>
                        </ext:Panel>
                    </Items>
                </ext:TabPanel>
            </Items>
        </ext:Panel>
        
        <ext:Label ID="Label1" runat="server" />
        
    </form>
</body>
</html>