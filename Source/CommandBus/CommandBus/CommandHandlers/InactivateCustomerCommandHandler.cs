using CommandBus.CommandBusCore.CommandHandlers;
using CommandBus.Commands;
using CommandBus.Repositories;

namespace CommandBus.CommandHandlers
{
    public class InactivateCustomerCommandHandler : ICommandHandler<InactivateCustomerCommand>
    {
        private readonly ICustomerRepository customerRepository;

        public InactivateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public void Handle(InactivateCustomerCommand command)
        {
            command.Customer.IsActive = false;

            this.customerRepository.Update(command.Customer.Id, command.Customer);
        }
    }
}
