using System;
using System.Data;
using Cqrs.CommandBusCore.CommandBusses;
using Cqrs.CommandBusCore.QueryHandlers;
using Cqrs.Contracts;
using Cqrs.Queries;
using Cqrs.Repositories;

namespace Cqrs.QueryHandlers
{
    public class GetCustomerByIdQueryHandler : IQueryHandler<GetCustomerByIdQuery, Customer>
    {
        private readonly ICustomerQueryRepository _customerQueryRepository;

        public GetCustomerByIdQueryHandler(ICustomerQueryRepository customerQueryRepository)
        {
            _customerQueryRepository = customerQueryRepository;
        }

        public Customer Handle(GetCustomerByIdQuery query)
        {
            return this._customerQueryRepository.GetById(query.Id);
        }
    }
}
