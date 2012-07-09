using System.Web.Services;
using Ext.Net;

namespace Ext.Net.Examples
{
    /// <summary>
    /// Summary description for TreeLoaderService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class TreeLoaderService : System.Web.Services.WebService
    {
        [WebMethod]
        public TreeNodeCollection GetNodes(string node)
        {
            TreeNodeCollection nodes = new TreeNodeCollection(false);

            if (!string.IsNullOrEmpty(node))
            {
                for (int i = 1; i < 6; i++)
                {
                    AsyncTreeNode asyncNode = new AsyncTreeNode();
                    asyncNode.Text = node + i;
                    asyncNode.NodeID = node + i;
                    nodes.Add(asyncNode);
                }

                for (int i = 6; i < 11; i++)
                {
                    TreeNode treeNode = new TreeNode();
                    treeNode.Text = node + i;
                    treeNode.NodeID = node + i;
                    treeNode.Leaf = true;
                    nodes.Add(treeNode);
                }
            }

            return nodes;
        }
    }
}
