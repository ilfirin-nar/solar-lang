using System;
using System.Linq;
using Solar.Infrastructure.Common.Extensions.ObjectExtensions;
using Solar.Infrastructure.Console.Actions.Directory;
using Solar.Infrastructure.Console.Actions.Services.Exceptions;
using Solar.Infrastructure.Console.Arguments.Attributes;
using Solar.Infrastructure.Console.Arguments.DataTransferObjects;

namespace Solar.Infrastructure.Console.Actions.Services
{
    internal class CommandLineActionSelector<TArguments> : ICommandLineActionSelector<TArguments>
        where TArguments : ICommandLineArguments
    {
        private readonly ICommandLineActionsDirectory _actionsDirectory;

        public CommandLineActionSelector(ICommandLineActionsDirectory actionsDirectory)
        {
            _actionsDirectory = actionsDirectory;
        }

        public Action<TArguments> Select(TArguments arguments)
        {
            var attributes = arguments.GetPropertiesAttributes<ConsoleOptionAttribute>();
            foreach (var attribute in attributes.Where(attribute => attribute.BoundedActionType != null))
            {
                return GetAction(attribute.BoundedActionType);
            }
            throw new NoActionWasFoundException(arguments);
        }

        private Action<TArguments> GetAction(Type type)
        {
            var actionService = _actionsDirectory.Actions.First(a => a.GetType() == type);
            return ((ICommandLineAction<TArguments>) actionService).Action;
        }
    }
}