using System;
using System.Threading;
using System.Threading.Tasks;
using Contracts.Models;
using Contracts.Repositories.Customers;
using MediatR;

namespace Application.Queries.Customers
{
    public static class GetCustomerById
    {
        public class Query : IRequest<Customer>
        {
            public Guid Id { get; set; }
        }

        public class GetCustomerByIdQueryHandler : IRequestHandler<Query, Customer>
        {
            private readonly ICustomerQueryRepository _customerQueryRepository;

            public GetCustomerByIdQueryHandler(ICustomerQueryRepository customerQueryRepository)
            {
                _customerQueryRepository = customerQueryRepository;
            }

            public async Task<Customer> Handle(Query request, CancellationToken cancellationToken)
            {
                return await this._customerQueryRepository.GetByIdAsync(request.Id);
            }
        }
    }
}
