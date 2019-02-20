using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Models;

namespace Contracts.Repositories.Customers
{
    public interface ICustomerQueryRepository
    {
        Task<IList<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(Guid id);
    }
}
