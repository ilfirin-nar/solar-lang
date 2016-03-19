using Solar.Infrastructure.Common.Interfaces.FrontendLayer;
using Solar.Infrastructure.Console.Arguments.DataTransferObjects;

namespace Solar.Infrastructure.Console.Actions
{
    public interface ICommandLineAction : IFrontendService {}

    public interface ICommandLineAction<in TArguments> : ICommandLineAction
        where TArguments : ICommandLineArguments
    {
        void Action(TArguments arguments);
    }
}