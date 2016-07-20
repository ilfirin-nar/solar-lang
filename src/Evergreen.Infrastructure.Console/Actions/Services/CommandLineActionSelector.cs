using System;
using System.Linq;
using Evergreen.Infrastructure.Common.Extensions.ObjectExtensions;
using Evergreen.Infrastructure.Console.Actions.Directory;
using Evergreen.Infrastructure.Console.Actions.Services.Exceptions;
using Evergreen.Infrastructure.Console.Arguments.Attributes;
using Evergreen.Infrastructure.Console.Arguments.DataTransferObjects;

namespace Evergreen.Infrastructure.Console.Actions.Services
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