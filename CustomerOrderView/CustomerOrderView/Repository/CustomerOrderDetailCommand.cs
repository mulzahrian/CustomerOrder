using CustomerOrderView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderView.Repository
{
    class CustomerOrderDetailCommand
    {
        private string _connectionString;

        public CustomerOrderDetailCommand(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IList<CustomerOrderDetailModels> GetList()
        {
            List<CustomerOrderDetailModels> customerOrderDetailModels = new List<CustomerOrderDetailModels>();

            return customerOrderDetailModels;
        }
    }
}
