using System.Collections.Generic;
using CommandBus.Contracts;

namespace CommandBus.Repositories
{
    public interface ICustomerRepository
    {
        IList<Customer> GetAll();
        Customer GetById(int id);
        void Update(int id, Customer customer);
    }
}
