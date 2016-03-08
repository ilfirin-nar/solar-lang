using Solar.Infrastructure.Common.Interfaces.InfrastructureLayer;
using Solar.Infrastructure.Console.DataTransferObjects;

namespace Solar.Infrastructure.Console.Services
{
    public interface ICommandLineArgumentsParser : IInfrastructureService
    {
        ICommandLineArguments Parse(string[] args);
    }
}