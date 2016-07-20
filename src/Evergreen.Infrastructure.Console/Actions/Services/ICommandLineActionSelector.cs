using System;
using Evergreen.Infrastructure.Common.Interfaces.InfrastructureLayer;
using Evergreen.Infrastructure.Console.Arguments.DataTransferObjects;

namespace Evergreen.Infrastructure.Console.Actions.Services
{
    public interface ICommandLineActionSelector<in TArguments> : IInfrastructureService
        where TArguments : ICommandLineArguments
    {
        Action<TArguments> Select(TArguments arguments);
    }
}