using System;
using System.Data;
using Cqrs.Contracts;
using Dapper;

namespace Cqrs.Repositories
{
    public class CustomerCommandRepository : ICustomerCommandRepository
    {
        private readonly IDbConnection _connection;

        public CustomerCommandRepository(IDbConnection connection)
        {
            this._connection = connection;
        }

        public void Update(Guid id, Customer customer)
        {
            this._connection.Open();

            this._connection.Execute(@"
                UPDATE Customers
                SET
                    FirstName = @FirstName,
                    LastName = @LastName,
                    IsActive = @IsActive
                WHERE Id = @Id",
                new
                {
                    Id = id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    IsActive = customer.IsActive
                });

            this._connection.Close();
        }
    }
}
