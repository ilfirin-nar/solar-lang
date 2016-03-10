using Solar.Frontend.Compiler.DataTransferObjects;
using Solar.Infrastructure.Common.Interfaces.FrontendLayer;

namespace Solar.Frontend.Compiler.Services.Actions
{
    public interface ICommandLineAction :IFrontendService
    {
        void Action(CompilerArguments arguments);
    }
}