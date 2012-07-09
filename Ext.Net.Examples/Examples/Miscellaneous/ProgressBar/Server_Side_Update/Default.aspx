<%@ Page Language="C#" %>

<%@ Import Namespace="System.Threading" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ProgressBar - Ext.NET Examples</title>    
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />  
    
    <script runat="server">
        protected void StartLongAction(object sender, DirectEventArgs e)
        {
            this.Session["LongActionProgress"] = 0;
            ThreadPool.QueueUserWorkItem(LongAction);
            ResourceManager1.AddScript("{0}.startTask('longactionprogress');", TaskManager1.ClientID);
        }

        private void LongAction(object state)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                this.Session["LongActionProgress"] = i+1;
            }
            this.Session.Remove("LongActionProgress");
        }

        protected void RefreshProgress(object sender, DirectEventArgs e)
        {
            object progress = this.Session["LongActionProgress"];

            if (progress != null)
            {
                Progress1.UpdateProgress(((int)progress) / 10f, string.Format("Step {0} of {1}...", progress.ToString(), 10));
            }
            else
            {
                ResourceManager1.AddScript("{0}.stopTask('longactionprogress');", TaskManager1.ClientID);
                Progress1.UpdateProgress(1,"All finished!");
            }
        }

    </script>
    
</head>
<body>
    <form runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <h1>Progress Bar</h1>
        <p>The example shows how to update the ProgressBar during long server-side actions.</p>
        
        <ext:Button ID="ShowProgress1" runat="server" Text="Start long action">
            <DirectEvents>
                <Click OnEvent="StartLongAction" />
            </DirectEvents>
        </ext:Button>
        
        <br />
        
        <ext:ProgressBar ID="Progress1" runat="server" Width="300" />
        
        <ext:TaskManager ID="TaskManager1" runat="server">
            <Tasks>
                <ext:Task 
                    TaskID="longactionprogress"
                    Interval="1000" 
                    AutoRun="false"
                    OnStart="
                        #{ShowProgress1}.setDisabled(true);"
                    OnStop="
                        #{ShowProgress1}.setDisabled(false);">
                    <DirectEvents>
                        <Update OnEvent="RefreshProgress" />
                    </DirectEvents>                    
                </ext:Task>
            </Tasks>
        </ext:TaskManager>
  
    </form>
</body>
</html>
