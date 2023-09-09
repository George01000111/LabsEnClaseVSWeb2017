using Cibertec.UnitOfWork;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cibertec.Mvc.Controllers
{
    public class OrderController : BaseController
    {
        public OrderController(ILog log, IUnitOfWork unit) : base(log, unit)
        {
        }

        // GET: Order
        public ActionResult Index()
        {
            return View(_unit.Orders.GetList());
        }
    }
}