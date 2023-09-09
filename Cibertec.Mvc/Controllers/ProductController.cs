using Cibertec.Models;
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
    public class ProductController : BaseController
    {
        public ProductController(ILog log, IUnitOfWork unit):base(log, unit)
        {
        }

        // GET: Product
        public ActionResult Index()
        {
            return View(_unit.Products.GetList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[ActionName("Create")]
        //public ActionResult Create(Product product)
        public ActionResult CreatePost()
        {
            var product = new Product();
            bool x = TryUpdateModel(product);

            var y = product.ProductName;

            return RedirectToAction("Index");
            //return View("Index");
        }

        [HttpPost]
        public ActionResult Create([Bind(Include ="ProductName,UnitPrice")] Product product)
        {            
                var y = product.ProductName;

            return RedirectToAction("Index");
            //return View("Index");
        }
    }
}