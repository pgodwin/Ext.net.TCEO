using System.Linq;
using System.Linq.Dynamic;
using System.Web.Mvc;

namespace Ext.Net.MVC.Demo.Controllers
{
    public class ChartController : BaseDataController
    {
        public ActionResult TotalByEmployee()
        {
            var query = (from e in this.DBContext.Employees
                        select new
                        {
                            EmployeeName = e.LastName + " " + e.FirstName,
                            Total = (from o in e.Orders
                                     join od in this.DBContext.OrderDetails on o.OrderID equals od.OrderID
                                     select od.UnitPrice * od.Quantity * (decimal)(1 - od.Discount)
                                    ).Sum()
                        }).OrderBy("Total DESC");

            return this.View(query.ToList());
        }

        public ActionResult ProductSalesByCategory()
        {
            return this.View();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetProductsSalesByCategoryImage(int year)
        {
            var query = (from c in this.DBContext.Categories
                         select new
                         {
                             c.CategoryName,
                             Total = (from od in this.DBContext.OrderDetails
                                      join p in c.Products on od.ProductID equals p.ProductID
                                      where od.Order.OrderDate.Value.Year == year || (year == 0)
                                      select od.UnitPrice * od.Quantity * (decimal)(1 - od.Discount)
                                     ).Sum()
                         }).OrderBy("Total DESC");
            this.ViewData["year"] = year;
            return this.View(query.ToList());
        }

        public ActionResult SalesByYear()
        {
            var query = (from o in this.DBContext.Orders
                         group o by o.OrderDate.Value.Year into orders
                         select new
                         {
                             Year = orders.Key,
                             Total = (from oy in orders
                                      join od in this.DBContext.OrderDetails on oy.OrderID equals od.OrderID 
                                      select od.UnitPrice * od.Quantity * (decimal)(1 - od.Discount)
                                     ).Sum()
                         }).OrderBy("Total DESC");

            return this.View(query.ToList());
        }
    }
}
