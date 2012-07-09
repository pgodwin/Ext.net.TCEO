<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Next_Click(object sender, DirectEventArgs e)
    {
        int index = int.Parse(e.ExtraParams["index"]);

        if ((index + 1) < this.WizardPanel.Items.Count)
        {
            this.WizardPanel.ActiveIndex = index + 1;
        }
        
        this.CheckButtons();
    }

    protected void Prev_Click(object sender, DirectEventArgs e)
    {
        int index = int.Parse(e.ExtraParams["index"]);
        
        if ((index - 1) >= 0)
        {
            this.WizardPanel.ActiveIndex = index - 1;
        }
        
        this.CheckButtons();
    }

    private void CheckButtons()
    {
        int index = this.WizardPanel.ActiveIndex;
        
        this.btnNext.Disabled = index == (this.WizardPanel.Items.Count - 1);
        this.btnPrev.Disabled = index == 0;
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CardLayout - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <ext:Panel 
            ID="WizardPanel" 
            runat="server" 
            Title="Example Wizard" 
            Padding="15" 
            Height="300" 
            Layout="card" 
            ActiveIndex="0">       
            <Items>
                <ext:Panel 
                    ID="Panel1"
                    runat="server" 
                    Html="<h1>Welcome to the Wizard!</h1><p>Step 1 of 3</p>" 
                    Border="false" 
                    Header="false" 
                    />
                <ext:Panel 
                    ID="Panel2"
                    runat="server" 
                    Html="<h1>Card 2</h1><p>Step 2 of 3</p>" 
                    Border="false" 
                    Header="false" 
                    />
                <ext:Panel 
                    ID="Panel3"
                    runat="server" 
                    Html="<h1>Congratulations!</h1><p>Step 3 of 3 - Complete</p>" 
                    Border="false" 
                    Header="false" 
                    />
            </Items>         
            <Buttons>
                <ext:Button ID="btnPrev" runat="server" Text="Prev" Disabled="true" Icon="PreviousGreen">
                    <DirectEvents>
                        <Click OnEvent="Prev_Click">
                            <ExtraParams>
                                <ext:Parameter Name="index" Value="#{WizardPanel}.items.indexOf(#{WizardPanel}.layout.activeItem)" Mode="Raw" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnNext" runat="server" Text="Next" Icon="NextGreen">
                    <DirectEvents>
                        <Click OnEvent="Next_Click">
                            <ExtraParams>
                                <ext:Parameter Name="index" Value="#{WizardPanel}.items.indexOf(#{WizardPanel}.layout.activeItem)" Mode="Raw" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
            </Buttons>     
        </ext:Panel>
    </form>
</body>
</html>