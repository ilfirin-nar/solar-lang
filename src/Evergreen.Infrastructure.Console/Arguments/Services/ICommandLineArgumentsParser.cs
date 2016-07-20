using System.Collections.Generic;
using Evergreen.Infrastructure.Common.Interfaces.InfrastructureLayer;
using Evergreen.Infrastructure.Console.Arguments.DataTransferObjects;

namespace Evergreen.Infrastructure.Console.Arguments.Services
{
    public interface ICommandLineArgumentsParser<out TCommandLineArguments> : IInfrastructureService
        where TCommandLineArguments : ICommandLineArguments, new()
    {
        TCommandLineArguments Parse(IEnumerable<string> args);
    }
}