#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="SampleCommandHandler.cs" company="United Shore Financial Services LLC.">
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
using System.Data;
using CommandBusTesting.Core.CommandHandlers;

namespace CommandBusTesting
{
    public class SampleCommandHandler : ICommandHandler<SampleCommand>
    {
	    private readonly IDbConnection _connection;

	    public SampleCommandHandler(IDbConnection connection)
	    {
		    _connection = connection;
	    }

        public void Handle(SampleCommand command)
        {
            Console.WriteLine($"Hello {command.FirstName} {command.LastName}");
        }
    }
}
