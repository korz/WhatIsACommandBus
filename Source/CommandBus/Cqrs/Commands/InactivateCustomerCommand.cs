using Cqrs.CommandBusCore.Commands;
using Cqrs.Contracts;

namespace Cqrs.Commands
{
    public class InactivateCustomerCommand : ICommand
    {
        public Customer Customer { get; set; }

        public InactivateCustomerCommand(Customer customer)
        {
            this.Customer = customer;
        }
    }
}
