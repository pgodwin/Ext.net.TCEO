﻿<%@ Control Language="C#" %>

<%@ Import Namespace="Ext.Net.Utilities" %>
<%@ Import Namespace="Button=Ext.Net.Button" %>
<%@ Import Namespace="Menu=Ext.Net.Menu" %>
<%@ Import Namespace="MenuItem=Ext.Net.MenuItem" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        ControlUtils.FindControls<Button>(this).ForEach(
            delegate(Button button)
                {
                    Menu menu = new Menu();
                    menu.Items.Add(new MenuItem("Menu Item 1"));
                    menu.Items.Add(new MenuItem("Menu Item 2"));
                    menu.Items.Add(new MenuItem("Menu Item 3"));
                    
                    button.Menu.Add(menu);
                });
    }
</script>

<h1>Menu Buttons</h1>

<ext:Panel runat="server" BaseCls="x-plain" Cls="btn-panel">
    <Items>
        <ext:TableLayout runat="server" Columns="3">
            <Cells>
                <ext:Cell ColSpan="3">
                    <ext:Panel runat="server" Border="false">
                        <Content>
                            <h3 style="padding: 15px 0 3px;">Text Only</h3>
                        </Content>
                    </ext:Panel>
                </ext:Cell>
                <ext:Cell>
                    <ext:Button runat="server" Text="Add User" />
                </ext:Cell>
                <ext:Cell>
                    <ext:Button runat="server" Text="Add User" Scale="Medium" />
                </ext:Cell>
                <ext:Cell>
                    <ext:Button runat="server" Text="Add User" Scale="Large" />
                </ext:Cell>
            </Cells>
        </ext:TableLayout>
    </Items>
</ext:Panel>

<ext:Panel runat="server" BaseCls="x-plain" Cls="btn-panel">
    <Items>
        <ext:TableLayout runat="server" Columns="3">
            <Cells>
                <ext:Cell ColSpan="3">
                    <ext:Panel runat="server" Border="false">
                        <Content>
                            <h3 style="padding: 15px 0 3px;">Icon Only</h3>
                        </Content>
                    </ext:Panel>
                </ext:Cell>
                <ext:Cell>
                    <ext:Button runat="server" IconCls="add16" />
                </ext:Cell>
                <ext:Cell>
                    <ext:Button runat="server" IconCls="add24" Scale="Medium" />
                </ext:Cell>
                <ext:Cell>
                    <ext:Button runat="server" IconCls="add32" Scale="Large" />
                </ext:Cell>
            </Cells>
        </ext:TableLayout>
    </Items>
</ext:Panel>

<ext:Panel runat="server" BaseCls="x-plain" Cls="btn-panel">
    <Items>
        <ext:TableLayout runat="server" Columns="3">
            <Cells>
                <ext:Cell ColSpan="3">
                    <ext:Panel runat="server" Border="false">
                        <Content>
                            <h3 style="padding: 15px 0 3px;">Icon and Text (left)</h3>
                        </Content>
                    </ext:Panel>
                </ext:Cell>
                <ext:Cell>
                    <ext:Button runat="server" Text="Add User" IconCls="add16" />
                </ext:Cell>
                <ext:Cell>
                    <ext:Button runat="server" Text="Add User" IconCls="add24" Scale="Medium" />
                </ext:Cell>
                <ext:Cell>
                    <ext:Button runat="server" Text="Add User" IconCls="add32" Scale="Large" />
                </ext:Cell>
            </Cells>
        </ext:TableLayout>
    </Items>
</ext:Panel>

<ext:Panel runat="server" BaseCls="x-plain" Cls="btn-panel">
    <Items>
        <ext:TableLayout runat="server" Columns="3">
            <Cells>
                <ext:Cell ColSpan="3">
                    <ext:Panel runat="server" Border="false">
                        <Content>
                            <h3 style="padding: 15px 0 3px;">Icon and Text (top)</h3>
                        </Content>
                    </ext:Panel>
                </ext:Cell>
                <ext:Cell>
                    <ext:Button runat="server" Text="Add User" IconCls="add16" IconAlign="Top" />
                </ext:Cell>
                <ext:Cell>
                    <ext:Button runat="server" Text="Add User" IconCls="add24" Scale="Medium" IconAlign="Top" />
                </ext:Cell>
                <ext:Cell>
                    <ext:Button runat="server" Text="Add User" IconCls="add32" Scale="Large" IconAlign="Top" />
                </ext:Cell>
            </Cells>
        </ext:TableLayout>
    </Items>
</ext:Panel>

<ext:Panel runat="server" BaseCls="x-plain" Cls="btn-panel">
    <Items>
        <ext:TableLayout runat="server" Columns="3">
            <Cells>
                <ext:Cell ColSpan="3">
                    <ext:Panel runat="server" Border="false">
                        <Content>
                            <h3 style="padding: 15px 0 3px;">Icon and Text (right)</h3>
                        </Content>
                    </ext:Panel>
                </ext:Cell>
                <ext:Cell>
                    <ext:Button runat="server" Text="Add User" IconCls="add16" IconAlign="Right" />
                </ext:Cell>
                <ext:Cell>
                    <ext:Button runat="server" Text="Add User" IconCls="add24" Scale="Medium" IconAlign="Right" />
                </ext:Cell>
                <ext:Cell>
                    <ext:Button runat="server" Text="Add User" IconCls="add32" Scale="Large" IconAlign="Right" />
                </ext:Cell>
            </Cells>
        </ext:TableLayout>
    </Items>
</ext:Panel>

<ext:Panel runat="server" BaseCls="x-plain" Cls="btn-panel">
    <Items>
        <ext:TableLayout runat="server" Columns="3">
            <Cells>
                <ext:Cell ColSpan="3">
                    <ext:Panel runat="server" Border="false">
                        <Content>
                            <h3 style="padding: 15px 0 3px;">Icon and Text (bottom)</h3>
                        </Content>
                    </ext:Panel>
                </ext:Cell>
                <ext:Cell>
                    <ext:Button runat="server" Text="Add User" IconCls="add16" IconAlign="Bottom" />
                </ext:Cell>
                <ext:Cell>
                    <ext:Button runat="server" Text="Add User" IconCls="add24" Scale="Medium" IconAlign="Bottom" />
                </ext:Cell>
                <ext:Cell>
                    <ext:Button runat="server" Text="Add User" IconCls="add32" Scale="Large" IconAlign="Bottom" />
                </ext:Cell>
            </Cells>
        </ext:TableLayout>
    </Items>
</ext:Panel>
