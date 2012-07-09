/********
 * @version   : 1.0.0 - Professional Edition (Ext.NET Professional License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2009-11-15
 * @copyright : Copyright (c) 2010, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using Ext.Net.Utilities;

namespace Ext.Net.Examples.FeedViewer
{
    public partial class FeedWindow
    {
        void AddClick_Event(object sender, DirectEventArgs e)
        {
            WebRequest request = WebRequest.Create(this.feedUrl.SelectedItem.Value);
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("ISO-8859-1"));

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(reader.ReadToEnd());
            XmlNodeList channels = doc.SelectNodes("rss/channel");
            if ( channels != null && channels.Count>0)
            {
                string title = this.feedUrl.SelectedItem.Value;
                XmlNode titleNode = channels[0].SelectSingleNode("title");
                if (titleNode != null && titleNode.InnerText.IsNotEmpty() )
                {
                    title = titleNode.InnerText;
                }
                this.FireEvent("validfeed", new { url = this.feedUrl.SelectedItem.Value, text = title });
                this.Hide();
            }
            else
            {
                e.Success = false;
            }
        }
    }
}