#region Copyright
//------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="United Shore Financial Services LLC.">
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

using System;

using CommandBusTesting.Composition;
using CommandBusTesting.Core.CommandBuses;
using CommandBusTesting.Core.Extensions;

namespace CommandBusTesting
{
    /// <summary>
    /// The program.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">The args.</param>
        public static void Main(string[] args)
        {
            var command1 = new SampleCommand
            {
                FirstName = "Brian",
                LastName = "Korzynski"
            };

            var command2 = new SampleCommand2
            {
                Username = "korz",
                Password = "password"
            };

            //var handler = new SampleCommandHandler();
            //handler.Handle(command);

            var commandBus = CompositionRoot.Get<ICommandBus>();
            commandBus.Send(command1);
            commandBus.Send(command2);

            Console.ReadKey();

            //ConcurrentDictionary
            //Retry Logic
            //Logging
            //CommandTranslation (take one command and process it then create another command to pass to another command)
            //Validation: ICommandValidator (mine wording), ValidationFailure
            //Different assemblies
            //Queries
            //Queue: persist messages to queue

        }
    }
}
