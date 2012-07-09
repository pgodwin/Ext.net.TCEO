using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Ext.Net.MVC.Demo.Models;

namespace Ext.Net.MVC.Demo.Controllers
{
    public class RestDemoController : BaseDataController
    {
        public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public RestResult Create(string data)
        {
            try
            {
                Category c = JSON.Deserialize<Category>(data);
            
                NorthwindDataContext context = this.DBContext;
                context.Categories.InsertOnSubmit(c);
                context.SubmitChanges();

                return new RestResult
                           {
                               Success = true,
                               Message = "New category added",
                               Data = new {c.CategoryID, c.Description, c.CategoryName}
                           };
            }
            catch (Exception e)
            {
                return new RestResult
                {
                    Success = false,
                    Message = e.Message
                };
            }
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public RestResult Read()
        {
            try
            {
                var query = from c in this.DBContext.Categories select new
                                                                           {
                                                                               c.CategoryID,
                                                                               c.CategoryName,
                                                                               c.Description                   
                                                                           };
                return new RestResult
                           {
                               Success = true,
                               Data = query
                           };
            }
            catch (Exception e)
            {
                return new RestResult
                    {
                        Success = false,
                        Message = e.Message
                    };
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public RestResult Update(int id, string data)
        {
            try
            {
                JsonObject fields = JSON.Deserialize<JsonObject>(data);

                NorthwindDataContext context = this.DBContext;

                Category c = (from ct in context.Categories where ct.CategoryID == id select ct).First();

                c.CategoryName = fields["CategoryName"].ToString();
                c.Description = fields["Description"].ToString();

                context.SubmitChanges();

                return new RestResult
                {
                    Success = true,
                    Message = "Category has been updated"
                };
            }
            catch (Exception e)
            {
                return new RestResult
                {
                    Success = false,
                    Message = e.Message
                };
            }
        }

        [AcceptVerbs(HttpVerbs.Delete)]
        public RestResult Destroy(int id)
        {
            try
            {
                NorthwindDataContext context = this.DBContext;

                Category c = (from ct in context.Categories where ct.CategoryID == id select ct).First();
                context.Categories.DeleteOnSubmit(c);
                context.SubmitChanges();

                return new RestResult
                {
                    Success = true,
                    Message = "Category has been deleted"
                };
            }
            catch (Exception e)
            {
                return new RestResult
                {
                    Success = false,
                    Message = e.Message
                };
            }
        }
    }
}
