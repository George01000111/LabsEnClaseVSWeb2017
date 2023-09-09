﻿using Cibertec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Repositories.Northwind
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable<Customer> PagedList(int startRow, int endRow);
        int Count();
    }
}
