using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Contracts;
using Contracts.Models;
using Dapper;

namespace Infrastructure.DatabasePopulators
{
    public static class DatabasePopulator
    {
        public static void Populate()
        {
            var customers = GetSampleCustomers();

            using (var connection = new SqlConnection(Settings.ConnectionString))
            {
                connection.Open();

                foreach (var customer in customers)
                {
                    connection.Execute("INSERT INTO Customers VALUES(@Id, @FirstName, @LastName, @IsActive)", new
                    {
                        customer.Id,
                        customer.FirstName,
                        customer.LastName,
                        customer.IsActive
                    });
                }

                connection.Close();
            }
        }

        private static IList<Customer> GetSampleCustomers()
        {
            return new List<Customer>
            {
                new Customer
                {
                    Id = Guid.Parse("05768B52-89FC-41A0-BDAE-B34759DF9E1B"),
                    FirstName = "Melissa",
                    LastName = "Labadie",
                    IsActive = true,
                },
                new Customer
                {
                    Id = Guid.Parse("2BAFA733-EFFB-447B-AC5B-A081FA9CE42C"),
                    FirstName = "Gerard",
                    LastName = "Gerhold",
                    IsActive = true,
                },
                new Customer
                {
                    Id = Guid.Parse("E25B3E82-125C-4901-99A4-3F2688591936"),
                    FirstName = "Clemens",
                    LastName = "Kassulke",
                    IsActive = true,
                },
                new Customer
                {
                    Id = Guid.Parse("CE1709DC-8F43-4940-89FC-CE207D49D5B8"),
                    FirstName = "Cloyd",
                    LastName = "Heaney",
                    IsActive = true,
                },
                new Customer
                {
                    Id = Guid.Parse("4F015E4A-F55A-45FB-B02C-1AD3827078D0"),
                    FirstName = "Magdalena",
                    LastName = "Lynch",
                    IsActive = true,
                },
                new Customer
                {
                    Id = Guid.Parse("A11CAD72-A4FC-478B-86E5-A26752FEB897"),
                    FirstName = "Zoila",
                    LastName = "Sanford",
                    IsActive = true,
                },
                new Customer
                {
                    Id = Guid.Parse("E4931718-A149-4C17-8545-5D36D81A6DD5"),
                    FirstName = "Owen",
                    LastName = "Treutel",
                    IsActive = true
                },
                new Customer
                {
                    Id = Guid.Parse("41F95E3D-42CA-4EB4-A800-BB974B71D974"),
                    FirstName = "Christa",
                    LastName = "Kessler",
                    IsActive = true
                },
                new Customer
                {
                    Id = Guid.Parse("11A20FCA-B739-471D-AB45-B9140CED8611"),
                    FirstName = "Dameon",
                    LastName = "Lehner",
                    IsActive = true
                }
            };
        }
    }
}
