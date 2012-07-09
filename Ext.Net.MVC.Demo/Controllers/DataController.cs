using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Linq.Dynamic;
using System.Xml.Linq;
using Ext.Net.MVC.Demo.Models;

namespace Ext.Net.MVC.Demo.Controllers
{
    [HandleError]
    public class DataController : BaseDataController
    {
        public AjaxStoreResult GetHomeSchema()
        {
            XElement document = XElement.Load(Server.MapPath("~/resources/images/HomeSchema.xml"));
            var defaultIcon = document.Attribute("defaultIcon") != null ? document.Attribute("defaultIcon").Value : "";
            var query = from g in document.Elements("group")
                        select new
                                   {
                                       Title = g.Attribute("title") != null ? g.Attribute("title").Value : "",
                                       Items = (from i in g.Elements("item") 
                                                select new
                                                           {
                                                               Title = i.Element("title") != null ? i.Element("title").Value : "",
                                                               Icon = i.Element("item-icon") != null ? i.Element("item-icon").Value : defaultIcon,
                                                               Accordion = i.Element("accordion-item") != null ? i.Element("accordion-item").Value : "",
                                                               MenuItem = i.Element("menu-item") != null ? i.Element("menu-item").Value : ""
                                                           }
                                                )
                                   };

            return new AjaxStoreResult(query);
        }
        
        //********************//
        //      Customer      //
        //********************//

        public AjaxStoreResult GetCustomer(int start, string filter)
        {
            if (!string.IsNullOrEmpty(filter))
            {
                var query = from c in this.DBContext.Customers

                            /// HACK: Simple search needs to be replaced with 'real' search
                            where (c.CompanyName.ToLower().Contains(filter.ToLower()) ||
                                   c.CustomerID.ToLower().StartsWith(filter.ToLower())
                                  ) 

                            select c;

                return new AjaxStoreResult(query.Skip(start).Take(1), query.Count());
            }

            return new AjaxStoreResult(this.DBContext.Customers.Skip(start).Take(1), this.DBContext.Customers.Count());
        }

        public AjaxStoreResult GetCustomersSimple(string filter)
        {
            var query = from c in this.DBContext.Customers

                        /// HACK: Simple search hack needs to be replaced with 'real' search
                        where (c.CompanyName.ToLower().StartsWith(filter.ToLower()) ||
                               c.CustomerID.ToLower().StartsWith(filter.ToLower()) ||
                               c.ContactName.ToLower().StartsWith(filter.ToLower()))

                        select new
                        {
                            c.CustomerID,
                            c.CompanyName,
                            c.ContactName
                        };

            return new AjaxStoreResult(query);
        }

        public AjaxStoreResult GetCustomersPaging(string filter, int start, int limit)
        {
            var query = from c in this.DBContext.Customers
                        
                        /// HACK: Simple search hack needs to be replaced with 'real' search
                        where (c.CompanyName.ToLower().StartsWith(filter.ToLower()) ||
                                c.CustomerID.ToLower().StartsWith(filter.ToLower()) ||
                               c.ContactName.ToLower().StartsWith(filter.ToLower()))
                        select new
                        {
                            c.CustomerID,
                            c.CompanyName,
                            c.ContactName
                        };

            return new AjaxStoreResult(query.Skip(start).Take(limit), query.Count());
        }

        public AjaxStoreResult GetCustomers(int limit, int start, string dir, string sort)
        {
            var query = (from c in this.DBContext.Customers
                        select new
                        {
                            c.CustomerID,
                            c.CompanyName,
                            c.ContactName,
                            c.Phone,
                            c.Fax,
                            c.Region
                        }).OrderBy(string.Concat(sort, " ", dir));

            int total = query.ToList().Count;

            query = query.Skip(start).Take(limit);
            return new AjaxStoreResult(query, total);
        }

        public AjaxResult DeleteCustomer(string id)
        {
            AjaxResult response = new AjaxResult();
            try
            {
                var customer = (from c in this.DBContext.Customers where c.CustomerID == id select c).First();
                this.DBContext.Customers.DeleteOnSubmit(customer);
                this.DBContext.SubmitChanges();
            }
            catch (Exception e)
            {
                response.ErrorMessage = e.ToString();
            }
            return response;
        }

