using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Contracts.Models;
using Contracts.Repositories.Customers;
using Dapper;

namespace Infrastructure.Repositories.Customers
{
    public class CustomerQueryRepository : ICustomerQueryRepository
    {
        public async Task<IList<Customer>> GetAllAsync()
        {
            var customers = new List<Customer>();

            using (var connection = new SqlConnection(Settings.ConnectionString))
            {
                connection.Open();

                var results = await connection.QueryAsync<Customer>("SELECT * FROM Customers");
                customers.AddRange(results.ToList());

                connection.Close();
            }

            return customers;
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            Customer customer;

            using (var connection = new SqlConnection(Settings.ConnectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<Customer>("SELECT * FROM Customers WHERE Id = @Id", new { Id = id });
                customer = result.SingleOrDefault();

                connection.Close();
            }

            return customer;
        }
    }
}
