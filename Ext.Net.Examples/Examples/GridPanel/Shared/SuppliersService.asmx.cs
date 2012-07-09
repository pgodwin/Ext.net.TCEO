using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Web.Services;

using Ext.Net.Examples.Northwind;
using XResponse = Ext.Net.Response;

namespace Ext.Net.Examples
{
    /// <summary>
    /// Summary description for SuppliersService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SuppliersService : System.Web.Services.WebService
    {
        [WebMethod]
        public List<SerializableEntity<Supplier>> GetAllSuppliers()
        {
            NorthwindDataContext db = new NorthwindDataContext();

            return db.Suppliers.ToList<Supplier, SerializableEntity<Supplier>>();
        }

        [WebMethod]
        public XResponse SaveSuppliers(string data)
        {
            Response sr = new Response(true);

            try
            {
                NorthwindDataContext db = new NorthwindDataContext();
                StoreDataHandler dataHandler = new StoreDataHandler(data);
                ChangeRecords<Supplier> dataList = dataHandler.ObjectData<Supplier>();

                foreach (Supplier supplier in dataList.Deleted)
                {
                    db.Suppliers.Attach(supplier);
                    db.Suppliers.DeleteOnSubmit(supplier);
                }

                foreach (Supplier supplier in dataList.Updated)
                {
                    db.Suppliers.Attach(supplier);
                    db.Refresh(RefreshMode.KeepCurrentValues, supplier);
                }

                foreach (Supplier supplier in dataList.Created)
                {
                    supplier.TemporaryID = supplier.SupplierID;
                    db.Suppliers.InsertOnSubmit(supplier);
                }

                db.SubmitChanges();
            }
            catch (Exception e)
            {
                sr.Success = false;
                sr.Message = e.Message;
            }

            return sr;
        }
    }
}
