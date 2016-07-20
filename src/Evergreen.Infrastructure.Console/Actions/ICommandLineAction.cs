using Evergreen.Infrastructure.Common.Interfaces.FrontendLayer;
using Evergreen.Infrastructure.Console.Arguments.DataTransferObjects;

namespace Evergreen.Infrastructure.Console.Actions
{
    public interface ICommandLineAction : IFrontendService {}

    public interface ICommandLineAction<in TArguments> : ICommandLineAction
        where TArguments : ICommandLineArguments
    {
        void Action(TArguments arguments);
    }
}