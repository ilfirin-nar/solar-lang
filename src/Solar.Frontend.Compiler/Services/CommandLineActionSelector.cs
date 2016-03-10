using System;
using System.Collections.Generic;
using System.Linq;
using Solar.Frontend.Compiler.DataTransferObjects;
using Solar.Frontend.Compiler.Services.Actions;

namespace Solar.Frontend.Compiler.Services
{
    internal class CommandLineActionSelector : ICommandLineActionSelector
    {
        private readonly IReadOnlyList<ICommandLineAction> _actions;

        public CommandLineActionSelector(IReadOnlyList<ICommandLineAction> actions)
        {
            _actions = actions;
        }

        public Action<CompilerArguments> Select(CompilerArguments arguments)
        {
            return arguments.ShowHelp ? GetAction<ShowHelpAction>() : GetAction<CompileAction>();
        }

        private Action<CompilerArguments> GetAction<TAction>()
            where TAction : ICommandLineAction
        {
            return _actions.First(a => a is TAction).Action;
        }
    }
}