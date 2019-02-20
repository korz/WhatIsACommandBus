using System;
using System.Collections.Generic;
using Cqrs.Contracts;

namespace Cqrs.Repositories
{
    public interface ICustomerQueryRepository
    {
        IList<Customer> GetAll();
        Customer GetById(Guid id);
    }
}
