using System.Collections.Generic;
using System.Linq;
using CommandBus.Composition;
using CommandBus.Contracts;

namespace CommandBus.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private IList<Customer> customers;

        public CustomerRepository()
        {
            this.customers = new List<Customer>();
            this.Populate();
        }

        private void Populate()
        {
            this.customers = new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    FirstName = "Melissa",
                    LastName = "Labadie",
                    IsActive = true,
                },
                new Customer
                {
                    Id = 2,
                    FirstName = "Gerard",
                    LastName = "Gerhold",
                    IsActive = true,
                },
                new Customer
                {
                    Id = 3,
                    FirstName = "Clemens",
                    LastName = "Kassulke",
                    IsActive = true,
                },
                new Customer
                {
                    Id = 4,
                    FirstName = "Cloyd",
                    LastName = "Heaney",
                    IsActive = true,
                },
                new Customer
                {
                    Id = 5,
                    FirstName = "Magdalena",
                    LastName = "Lynch",
                    IsActive = true,
                },
                new Customer
                {
                    Id = 6,
                    FirstName = "Zoila",
                    LastName = "Sanford",
                    IsActive = true,
                },
                new Customer
                {
                    Id = 7,
                    FirstName = "Owen",
                    LastName = "Treutel",
                    IsActive = true
                },
                new Customer
                {
                    Id = 8,
                    FirstName = "Christa",
                    LastName = "Kessler",
                    IsActive = true
                },
                new Customer
                {
                    Id = 9,
                    FirstName = "Dameon",
                    LastName = "Lehner",
                    IsActive = true
                }
            };
        }

        public IList<Customer> GetAll()
        {
            return this.customers;
        }

        public Customer GetById(int id)
        {
            return this.customers.Where(x => x.Id == id).SingleOrDefault();
        }

        public void Update(int id, Customer customer)
        {
            var currentCustomer = this.customers.Where(x => x.Id == id).SingleOrDefault();

            currentCustomer.FirstName = customer.FirstName;
            currentCustomer.LastName = customer.LastName;
            currentCustomer.IsActive = customer.IsActive;
        }
    }
}
