using System.Collections.Generic;
using Evergreen.Infrastructure.Common.Interfaces;

namespace Evergreen.Infrastructure.Console.Actions.Directory
{
    internal interface ICommandLineActionsDirectory : IDirectory
    {
        IReadOnlyList<ICommandLineAction> Actions { get; }
    }
}