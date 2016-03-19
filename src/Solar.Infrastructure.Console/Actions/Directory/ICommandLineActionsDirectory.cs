using System.Collections.Generic;
using Solar.Infrastructure.Common.Interfaces;

namespace Solar.Infrastructure.Console.Actions.Directory
{
    internal interface ICommandLineActionsDirectory : IDirectory
    {
        IReadOnlyList<ICommandLineAction> Actions { get; }
    }
}