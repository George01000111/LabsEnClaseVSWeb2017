using Cibertec.Models;
using Cibertec.Mvc.ActionFilters;
using Cibertec.Mvc.ViewModels;
using Cibertec.Repositories.Dapper.Northwind;
using Cibertec.UnitOfWork;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cibertec.Mvc.Controllers
{
    //[LoggingFilter]
    [ErrorActionFilter]
    [RoutePrefix("Customer")]
    public class CustomerController : BaseController
    {
        public CustomerController(ILog log, IUnitOfWork unit): base(log, unit)
        {
        }

        // GET: Customer
        public ActionResult Index()
        {
            _log.Info("Ejecucion de controlador Customer");
            return View(_unit.Customers.GetList());
        }

        public ActionResult Error()
        {
            throw new Exception("Erorr de prueba para validar Action Filter");
        }

        public ActionResult Details(int id)
        {
            return View(_unit.Customers.GetById(id));
        }

        //[LoggingFilter]
        public ActionResult DetailsName(string clientName)
        {
            var customer = _unit.Customers.GetList()
                .Where(q => q.FirstName == clientName).FirstOrDefault();

            var customer2 = _unit.Customers.GetList()
                .FirstOrDefault(q => q.FirstName == clientName);

            return View("Details", customer);
        }

        public PartialViewResult Create()
        {
            return PartialView("_Create", new Customer());
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid) return PartialView("_Create", customer);

            int result = _unit.Customers.Insert(customer);
            return PartialView("_List", _unit.Customers.GetList());
            //RedirectToAction("Index");
        }

        public ActionResult OrdersByCustomer(int id)
        {
            var customer = _unit.Customers.GetById(id);
            var orders = _unit.Orders.GetList();
            var ordersBycustomer = orders.Where(o => o.CustomerId == id);

            return View(new CustomerOrderViewModel() {
                CustomerName = customer.FirstName + " " + customer.LastName,
                Orders = ordersBycustomer.ToList()
            });
        }

        public PartialViewResult Edit(int id)
        {
            var customer = _unit.Customers.GetById(id);
            return PartialView("_Edit",customer);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (!ModelState.IsValid) return PartialView("_Edit", customer);

            bool result = _unit.Customers.Update(customer);
            return PartialView("_List", _unit.Customers.GetList());
                //RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var customer = _unit.Customers.GetById(id);
            return PartialView("_Delete", customer);

            //var customer = _unit.Customers.GetById(id);
            //_unit.Customers.Delete(customer);
            //return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(Customer customer)
        {
            if (_unit.Customers.Delete(customer))
                return PartialView("_List", _unit.Customers.GetList());
            //return RedirectToAction("Index");

            return PartialView("_Delete", customer);
        }

        [Route("List/{page:int}/{rows:int}")]
        public PartialViewResult List(int page, int rows)
        {
            if (page <= 0 || rows <= 0) return PartialView(new List<Customer>());

            var startRecord = ((page - 1) * rows) + 1;
            var endRecord = page * rows;
            return PartialView("_List", _unit.Customers.PagedList(startRecord, endRecord));
        }

        [HttpGet]
        [Route("Count/{rows:int}")]
        //[Route("{rows:int}")]
        //[Route("Count")]
        public int Count(int rows)
        {
            //int rows = 1;
            var totalRecords = _unit.Customers.Count();
            return totalRecords % rows != 0 ? (totalRecords / rows) + 1 : totalRecords / rows; 
        }
    }
}