using System;
using System.Collections.Generic;
using System.Text;

namespace BrsPontes.Shared.Commands
{
    public interface ICommandHandler<T> where T : ICommands
    {
        ICommandResult Handle(T command);
    }
}
