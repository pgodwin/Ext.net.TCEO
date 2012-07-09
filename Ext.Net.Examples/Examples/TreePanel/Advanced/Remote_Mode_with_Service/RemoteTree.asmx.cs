using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;

namespace Ext.Net.Examples.Examples.TreePanel.Advanced.Remote_Mode_with_Service
{
    /// <summary>
    /// Summary description for RemoteTree
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class RemoteTree : System.Web.Services.WebService
    {
        [WebMethod]        
        public string GetNodes(string node)
        {
            TreeNodeCollection nodes = new TreeNodeCollection(false);

            string prefix = DateTime.Now.Second + "_";
            for (int i = 0; i < 10; i++)
            {
                Ext.Net.TreeNode newNode = new Ext.Net.TreeNode();
                newNode.NodeID = i.ToString();
                newNode.Text = prefix + i;
                newNode.Leaf = true;
                nodes.Add(newNode);
            }

            return nodes.ToJson();
        }

        // PLEASE NOTE: under ASP.NET MVC you have to add 'd' (mimic Json WebService response) object like
        // return new JsonResult(new { d = new {success = false, message = "Renaming is disabled" }});

        [WebMethod]        
        public object RemoteRename(string id, string newText, string oldText)
        {
            return new { success = true };
            //return new { success = false, message = "Renaming is disabled" };
            //return new { success = true, response = new {text= "New text"} };
        }

        [WebMethod]        
        public object RemoteRemove(string id)
        {
            return new { success = true };
        }

        [WebMethod]
        public object RemoteAppend(string id, string parentId, string text)
        {
            //return new { success = true, response = new { id = "newId", text = text + "_new" } };
            return new { success = true, response = new { text = text + "_new" } };
        }

        [WebMethod]
        public object RemoteInsert(string id, string parentId, string text)
        {
            return new { success = true, response = new { text = text + "_new" } };
        }

        [WebMethod]
        public object RemoteMove(string id, string targetId, string point)
        {
            return new { success = true };
        }
    }
}
