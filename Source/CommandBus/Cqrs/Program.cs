using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Cqrs.CommandBusCore.CommandBusses;
using Cqrs.Composition;
using Cqrs.Contracts;
using Cqrs.Queries;
using Dapper;

namespace Cqrs
{
    static class Program
    {
        private static ICommandBus CommandBus;

        static Program()
        {
            CommandBus = CompositionRoot.Get<ICommandBus>();
        }

        static void Main(string[] args)
        {
            var getCustomerQuery = new GetCustomerByIdQuery {Id = Guid.Parse("4AC1E4A4-8031-4D66-BDB1-0FDCBB9B4443")};

            var customer = getCustomerQuery.SendQuery<GetCustomerByIdQuery, Customer>(getCustomerQuery);
            
        }

        private static void SetupDatabase(IDbConnection connection)
        {
            var customers = Populate();

            connection.Open();

            foreach (var customer in customers)
            {
                connection.Execute("INSERT INTO Customers VALUES (@Id, @FirstName, @LastName, @IsActive)", new
                {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    IsActive = customer.IsActive
                });
            }

            connection.Close();
        }

        private static IList<Customer> Populate()
        {
            return new List<Customer>
            {
                new Customer
                {
                    FirstName = "Melissa",
                    LastName = "Labadie",
                    IsActive = true,
                },
                new Customer
                {
                    FirstName = "Gerard",
                    LastName = "Gerhold",
                    IsActive = true,
                },
                new Customer
                {
                    FirstName = "Clemens",
                    LastName = "Kassulke",
                    IsActive = true,
                },
                new Customer
                {
                    FirstName = "Cloyd",
                    LastName = "Heaney",
                    IsActive = true,
                },
                new Customer
                {
                    FirstName = "Magdalena",
                    LastName = "Lynch",
                    IsActive = true,
                },
                new Customer
                {
                    FirstName = "Zoila",
                    LastName = "Sanford",
                    IsActive = true,
                },
                new Customer
                {
                    FirstName = "Owen",
                    LastName = "Treutel",
                    IsActive = true
                },
                new Customer
                {
                    FirstName = "Christa",
                    LastName = "Kessler",
                    IsActive = true
                },
                new Customer
                {
                    FirstName = "Dameon",
                    LastName = "Lehner",
                    IsActive = true
                }
            };
        }
    }
}
