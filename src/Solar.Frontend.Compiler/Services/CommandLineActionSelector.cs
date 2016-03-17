using System;
using System.Linq;
using Solar.Frontend.Compiler.DataTransferObjects;
using Solar.Frontend.Compiler.Services.Actions;

namespace Solar.Frontend.Compiler.Services
{
    internal class CommandLineActionSelector : ICommandLineActionSelector
    {
        private readonly ICommandLineActionsDirectory _actionsDirectory;

        public CommandLineActionSelector(ICommandLineActionsDirectory actionsDirectory)
        {
            _actionsDirectory = actionsDirectory;
        }

        public Action<ICompilerArguments> Select(ICompilerArguments arguments)
        {
            return arguments.ShowHelp ? GetAction<ShowHelpAction>() : GetAction<CompileAction>();
        }

        private Action<ICompilerArguments> GetAction<TAction>() where TAction : ICommandLineAction
        {
            return _actionsDirectory.Actions.First(a => a is TAction).Action;
        }
    }
}