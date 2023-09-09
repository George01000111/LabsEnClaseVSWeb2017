using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Cibertec.Mvc
{
    public class CustomerHub: Hub
    {
        //public void Message(string message)
        //{
        //    Clients.All.getMessage(message);
        //}

        static List<int> CustomerIds = new List<int>();

        public void AddCustomerId(int id)
        {
            if (!CustomerIds.Contains(id)) CustomerIds.Add(id);
            Clients.All.customerStatus(CustomerIds);
        }

        public void RemoveCustomerId(int id)
        {
            if (CustomerIds.Contains(id)) CustomerIds.Remove(id);
            Clients.All.customerStatus(CustomerIds);
        }

        public override Task OnConnected()
        {
            //return base.OnConnected();
            return Clients.All.customerStatus(CustomerIds);
        }
    }
}