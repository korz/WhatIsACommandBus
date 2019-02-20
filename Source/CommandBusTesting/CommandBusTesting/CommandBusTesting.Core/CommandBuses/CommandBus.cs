#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="CommandBus.cs" company="United Shore Financial Services LLC.">
//     Copyright &copy; United Shore Financial Services Inc. 2012-2017.
// 
//     Copyright in the application source code, and in the information and
//     material therein and in their arrangement, is owned by United Shore Financial Services LLC.
//     unless otherwise indicated.
// 
//     You shall not remove or obscure any copyright, trademark or other notices.
//     You may not copy, republish, redistribute, transmit, participate in the
//     transmission of, create derivatives of, alter edit or exploit in any
//     manner any material including by storage on retrieval systems, without the
//     express written permission of United Shore Financial Services LLC.
// </copyright>
//------------------------------------------------------------------------------------------

#endregion

using CommandBusTesting.Core.BindingHandlers;
using CommandBusTesting.Core.Commands;
using CommandBusTesting.Core.Queries;

using Serilog;

namespace CommandBusTesting.Core.CommandBuses
{
    public class CommandBus : ICommandBus
    {
        private readonly ICommandHandlerRetreiver commandHandlerRetreiver;
        private readonly IQueryHandlerRetreiver queryHandlerRetreiver;

        private readonly ILogger logger;

        public CommandBus(ICommandHandlerRetreiver commandHandlerRetreiver, 
            IQueryHandlerRetreiver queryHandlerRetreiver, 
            ILogger logger)
        {
            this.commandHandlerRetreiver = commandHandlerRetreiver;
            this.queryHandlerRetreiver = queryHandlerRetreiver;
            this.logger = logger;
        }

        public void Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            this.logger.Information("Starting to process command");

            var handler = this.commandHandlerRetreiver.Get<TCommand>();

            handler.Handle(command);

            this.logger.Information("Finished processing the command");
        }

        public TResult Send<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {
            this.logger.Information("Starting to process query");

            var handler = this.queryHandlerRetreiver.Get<TQuery, TResult>();

            var result = handler.Handle(query);

            this.logger.Information("Finished processing the query");

            return result;
        }
    }
}
