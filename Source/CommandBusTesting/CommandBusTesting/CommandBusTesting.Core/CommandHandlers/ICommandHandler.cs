#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="ICommandHandler.cs" company="United Shore Financial Services LLC.">
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

using CommandBusTesting.Core.Commands;

namespace CommandBusTesting.Core.CommandHandlers
{
    /// <summary>
    /// The CommandHandler interface.
    /// </summary>
    /// <typeparam name="TCommand">Command type
    /// </typeparam>
    public interface ICommandHandler<in TCommand> : IBaseCommandHandler where TCommand : ICommand
    {
        /// <summary>
        /// Handles the command
        /// </summary>
        /// <param name="command">Command needing processing</param>
        void Handle(TCommand command);
    }
}