        public AjaxFormResult SaveCustomer(string id, FormCollection values)
        {
            AjaxFormResult response = new AjaxFormResult();

            try
            {
                //for example
                if (string.IsNullOrEmpty(values["CompanyName"]))
                {
                    response.Success = false;
                    response.Errors.Add(new FieldError("CompanyName", "The CompanyName field is required"));
                    return response;
                }

                bool isNew = false;

                Customer customer;

                if(string.IsNullOrEmpty(id))
                {
                    if (string.IsNullOrEmpty(values["CustomerID"]))
                    {
                        response.Success = false;
                        response.Errors.Add(new FieldError("CustomerID", "The CustomerID field is required"));
                        return response;
                    }
                    
                    customer = new Customer();
                    customer.CustomerID = values["CustomerID"];
                    isNew = true;
                }
                else
                {
                    customer = (from c in this.DBContext.Customers where c.CustomerID == id select c).First();
                }
                
                customer.CompanyName = values["CompanyName"];
                customer.Address = values["Address"];
                customer.City = values["City"];
                customer.ContactName = values["ContactName"];
                customer.ContactTitle = values["ContactTitle"];
                customer.Country = values["Country"];
                customer.Fax = values["Fax"];                
                customer.Phone = values["Phone"];
                customer.PostalCode = values["PostalCode"];
                customer.Region = values["Region"];

                if(isNew)
                {
                    this.DBContext.Customers.InsertOnSubmit(customer);
                }

                this.DBContext.SubmitChanges();

                response.ExtraParams["newID"] = customer.CustomerID.ToString();
            }
            catch (Exception e)
            {
                response.Success = false;
                response.ExtraParams["msg"] = e.ToString();
            }

            return response;
        }

        public AjaxStoreResult SaveCustomersWithoutConfirmation()
        {
            AjaxStoreResult ajaxStoreResult = new AjaxStoreResult(StoreResponseFormat.Save);

            try
            {
                NorthwindDataContext db = this.DBContext;
                StoreDataHandler dataHandler = new StoreDataHandler(HttpContext.Request["data"]);
                ChangeRecords<Customer> data = dataHandler.ObjectData<Customer>();

                foreach (Customer customer in data.Deleted)
                {
                    db.Customers.Attach(customer);
                    db.Customers.DeleteOnSubmit(customer);
                }

                foreach (Customer customer in data.Updated)
                {
                    db.Customers.Attach(customer);
                    db.Refresh(RefreshMode.KeepCurrentValues, customer);
                }

                foreach (Customer customer in data.Created)
                {
                    db.Customers.InsertOnSubmit(customer);
                }

                db.SubmitChanges();
            }
            catch (Exception e)
            {
                ajaxStoreResult.SaveResponse.Success = false;
                ajaxStoreResult.SaveResponse.Message = e.Message;
            }

            return ajaxStoreResult;
        }

        public AjaxStoreResult SaveCustomersWithConfirmation()
        {
            AjaxStoreResult ajaxStoreResult = new AjaxStoreResult(StoreResponseFormat.Save);

            try
            {
                NorthwindDataContext db = this.DBContext;
                StoreDataHandler dataHandler = new StoreDataHandler(HttpContext.Request["data"]);
                ChangeRecords<Customer> data = dataHandler.ObjectData<Customer>();
                ConfirmationList confirmationList = dataHandler.BuildConfirmationList("CustomerID");

                foreach (Customer customer in data.Deleted)
                {
                    db.Customers.Attach(customer);
                    db.Customers.DeleteOnSubmit(customer);
                }

                foreach (Customer customer in data.Updated)
                {
                    db.Customers.Attach(customer);
                    db.Refresh(RefreshMode.KeepCurrentValues, customer);
                }

                foreach (Customer customer in data.Created)
                {
                    db.Customers.InsertOnSubmit(customer);
                }

                db.SubmitChanges();

                //ideally we should confirm after each operation
                //but LINQ can make batch submit of changes

                foreach (Customer customer in data.Deleted)
                {
                    confirmationList[customer.CustomerID].ConfirmRecord();
                }

                foreach (Customer customer in data.Updated)
                {
                    confirmationList[customer.CustomerID].ConfirmRecord();
                }

                foreach (Customer customer in data.Created)
                {
                    confirmationList[customer.CustomerID].ConfirmRecord();
                }


                ajaxStoreResult.SaveResponse.ConfirmationList = confirmationList;
            }
            catch (Exception e)
            {
                ajaxStoreResult.SaveResponse.Success = false;
                ajaxStoreResult.SaveResponse.Message = e.Message;
            }

            return ajaxStoreResult;
        }


