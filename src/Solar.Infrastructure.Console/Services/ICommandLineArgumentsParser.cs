using Solar.Infrastructure.Common.Interfaces.InfrastructureLayer;
using Solar.Infrastructure.Console.DataTransferObjects;

namespace Solar.Infrastructure.Console.Services
{
    public interface ICommandLineArgumentsParser<out TCommandLineArguments> : IInfrastructureService
        where TCommandLineArguments : ICommandLineArguments
    {
        TCommandLineArguments Parse(string[] args);
    }
}