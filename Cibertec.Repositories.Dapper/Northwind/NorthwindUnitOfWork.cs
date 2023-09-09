using Cibertec.Repositories.Northwind;
using Cibertec.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Repositories.Dapper.Northwind
{
    public class NorthwindUnitOfWork : IUnitOfWork
    {
        public NorthwindUnitOfWork(string connectionString)
        {
            Customers = new CustomerRepository(connectionString);
            Products = new ProductRepository(connectionString);
            Orders = new OrderRepository(connectionString);
            Users = new UserRepository(connectionString);
        }

        public ICustomerRepository Customers { get; private set; }
        public IProductRepository Products { get; private set; }
        public IOrderRepository Orders { get; private set; }

        public IUserRepository Users { get; private set; }
    }
}
