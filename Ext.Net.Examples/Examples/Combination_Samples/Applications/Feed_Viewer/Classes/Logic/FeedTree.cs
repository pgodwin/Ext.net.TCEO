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
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "FeedTree")]
    public partial class FeedTree
    {
        private void OnRemoveFeedClick(object sender, DirectEventArgs e)
        {
            string nodeId = e.ExtraParams["nodeId"];
            this.RemoveFeed(nodeId);
        }

        private void DeleteFeedClick(object sender, DirectEventArgs e)
        {
            SubmittedNode node = ((DefaultSelectionModel) this.SelectionModel[0]).SelectedNode;

            if (node != null && node.NodeID.IsNotEmpty())
            {
                this.RemoveFeed(node.NodeID);    
            }
        }

        private void AddFeedClick(object sender, DirectEventArgs e)
        {
            ControlUtils.FindControl<FeedWindow>(this.Page).Show();
        }

        public void RemoveFeed(string nodeId)
        {
            this.RemoveNodeClass(nodeId, "x-node-ctx");
            this.UnselectNode(nodeId);
            string nodeDescriptor = this.GetNodeDescriptor(nodeId);

            this.GetNodeUIElement(nodeId).Ghost("l", new FxConfig
            {
                Duration = 0.4,
                Scope = nodeDescriptor,
                Callback = new JFunction { Fn = nodeDescriptor + ".remove" }
            });
            
            this.Set("ctxNode", null);
        }

        [DirectMethod]
        public void AddFeed(string url, string text, bool inactive, bool preventAnimation)
        {
            TreeNode node = new TreeNode
            {
                NodeID = url,
                Cls = "feed",
                Leaf = true,
                IconCls = "feed-icon",
                Text = text,
                CustomAttributes =
                {
                    new ConfigItem("url", url, ParameterMode.Value)
                }
            };
            
            this.AppendChild("MyFeeds", node);

            if (!inactive)
            {
                if (!preventAnimation)
                {
                    string descriptor = this.GetNodeDescriptor(url);

                    this.GetNodeUIElement(url).SlideIn("l", new FxConfig
                    {
                        Duration = 0.4,
                        Scope = descriptor,
                        Callback = new JFunction { Fn = descriptor + ".select" }
                    });
                }
                else
                {
                    this.SelectNode(url);
                }
            }
        }
    }
}
