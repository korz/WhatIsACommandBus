using System;
using CommandBus.CommandBusCore.CommandBusses;
using CommandBus.Commands;
using CommandBus.Composition;
using CommandBus.Repositories;

namespace CommandBus
{
    class Program
    {
        static void Main(string[] args)
        {
            var commandBus = CompositionRoot.Get<ICommandBus>();
            var customerRepository = CompositionRoot.Get<ICustomerRepository>();

            var customer = customerRepository.GetById(1);

            Console.WriteLine(customer.ToJson());

            commandBus.Send(new InactivateCustomerCommand(customer));

            var updatedCustomer = customerRepository.GetById(1);

            Console.WriteLine(updatedCustomer.ToJson());

            Console.ReadKey();
        }
    }
}
