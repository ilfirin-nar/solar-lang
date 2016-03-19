using System;
using Solar.Infrastructure.Common.Interfaces.InfrastructureLayer;
using Solar.Infrastructure.Console.Arguments.DataTransferObjects;

namespace Solar.Infrastructure.Console.Actions.Services
{
    public interface ICommandLineActionSelector<in TArguments> : IInfrastructureService
        where TArguments : ICommandLineArguments
    {
        Action<TArguments> Select(TArguments arguments);
    }
}