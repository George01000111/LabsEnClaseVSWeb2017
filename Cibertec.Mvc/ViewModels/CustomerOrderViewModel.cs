using Cibertec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cibertec.Mvc.ViewModels
{
    public class CustomerOrderViewModel
    {
        public string CustomerName { get; set; }
        public List<Order> Orders { get; set; }
    }
}