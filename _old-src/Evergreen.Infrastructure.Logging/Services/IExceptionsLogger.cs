using System;
using Evergreen.Infrastructure.Common.Interfaces.InfrastructureLayer;
using JetBrains.Annotations;

namespace Evergreen.Infrastructure.Logging.Services
{
    public interface IExceptionsLogger : IInfrastructureService
    {
        void Log([NotNull] Exception exception);
    }
}