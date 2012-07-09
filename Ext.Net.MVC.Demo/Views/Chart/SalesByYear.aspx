<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body {
            padding : 0px;
            margin  : 0px;
        }
    </style>
</head>
<body>
    <% 
        IEnumerable data = this.Model as IEnumerable;

        if (!string.IsNullOrEmpty(this.Request["height"]))
        {
            this.Chart1.Height = int.Parse(this.Request["height"]);
        }

        if (!string.IsNullOrEmpty(this.Request["width"]))
        {
            this.Chart1.Width = int.Parse(this.Request["width"]);
        }

        this.Chart1.Series["Default"].Points.DataBind(data, "Year", "Total", "");
        this.Chart1.Series["Default"]["PieLabelStyle"] = "Inside";

        double max = 0;
        DataPoint maxPoint = null;
        
        foreach (DataPoint point in Chart1.Series["Default"].Points)
        {
            point["Exploded"] = "false";
            if (point.YValues[0] > max)
            {
                max = point.YValues[0];
                maxPoint = point;
            }
        }
        if (maxPoint != null)
        {
            maxPoint["Exploded"] = "true";
        }

        this.Chart1.Series[0]["PieDrawingStyle"] = "Concave";
    %>

    <asp:Chart 
        ID="Chart1" 
        runat="server" 
        Palette="BrightPastel" 
        BackColor="WhiteSmoke"
        Height="400px" 
        Width="800px" 
        BorderDashStyle="Solid" 
        BackSecondaryColor="White"
        BackGradientStyle="TopBottom" 
        BorderWidth="0" 
        BorderColor="26, 59, 105">
        <BorderSkin SkinStyle="None" />
        <Series>
            <asp:Series 
                Name="Default" 
                Label="#VALX" 
                ToolTip="#VALY{C}" 
                ChartType="Pie" 
                BorderColor="180, 26, 59, 105"
                Color="220, 65, 140, 240"
                />
        </Series>
        <ChartAreas>
            <asp:ChartArea 
                Name="ChartArea1" 
                BorderColor="64, 64, 64, 64" 
                BackSecondaryColor="Transparent"
                BackColor="Transparent" 
                ShadowColor="Transparent" 
                BorderWidth="0">
                <AxisY LineColor="64, 64, 64, 64">
                    <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                    <MajorGrid LineColor="64, 64, 64, 64" />
                </AxisY>
                <AxisX LineColor="64, 64, 64, 64">
                    <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                    <MajorGrid LineColor="64, 64, 64, 64" />
                </AxisX>
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
</body>
</html>
