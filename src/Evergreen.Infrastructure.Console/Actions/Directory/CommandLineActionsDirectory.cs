using System.Collections.Generic;

namespace Evergreen.Infrastructure.Console.Actions.Directory
{
    internal class CommandLineActionsDirectory : ICommandLineActionsDirectory
    {
        public CommandLineActionsDirectory(IReadOnlyList<ICommandLineAction> actions)
        {
            Actions = actions;
        }

        public IReadOnlyList<ICommandLineAction> Actions { get; }
    }
}