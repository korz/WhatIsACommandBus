using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Cqrs.Contracts;
using Dapper;

namespace Cqrs.Repositories
{
    public class CustomerQueryRepository : ICustomerQueryRepository
    {
        private readonly IDbConnection _connection;

        public CustomerQueryRepository(IDbConnection connection)
        {
            this._connection = connection;
        }

        public IList<Customer> GetAll()
        {
            this._connection.Open();

            var results = this._connection.Query<Customer>("SELECT * FROM Customers").ToList();

            this._connection.Close();

            return results;
        }

        public Customer GetById(Guid id)
        {
            this._connection.Open();

            var result = this._connection.Query<Customer>("SELECT * FROM Customers WHERE Id = @Id", new { Id = id }).SingleOrDefault();

            this._connection.Close();

            return result;
        }
    }
}
