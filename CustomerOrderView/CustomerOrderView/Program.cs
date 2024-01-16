using CustomerOrderView.Models;
using CustomerOrderView.Repository;
using System.Data.SqlClient;
using System;

namespace CustomerOrderView
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerOrderDetailCommand customerOrderDetailCommand = new CustomerOrderDetailCommand(@"Data Source=(localdb)\Local; Initial Catalog=CustomerOrderViewer; Integrated Security=True");

            IList<CustomerOrderDetailModels> customerOrderDetailModels = customerOrderDetailCommand.GetList();
        }
    }

}