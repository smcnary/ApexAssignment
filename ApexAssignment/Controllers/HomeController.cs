using ApexAssignment.Models;
using ApexAssignment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Configuration;
using OfficeOpenXml;

namespace ApexAssignment.Controllers
{
    public class HomeController : Controller
    {
        private AWModel db;

        public HomeController()
        {
            db = new AWModel();
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetOrders(DateTime startDate, DateTime endDate)
        {
            
            var model = db.SalesOrderDetails
                .Where(e => e.SalesOrderHeader.OrderDate > startDate)
                .Where(e => e.SalesOrderHeader.OrderDate < endDate)
                .Join(db.Products, order => order.ProductID,
                    product => product.ProductID,
                    (order, product) => new OrderViewModel()
                    {
                        Quantity = order.OrderQty,
                        UnitNet = order.UnitPrice,
                        DueDate = order.SalesOrderHeader.DueDate,
                        CustomerPO = order.SalesOrderHeader.PurchaseOrderNumber,
                        InvoiceNumber = order.SalesOrderHeader.SalesOrderNumber,
                        InvoiceTotal = order.SalesOrderHeader.TotalDue,
                        OrderDate = order.SalesOrderHeader.OrderDate,
                        AccountNumber = order.SalesOrderHeader.AccountNumber,
                        Store = order.SalesOrderHeader.Customer.Store.Name,
                        Customer = order.SalesOrderHeader.Customer.Person.FirstName + " " +
                                   order.SalesOrderHeader.Customer.Person.LastName,
                        ProductNumber = product.ProductNumber
                    }).Take(15);

            return View(model.ToList());
        }

        //public void ExportToExcel(DateTime startDate, DateTime endDate)
        //{
        //    var pkg = new ExcelPackage();
        //    var wbk = pkg.Workbook;
        //    var sheet = wbk.Worksheets.Add("Invoice Data");

        //    var normalStyle = "Normal";
        //    var acctStyle = wbk.CreateAccountingFormat();
        //    var data = db.SalesOrderDetails
        //        .Where(e => e.SalesOrderHeader.OrderDate > startDate)
        //        .Where(e => e.SalesOrderHeader.OrderDate < endDate)
        //        .Join(db.Products, order => order.ProductID,
        //            product => product.ProductID,
        //            (order, product) => new OrderViewModel()
        //            {
        //                Quantity = order.OrderQty,
        //                UnitNet = order.UnitPrice,
        //                DueDate = order.SalesOrderHeader.DueDate,
        //                CustomerPO = order.SalesOrderHeader.PurchaseOrderNumber,
        //                InvoiceNumber = order.SalesOrderHeader.SalesOrderNumber,
        //                InvoiceTotal = order.SalesOrderHeader.TotalDue,
        //                OrderDate = order.SalesOrderHeader.OrderDate,
        //                AccountNumber = order.SalesOrderHeader.AccountNumber,
        //                Store = order.SalesOrderHeader.Customer.Store.Name,
        //                Customer = order.SalesOrderHeader.Customer.Person.FirstName + " " +
        //                           order.SalesOrderHeader.Customer.Person.LastName,
        //                ProductNumber = product.ProductNumber
        //            }).Take(15);


        //}    
            
    }


        
}
