using Cqrs.CommandBusCore.CommandHandlers;
using Cqrs.Commands;
using Cqrs.Repositories;

namespace Cqrs.CommandHandlers
{
    public class InactivateCustomerCommandHandler : ICommandHandler<InactivateCustomerCommand>
    {
        private readonly ICustomerCommandRepository _customerCommandRepository;

        public InactivateCustomerCommandHandler(ICustomerCommandRepository _customerCommandRepository)
        {
            this._customerCommandRepository = _customerCommandRepository;
        }

        public void Handle(InactivateCustomerCommand command)
        {
            command.Customer.IsActive = false;

            this._customerCommandRepository.Update(command.Customer.Id, command.Customer);
        }
    }
}
