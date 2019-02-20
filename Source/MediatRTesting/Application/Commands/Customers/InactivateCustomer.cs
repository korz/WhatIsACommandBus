using System.Threading;
using System.Threading.Tasks;
using Contracts.Models;
using Contracts.Repositories.Customers;
using MediatR;

namespace Application.Commands.Customers
{
    public static class InactivateCustomer
    {
        public class Command : IRequest<Customer>
        {
            public Customer Customer { get; set; }

            public Command(Customer customer)
            {
                this.Customer = customer;
            }
        }

        public class InactivateCustomerCommandHandler : IRequestHandler<Command, Customer>
        {
            private readonly ICustomerCommandRepository _customerCommandRepository;

            public InactivateCustomerCommandHandler(ICustomerCommandRepository customerCommandRepository)
            {
                this._customerCommandRepository = customerCommandRepository;
            }

            public async Task<Customer> Handle(Command request, CancellationToken cancellationToken)
            {
                request.Customer.IsActive = false;

                var customer = await this._customerCommandRepository.UpdateAsync(request.Customer.Id, request.Customer);

                return customer;
            }
        }
    }
}
