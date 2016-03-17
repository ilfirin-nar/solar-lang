using System.Collections.Generic;
using Solar.Frontend.Compiler.Services.Actions;

namespace Solar.Frontend.Compiler.Services
{
    internal class CommandLineActionsDirectory : ICommandLineActionsDirectory
    {
        public CommandLineActionsDirectory(IReadOnlyList<ICommandLineAction> actions)
        {
            Actions = actions;
        }

        public IReadOnlyList<ICommandLineAction> Actions { get; private set; }
    }
}