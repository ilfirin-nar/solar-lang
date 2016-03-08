using System.Collections.Generic;
using Solar.Infrastructure.Common.Interfaces.InfrastructureLayer;
using Solar.Infrastructure.Console.DataTransferObjects;

namespace Solar.Infrastructure.Console.Services
{
    public interface ICommandLineArgumentsParser<out TCommandLineArguments> : IInfrastructureService
        where TCommandLineArguments : ICommandLineArguments, new()
    {
        TCommandLineArguments Parse(IEnumerable<string> args);
    }
}