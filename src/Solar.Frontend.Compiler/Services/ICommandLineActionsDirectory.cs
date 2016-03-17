using System.Collections.Generic;
using Solar.Frontend.Compiler.Services.Actions;
using Solar.Infrastructure.Common.Interfaces;

namespace Solar.Frontend.Compiler.Services
{
    internal interface ICommandLineActionsDirectory : IDirectory
    {
        IReadOnlyList<ICommandLineAction> Actions { get; }
    }
}