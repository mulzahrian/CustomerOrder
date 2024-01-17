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
            try
            {
                CustomerOrderDetailCommand customerOrderDetailCommand = new CustomerOrderDetailCommand(@"Data Source=(localdb)\Local; Initial Catalog=CustomerOrderViewer; Integrated Security=True");

                IList<CustomerOrderDetailModels> customerOrderDetailModels = customerOrderDetailCommand.GetList();

                if (customerOrderDetailModels.Any())
                {
                    foreach(CustomerOrderDetailModels customerOrderDetailModel in customerOrderDetailModels)
                    {
                        Console.WriteLine("{0}: Fullname: {1} {2} (Id: {3}) = purchased {4} for {5} (Id: {6})",
                            customerOrderDetailModel.CustomerId,
                            customerOrderDetailModel.FirstName,
                            customerOrderDetailModel.LastName,
                            customerOrderDetailModel.CustomerId,
                            customerOrderDetailModel.Description,
                            customerOrderDetailModel.Price,
                            customerOrderDetailModel.ItemId

);
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine("Something went wrong {0}",ex.Message);
            }
        }
    }

}