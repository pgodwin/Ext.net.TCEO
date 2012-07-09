<%@ Page Language="C#" %>

<script runat="server">
    protected void Page_Load(object sender, System.EventArgs e)
    {
        string year = (this.ViewData["year"]??"").ToString();
        string title = "";
        
        if(!string.IsNullOrEmpty(year))
        {
            title = (year == "0" ? "All years" : year+" year");
        }
        
        this.Chart1.Titles[0].Text = "Product Sales By Category - "+title;
        this.Chart1.Series["Series1"]["DrawingStyle"] = "Cylinder";

        IEnumerable data = this.Model as IEnumerable;
        this.Chart1.Series["Series1"].Points.DataBind(data, "CategoryName", "Total", "");

        if (!string.IsNullOrEmpty(this.Request["height"]))
        {
            this.Chart1.Height = int.Parse(this.Request["height"]);
        }

        if (!string.IsNullOrEmpty(this.Request["width"]))
        {
            this.Chart1.Width = int.Parse(this.Request["width"]);
        }      
    }
</script>
<asp:Chart 
    id="Chart1" 
    runat="server" 
    Palette="BrightPastel" 
    BackColor="#F3DFC1" 
    Width="412px" 
    Height="296px" 
    BorderDashStyle="Solid" 
    BackGradientStyle="TopBottom" 
    BorderWidth="0" 
    BorderColor="181, 64, 1">
	<Titles>
		<asp:Title 
		    ShadowColor="32, 0, 0, 0" 
		    Font="Trebuchet MS, 14.25pt, style=Bold" 
		    ShadowOffset="3" 
		    Name="Title1" 
		    ForeColor="26, 59, 105"
		    />
	</Titles>
	
	<Series>
		<asp:Series  
		    Name="Series1" 
		    BorderColor="180, 26, 59, 105" 
		    ChartType="Column"
		    />
	</Series>
	
	<ChartAreas>
		<asp:ChartArea 
		    Name="ChartArea1" 
		    BorderColor="64, 64, 64, 64" 
		    BackSecondaryColor="White" 
		    BackColor="OldLace" 
		    ShadowColor="Transparent" 
		    BackGradientStyle="TopBottom">
			<AxisY LineColor="64, 64, 64, 64" LabelAutoFitMaxFontSize="8">
				<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" Format="C0" />
				<MajorGrid LineColor="64, 64, 64, 64" />
			</axisy>
			<Axisx LineColor="64, 64, 64, 64" LabelAutoFitMaxFontSize="8">
				<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
				<MajorGrid LineColor="64, 64, 64, 64" />
			</axisx>
		</asp:ChartArea>
	</ChartAreas>
</asp:Chart>