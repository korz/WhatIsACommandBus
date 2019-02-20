using System;
using Cqrs.CommandBusCore.Queries;
using Cqrs.Contracts;

namespace Cqrs.Queries
{
    public class GetCustomerByIdQuery : IQuery<Customer>
    {
        public Guid Id { get; set; }
    }
}
