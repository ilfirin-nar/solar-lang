using Solar.Infrastructure.Common.Exceptions;
using Solar.Infrastructure.Console.Arguments.DataTransferObjects;

namespace Solar.Infrastructure.Console.Actions.Services.Exceptions
{
    public class NoActionWasFoundException : InfrastructureException
    {
        private readonly string _argumentsTypeName;

        public NoActionWasFoundException(ICommandLineArguments arguments)
        {
            _argumentsTypeName = arguments.GetType().Name;
        }

        public override string Message => $"No action was found in arguments `{_argumentsTypeName}`";
    }
}