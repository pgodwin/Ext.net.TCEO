using System.Web.Mvc;
using Ext.Net.MVC.Demo.Models;

namespace Ext.Net.MVC.Demo.Controllers
{
    public abstract class BaseDataController : Controller
    {
        public BaseDataController()
        {
            this.db = new NorthwindDataContext();
        }

        NorthwindDataContext db;

        public NorthwindDataContext DBContext
        {
            get { return this.db; }
        }
    }
}
