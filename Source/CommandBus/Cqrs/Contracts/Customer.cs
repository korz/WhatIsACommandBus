using System;

namespace Cqrs.Contracts
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }

        public Customer()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
