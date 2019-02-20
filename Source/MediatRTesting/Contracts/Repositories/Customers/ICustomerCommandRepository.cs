using System;
using System.Threading.Tasks;
using Contracts.Models;

namespace Contracts.Repositories.Customers
{
    public interface ICustomerCommandRepository
    {
        void Update(Guid id, Customer customer);
        Task<Customer> UpdateAsync(Guid id, Customer customer);
    }
}
