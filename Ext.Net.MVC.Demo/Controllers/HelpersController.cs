using System;
using System.Web.Mvc;

namespace Ext.Net.MVC.Demo.Controllers
{
    [HandleError]
    public class HelpersController : Controller
    {
        public AjaxResult GetTimestamp()
        {
            JsonObject company = new JsonObject();

            company.Add("name", "Ext.NET");
            company.Add("country", "Canada");

            JsonObject customer = new JsonObject();

            customer.Add("name", "Geoff");
            customer.Add("email", "geoff@ext.com");
            customer.Add("company", company);

            JsonObject obj = new JsonObject();

            obj.Add("date", DateTime.Now);
            obj.Add("day", DateTime.Now.ToString("dddd"));
            obj.Add("month", DateTime.Now.ToString("MMMM"));
            obj.Add("year", DateTime.Now.Year);
            obj.Add("leapyear", DateTime.IsLeapYear(DateTime.Now.Year));
            obj.Add("customer", customer);

            return new AjaxResult(obj);
        }
    }
}
