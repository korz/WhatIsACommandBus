using System;
using Application.Queries.Customers;
using MediatR;
using MediatRTesting.Composition;

namespace MediatRTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            var mediator = CompositionRoot.Get<IMediator>();

            var getCustomerQuery = new GetCustomerById.Query { Id = Guid.Parse("E4931718-A149-4C17-8545-5D36D81A6DD5") };
            
            var customer = mediator.Send(getCustomerQuery).Result;
        }
    }
}
