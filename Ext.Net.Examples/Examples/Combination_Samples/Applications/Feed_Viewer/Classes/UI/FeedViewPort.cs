/********
 * @version   : 1.0.0 - Professional Edition (Ext.NET Professional License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2009-11-15
 * @copyright : Copyright (c) 2010, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.Web.UI;

namespace Ext.Net.Examples.FeedViewer
{
    public partial class FeedViewPort : Viewport
    {
        public FeedViewPort()
        {
            this.Layout = "Border";

            this.Items.Add(new BoxComponent
            {
                Height = 32,
                Region = Ext.Net.Region.North,
                AutoEl =
                {
                    Children =
                    {
                        new DomObject
                        {
                            ID = "direct_indicator",
                            Tag = HtmlTextWriterTag.Img,
                            Cls = "x-hidden x-load-ind",
                            CustomConfig =
                            {
                                new ConfigItem("src", "resources/images/ajax-loader.gif", ParameterMode.Value)
                            }
                        }
                    }
                }
            });

            this.Items.Add(new FeedTree { ID = "ctlFeedTree" });
            this.Items.Add(new MainPanel { ID = "MainPanel1"});
        }

        protected override void OnInit(System.EventArgs e)
        {
 	        base.OnInit(e);
            this.Page.Init += delegate {
                this.Page.Form.Controls.Add(new FeedWindow());
            };            
        }
    }
}
