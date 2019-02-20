using System;
using Cqrs.Contracts;

namespace Cqrs.Repositories
{
    public interface ICustomerCommandRepository
    {
        void Update(Guid id, Customer customer);
    }
}
