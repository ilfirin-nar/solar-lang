using Solar.Frontend.Compiler.DataTransferObjects;
using Solar.Infrastructure.Common.Interfaces.FrontendLayer;

namespace Solar.Frontend.Compiler.Services.Actions
{
    internal interface ICommandLineAction :IFrontendService
    {
        void Action(ICompilerArguments arguments);
    }
}