/********
 * @version   : 1.0.0 - Professional Edition (Ext.NET Professional License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2009-11-15
 * @copyright : Copyright (c) 2010, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using Ext.Net.Utilities;

namespace Ext.Net.Examples.FeedViewer
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "MainPanel")]
    public partial class MainPanel
    {
        void ShowPreview_Toggle(object sender, DirectEventArgs e)
        {
            GridView view = ControlUtils.FindControl<FeedGrid>(this.Page).View[0];
            view.Set("showPreview", bool.Parse(e.ExtraParams["pressed"]));
            view.Refresh();
        }

        [DirectMethod]
        public void MovePreview(string place)
        {
            Panel right = ControlUtils.FindControl<Panel>(this.Page, "RightPreview");
            Panel bottom = ControlUtils.FindControl<Panel>(this.Page, "BottomPreview");
            SplitButton btn = ControlUtils.FindControl<SplitButton>(this.Page, "PreviewPlaceButton");

            switch (place)
            {
                case "Bottom":
                    right.Hide();
                    bottom.Call("add", this.Preview.ClientID);
                    bottom.Show();
                    ((Panel)this.Items[0]).DoLayout();
                    btn.IconCls = "preview-bottom";
                    break;

                case "Right":
                    bottom.Hide();
                    right.Call("add", this.Preview.ClientID);
                    right.Show();
                    ((Panel)this.Items[0]).DoLayout();
                    btn.IconCls = "preview-right";
                    break;

                case "Hide":
                    bottom.Hide();
                    right.Hide();
                    ((Panel)this.Items[0]).DoLayout();
                    btn.IconCls = "preview-hide";
                    break;
            }
        }

        [DirectMethod]
        public void OpenTab(string id, string title, string link)
        {
            var p = new Panel
            {
                ID = id,
                Cls = "preview single-preview",
                Title = title,
                TabTip = title,
                Closable = true,
                AutoScroll = true,
                Border = true,
                Listeners =
                {
                    Render = { Fn = "FeedViewer.LinkInterceptor" }
                },

                TopBar =
                {
                    new Toolbar
                    {
                        ID = id + "_topb",
                        Items =
                        {
                        new Button
                        {
                            ID = id+"_gobutton",
                            IconCls = "new-win",
                            Text = "Go to Post",
                            Handler = new JFunction("window.open(this.link);").ToScript(),
                            CustomConfig =
                            {
                                new ConfigItem("link", link, ParameterMode.Value)
                            }
                        } 
                     }
                  }
               }
            };

            p.Render(this);

            this.SetActiveTab(id);
        }
    }
}