        //********************//
        //       Order        //
        //********************//

        public AjaxStoreResult GetOrder(int orderID)
        {
             var query = from o in this.DBContext.Orders
                            where o.OrderID.Equals(orderID)
                            select new
                                       {
                                           o.OrderID,
                                           Salesperson = o.Employee.LastName + " " + o.Employee.FirstName,
                                           CustomerName = o.Customer.CompanyName,
                                           o.OrderDate,
                                           OrderDetails = from od in o.OrderDetails select new 
                                                            {
                                                                od.OrderID,
                                                                Product = od.Product.ProductName,
                                                                od.Quantity,
                                                                od.UnitPrice,
                                                                od.Discount
                                                            },
                                           ShippingCompany = o.Shipper.CompanyName,
                                           o.ShippedDate,
                                           o.Freight,
                                           o.ShipName,
                                           o.ShipAddress,
                                           o.ShipCity,
                                           o.ShipRegion,
                                           o.ShipPostalCode,
                                           o.ShipCountry
                                       };
                return new AjaxStoreResult(query.Take(1));
        }

        public AjaxStoreResult GetOrders(int limit, int start, string dir, string sort)
        {
            var query = (from o in this.DBContext.Orders
                        select new
                        {
                            o.OrderID,
                            o.OrderDate,
                            Salesperson = o.Employee.LastName + " " + o.Employee.FirstName,
                            o.Customer.CompanyName,
                            o.ShippedDate,
                            o.Freight,
                            Total = (from od in o.OrderDetails select od.UnitPrice * od.Quantity * (decimal) (1-od.Discount)).Sum() + o.Freight
                        }).OrderBy(string.Concat(sort, " ", dir));

            int total = query.ToList().Count;

            query = query.Skip(start).Take(limit);

            return new AjaxStoreResult(query, total);
        }

        public AjaxStoreResult GetCustomerOrders(string customerID)
        {
            var query = from o in this.DBContext.Orders
                        where o.CustomerID == customerID
                        select new
                         {
                             o.OrderID,                             
                             o.OrderDate,
                             o.RequiredDate,
                             o.ShippedDate
                         };

            return new AjaxStoreResult(query);
        }

        public AjaxStoreResult GetOrdersYears()
        {
            var query = (from o in this.DBContext.Orders
                        select new
                                   {
                                       o.OrderDate.Value.Year
                                   }).Distinct().OrderBy("Year");

            return new AjaxStoreResult(query);
        }

        //********************//
        //       Reports      //
        //********************//

        public AjaxStoreResult CustomerAddressBookReport()
        {
            var query = from c in this.DBContext.Customers
                        group c by c.ContactName[0] into custs
                        select new
                        {
                            Letter = custs.Key,
                            Customers = from cust in custs
                                        select new
                                        {
                                            cust.CustomerID,
                                            cust.CompanyName,
                                            ContactName = cust.ContactName ?? "-[no name]",
                                            Address = cust.Address ?? "",
                                            City = cust.City ?? "",
                                            Region = cust.Region ?? "",
                                            PostalCode = cust.PostalCode ?? "",
                                            Country = cust.Country ?? ""
                                        }
                        };

            return new AjaxStoreResult(query);
        }
    }
}