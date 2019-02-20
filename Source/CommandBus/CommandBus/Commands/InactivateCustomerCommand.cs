using CommandBus.CommandBusCore.Commands;
using CommandBus.Contracts;

namespace CommandBus.Commands
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
