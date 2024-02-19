using CustomerOrderViewe2._0.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderViewe2._0.Repository
{
    internal class CustomerOrderCommand
    {
        private string _connectionString;

        public CustomerOrderCommand(String connectionString)
        {
            _connectionString = connectionString;
        }

        public void Upsert(int customerOrderId, int customerId, int itemId, string userId)
        {
            var upsertStatement = "CustomerOrderDetail_Upsert";

            var dataTable = new DataTable();
            dataTable.Columns.Add("CustomerOrderId", typeof(int));
            dataTable.Columns.Add("CustomerId", typeof(int));
            dataTable.Columns.Add("ItemId", typeof(int));
            dataTable.Rows.Add(customerOrderId, customerId, itemId);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Execute(upsertStatement, new { @CustomerOrderType = dataTable.AsTableValuedParameter("CustomerOrderType"), @UserId = userId }, commandType: CommandType.StoredProcedure);
            }
        }
       

        public void Delete(int customerOrderId, string userId)
        {
            var upsertStatement = "CustomerOrderDetail_Delete";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                connection.Execute(upsertStatement, new { @CustomerOrderId = customerOrderId, @UserId = userId }, commandType: CommandType.StoredProcedure);

            }

        }

        public IList<CustomerOrderDetailModel> GetList()
        {
            List<CustomerOrderDetailModel> customerOrderDetailModels = new List<CustomerOrderDetailModel>();

            var sql = "CustomerOrderDetail_GetList";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                customerOrderDetailModels = connection.Query<CustomerOrderDetailModel>(sql).ToList();

            }

            return customerOrderDetailModels;

        }

    }
}
